#include <Thor/Framework/ThAsyncOpManager.h>
#include <Thor/Framework/Filesystem/ThiFileSystem.h>
#include <functional>

namespace Thor
{
THOR_REG_TYPE(ThFileAsyncResult, THOR_TYPELIST_1(ThiAsyncResult));
THOR_REG_TYPE(ThAsyncOpManager, THOR_TYPELIST_1(ThiObject));
//----------------------------------------------------------------------------------------
//
//					ThFileAsyncResult
//
//----------------------------------------------------------------------------------------
ThFileAsyncResult::ThFileAsyncResult()
	:
m_Complete(false),
m_Cancelled(false),
m_Buf(0),
m_BufOffset(0),
m_Size(0),
m_IsReadOp(true)
{
	//
}
//----------------------------------------------------------------------------------------
ThFileAsyncResult::ThFileAsyncResult(ThBool isReadOp, const ThiFileStreamPtr& file, const void* buf, ThSize bufOffset, ThSize size, const ThiAsyncResultCallback& callback)
	:
m_File(file),
m_Complete(false),
m_Cancelled(false),
m_IsReadOp(isReadOp),
m_Buf( const_cast<void*>(buf) ),
m_BufOffset(bufOffset),
m_Size(size),
m_Callback(callback)
{
	//
}
//----------------------------------------------------------------------------------------
ThiType* ThFileAsyncResult::GetType()const
{
	return ThType<ThFileAsyncResult>::Instance();
}
//----------------------------------------------------------------------------------------
ThBool ThFileAsyncResult::IsComplete()const
{
	return m_Complete;
}
//----------------------------------------------------------------------------------------
ThBool ThFileAsyncResult::Cancel()
{
	m_Cancelled = true;
	return true;
}
//----------------------------------------------------------------------------------------
const ThiFileStreamPtr& ThFileAsyncResult::GetFile()const
{
	return m_File;
}
//----------------------------------------------------------------------------------------
const void* ThFileAsyncResult::GetBuffer()const
{
	return m_Buf;
}
//----------------------------------------------------------------------------------------
ThSize ThFileAsyncResult::GetSize()const
{
	return m_Size;
}
//----------------------------------------------------------------------------------------
ThSize ThFileAsyncResult::GetBufferOffset()const
{
	return m_BufOffset;
}
//----------------------------------------------------------------------------------------
//
//					ThAsyncOpManager
//
//----------------------------------------------------------------------------------------
ThAsyncOpManager::ThAsyncOpManager()
	:
m_Thread(std::bind(&ThAsyncOpManager::Process, this)),
m_Suspended(false)
{
	//
}
//----------------------------------------------------------------------------------------
ThiType* ThAsyncOpManager::GetType()const
{
	return ThType<ThAsyncOpManager>::Instance();
}
//----------------------------------------------------------------------------------------
void ThAsyncOpManager::Process()
{
	ThiAsyncResultPtr ar;
	
	while( true )
	{
		//if we have requests - process them
		if(m_WorkItems.try_pop(ar))
		{
			ThFileAsyncResultPtr item = ObjectCast<ThFileAsyncResult>(ar);

			if(item && !item->m_Cancelled && item->m_File)//op not cancelled and is in valid state
			{
				ThI8* buf = (ThI8*)item->m_Buf;
				buf += item->m_BufOffset;

				if(item->m_IsReadOp)
					item->m_File->Read(buf, item->m_Size);
				else
					item->m_File->Write(buf, item->m_Size);

				item->m_Complete = true;
				item->m_Callback(ar);
			}
		}
	}
}
//----------------------------------------------------------------------------------------
void ThAsyncOpManager::AddWorkItem(const ThiAsyncResultPtr& item)
{
	m_WorkItems.push(item);

	
}
//----------------------------------------------------------------------------------------
void ThAsyncOpManager::Update()
{
	if(m_WorkItems.empty())
		SetThreadState(true);
	else
		SetThreadState(false);
}
//----------------------------------------------------------------------------------------
void ThAsyncOpManager::SetThreadState(ThBool suspend)
{
	if(m_Suspended != suspend)
	{
		mutex_t::scoped_lock lock(m_Mutex);//not really necessary as im going to call this from the main thread only
		m_Suspended = suspend;

#ifdef THOR_MS_WIN
		if(suspend)
			SuspendThread(m_Thread.native_handle());
		else
			ResumeThread(m_Thread.native_handle());
#else
	#error "Implement thread state switch"
#endif
	}
}

}