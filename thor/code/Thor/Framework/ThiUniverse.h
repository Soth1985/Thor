#pragma once

#include <Thor/Framework/FrameworkFwd.h>

namespace Thor
{

class THOR_FRAMEWORK_DLL ThiUniverse: public ThiRtti
{
public:

	virtual ThSize		GetNumWorlds()const = 0;
	virtual ThiWorld*	GetWorld(ThSize idx) = 0;
};

}