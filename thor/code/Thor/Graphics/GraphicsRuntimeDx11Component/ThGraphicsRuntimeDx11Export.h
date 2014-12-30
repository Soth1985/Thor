#pragma once

#include <Thor/Framework/Common.h>

#ifdef THOR_MS_WIN
	#ifdef THOR_GRAPHICS_RUNTIME_DX11_EXPORT
		#define THOR_GRAPHICS_RUNTIME_DX11_DLL __declspec(dllexport)
	#elif defined THOR_GRAPHICS_RUNTIME_DX11_IMPORT
		#define THOR_GRAPHICS_RUNTIME_DX11_DLL __declspec(dllimport)
	#else
		#define THOR_GRAPHICS_RUNTIME_DX11_DLL 
	#endif
#else 
		#define THOR_GRAPHICS_RUNTIME_DX11_DLL
#endif