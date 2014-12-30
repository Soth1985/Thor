#include <Thor/Framework/ThiTask.h>
#include <Thor/Framework/ThLogger.h>

namespace Thor
{

THOR_REG_TYPE(ThiTask, THOR_TYPELIST_1(ThiObject));
//----------------------------------------------------------------------------------------
//
//					ThiTask
//
//----------------------------------------------------------------------------------------
ThBool ThiTask::IsPrimaryThreadTask()const
{
	return false;
}

}