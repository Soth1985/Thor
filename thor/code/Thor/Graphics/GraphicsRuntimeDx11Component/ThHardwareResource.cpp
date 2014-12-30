#include <Thor/Graphics/GraphicsRuntimeDx11Component/ThHardwareResource.h>

namespace Thor{

THOR_REG_TYPE(ThHardwareResource, THOR_TYPELIST_1(ThiObject));
//----------------------------------------------------------------------------------------
//
//					ThHardwareResource
//
//----------------------------------------------------------------------------------------
ThHardwareResource::ThHardwareResource()
{
	//
}
//----------------------------------------------------------------------------------------
ThHardwareResource::~ThHardwareResource()
{
	//
}
//----------------------------------------------------------------------------------------
ThHardwareResource::ThHardwareResource(const ThHardwareResource& copy)
{
	//
}
//----------------------------------------------------------------------------------------
const ThHardwareResource& ThHardwareResource::operator=(const ThHardwareResource& rhs)
{
	return *this;
}
//----------------------------------------------------------------------------------------
ThiType* ThHardwareResource::GetType()const
{
	return ThType<ThHardwareResource>::Instance();
}

}