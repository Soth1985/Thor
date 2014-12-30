#pragma once

#include <Thor/Framework/Common.h>

#ifdef THOR_MS_WIN
	#ifdef THOR_CONTENT_PIPELINE_EXPORT
		#define THOR_CONTENT_PIPELINE_DLL __declspec(dllexport)
	#elif defined THOR_CONTENT_PIPELINE_IMPORT
		#define THOR_CONTENT_PIPELINE_DLL __declspec(dllimport)
	#else
		#define THOR_CONTENT_PIPELINE_DLL 
	#endif
#else 
	#define THOR_CONTENT_PIPELINE_DLL
#endif