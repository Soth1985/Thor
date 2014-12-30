#include <Thor/Framework/ThUniverse.h>

namespace Thor
{

THOR_REG_TYPE(ThUniverse, THOR_TYPELIST_1(ThiUniverse));

ThSize		ThUniverse::GetNumWorlds()const
{
	return m_Worlds.Size();
}

ThiWorld*	ThUniverse::GetWorld(ThSize idx)
{
	return &m_Worlds[idx];
}

}