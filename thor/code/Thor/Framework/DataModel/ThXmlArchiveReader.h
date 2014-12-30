#pragma once

#include <Thor/Framework/DataModel/ThiArchiveReader.h>

#include <rapidxml/rapidxml.hpp>

namespace Thor
{

class THOR_FRAMEWORK_DLL ThXmlArchiveReader : public ThiArchiveReader
{
public:

	ThXmlArchiveReader();

	virtual ThiType* GetType(void)const;

	virtual void Load(ThVector<ThiEntityPtr>& entities, ThiDataStreamPtr& stream);

	virtual ThBool ReadField(const ThI8* name, ThI64& val);
	virtual ThBool ReadField(const ThI8* name, ThI32& val);
	virtual ThBool ReadField(const ThI8* name, ThI16& val);
	virtual ThBool ReadField(const ThI8* name, ThI8& val);

	virtual ThBool ReadField(const ThI8* name, ThU64& val);
	virtual ThBool ReadField(const ThI8* name, ThU32& val);
	virtual ThBool ReadField(const ThI8* name, ThU16& val);
	virtual ThBool ReadField(const ThI8* name, ThU8& val);

	virtual ThBool ReadField(const ThI8* name, ThF64& val);
	virtual ThBool ReadField(const ThI8* name, ThF32& val);

	virtual ThBool ReadField(const ThI8* name, ThBool& val);

	virtual ThBool ReadField(const ThI8* name, ThU16String& val);
	virtual ThBool ReadField(const ThI8* name, ThWideString& val);
	virtual ThBool ReadField(const ThI8* name, ThString& val);

	virtual ThBool ReadField(const ThI8* name, ThVec2& val);
	virtual ThBool ReadField(const ThI8* name, ThVec3& val);
	virtual ThBool ReadField(const ThI8* name, ThVec4& val);

	virtual ThBool ReadField(const ThI8* name, ThVec2d& val);
	virtual ThBool ReadField(const ThI8* name, ThVec3d& val);
	virtual ThBool ReadField(const ThI8* name, ThVec4d& val);

	virtual ThBool ReadField(const ThI8* name, ThMat2x2& val);
	virtual ThBool ReadField(const ThI8* name, ThMat3x3& val);
	virtual ThBool ReadField(const ThI8* name, ThMat4x4& val);

	virtual ThBool ReadField(const ThI8* name, ThMat2x2d& val);
	virtual ThBool ReadField(const ThI8* name, ThMat3x3d& val);
	virtual ThBool ReadField(const ThI8* name, ThMat4x4d& val);

	virtual ThBool ReadField(const ThI8* name, ThQuat& val);
	virtual ThBool ReadField(const ThI8* name, ThQuatd& val);

	virtual ThBool ReadBeginStructureField(const ThI8* name);
	virtual void ReadEndStructureField(const ThI8* name);

	virtual ThBool ReadBeginSubstructure(const ThI8* name);
	virtual void ReadEndSubstructure(const ThI8* name);

	virtual ThBool ReadBeginListField(const ThI8* name, const ThiType* itemType, ThSize& size);
	virtual void ReadEndListField(const ThI8* name, const ThiType* itemType);

	virtual ThBool ReadBeginMapField(const ThI8* name, const ThiType* keyType, const ThiType* valueType, ThSize& size);
	virtual void ReadEndMapField(const ThI8* name, const ThiType* keyType, const ThiType* valueType);

	virtual ThiEntity* ReadReferenceField(const ThI8* name, const ThiType* refType, ThUUID& uuid);
	virtual ThiEntity* ReadWeakReferenceField(const ThI8* name, const ThiType* refType, ThUUID& uuid);

	virtual ThBool ReadEnumField(const ThI8* name, const ThI8* enumType, ThU32& value);

	virtual void ReadBeginEntity(const ThiEntity* entity, const ThUUID& uuid);
	virtual void ReadEndEntity(const ThiEntity* entity);

	virtual ThBool ReadBeginSubentity(const ThI8* entityType);
	virtual void ReadEndSubentity(const ThI8* entityType);

	virtual ThBool IsEntityDeserialized(const ThiEntity* entity);

private:

	friend struct ThXmlArchiveReaderUtils;

	typedef rapidxml::xml_node<> xml_node;
	typedef rapidxml::xml_document<> xml_document;
	typedef rapidxml::xml_attribute<> xml_attribute;

	struct ConversionEntry
	{
		ConversionEntry()
			:
		m_TypeName(0),
		m_PrecisionLoss(false),
		m_SignedUnsignedMismatch(false)
		{

		}

		ConversionEntry(const ThI8* typeName, ThBool precisionLoss = false, ThBool signedUnsignedMismatch = false)
			:
		m_TypeName(typeName),
		m_PrecisionLoss(precisionLoss),
		m_SignedUnsignedMismatch(signedUnsignedMismatch)
		{

		}

		const ThI8* m_TypeName;
		ThBool m_PrecisionLoss;
		ThBool m_SignedUnsignedMismatch;
	};

	struct ConversionCheckResult
	{
		ConversionCheckResult(ThBool isConvertible, ThBool precisionLoss, ThBool signedUnsignedMismatch)
			:
		m_IsConvertible(isConvertible),
		m_PrecisionLoss(precisionLoss),
		m_SignedUnsignedMismatch(signedUnsignedMismatch)
		{

		}

		ThBool m_IsConvertible;
		ThBool m_PrecisionLoss;
		ThBool m_SignedUnsignedMismatch;
	};

	void PushNode(xml_node* node);
	xml_node* PopNode();
	void Reset();
	void InitBaseTypeConversionTable();
	ConversionCheckResult IsBaseTypeConvertibleTo(const ThI8* from, const ThI8* to);

	xml_document m_Document;
	ThVector<xml_node*> m_NodeStack;
	ThHashMap<const ThiEntity*, ThBool> m_DeserializedEntities;
	ThHashMap<ThU64, ThiEntity* > m_DeserializedEntitiesById;
	ThHashMap<const ThI8*, ThVector<ConversionEntry> > m_BaseTypeConversionTable;
	xml_node* m_EntitiesRootNode;
	xml_node* m_CurrentContainerNode;
	xml_node* m_CurrentSubcontainerNode;
};

}