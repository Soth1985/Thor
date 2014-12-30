#pragma once

#include <Thor/Framework/DataModel/ThiField.h>
#include <Thor/Framework/Containers/ThVector.h>
#include <Thor/Framework/DataModel/ThFieldTraits.h>
#include <Thor/Framework/ThMutexPolicy.h>

#include <algorithm>

#include <tbb/concurrent_vector.h>

namespace Thor
{
//----------------------------------------------------------------------------------------
//
//					ThiListFieldProxy
//
//----------------------------------------------------------------------------------------
template <bool ThreadSafe>
class ThiListFieldProxy: public ThiFieldProxy<ThreadSafe>
{
public:

	ThiListFieldProxy()
	{

	}

	ThiListFieldProxy(const ThiListFieldProxy& other)
		:
	ThiFieldProxy<ThreadSafe>(other)
	{

	}

	THOR_DM_VIRTUAL ThiType*		GetType()const
	{
		return ThType< ThiListFieldProxy<false> >::Instance();
	}

#ifndef THOR_DM_THIFIELD_NOVIRTUALS
	virtual ThiType*		GetItemFieldType()const = 0;

	virtual ThiType*		GetItemValueType()const = 0;

	virtual ThSize GetSizeGeneric()const = 0;

	virtual ThiField* GetItemGeneric(ThSize index) = 0;

	virtual const ThiField* GetItemGeneric(ThSize index)const = 0;
#endif

protected:

	const ThiListFieldProxy& operator=(const ThiListFieldProxy& other)
	{
		return *this;
	}
};

typedef ThiListFieldProxy<false> ThiListField;

THOR_DECL_TYPE(Thor::ThiListField);

namespace Private
{
	//----------------------------------------------------------------------------------------
	//
	//					ThListFieldUtils
	//
	//----------------------------------------------------------------------------------------
	struct ThListFieldUtils
	{
		template <class T, class FieldT>
		static void SerializeImpl(ThiArchiveWriter* archive, const ThI8* fieldName, const FieldT* field, const ThVector<T>& items)
		{
			archive->WriteBeginListField(fieldName, field->GetItemValueType(), items.Size());
			ThI8 buf[128];

			for(ThSize i = 0; i < items.Size(); ++i)
			{
				sprintf(buf, "Item%u", i);
				items[i].Serialize(archive, buf);
			}

			archive->WriteEndListField(fieldName, field->GetItemValueType());
		}

		template <class T, class FieldT>
		static ThBool DeserializeImpl(ThiArchiveReader* archive, const ThI8* fieldName, const FieldT* field, ThVector<T>& items)
		{
			ThSize size = 0;
			if (archive->ReadBeginListField(fieldName, field->GetItemValueType(), size))
			{
				items.Resize(size);
				ThI8 buf[128];

				for (ThSize i = 0; i < items.Size(); ++i)
				{
					sprintf(buf, "Item%u", i);
					items[i].Deserialize(archive, buf);
				}

				archive->ReadEndListField(fieldName, field->GetItemValueType());
			}

			return size != 0;
		}
	};
	//----------------------------------------------------------------------------------------
	//
	//					ThListModifyOp
	//
	//----------------------------------------------------------------------------------------
	struct ThListModifyOp
	{
		enum eOp
		{
			eModify,
			eInsert,
			eErase,
			eNoOp
		};

		ThListModifyOp()
			:
		m_Where(0),
		m_What(0),
		m_Op(eNoOp)
		{

		}

		ThListModifyOp(eOp op, ThSize where, ThSize what)
			:
		m_Where(where),
		m_What(what),
		m_Op(op)
		{

		}

		ThBool operator<(const ThListModifyOp& other)
		{
			return m_Op < other.m_Op;
		}

		eOp m_Op;
		ThSize m_Where;
		ThSize m_What;
	};
}
//----------------------------------------------------------------------------------------
//
//					ThListDualBufferField
//
//----------------------------------------------------------------------------------------
template <class T>
class ThListDualBufferField : public ThiListFieldProxy<true>
{
public:

	typedef ThVector<T> ValueType;
	typedef typename T::ValueType ItemType;

	ThListDualBufferField()
	{
		m_Flags.SetFlag(true, Private::eFieldFlags::IsDefaultValue);
	}

	ThListDualBufferField(const ValueType& initVal)
		:
	m_Value(initVal)
	{
		m_Flags.SetFlag(true, Private::eFieldFlags::IsDefaultValue);
	}

	ThListDualBufferField(const ThListDualBufferField& other)
		:
	ThiListFieldProxy<true>(other),
	m_Value(other.m_Value)
	{
		
	}

	const ThListDualBufferField& operator=(const ThListDualBufferField& other)
	{
		SetValue(other.GetValue());
		return *this;
	}

