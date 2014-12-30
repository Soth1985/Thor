#pragma once

#include <Thor/Framework/FrameworkFwdInternal.h>
#include <Thor/ThorMath/FixedVector.h>
#include <Thor/ThorMath/FixedMatrix.h>
#include <Thor/Framework/Containers/ThVector.h>

namespace Thor
{

class THOR_FRAMEWORK_DLL ThiArchiveReader : public ThiObject
{
public:
	
	virtual void Load(ThVector<ThiEntityPtr>& entities, ThiDataStreamPtr& stream) = 0;

	virtual ThBool ReadField(const ThI8* name, ThI64& val) = 0;
	virtual ThBool ReadField(const ThI8* name, ThI32& val) = 0;
	virtual ThBool ReadField(const ThI8* name, ThI16& val) = 0;
	virtual ThBool ReadField(const ThI8* name, ThI8& val) = 0;

	virtual ThBool ReadField(const ThI8* name, ThU64& val) = 0;
	virtual ThBool ReadField(const ThI8* name, ThU32& val) = 0;
	virtual ThBool ReadField(const ThI8* name, ThU16& val) = 0;
	virtual ThBool ReadField(const ThI8* name, ThU8& val) = 0;

	virtual ThBool ReadField(const ThI8* name, ThF64& val) = 0;
	virtual ThBool ReadField(const ThI8* name, ThF32& val) = 0;

	virtual ThBool ReadField(const ThI8* name, ThBool& val) = 0;

	virtual ThBool ReadField(const ThI8* name, ThU16String& val) = 0;
	virtual ThBool ReadField(const ThI8* name, ThString& val) = 0;
	virtual ThBool ReadField(const ThI8* name, ThWideString& val) = 0;

	virtual ThBool ReadField(const ThI8* name, ThVec2& val) = 0;
	virtual ThBool ReadField(const ThI8* name, ThVec3& val) = 0;
	virtual ThBool ReadField(const ThI8* name, ThVec4& val) = 0;

	virtual ThBool ReadField(const ThI8* name, ThVec2d& val) = 0;
	virtual ThBool ReadField(const ThI8* name, ThVec3d& val) = 0;
	virtual ThBool ReadField(const ThI8* name, ThVec4d& val) = 0;

	virtual ThBool ReadField(const ThI8* name, ThMat2x2& val) = 0;
	virtual ThBool ReadField(const ThI8* name, ThMat3x3& val) = 0;
	virtual ThBool ReadField(const ThI8* name, ThMat4x4& val) = 0;

	virtual ThBool ReadField(const ThI8* name, ThMat2x2d& val) = 0;
	virtual ThBool ReadField(const ThI8* name, ThMat3x3d& val) = 0;
	virtual ThBool ReadField(const ThI8* name, ThMat4x4d& val) = 0;

	virtual ThBool ReadField(const ThI8* name, ThQuat& val) = 0;
	virtual ThBool ReadField(const ThI8* name, ThQuatd& val) = 0;

	virtual ThBool ReadBeginStructureField(const ThI8* name) = 0;
	virtual void ReadEndStructureField(const ThI8* name) = 0;

	virtual ThBool ReadBeginSubstructure(const ThI8* type) = 0;
	virtual void ReadEndSubstructure(const ThI8* type) = 0;

	virtual ThBool ReadBeginListField(const ThI8* name, const ThiType* itemType, ThSize& size) = 0;
	virtual void ReadEndListField(const ThI8* name, const ThiType* itemType) = 0;

	virtual ThBool ReadBeginMapField(const ThI8* name, const ThiType* keyType, const ThiType* valueType, ThSize& size) = 0;
	virtual void ReadEndMapField(const ThI8* name, const ThiType* keyType, const ThiType* valueType) = 0;

	virtual ThiEntity* ReadReferenceField(const ThI8* name, const ThiType* refType, ThUUID& uuid) = 0;
	virtual ThiEntity* ReadWeakReferenceField(const ThI8* name, const ThiType* refType, ThUUID& uuid) = 0;

	virtual ThBool ReadEnumField(const ThI8* name, const ThI8* enumType, ThU32& value) = 0;

	virtual void ReadBeginEntity(const ThiEntity* entity, const ThUUID& uuid) = 0;
	virtual void ReadEndEntity(const ThiEntity* entity) = 0;

	virtual ThBool ReadBeginSubentity(const ThI8* entityType) = 0;
	virtual void ReadEndSubentity(const ThI8* entityType) = 0;

	virtual ThBool IsEntityDeserialized(const ThiEntity* entity) = 0;
};

}