#include <Thor/Framework/ThUUID.h>

#ifdef THOR_USE_BOOST_UUID
	#include <boost/uuid/random_generator.hpp>
#endif

namespace Thor
{
//----------------------------------------------------------------------------------------
//
//					ThUUID
//
//----------------------------------------------------------------------------------------
ThUUID::ThUUID()
#ifndef THOR_USE_BOOST_UUID
	:
m_UUID(0)
#endif
{
	//
}

ThUUID::ThUUID(uuid_t id)
#ifndef THOR_USE_BOOST_UUID
	:
m_UUID(id)
#endif
{
#ifdef THOR_USE_BOOST_UUID
	ThU8* pId = (ThU8*)&id;
	
	for(int i = 0; i < sizeof uuid_t; ++i)
		m_UUID.data[i] = pId[i];

	for(int i = 0; i < m_UUID.size(); ++i)
		m_UUID.data[i] = 0;
#endif
}
//----------------------------------------------------------------------------------------
ThUUID::ThUUID(const ThUUID& copy)
{
	m_UUID = copy.m_UUID;
}
//----------------------------------------------------------------------------------------
ThUUID&	ThUUID::operator=(const ThUUID& rhs)
{
	m_UUID = rhs.m_UUID;
	return *this;
}

ThUUID&	ThUUID::operator=(const uuid_t& rhs)
{
	m_UUID = rhs;
	return *this;
}
//----------------------------------------------------------------------------------------
ThBool ThUUID::operator==(const ThUUID& rhs)const
{
	return m_UUID == rhs.m_UUID;
}
//----------------------------------------------------------------------------------------
ThBool ThUUID::operator!=(const ThUUID& rhs)const
{
	return m_UUID != rhs.m_UUID;
}
//----------------------------------------------------------------------------------------
ThUUID::operator bool()const
{
	return !IsNil();
}
//----------------------------------------------------------------------------------------
ThSize	ThUUID::Size()const
{
#ifdef THOR_USE_BOOST_UUID
	return m_UUID.size();
#else
	return sizeof ThI64;
#endif
}
//----------------------------------------------------------------------------------------
bool	ThUUID::IsNil()const
{
#ifdef THOR_USE_BOOST_UUID
	return m_UUID.is_nil();
#else
	return m_UUID == 0;
#endif
}
//----------------------------------------------------------------------------------------
ThU8*	ThUUID::GetPtr()const
{
#ifdef THOR_USE_BOOST_UUID
	return (ThU8*)m_UUID.data[0];
#else
	return (ThU8*)&m_UUID;
#endif
}
//----------------------------------------------------------------------------------------
void	ThUUID::Generate()
{
#ifdef THOR_USE_BOOST_UUID
	m_UUID = boost::uuids::random_generator()();
#endif
}

const ThUUID::uuid_t& ThUUID::Get()const
{
	return m_UUID;
}

ThUUID::operator uuid_t()const
{
	return m_UUID;
}

}