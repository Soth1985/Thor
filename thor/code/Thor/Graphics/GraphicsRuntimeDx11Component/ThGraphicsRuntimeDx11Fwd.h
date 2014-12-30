#pragma once

#include <Thor/Framework/FrameworkFwd.h>
#include <Thor/Graphics/GraphicsRuntimeDx11Component/ThGraphicsRuntimeDx11Export.h>

namespace Thor
{
	extern const ThI8* graphicsRuntimeDx11LogTag;

	THOR_DECLARE_CLASS_NS(ThDirectX11Renderer, Thor);
	THOR_DECLARE_CLASS_NS(ThHardwareResource, Thor);
	THOR_DECLARE_CLASS_NS(ThHardwareBuffer, Thor);
	THOR_DECLARE_CLASS_NS(ThTexture1D, Thor);
	THOR_DECLARE_CLASS_NS(ThTexture2D, Thor);
	THOR_DECLARE_CLASS_NS(ThTexture3D, Thor);
}