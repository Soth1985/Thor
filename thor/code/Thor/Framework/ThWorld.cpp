#include <Thor/Framework/ThWorld.h>
#include <Thor/Framework/DataModel/ThiEntity.h>

namespace Thor
{

THOR_REG_TYPE(ThWorld, THOR_TYPELIST_1(ThiWorld));

ThFrameworkRootEntity* ThWorld::GetRootEntity()
{
	return m_Root.GetPtr();
}

void ThWorld::Push()
{
	Private::ThiEntityInternalAccess::Push(m_Root.GetPtr());
}

void ThWorld::OnEntityCreated(ThiEntity* entity)
{
	m_CreatedEntities.PushBack(entity);
	Private::ThiEntityInternalAccess::SetUserData(entity, this);
}

void ThWorld::OnEntityDestroyed(ThiEntity* entity)
{
	//check if it was destroyed immediately after creation
	for (ThSize i = 0; i < m_CreatedEntities.Size(); ++i)
	{
		if (m_CreatedEntities[i] == entity)
		{
			m_CreatedEntities.MoveToBackAndRemove(i);
			return;
		}
	}

	m_DestroyedEntities.PushBack(entity);
}

}