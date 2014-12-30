#include <Thor/Framework/DataModel/ThiEnumField.h>

namespace Thor
{

THOR_REG_TYPE(ThiEnumField, THOR_TYPELIST_1(ThiField));
THOR_REG_TYPE(ThiEnumDualBufferField, THOR_TYPELIST_1(ThiEnumField));
THOR_REG_TYPE(ThiEnumSimpleField, THOR_TYPELIST_1(ThiEnumField));
THOR_REG_TYPE(ThiEnumSimpleFieldThreadSafe, THOR_TYPELIST_1(ThiEnumField));
//----------------------------------------------------------------------------------------
//
//					ThiEnumField
//
//----------------------------------------------------------------------------------------
ThiEnumField::ThiEnumField()
{

}

ThiEnumField::ThiEnumField(const ThiEnumField& other)
	:
ThiField(other)
{

}

const ThiEnumField& ThiEnumField::operator=(const ThiEnumField& other)
{
	return *this;
}

ThiType* ThiEnumField::GetType()const
{
	return ThType<ThiEnumField>::Instance();
}
//----------------------------------------------------------------------------------------
//
//					ThiEnumDualBufferField
//
//----------------------------------------------------------------------------------------
ThiEnumDualBufferField::ThiEnumDualBufferField()
	:
ThiEnumField()
{
	m_Flags.SetFlag(true, Private::eFieldFlags::IsDefaultValue);
}

ThiEnumDualBufferField::ThiEnumDualBufferField(ThU32 initVal)
	:
m_Value(initVal)
{
	m_Flags.SetFlag(true, Private::eFieldFlags::IsDefaultValue);
}

ThiEnumDualBufferField::ThiEnumDualBufferField(const ThiEnumDualBufferField& other)
	:
ThiEnumField(other),
m_Value(other.m_Value)
{
	
}

const ThiEnumDualBufferField& ThiEnumDualBufferField::operator=(const ThiEnumDualBufferField& other)
{
	SetValue(other.GetValue());
	return *this;
}

ThBool ThiEnumDualBufferField::operator==(ThU32 other)const
{
	return m_Value == other;
}

ThBool ThiEnumDualBufferField::operator!=(ThU32 other)const
{
	return m_Value != other;
}

ThBool ThiEnumDualBufferField::operator==(const ThiEnumDualBufferField& other)const
{
	return m_Value == other.GetValue();
}

ThBool ThiEnumDualBufferField::operator!=(const ThiEnumDualBufferField& other)const
{
	return m_Value != other.GetValue();
}


void ThiEnumDualBufferField::Serialize(ThiArchiveWriter* archive, const ThI8* fieldName)const
{
	archive->WriteEnumField(fieldName, GetEnumName(), m_Value);
}

void ThiEnumDualBufferField::Deserialize(ThiArchiveReader* archive, const ThI8* fieldName)
{
	if (archive->ReadEnumField(fieldName, GetEnumName(), m_Value))
		SetIsDefault(false);
}

void ThiEnumDualBufferField::SetValue(ThU32 value)
{
	tbb::spin_mutex::scoped_lock lock(m_Mutex);
	SetDirty(true);
	m_NewValue = value;
}

ThU32 ThiEnumDualBufferField::GetValue()const
{
	return m_Value;
}

void ThiEnumDualBufferField::Push()
{
	if (IsDirty())
	{
		m_Value = m_NewValue;
		SetDirty(false);
	}
}
//----------------------------------------------------------------------------------------
//
//					ThiEnumSimpleField
//
//----------------------------------------------------------------------------------------
ThiEnumSimpleField::ThiEnumSimpleField()
	:
ThiEnumField()
{

}

ThiEnumSimpleField::ThiEnumSimpleField(ThU32 initVal)
	:
m_Value(initVal)
{

}

ThiEnumSimpleField::ThiEnumSimpleField(const ThiEnumSimpleField& other)
	:
ThiEnumField(other),
m_Value(other.m_Value)
{

}

const ThiEnumSimpleField& ThiEnumSimpleField::operator=(const ThiEnumSimpleField& other)
{
	SetValue(other.GetValue());
	return *this;
}

ThBool ThiEnumSimpleField::operator==(ThU32 other)const
{
	return m_Value == other;
}

ThBool ThiEnumSimpleField::operator!=(ThU32 other)const
{
	return m_Value != other;
}

ThBool ThiEnumSimpleField::operator==(const ThiEnumSimpleField& other)const
{
	return m_Value == other.GetValue();
}

ThBool ThiEnumSimpleField::operator!=(const ThiEnumSimpleField& other)const
{
	return m_Value != other.GetValue();
}

void ThiEnumSimpleField::Serialize(ThiArchiveWriter* archive, const char* fieldName)const
{
	archive->WriteEnumField(fieldName, GetEnumName(), m_Value);
}

void ThiEnumSimpleField::Deserialize(ThiArchiveReader* archive, const char* fieldName)
{
	archive->ReadEnumField(fieldName, GetEnumName(), m_Value);
}

void ThiEnumSimpleField::SetValue(ThU32 value)
{
	m_Value = value;
}

ThU32 ThiEnumSimpleField::GetValue()const
{
	return m_Value;
}

void ThiEnumSimpleField::Push()
{
	
}
//----------------------------------------------------------------------------------------
//
//					ThiEnumSimpleFieldThreadSafe
//
//----------------------------------------------------------------------------------------
ThiEnumSimpleFieldThreadSafe::ThiEnumSimpleFieldThreadSafe()
	:
ThiEnumField()
{

}

ThiEnumSimpleFieldThreadSafe::ThiEnumSimpleFieldThreadSafe(ThU32 initVal)
	:
m_Value(initVal)
{

}

ThiEnumSimpleFieldThreadSafe::ThiEnumSimpleFieldThreadSafe(const ThiEnumSimpleFieldThreadSafe& other)
	:
ThiEnumField(other),
m_Value(other.m_Value)
{

}

const ThiEnumSimpleFieldThreadSafe& ThiEnumSimpleFieldThreadSafe::operator=(const ThiEnumSimpleFieldThreadSafe& other)
{
	SetValue(other.GetValue());
	return *this;
}

ThBool ThiEnumSimpleFieldThreadSafe::operator==(ThU32 other)const
{
	return m_Value == other;
}

ThBool ThiEnumSimpleFieldThreadSafe::operator!=(ThU32 other)const
{
	return m_Value != other;
}

ThBool ThiEnumSimpleFieldThreadSafe::operator==(const ThiEnumSimpleFieldThreadSafe& other)const
{
	return m_Value == other.GetValue();
}

ThBool ThiEnumSimpleFieldThreadSafe::operator!=(const ThiEnumSimpleFieldThreadSafe& other)const
{
	return m_Value != other.GetValue();
}

void ThiEnumSimpleFieldThreadSafe::Serialize(ThiArchiveWriter* archive, const char* fieldName)const
{
	archive->WriteEnumField(fieldName, GetEnumName(), m_Value);
}

void ThiEnumSimpleFieldThreadSafe::Deserialize(ThiArchiveReader* archive, const char* fieldName)
{
	archive->ReadEnumField(fieldName, GetEnumName(), m_Value);
}

void ThiEnumSimpleFieldThreadSafe::SetValue(ThU32 value)
{
	tbb::spin_mutex::scoped_lock lock(m_Mutex);
	m_Value = value;
}

ThU32 ThiEnumSimpleFieldThreadSafe::GetValue()const
{
	tbb::spin_mutex::scoped_lock lock(m_Mutex);
	return m_Value;
}

void ThiEnumSimpleFieldThreadSafe::Push()
{

}
}