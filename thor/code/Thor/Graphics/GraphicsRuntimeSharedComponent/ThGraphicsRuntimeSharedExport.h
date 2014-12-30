#pragma once

#include <Thor/Framework/Common.h>

#ifdef THOR_MS_WIN
	#ifdef THOR_GRAPHICS_RUNTIME_SHARED_EXPORT
		#define THOR_GRAPHICS_RUNTIME_SHARED_DLL __declspec(dllexport)
	#elif defined THOR_GRAPHICS_RUNTIME_SHARED_IMPORT
		#define THOR_GRAPHICS_RUNTIME_SHARED_DLL __declspec(dllimport)
	#else
		#define THOR_GRAPHICS_RUNTIME_SHARED_DLL 
	#endif
#else 
	#define THOR_GRAPHICS_RUNTIME_SHARED_DLL
#endif