#include <stdlib.h>
//#include <Thor/Framework/FrameworkFwd.h>
#include <Thor/Framework/ThMemory.h>
#include <Thor/Framework/TypeLists.h>
#include <map>
#include <string>

using namespace Thor;
#if MALLOC_LD_PRELOAD

/*** service functions and variables ***/

#include <unistd.h> // for sysconf
#include <dlfcn.h>

static long memoryPageSize;

static inline void initPageSize()
{
	memoryPageSize = sysconf(_SC_PAGESIZE);
}

/* For the expected behaviour (i.e., finding malloc/free/etc from libc.so, 
not from ld-linux.so) dlsym(RTLD_NEXT) should be called from 
a LD_PRELOADed library, not another dynamic library.
So we have to put find_original_malloc here.
*/
extern "C" bool __TBB_internal_find_original_malloc(int num, const char *names[],
													void *ptrs[])
{
	for (int i=0; i<num; i++)
		if (NULL == (ptrs[i] = dlsym (RTLD_NEXT, names[i])))
			return false;

	return true;
}

/* __TBB_malloc_proxy used as a weak symbol by libtbbmalloc for: 
1) detection that the proxy library is loaded
2) check that dlsym("malloc") found something different from our replacement malloc
*/
extern "C" void *__TBB_malloc_proxy() __attribute__ ((alias ("malloc")));

#ifndef __THROW
#define __THROW
#endif

/*** replacements for malloc and the family ***/

extern "C" {

	void *malloc(size_t size) __THROW
	{
		return __TBB_internal_malloc(size);
	}

	void * calloc(size_t num, size_t size) __THROW
	{
		return __TBB_internal_calloc(num, size);
	}

	void free(void *object) __THROW
	{
		__TBB_internal_free(object);
	}

	void * realloc(void* ptr, size_t sz) __THROW
	{
		return __TBB_internal_realloc(ptr, sz);
	}

	int posix_memalign(void **memptr, size_t alignment, size_t size) __THROW
	{
		return __TBB_internal_posix_memalign(memptr, alignment, size);
	}

	/* The older *NIX interface for aligned allocations;
	it's formally substituted by posix_memalign and deprecated,
	so we do not expect it to cause cyclic dependency with C RTL. */
	void * memalign(size_t alignment, size_t size)  __THROW
	{
		return scalable_aligned_malloc(size, alignment);
	}

	/* valloc allocates memory aligned on a page boundary */
	void * valloc(size_t size) __THROW
	{
		if (! memoryPageSize) initPageSize();

		return scalable_aligned_malloc(size, memoryPageSize);
	}

	/* pvalloc allocates smallest set of complete pages which can hold 
	the requested number of bytes. Result is aligned on page boundary. */
	void * pvalloc(size_t size) __THROW
	{
		if (! memoryPageSize) initPageSize();
		// align size up to the page size
		size = ((size-1) | (memoryPageSize-1)) + 1;

		return scalable_aligned_malloc(size, memoryPageSize);
	}

	int mallopt(int /*param*/, int /*value*/) __THROW
	{
		return 1;
	}

} /* extern "C" */

#if __linux__
#include <malloc.h>
#include <string.h> // for memset

extern "C" struct mallinfo mallinfo() __THROW
{
	struct mallinfo m;
	memset(&m, 0, sizeof(struct mallinfo));

	return m;
}
#endif /* __linux__ */

/*** replacements for global operators new and delete ***/

#include <new>

void* operator new(size_t sz) throw ()
{
	return Private::ThMemoryToolbox::MallocOrThrow(sz);
}

void* operator new[](size_t sz) throw ()
{
	return Private::ThMemoryToolbox::MallocOrThrow(sz);
}

void operator delete(void* ptr) throw()
{
	ThMemory::Free(ptr);
}

void operator delete[](void* ptr) throw()
{
	ThMemory::Free(ptr);
}

void* operator new(size_t sz, const std::nothrow_t&) throw()
{
	return ThMemory::Malloc(sz);
}

void* operator new[](std::size_t sz, const std::nothrow_t&) throw()
{
	return ThMemory::Malloc(sz);
}

void operator delete(void* ptr, const std::nothrow_t&) throw()
{
	ThMemory::Free(ptr);
}

void operator delete[](void* ptr, const std::nothrow_t&) throw()
{
	ThMemory::Free(ptr);
}

#endif /* MALLOC_LD_PRELOAD */


