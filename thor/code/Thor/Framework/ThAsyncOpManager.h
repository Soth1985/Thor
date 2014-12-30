#pragma once

#include <Thor/Framework/ThiAsyncResult.h>
#include <Thor/Framework/FrameworkFwdInternal.h>
#include <Thor/Framework/Singleton.h>
#include <tbb/tbb_thread.h>
#include <tbb/concurrent_queue.h>

namespace Thor
{

//----------------------------------------------------------------------------------------
//
//					ThFileAsyncResult
//
//----------------------------------------------------------------------------------------
class THOR_FRAMEWORK_DLL ThFileAsyncResult: public ThiAsyncResult
{
public:

	ThFileAsyncResult();
	ThFileAsyncResult(ThBool isReadOp, const ThiFileStreamPtr& file, const void* buf, ThSize bufOffset, ThSize size, const ThiAsyncResultCallback& callback);

	virtual ThiType*		GetType()const;
	virtual ThBool			IsComplete()const;
	virtual ThBool			Cancel();

	const ThiFileStreamPtr& GetFile()const;
	const void*				GetBuffer()const;
	ThSize					GetSize()const;
	ThSize					GetBufferOffset()const;

private:
	friend class ThAsyncOpManager;

	void*					m_Buf;
	ThSize					m_BufOffset;
	ThSize					m_Size;
	ThBool					m_IsReadOp;
	ThBool					m_Complete;
	ThBool					m_Cancelled;	
	ThiFileStreamPtr		m_File;
	ThiAsyncResultCallback	m_Callback;
};
//----------------------------------------------------------------------------------------
//
//					ThAsyncOpManager
//
//----------------------------------------------------------------------------------------
class ThAsyncOpManager:public ThiObject
{
public:

	ThAsyncOpManager();

	virtual ThiType* GetType()const;

	void Process();
	void AddWorkItem(const ThiAsyncResultPtr& item);
	void Update();
	void SetThreadState(ThBool suspend);	

private:

	typedef tbb::spin_mutex						mutex_t;

	mutex_t										m_Mutex;
	tbb::tbb_thread								m_Thread;
	tbb::concurrent_queue<ThiAsyncResultPtr>	m_WorkItems;
	ThBool										m_Suspended;		
};

}