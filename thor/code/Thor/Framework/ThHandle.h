#pragma once

#include <Thor/Framework/Common.h>
#include <Thor/Framework/ThUUID.h>
#include <Thor/Framework/ThObjectTable.h>
#include <Thor/Framework/ThObjectUtils.h>
#include "limits.h"

#define THOR_DECLARE_HANDLE(typeName)\
	typedef ThHandle<typeName> typeName##Hdl;

namespace Thor
{

template <class Type>
class ThHandle
{
public:

	ThHandle()
	{
		m_ObjectHandle = UINT_MAX;
	}

	template <class X>
	ThHandle(const ThHandle<X>& handle)
		:
	m_ObjectHandle(handle.m_ObjectHandle),
	m_ObjectUUID(handle.m_ObjectUUID)
	{
		typedef std::tr1::is_convertible<X, Type> check_t;
		THOR_STATIC_ASSERT(check_t::value, "Inconvertible types");
	}

	ThHandle(ThU32 handle)
		:
	m_ObjectHandle(handle)
	{
		ThiRtti* obj = ThObjectTable::GetObject(m_ObjectHandle);

		if(obj)
			m_ObjectUUID = obj->GetUUID();
	}

	ThHandle(ThU32 handle, const ThUUID& uuid)
		:
	m_ObjectHandle(handle),
	m_ObjectUUID(uuid)
	{
		//
	}

	ThHandle(const ThUUID& uuid)
		:
	m_ObjectHandle(UINT_MAX),
	m_ObjectUUID(uuid)
	{
		//
	}

	const ThHandle& operator=(const ThHandle& rhs)
	{
		m_ObjectHandle = rhs.m_ObjectHandle;
		m_ObjectUUID = rhs.m_ObjectUUID;
		return *this;
	}

	ThBool operator==(const ThHandle& rhs)
	{
		return m_ObjectHandle == rhs.m_ObjectHandle && m_ObjectUUID == rhs.m_ObjectUUID;
	}

	operator bool()const
	{
		return Get()!=0;		
	}	

	Type* operator->()const
	{
		return ThObjectTable::GetObject(m_ObjectHandle);
	}

	Type* Get()const
	{
		Type* obj = 0;

		if(m_ObjectHandle == UINT_MAX && !m_ObjectUUID.IsNil())
		{
			m_ObjectHandle = ThObjectTable::GetObjectHandle(m_ObjectUUID);
		}

		if(m_ObjectHandle < UINT_MAX)
		{
			obj = TypeCast<Type>( ThObjectTable::GetObject(m_ObjectHandle) );
			if( obj && m_ObjectUUID != obj->GetUUID() )
				obj = 0;
		}		

		return obj;
	}

private:
	ThUUID	m_ObjectUUID;
	mutable tbb::atomic<ThU32>	m_ObjectHandle;	
};

}