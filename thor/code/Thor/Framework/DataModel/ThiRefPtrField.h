#pragma once

#include <Thor/Framework/DataModel/ThiField.h>
#include <Thor/Framework/DataModel/ThFieldTraits.h>
#include <Thor/Framework/ThMutexPolicy.h>

namespace Thor
{
//----------------------------------------------------------------------------------------
//
//					ThiRefPtrFieldProxy
//
//----------------------------------------------------------------------------------------
template <bool ThreadSafe>
class ThiRefPtrFieldProxy: public ThiFieldProxy<ThreadSafe>
{
public:

	ThiRefPtrFieldProxy()
	{

	}

	ThiRefPtrFieldProxy(const ThiRefPtrFieldProxy& other)
		:
	ThiFieldProxy<ThreadSafe>(other)
	{

	}

	THOR_DM_VIRTUAL ThiType*		GetType()const
	{
		return ThType< ThiRefPtrFieldProxy<false> >::Instance();
	}

#ifndef THOR_DM_THIFIELD_NOVIRTUALS
	virtual ThiType*		GetReferencedEntityType()const = 0;
#endif

protected:

	const ThiRefPtrFieldProxy& operator=(const ThiRefPtrFieldProxy& other)
	{
		return *this;
	}
};

typedef ThiRefPtrFieldProxy<false> ThiRefPtrField;

THOR_DECL_TYPE(Thor::ThiRefPtrField);

namespace Private
{
	//----------------------------------------------------------------------------------------
	//
	//					ThRefPtrFieldUtils
	//
	//----------------------------------------------------------------------------------------
	struct ThRefPtrFieldUtils
	{
		template <class T, class FieldT>
		static void SerializeImpl(ThiArchiveWriter* archive, const ThI8* fieldName, const FieldT* field, const ThRefPtr<T>& val)
		{
			if (val)
			{
				val->Serialize(archive);
				archive->WriteReferenceField(fieldName, field->GetReferencedEntityType(), val->GetUUID());
			}
		}

		template <class T, class FieldT>
		static ThBool DeserializeImpl(ThiArchiveReader* archive, const ThI8* fieldName, FieldT* field, ThRefPtr<T>& handleVal)
		{
			ThUUID uuid;
			ThiEntity* ent = archive->ReadReferenceField(fieldName, field->GetReferencedEntityType(), uuid);

			if (ent)
			{
				ent->Deserialize(archive, uuid);
				handleVal = ent;
			}

			return ent != 0;
		}
	};
}
//----------------------------------------------------------------------------------------
//
//					ThRefPtrDualBufferField
//
//----------------------------------------------------------------------------------------
template<class T>
class ThRefPtrDualBufferField: public ThiRefPtrFieldProxy<true>
{
public:

	typedef ThRefPtr<T> ValueType;

	ThRefPtrDualBufferField()
	{
		m_Flags.SetFlag(true, Private::eFieldFlags::IsDefaultValue);
	}

	ThRefPtrDualBufferField(const ValueType& initVal)
		:
	m_Value(initVal)
	{
		m_Flags.SetFlag(true, Private::eFieldFlags::IsDefaultValue);
	}

	ThRefPtrDualBufferField(const ThRefPtrDualBufferField& other)
		:
	ThiRefPtrFieldProxy<true>(other)
	{
		*this = other;
	}

	const ThRefPtrDualBufferField& operator=(const ThRefPtrDualBufferField& other)
	{
		SetValue(other.m_Value);
		return *this;
	}

	const ThRefPtrDualBufferField& operator=(const ThRefPtr<T>& other)
	{
		SetValue(other);
		return *this;
	}

