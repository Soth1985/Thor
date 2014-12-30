#pragma once

#include <Thor/Framework/ThiFramework.h>
#include <Thor/Framework/ThiApplication.h>
#include <Thor/Framework/ThComponentInstance.h>
#include <Thor/Framework/FrameworkFwdInternal.h>
#include <Thor/Framework/Singleton.h>
#include <Thor/Framework/Containers/ThHashMap.h>
#include <tbb/concurrent_hash_map.h>

namespace Thor
{
//----------------------------------------------------------------------------------------
//
//					TheNotAComponent
//
//----------------------------------------------------------------------------------------
class TheNotAComponent:public ThException
{
public:
	TheNotAComponent(const ThString& name);
};
//----------------------------------------------------------------------------------------
//
//					TheComponentAlreadyExists
//
//----------------------------------------------------------------------------------------
class TheComponentAlreadyExists:public ThException
{
public:
	TheComponentAlreadyExists(const ThString& name);
};
//----------------------------------------------------------------------------------------
//
//					TheComponentInterfaceAlreadyExists
//
//----------------------------------------------------------------------------------------
class TheComponentInterfaceAlreadyExists:public ThException
{
public:
	TheComponentInterfaceAlreadyExists(const ThString& name);
};
//----------------------------------------------------------------------------------------
//
//					TheFailedToLoadPlugin
//
//----------------------------------------------------------------------------------------
class TheFailedToLoadPlugin:public ThException
{
public:
	TheFailedToLoadPlugin(const ThString& name);
};
//----------------------------------------------------------------------------------------
//
//					TheInterfaceNotAvailable
//
//----------------------------------------------------------------------------------------
class TheInterfaceNotAvailable:public ThException
{
public:
	TheInterfaceNotAvailable(const ThString& comName, const ThString& ifaceName);
};
//----------------------------------------------------------------------------------------
//
//					ThFramework
//
//----------------------------------------------------------------------------------------
class ThFramework: public ThiFramework
{
public:
	ThFramework();

	virtual ThiType*					GetType()const;	
	virtual ThBool						SwitchComponentState(const ThiComponentPtr& com, eComponentState::Val state);
	virtual eComponentState::Val		GetComponentState(const ThiComponentPtr& com)const;
	virtual ThiComponentInterfacePtr	GetComponentInterface(ThiType* type);
	virtual void						PostEvent(const ThiEventPtr& eventData);	
	virtual eFrameworkState::Val		GetFrameworkState()const;
	virtual ThBool						LoadPluginComponent(const ThString& dllName);
	virtual ThiFileSystemPtr			GetFileSystem();
	virtual ThAssemblyVersionInfo		GetAssemblyVersion()const;
	virtual	ThiUniverse*				GetUniverse();

	void								Start(const ThiApplicationPtr& app);
	void								Run();
	
private:
	typedef ThiComponent::TypeList								TypeList;
	typedef ThHashMap<ThiComponentPtr, ThComponentInstancePtr>	ComponentMap;
	//map component type to its provided interfaces
	typedef ThHashMap<ThiType*, ThiComponentInterfacePtr>		ComponentInterfacesMap;

	typedef ThVector<ThComponentInstancePtr>								ComponentInstanceList;
	typedef tbb::concurrent_hash_map<ThiType*, ComponentInstanceList>		EventFilters;

	ThiComponentPtr						LoadPluginComponentInternal(const ThString& dllName);	

	ComponentMap				m_Components;
	ComponentInterfacesMap		m_ComponentInterfaces;
	EventFilters				m_EventFilters;
	eFrameworkState::Val		m_FrameworkState;
	ThiApplicationPtr			m_Application;
	ThiFileSystemPtr			m_FileSystem;
	ThTbbTaskManagerPtr			m_TaskManager;
	ThAsyncOpManagerPtr			m_AsyncOpManager;
};
//----------------------------------------------------------------------------------------
//
//					ThFrameworkInstance
//
//----------------------------------------------------------------------------------------
class ThFrameworkInstance:public NonCopyable
{
public:	
	ThFrameworkInstance();

	ThFrameworkPtr&					GetFramework();
	ThiFrameworkPtr&				GetFrameworkInterface();

	static ThFrameworkInstance&		Instance();
private:
	typedef Singleton<ThFrameworkInstance> singleton_t;
	friend class Singleton<ThFrameworkInstance>;

	ThiFrameworkPtr		m_FrameworkInterface;
	ThFrameworkPtr		m_Framework;
};

}//Thor