#ifdef _WIN32
#include <windows.h>
#include <stdio.h>
#include <Thor/Framework/tbb_function_replacement.h>
#include <new>

//----------------------------------------------------------------------------------------
struct eModule
{
	enum Val
	{
		Msvcr80d,
		Msvcr80,
		Msvcr90d,
		Msvcr90,
		Msvcr70d,
		Msvcr70,
		Msvcr71d,
		Msvcr71,
		Msvcr100d,
		Msvcr100,
		Msvcr110d,
		Msvcr110
	};
};
//----------------------------------------------------------------------------------------
static const char* modules_to_replace[] = {
	"msvcr70d.dll",
	"msvcr70.dll",
	"msvcr71d.dll",
	"msvcr71.dll",
	"msvcr80d.dll",
	"msvcr80.dll",
	"msvcr90d.dll",
	"msvcr90.dll",
	"msvcr100d.dll",
	"msvcr100.dll",
	"msvcr110d.dll",
	"msvcr110.dll"
};
//----------------------------------------------------------------------------------------
template <eModule::Val module>
struct ThModule
{
	static const char* GetName()
	{
		return modules_to_replace[module];
	}
};
//----------------------------------------------------------------------------------------
typedef THOR_TYPELIST_12(
	ThModule<eModule::Msvcr70d>,
	ThModule<eModule::Msvcr70>,
	ThModule<eModule::Msvcr71d>,
	ThModule<eModule::Msvcr71>,
	ThModule<eModule::Msvcr80d>,
	ThModule<eModule::Msvcr80>,
	ThModule<eModule::Msvcr90d>,
	ThModule<eModule::Msvcr90>,
	ThModule<eModule::Msvcr100d>,
	ThModule<eModule::Msvcr100>,
	ThModule<eModule::Msvcr110d>,
	ThModule<eModule::Msvcr110>
)
ThReplacedModules;
//----------------------------------------------------------------------------------------
template<class Module, template<typename T> class Func >
struct PatchModules
{
	static void Process()
	{
		Func<Module>::Replace();
	}
};
//----------------------------------------------------------------------------------------
template< template<typename T> class Func >
struct PatchModules<NullType, Func>
{
	static void Process()
	{
		//
	}
};
//----------------------------------------------------------------------------------------
template<class Head, class Tail, template<typename T> class Func>
struct PatchModules< Typelist<Head, Tail>, Func >
{
	static void Process()
	{
		PatchModules<Head, Func>::Process();
		PatchModules<Tail, Func>::Process();
	}	
};
//----------------------------------------------------------------------------------------
// limit is 30 bytes/60 symbols per line
const char* known_bytecodes[] = {
#if _WIN64
	"4883EC284885C974",       //release free() win64
	"4883EC384885C975",       //release msize() win64
	"4885C974375348",         //release free() 8.0.50727.42 win64
	"48894C24084883EC28BA",   //debug prologue for win64
	"4C8BC1488B0DA6E4040033", //win64 SDK
	"4883EC284885C975",       //release msize() 10.0.21003.1 win64
#else
	"558BEC6A018B",				//debug free() & _msize() 8.0.50727.4053 win32
	"6A1868********E8",			//release free() 8.0.50727.4053 win32
	"6A1C68********E8",			//release _msize() 8.0.50727.4053 win32
	"558BEC837D08000F",			//release _msize() 11.0.51106.1 win32
	"8BFF558BEC6A",				//debug free() & _msize() 9.0.21022.8 win32
	"8BFF558BEC8B",				//debug array delete & _aligned_free 9.0.30729 win32
	"8BFF558BEC5D",				//release array delete & _aligned_free 9.0.30729 win32	
	"8BFF558BEC83",           //debug free() & _msize() 10.0.21003.1 win32
#endif
	NULL
};

