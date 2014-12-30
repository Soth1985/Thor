#pragma once

#include <Thor/Framework/ThiObject.h>
#include <Thor/Framework/ThObjectUtils.h>
#include <Thor/Framework/ThException.h>
#include <Thor/Framework/ThLogger.h>
#include <Thor/Framework/ThAssert.h>

namespace Thor
{
	extern const ThI8* frameworkSysLogTag;
	//Framework core classes
	THOR_DECLARE_CLASS_NS(ThiApplication, Thor);
	THOR_DECLARE_CLASS_NS(ThiTask, Thor);
	THOR_DECLARE_CLASS_NS(ThiComponent, Thor);
	THOR_DECLARE_CLASS_NS(ThiComponentInterface, Thor);
	THOR_DECLARE_CLASS_NS(ThiFramework, Thor);	
    THOR_DECLARE_CLASS_NS(ThiEvent, Thor);
    THOR_DECLARE_CLASS_NS(ThiSysEvent, Thor);
    THOR_DECLARE_CLASS_NS(ThiSimEvent, Thor);
	THOR_DECLARE_CLASS_NS(ThiSystemWindow, Thor);
	THOR_DECLARE_CLASS_NS(ThiAsyncResult, Thor);
	//DataModel
	THOR_DECLARE_CLASS_NS(ThiEntity, Thor);
	THOR_DECLARE_PLAIN_CLASS_NS(ThiField, Thor);
	THOR_DECLARE_PLAIN_CLASS_NS(ThiEntityUserData, Thor);
	THOR_DECLARE_PLAIN_CLASS_NS(ThiStructField, Thor);
	//Filesystem classes
	THOR_DECLARE_CLASS_NS(ThiDataStream, Thor);
	THOR_DECLARE_CLASS_NS(ThiFileStream, Thor);
	THOR_DECLARE_CLASS_NS(ThiMemoryStream, Thor);
	THOR_DECLARE_CLASS_NS(ThiFileSystem, Thor);
	THOR_DECLARE_CLASS_NS(ThiDynamicLibrary, Thor);
	THOR_DECLARE_CLASS_NS(ThFileAsyncResult, Thor);
	//Archive
	THOR_DECLARE_CLASS_NS(ThiArchiveReader, Thor);
	THOR_DECLARE_CLASS_NS(ThiArchiveWriter, Thor);
	//Core classes that don`t use reference counting
	THOR_DECLARE_HDL_CLASS_NS(ThiWorld, Thor);
	THOR_DECLARE_HDL_CLASS_NS(ThiUniverse, Thor);
	//Typedefs
	typedef ThDelegate<ThiAsyncResultPtr>	ThiAsyncResultCallback;
	typedef std::vector<ThiEntityHdl>		ThiEntityList;
	typedef std::vector<ThiField*>			ThiFieldList;
	
}//Thor