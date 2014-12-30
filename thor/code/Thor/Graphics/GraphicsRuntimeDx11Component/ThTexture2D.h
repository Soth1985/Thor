#ifndef THOR_GRAPHICS_TEXTURE2D_H
#define THOR_GRAPHICS_TEXTURE2D_H

#include <Thor/Graphics/GraphicsRuntimeDx11Component/ThHardwareResource.h>

namespace Thor
{
namespace Private{
	template<>
	struct CreateClassInstance<ThTexture2D, false>
	{
		static void* Create(ThU32 param)
		{
			return 0;
		}
	};
}
//----------------------------------------------------------------------------------------
//
//					ThTexture2D
//
//----------------------------------------------------------------------------------------
class ThTexture2D: public ThHardwareResource
{
public:

	virtual ThiType* GetType()const;

	virtual ID3D11Resource* GetResource()const;

	virtual const ThString& GetName()const;

	ID3D11Texture2D* GetTexture()const;

protected:

	friend class ThDirectX11Renderer;

	ThTexture2D(const ThString* name, ThDirectX11Renderer* renderer, ID3D11Texture2D* texture);

	ThTexture2D();

	~ThTexture2D();

	const ThString*			m_Name;
	ThDirectX11Renderer*	m_Renderer;
	ID3D11Texture2D*		m_Texture;
};

}

#endif