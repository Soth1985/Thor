#include <Thor/Framework/DataModel/ThiEntity.h>
#include <Thor/Framework/ThObjectTableInternal.h>
#include <Thor/Framework/DataModel/ThiArchiveWriter.h>
#include <Thor/Framework/DataModel/ThiArchiveReader.h>
#include <Thor/Framework/DataModel/ThiEntityUserData.h>
#include <Thor/Framework/ThiWorld.h>

namespace Thor
{

namespace Private
{
	void ThiEntityInternalAccess::Push(ThiEntity* entity)
	{
		entity->Push();
	}

	void ThiEntityInternalAccess::SetUserData(ThiEntity* entity, ThiEntityUserData* userData)
	{
		entity->m_UserData = userData;
	}
}

THOR_REG_TYPE(ThiEntity, THOR_TYPELIST_1(ThiObject));

ThiEntity::ThiEntity()
	:
m_UUID((ThUUID::uuid_t)this),
m_UserData(0)
{
	//ThObjectTableImpl::Instance().AddObject(this);
}

ThiEntity::ThiEntity(const ThUUID& uuid)
	:
m_UUID(uuid),
m_UserData(0)
{

}

ThiEntity::ThiEntity(const ThiEntity& other)
	:
m_UUID((ThUUID::uuid_t)this),
m_UserData(other.m_UserData)
{
	//ThObjectTableImpl::Instance().AddObject(this);
}

ThiEntity::~ThiEntity()
{
	//ThObjectTableImpl::Instance().RemoveObject(this);

	if (m_UserData)
		m_UserData->OnEntityDestroyed(this);
}

const ThiEntity& ThiEntity::operator=(const ThiEntity& other)
{
	m_UserData = other.m_UserData;
	return *this;
}

ThUUID	ThiEntity::GetUUID()const
{
	return m_UUID;
}

ThiEntityUserData* ThiEntity::GetUserData()const
{
	return m_UserData;
}

void ThiEntity::Serialize( ThiArchiveWriter* archive ) const
{
	if (!archive->IsEntitySerialized(this))
	{
		archive->WriteBeginEntity(this);
		SerializeSubentity(archive);
		archive->WriteEndEntity(this);
	}
}

void ThiEntity::Deserialize(ThiArchiveReader* archive, const ThUUID& uuid)
{
	if (!archive->IsEntityDeserialized(this))
	{
		m_UUID = uuid;
		archive->ReadBeginEntity(this, m_UUID);
		DeserializeSubentity(archive);
		archive->ReadEndEntity(this);
	}
}

ThBool ThiEntity::Equals(const ThiEntityPtr& other)const
{
	return Equals(other.GetPtr());
}

ThBool ThiEntity::Equals(const ThiEntity* other)const
{
	if (this == other)
		return true;

	if (!other)
		return false;

	return EqualsImpl(other);
}

}