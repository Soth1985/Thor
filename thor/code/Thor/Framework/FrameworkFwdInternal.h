#pragma once

#include <Thor/Framework/ThiObject.h>
#include <Thor/Framework/FrameworkFwd.h>

namespace Thor
{	
	THOR_DECLARE_CLASS_NS(ThComponentInstance, Thor);
	THOR_DECLARE_CLASS_NS(ThFramework, Thor);
	THOR_DECLARE_CLASS_NS(ThTbbTaskManager, Thor);
	THOR_DECLARE_CLASS_NS(ThAsyncOpManager, Thor);
	THOR_DECLARE_CLASS_NS(ThWorld, Thor);
	THOR_DECLARE_CLASS_NS(ThUniverse, Thor);

	//Archive
	THOR_DECLARE_CLASS_NS(ThXmlArchiveReader, Thor);
	THOR_DECLARE_CLASS_NS(ThXmlArchiveWriter, Thor);

#ifdef THOR_MS_WIN
	THOR_DECLARE_CLASS_NS(ThWinSystemWindow, Thor);
#endif
}