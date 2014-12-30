#include <Thor/Framework/ThTbbTaskManager.h>
#include <tbb/parallel_invoke.h>

namespace Thor
{
THOR_REG_TYPE(ThTbbTaskManager, THOR_TYPELIST_1(ThiObject));
//----------------------------------------------------------------------------------------
//
//					ThTaskWrapper
//
//----------------------------------------------------------------------------------------
struct ThTaskWrapper
{
	ThTaskWrapper(ThiTaskPtr& task)
		:
	m_Task(task)
	{
		//
	}

	void operator()()const
	{
		m_Task->Execute();
	}

	mutable ThiTaskPtr& m_Task;
};
//----------------------------------------------------------------------------------------
//
//					ThTbbTaskManager
//
//----------------------------------------------------------------------------------------
ThTbbTaskManager::ThTbbTaskManager()
	:
m_PrevTaskCount(0)
{
	//
}
//----------------------------------------------------------------------------------------
ThiType* ThTbbTaskManager::GetType()const
{
	return ThType<ThTbbTaskManager>::Instance();
}
//----------------------------------------------------------------------------------------
void ThTbbTaskManager::AddTask(const ThiTaskPtr& task)
{
	m_Tasks.PushBack(task);
}
//----------------------------------------------------------------------------------------
void ThTbbTaskManager::ExecuteTasks()
{
	//save the size of the task queue to know how much space to reserve later
	m_PrevTaskCount = m_Tasks.Size();
	
	TaskList parallelTasks;
	TaskList serialTasks;

	parallelTasks.Reserve(m_PrevTaskCount);
	serialTasks.Reserve(m_PrevTaskCount);

	//build serial and parallel execution lists
	for(TaskList::Iterator i = m_Tasks.Begin(); i != m_Tasks.End(); ++i)
	{
		if( (*i)->IsPrimaryThreadTask() )
			serialTasks.PushBack(*i);
		else
			parallelTasks.PushBack(*i);
	}

	//execute serial tasks
	for(TaskList::Iterator i = serialTasks.Begin(); i != serialTasks.End(); ++i)
	{
		(*i)->Execute();
	}

	//execute parallel tasks
	ThSize numParallelTasks = parallelTasks.Size();
	if( numParallelTasks > 1 )
	{
		ThI32 numChildren = 0;
		ThI32 num3Groups = 0;
		ThI32 num2Groups = 0;
		ThI32 num1Groups = 0;

		if(numParallelTasks <= 4)
		{
			numChildren = numParallelTasks;
			num1Groups = numParallelTasks - 1;//-1 because the last task is spawned and executed individually
		}
		else
		{
			ThI32 count = numParallelTasks - 1;

			num3Groups = count / 3;
			count -= num3Groups * 3;
			num2Groups = count / 2;
			count -= num2Groups * 2;
			num1Groups = count;
			numChildren = num3Groups + num2Groups + num1Groups + 1;//+1 for the last task
		}
		tbb::task_group_context context;
		tbb::internal::parallel_invoke_cleaner cleaner(numChildren, context);
		tbb::internal::parallel_invoke_helper& root = cleaner.root;

		ThI32 task = 0;
		//spawn tasks in groups of 3
		for(ThI32 i = 0; i < num3Groups; task += 3, ++i)
		{
			ThTaskWrapper wrapper1( parallelTasks[task] );
			ThTaskWrapper wrapper2( parallelTasks[task + 1] );
			ThTaskWrapper wrapper3( parallelTasks[task + 2] );
			root.add_children(wrapper1, wrapper2, wrapper3);
		}
		//spawn tasks in groups of 2
		for(ThI32 i = 0; i < num2Groups; task += 2, ++i)
		{
			ThTaskWrapper wrapper1( parallelTasks[task] );
			ThTaskWrapper wrapper2( parallelTasks[task + 1] );
			root.add_children(wrapper1, wrapper2);
		}
		//spawn tasks in groups of 1
		for(ThI32 i = 0; i < num1Groups; ++task, ++i)
		{
			ThTaskWrapper wrapper1( parallelTasks[task] );			
			root.add_child(wrapper1);
		}

		//spawn the last task and wait for completion
		ThTaskWrapper wrapper( parallelTasks.Back() );
		root.run_and_finish( wrapper );
	}
	else if(numParallelTasks == 1)
	{
		parallelTasks[0]->Execute();
	}

	//clear the task queue and reserve space for the next update
	m_Tasks.Clear();
	m_Tasks.Reserve(m_PrevTaskCount);
}

}