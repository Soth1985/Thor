#pragma once

#include <Thor/Framework/DataModel/ThiField.h>
#include <Thor/Framework/DataModel/ThFieldTraits.h>
#include <Thor/Framework/Containers/ThHashMap.h>
#include <Thor/Framework/ThMutexPolicy.h>

#include <tbb/concurrent_vector.h>
#include <tbb/concurrent_hash_map.h>

namespace Thor
{
//----------------------------------------------------------------------------------------
//
//					ThiMapFieldProxy
//
//----------------------------------------------------------------------------------------
template <bool ThreadSafe>
class ThiMapFieldProxy: public ThiFieldProxy<ThreadSafe>
{
public:

	ThiMapFieldProxy()
	{

	}

	ThiMapFieldProxy(const ThiMapFieldProxy& other)
		:
	ThiFieldProxy<ThreadSafe>(other)
	{

	}

	THOR_DM_VIRTUAL ThiType*		GetType()const
	{
		return ThType< ThiMapFieldProxy<false> >::Instance();
	}

#ifndef THOR_DM_THIFIELD_NOVIRTUALS
	virtual ThiType*		GetKeyFieldType()const = 0;

	virtual ThiType*		GetValueFieldType()const = 0;

	virtual ThiType*		GetKeyValueType()const = 0;

	virtual ThiType*		GetValueType()const = 0;

	virtual ThSize GetSizeGeneric()const = 0;

	virtual const ThiField* GetItemGeneric(ThSize index)const = 0;

	virtual ThiField* GetItemGeneric(ThSize index) = 0;
#endif

protected:

	const ThiMapFieldProxy& operator=(const ThiMapFieldProxy& other)
	{
		return *this;
	}
};

typedef ThiMapFieldProxy<false> ThiMapField;

THOR_DECL_TYPE(Thor::ThiMapField);

namespace Private
{
	//----------------------------------------------------------------------------------------
	//
	//					ThMapFieldUtils
	//
	//----------------------------------------------------------------------------------------
	struct ThMapFieldUtils
	{
		template <class KeyT, class ValueT, class FieldT>
		static void SerializeImpl(ThiArchiveWriter* archive, const ThI8* fieldName, const FieldT* field, const ThHashMap<KeyT, ValueT>& items)
		{
			archive->WriteBeginMapField(fieldName, field->GetKeyValueType(), field->GetValueType(), items.Size());
			ThI8 buf[128];

			for(ThSize i = 0; i < items.Size(); ++i)
			{
				sprintf(buf, "Key%u", i);
				archive->WriteField(buf, items.GetItem(i).Key());
				sprintf(buf, "Value%u", i);
				items.GetItem(i).Value().Serialize(archive, buf);
			}

			archive->WriteEndMapField(fieldName, field->GetKeyValueType(), field->GetValueType());
		}

		template <class KeyT, class ValueT, class FieldT>
		static ThBool DeserializeImpl(ThiArchiveReader* archive, const ThI8* fieldName, const FieldT* field, ThHashMap<KeyT, ValueT>& items)
		{
			ThSize size = 0;

			if (archive->ReadBeginMapField(fieldName, field->GetKeyValueType(), field->GetValueType(), size))
			{
				items.Reserve(size);
				ThI8 buf[128];
				KeyT key;

				for (ThSize i = 0; i < size; ++i)
				{					
					sprintf(buf, "Key%u", i);
					archive->ReadField(buf, key);
					sprintf(buf, "Value%u", i);
					items[key].Deserialize(archive, buf);					
				}

				archive->ReadEndMapField(fieldName, field->GetKeyValueType(), field->GetValueType());
			}

			return size != 0;
		}
	};
	//----------------------------------------------------------------------------------------
	//
	//					ThMapModifyOp
	//
	//----------------------------------------------------------------------------------------
	struct ThMapModifyOp
	{
		enum eOp
		{
			eModify,
			eInsert,
			eErase,
			eNoOp
		};

		ThMapModifyOp()
			:
		m_Where(0),
		m_Op(eNoOp)
		{

		}

		ThMapModifyOp(eOp op, ThSize where)
			:
		m_Where(where),
		m_Op(op)
		{

		}

