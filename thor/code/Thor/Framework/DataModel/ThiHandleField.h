#pragma once

#include <Thor/Framework/DataModel/ThiField.h>
#include <Thor/Framework/DataModel/ThFieldTraits.h>
#include <Thor/Framework/ThMutexPolicy.h>

namespace Thor
{
//----------------------------------------------------------------------------------------
//
//					ThiHandleFieldProxy
//
//----------------------------------------------------------------------------------------
template <bool ThreadSafe>
class ThiHandleFieldProxy: public ThiFieldProxy<ThreadSafe>
{
public:

	ThiHandleFieldProxy()
	{

	}

	ThiHandleFieldProxy(const ThiHandleFieldProxy& other)
		:
	ThiFieldProxy(other)
	{

	}

	THOR_DM_VIRTUAL ThiType*		GetType()const
	{
		return ThType< ThiHandleFieldProxy<false> >::Instance();
	}

#ifndef THOR_DM_THIFIELD_NOVIRTUALS
	virtual ThiType*		GetReferencedEntityType()const = 0;
#endif

protected:

	const ThiHandleFieldProxy& operator=(const ThiHandleFieldProxy& other)
	{

	}
};

typedef ThiHandleFieldProxy<false> ThiHandleField;

THOR_DECL_TYPE(Thor::ThiHandleField);

namespace Private
{
	//----------------------------------------------------------------------------------------
	//
	//					ThHandleFieldUtils
	//
	//----------------------------------------------------------------------------------------
	struct ThHandleFieldUtils
	{
		template <class T, class FieldT>
		static void SerializeImpl(ThiArchiveWriter* archive, const ThI8* fieldName, const FieldT* handle, const ThHandle<T>& handleVal)
		{
			THOR_ASSERT(0, "Not Implemented");
		}

		template <class T, class FieldT>
		static void DeserializeImpl(ThiArchiveReader* archive, const ThI8* fieldName, const FieldT* handle, ThHandle<T>& handleVal)
		{
			THOR_ASSERT(0, "Not Implemented");
		}
	};
}
//----------------------------------------------------------------------------------------
//
//					ThHandleField
//
//----------------------------------------------------------------------------------------
template<class T>
class ThHandleField: public ThiHandleFieldProxy<true>
{
public:

	typedef ThHandle<T> ValueType;

	ThHandleField()
	{
		m_Flags.SetFlag(true, Private::eFieldFlags::IsDefaultValue);
	}

	ThHandleField(const ValueType& initVal)
		:
	m_Value(initVal)
	{
		m_Flags.SetFlag(true, Private::eFieldFlags::IsDefaultValue);
	}

	ThHandleField(const ThHandleField& other)
		:
	ThiHandleFieldProxy<true>(other)
	{
		*this = other;
	}

	const ThHandleField& operator=(const ThHandleField& other)
	{
		m_Value = other.m_Value;
		return *this;
	}

	const ThHandleField& operator=(const ThHandle<T>& other)
	{
		SetValue(other);
		return *this;
	}

	ThBool operator==(const ThHandle<T>& other)const
	{
		T* selfPtr = m_Value.Get();
		T* otherPtr = other.Get();

		if (selfPtr == 0)
		{
			if (otherPtr == 0)
			{
				// null == null = true. 
				return true;
			}

			// Only the left side is null. 
			return false;
		}

		return selfPtr->Equals(otherPtr);
	}

	ThBool operator!=(const ThHandle<T>& other)const
	{
		return !operator==(other);
	}

	ThBool operator==(const ThHandleField& other)const
	{
		return operator==(other.GetValue());
	}

	ThBool operator!=(const ThHandleField& other)const
	{
		return !operator==(other.GetValue());
	}

	THOR_DM_VIRTUAL ThiType*		GetReferencedEntityType()const
	{
		return ThType<typename ThFieldTraits<T>::FieldType>::Instance();
	}

	void SetValue(const ThHandle<T>& value)
	{
		ScopedLock lock;
		InitScopedLock(lock);

		SetDirty(true);
		m_NewValue = value;
	}

	const ThHandle<T>& GetValue()const
	{
		return m_Value;
	}

	ThHandle<T>& GetValue()
	{
		return m_Value;
	}

	THOR_DM_VIRTUAL void Serialize(ThiArchiveWriter* archive, const ThI8* fieldName)const
	{
		Private::ThHandleFieldUtils::SerializeImpl(archive,fieldName , this, m_Value);
	}

	THOR_DM_VIRTUAL void Deserialize(ThiArchiveReader* archive, const ThI8* fieldName)
	{
		Private::ThHandleFieldUtils::DeserializeImpl(archive, fieldName, this, m_Value);
	}