	ThBool operator==(const ThListDualBufferField& other)const
	{
		return m_Value == other.GetValue();
	}

	ThBool operator!=(const ThListDualBufferField& other)const
	{
		return m_Value != other.GetValue();
	}

	const ThListDualBufferField& Assign(const ThVector<T>& other)
	{
		SetValue(other);
		return *this;
	}

	const ThListDualBufferField& AssignValue(const ThVector<ItemType>& other)
	{
		Clear();

		for (ThSize i = 0; i < other.Size(); ++i)
		{
			PushBackItemValue(other[i]);
		}

		return *this;
	}

	THOR_DM_VIRTUAL ThiType*		GetItemFieldType()const
	{
		return ThType< typename ThFieldTraits<T>::FieldType >::Instance();
	}

	THOR_DM_VIRTUAL ThiType*		GetItemValueType()const
	{
		return ThType< typename ThFieldTraits<T>::ValueType >::Instance();
	}

	THOR_DM_VIRTUAL void Serialize(ThiArchiveWriter* archive, const ThI8* fieldName)const
	{
		Private::ThListFieldUtils::SerializeImpl(archive, fieldName, this, m_Value);
	}

	THOR_DM_VIRTUAL void Deserialize(ThiArchiveReader* archive, const ThI8* fieldName)
	{
		if(Private::ThListFieldUtils::DeserializeImpl(archive, fieldName, this, m_Value))
			SetIsDefault(false);
	}

#ifndef THOR_DM_THIFIELD_NOVIRTUALS
	virtual ThSize GetSizeGeneric()const
	{
		return GetSize();
	}

	virtual ThiField* GetItemGeneric(ThSize index)
	{
		//m_ModifyOpList.push_back(Private::ThListModifyOp(Private::ThListModifyOp::eModify, index, 0));
		SetDirtyPushItemsLock();
		return &m_Value[index];
	}

	virtual const ThiField* GetItemGeneric(ThSize index)const
	{
		return &m_Value[index];
	}
#endif

	const ValueType& GetValue()const
	{
		return m_Value;
	}

	void SetValue(const ValueType& value)
	{		
		SetDirtyPushItemsLock();
		SetUniqueOpLock(true, eSwapOp);

		ScopedLock lock;
		InitScopedLock(lock);

		m_NewValue = value;
	}

	void SwapValue(const ValueType& value)
	{
		SetDirtyPushItemsLock();
		SetUniqueOpLock(true, eSwapOp);

		ScopedLock lock;
		InitScopedLock(lock);

		m_NewValue.Swap(value);
	}

	void SetItem(ThSize index, const T& item)
	{
		if (index < m_Value.Size())
		{
			//m_ModifyOpList.push_back(Private::ThListModifyOp(Private::ThListModifyOp::eModify, index, 0));
			SetDirtyPushItemsLock();
			m_Value[index].SetValue(item.GetValue());
		}		
	}

	const T& GetItem(ThSize index)const
	{
		return m_Value[index];
	}

	T& GetItem(ThSize index)
	{
		//m_ModifyOpList.push_back(Private::ThListModifyOp(Private::ThListModifyOp::eModify, index, 0));
		SetDirtyPushItemsLock();
		return m_Value[index];
	}

	void SetItemValue(ThSize index, const ItemType& value)
	{
		if (index < m_Value.Size())
		{
			//m_ModifyOpList.push_back(Private::ThListModifyOp(Private::ThListModifyOp::eModify, index, 0));
			SetDirtyPushItemsLock();
			m_Value[index].SetValue(value);
		}		
	}

	const ItemType& GetItemValue(ThSize index)const
	{
		return m_Value[index].GetValue();
	}

	ThSize GetSize()const
	{
		return m_Value.Size();
	}

	void Sort()
	{
		SetDirtyLock();
		SetUniqueOpLock(true, eSortOp);		
	}

	void Erase(ThSize index)
	{
		if (index < m_Value.Size())
		{
			m_ModifyOpList.push_back(Private::ThListModifyOp(Private::ThListModifyOp::eErase, index, 0));
			SetDirtyLock();
		}
	}

	void PushBackItem(const T& item)
	{
		tbb::concurrent_vector<ItemType>::iterator i = m_NewItems.push_back(item.GetValue());
		m_ModifyOpList.push_back(Private::ThListModifyOp(Private::ThListModifyOp::eInsert, m_Value.Size(), i - m_NewItems.begin()));
		SetDirtyLock();
	}

