#include <Thor/Graphics/GraphicsRuntimeDx11Component/ThHardwareBuffer.h>
#include <Thor/Graphics/GraphicsRuntimeDx11Component/ThDirectX11Renderer.h>

namespace Thor{

THOR_REG_TYPE(ThHardwareBuffer, THOR_TYPELIST_1(ThHardwareResource));
//----------------------------------------------------------------------------------------
//
//					ThHardwareBuffer
//
//----------------------------------------------------------------------------------------
ThiType* ThHardwareBuffer::GetType()const
{
	return ThType<ThHardwareBuffer>::Instance();
}
//----------------------------------------------------------------------------------------
ID3D11Resource* ThHardwareBuffer::GetResource()const
{
	return m_Buffer;
}
//----------------------------------------------------------------------------------------
const ThString& ThHardwareBuffer::GetName()const
{
	return *m_Name;
}
//----------------------------------------------------------------------------------------
ID3D11Buffer* ThHardwareBuffer::GetBuffer()const
{
	return m_Buffer;
}
//----------------------------------------------------------------------------------------
ThHardwareBuffer::ThHardwareBuffer(const ThString* name, ThDirectX11Renderer* renderer, ID3D11Buffer* buffer)
	:
m_Name(name),
m_Renderer(renderer),
m_Buffer(buffer)
{
	//
}
//----------------------------------------------------------------------------------------
ThHardwareBuffer::ThHardwareBuffer()
{
	//
}
//----------------------------------------------------------------------------------------
ThHardwareBuffer::~ThHardwareBuffer()
{
	ThGraphicsUtils::SafeRelease(m_Buffer);
	m_Renderer->RemoveHardwareBuffer(m_Name);
}

}