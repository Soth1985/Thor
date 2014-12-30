#pragma once

#include <Thor/Framework/Common.h>

#ifdef THOR_MS_WIN
	#ifdef THOR_TEXTURE_TOOLS_EXPORT
		#define THOR_TEXTURE_TOOLS_DLL __declspec(dllexport)
	#elif defined THOR_TEXTURE_TOOLS_IMPORT
		#define THOR_TEXTURE_TOOLS_DLL __declspec(dllimport)
	#else
		#define THOR_TEXTURE_TOOLS_DLL 
	#endif
#else 
	#define THOR_TEXTURE_TOOLS_DLL
#endif