		ThBool operator<(const ThMapModifyOp& other)
		{
			return m_Op < other.m_Op;
		}

		eOp m_Op;
		ThSize m_Where;
	};
}
//----------------------------------------------------------------------------------------
//
//					ThMapDualBufferField
//
//----------------------------------------------------------------------------------------
template <class KeyT, class ValueT>
class ThMapDualBufferField : public ThiMapFieldProxy<true>
{
public:

	typedef typename KeyT::ValueType KeyType;
	typedef ValueT MappedType;
	typedef typename ValueT::ValueType ItemType;
	typedef ThHashMap<KeyType, MappedType> ValueType;
	typedef typename ValueType::ValueType KeyValuePair;

	ThMapDualBufferField()
	{
		m_Flags.SetFlag(true, Private::eFieldFlags::IsDefaultValue);
	}

	ThMapDualBufferField(const ValueType& initVal)
		:
	m_Value(initVal)
	{
		m_Flags.SetFlag(true, Private::eFieldFlags::IsDefaultValue);
	}

	ThMapDualBufferField(const ThMapDualBufferField& other)
		:
	ThiMapFieldProxy<true>(other),
	m_Value(other.m_Value)
	{
	}

	const ThMapDualBufferField& operator=(const ThMapDualBufferField& other)
	{
		SetValue(other.GetValue());
		return *this;
	}

	ThBool operator==(const ThMapDualBufferField& other)const
	{
		return m_Value == other.GetValue();
	}

	ThBool operator!=(const ThMapDualBufferField& other)const
	{
		return m_Value != other.GetValue();
	}

	const ThMapDualBufferField& Assign(const ThHashMap<KeyType, ValueType>& other)
	{
		SetValue(other);
		return *this;
	}

	const ThMapDualBufferField& AssignValue(const ThHashMap<KeyType, ItemType>& other)
	{
		Clear();

		for (ThSize i = 0; i < other.Size(); ++i)
		{
			SetItemValue(other.GetItem(i).Key(), other.GetItem(i).Value());
		}

		return *this;
	}

	const ValueType& GetValue()const
	{
		return m_Value;
	}

	void SetValue(const ValueType& value)
	{		
		SetDirtyLock();
		SetUniqueOpLock(true, eSwapOp);
		
		ScopedLock lock;
		InitScopedLock(lock);

		m_NewValue = value;
	}

	void SwapValue(const ValueType& value)
	{		
		SetDirtyLock();
		SetUniqueOpLock(true, eSwapOp);
		
		ScopedLock lock;
		InitScopedLock(lock);

		m_NewValue.Swap(value);
	}

	THOR_DM_VIRTUAL ThiType*		GetKeyFieldType()const
	{
		return ThType<typename ThFieldTraits<KeyT>::FieldType>::Instance();
	}

	THOR_DM_VIRTUAL ThiType*		GetValueFieldType()const
	{
		return ThType<typename ThFieldTraits<ValueT>::FieldType>::Instance();
	}

	THOR_DM_VIRTUAL ThiType*		GetKeyValueType()const
	{
		return ThType<typename ThFieldTraits<KeyT>::ValueType>::Instance();
	}

	THOR_DM_VIRTUAL ThiType*		GetValueType()const
	{
		return ThType<typename ThFieldTraits<ValueT>::ValueType>::Instance();
	}

	THOR_DM_VIRTUAL void Serialize(ThiArchiveWriter* archive, const ThI8* fieldName)const
	{
		Private::ThMapFieldUtils::SerializeImpl(archive, fieldName, this, m_Value);
	}

	THOR_DM_VIRTUAL void Deserialize(ThiArchiveReader* archive, const ThI8* fieldName)
	{
		if (Private::ThMapFieldUtils::DeserializeImpl(archive, fieldName, this, m_Value))
			SetIsDefault(false);
	}

#ifndef THOR_DM_THIFIELD_NOVIRTUALS
	virtual ThSize GetSizeGeneric()const
	{
		return m_Value.Size();
	}

	virtual const ThiField* GetItemGeneric(ThSize index)const
	{
		return &m_Value.GetItem(index).Value();
	}

