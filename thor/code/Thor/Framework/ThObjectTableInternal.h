#pragma once

#include <Thor/Framework/ThObjectTable.h>
#include <Thor/Framework/Singleton.h>

#ifdef THOR_USE_TBB
	#include <tbb/concurrent_vector.h>
	#include <tbb/concurrent_queue.h>
#endif

namespace Thor
{

#ifdef THOR_USE_TBB

//----------------------------------------------------------------------------------------
//
//					ThObjectTableImpl
//
//----------------------------------------------------------------------------------------
class ThObjectTableImpl: public NonCopyable
{
public:
	static ThObjectTableImpl& Instance();

	ThiRtti*	GetObject(ThU32 handle);

	ThU32		GetObjectHandle(const ThUUID& uuid);

	ThU32		AddObject(ThiRtti* obj);

	void		RemoveObject(ThU32 handle);

	void		RemoveObject(ThiRtti* obj);

private:

	ThObjectTableImpl();

	typedef Singleton<ThObjectTableImpl> singleton_t;
	friend class Singleton<ThObjectTableImpl>;

	typedef tbb::concurrent_vector<ThiRtti*>		object_list_t;
	typedef tbb::concurrent_queue<ThU32>			handle_list_t;

	object_list_t	m_ObjectList;
	handle_list_t	m_FreeHandles;
	tbb::atomic<ThU32>			m_InsertIndex;
};

#else
//----------------------------------------------------------------------------------------
//
//					ThObjectTableImpl
//
//----------------------------------------------------------------------------------------
class ThObjectTableImpl: public NonCopyable
{
public:
	static ThObjectTableImpl& Instance();

	ThiRtti*	GetObject(ThU32 handle);

	ThU32		GetObjectHandle(const ThUUID& uuid);

	ThU32		AddObject(ThiRtti* obj);

	void		RemoveObject(ThU32 handle);

	void		RemoveObject(ThiRtti* obj);

private:

	ThObjectTableImpl();

	typedef Singleton<ThObjectTableImpl> singleton_t;
	friend class Singleton<ThObjectTableImpl>;

	typedef std::vector<ThiRtti*>		object_list_t;
	typedef std::vector<ThU32>			handle_list_t;

	tbb::spin_mutex m_Mutex;
	object_list_t	m_ObjectList;
	handle_list_t	m_FreeHandles;
	ThU32			m_MaxObjInsertIndex;
	ThU32			m_MaxFreeObjIndex;
};

#endif

}