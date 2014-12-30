#include <Thor/Framework/ThiEvent.h>

namespace Thor
{

THOR_REG_TYPE(ThiEvent, THOR_TYPELIST_1(ThiObject));
THOR_REG_TYPE(ThiSysEvent, THOR_TYPELIST_1(ThiEvent));
THOR_REG_TYPE(ThiSimEvent, THOR_TYPELIST_1(ThiEvent));

}