	virtual ThiField* GetItemGeneric(ThSize index)
	{
		//m_ModifyOpList.push_back(Private::ThMapModifyOp(Private::ThMapModifyOp::eModify, index));
		SetDirtyPushItemsLock();
		return &m_Value.GetItem(index).Value();
	}
#endif

	void SetItem(const KeyType& key, const MappedType& value)
	{
		ValueType::ConstIterator it = m_Value.Find(key);


		if (it != m_Value.End())
		{
			it->Value() = value;
			//m_ModifyOpList.push_back(Private::ThMapModifyOp(Private::ThMapModifyOp::eModify, it - m_Value.Begin()));
			SetDirtyPushItemsLock();
		}
		else
		{
			SetDirtyLock();

			typedef tbb::concurrent_hash_map<KeyType, ItemType> map_t;

			map_t::accessor result;

			if (m_NewItems.find(result, key))
			{
				result->second = value.GetValue();
			}
			else
				m_NewItems.insert(map_t::value_type(key, value));
		}
	}

	const KeyValuePair& GetItem(ThSize index)const
	{
		return m_Value.GetItem(index);
	}

	KeyValuePair& GetItem(ThSize index)
	{
		//m_ModifyOpList.push_back(Private::ThMapModifyOp(Private::ThMapModifyOp::eModify, index));
		SetDirtyPushItemsLock();
		return m_Value.GetItem(index);
	}

	void SetItemValue(const KeyType& key, const ItemType& value)
	{
		ValueType::Iterator it = m_Value.Find(key);

		if (it != m_Value.End())
		{
			it->Value().SetValue(value);
			SetDirtyPushItemsLock();
			//m_ModifyOpList.push_back(Private::ThMapModifyOp(Private::ThMapModifyOp::eModify, it - m_Value.Begin()));
		}
		else
		{
			SetDirtyLock();

			typedef tbb::concurrent_hash_map<KeyType, ItemType> map_t;

			map_t::accessor result;

			if (m_NewItems.find(result, key))
			{
				result->second = value;
			}
			else
				m_NewItems.insert(map_t::value_type(key, value));
		}
	}

	const ItemType& GetItemValue(ThSize index)
	{
		return m_Value.GetItem(index).GetValue();
	}

	const MappedType* Find(const KeyType& key)const
	{
		ValueType::ConstIterator it = m_Value.Find(key);

		if (it != m_Value.End())
			return it->Value();

		return 0;
	}

	MappedType* Find(const KeyType& key)
	{
		ValueType::Iterator it = m_Value.Find(key);

		if (it != m_Value.End())
		{
			//m_ModifyOpList.push_back(Private::ThMapModifyOp(Private::ThMapModifyOp::eModify, it - m_Value.Begin()));
			SetDirtyPushItemsLock();
			return it->Value();
		}

		return 0;
	}

	ThSize GetSize()const
	{
		return m_Value.Size();
	}

	void Erase(const KeyType& key)
	{
		ValueType::Iterator i = m_Value.Find(key);

		if (i != m_Value.End() )
		{
			SetDirtyLock();
			m_ModifyOpList.push_back(Private::ThMapModifyOp(Private::ThMapModifyOp::eErase, i - m_Value.Begin()));
		}
	}

	void Clear()
	{
		SetDirtyLock();
		SetUniqueOpLock(true, eClearOp);
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
		if (m_UniqueOps.CheckFlag(eSwapOp))
		{
			m_Value.Swap(m_NewValue);
			DoPush();
			PostPush();
			return;
		}

		ThBool isCleared = false;

		if (m_UniqueOps.CheckFlag(eClearOp))
		{
			m_Value.Clear();
			isCleared = true;
			//PostPush();
			//return;
		}

		DoPush();

		std::sort(m_ModifyOpList.begin(), m_ModifyOpList.end());

		for (ThSize i = 0; i < m_ModifyOpList.size(); ++i)
		{
			Private::ThMapModifyOp& curOp = m_ModifyOpList[i];

			/*if (curOp.m_Op == Private::ThListModifyOp::eModify)
			{
				Private::ThiFieldInternalAccess::Push(&m_Value.GetItem(curOp.m_Where).Value());
			}
			else*/ if (!isCleared && curOp.m_Op == Private::ThListModifyOp::eErase)
			{
				m_Value.Erase(m_Value.Begin() + curOp.m_Where);
			}
		}

		tbb::concurrent_hash_map<KeyType, ItemType>::iterator it;

		for(it = m_NewItems.begin(); it != m_NewItems.end(); ++it)
		{
			m_Value.Insert(it->first, MappedType(it->second));
		}

		PostPush();
	}

private:

#ifdef THOR_DM_THIFIELD_NOVIRTUALS
	friend struct Private::ThiFieldInternalAccess;
#endif