	void PushBackItemValue(const ItemType& value)
	{
		tbb::concurrent_vector<ItemType>::iterator i = m_NewItems.push_back(value);
		m_ModifyOpList.push_back(Private::ThListModifyOp(Private::ThListModifyOp::eInsert, m_Value.Size(), i - m_NewItems.begin()));
		SetDirtyLock();
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
			Private::ThListModifyOp& curOp = m_ModifyOpList[i];

			/*if (curOp.m_Op == Private::ThListModifyOp::eModify)
			{
				Private::ThiFieldInternalAccess::Push(&m_Value[curOp.m_Where]);
			}
			else*/ if (!isCleared && curOp.m_Op == Private::ThListModifyOp::eErase)
			{
				m_Value.Erase(m_Value.Data() + curOp.m_Where);
			}
			else if (curOp.m_Op == Private::ThListModifyOp::eInsert)
			{
				m_Value.PushBack(T(m_NewItems[curOp.m_What]));
			}
		}

		if (m_UniqueOps.CheckFlag(eSortOp) && !m_Value.Empty())
		{
			DoSort< ThFieldTraits<T>::ListSortEnabled >();
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
		eSortOp = 1 << 1,
		eSwapOp = 1 << 2,
		ePushItemsOp = 1 << 3
	};

	template <bool isSortEnabled>
	void DoSort();

	template <>
	void DoSort<true>()
	{
		QuickSort();
	}

	template <>
	void DoSort<false>()
	{

	}

	void PostPush()
	{
		m_ModifyOpList.clear();
		m_NewItems.clear();
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

	void DoPush()
	{
		if (m_UniqueOps.CheckFlag(ePushItemsOp))
		{
			for (ThSize i = 0; i < m_Value.Size(); ++i)
			{
				if (m_Value[i].IsDirty())
					Private::ThiFieldInternalAccess::Push(&m_Value[i]);
			}
		}		
	}

	ThSize Mid(ThSize lo, ThSize hi)
	{
		return (lo + ((hi - lo) >> 1));
	}

	void QuickSort() 
	{
		struct qstack 
		{
			ThSize lo, hi;
		};

		qstack stack[sizeof(ThSize) * 8], *sp;

		ThListSortCompare<ItemType> pred;

		ThSize i, k;
		ItemType pivot;
		ThSize lo, hi;
		ItemType tmp;

		/* initialize our stack */
		sp = stack;
		sp->hi = m_Value.Size() - 1;
		sp->lo = 0;
		sp++;

		do 
		{
			/* pop our lo and hi indexes off the stack */
			sp--;
			lo = sp->lo;
			hi = sp->hi;

			if ((hi - lo) < 1)
				continue;

			/* cache our pivot value */
			ThSize mid = Mid(lo, hi);
			pivot = m_Value[mid].GetValue();

			i = lo;
			k = hi;

			do 
			{
				/*while (i < k && m_Value[i].GetValue() < pivot)
				{
					i++;
				}

				while (k > i && k != mid && m_Value[k].GetValue() > pivot)
				{
					k--;
				}*/

				while (i < k && pred(m_Value[i].GetValue(),pivot))
				{
					i++;
				}

				while (k > i && k != mid && !pred(m_Value[k].GetValue(), pivot))
				{
					k--;
				}

				if (i <= k) 
				{
					tmp = m_Value[i].GetValue();
					m_Value[i].SetValue(m_Value[k].GetValue());
					m_Value[k].SetValue(tmp);
					Private::ThiFieldInternalAccess::Push(&m_Value[i]);
					Private::ThiFieldInternalAccess::Push(&m_Value[k]);
					i++;

					if (k != mid)
						k--;
				}
				else
				{
					break;
				}
			} 
			while (1);

			if (lo < k) 
			{
				/* push the first partition onto our stack */
				sp->lo = lo;
				sp->hi = k;
				sp++;
			}

			if (i < hi) 
			{
				/* push the second partition onto our stack */
				sp->lo = i;
				sp->hi = hi;
				sp++;
			}
		} 
		while (sp > stack);
	}

	ThFlags8 m_Flags;
	ThFlags8 m_UniqueOps;
	tbb::concurrent_vector<Private::ThListModifyOp> m_ModifyOpList;
	tbb::concurrent_vector<ItemType> m_NewItems;	
	ThVector<T> m_Value;
	ThVector<T> m_NewValue;
};

template <class T>
struct ThFieldTraits< ThListDualBufferField<T> >
{
	typedef ThiListField FieldType;
	typedef ThiListField ValueType;
	enum eSort{ListSortEnabled = 0};
};
//----------------------------------------------------------------------------------------
//
//					ThListSimpleField
//
//----------------------------------------------------------------------------------------
template <class T, bool ThreadSafe = false>
class ThListSimpleField : public ThiListFieldProxy<ThreadSafe>
{
public:

	typedef ThVector<T> ValueType;
	typedef typename T::ValueType ItemType;

	ThListSimpleField()
	{

	}

	ThListSimpleField(const ValueType& initVal)
		:
	m_Value(initVal)
	{

	}

