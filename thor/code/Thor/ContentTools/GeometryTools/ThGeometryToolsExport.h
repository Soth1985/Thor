#pragma once

#include <Thor/Framework/Common.h>

#ifdef THOR_MS_WIN
	#ifdef THOR_GEOMETRY_TOOLS_EXPORT
		#define THOR_GEOMETRY_TOOLS_DLL __declspec(dllexport)
	#elif defined THOR_GEOMETRY_TOOLS_IMPORT
		#define THOR_GEOMETRY_TOOLS_DLL __declspec(dllimport)
	#else
		#define THOR_GEOMETRY_TOOLS_DLL 
	#endif
#else 
	#define THOR_GEOMETRY_TOOLS_DLL
#endif