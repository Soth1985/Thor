#pragma once

#include <Thor/Framework/FrameworkFwd.h>
#include <Thor/Framework/ThiComponent.h>
#include <Thor/Framework/Filesystem/ThiFileSystem.h>
#include <Thor/Framework/ThAssemblyVersionInfo.h>

namespace Thor
{
//----------------------------------------------------------------------------------------
//
//					eFrameworkState
//
//----------------------------------------------------------------------------------------
struct eFrameworkState
{
	enum Val
	{
		eCreated,
		eInitialized,
		eRunning
	};
};
//----------------------------------------------------------------------------------------
//
//					ThiFramework
//
//----------------------------------------------------------------------------------------
class THOR_FRAMEWORK_DLL ThiFramework : public ThiObject
{
public:

	virtual ThBool						SwitchComponentState(const ThiComponentPtr& com, eComponentState::Val state) = 0;
	virtual eComponentState::Val		GetComponentState(const ThiComponentPtr& com)const = 0;
	virtual ThiComponentInterfacePtr	GetComponentInterface(ThiType* type) = 0;
	virtual void						PostEvent(const ThiEventPtr& eventData) = 0;	
	virtual ThiFileSystemPtr			GetFileSystem() = 0;
	virtual eFrameworkState::Val		GetFrameworkState()const = 0;
	virtual ThBool						LoadPluginComponent(const ThString& dllName) = 0;
	virtual ThAssemblyVersionInfo		GetAssemblyVersion()const = 0;
	virtual	ThiUniverse*				GetUniverse() = 0;
};	

void THOR_FRAMEWORK_DLL					RunApplication(const ThiApplicationPtr& app);
ThiFrameworkPtr THOR_FRAMEWORK_DLL		GetFramework();

typedef ThiComponentPtr (*ThPluginFunc)();

}