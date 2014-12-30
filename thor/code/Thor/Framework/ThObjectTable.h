#pragma once

#include <Thor/Framework/Common.h>
#include <Thor/Framework/ThUUID.h>
#include <Thor/Framework/FrameworkExport.h>

namespace Thor
{

class ThiRtti;
//----------------------------------------------------------------------------------------
//
//					ThObjectTable
//
//----------------------------------------------------------------------------------------
class THOR_FRAMEWORK_DLL ThObjectTable
{
public:

	static ThiRtti*	GetObject(ThU32 handle);
	static ThU32	GetObjectHandle(const ThUUID& uuid);

};

}