	enum eUniqueOp
	{
		eClearOp = 1 << 0,
		eSwapOp = 1 << 1,
		ePushItemsOp = 1 << 2
	};

	void DoPush()
	{
		if(m_UniqueOps.CheckFlag(ePushItemsOp))
		{
			for (ThSize i = 0; i < m_Value.Size(); ++i)
			{
				MappedType& item = m_Value.GetItem(i).Value();

				if (item.IsDirty())
					Private::ThiFieldInternalAccess::Push(&item);
			}
		}		
	}

	void PostPush()
	{
		m_NewItems.clear();
		m_ModifyOpList.clear();
		m_NewValue.Clear();
		m_UniqueOps.Reset();
		SetDirty(false);
	}

	void SetDirtyLock()
	{
		ScopedLock lock;
		InitScopedLock(lock);

		SetDirty(true);
	}

	void SetDirtyPushItemsLock()
	{
		ScopedLock lock;
		InitScopedLock(lock);

		SetDirty(true);
		m_UniqueOps.SetFlag(true, ePushItemsOp);
	}

	void SetUniqueOpLock(ThBool val, eUniqueOp op)
	{
		ScopedLock lock;
		InitScopedLock(lock);

		m_UniqueOps.SetFlag(val, op);
	}

	ThFlags8 m_Flags;
	ThFlags8 m_UniqueOps;
	tbb::concurrent_vector<Private::ThMapModifyOp> m_ModifyOpList;
	tbb::concurrent_hash_map< KeyType, ItemType > m_NewItems;	
	ValueType m_NewValue;
	ValueType m_Value;
};

template <class KeyT, class ValueT>
struct ThFieldTraits< ThMapDualBufferField<KeyT, ValueT> >
{
	typedef ThiMapField FieldType;
	typedef ThiMapField ValueType;
	enum eSort{ListSortEnabled = 0};
};
//----------------------------------------------------------------------------------------
//
//					ThMapSimpleField
//
//----------------------------------------------------------------------------------------
template <class KeyT, class ValueT, bool ThreadSafe = false>
class ThMapSimpleField : public ThiMapFieldProxy<ThreadSafe>
{
public:

	typedef typename KeyT::ValueType KeyType;
	typedef ValueT MappedType;
	typedef typename ValueT::ValueType ItemType;
	typedef ThHashMap<KeyType, MappedType> ValueType;
	typedef typename ValueType::ValueType KeyValuePair;

	ThMapSimpleField()
	{

	}

	ThMapSimpleField(const ValueType& initVal)
		:
	m_Value(initVal)
	{

	}

	ThMapSimpleField(const ThMapSimpleField& other)
		:
	ThiMapFieldProxy<ThreadSafe>(other)
	{
		*this = other;
	}

	const ThMapSimpleField& operator=(const ThMapSimpleField& other)
	{
		SetValue(other.m_Value);
		return *this;
	}

	ThBool operator==(const ThMapSimpleField& other)const
	{
		return m_Value == other.GetValue();
	}

	ThBool operator!=(const ThMapSimpleField& other)const
	{
		return m_Value != other.GetValue();
	}

	const ThMapSimpleField& Assign(const ThHashMap<KeyType, MappedType>& other)
	{
		SetValue(other);
		return *this;
	}

	const ThMapSimpleField& AssignValue(const ThHashMap<KeyType, ItemType>& other)
	{
		Clear();

		for (ThSize i = 0; i < other.Size(); ++i)
		{
			SetItemValue(other.GetItem(i).Key(), other.GetItem(i).Value());
		}

		return *this;
	}

