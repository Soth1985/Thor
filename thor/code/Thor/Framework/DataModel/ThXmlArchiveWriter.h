#pragma once

#include <Thor/Framework/FrameworkFwdInternal.h>
#include <Thor/Framework/DataModel/ThiArchiveWriter.h>
#include <Thor/Framework/Containers/ThHashMap.h>

#include <rapidxml/rapidxml.hpp>

namespace Thor
{

class THOR_FRAMEWORK_DLL ThXmlArchiveWriter : public ThiArchiveWriter
{
public:

	ThXmlArchiveWriter();

	~ThXmlArchiveWriter();

	virtual ThiType* GetType(void)const;
	
	virtual void Save(const ThVector<ThiEntityPtr>& entities, ThiDataStreamPtr& stream);

	virtual void WriteField(const ThI8* name, ThI64 val);
	virtual void WriteField(const ThI8* name, ThI32 val);
	virtual void WriteField(const ThI8* name, ThI16 val);
	virtual void WriteField(const ThI8* name, ThI8 val);

	virtual void WriteField(const ThI8* name, ThU64 val);
	virtual void WriteField(const ThI8* name, ThU32 val);
	virtual void WriteField(const ThI8* name, ThU16 val);
	virtual void WriteField(const ThI8* name, ThU8 val);

	virtual void WriteField(const ThI8* name, ThF64 val);
	virtual void WriteField(const ThI8* name, ThF32 val);

	virtual void WriteField(const ThI8* name, ThBool val);

	virtual void WriteField(const ThI8* name, const ThU16String& val);
	virtual void WriteField(const ThI8* name, const ThWideString& val);
	virtual void WriteField(const ThI8* name, const ThString& val);

	virtual void WriteField(const ThI8* name, const ThVec2& val);
	virtual void WriteField(const ThI8* name, const ThVec3& val);
	virtual void WriteField(const ThI8* name, const ThVec4& val);

	virtual void WriteField(const ThI8* name, const ThVec2d& val);
	virtual void WriteField(const ThI8* name, const ThVec3d& val);
	virtual void WriteField(const ThI8* name, const ThVec4d& val);

	virtual void WriteField(const ThI8* name, const ThMat2x2& val);
	virtual void WriteField(const ThI8* name, const ThMat3x3& val);
	virtual void WriteField(const ThI8* name, const ThMat4x4& val);

	virtual void WriteField(const ThI8* name, const ThMat2x2d& val);
	virtual void WriteField(const ThI8* name, const ThMat3x3d& val);
	virtual void WriteField(const ThI8* name, const ThMat4x4d& val);

	virtual void WriteField(const ThI8* name, const ThQuat& val);
	virtual void WriteField(const ThI8* name, const ThQuatd& val);

	virtual void WriteBeginStructureField(const ThI8* name, const ThiStructField* structure);
	virtual void WriteEndStructureField(const ThI8* name, const ThiStructField* structure);

	virtual void WriteBeginSubstructure(const ThI8* structureType);
	virtual void WriteEndSubstructure(const ThI8* structureType);

	virtual void WriteBeginListField(const ThI8* name, const ThiType* itemType, ThSize size);
	virtual void WriteEndListField(const ThI8* name, const ThiType* itemType);

	virtual void WriteBeginMapField(const ThI8* name, const ThiType* keyType, const ThiType* valueType, ThSize size);
	virtual void WriteEndMapField(const ThI8* name, const ThiType* keyType, const ThiType* valueType);

	virtual void WriteReferenceField(const ThI8* name, const ThiType* refType, const ThUUID& refId);
	virtual void WriteWeakReferenceField(const ThI8* name, const ThiType* refType, const ThUUID& refId);

	virtual void WriteBeginEntity(const ThiEntity* entity);
	virtual void WriteEndEntity(const ThiEntity* entity);

	virtual void WriteBeginSubentity(const ThI8* entityType);
	virtual void WriteEndSubentity(const ThI8* entityType);

	virtual void WriteEnumField(const ThI8* name, const ThI8* enumType, ThU32 value);

	virtual ThBool IsEntitySerialized(const ThiEntity* entity)const;

private:

	friend struct ThXmlArchiveWriterUtils;

	typedef rapidxml::xml_node<> xml_node;
	typedef rapidxml::xml_document<> xml_document;
	typedef rapidxml::xml_attribute<> xml_attribute;

	ThI8* CopyBuffer();
	ThI8* AllocateString(const ThI8* str);
	void PushNode(xml_node* node);
	xml_node* PopNode();
	void Reset();

	xml_document m_Document;	
	ThVector<xml_node*> m_NodeStack;
	xml_node* m_EntitiesRootNode;
	xml_node* m_CurrentContainerNode;
	xml_node* m_CurrentSubcontainerNode;
	ThI8* m_Buffer;
	ThSize m_BufferSize;
	ThHashMap<ThiEntity*, ThBool> m_SerializedEntities;
};

}