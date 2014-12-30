#include <Thor/Framework/DataModel/ThiStructField.h>

namespace Thor
{
THOR_REG_TYPE(ThiStructField, THOR_TYPELIST_1(ThiField));

ThiStructField::ThiStructField()
{

}

ThiStructField::ThiStructField(const ThiStructField& other)
	:
ThiField(other)
{

}

const ThiStructField& ThiStructField::operator=(const ThiStructField& other)
{
	return *this;
}

ThiType* ThiStructField::GetType()const
{
	return ThType<ThiStructField>::Instance();
}

void ThiStructField::Serialize(ThiArchiveWriter* archive, const ThI8* fieldName)const
{
	archive->WriteBeginStructureField(fieldName, this);		
	SerializeSubstructure(archive);
	archive->WriteEndStructureField(fieldName, this);		
}

void ThiStructField::Deserialize(ThiArchiveReader* archive, const ThI8* fieldName)
{
	if(archive->ReadBeginStructureField(fieldName))
	{
		DeserializeSubstructure(archive);
		archive->ReadEndStructureField(fieldName);
	}
}

}