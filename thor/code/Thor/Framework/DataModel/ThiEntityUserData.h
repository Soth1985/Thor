#pragma once

#include <Thor/Framework/FrameworkFwd.h>

namespace Thor
{

class THOR_FRAMEWORK_DLL ThiEntityUserData : public ThiRtti
{

public:

	virtual void OnEntityDestroyed(ThiEntity* entity) = 0;
};

}