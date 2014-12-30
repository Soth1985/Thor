#pragma once

#include <Thor/Framework/FrameworkFwdInternal.h>
#include <Thor/Framework/ThiWorld.h>
#include <Thor/Framework/Containers/ThVector.h>
#include <Thor/Framework/DataModel/ThiEntityUserData.h>

namespace Thor
{

class ThWorld: public ThiWorld, public ThiEntityUserData
{
public:

	virtual ThFrameworkRootEntity*		GetRootEntity();

	void Push();

protected:

	virtual void OnEntityCreated(ThiEntity* entity);
	virtual void OnEntityDestroyed(ThiEntity* entity);

	ThFrameworkRootEntityPtr m_Root;
	ThVector<ThiEntity*> m_CreatedEntities;
	ThVector<ThiEntity*> m_DestroyedEntities;
};

}