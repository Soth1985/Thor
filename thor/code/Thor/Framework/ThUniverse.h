#pragma once

#include <Thor/Framework/FrameworkFwdInternal.h>
#include <Thor/Framework/ThiUniverse.h>
#include <Thor/Framework/Containers/ThVector.h>
#include <Thor/Framework/ThWorld.h>

namespace Thor
{

class ThUniverse: public ThiUniverse
{
public:

	virtual ThSize		GetNumWorlds()const;
	virtual ThiWorld*	GetWorld(ThSize idx);

private:

	ThVector<ThWorld> m_Worlds;
};

}