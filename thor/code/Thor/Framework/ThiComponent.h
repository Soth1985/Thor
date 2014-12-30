#pragma once

#include <Thor/Framework/FrameworkFwd.h>
#include <Thor/Framework/ThiComponentInterface.h>
#include <Thor/Framework/Containers/ThHashSet.h>

namespace Thor
{
//----------------------------------------------------------------------------------------
//
//					eComponentState
//
//----------------------------------------------------------------------------------------
struct eComponentState
{
	enum Val
	{
		Created,
		Initialized,
		Running,
		Paused,
		Failed,
		Count
	};
};
//----------------------------------------------------------------------------------------
//
//					ThiComponent
//
//----------------------------------------------------------------------------------------
class THOR_FRAMEWORK_DLL ThiComponent: public ThiObject
{
public:
	typedef ThHashSet<ThiType*>		TypeList;
	typedef ThVector<ThiComponentInterfacePtr>	ProvidedInterfaces;

	const TypeList&			GetRequiredInterfaces()const;
	const ProvidedInterfaces&	GetProvidedInterfaces()const;
	const TypeList&			GetPublishedEvents()const;
	const TypeList&			GetSubscribedEvents()const;

	virtual ThiTaskPtr			GetRootTask() = 0;
	virtual void				Initialize() = 0;
	virtual void				Start() = 0;
    virtual void                Pause() = 0;
    virtual void                Resume() = 0;
    virtual void                Recover() = 0;
	virtual ThBool				HandleEventSync(const ThiEventPtr& data) = 0;
	virtual void				HandleEventAsync(const ThiEventPtr& data) = 0;

protected:

	TypeList			m_RequiredInterfaces;
	ProvidedInterfaces	m_ProvidedInterfaces;
	TypeList			m_PublishedEvents;
	TypeList			m_SubscribedEvents;
};

}