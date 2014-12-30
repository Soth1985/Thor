#include <Thor/Framework/ThAssemblyVersionInfo.h>

namespace Thor
{		
//----------------------------------------------------------------------------------------
//
//					ThAssemblyVersionInfo
//
//----------------------------------------------------------------------------------------
ThAssemblyVersionInfo::ThAssemblyVersionInfo(ThU32 major, ThU32 minor, ThU32 revision, ThU32 patch)
	:
m_Major(major),
m_Minor(minor),
m_Revision(revision),
m_Patch(patch)
{
	//
}
//----------------------------------------------------------------------------------------
ThString	ThAssemblyVersionInfo::ToString()const
{	
	char buf[128]="";
	sprintf(buf, "%d.%d.%d.%d", m_Major, m_Minor, m_Patch, m_Revision );
	ThString result(buf);
	return result;
}
//----------------------------------------------------------------------------------------
ThBool		ThAssemblyVersionInfo::operator==(const ThAssemblyVersionInfo& rhs)const
{
	return (m_Major == rhs.m_Major) && (m_Minor == rhs.m_Minor) && (m_Revision == rhs.m_Revision) && (m_Patch == rhs.m_Patch);
}

}