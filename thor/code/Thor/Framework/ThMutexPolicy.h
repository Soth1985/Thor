#pragma once

#include <Thor/Framework/Common.h>

#ifdef THOR_USE_TBB
	#include <tbb/spin_mutex.h>
#endif

namespace Thor
{

template <bool ThreadSafe>
class ThMutexPolicy;

template <>
class ThMutexPolicy<true>
{
public:

	typedef tbb::spin_mutex::scoped_lock ScopedLock;

	void InitScopedLock(ScopedLock& lock)const
	{
		lock.acquire(m_Mutex);
	}

private:

#ifdef THOR_USE_TBB
	typedef tbb::spin_mutex Mutex;
	mutable Mutex m_Mutex;
#endif
};

template <>
class ThMutexPolicy<false>
{
public:

	class ScopedLock
	{};

	void InitScopedLock(ScopedLock& lock)const
	{}
};

}