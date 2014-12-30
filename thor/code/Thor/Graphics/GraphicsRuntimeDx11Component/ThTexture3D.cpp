#include <Thor/Graphics/GraphicsRuntimeDx11Component/ThTexture3D.h>
#include <Thor/Graphics/GraphicsRuntimeDx11Component/ThDirectX11Renderer.h>

namespace Thor{

THOR_REG_TYPE(ThTexture3D, THOR_TYPELIST_1(ThHardwareResource));
//----------------------------------------------------------------------------------------
//
//					ThTexture3D
//
//----------------------------------------------------------------------------------------
ThiType* ThTexture3D::GetType()const
{
	return ThType<ThTexture3D>::Instance();
}
//----------------------------------------------------------------------------------------
ID3D11Resource* ThTexture3D::GetResource()const
{
	return m_Texture;
}
//----------------------------------------------------------------------------------------
const ThString& ThTexture3D::GetName()const
{
	return *m_Name;
}
//----------------------------------------------------------------------------------------
ID3D11Texture3D* ThTexture3D::GetTexture()const
{
	return m_Texture;
}
//----------------------------------------------------------------------------------------
ThTexture3D::ThTexture3D(const ThString* name, ThDirectX11Renderer* renderer, ID3D11Texture3D* texture)
	:
m_Name(name),
m_Renderer(renderer),
m_Texture(texture)
{
	//
}
//----------------------------------------------------------------------------------------
ThTexture3D::ThTexture3D()
{
	//
}
//----------------------------------------------------------------------------------------
ThTexture3D::~ThTexture3D()
{
	ThGraphicsUtils::SafeRelease(m_Texture);
	m_Renderer->RemoveTexture3D(m_Name);
}
}