/*
We need to replace following functions:
malloc
calloc
realloc
free
_msize
_aligned_malloc
_aligned_realloc
_aligned_free
??2@YAPAXI@Z      operator new                         (ia32)
??_U@YAPAXI@Z     void * operator new[] (size_t size)  (ia32)
??3@YAXPAX@Z      operator delete                      (ia32)  
??_V@YAXPAX@Z     operator delete[]                    (ia32)
??2@YAPEAX_K@Z    void * operator new(unsigned __int64)   (intel64)
??_V@YAXPEAX@Z    void * operator new[](unsigned __int64) (intel64)
??3@YAXPEAX@Z     operator delete                         (intel64)  
??_V@YAXPEAX@Z    operator delete[]                       (intel64)
??2@YAPAXIABUnothrow_t@std@@@Z      void * operator new (size_t sz, const std::nothrow_t&) throw()  (optional)
??_U@YAPAXIABUnothrow_t@std@@@Z     void * operator new[] (size_t sz, const std::nothrow_t&) throw() (optional)
*/
//----------------------------------------------------------------------------------------
struct ThReplaceFuncBase
{	
protected:
	static void DoReplacement(const char* moduleName,const char* funcToReplace, FRR_ON_ERROR onError, FUNCPTR replaceFunc, FUNCPTR* origFunc)
	{
		FRR_TYPE type = FRR_NODLL;

		if(origFunc)
			type = ReplaceFunction( moduleName, funcToReplace, replaceFunc, known_bytecodes, origFunc );
		else
		{
			// in Microsoft* Visual Studio* 11 Beta 32-bit operator delete consists of 2 bytes only: short jump to free(ptr);
			// replacement should be skipped for this particular case.
			if ( (strcmp(moduleName, "msvcr110.dll") == 0) && (strcmp(funcToReplace, "??3@YAXPAX@Z") == 0) ) 
				return;

			type = ReplaceFunction( moduleName, funcToReplace, replaceFunc, 0, 0 );
		}

		if (type == FRR_NODLL) return;

		if (type != FRR_OK && onError==FRR_FAIL)
		{
			fprintf(stderr, "Failed to replace function %s in module %s\n",
				funcToReplace, moduleName);
			exit(1);
		}
	}	
};
//----------------------------------------------------------------------------------------
template <class Module, template<class M> class Func>
struct ThReplaceFunc: public ThReplaceFuncBase
{
	static FUNCPTR m_OrigFunc;
};

template <class Module, template<class M> class Func>
FUNCPTR ThReplaceFunc<Module, Func>::m_OrigFunc=0;
//----------------------------------------------------------------------------------------
template <class Module>
struct ThReplaceMalloc: public ThReplaceFunc<Module, ThReplaceMalloc>
{
	static void Replace()
	{
		DoReplacement(Module::GetName(), "malloc", FRR_FAIL, (FUNCPTR)ThMemory::Malloc, 0);
	}
};
//----------------------------------------------------------------------------------------
template <class Module>
struct ThReplaceCalloc: public ThReplaceFunc<Module, ThReplaceCalloc>
{
	static void Replace()
	{
		DoReplacement(Module::GetName(), "calloc", FRR_FAIL, (FUNCPTR)ThMemory::Calloc, 0);
	}
};
//----------------------------------------------------------------------------------------
template <class Module>
struct ThReplaceRealloc: public ThReplaceFunc<Module, ThReplaceRealloc>
{
	static void Replace()
	{
		DoReplacement(Module::GetName(), "realloc", FRR_FAIL, (FUNCPTR)ThMemory::Realloc, 0);
	}
};
//----------------------------------------------------------------------------------------
template <class Module>
struct ThReplaceFree: public ThReplaceFunc<Module, ThReplaceFree>
{
	static void Replace()
	{
		DoReplacement(Module::GetName(), "free", FRR_FAIL, (FUNCPTR)ThReplaceFree::Free, &m_OrigFunc);
	}

	typedef void (*orig_func_t)(void*);

	static void Free(void* ptr)
	{
		if( ThMemory::IsCustomAllocatedMemory(ptr) )
		{
			ThMemory::Free(ptr);
		}
		else
		{
			assert(m_OrigFunc && "Original func does not exist");
			orig_func_t orig = (orig_func_t)m_OrigFunc;
			orig(ptr);
		}
	}
};
//----------------------------------------------------------------------------------------
template <class Module>
struct ThReplaceMsize: public ThReplaceFunc<Module, ThReplaceMsize>
{
	static void Replace()
	{
		DoReplacement(Module::GetName(), "_msize", FRR_FAIL, (FUNCPTR)ThReplaceMsize::Msize, &m_OrigFunc);
	}

	typedef void (*orig_func_t)(void*);

