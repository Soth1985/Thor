#pragma once

#include <Thor/Framework/Common.h>

#ifdef THOR_MS_WIN
	#ifdef THOR_GRAPHICS_SCENE_EXPORT
		#define THOR_GRAPHICS_SCENE_DLL __declspec(dllexport)
	#elif defined THOR_GRAPHICS_SCENE_IMPORT
		#define THOR_GRAPHICS_SCENE_DLL __declspec(dllimport)
	#else
		#define THOR_GRAPHICS_SCENE_DLL 
	#endif
#else 
	#define THOR_GRAPHICS_SCENE_DLL
#endif