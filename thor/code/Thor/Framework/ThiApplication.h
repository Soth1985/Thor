#pragma once

#include <Thor/Framework/FrameworkFwd.h>

namespace Thor
{
//----------------------------------------------------------------------------------------
//
//					ThComponentDescriptor
//
//----------------------------------------------------------------------------------------
struct THOR_FRAMEWORK_DLL ThComponentDescriptor
{
	ThComponentDescriptor();

	ThComponentDescriptor(ThiType* type);

	ThComponentDescriptor(const ThString& module);

	ThiType*	m_Type;
	ThString	m_Module;
	ThString	m_ConfigFile;
};
//----------------------------------------------------------------------------------------
//
//					ThiApplication
//
//----------------------------------------------------------------------------------------
class THOR_FRAMEWORK_DLL ThiApplication:public ThiObject
{
public:
	typedef std::vector<ThComponentDescriptor>	component_list_t;	

	virtual ThString				GetApplicationName()const=0;
	const component_list_t&			GetRequiredComponents()const;	
protected:
	component_list_t			m_RequiredComponents;
};

}//Thor