	static void Msize(void* ptr)
	{
		if( ThMemory::IsCustomAllocatedMemory(ptr) )
		{
			ThMemory::Msize(ptr);
		}
		else
		{
			assert(m_OrigFunc && "Original func does not exist");
			orig_func_t orig = (orig_func_t)m_OrigFunc;
			orig(ptr);
		}
	}
};
//----------------------------------------------------------------------------------------
template <class Module>
struct ThReplaceAlignedMalloc: public ThReplaceFunc<Module, ThReplaceAlignedMalloc>
{
	static void Replace()
	{
		DoReplacement(Module::GetName(), "_aligned_malloc", FRR_FAIL, (FUNCPTR)ThMemory::Malloc, 0);
	}
};
//----------------------------------------------------------------------------------------
template <class Module>
struct ThReplaceAlignedRealloc: public ThReplaceFunc<Module, ThReplaceAlignedRealloc>
{
	static void Replace()
	{
		DoReplacement(Module::GetName(), "_aligned_realloc", FRR_FAIL, (FUNCPTR)ThMemory::Realloc, 0);
	}
};
//----------------------------------------------------------------------------------------
template <class Module>
struct ThReplaceAlignedFree: public ThReplaceFunc<Module, ThReplaceAlignedFree>//use free as original func
{
	static void Replace()
	{
		DoReplacement(Module::GetName(), "_aligned_free", FRR_FAIL, (FUNCPTR)ThReplaceAlignedFree::AlignedFree, &m_OrigFunc);
	}

	typedef void (*orig_func_t)(void*);

	static void AlignedFree(void* ptr)
	{
		if( ThMemory::IsCustomAllocatedMemory(ptr) )
		{
			ThMemory::AlignedFree(ptr);
		}
		else
		{
			assert(m_OrigFunc && "Original func does not exist");
			orig_func_t orig = (orig_func_t)m_OrigFunc;
			orig(ptr);
		}
	}
};
//----------------------------------------------------------------------------------------
#if _MSC_VER && !defined(__INTEL_COMPILER)
#pragma warning( push )
#pragma warning( disable : 4290 )
#endif

template <class Module>
struct ThReplaceOperatorNew: public ThReplaceFunc<Module, ThReplaceOperatorNew>
{
	static void Replace()
	{
#if _WIN64
		DoReplacement(Module::GetName(), "??2@YAPEAX_K@Z", FRR_FAIL, (FUNCPTR)ThReplaceOperatorNew::OperatorNew, 0);
#else
		DoReplacement(Module::GetName(), "??2@YAPAXI@Z", FRR_FAIL, (FUNCPTR)ThReplaceOperatorNew::OperatorNew, 0);
#endif
	}

	static void* OperatorNew(size_t sz) 
	{
		return Private::ThMemoryToolbox::MallocOrThrow(sz);
	}
};
//----------------------------------------------------------------------------------------
template <class Module>
struct ThReplaceOperatorArrayNew: public ThReplaceFunc<Module, ThReplaceOperatorArrayNew>
{
	static void Replace()
	{
#if _WIN64
		DoReplacement(Module::GetName(), "??_U@YAPEAX_K@Z", FRR_FAIL, (FUNCPTR)ThReplaceOperatorArrayNew::OperatorArrayNew, 0);
#else
		DoReplacement(Module::GetName(), "??_U@YAPAXI@Z", FRR_FAIL, (FUNCPTR)ThReplaceOperatorArrayNew::OperatorArrayNew, 0);
#endif	
	}

	static void* OperatorArrayNew(size_t sz) 
	{
		return Private::ThMemoryToolbox::MallocOrThrow(sz);
	}
};
//----------------------------------------------------------------------------------------
template <class Module>
struct ThReplaceOperatorDelete: public ThReplaceFunc<Module, ThReplaceOperatorDelete>
{
	static void Replace()
	{
#if _WIN64
		DoReplacement(Module::GetName(), "??3@YAXPEAX@Z", FRR_FAIL, (FUNCPTR)ThReplaceOperatorDelete::OperatorDelete, &m_OrigFunc);
#else
		DoReplacement(Module::GetName(), "??3@YAXPAX@Z", FRR_FAIL, (FUNCPTR)ThReplaceOperatorDelete::OperatorDelete, &m_OrigFunc);
#endif
	}

	typedef void (*orig_func_t)(void*);

	static void OperatorDelete(void* ptr)
	{
		if( ThMemory::IsCustomAllocatedMemory(ptr) )
		{
			ThMemory::Free(ptr);
		}
		else
		{
			assert(m_OrigFunc && "Original func does not exist");
			orig_func_t orig = (orig_func_t)m_OrigFunc;
			orig(ptr);
		}
	}	
};
//----------------------------------------------------------------------------------------
#if _MSC_VER && !defined(__INTEL_COMPILER)
#pragma warning( pop )
#endif

