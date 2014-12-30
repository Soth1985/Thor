#include <Thor/Framework/ThiApplication.h>

namespace Thor
{

THOR_REG_TYPE(ThiApplication, THOR_TYPELIST_1(ThiObject));

//----------------------------------------------------------------------------------------
//
//					ThComponentDescriptor
//
//----------------------------------------------------------------------------------------
ThComponentDescriptor::ThComponentDescriptor()
	:
m_Type(0)
{
	//
}
//----------------------------------------------------------------------------------------
ThComponentDescriptor::ThComponentDescriptor(ThiType* type)
	:
m_Type(type)
{
	//
}
//----------------------------------------------------------------------------------------
ThComponentDescriptor::ThComponentDescriptor(const ThString& module)
	:
m_Module(module)
{
	//
}
//----------------------------------------------------------------------------------------
//
//					ThiApplication
//
//----------------------------------------------------------------------------------------
const ThiApplication::component_list_t& ThiApplication::GetRequiredComponents()const
{
	return m_RequiredComponents;
}

}