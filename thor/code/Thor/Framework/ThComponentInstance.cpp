#include <Thor/Framework/ThComponentInstance.h>
#include <Thor/Framework/ThiEvent.h>

namespace Thor
{

THOR_REG_TYPE(ThComponentInstance, THOR_TYPELIST_1(ThiObject));
//----------------------------------------------------------------------------------------
//
//					ThComponent
//
//----------------------------------------------------------------------------------------
ThComponentInstance::ThComponentInstance()
	:
m_State(eComponentState::Created)
{
	//
}
//----------------------------------------------------------------------------------------
ThComponentInstance::ThComponentInstance(const ThiComponentPtr& plugin)
	:
m_Plugin(plugin),
m_State(eComponentState::Created)
{
	//
}
//----------------------------------------------------------------------------------------
ThiType* ThComponentInstance::GetType()const
{
	return Thor::TypeOf<ThComponentInstance>();
}
//----------------------------------------------------------------------------------------
eComponentState::Val ThComponentInstance::GetState()const
{
	return m_State;
}
//----------------------------------------------------------------------------------------
void ThComponentInstance::Initialize()
{
	m_Plugin->Initialize();
}
//----------------------------------------------------------------------------------------
void ThComponentInstance::Update()
{
	//get the events from the incoming list
	m_AsyncEvents.swap( m_AsyncEventsIncoming );
	//process buffered events
	for(EventList::iterator i = m_AsyncEvents.begin(); i != m_AsyncEvents.end(); ++i)
	{
		m_Plugin->HandleEventAsync(*i);
	}

	m_AsyncEvents.clear();
	//
}
//----------------------------------------------------------------------------------------
ThiComponentPtr& ThComponentInstance::GetPlugin()
{
	return m_Plugin;
}
//----------------------------------------------------------------------------------------
void ThComponentInstance::ProcessEvent(const ThiEventPtr& eventData)
{	
	//if the event is not handled by a component synchronously, push it into async processing queue
	if( !m_Plugin->HandleEventSync(eventData) )
	{
		m_AsyncEventsIncoming.push_back(eventData);
	}
}

}