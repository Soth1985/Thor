#ifndef THOR_GRAPHICS_TEXTURE1D_H
#define THOR_GRAPHICS_TEXTURE1D_H

#include <Thor/Graphics/GraphicsRuntimeDx11Component/ThHardwareResource.h>

namespace Thor
{

namespace Private{
	template<>
	struct CreateClassInstance<ThTexture1D, false>
	{
		static void* Create(ThU32 param)
		{
			return 0;
		}
	};
}
//----------------------------------------------------------------------------------------
//
//					ThTexture1D
//
//----------------------------------------------------------------------------------------
class ThTexture1D: public ThHardwareResource
{
public:

	virtual ThiType* GetType()const;

	virtual ID3D11Resource* GetResource()const;

	virtual const ThString& GetName()const;

	ID3D11Texture1D* GetTexture()const;

protected:

	friend class ThDirectX11Renderer;

	ThTexture1D(const ThString* name, ThDirectX11Renderer* renderer, ID3D11Texture1D* texture);

	ThTexture1D();

	~ThTexture1D();

	const ThString*			m_Name;
	ThDirectX11Renderer*	m_Renderer;
	ID3D11Texture1D*		m_Texture;
};

}

#endif