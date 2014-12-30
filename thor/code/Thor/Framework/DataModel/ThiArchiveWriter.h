#pragma once

#include <Thor/Framework/FrameworkFwd.h>
#include <Thor/ThorMath/FixedVector.h>
#include <Thor/ThorMath/FixedMatrix.h>
#include <Thor/Framework/Containers/ThVector.h>

namespace Thor
{

class THOR_FRAMEWORK_DLL ThiArchiveWriter : public ThiObject
{
public:
	
	virtual void Save(const ThVector<ThiEntityPtr>& entities, ThiDataStreamPtr& stream) = 0;	

	virtual void WriteField(const ThI8* name, ThI64 val) = 0;
	virtual void WriteField(const ThI8* name, ThI32 val) = 0;
	virtual void WriteField(const ThI8* name, ThI16 val) = 0;
	virtual void WriteField(const ThI8* name, ThI8 val) = 0;

	virtual void WriteField(const ThI8* name, ThU64 val) = 0;
	virtual void WriteField(const ThI8* name, ThU32 val) = 0;
	virtual void WriteField(const ThI8* name, ThU16 val) = 0;
	virtual void WriteField(const ThI8* name, ThU8 val) = 0;

	virtual void WriteField(const ThI8* name, ThF64 val) = 0;
	virtual void WriteField(const ThI8* name, ThF32 val) = 0;

	virtual void WriteField(const ThI8* name, ThBool val) = 0;

	virtual void WriteField(const ThI8* name, const ThU16String& val) = 0;
	virtual void WriteField(const ThI8* name, const ThString& val) = 0;
	virtual void WriteField(const ThI8* name, const ThWideString& val) = 0;
	
	virtual void WriteField(const ThI8* name, const ThVec2& val) = 0;
	virtual void WriteField(const ThI8* name, const ThVec3& val) = 0;
	virtual void WriteField(const ThI8* name, const ThVec4& val) = 0;

	virtual void WriteField(const ThI8* name, const ThVec2d& val) = 0;
	virtual void WriteField(const ThI8* name, const ThVec3d& val) = 0;
	virtual void WriteField(const ThI8* name, const ThVec4d& val) = 0;

	virtual void WriteField(const ThI8* name, const ThMat2x2& val) = 0;
	virtual void WriteField(const ThI8* name, const ThMat3x3& val) = 0;
	virtual void WriteField(const ThI8* name, const ThMat4x4& val) = 0;

	virtual void WriteField(const ThI8* name, const ThMat2x2d& val) = 0;
	virtual void WriteField(const ThI8* name, const ThMat3x3d& val) = 0;
	virtual void WriteField(const ThI8* name, const ThMat4x4d& val) = 0;
	
	virtual void WriteField(const ThI8* name, const ThQuat& val) = 0;
	virtual void WriteField(const ThI8* name, const ThQuatd& val) = 0;

	virtual void WriteBeginStructureField(const ThI8* name, const ThiStructField* structure) = 0;
	virtual void WriteEndStructureField(const ThI8* name, const ThiStructField* structure) = 0;

	virtual void WriteBeginSubstructure(const ThI8* type) = 0;
	virtual void WriteEndSubstructure(const ThI8* type) = 0;

	virtual void WriteBeginListField(const ThI8* name, const ThiType* itemType, ThSize size) = 0;
	virtual void WriteEndListField(const ThI8* name, const ThiType* itemType) = 0;

	virtual void WriteBeginMapField(const ThI8* name, const ThiType* keyType, const ThiType* valueType, ThSize size) = 0;
	virtual void WriteEndMapField(const ThI8* name, const ThiType* keyType, const ThiType* valueType) = 0;

	virtual void WriteReferenceField(const ThI8* name, const ThiType* refType, const ThUUID& refId) = 0;
	virtual void WriteWeakReferenceField(const ThI8* name, const ThiType* refType, const ThUUID& refId) = 0;

	virtual ThBool IsEntitySerialized(const ThiEntity* entity)const = 0;

	virtual void WriteBeginEntity(const ThiEntity* entity) = 0;
	virtual void WriteEndEntity(const ThiEntity* entity) = 0;

	virtual void WriteBeginSubentity(const ThI8* entityType) = 0;
	virtual void WriteEndSubentity(const ThI8* entityType) = 0;

	virtual void WriteEnumField(const ThI8* name, const ThI8* enumType, ThU32 value) = 0;
};

}