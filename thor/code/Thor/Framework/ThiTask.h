#pragma once

#include <Thor/Framework/FrameworkFwd.h>
#include <Thor/Framework/ThiFramework.h>
#include <Thor/Framework/ThiComponent.h>
#include <string>

namespace Thor
{
//----------------------------------------------------------------------------------------
//
//					ThiTask
//
//----------------------------------------------------------------------------------------
class THOR_FRAMEWORK_DLL ThiTask: public ThiObject
{
public:

	virtual ThBool	IsPrimaryThreadTask()const;
	virtual void	Execute()=0;
};

}