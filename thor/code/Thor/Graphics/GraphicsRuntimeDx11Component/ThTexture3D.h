#ifndef THOR_GRAPHICS_TEXTURE3D_H
#define THOR_GRAPHICS_TEXTURE3D_H

#include <Thor/Graphics/GraphicsRuntimeDx11Component/ThHardwareResource.h>

namespace Thor
{
namespace Private{
	template<>
	struct CreateClassInstance<ThTexture3D, false>
	{
		static void* Create(ThU32 param)
		{
			return 0;
		}
	};
}
//----------------------------------------------------------------------------------------
//
//					ThTexture3D
//
//----------------------------------------------------------------------------------------
class ThTexture3D: public ThHardwareResource
{
public:

	virtual ThiType* GetType()const;

	virtual ID3D11Resource* GetResource()const;

	virtual const ThString& GetName()const;

	ID3D11Texture3D* GetTexture()const;

protected:

	friend class ThDirectX11Renderer;

	ThTexture3D(const ThString* name, ThDirectX11Renderer* renderer, ID3D11Texture3D* textue);

	ThTexture3D();

	~ThTexture3D();

	const ThString*			m_Name;
	ThDirectX11Renderer*	m_Renderer;
	ID3D11Texture3D*		m_Texture;
};

}

#endif