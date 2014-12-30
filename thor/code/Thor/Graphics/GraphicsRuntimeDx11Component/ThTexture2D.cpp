#include <Thor/Graphics/GraphicsRuntimeDx11Component/ThTexture2D.h>
#include <Thor/Graphics/GraphicsRuntimeDx11Component/ThDirectX11Renderer.h>

namespace Thor{

THOR_REG_TYPE(ThTexture2D, THOR_TYPELIST_1(ThHardwareResource));
//----------------------------------------------------------------------------------------
//
//					ThTexture2D
//
//----------------------------------------------------------------------------------------
ThiType* ThTexture2D::GetType()const
{
	return ThType<ThTexture2D>::Instance();
}
//----------------------------------------------------------------------------------------
ID3D11Resource* ThTexture2D::GetResource()const
{
	return m_Texture;
}
//----------------------------------------------------------------------------------------
const ThString& ThTexture2D::GetName()const
{
	return *m_Name;
}
//----------------------------------------------------------------------------------------
ID3D11Texture2D* ThTexture2D::GetTexture()const
{
	return m_Texture;
}
//----------------------------------------------------------------------------------------
ThTexture2D::ThTexture2D(const ThString* name, ThDirectX11Renderer* renderer, ID3D11Texture2D* texture)
	:
m_Name(name),
m_Renderer(renderer),
m_Texture(texture)
{
	//
}
//----------------------------------------------------------------------------------------
ThTexture2D::ThTexture2D()
{
	//
}
//----------------------------------------------------------------------------------------
ThTexture2D::~ThTexture2D()
{
	ThGraphicsUtils::SafeRelease(m_Texture);
	m_Renderer->RemoveTexture2D(m_Name);
}
}