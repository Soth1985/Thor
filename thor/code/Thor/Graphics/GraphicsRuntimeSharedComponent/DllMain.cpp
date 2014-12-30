#include <Thor/Graphics/GraphicsRuntimeSharedComponent/ThGraphicsRuntimeSharedFwd.h>

namespace Thor
{

const ThI8* graphicsRuntimeSharedLogTag = "GraphicsRtShared";

}

#ifdef _WIN32

#include <windows.h>

extern "C" BOOL WINAPI DllMain( HINSTANCE hInst, DWORD callReason, LPVOID reserved )
{
	if ( callReason==DLL_PROCESS_ATTACH && reserved && hInst )
	{

	}

	if ( callReason==DLL_PROCESS_DETACH && reserved && hInst )
	{
	}

	return TRUE;
}

#endif //_WIN32