#pragma once

#include <Thor/Framework/DataModel/ThiField.h>

namespace Thor
{
//----------------------------------------------------------------------------------------
//
//					ThiStructField
//
//----------------------------------------------------------------------------------------
class THOR_FRAMEWORK_DLL ThiStructField: public ThiField
{
public:

	ThiStructField();

	ThiStructField(const ThiStructField& other);

	virtual ThiType*		GetType()const;

	virtual ThSize			GetNumFields()const = 0;

	virtual ThiField*		GetField(ThSize index) = 0;

	virtual const char*		GetFieldName(ThSize idx)const = 0;

	virtual ThiType*		GetFieldType(ThSize idx)const = 0;

	virtual ThiType*		GetStructType()const = 0;

	void Serialize(ThiArchiveWriter* archive, const ThI8* fieldName)const;

	void Deserialize(ThiArchiveReader* archive, const ThI8* fieldName);

protected:

	const ThiStructField& operator=(const ThiStructField& other);

	virtual void SerializeSubstructure(ThiArchiveWriter* archive)const = 0;

	virtual void DeserializeSubstructure(ThiArchiveReader* archive) = 0;
};
}