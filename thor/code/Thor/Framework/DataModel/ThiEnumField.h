#pragma once

#include <Thor/Framework/DataModel/ThiField.h>

namespace Thor
{
//----------------------------------------------------------------------------------------
//
//					ThiEnumField
//
//----------------------------------------------------------------------------------------
class THOR_FRAMEWORK_DLL ThiEnumField: public ThiField
{
public:

	ThiEnumField();

	ThiEnumField(const ThiEnumField& other);

	virtual ThiType*		GetType()const;

	virtual ThiType* GetEnumType()const = 0;

	virtual const char* GetEnumName()const = 0;

	virtual ThBool IsFlags()const = 0;

	virtual ThSize GetNumItems()const = 0;

	virtual ThU32 GetItemValue(ThSize index) = 0;

	virtual const char* GetItemName(ThSize index) = 0;

	virtual void SetValue(ThU32 value) = 0;

	virtual ThU32 GetValue()const = 0;

protected:

	const ThiEnumField& operator=(const ThiEnumField& other);
};

THOR_DECL_TYPE(Thor::ThiEnumField);
//----------------------------------------------------------------------------------------
//
//					ThiEnumDualBufferField
//
//----------------------------------------------------------------------------------------
class THOR_FRAMEWORK_DLL ThiEnumDualBufferField: public ThiEnumField
{
public:

	typedef ThU32 ValueType;

	ThiEnumDualBufferField();

	ThiEnumDualBufferField(ThU32 initVal);

	ThiEnumDualBufferField(const ThiEnumDualBufferField& other);

	const ThiEnumDualBufferField& operator=(const ThiEnumDualBufferField& other);

	ThBool operator==(ThU32 other)const;

	ThBool operator!=(ThU32 other)const;

	ThBool operator==(const ThiEnumDualBufferField& other)const;

	ThBool operator!=(const ThiEnumDualBufferField& other)const;

	virtual void Serialize(ThiArchiveWriter* archive, const ThI8* fieldName)const;

	virtual void Deserialize(ThiArchiveReader* archive, const ThI8* fieldName);

	virtual void SetValue(ThU32 value);

	virtual ThU32 GetValue()const;

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

	virtual void Push();

private:

	ThU32 m_Value;
	ThU32 m_NewValue;
	ThFlags8 m_Flags;
	tbb::spin_mutex m_Mutex;
};

THOR_DECL_TYPE(Thor::ThiEnumDualBufferField);
//----------------------------------------------------------------------------------------
//
//					ThiEnumSimpleField
//
//----------------------------------------------------------------------------------------
class THOR_FRAMEWORK_DLL ThiEnumSimpleField: public ThiEnumField
{
public:

	typedef ThU32 ValueType;

	ThiEnumSimpleField();

	ThiEnumSimpleField(ThU32 initVal);

	ThiEnumSimpleField(const ThiEnumSimpleField& other);

	const ThiEnumSimpleField& operator=(const ThiEnumSimpleField& other);

	ThBool operator==(ThU32 other)const;

	ThBool operator!=(ThU32 other)const;

	ThBool operator==(const ThiEnumSimpleField& other)const;

	ThBool operator!=(const ThiEnumSimpleField& other)const;

	virtual void Serialize(ThiArchiveWriter* archive, const ThI8* fieldName)const;

	virtual void Deserialize(ThiArchiveReader* archive, const ThI8* fieldName);

	virtual void SetValue(ThU32 value);

	virtual ThU32 GetValue()const;

	ThBool IsDirty()const
	{
		return true;
	}

	ThBool IsDefaultValue()const
	{
		return false;
	}

protected:	

	virtual void Push();

private:

	ThU32 m_Value;
};

THOR_DECL_TYPE(Thor::ThiEnumSimpleField);
//----------------------------------------------------------------------------------------
//
//					ThiEnumSimpleFieldThreadSafe
//
//----------------------------------------------------------------------------------------
class THOR_FRAMEWORK_DLL ThiEnumSimpleFieldThreadSafe: public ThiEnumField
{
public:

	typedef ThU32 ValueType;

	ThiEnumSimpleFieldThreadSafe();

	ThiEnumSimpleFieldThreadSafe(ThU32 initVal);

	ThiEnumSimpleFieldThreadSafe(const ThiEnumSimpleFieldThreadSafe& other);

	const ThiEnumSimpleFieldThreadSafe& operator=(const ThiEnumSimpleFieldThreadSafe& other);

	ThBool operator==(ThU32 other)const;

	ThBool operator!=(ThU32 other)const;

	ThBool operator==(const ThiEnumSimpleFieldThreadSafe& other)const;

	ThBool operator!=(const ThiEnumSimpleFieldThreadSafe& other)const;

	virtual void Serialize(ThiArchiveWriter* archive, const ThI8* fieldName)const;

	virtual void Deserialize(ThiArchiveReader* archive, const ThI8* fieldName);

	virtual void SetValue(ThU32 value);

	virtual ThU32 GetValue()const;

	ThBool IsDirty()const
	{
		return true;
	}

	ThBool IsDefaultValue()const
	{
		return false;
	}

protected:	

	virtual void Push();

private:

	ThU32 m_Value;
	mutable tbb::spin_mutex m_Mutex;
};

THOR_DECL_TYPE(Thor::ThiEnumSimpleFieldThreadSafe);

}