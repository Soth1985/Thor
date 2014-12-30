#ifndef THOR_GRAPHICS_THHARDWARERESOURCE_H
#define THOR_GRAPHICS_THHARDWARERESOURCE_H

#include <Thor/Graphics/GraphicsRuntimeDx11Component/ThGraphicsRuntimeDx11Fwd.h>
#include <Thor/Graphics/GraphicsRuntimeDx11Component/DirectX11.h>

namespace Thor{

namespace Private{
	template<>
	struct CreateClassInstance<ThHardwareResource, true>
	{
		static void* Create(ThU32 param)
		{
			return 0;
		}
	};
}

//----------------------------------------------------------------------------------------
//
//					ThHardwareResource
//
//----------------------------------------------------------------------------------------
class THOR_GRAPHICS_RUNTIME_DX11_DLL ThHardwareResource: public ThiObject
{
public:

	virtual ThiType* GetType()const;

	virtual ID3D11Resource* GetResource()const = 0;

	virtual const ThString& GetName()const = 0;

protected:

	ThHardwareResource();

	virtual ~ThHardwareResource() = 0;

private:

	ThHardwareResource(const ThHardwareResource& copy);

	const ThHardwareResource& operator=(const ThHardwareResource& rhs);
};

}

#endif