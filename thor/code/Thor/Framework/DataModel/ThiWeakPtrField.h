#pragma once

#include <Thor/Framework/DataModel/ThiField.h>
#include <Thor/Framework/DataModel/ThFieldTraits.h>
#include <Thor/Framework/ThMutexPolicy.h>

namespace Thor
{
//----------------------------------------------------------------------------------------
//
//					ThiWeakPtrFieldProxy
//
//----------------------------------------------------------------------------------------
template <bool ThreadSafe>
class ThiWeakPtrFieldProxy: public ThiFieldProxy<ThreadSafe>
{
public:

	ThiWeakPtrFieldProxy()
	{

	}

	ThiWeakPtrFieldProxy(const ThiWeakPtrFieldProxy& other)
		:
	ThiFieldProxy<ThreadSafe>(other)
	{

	}

	THOR_DM_VIRTUAL ThiType*		GetType()const
	{
		return ThType< ThiWeakPtrFieldProxy<false> >::Instance();
	}

#ifndef THOR_DM_THIFIELD_NOVIRTUALS
	virtual ThiType*		GetReferencedEntityType()const = 0;
#endif

protected:

	const ThiWeakPtrFieldProxy& operator=(const ThiWeakPtrFieldProxy& other)
	{
		return *this;
	}
};

typedef ThiWeakPtrFieldProxy<false> ThiWeakPtrField;

THOR_DECL_TYPE(Thor::ThiWeakPtrField);

namespace Private
{
	//----------------------------------------------------------------------------------------
	//
	//					ThWeakPtrFieldUtils
	//
	//----------------------------------------------------------------------------------------
	struct ThWeakPtrFieldUtils
	{
		template <class T, class FieldT>
		static void SerializeImpl(ThiArchiveWriter* archive, const ThI8* fieldName, const FieldT* field, const ThWeakPtr<T>& val)
		{
			ThRefPtr<T> ptr = val.Lock();
			if (ptr)
			{
				ptr->Serialize(archive);
				archive->WriteWeakReferenceField(fieldName, field->GetReferencedEntityType(), ptr->GetUUID());
			}
		}

		template <class T, class FieldT>
		static ThBool DeserializeImpl(ThiArchiveReader* archive, const ThI8* fieldName, const FieldT* field, ThWeakPtr<T>& val)
		{
			ThUUID uuid;
			ThiEntity* ent = archive->ReadWeakReferenceField(fieldName, field->GetReferencedEntityType(), uuid);

			if (ent)
			{
				ent->Deserialize(archive, uuid);
				val = ThRefPtr<T>(ent);
			}

			return ent != 0;
		}
	};
}
//----------------------------------------------------------------------------------------
//
//					ThWeakPtrDualBufferField
//
//----------------------------------------------------------------------------------------
template<class T>
class ThWeakPtrDualBufferField: public ThiWeakPtrFieldProxy<true>
{
public:

	typedef ThWeakPtr<T> ValueType;

	ThWeakPtrDualBufferField()
	{
		m_Flags.SetFlag(true, Private::eFieldFlags::IsDefaultValue);
	}

	ThWeakPtrDualBufferField(const ValueType& initVal)
		:
	m_Value(initVal)
	{
		m_Flags.SetFlag(true, Private::eFieldFlags::IsDefaultValue);
	}

	ThWeakPtrDualBufferField(const ThWeakPtrDualBufferField& other)
		:
	ThiWeakPtrFieldProxy<true>(other)
	{
		*this = other;
	}

	const ThWeakPtrDualBufferField& operator=(const ThWeakPtrDualBufferField& other)
	{
		SetValue(other.m_Value);
		return *this;
	}

	const ThWeakPtrDualBufferField& operator=(const ThWeakPtr<T>& other)
	{
		SetValue(other);
		return *this;
	}

