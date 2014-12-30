#pragma once

#include <Thor/Framework/FrameworkFwdInternal.h>
#include <Thor/Framework/ThiComponent.h>
#include <tbb/concurrent_vector.h>

namespace Thor
{
//----------------------------------------------------------------------------------------
//
//					ThComponentInstance
//
//----------------------------------------------------------------------------------------
class ThComponentInstance: public ThiObject
{
public:

	ThComponentInstance();

	ThComponentInstance(const ThiComponentPtr& plugin);

	typedef ThiComponent::TypeList					TypeList;	
	typedef tbb::concurrent_vector< ThiEventPtr >		EventList;

	virtual ThiType*		GetType()const;	
	void					ProcessEvent(const ThiEventPtr& eventData);
	ThiComponentPtr&		GetPlugin();
	void					Update();
	eComponentState::Val	GetState()const;
	void					Initialize();

private:

	eComponentState::Val	m_State;
    ThiComponentPtr			m_Plugin;	
	EventList			m_AsyncEvents;
	EventList			m_AsyncEventsIncoming;
};

}