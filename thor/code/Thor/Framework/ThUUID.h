#pragma once

#include <Thor/Framework/Common.h>
#include <Thor/Framework/FrameworkExport.h>

#ifdef THOR_USE_BOOST_UUID
	#include <boost/uuid/uuid.hpp>
#endif

namespace Thor
{
//----------------------------------------------------------------------------------------
//
//					ThUUID
//
//----------------------------------------------------------------------------------------
class THOR_FRAMEWORK_DLL ThUUID
{	
public:

	typedef ThU64 uuid_t;

	ThUUID();
	ThUUID(uuid_t id);
	ThUUID(const ThUUID& copy);

	ThUUID&	operator=(const ThUUID& rhs);
	ThUUID&	operator=(const uuid_t& rhs);
	ThBool	operator==(const ThUUID& rhs)const;
	ThBool  operator!=(const ThUUID& rhs)const;
	operator bool()const;
	operator uuid_t()const;

	ThSize	Size()const;
	bool	IsNil()const;
	ThU8*	GetPtr()const;
	void	Generate();
	const uuid_t& Get()const;

private:

#ifdef THOR_USE_BOOST_UUID
	boost::uuids::uuid	m_UUID;
#else
	uuid_t m_UUID;
#endif
};

}