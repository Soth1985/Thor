#include <Thor/ContentTools/ContentPipeline/ThiContentImporter.h>

namespace Thor
{

THOR_REG_TYPE(ThiContentImporter, THOR_TYPELIST_1(ThiObject));

ThiContentImporter::ThiContentImporter()
	:
m_Priority(0)
{

}

void ThiContentImporter::SetPriority(ThSize priority)
{
	m_Priority = priority;
}

ThSize ThiContentImporter::GetPriority()const
{
	return m_Priority;
}

}