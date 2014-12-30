#include <Thor/Framework/ThFramework.h>
#include <Thor/Framework/ThLogger.h>
#include <Thor/Framework/ThPlatformUtils.h>
#include <Thor/Framework/Filesystem/LoggerFileOutput.h>
#include <Thor/Framework/FrameworkAI.inl>
#include <Thor/Framework/ThAsyncOpManager.h>
#include <Thor/Framework/ThTbbTaskManager.h>
#include <Thor/Framework/ThiEvent.h>

#ifdef THOR_USE_BOOSTFS
	#include <Thor/Framework/Filesystem/BoostFileSystem.h>
#elif defined(THOR_USE_PHYSFS)
	#include <Thor/Framework/Filesystem/PhysFileSystem.h>
#endif

namespace Thor
{

const ThI8* frameworkSysLogTag="ThSys";

THOR_REG_TYPE(ThFramework, THOR_TYPELIST_1(ThiFramework));
//----------------------------------------------------------------------------------------
void RunApplication(const ThiApplicationPtr& app)
{
	ThFrameworkInstance::Instance().GetFramework()->Start(app);
}
//----------------------------------------------------------------------------------------
ThiFrameworkPtr GetFramework()
{
	ThiFrameworkPtr framework = ThFrameworkInstance::Instance().GetFrameworkInterface();

	if(framework && framework->GetFrameworkState() != eFrameworkState::eCreated)
		return framework;
	else
		return ThiFrameworkPtr();
}
//----------------------------------------------------------------------------------------
//
//					TheNotAComponent
//
//----------------------------------------------------------------------------------------
TheNotAComponent::TheNotAComponent(const ThString& name)
	:
ThException(name + " is not a component")
{
	//
}
//----------------------------------------------------------------------------------------
//
//					TheComponentAlreadyExists
//
//----------------------------------------------------------------------------------------
TheComponentAlreadyExists::TheComponentAlreadyExists(const ThString& name)
	:
ThException(ThString("Component ") + name + " already exists" )
{
	//
}
//----------------------------------------------------------------------------------------
//
//					TheFailedToLoadPlugin
//
//----------------------------------------------------------------------------------------
TheFailedToLoadPlugin::TheFailedToLoadPlugin(const ThString& name)
:
ThException(ThString("Failed to load plugin ") + name )
{
	//
}
//----------------------------------------------------------------------------------------
//
//					TheComponentInterfaceAlreadyExists
//
//----------------------------------------------------------------------------------------
TheComponentInterfaceAlreadyExists::TheComponentInterfaceAlreadyExists(const ThString& name)
	:
ThException(ThString("Component interface ") + name + " already exists" )
{
	//
}
//----------------------------------------------------------------------------------------
//
//					TheInterfaceNotAvailable
//
//----------------------------------------------------------------------------------------
TheInterfaceNotAvailable::TheInterfaceNotAvailable(const ThString& comName, const ThString& ifaceName)
	:
ThException(ThString("Component ") + comName + " requires interface " + ifaceName + " which does not exist")
{
}
//----------------------------------------------------------------------------------------
//
//					ThFramework
//
//----------------------------------------------------------------------------------------
ThFramework::ThFramework()
	:
m_FrameworkState(eFrameworkState::eCreated),
m_AsyncOpManager( new ThAsyncOpManager() ),
m_TaskManager( new ThTbbTaskManager() )
{
#ifdef THOR_USE_BOOSTFS
	m_FileSystem = new ThBoostFileSystem();
#elif defined(THOR_USE_PHYSFS)
	m_FileSystem = new ThPhysFileSystem();
#endif

	ThiFileStreamPtr file = m_FileSystem->OpenFile("FrameworkLog.txt", eStreamMode::WriteMode, eFileWriteMode::Truncate);
	ThiLoggerOutputTargetPtr foutput( new ThLoggerFileOutput(file) );
	ThLogger::Instance().AddOutputTarget(foutput);
	THOR_INF("Thor framework version %s is instantiated")(frameworkSysLogTag, s_AssemblyInfo.ToString().c_str());
	ThPlatformUtils::SetupMinidump(eMinidumpLevel::Med);
}
//----------------------------------------------------------------------------------------
ThiType* ThFramework::GetType()const
{
	return ThType<ThFramework>::Instance();
}
//----------------------------------------------------------------------------------------
void ThFramework::PostEvent(const ThiEventPtr &eventData)
{	
	ThiType* eventType = eventData->GetType();
	//check if this event is not filtered out
	EventFilters::accessor access;
	//check the cache first
	if( m_EventFilters.find(access, eventType) )
	{
		//let all the components interested in this events process it
		for(ComponentInstanceList::Iterator ci = access->second.Begin(); ci != access->second.End(); ++ci)
			(*ci)->ProcessEvent(eventData);
	}
	else
	{
		ComponentInstanceList subscribedComponents;
		//get all components interested in this event
		for(ComponentMap::Iterator com = m_Components.Begin(); com != m_Components.End(); ++com)
		{
			ThComponentInstancePtr& comInstance = com->Value();
			const ThiComponentPtr&	comIface = com->Key();			
			//check component whether this type of event is to be filtered out
			for(TypeList::ConstIterator i = comIface->GetSubscribedEvents().Begin(); i != comIface->GetSubscribedEvents().End(); ++i)
			{
				ThiType* t = i->Key();			
				if( IsConvertible(eventType, t) )
				{
					comInstance->ProcessEvent(eventData);
					subscribedComponents.PushBack(comInstance);
				}
			}
		}
		//insert the result into the filter
		m_EventFilters.insert( EventFilters::value_type(eventType, subscribedComponents) );		
	}	
}
//----------------------------------------------------------------------------------------
ThBool ThFramework::SwitchComponentState(const ThiComponentPtr& com, eComponentState::Val state)
{
	return false;
}
//----------------------------------------------------------------------------------------
eComponentState::Val ThFramework::GetComponentState(const ThiComponentPtr& com)const
{
	ComponentMap::ConstIterator comInstance = m_Components.Find(com);
	
	if( comInstance != m_Components.End() )
		return comInstance->Value()->GetState();

	return eComponentState::Failed;
}
//----------------------------------------------------------------------------------------
ThiComponentInterfacePtr ThFramework::GetComponentInterface(ThiType* type)
{
	ComponentInterfacesMap::Iterator i = m_ComponentInterfaces.Find(type);

	if( i != m_ComponentInterfaces.End() )
		return i->Value();
	else
		return ThiComponentInterfacePtr();
}
//----------------------------------------------------------------------------------------
void ThFramework::Start(const ThiApplicationPtr& app)
{
	if(!m_Application)
	{
		mutex_t::scoped_lock lock(m_Mutex);
		if(!m_Application)
		{
			m_Application = app;
			//process required components list
			ThiApplication::component_list_t components = m_Application->GetRequiredComponents();
			
			for(ThiApplication::component_list_t::iterator i = components.begin(); i != components.end(); ++i)
			{
				ThiType* comType = i->m_Type;
				ThiComponentPtr plugin;
				//if type is not set in the descriptor -> try to load a plugin
				if(!comType)
				{
					plugin = LoadPluginComponentInternal(i->m_Module);
				}
				else//else create it manually
				{
					plugin = comType->CreateObject<ThiComponent>();
				}				

				if( !plugin )
					throw TheNotAComponent( comType->GetName() );
				//create component
				ThComponentInstancePtr com = new ThComponentInstance(plugin);

				//push the component into the framework
				if( !m_Components.Insert(plugin,com) )
					throw TheComponentAlreadyExists( comType->GetName() );
				//create and register component`s provided interfaces
				ThiComponent::ProvidedInterfaces providedIfaces = plugin->GetProvidedInterfaces();

				for(ThiComponent::ProvidedInterfaces::Iterator itype = providedIfaces.Begin(); itype != providedIfaces.End(); ++itype)
				{					
					ThiComponentInterfacePtr interface = *itype;

					if(interface)
					{
						if( !m_ComponentInterfaces.Insert( interface->GetType(), interface)  )
							throw TheComponentInterfaceAlreadyExists( interface->GetType()->GetName() );
					}
				}				
			}
			//initialize components
			for(ComponentMap::Iterator com = m_Components.Begin(); com != m_Components.End(); ++com)
			{
				ThComponentInstancePtr comInst = com->Value();
				ThiComponent::TypeList requiredInterfaces = comInst->GetPlugin()->GetRequiredInterfaces();
				//check if we have all required interfaces for this component
				for(ThiComponent::TypeList::Iterator itype = requiredInterfaces.Begin(); itype != requiredInterfaces.End(); ++itype)
				{
					ThiType* ifaceType = itype->Key();
					if( m_ComponentInterfaces.Find(ifaceType) == m_ComponentInterfaces.End() )
						throw TheInterfaceNotAvailable(comInst->GetType()->GetName(), ifaceType->GetName());
				}
				comInst->Initialize();
			}			
			//TODO build component dependencies
			m_FrameworkState = eFrameworkState::eInitialized;
			Run();
		}		
	}
	else
	{
		THOR_ERR("Framework is already hosting the application %s, attempt to reinitialize it with an application %s")
			(frameworkSysLogTag, m_Application->GetApplicationName().c_str(), app->GetApplicationName().c_str() );
	}	
}
//----------------------------------------------------------------------------------------
void ThFramework::Run()
{
	//main loop
	m_FrameworkState = eFrameworkState::eRunning;
	while(true)
	{
		ThPlatformUtils::DispatchOperatingSystemMessages();
		m_AsyncOpManager->Update();
		m_TaskManager->ExecuteTasks();
	}
}
//----------------------------------------------------------------------------------------
eFrameworkState::Val ThFramework::GetFrameworkState()const
{
	return m_FrameworkState;
}
//----------------------------------------------------------------------------------------
ThBool ThFramework::LoadPluginComponent(const ThString& dllName)
{
	return false;
}
//----------------------------------------------------------------------------------------
ThiComponentPtr ThFramework::LoadPluginComponentInternal(const ThString& dllName)
{
	ThiDynamicLibraryPtr dll = GetFileSystem()->LoadDynamicLibrary(dllName);

	if(!dll)
	{
		throw TheFailedToLoadPlugin(dllName);
		return ThiComponentPtr();
	}
	else
	{
		ThPluginFunc plugin;
		plugin = (ThPluginFunc)dll->GetProcedureAddress("GetComponent");

		if(plugin)
		{
			return plugin();
		}
		else
		{
			throw TheFailedToLoadPlugin(dllName);
			return ThiComponentPtr();
		}
	}
}
//----------------------------------------------------------------------------------------
ThiFileSystemPtr ThFramework::GetFileSystem()
{
	return m_FileSystem;
}
//----------------------------------------------------------------------------------------
ThAssemblyVersionInfo ThFramework::GetAssemblyVersion()const
{
	return s_AssemblyInfo;
}
//----------------------------------------------------------------------------------------
ThiUniverse* ThFramework::GetUniverse()
{
	return 0;
}
//----------------------------------------------------------------------------------------
//
//					ThFrameworkInstance
//
//----------------------------------------------------------------------------------------
ThFrameworkPtr& ThFrameworkInstance::GetFramework()
{
	return m_Framework;
}
//----------------------------------------------------------------------------------------
ThiFrameworkPtr& ThFrameworkInstance::GetFrameworkInterface()
{
	return m_FrameworkInterface;
}
//----------------------------------------------------------------------------------------
ThFrameworkInstance& ThFrameworkInstance::Instance()
{
	return singleton_t::Instance();
}
//----------------------------------------------------------------------------------------
ThFrameworkInstance::ThFrameworkInstance()
{
	m_Framework = new ThFramework();
	m_FrameworkInterface = m_Framework;
}

}