	ThBool operator==(const ThWeakPtr<T>& other)const
	{
		ThRefPtr<T> selfRef = m_Value.Lock();
		ThRefPtr<T> otherRef = other.Lock();

		const T* selfPtr = selfRef.GetPtr();
		const T* otherPtr = otherRef.GetPtr();

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

	ThBool operator!=(const ThWeakPtr<T>& other)const
	{
		return !operator==(other);
	}

	ThBool operator==(const ThWeakPtrDualBufferField& other)const
	{
		return operator==(other.GetValue());
	}

	ThBool operator!=(const ThWeakPtrDualBufferField& other)const
	{
		return !operator==(other.GetValue());
	}

	THOR_DM_VIRTUAL ThiType*		GetReferencedEntityType()const
	{
		return ThType<typename ThFieldTraits<T>::FieldType>::Instance();
	}

	void SetValue(const ThWeakPtr<T>& value)
	{
		ScopedLock lock;
		InitScopedLock(lock);

		SetDirty(true);
		m_NewValue = value;
	}

	const ThWeakPtr<T>& GetValue()const
	{
		return m_Value;
	}

	T* Lock()
	{
		ThRefPtr<T> temp = m_Value.Lock();

		if (temp)
			return temp.GetPtr();
		else
			return 0;
	}

	THOR_DM_VIRTUAL void Serialize(ThiArchiveWriter* archive, const ThI8* fieldName)const
	{
		Private::ThWeakPtrFieldUtils::SerializeImpl(archive,fieldName , this, m_Value);
	}

	THOR_DM_VIRTUAL void Deserialize(ThiArchiveReader* archive, const ThI8* fieldName)
	{
		if (Private::ThWeakPtrFieldUtils::DeserializeImpl(archive, fieldName, this, m_Value))
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

		ThRefPtr<T> ptr = m_Value.Lock();

		if(ptr)
		{
			Private::ThiEntityInternalAccess::Push(ptr.GetPtr());
		}
	}

private:

#ifdef THOR_DM_THIFIELD_NOVIRTUALS
	friend struct Private::ThiFieldInternalAccess;
#endif

	ThFlags8 m_Flags;
	ThWeakPtr<T> m_NewValue;
	ThWeakPtr<T> m_Value;
};

template <class T>
struct ThFieldTraits< ThWeakPtrDualBufferField<T> >
{
	typedef ThiWeakPtrField FieldType;
	typedef ThiWeakPtrField ValueType;
	enum eSort{ListSortEnabled = 0};
};
//----------------------------------------------------------------------------------------
//
//					ThWeakPtrSimpleField
//
//----------------------------------------------------------------------------------------
template<class T, bool ThreadSafe = false>
class ThWeakPtrSimpleField: public ThiWeakPtrFieldProxy<ThreadSafe>
{
public:

	typedef ThWeakPtr<T> ValueType;

	ThWeakPtrSimpleField()
	{

	}

	ThWeakPtrSimpleField(const ValueType& initVal)
		:
	m_Value(initVal)
	{

	}

	ThWeakPtrSimpleField(const ThWeakPtrSimpleField& other)
		:
	ThiWeakPtrFieldProxy<ThreadSafe>(other)
	{
		*this = other;
	}

	const ThWeakPtrSimpleField& operator=(const ThWeakPtrSimpleField& other)
	{
		SetValue(other.m_Value);
		return *this;
	}

	const ThWeakPtrSimpleField& operator=(const ThWeakPtr<T>& other)
	{
		SetValue(other);
		return *this;
	}

	ThBool operator==(const ThWeakPtr<T>& other)const
	{
		ThRefPtr<T> selfRef = m_Value.Lock();
		ThRefPtr<T> otherRef = other.Lock();

		const T* selfPtr = selfRef.GetPtr();
		const T* otherPtr = otherRef.GetPtr();

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

	ThBool operator!=(const ThWeakPtr<T>& other)const
	{
		return !operator==(other);
	}

	ThBool operator==(const ThWeakPtrSimpleField& other)const
	{
		return operator==(other.GetValue());
	}

	ThBool operator!=(const ThWeakPtrSimpleField& other)const
	{
		return !operator==(other.GetValue());
	}

	THOR_DM_VIRTUAL ThiType*		GetReferencedEntityType()const
	{
		return ThType<typename ThFieldTraits<T>::FieldType>::Instance();
	}

	void SetValue(const ThWeakPtrSimpleField& value)
	{
		ScopedLock lock;
		InitScopedLock(lock);

		m_Value = value.GetValue();
	}

	const ThWeakPtr<T>& GetValue()const
	{
		ScopedLock lock;
		InitScopedLock(lock);

		return m_Value;
	}

	T* Lock()
	{
		ScopedLock lock;
		InitScopedLock(lock);

		ThRefPtr<T> temp = m_Value.Lock();

		if (temp)
			return temp.GetPtr();
		else
			return 0;
	}

	THOR_DM_VIRTUAL void Serialize(ThiArchiveWriter* archive, const ThI8* fieldName)const
	{
		Private::ThWeakPtrFieldUtils::SerializeImpl(archive, fieldName, this, m_Value);
	}

	THOR_DM_VIRTUAL void Deserialize(ThiArchiveReader* archive, const ThI8* fieldName)
	{
		Private::ThWeakPtrFieldUtils::DeserializeImpl(archive, fieldName, this, m_Value);
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

	ThWeakPtr<T> m_Value;
};

template <class T, bool ThreadSafe>
struct ThFieldTraits< ThWeakPtrSimpleField<T, ThreadSafe> >
{
	typedef ThiWeakPtrField FieldType;
	typedef ThiWeakPtrField ValueType;
	enum eSort{ListSortEnabled = 0};
};

}