//----------------------------------------------------------------------------------------
template <class Module>
struct ThReplaceOperatorArrayDelete: public ThReplaceFunc<Module, ThReplaceOperatorArrayDelete>
{
	static void Replace()
	{
#if _WIN64
		DoReplacement(Module::GetName(), "??_V@YAXPEAX@Z", FRR_FAIL, (FUNCPTR)ThReplaceOperatorArrayDelete::OperatorArrayDelete, &m_OrigFunc);
#else
		DoReplacement(Module::GetName(), "??_V@YAXPAX@Z", FRR_FAIL, (FUNCPTR)ThReplaceOperatorArrayDelete::OperatorArrayDelete, &m_OrigFunc);
#endif
	}

	typedef void (*orig_func_t)(void*);

	static void OperatorArrayDelete(void* ptr)
	{
		if( ThMemory::IsCustomAllocatedMemory(ptr) )
		{
			ThMemory::Free(ptr);
		}
		else
		{
			assert(m_OrigFunc && "Original func does not exist");
			orig_func_t orig = (orig_func_t)m_OrigFunc;
			orig(ptr);
		}
	}	
};
//----------------------------------------------------------------------------------------
template <class Module>
struct ThReplaceOperatorNewThrow: public ThReplaceFunc<Module, ThReplaceOperatorNewThrow>
{
	static void Replace()
	{
		DoReplacement(Module::GetName(), "??2@YAPAXIABUnothrow_t@std@@@Z", FRR_IGNORE, (FUNCPTR)ThReplaceOperatorNewThrow::OperatorNew, 0);	
	}

	static void* OperatorNew(size_t sz, const std::nothrow_t& n) throw()
	{
		return ThMemory::Malloc(sz);
	}
};
//----------------------------------------------------------------------------------------
template <class Module>
struct ThReplaceOperatorArrayNewThrow: public ThReplaceFunc<Module, ThReplaceOperatorArrayNewThrow>
{
	static void Replace()
	{
		DoReplacement(Module::GetName(), "??_U@YAPAXIABUnothrow_t@std@@@Z", FRR_IGNORE, (FUNCPTR)ThReplaceOperatorArrayNewThrow::OperatorArrayNew, 0);	
	}

	static void* OperatorArrayNew(size_t sz, const std::nothrow_t& n) throw()
	{
		return ThMemory::Malloc(sz);
	}
};
//----------------------------------------------------------------------------------------
void DoPatchModules()
{
#ifdef THOR_USE_TBB_MALLOC
	PatchModules<ThReplacedModules, ThReplaceMalloc>::Process();
	PatchModules<ThReplacedModules, ThReplaceCalloc>::Process();
	PatchModules<ThReplacedModules, ThReplaceRealloc>::Process();
	PatchModules<ThReplacedModules, ThReplaceFree>::Process();
	PatchModules<ThReplacedModules, ThReplaceMsize>::Process();
	PatchModules<ThReplacedModules, ThReplaceAlignedMalloc>::Process();
	PatchModules<ThReplacedModules, ThReplaceAlignedRealloc>::Process();
	PatchModules<ThReplacedModules, ThReplaceAlignedFree>::Process();
#endif
	PatchModules<ThReplacedModules, ThReplaceOperatorNew>::Process();
	PatchModules<ThReplacedModules, ThReplaceOperatorDelete>::Process();
	PatchModules<ThReplacedModules, ThReplaceOperatorArrayNew>::Process();
	PatchModules<ThReplacedModules, ThReplaceOperatorArrayDelete>::Process();
	//PatchModules<ThReplacedModules, ThReplaceOperatorNewThrow>::Process();
	//PatchModules<ThReplacedModules, ThReplaceOperatorArrayNewThrow>::Process();
}
//----------------------------------------------------------------------------------------
extern "C" BOOL WINAPI DllMain( HINSTANCE hInst, DWORD callReason, LPVOID reserved )
{	
	if ( callReason==DLL_PROCESS_ATTACH && reserved && hInst )
	{
#ifdef THOR_OVERLOAD_GLOBAL_NEW
		DoPatchModules();		
#endif
	}

	if ( callReason==DLL_PROCESS_DETACH && reserved && hInst )
	{
		
	}
	return TRUE;
}

#endif //_WIN32
