#include <Thor/Framework/ThObjectTableInternal.h>
#include <Thor/Framework/ThiRtti.h>

namespace Thor
{
#ifdef THOR_USE_TBB

static const ThU32 g_ReserveSize = 512;
//----------------------------------------------------------------------------------------
//
//					ThObjectTableImpl
//
//----------------------------------------------------------------------------------------	
ThObjectTableImpl& ThObjectTableImpl::Instance()
{
	return singleton_t::Instance();
}
//----------------------------------------------------------------------------------------
ThiRtti* ThObjectTableImpl::GetObject(ThU32 handle)
{
	if( handle < m_ObjectList.size() )
		return m_ObjectList[handle];
	else
		return 0;
}
//----------------------------------------------------------------------------------------
ThU32 ThObjectTableImpl::GetObjectHandle(const ThUUID& uuid)
{
	for(ThU32 i = 0; i < m_ObjectList.size(); ++i)
	{
		if( m_ObjectList[i] && m_ObjectList[i]->GetUUID()==uuid )
			return i;
	}

	return UINT_MAX;
}
//----------------------------------------------------------------------------------------
ThU32 ThObjectTableImpl::AddObject(ThiRtti* obj)
{
	ThU32 recycledIdx = UINT_MAX;

	bool isRecycled = m_FreeHandles.try_pop(recycledIdx);

	if( isRecycled )//insert the object into previously freed slot
	{
		m_ObjectList[recycledIdx] = obj;
		return recycledIdx;
	}
	else//no prev freed slots -> insert to the end of the list
	{
		m_ObjectList.push_back(obj);
		return m_InsertIndex++;
	}
}
//----------------------------------------------------------------------------------------
void ThObjectTableImpl::RemoveObject(ThU32 handle)
{
	if( handle < m_ObjectList.size() )
	{
		m_ObjectList[handle] = 0;
		m_FreeHandles.push(handle);
	}
}
//----------------------------------------------------------------------------------------
void ThObjectTableImpl::RemoveObject(ThiRtti* obj)
{
	for(ThU32 i = 0; i < m_ObjectList.size(); ++i)//find the object in the table
	{
		if( m_ObjectList[i] == obj )
		{
			RemoveObject(i);
			return;
		}
	}
}
//----------------------------------------------------------------------------------------
ThObjectTableImpl::ThObjectTableImpl()
{
	m_InsertIndex = 0;
	m_ObjectList.reserve(g_ReserveSize);
}

#else

static const ThU32 g_ReserveSize = 128;

template <class VecT>
void	GrowVector(VecT& vec, ThU32 sz)
{
	typedef typename VecT::value_type value_type;
	ThU32 oldSize = vec.size();
	ThU32 newSize = oldSize + sz;
	vec.reserve(newSize);
	memset(&vec[oldSize+1], 0, sizeof(value_type) * sz);
}
//----------------------------------------------------------------------------------------
//
//					ThObjectTableImpl
//
//----------------------------------------------------------------------------------------	
ThObjectTableImpl& ThObjectTableImpl::Instance()
{
	return singleton_t::Instance();
}
//----------------------------------------------------------------------------------------
ThiRtti* ThObjectTableImpl::GetObject(ThU32 handle)
{
	tbb::spin_mutex::scoped_lock lock(m_Mutex);

	if( handle < m_ObjectList.size() )
		return m_ObjectList[handle];
	else
		return 0;
}
//----------------------------------------------------------------------------------------
ThU32 ThObjectTableImpl::GetObjectHandle(const ThUUID& uuid)
{
	tbb::spin_mutex::scoped_lock lock(m_Mutex);

	for(ThU32 i = 0; i < m_ObjectList.size(); ++i)
	{
		if( m_ObjectList[i] && m_ObjectList[i]->GetUUID()==uuid )
			return i;
	}

	return UINT_MAX;
}
//----------------------------------------------------------------------------------------
ThU32 ThObjectTableImpl::AddObject(ThiRtti* obj)
{
	tbb::spin_mutex::scoped_lock lock(m_Mutex);

	if( m_FreeHandles.size() )//insert the object into previously freed slot
	{
		ThU32 idx = m_FreeHandles.back();
		m_FreeHandles.pop_back();
		m_ObjectList[idx] = obj;
		--m_MaxFreeObjIndex;
		return idx;
	}
	else//no prev freed slots -> insert to the end of the list
	{
		if(m_MaxObjInsertIndex >= m_ObjectList.size())//check the need to update the table size
			GrowVector(m_ObjectList, g_ReserveSize);

		m_ObjectList.push_back(obj);
		return m_MaxObjInsertIndex++;
	}
}
//----------------------------------------------------------------------------------------
void ThObjectTableImpl::RemoveObject(ThU32 handle)
{
	tbb::spin_mutex::scoped_lock lock(m_Mutex);

	if( handle < m_ObjectList.size() )
	{
		m_ObjectList[handle]=0;

		if(m_MaxFreeObjIndex >= m_FreeHandles.size() )//check if we need to update the free list size
			GrowVector(m_FreeHandles, g_ReserveSize);

		++m_MaxFreeObjIndex;
	}
}
//----------------------------------------------------------------------------------------
void ThObjectTableImpl::RemoveObject(ThiRtti* obj)
{
	for(ThU32 i = 0; i < m_ObjectList.size(); ++i)//find the object in the table
	{
		if( m_ObjectList[i] == obj )
		{
			RemoveObject(i);
			return;
		}
	}
}
//----------------------------------------------------------------------------------------
ThObjectTableImpl::ThObjectTableImpl()
{
	m_MaxObjInsertIndex = 0;
	m_MaxFreeObjIndex = 0;
	GrowVector(m_ObjectList, g_ReserveSize);
	GrowVector(m_FreeHandles, g_ReserveSize);
}
#endif
}