	ThListSimpleField(const ThListSimpleField& other)
		:
	ThiListFieldProxy<ThreadSafe>(other),
	m_Value(other.m_Value)
	{
		
	}

	const ThListSimpleField& operator=(const ThListSimpleField& other)
	{
		SetValue( other.GetValue() );
		return *this;
	}

	ThBool operator==(const ThListSimpleField& other)const
	{
		return m_Value == other.GetValue();
	}

	ThBool operator!=(const ThListSimpleField& other)const
	{
		return m_Value != other.GetValue();
	}

	const ThListSimpleField& Assign(const ThVector<T>& other)
	{
		SetValue(other);
		return *this;
	}

	const ThListSimpleField& AssignValue(const ThVector<ItemType>& other)
	{
		Clear();

		for (ThSize i = 0; i < other.Size(); ++i)
		{
			PushBackItemValue(other[i]);
		}

		return *this;
	}

	THOR_DM_VIRTUAL ThiType*		GetItemFieldType()const
	{
		return ThType< typename ThFieldTraits<T>::FieldType >::Instance();
	}

	THOR_DM_VIRTUAL ThiType*		GetItemValueType()const
	{
		return ThType< typename ThFieldTraits<T>::ValueType >::Instance();
	}

	THOR_DM_VIRTUAL void Serialize(ThiArchiveWriter* archive, const ThI8* fieldName)const
	{
		Private::ThListFieldUtils::SerializeImpl(archive, fieldName, this, m_Value);
	}

	THOR_DM_VIRTUAL void Deserialize(ThiArchiveReader* archive, const ThI8* fieldName)
	{
		Private::ThListFieldUtils::DeserializeImpl(archive, fieldName, this, m_Value);
	}

#ifndef THOR_DM_THIFIELD_NOVIRTUALS
	virtual ThSize GetSizeGeneric()const
	{
		return GetSize();
	}

	virtual ThiField* GetItemGeneric(ThSize index)
	{
		//SetDirty(true);
		ScopedLock lock;
		InitScopedLock(lock);

		return &m_Value[index];
	}

	virtual const ThiField* GetItemGeneric(ThSize index)const
	{
		ScopedLock lock;
		InitScopedLock(lock);

		return &m_Value[index];
	}
#endif
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

	void SetItem(ThSize index, const T& item)
	{
		//SetDirty(true);
		ScopedLock lock;
		InitScopedLock(lock);

		m_Value[index] = item;
	}

	const T& GetItem(ThSize index)const
	{
		ScopedLock lock;
		InitScopedLock(lock);

		return m_Value[index];
	}

	T& GetItem(ThSize index)
	{
		//SetDirty(true);
		ScopedLock lock;
		InitScopedLock(lock);

		return m_Value[index];
	}

	void SetItemValue(ThSize index, const ItemType& value)
	{
		//SetDirty(true);
		ScopedLock lock;
		InitScopedLock(lock);

		m_Value[index].SetValue(value);
	}

	const ItemType& GetItemValue(ThSize index)const
	{
		ScopedLock lock;
		InitScopedLock(lock);

		return m_Value[index].GetValue();
	}

	ThSize GetSize()const
	{
		ScopedLock lock;
		InitScopedLock(lock);

		return m_Value.Size();
	}

	void Sort()
	{
		ScopedLock lock;
		InitScopedLock(lock);

		DoSort< ThFieldTraits<T>::ListSortEnabled >();
	}

	void Erase(ThSize index)
	{
		//SetDirty(true);
		ScopedLock lock;
		InitScopedLock(lock);

		m_Value.Erase(m_Value.Data() + index);
	}

	void PushBackItem(const T& item)
	{
		//SetDirty(true);
		ScopedLock lock;
		InitScopedLock(lock);

		m_Value.PushBack(item);
	}

	void PushBackItemValue(const ItemType& value)
	{
		//SetDirty(true);
		ScopedLock lock;
		InitScopedLock(lock);

		m_Value.PushBack(T(value));
	}

	void Clear()
	{
		//SetDirty(true);
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

	template <bool isSortEnabled>
	void DoSort();

	template <>
	void DoSort<true>()
	{
		//SetDirty(true);
		std::sort(m_Value.Begin(), m_Value.End(), ThListSortCompare<T>());
	}

	template <>
	void DoSort<false>()
	{

	}

	THOR_DM_VIRTUAL void Push()
	{
		//SetDirty(false);
	}

private:

#ifdef THOR_DM_THIFIELD_NOVIRTUALS
	friend struct Private::ThiFieldInternalAccess;
#endif

	ThVector<T> m_Value;
};

template <class T, bool ThreadSafe>
struct ThFieldTraits< ThListSimpleField<T, ThreadSafe> >
{
	typedef ThiListField FieldType;
	typedef ThiListField ValueType;
	enum eSort{ListSortEnabled = 0};
};

}