	ThBool IsDirty()const
	{
		return m_Flags.CheckFlag(Private::eFieldFlags::IsDirty);
	}

	ThBool IsDefaultValue()const
	{
		return m_Flags.CheckFlag(Private::eFieldFlags::IsDefaultValue);
	}

protected:

	void SetDirty(ThBool val)
	{
		m_Flags.SetFlag(val, Private::eFieldFlags::IsDirty);
		m_Flags.SetFlag(false, Private::eFieldFlags::IsDefaultValue);
	}

	void SetIsDefault(ThBool val)
	{
		m_Flags.SetFlag(val, Private::eFieldFlags::IsDefaultValue);
	}

	THOR_DM_VIRTUAL void Push()
	{
		if (IsDirty())
		{
			m_Value = m_NewValue;
			SetDirty(false);
		}			
	}

private:

#ifdef THOR_DM_THIFIELD_NOVIRTUALS
	friend struct Private::ThiFieldInternalAccess;
#endif

	ThFlags8 m_Flags;
	ThHandle<T> m_NewValue;
	ThHandle<T> m_Value;
};

template <class T>
struct ThFieldTraits< ThHandleField<T> >
{
	typedef ThiHandleField FieldType;
	typedef ThiHandleField ValueType;
	enum eSort{ListSortEnabled = 0};
};
//----------------------------------------------------------------------------------------
//
//					ThHandleSimpleField
//
//----------------------------------------------------------------------------------------
template<class T, bool ThreadSafe = false>
class ThHandleSimpleField: public ThiHandleFieldProxy<ThreadSafe>
{
public:

	typedef ThHandle<T> ValueType;

	ThHandleSimpleField()
	{

	}

	ThHandleSimpleField(const ThHandleSimpleField& other)
		:
	ThiHandleFieldProxy<ThreadSafe>(other),
	m_Value(other.m_Value)
	{
		
	}

	const ThHandleSimpleField& operator=(const ThHandleSimpleField& other)
	{
		SetValue(other.GetValue());
		return *this;
	}

	const ThHandleSimpleField& operator=(const ThHandle<T>& other)
	{
		SetValue(other);
		return *this;
	}

	ThBool operator==(const ThHandle<T>& other)const
	{
		T* selfPtr = m_Value.Get();
		T* otherPtr = other.Get();

		if (selfPtr == 0)
		{
			if (otherPtr == 0)
			{
				// null == null = true. 
				return true;
			}

			// Only the left side is null. 
			return false;
		}

		return selfPtr->Equals(otherPtr);
	}

	ThBool operator!=(const ThHandle<T>& other)const
	{
		return !operator==(other);
	}

	ThBool operator==(const ThHandleField& other)const
	{
		return operator==(other.GetValue());
	}

	ThBool operator!=(const ThHandleField& other)const
	{
		return !operator==(other.GetValue());
	}

	THOR_DM_VIRTUAL ThiType*		GetReferencedEntityType()const
	{
		return ThType< typename ThFieldTraits<T>::FieldType >::Instance();
	}

	void SetValue(const ThHandle<T>& value)
	{
		ScopedLock lock;
		InitScopedLock(lock);

		m_Value = value;
	}

	const ThHandle<T>& GetValue()const
	{
		ScopedLock lock;
		InitScopedLock(lock);

		return m_Value;
	}

	THOR_DM_VIRTUAL void Serialize(ThiArchiveWriter* archive, const ThI8* fieldName)const
	{
		Private::ThHandleFieldUtils::SerializeImpl(archive, fieldName, this, m_Value);
	}

	THOR_DM_VIRTUAL void Deserialize(ThiArchiveReader* archive, const ThI8* fieldName)
	{
		Private::ThHandleFieldUtils::DeserializeImpl(archive, fieldName, this, m_Value);
	}

	ThBool IsDirty()const
	{
		return true;
	}

	ThBool IsDefaultValue()const
	{
		return false;
	}

protected:

	THOR_DM_VIRTUAL void Push()
	{		
		
	}

private:

#ifdef THOR_DM_THIFIELD_NOVIRTUALS
	friend struct Private::ThiFieldInternalAccess;
#endif

	ThHandle<T> m_Value;
};

template <class T, bool ThreadSafe>
struct ThFieldTraits< ThHandleSimpleField<T, ThreadSafe> >
{
	typedef ThiHandleField FieldType;
	typedef ThiHandleField ValueType;
	enum eSort{ListSortEnabled = 0};
};

}