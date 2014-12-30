#include <Thor/Framework/ThiComponent.h>

namespace Thor
{

THOR_REG_TYPE(ThiComponent, THOR_TYPELIST_1(ThiObject));

//----------------------------------------------------------------------------------------
//
//					ThiComponent
//
//----------------------------------------------------------------------------------------
const ThiComponent::TypeList& ThiComponent::GetRequiredInterfaces()const
{
	return m_RequiredInterfaces;
}
//----------------------------------------------------------------------------------------
const ThiComponent::ProvidedInterfaces& ThiComponent::GetProvidedInterfaces()const
{
	return m_ProvidedInterfaces;
}
//----------------------------------------------------------------------------------------
const ThiComponent::TypeList& ThiComponent::GetPublishedEvents()const
{
	return m_PublishedEvents;
}
//----------------------------------------------------------------------------------------
const ThiComponent::TypeList& ThiComponent::GetSubscribedEvents()const
{
	return m_SubscribedEvents;
}

}