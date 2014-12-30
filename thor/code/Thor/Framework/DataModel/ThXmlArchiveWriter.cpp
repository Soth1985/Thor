#include <Thor/Framework/DataModel/ThXmlArchiveWriter.h>
#include <Thor/Framework/ThStringUtilities.h>
#include <Thor/Framework/DataModel/ThDataModel.h>
#include <Thor/Framework/Filesystem/LibFileSystem.h>
#include <Thor/Framework/ThMathReflection.h>

#include <rapidxml/rapidxml_print.hpp>
#include <utf8cpp/utf8.h>

namespace Thor
{

struct ThXmlArchiveWriterUtils
{
	template <class T>
	static void WriteBasicTypeField(ThXmlArchiveWriter* writer, const ThI8* name, const T& val)
	{
		ThXmlArchiveWriter::xml_node* fieldNode = WriteFieldHeader(writer, name, ThType<T>::Instance()->GetName());
		ThStringUtilities::ToString(val, writer->m_Buffer, writer->m_BufferSize);
		WriteValue(writer, fieldNode, writer->CopyBuffer());
	}

	template <class VecT>
	static void WriteVectorTypeField(ThXmlArchiveWriter* writer, const ThI8* name, const VecT& val)
	{
		ThXmlArchiveWriter::xml_node* fieldNode = WriteFieldHeader(writer, name, ThType<VecT>::Instance()->GetName());

		for (unsigned int i = 0; i < val.Size(); ++i)
		{
			ThI8* buf = const_cast<ThI8*>(writer->m_Buffer);
			sprintf(buf, "v%u", i);
			const ThI8* nodeName = writer->CopyBuffer();
			ThStringUtilities::ToString(val(i), writer->m_Buffer, writer->m_BufferSize);
			const ThI8* nodeValue = writer->CopyBuffer();
			ThXmlArchiveWriter::xml_node* valueNode = writer->m_Document.allocate_node(rapidxml::node_element, nodeName, nodeValue);
			fieldNode->append_node(valueNode);
		}

		writer->m_CurrentSubcontainerNode->append_node(fieldNode);
	}

	template <class MatT>
	static void WriteMatrixTypeField(ThXmlArchiveWriter* writer, const ThI8* name, const MatT& val)
	{
		ThXmlArchiveWriter::xml_node* fieldNode = WriteFieldHeader(writer, name, ThType<MatT>::Instance()->GetName());

		if (val.IsRowMajor())
		{
			ThXmlArchiveWriter::xml_node* isRowMajorNode = writer->m_Document.allocate_node(rapidxml::node_element, "IsRowMajor", writer->AllocateString("1"));
			fieldNode->append_node(isRowMajorNode);
		}
		else
		{
			ThXmlArchiveWriter::xml_node* isRowMajorNode = writer->m_Document.allocate_node(rapidxml::node_element, "IsRowMajor", writer->AllocateString("0"));
			fieldNode->append_node(isRowMajorNode);
		}

		for (unsigned int i = 0; i < val.Size(); ++i)
		{
			ThI8* buf = writer->m_Buffer;
			sprintf(buf, "m%u", i);
			const ThI8* nodeName = writer->CopyBuffer();
			ThStringUtilities::ToString(val(i), writer->m_Buffer, writer->m_BufferSize);
			const ThI8* nodeValue = writer->CopyBuffer();
			ThXmlArchiveWriter::xml_node* valueNode = writer->m_Document.allocate_node(rapidxml::node_element, nodeName, nodeValue);
			fieldNode->append_node(valueNode);
		}

		writer->m_CurrentSubcontainerNode->append_node(fieldNode);
	}

	static ThXmlArchiveWriter::xml_node* WriteFieldHeader(ThXmlArchiveWriter* writer, const ThI8* name, const ThI8* type)
	{
		ThXmlArchiveWriter::xml_node* fieldNode = writer->m_Document.allocate_node(rapidxml::node_element, "Field");
		ThXmlArchiveWriter::xml_attribute* nameAttr = writer->m_Document.allocate_attribute("Name", writer->AllocateString(name));
		fieldNode->append_attribute(nameAttr);
		ThXmlArchiveWriter::xml_attribute* typeAttr = writer->m_Document.allocate_attribute("Type", type);
		fieldNode->append_attribute(typeAttr);
		return fieldNode;
	}