	const ValueType& GetValue()const
	{
		ScopedLock lock;
		InitScopedLock(lock);

		return m_Value;
	}

	void SetValue(const ValueType& value)
	{
		//SetDirty(true);
		ScopedLock lock;
		InitScopedLock(lock);

		m_Value = value;
	}

	THOR_DM_VIRTUAL ThiType*		GetKeyFieldType()const
	{
		return ThType<typename ThFieldTraits<KeyT>::FieldType>::Instance();
	}

	THOR_DM_VIRTUAL ThiType*		GetValueFieldType()const
	{
		return ThType<typename ThFieldTraits<ValueT>::FieldType>::Instance();
	}

	THOR_DM_VIRTUAL ThiType*		GetKeyValueType()const
	{
		return ThType<typename ThFieldTraits<KeyT>::ValueType>::Instance();
	}

	THOR_DM_VIRTUAL ThiType*		GetValueType()const
	{
		return ThType<typename ThFieldTraits<ValueT>::ValueType>::Instance();
	}

	THOR_DM_VIRTUAL void Serialize(ThiArchiveWriter* archive, const ThI8* fieldName)const
	{
		Private::ThMapFieldUtils::SerializeImpl(archive, fieldName, this, m_Value);
	}

	THOR_DM_VIRTUAL void Deserialize(ThiArchiveReader* archive, const ThI8* fieldName)
	{
		Private::ThMapFieldUtils::DeserializeImpl(archive, fieldName, this, m_Value);
	}

#ifndef THOR_DM_THIFIELD_NOVIRTUALS
	virtual ThSize GetSizeGeneric()const
	{
		ScopedLock lock;
		InitScopedLock(lock);

		return m_Value.Size();
	}

	virtual const ThiField* GetItemGeneric(ThSize index)const
	{
		ScopedLock lock;
		InitScopedLock(lock);

		return &m_Value.GetItem(index).Value();
	}

	virtual ThiField* GetItemGeneric(ThSize index)
	{
		ScopedLock lock;
		InitScopedLock(lock);

		return &m_Value.GetItem(index).Value();
	}
#endif
	void SetItem(const KeyType& key, const MappedType& value)
	{
		ScopedLock lock;
		InitScopedLock(lock);

		m_Value[key] = value;
	}

	const KeyValuePair& GetItem(ThSize index)const
	{
		ScopedLock lock;
		InitScopedLock(lock);

		return m_Value.GetItem(index);
	}

	void SetItemValue(const KeyType& key, const ItemType& value)
	{
		ScopedLock lock;
		InitScopedLock(lock);

		m_Value[key].SetValue(value);
	}

	const ItemType& GetItemValue(ThSize index)
	{
		ScopedLock lock;
		InitScopedLock(lock);

		return m_Value.GetItem(index).Value().GetValue();
	}

	const MappedType* Find(const KeyType& key)const
	{
		ScopedLock lock;
		InitScopedLock(lock);

		ValueType::ConstIterator it = m_Value.Find(key);

		if (it != m_Value.End())
			return it->Value();

		return 0;
	}

	MappedType* Find(const KeyType& key)
	{
		ScopedLock lock;
		InitScopedLock(lock);

		ValueType::Iterator it = m_Value.Find(key);

		if (it != m_Value.End())
			return &it->Value();

		return 0;
	}

	ThSize GetSize()const
	{
		ScopedLock lock;
		InitScopedLock(lock);

		return m_Value.Size();
	}

	void Erase(const KeyType& key)
	{
		ScopedLock lock;
		InitScopedLock(lock);

		m_Value.Erase(key);
	}

	void Clear()
	{
		ScopedLock lock;
		InitScopedLock(lock);

		m_Value.Clear();
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
		//SetDirty(false);
	}

private:

#ifdef THOR_DM_THIFIELD_NOVIRTUALS
	friend struct Private::ThiFieldInternalAccess;
#endif

	ValueType m_Value;
};

template <class KeyT, class ValueT, bool ThreadSafe>
struct ThFieldTraits< ThMapSimpleField<KeyT, ValueT, ThreadSafe> >
{
	typedef ThiMapField FieldType;
	typedef ThiMapField ValueType;
	enum eSort{ListSortEnabled = 0};
};

}