#include <Thor/Graphics/GraphicsRuntimeDx11Component/ThTexture1D.h>
#include <Thor/Graphics/GraphicsRuntimeDx11Component/ThDirectX11Renderer.h>

namespace Thor{

THOR_REG_TYPE(ThTexture1D, THOR_TYPELIST_1(ThHardwareResource));
//----------------------------------------------------------------------------------------
//
//					ThTexture1D
//
//----------------------------------------------------------------------------------------
ThiType* ThTexture1D::GetType()const
{
	return ThType<ThTexture1D>::Instance();
}
//----------------------------------------------------------------------------------------
ID3D11Resource* ThTexture1D::GetResource()const
{
	return m_Texture;
}
//----------------------------------------------------------------------------------------
const ThString& ThTexture1D::GetName()const
{
	return *m_Name;
}
//----------------------------------------------------------------------------------------
ID3D11Texture1D* ThTexture1D::GetTexture()const
{
	return m_Texture;
}
//----------------------------------------------------------------------------------------
ThTexture1D::ThTexture1D(const ThString* name, ThDirectX11Renderer* renderer, ID3D11Texture1D* texture)
	:
m_Name(name),
m_Renderer(renderer),
m_Texture(texture)
{
	//
}
//----------------------------------------------------------------------------------------
ThTexture1D::ThTexture1D()
{
	//
}
//----------------------------------------------------------------------------------------
ThTexture1D::~ThTexture1D()
{
	ThGraphicsUtils::SafeRelease(m_Texture);
	m_Renderer->RemoveTexture1D(m_Name);
}
}