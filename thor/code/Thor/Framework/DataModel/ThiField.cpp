#include <Thor/Framework/DataModel/ThiField.h>

namespace Thor
{
#ifndef THOR_DM_THIFIELD_NOVIRTUALS
THOR_REG_TYPE(ThiField, THOR_TYPELIST_1(ThiRtti));

namespace Private
{
	void ThiFieldInternalAccess::Push(ThiField* field)
	{
		field->Push();
	}
}
#else
	THOR_REG_ROOT_TYPE(ThiField);
#endif
//----------------------------------------------------------------------------------------
//
//					ThiField
//
//----------------------------------------------------------------------------------------
ThiField::ThiField()
{
	//
}

ThiField::ThiField(const ThiField& other)
{
	*this = other;
}

const ThiField& ThiField::operator=(const ThiField& other)
{
	return *this;
}

}