	static ThXmlArchiveWriter::xml_node* WriteStructureFieldHeader(ThXmlArchiveWriter* writer, const ThI8* name, const ThI8* type)
	{
		ThXmlArchiveWriter::xml_node* fieldNode = writer->m_Document.allocate_node(rapidxml::node_element, "StructureField");
		ThXmlArchiveWriter::xml_attribute* nameAttr = writer->m_Document.allocate_attribute("Name", writer->AllocateString(name));
		fieldNode->append_attribute(nameAttr);
		ThXmlArchiveWriter::xml_attribute* typeAttr = writer->m_Document.allocate_attribute("Type", type);
		fieldNode->append_attribute(typeAttr);
		return fieldNode;
	}

	static ThXmlArchiveWriter::xml_node* WriteListFieldHeader(ThXmlArchiveWriter* writer, const ThI8* name, const ThI8* itemType, ThSize size)
	{
		ThXmlArchiveWriter::xml_node* fieldNode = writer->m_Document.allocate_node(rapidxml::node_element, "ListField");
		ThXmlArchiveWriter::xml_attribute* nameAttr = writer->m_Document.allocate_attribute("Name", writer->AllocateString(name));
		fieldNode->append_attribute(nameAttr);
		ThXmlArchiveWriter::xml_attribute* typeAttr = writer->m_Document.allocate_attribute("Type", itemType);
		fieldNode->append_attribute(typeAttr);
		ThStringUtilities::ToString(size, writer->m_Buffer, writer->m_BufferSize);
		ThXmlArchiveWriter::xml_attribute* sizeAttr = writer->m_Document.allocate_attribute("Size", writer->CopyBuffer());
		fieldNode->append_attribute(sizeAttr);
		return fieldNode;
	}

	static ThXmlArchiveWriter::xml_node* WriteMapFieldHeader(ThXmlArchiveWriter* writer, const ThI8* name, const ThI8* keyType, const ThI8* valueType, ThSize size)
	{
		ThXmlArchiveWriter::xml_node* fieldNode = writer->m_Document.allocate_node(rapidxml::node_element, "MapField");
		ThXmlArchiveWriter::xml_attribute* nameAttr = writer->m_Document.allocate_attribute("Name", writer->AllocateString(name));
		fieldNode->append_attribute(nameAttr);
		ThXmlArchiveWriter::xml_attribute* keyTypeAttr = writer->m_Document.allocate_attribute("KeyType", keyType);
		fieldNode->append_attribute(keyTypeAttr);
		ThXmlArchiveWriter::xml_attribute* valueTypeAttr = writer->m_Document.allocate_attribute("ValueType", valueType);
		fieldNode->append_attribute(valueTypeAttr);
		ThStringUtilities::ToString(size, writer->m_Buffer, writer->m_BufferSize);
		ThXmlArchiveWriter::xml_attribute* sizeAttr = writer->m_Document.allocate_attribute("Size", writer->CopyBuffer());
		fieldNode->append_attribute(sizeAttr);
		return fieldNode;
	}

	static ThXmlArchiveWriter::xml_node* WriteReferenceFieldHeader(ThXmlArchiveWriter* writer, const ThI8* name, const ThI8* refType)
	{
		ThXmlArchiveWriter::xml_node* fieldNode = writer->m_Document.allocate_node(rapidxml::node_element, "RefField");
		ThXmlArchiveWriter::xml_attribute* nameAttr = writer->m_Document.allocate_attribute("Name", writer->AllocateString(name));
		fieldNode->append_attribute(nameAttr);
		ThXmlArchiveWriter::xml_attribute* typeAttr = writer->m_Document.allocate_attribute("Type", refType);
		fieldNode->append_attribute(typeAttr);
		return fieldNode;
	}

	static ThXmlArchiveWriter::xml_node* WriteWeakReferenceFieldHeader(ThXmlArchiveWriter* writer, const ThI8* name, const ThI8* refType)
	{
		ThXmlArchiveWriter::xml_node* fieldNode = writer->m_Document.allocate_node(rapidxml::node_element, "WeakRefField");
		ThXmlArchiveWriter::xml_attribute* nameAttr = writer->m_Document.allocate_attribute("Name", writer->AllocateString(name));
		fieldNode->append_attribute(nameAttr);
		ThXmlArchiveWriter::xml_attribute* typeAttr = writer->m_Document.allocate_attribute("Type", refType);
		fieldNode->append_attribute(typeAttr);
		return fieldNode;
	}

