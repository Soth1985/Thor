#ifndef THOR_GRAPHICS_THHARDWAREBUFFER_H
#define THOR_GRAPHICS_THHARDWAREBUFFER_H

#include <Thor/Graphics/GraphicsRuntimeDx11Component/ThHardwareResource.h>

namespace Thor{

namespace Private{
	template<>
	struct CreateClassInstance<ThHardwareBuffer, false>
	{
		static void* Create(ThU32 param)
		{
			return 0;
		}
	};
}
//----------------------------------------------------------------------------------------
//
//					ThHardwareBuffer
//
//----------------------------------------------------------------------------------------
class THOR_GRAPHICS_RUNTIME_DX11_DLL ThHardwareBuffer: public ThHardwareResource
{
public:

	virtual ThiType* GetType()const;

	virtual ID3D11Resource* GetResource()const;

	virtual const ThString& GetName()const;

	ID3D11Buffer* GetBuffer()const;

protected:

	friend class ThDirectX11Renderer;

	ThHardwareBuffer(const ThString* name, ThDirectX11Renderer* renderer, ID3D11Buffer* buffer);

	ThHardwareBuffer();

	~ThHardwareBuffer();

	const ThString*			m_Name;
	ThDirectX11Renderer*	m_Renderer;
	ID3D11Buffer*			m_Buffer;
};

}

#endif