	ThBool operator==(const ThRefPtr<T>& other)const
	{
		const T* selfPtr = m_Value.GetPtr();
		const T* otherPtr = other.GetPtr();

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

	ThBool operator!=(const ThRefPtr<T>& other)const
	{
		return !operator==(other);
	}

	ThBool operator==(const ThRefPtrDualBufferField& other)const
	{
		return operator==(other.GetValue());
	}

	ThBool operator!=(const ThRefPtrDualBufferField& other)const
	{
		return !operator==(other.GetValue());
	}

	THOR_DM_VIRTUAL ThiType*		GetReferencedEntityType()const
	{
		return ThType<typename ThFieldTraits<T>::FieldType>::Instance();
	}

	void SetValue(const ThRefPtr<T>& value)
	{
		ScopedLock lock;
		InitScopedLock(lock);

		SetDirty(true);
		m_NewValue = value;
	}

	const ThRefPtr<T>& GetValue()const
	{
		return m_Value;
	}

	T* GetPointer()
	{
		return m_Value.GetPtr();
	}

	const T* GetPointer()const
	{
		return m_Value.GetPtr();
	}

	T* operator->()
	{
		return m_Value.GetPtr();
	};

	const T* operator->()const
	{
		m_Value.GetPtr();
	};

	THOR_DM_VIRTUAL void Serialize(ThiArchiveWriter* archive, const ThI8* fieldName)const
	{
		Private::ThRefPtrFieldUtils::SerializeImpl(archive,fieldName , this, m_Value);
	}

	THOR_DM_VIRTUAL void Deserialize(ThiArchiveReader* archive, const ThI8* fieldName)
	{
		if (Private::ThRefPtrFieldUtils::DeserializeImpl(archive, fieldName, this, m_Value))
			SetIsDefault(false);
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

		if(m_Value)
		{
			Private::ThiEntityInternalAccess::Push(m_Value.GetPtr());
		}
	}

private:

#ifdef THOR_DM_THIFIELD_NOVIRTUALS
	friend struct Private::ThiFieldInternalAccess;
#endif

	ThFlags8 m_Flags;
	ThRefPtr<T> m_NewValue;
	ThRefPtr<T> m_Value;
};

template <class T>
struct ThFieldTraits< ThRefPtrDualBufferField<T> >
{
	typedef ThiRefPtrField FieldType;
	typedef ThiRefPtrField ValueType;
	enum eSort{ListSortEnabled = 0};
};
//----------------------------------------------------------------------------------------
//
//					ThRefPtrSimpleField
//
//----------------------------------------------------------------------------------------
template<class T, bool ThreadSafe = false>
class ThRefPtrSimpleField: public ThiRefPtrFieldProxy<ThreadSafe>
{
public:

	typedef ThRefPtr<T> ValueType;

	ThRefPtrSimpleField()
	{

	}

	ThRefPtrSimpleField(const ValueType& initVal)
		:
	m_Value(initVal)
	{

	}

	ThRefPtrSimpleField(const ThRefPtrSimpleField& other)
		:
	ThiRefPtrFieldProxy<ThreadSafe>(other)
	{
		*this = other;
	}

	const ThRefPtrSimpleField& operator=(const ThRefPtrSimpleField& other)
	{
		SetValue(other.m_Value);
		return *this;
	}

	const ThRefPtrSimpleField& operator=(const ThRefPtr<T>& other)
	{
		SetValue(other);
		return *this;
	}

	ThBool operator==(const ThRefPtr<T>& other)const
	{
		const T* selfPtr = m_Value.GetPtr();
		const T* otherPtr = other.GetPtr();

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

	ThBool operator!=(const ThRefPtr<T>& other)const
	{
		return !operator==(other);
	}

	ThBool operator==(const ThRefPtrSimpleField& other)const
	{
		return operator==(other.GetValue());
	}

	ThBool operator!=(const ThRefPtrSimpleField& other)const
	{
		return !operator==(other.GetValue());
	}

	THOR_DM_VIRTUAL ThiType*		GetReferencedEntityType()const
	{
		return ThType<typename ThFieldTraits<T>::FieldType>::Instance();
	}

	void SetValue(const ThRefPtrSimpleField& value)
	{
		ScopedLock lock;
		InitScopedLock(lock);

		m_Value = value.GetValue();
	}

	const ThRefPtr<T>& GetValue()const
	{
		ScopedLock lock;
		InitScopedLock(lock);

		return m_Value;
	}

	T* GetPointer()
	{
		ScopedLock lock;
		InitScopedLock(lock);

		return m_Value.GetPtr();
	}

	const T* GetPointer()const
	{
		ScopedLock lock;
		InitScopedLock(lock);

		return m_Value.GetPtr();
	}

	T* operator->()
	{
		ScopedLock lock;
		InitScopedLock(lock);

		return m_Value.GetPtr();
	};

	const T* operator->()const
	{
		ScopedLock lock;
		InitScopedLock(lock);

		m_Value.GetPtr();
	};

	THOR_DM_VIRTUAL void Serialize(ThiArchiveWriter* archive, const ThI8* fieldName)const
	{
		Private::ThRefPtrFieldUtils::SerializeImpl(archive,fieldName , this, m_Value);
	}

	THOR_DM_VIRTUAL void Deserialize(ThiArchiveReader* archive, const ThI8* fieldName)
	{
		Private::ThRefPtrFieldUtils::DeserializeImpl(archive, fieldName, this, m_Value);
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

	ThRefPtr<T> m_Value;
};

template <class T, bool ThreadSafe>
struct ThFieldTraits< ThRefPtrSimpleField<T, ThreadSafe> >
{
	typedef ThiRefPtrField FieldType;
	typedef ThiRefPtrField ValueType;
	enum eSort{ListSortEnabled = 0};
};

}