#pragma once

#include <Thor/Framework/FrameworkFwd.h>

namespace Thor
{

namespace Private
{
	struct THOR_FRAMEWORK_DLL ThiEntityInternalAccess
	{
		static void Push(ThiEntity* entity);
		static void SetUserData(ThiEntity* entity, ThiEntityUserData* userData);
	};
}

class THOR_FRAMEWORK_DLL ThiEntity: public ThiObject
{
public:

	ThiEntity();
	ThiEntity(const ThUUID& uuid);
	ThiEntity(const ThiEntity& other);
	virtual ~ThiEntity();

	virtual ThUUID	GetUUID()const;

	virtual ThSize		GetNumFields()const = 0;
	virtual ThiField*	GetField(ThSize idx) = 0;
	virtual const char* GetFieldName(ThSize idx)const = 0;
	virtual ThiType*	GetFieldType(ThSize idx)const = 0;

	ThiEntityUserData*	GetUserData()const;
	
	void Serialize(ThiArchiveWriter* archive)const;
	void Deserialize(ThiArchiveReader* archive, const ThUUID& uuid);

	ThBool Equals(const ThiEntityPtr& other)const;
	ThBool Equals(const ThiEntity* other)const;

protected:

	friend struct Private::ThiEntityInternalAccess;

	const ThiEntity& operator=(const ThiEntity& other);

	virtual void Push() = 0;
	virtual ThBool EqualsImpl(const ThiEntity* other)const = 0;
	virtual void SerializeSubentity(ThiArchiveWriter* archive)const = 0;
	virtual void DeserializeSubentity(ThiArchiveReader* archive) = 0;

	ThUUID		m_UUID;
	ThiEntityUserData*	m_UserData;
};

}