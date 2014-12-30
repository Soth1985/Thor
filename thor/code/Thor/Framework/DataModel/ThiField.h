#pragma once

#include <Thor/Framework/FrameworkFwd.h>
#include <Thor/Framework/DataModel/ThiArchiveReader.h>
#include <Thor/Framework/DataModel/ThiArchiveWriter.h>

#define THOR_DM_THIFIELD_NOVIRTUALS 1

#ifdef THOR_DM_THIFIELD_NOVIRTUALS
	#define THOR_DM_VIRTUAL
#else
	#define THOR_DM_VIRTUAL virtual
#endif

namespace Thor
{

namespace Private
{
	struct eFieldFlags
	{
		enum Val
		{
			IsDirty = 1 << 0,
			IsDefaultValue = 1 << 1
		};
	};

#ifndef THOR_DM_THIFIELD_NOVIRTUALS
	struct THOR_FRAMEWORK_DLL ThiFieldInternalAccess
	{
		static void Push(ThiField* field);
	};
#else
	struct ThiFieldInternalAccess
	{
		template <class FieldT>
		static void Push(FieldT* field)
		{
			field->Push();
		}
	};
#endif
}
//----------------------------------------------------------------------------------------
//
//					ThiField
//
//----------------------------------------------------------------------------------------
class THOR_FRAMEWORK_DLL ThiField
#ifndef THOR_DM_THIFIELD_NOVIRTUALS
	: public ThiRtti
#endif
{
public:

	ThiField();

	ThiField(const ThiField& other);

#ifndef THOR_DM_THIFIELD_NOVIRTUALS
	virtual void Serialize(ThiArchiveWriter* archive, const ThI8* fieldName)const = 0;

	virtual void Deserialize(ThiArchiveReader* archive, const ThI8* fieldName) = 0;
#endif

protected:

	friend struct Private::ThiFieldInternalAccess;

	const ThiField& operator=(const ThiField& other);

#ifndef THOR_DM_THIFIELD_NOVIRTUALS
	virtual void Push() = 0;
#endif
};
//----------------------------------------------------------------------------------------
//
//					ThiFieldProxy
//
//----------------------------------------------------------------------------------------
template <bool ThreadSafe>
class ThiFieldProxy;

template <>
class ThiFieldProxy<true> : public ThiField
{
public:

	ThiFieldProxy()
	{

	}

	ThiFieldProxy(const ThiFieldProxy& other)
	{
		*this = other;
	}

	typedef tbb::spin_mutex::scoped_lock ScopedLock;

	void InitScopedLock(ScopedLock& lock)const
	{
		lock.acquire(m_Mutex);
	}

protected:

	const ThiFieldProxy& operator=(const ThiFieldProxy& other)
	{
		return *this;
	}

private:

	mutable tbb::spin_mutex m_Mutex;
};

template <>
class ThiFieldProxy<false> : public ThiField
{
public:

	ThiFieldProxy()
	{

	}

	ThiFieldProxy(const ThiFieldProxy& other)
	{
		*this = other;
	}

	class ScopedLock
	{};

	void InitScopedLock(ScopedLock& lock)const
	{}

protected:

	const ThiFieldProxy& operator=(const ThiFieldProxy& other)
	{
		return *this;
	}

};

}