	static void WriteValue(ThXmlArchiveWriter* writer, ThXmlArchiveWriter::xml_node* fieldNode, const ThI8* value)
	{
		ThXmlArchiveWriter::xml_node* valueNode = writer->m_Document.allocate_node(rapidxml::node_element, "Value", value);
		fieldNode->append_node(valueNode);
		writer->m_CurrentSubcontainerNode->append_node(fieldNode);
	}
};

THOR_REG_TYPE(ThXmlArchiveWriter, THOR_TYPELIST_1(ThiArchiveWriter));

ThXmlArchiveWriter::ThXmlArchiveWriter()
{
	Reset();
	m_BufferSize = 128;
	m_Buffer = new ThI8[m_BufferSize];
}

ThXmlArchiveWriter::~ThXmlArchiveWriter()
{
	delete[] m_Buffer;
}

void ThXmlArchiveWriter::Reset()
{
	m_EntitiesRootNode = 0;
	m_CurrentContainerNode = 0;
	m_CurrentSubcontainerNode = 0;
	m_NodeStack.Clear();
	m_SerializedEntities.Clear();
	m_Document.clear();
}

ThI8* ThXmlArchiveWriter::AllocateString(const ThI8* str)
{
	return m_Document.allocate_string(str);
}

ThI8* ThXmlArchiveWriter::CopyBuffer()
{
	return AllocateString(m_Buffer);
}

void ThXmlArchiveWriter::PushNode(xml_node* node)
{
	if (node)
		m_NodeStack.PushBack(node);
}

ThXmlArchiveWriter::xml_node* ThXmlArchiveWriter::PopNode()
{
	if (m_NodeStack.Size())
	{
		xml_node* result = m_NodeStack.Back();
		m_NodeStack.PopBack();
		return result;
	}
	else
		return 0;
}

ThiType* ThXmlArchiveWriter::GetType(void)const
{
	return ThType<ThXmlArchiveWriter>::Instance();
}

void ThXmlArchiveWriter::Save(const ThVector<ThiEntityPtr>& entities, ThiDataStreamPtr& stream)
{
	m_NodeStack.Reserve(64);

	xml_node* decl = m_Document.allocate_node(rapidxml::node_declaration);
	decl->append_attribute(m_Document.allocate_attribute("version", "1.0"));
	decl->append_attribute(m_Document.allocate_attribute("encoding", "utf-8"));
	m_Document.append_node(decl);

	m_EntitiesRootNode = m_Document.allocate_node(rapidxml::node_element, "EntitiesRoot");
	//ThStringUtilities::ToString(entities.Size(), m_Buffer);
	//m_EntitiesRootNode->append_attribute(m_Document.allocate_attribute("Count", CopyBuffer()));
	m_Document.append_node(m_EntitiesRootNode);

	for (ThSize i = 0; i < entities.Size(); ++i)
	{
		entities[i]->Serialize(this);
	}

	ThString output;
	output.reserve(64 * 1024);
	rapidxml::print(std::back_inserter(output), m_Document, 0);
	stream->Write(output.c_str(), output.length() + 1);

	Reset();
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, ThI64 val)
{
	ThXmlArchiveWriterUtils::WriteBasicTypeField(this, name, val);
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, ThI32 val)
{
	ThXmlArchiveWriterUtils::WriteBasicTypeField(this, name, val);
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, ThI16 val)
{
	ThXmlArchiveWriterUtils::WriteBasicTypeField(this, name, val);
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, ThI8 val)
{
	ThXmlArchiveWriterUtils::WriteBasicTypeField(this, name, val);
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, ThU64 val)
{
	ThXmlArchiveWriterUtils::WriteBasicTypeField(this, name, val);
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, ThU32 val)
{
	ThXmlArchiveWriterUtils::WriteBasicTypeField(this, name, val);
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, ThU16 val)
{
	ThXmlArchiveWriterUtils::WriteBasicTypeField(this, name, val);
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, ThU8 val)
{
	ThXmlArchiveWriterUtils::WriteBasicTypeField(this, name, val);
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, ThF64 val)
{
	ThXmlArchiveWriterUtils::WriteBasicTypeField(this, name, val);
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, ThF32 val)
{
	ThXmlArchiveWriterUtils::WriteBasicTypeField(this, name, val);
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, ThBool val)
{
	ThXmlArchiveWriterUtils::WriteBasicTypeField(this, name, val);
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, const ThU16String& val)
{
	THOR_ASSERT(0, "Not Implemented");
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, const ThWideString& val)
{
	xml_node* fieldNode = ThXmlArchiveWriterUtils::WriteFieldHeader(this, name, ThType<ThWideString>::Instance()->GetName());

	std::string converted;
	//ThWideString cp(val);
	utf8::utf16to8(val.begin(), val.end(), std::back_inserter(converted));

	ThXmlArchiveWriterUtils::WriteValue(this, fieldNode, AllocateString(converted.c_str()));
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, const ThString& val)
{
	xml_node* fieldNode = ThXmlArchiveWriterUtils::WriteFieldHeader(this, name, ThType<ThString>::Instance()->GetName());

	ThXmlArchiveWriterUtils::WriteValue(this, fieldNode, AllocateString(val.c_str()));
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, const ThVec2& val)
{
	ThXmlArchiveWriterUtils::WriteVectorTypeField(this, name, val);
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, const ThVec3& val)
{
	ThXmlArchiveWriterUtils::WriteVectorTypeField(this, name, val);
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, const ThVec4& val)
{
	ThXmlArchiveWriterUtils::WriteVectorTypeField(this, name, val);
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, const ThVec2d& val)
{
	ThXmlArchiveWriterUtils::WriteVectorTypeField(this, name, val);
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, const ThVec3d& val)
{
	ThXmlArchiveWriterUtils::WriteVectorTypeField(this, name, val);
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, const ThVec4d& val)
{
	ThXmlArchiveWriterUtils::WriteVectorTypeField(this, name, val);
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, const ThMat2x2& val)
{
	ThXmlArchiveWriterUtils::WriteMatrixTypeField(this, name, val);
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, const ThMat3x3& val)
{
	ThXmlArchiveWriterUtils::WriteMatrixTypeField(this, name, val);
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, const ThMat4x4& val)
{
	ThXmlArchiveWriterUtils::WriteMatrixTypeField(this, name, val);
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, const ThMat2x2d& val)
{
	ThXmlArchiveWriterUtils::WriteMatrixTypeField(this, name, val);
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, const ThMat3x3d& val)
{
	ThXmlArchiveWriterUtils::WriteMatrixTypeField(this, name, val);
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, const ThMat4x4d& val)
{
	ThXmlArchiveWriterUtils::WriteMatrixTypeField(this, name, val);
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, const ThQuat& val)
{
	ThXmlArchiveWriterUtils::WriteVectorTypeField(this, name, val);
}

void ThXmlArchiveWriter::WriteField(const ThI8* name, const ThQuatd& val)
{
	ThXmlArchiveWriterUtils::WriteVectorTypeField(this, name, val);
}

void ThXmlArchiveWriter::WriteBeginStructureField(const ThI8* name, const ThiStructField* structure)
{
	PushNode(m_CurrentContainerNode);
	m_CurrentContainerNode = ThXmlArchiveWriterUtils::WriteStructureFieldHeader(this, name, structure->GetStructType()->GetName());
}

void ThXmlArchiveWriter::WriteEndStructureField(const ThI8* name, const ThiStructField* structure)
{
	xml_node* structRoot = m_CurrentContainerNode;
	m_CurrentContainerNode = PopNode();
	m_CurrentSubcontainerNode->append_node(structRoot);
}

void ThXmlArchiveWriter::WriteBeginSubstructure(const ThI8* structureType)
{
	PushNode(m_CurrentSubcontainerNode);

	m_CurrentSubcontainerNode = m_Document.allocate_node(rapidxml::node_element, "Substructure");
	m_CurrentSubcontainerNode->append_attribute(m_Document.allocate_attribute("Type", structureType));
}

void ThXmlArchiveWriter::WriteEndSubstructure(const ThI8* structureType)
{
	xml_node* substructRoot = m_CurrentSubcontainerNode;	
	m_CurrentSubcontainerNode = PopNode();
	m_CurrentContainerNode->append_node(substructRoot);
}

void ThXmlArchiveWriter::WriteBeginListField(const ThI8* name, const ThiType* itemType, ThSize size)
{
	PushNode(m_CurrentSubcontainerNode);
	m_CurrentSubcontainerNode = ThXmlArchiveWriterUtils::WriteListFieldHeader(this, name, itemType->GetName(), size);
}

void ThXmlArchiveWriter::WriteEndListField(const ThI8* name, const ThiType* itemType)
{
	xml_node* listRoot = m_CurrentSubcontainerNode;	
	m_CurrentSubcontainerNode = PopNode();
	m_CurrentSubcontainerNode->append_node(listRoot);
}

void ThXmlArchiveWriter::WriteBeginMapField(const ThI8* name, const ThiType* keyType, const ThiType* valueType, ThSize size)
{
	PushNode(m_CurrentSubcontainerNode);
	m_CurrentSubcontainerNode = ThXmlArchiveWriterUtils::WriteMapFieldHeader(this, name, keyType->GetName(), valueType->GetName(), size);
}

void ThXmlArchiveWriter::WriteEndMapField(const ThI8* name, const ThiType* keyType, const ThiType* valueType)
{
	xml_node* mapRoot = m_CurrentSubcontainerNode;	
	m_CurrentSubcontainerNode = PopNode();
	m_CurrentSubcontainerNode->append_node(mapRoot);
}

void ThXmlArchiveWriter::WriteReferenceField(const ThI8* name, const ThiType* refType, const ThUUID& refId)
{
	xml_node* fieldNode = ThXmlArchiveWriterUtils::WriteReferenceFieldHeader(this, name, refType->GetName());
	ThStringUtilities::ToString(refId.Get(), m_Buffer, m_BufferSize);
	xml_node* idNode = m_Document.allocate_node(rapidxml::node_element, "Id", CopyBuffer());
	fieldNode->append_node(idNode);
	m_CurrentSubcontainerNode->append_node(fieldNode);
}

void ThXmlArchiveWriter::WriteWeakReferenceField(const ThI8* name, const ThiType* refType, const ThUUID& refId)
{
	xml_node* fieldNode = ThXmlArchiveWriterUtils::WriteWeakReferenceFieldHeader(this, name, refType->GetName());
	ThStringUtilities::ToString(refId.Get(), m_Buffer, m_BufferSize);
	xml_node* idNode = m_Document.allocate_node(rapidxml::node_element, "Id", CopyBuffer());
	fieldNode->append_node(idNode);
	m_CurrentSubcontainerNode->append_node(fieldNode);
}

void ThXmlArchiveWriter::WriteBeginEntity(const ThiEntity* entity)
{
	m_SerializedEntities.Insert(const_cast<ThiEntity*>(entity), true);

	PushNode(m_CurrentContainerNode);

	m_CurrentContainerNode = m_Document.allocate_node(rapidxml::node_element, "Entity");
	ThStringUtilities::ToString(entity->GetUUID().Get(), m_Buffer, m_BufferSize);
	m_CurrentContainerNode->append_attribute(m_Document.allocate_attribute("ID", CopyBuffer()));
	m_CurrentContainerNode->append_attribute(m_Document.allocate_attribute("Type", entity->GetType()->GetName()));
}

void ThXmlArchiveWriter::WriteEndEntity(const ThiEntity* entity)
{
	xml_node* entityNode = m_CurrentContainerNode;

	m_EntitiesRootNode->append_node(m_CurrentContainerNode);

	m_CurrentContainerNode = PopNode();

	if (m_CurrentContainerNode == 0)
	{
		entityNode->append_attribute(m_Document.allocate_attribute("IsRoot", "1"));
	}
}

void ThXmlArchiveWriter::WriteBeginSubentity(const ThI8* entityType)
{
	PushNode(m_CurrentSubcontainerNode);

	m_CurrentSubcontainerNode = m_Document.allocate_node(rapidxml::node_element, "Subentity");
	m_CurrentSubcontainerNode->append_attribute(m_Document.allocate_attribute("Type", entityType));
}

void ThXmlArchiveWriter::WriteEndSubentity(const ThI8* entityType)
{
	m_CurrentContainerNode->append_node(m_CurrentSubcontainerNode);
	
	m_CurrentSubcontainerNode = PopNode();
}

void ThXmlArchiveWriter::WriteEnumField(const ThI8* name, const ThI8* enumType, ThU32 value)
{
	xml_node* fieldNode = ThXmlArchiveWriterUtils::WriteFieldHeader(this, name, enumType);

	ThStringUtilities::ToString(value, m_Buffer, m_BufferSize);

	ThXmlArchiveWriterUtils::WriteValue(this, fieldNode, CopyBuffer());
}

ThBool ThXmlArchiveWriter::IsEntitySerialized(const ThiEntity* entity)const
{
	return m_SerializedEntities.Find(const_cast<ThiEntity*>(entity)) != m_SerializedEntities.End();
}

}