#pragma once

#include <Thor/Framework/FrameworkExport.h>

namespace Thor
{

//----------------------------------------------------------------------------------------
//
//					ThAssemblyVersionInfo
//
//----------------------------------------------------------------------------------------
struct THOR_FRAMEWORK_DLL ThAssemblyVersionInfo
{
	ThU32 m_Major;
	ThU32 m_Minor;
	ThU32 m_Revision;
	ThU32 m_Patch;

	ThAssemblyVersionInfo(ThU32 major, ThU32 minor, ThU32 revision, ThU32 patch);

	ThString	ToString()const;
	ThBool		operator==(const ThAssemblyVersionInfo& rhs)const;
};

}