#pragma once

#include <Thor/Framework/FrameworkFwdInternal.h>
#include <Thor/Framework/ThiTask.h>
#include <Thor/Framework/Containers/ThVector.h>

namespace Thor
{
//----------------------------------------------------------------------------------------
//
//					ThTbbTaskManager
//
//----------------------------------------------------------------------------------------
class ThTbbTaskManager:public ThiObject
{
public:

	ThTbbTaskManager();

	virtual ThiType* GetType()const;

	void AddTask(const ThiTaskPtr& task);
	void ExecuteTasks();

private:

	typedef ThVector<ThiTaskPtr> TaskList;

	TaskList	m_Tasks;
	ThSize		m_PrevTaskCount;
};

}