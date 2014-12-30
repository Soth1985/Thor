#include <Thor/Framework/DataModel/ThXmlArchiveReader.h>
#include <Thor/Framework/DataModel/ThDataModel.h>
#include <Thor/Framework/Filesystem/LibFileSystem.h>
#include <Thor/Framework/ThRttiManager.h>
#include <Thor/Framework/ThStringUtilities.h>
#include <Thor/Framework/ThMathReflection.h>
#include <utf8cpp/utf8.h>
#include <rapidxml/rapidxml.hpp>

namespace Thor
{

struct ThXmlArchiveReaderUtils
{
	static ThXmlArchiveReader::xml_node* FindEntityNode(ThXmlArchiveReader::xml_node* entitiesRoot, const ThUUID& uuid)
	{
		ThXmlArchiveReader::xml_node* curEnt = entitiesRoot->first_node("Entity");

		while(curEnt)
		{			
			if (GetId(curEnt) == uuid.Get())
				return curEnt;

			curEnt = curEnt->next_sibling("Entity");
		}

		return 0;
	}

	static ThiEntity* CreateEntity(ThiType* type)
	{
		ThiEntity* result = 0;

		if (type->IsChildOf(ThType<ThiEntity>::Instance()))
		{
			result = (ThiEntity*)type->CreateObject(1);
		}
		else
		{
			THOR_ERR("Type %s is not an entity class")(frameworkSysLogTag, type->GetName() );
		}

		return result;
	}

	static ThiEntity* CreateEntity(const ThI8* typeName)
	{
		ThiType* type = ThRttiManager::Instance().GetType(typeName);

		if (type)
		{
			return CreateEntity(type);
		}

		THOR_ERR("Type %s is not found")(frameworkSysLogTag, typeName);

		return 0;
	}

	static ThiEntity* CreateEntity(ThXmlArchiveReader::xml_node* entityNode)
	{
		ThXmlArchiveReader::xml_attribute* typeAttr = entityNode->first_attribute("Type");
		ThiType* type = ThRttiManager::Instance().GetType(typeAttr->value());

		if(type)
		{
			return CreateEntity(type);
		}
		else
		{
			ThXmlArchiveReader::xml_node* subentityNode = entityNode->first_node("Subentity");

			while (subentityNode)
			{
				typeAttr = subentityNode->first_attribute("Type");
				type = ThRttiManager::Instance().GetType(subentityNode->value());

				if (type)
				{
					return CreateEntity(type);
				}

				subentityNode = subentityNode->next_sibling("Subentity");
			}
		}

		THOR_ERR("Type %s is not found")(frameworkSysLogTag, typeAttr->value());

		return 0;
	}

	static ThXmlArchiveReader::xml_node* FindSubcontainerNode(ThXmlArchiveReader::xml_node* containerNode, const ThI8* typeName, const ThI8* subContainerTag)
	{
		ThXmlArchiveReader::xml_node* result = containerNode->first_node(subContainerTag);

		while (result)
		{
			ThXmlArchiveReader::xml_attribute* typeAttr = result->first_attribute("Type");

			if (!strcmp(typeAttr->value(), typeName))
			{
				return result;
			}

			result = result->next_sibling(subContainerTag);
		}
		
		return 0;
	}

	static ThXmlArchiveReader::xml_node* FindFieldNode(ThXmlArchiveReader::xml_node* containerNode, const ThI8* fieldTag, const ThI8* fieldName)
	{
		ThXmlArchiveReader::xml_node* fieldNode = containerNode->first_node(fieldTag);

		while (fieldNode)
		{
			ThXmlArchiveReader::xml_attribute* nameAttr = fieldNode->first_attribute("Name");

			if (!strcmp(fieldName, nameAttr->value()))
			{
				return fieldNode;
			}

			fieldNode = fieldNode->next_sibling(fieldTag);
		}

		return 0;
	}

	static const ThI8* GetValue(ThXmlArchiveReader::xml_node* node, const ThI8* valueTag)
	{
		return node->first_node(valueTag)->value();
	}

	static const ThI8* GetTypeName(ThXmlArchiveReader::xml_node* node)
	{
		ThXmlArchiveReader::xml_attribute* typeAttr = node->first_attribute("Type");
		return typeAttr->value();
	}

	static const ThI8* GetKeyTypeName(ThXmlArchiveReader::xml_node* node)
	{
		ThXmlArchiveReader::xml_attribute* typeAttr = node->first_attribute("KeyType");
		return typeAttr->value();
	}
	static const ThI8* GetValueTypeName(ThXmlArchiveReader::xml_node* node)
	{
		ThXmlArchiveReader::xml_attribute* typeAttr = node->first_attribute("ValueType");
		return typeAttr->value();
	}

	static const ThI8* GetName(ThXmlArchiveReader::xml_node* node)
	{
		ThXmlArchiveReader::xml_attribute* nameAttr = node->first_attribute("Name");
		return nameAttr->value();
	}

	static ThU64 GetId(ThXmlArchiveReader::xml_node* node)
	{
		ThU64 result = 0;
		ThXmlArchiveReader::xml_attribute* idAttr = node->first_attribute("ID");
		
		if (!ThStringUtilities::Parse(idAttr->value(), result))
		{
			LogParseFailedInfo(node, GetName(node));
		}
		
		return result;
	}

	static ThSize GetSize(ThXmlArchiveReader::xml_node* node)
	{
		ThSize result = 0;
		ThXmlArchiveReader::xml_attribute* idAttr = node->first_attribute("Size");
		ThStringUtilities::Parse(idAttr->value(), result);
		return result;
	}

	static ThXmlArchiveReader::xml_node* FindParentEntity(ThXmlArchiveReader::xml_node* node)
	{
		ThXmlArchiveReader::xml_node* curNode = node;

		while(curNode)
		{
			if (!strcmp("Entity", curNode->name()))
				return curNode;

			curNode = curNode->parent();
		}

		return 0;
	}

	static void LogParseFailedInfo(ThXmlArchiveReader::xml_node* fieldNode, const ThI8* name)
	{
		ThXmlArchiveReader::xml_node* entity = FindParentEntity(fieldNode);
		THOR_ERR("Field %s in entity with id = %lld has failed to be parsed")(frameworkSysLogTag, name, GetId(entity));
	}

	static void LogInvalidEnumTypeInfo(ThXmlArchiveReader::xml_node* fieldNode, const ThI8* name)
	{
		ThXmlArchiveReader::xml_node* entity = FindParentEntity(fieldNode);
		THOR_ERR("Field %s in entity with id = %lld has unexpected enum type")(frameworkSysLogTag, name, GetId(entity));
	}

	static void LogIncompatibleReferenceTypeInfo(ThXmlArchiveReader::xml_node* fieldNode, const ThI8* name)
	{
		ThXmlArchiveReader::xml_node* entity = FindParentEntity(fieldNode);
		THOR_ERR("Field %s in entity with id = %lld references a non-existent entity")(frameworkSysLogTag, name, GetId(entity));
	}

	static void LogEntityNotFound(const ThUUID& uuid)
	{
		THOR_ERR("Entity with id = %lld is not found")(frameworkSysLogTag, uuid.Get());
	}

	static void LogConversionInfo(ThXmlArchiveReader::xml_node* fieldNode, const ThI8* name, const ThXmlArchiveReader::ConversionCheckResult& check)
	{
		if (!check.m_IsConvertible)
		{
			ThXmlArchiveReader::xml_node* entity = FindParentEntity(fieldNode);
			THOR_ERR("Field %s in entity with id = %lld cannot be read")(frameworkSysLogTag, name, GetId(entity));
		}

		if (check.m_PrecisionLoss)
		{
			ThXmlArchiveReader::xml_node* entity = FindParentEntity(fieldNode);
			THOR_WRN("Possible precision loss during conversion of field %s in entity with id = %lld")(frameworkSysLogTag, name, GetId(entity));
		}

		if (check.m_SignedUnsignedMismatch)
		{
			ThXmlArchiveReader::xml_node* entity = FindParentEntity(fieldNode);
			THOR_WRN("Signed/unsigned mismatch during conversion of field %s in entity with id = %lld")(frameworkSysLogTag, name, GetId(entity));
		}
	}

	template <class T>
	static ThBool ReadBasicTypeField(ThXmlArchiveReader* reader, const ThI8* name, T& val)
	{
		ThXmlArchiveReader::xml_node* fieldNode = FindFieldNode(reader->m_CurrentSubcontainerNode, "Field", name);
		ThBool result = false;

		if (fieldNode)
		{
			ThXmlArchiveReader::ConversionCheckResult check = reader->IsBaseTypeConvertibleTo(GetTypeName(fieldNode), ThType<T>::Instance()->GetName());
			LogConversionInfo(fieldNode, name, check);
			if (check.m_IsConvertible)
			{
				if(!ThStringUtilities::Parse(GetValue(fieldNode, "Value"), val))
				{
					LogParseFailedInfo(fieldNode, name);
				}
				else
					result = true;
			}
		}

		return result;
	}

	template <class VecT>
	static ThBool ReadVectorTypeField(ThXmlArchiveReader* reader, const ThI8* name, VecT& val)
	{
		ThXmlArchiveReader::xml_node* fieldNode = FindFieldNode(reader->m_CurrentSubcontainerNode, "Field", name);
		ThBool result = false;

		if (fieldNode)
		{
			ThXmlArchiveReader::ConversionCheckResult check = reader->IsBaseTypeConvertibleTo(GetTypeName(fieldNode), ThType<VecT>::Instance()->GetName());
			LogConversionInfo(fieldNode, name, check);

			ThI8 buf[128];

			if (check.m_IsConvertible)
			{
				result = true;

				for (unsigned int i = 0; i < val.Size(); ++i)
				{
					sprintf(buf, "v%u", i);
					ThXmlArchiveReader::xml_node* valNode = fieldNode->first_node(buf);

					if(!ThStringUtilities::Parse(valNode->value(), val(i)))
					{
						LogParseFailedInfo(fieldNode, name);
						result = false;
						//break;
					}
				}
			}
		}

		return result;
	}

	template <class MatT>
	static ThBool ReadMatrixTypeField(ThXmlArchiveReader* reader, const ThI8* name, MatT& val)
	{
		ThXmlArchiveReader::xml_node* fieldNode = FindFieldNode(reader->m_CurrentSubcontainerNode, "Field", name);
		ThBool result = false;

		if (fieldNode)
		{
			ThXmlArchiveReader::ConversionCheckResult check = reader->IsBaseTypeConvertibleTo(GetTypeName(fieldNode), ThType<MatT>::Instance()->GetName());
			LogConversionInfo(fieldNode, name, check);
			ThI8 buf[128];

			if (check.m_IsConvertible)
			{
				result = true;
				for (unsigned int i = 0; i < val.Size(); ++i)
				{
					sprintf(buf, "m%u", i);
					ThXmlArchiveReader::xml_node* valNode = fieldNode->first_node(buf);

					if(!ThStringUtilities::Parse(valNode->value(), val(i)))
					{
						LogParseFailedInfo(fieldNode, name);
						result = false;
					}
				}

				ThXmlArchiveReader::xml_node* isRowMajorAttr = fieldNode->first_node("IsRowMajor");

				if (isRowMajorAttr)
				{
					ThBool isRowMajor = true;

					if (!strcmp(isRowMajorAttr->value(), "0"))
						isRowMajor = false;

					if (isRowMajor != val.IsRowMajor())
						val.Transpose();
				}
			}
		}

		return result;
	}

	static ThiEntity* ReadReferenceField(ThXmlArchiveReader* reader, const ThI8* name, const ThI8* fieldTag, const ThiType* refType, ThUUID& uuid)
	{
		ThiEntity* result = 0;

		ThXmlArchiveReader::xml_node* fieldNode = FindFieldNode(reader->m_CurrentSubcontainerNode, fieldTag, name);

		if (fieldNode)
		{
			const ThI8* typeName = GetTypeName(fieldNode);

			if (!strcmp(refType->GetName(), typeName))
			{
				ThU64 id;
				if (ThStringUtilities::Parse(GetValue(fieldNode, "Id"), id))
				{
					uuid = id;
					ThHashMap<ThU64, ThiEntity* >::Iterator i = reader->m_DeserializedEntitiesById.Find(id);

					if (i != reader->m_DeserializedEntitiesById.End())
						return i->Value();

					ThXmlArchiveReader::xml_node* entityNode = FindEntityNode(reader->m_EntitiesRootNode, id);

					if (entityNode)
						result = CreateEntity(entityNode);
					else
						LogEntityNotFound(id);
				}
				else
					LogParseFailedInfo(fieldNode, name);
			}
			else
				LogIncompatibleReferenceTypeInfo(fieldNode, name);
		}

		 
		return result;
	}
};

THOR_REG_TYPE(ThXmlArchiveReader, THOR_TYPELIST_1(ThiArchiveReader));

ThXmlArchiveReader::ThXmlArchiveReader()
{
	Reset();
	InitBaseTypeConversionTable();
}

void ThXmlArchiveReader::Reset()
{
	m_Document.clear();
	m_NodeStack.Clear();
	m_EntitiesRootNode = 0;
	m_CurrentContainerNode = 0;
	m_CurrentSubcontainerNode = 0;
}

ThXmlArchiveReader::ConversionCheckResult ThXmlArchiveReader::IsBaseTypeConvertibleTo(const ThI8* from, const ThI8* to)
{
	if(!strcmp(from, to))
		return ConversionCheckResult(true, false, false);

	ThHashMap<const ThI8*, ThVector<ConversionEntry> >::Iterator i = m_BaseTypeConversionTable.Find(from);

	if (i != m_BaseTypeConversionTable.End())
	{
		ThVector<ConversionEntry>& entries = i->Value();
		
		for(ThSize e = 0; e < entries.Size(); ++e)
		{
			if (!strcmp(entries[e].m_TypeName, to))
			{
				return ConversionCheckResult(true, entries[e].m_PrecisionLoss, entries[e].m_SignedUnsignedMismatch);
			}
		}
	}

	return ConversionCheckResult(false, false, false);
}

void ThXmlArchiveReader::InitBaseTypeConversionTable()
{
	const ThI8* thI8Name = ThType<ThI8>::Instance()->GetName();
	const ThI8* thI16Name = ThType<ThI16>::Instance()->GetName();
	const ThI8* thI32Name = ThType<ThI32>::Instance()->GetName();
	const ThI8* thI64Name = ThType<ThI64>::Instance()->GetName();

	const ThI8* thU8Name = ThType<ThU8>::Instance()->GetName();
	const ThI8* thU16Name = ThType<ThU16>::Instance()->GetName();
	const ThI8* thU32Name = ThType<ThU32>::Instance()->GetName();
	const ThI8* thU64Name = ThType<ThU64>::Instance()->GetName();

	const ThI8* thF32Name = ThType<ThF32>::Instance()->GetName();
	const ThI8* thF64Name = ThType<ThF64>::Instance()->GetName();

	const ThI8* thBoolName = ThType<ThBool>::Instance()->GetName();

	const ThI8* thVec2Name = ThType<ThVec2>::Instance()->GetName();
	const ThI8* thVec3Name = ThType<ThVec3>::Instance()->GetName();
	const ThI8* thVec4Name = ThType<ThVec4>::Instance()->GetName();

	const ThI8* thVec2dName = ThType<ThVec2d>::Instance()->GetName();
	const ThI8* thVec3dName = ThType<ThVec3d>::Instance()->GetName();
	const ThI8* thVec4dName = ThType<ThVec4d>::Instance()->GetName();

	const ThI8* thMat2x2Name = ThType<ThMat2x2>::Instance()->GetName();
	const ThI8* thMat3x3Name = ThType<ThMat3x3>::Instance()->GetName();
	const ThI8* thMat4x4Name = ThType<ThMat4x4>::Instance()->GetName();

	const ThI8* thMat2x2dName = ThType<ThMat2x2d>::Instance()->GetName();
	const ThI8* thMat3x3dName = ThType<ThMat3x3d>::Instance()->GetName();
	const ThI8* thMat4x4dName = ThType<ThMat4x4d>::Instance()->GetName();
	
	const ThI8* thQuatName = ThType<ThQuat>::Instance()->GetName();
	const ThI8* thQuatdName = ThType<ThQuatd>::Instance()->GetName();

	const ThI8* thStringName = ThType<ThString>::Instance()->GetName();
	const ThI8* thWideStringName = ThType<ThWideString>::Instance()->GetName();
	
	//ThI8
	{
		m_BaseTypeConversionTable[thI8Name].PushBack( ConversionEntry(thI16Name) );
		m_BaseTypeConversionTable[thI8Name].PushBack( ConversionEntry(thI32Name) );
		m_BaseTypeConversionTable[thI8Name].PushBack( ConversionEntry(thI64Name) );

		m_BaseTypeConversionTable[thI8Name].PushBack( ConversionEntry(thU8Name, false, true) );
		m_BaseTypeConversionTable[thI8Name].PushBack( ConversionEntry(thU16Name, false, true) );
		m_BaseTypeConversionTable[thI8Name].PushBack( ConversionEntry(thU32Name, false, true) );
		m_BaseTypeConversionTable[thI8Name].PushBack( ConversionEntry(thU64Name, false, true) );

		m_BaseTypeConversionTable[thI8Name].PushBack( ConversionEntry(thBoolName) );

		m_BaseTypeConversionTable[thI8Name].PushBack( ConversionEntry(thF32Name) );
		m_BaseTypeConversionTable[thI8Name].PushBack( ConversionEntry(thF64Name) );
	}

	//ThI16
	{
		m_BaseTypeConversionTable[thI16Name].PushBack( ConversionEntry(thI8Name, true) );
		m_BaseTypeConversionTable[thI16Name].PushBack( ConversionEntry(thI32Name) );
		m_BaseTypeConversionTable[thI16Name].PushBack( ConversionEntry(thI64Name) );

		m_BaseTypeConversionTable[thI16Name].PushBack( ConversionEntry(thU8Name, true, true) );
		m_BaseTypeConversionTable[thI16Name].PushBack( ConversionEntry(thU16Name, false, true) );
		m_BaseTypeConversionTable[thI16Name].PushBack( ConversionEntry(thU32Name, false, true) );
		m_BaseTypeConversionTable[thI16Name].PushBack( ConversionEntry(thU64Name, false, true) );

		m_BaseTypeConversionTable[thI16Name].PushBack( ConversionEntry(thBoolName) );

		m_BaseTypeConversionTable[thI16Name].PushBack( ConversionEntry(thF32Name) );
		m_BaseTypeConversionTable[thI16Name].PushBack( ConversionEntry(thF64Name) );
	}

	//ThI32
	{
		m_BaseTypeConversionTable[thI32Name].PushBack( ConversionEntry(thI8Name, true) );
		m_BaseTypeConversionTable[thI32Name].PushBack( ConversionEntry(thI16Name, true) );
		m_BaseTypeConversionTable[thI32Name].PushBack( ConversionEntry(thI64Name) );

		m_BaseTypeConversionTable[thI32Name].PushBack( ConversionEntry(thU8Name, true, true) );
		m_BaseTypeConversionTable[thI32Name].PushBack( ConversionEntry(thU16Name, true, true) );
		m_BaseTypeConversionTable[thI32Name].PushBack( ConversionEntry(thU32Name, false, true) );
		m_BaseTypeConversionTable[thI32Name].PushBack( ConversionEntry(thU64Name, false, true) );

		m_BaseTypeConversionTable[thI32Name].PushBack( ConversionEntry(thBoolName) );

		m_BaseTypeConversionTable[thI32Name].PushBack( ConversionEntry(thF32Name) );
		m_BaseTypeConversionTable[thI32Name].PushBack( ConversionEntry(thF64Name) );
	}

	//ThI64
	{
		m_BaseTypeConversionTable[thI64Name].PushBack( ConversionEntry(thI8Name, true) );
		m_BaseTypeConversionTable[thI64Name].PushBack( ConversionEntry(thI16Name, true) );
		m_BaseTypeConversionTable[thI64Name].PushBack( ConversionEntry(thI32Name, true) );

		m_BaseTypeConversionTable[thI64Name].PushBack( ConversionEntry(thU8Name, true, true) );
		m_BaseTypeConversionTable[thI64Name].PushBack( ConversionEntry(thU16Name, true, true) );
		m_BaseTypeConversionTable[thI64Name].PushBack( ConversionEntry(thU32Name, true, true) );
		m_BaseTypeConversionTable[thI64Name].PushBack( ConversionEntry(thU64Name, false, true) );

		m_BaseTypeConversionTable[thI64Name].PushBack( ConversionEntry(thBoolName) );

		m_BaseTypeConversionTable[thI64Name].PushBack( ConversionEntry(thF32Name) );
		m_BaseTypeConversionTable[thI64Name].PushBack( ConversionEntry(thF64Name) );
	}
	
	//ThU8
	{
		m_BaseTypeConversionTable[thU8Name].PushBack( ConversionEntry(thI8Name, false, true) );
		m_BaseTypeConversionTable[thU8Name].PushBack( ConversionEntry(thI16Name, false, true) );
		m_BaseTypeConversionTable[thU8Name].PushBack( ConversionEntry(thI32Name, false, true) );
		m_BaseTypeConversionTable[thU8Name].PushBack( ConversionEntry(thI64Name, false, true) );

		m_BaseTypeConversionTable[thU8Name].PushBack( ConversionEntry(thU16Name) );
		m_BaseTypeConversionTable[thU8Name].PushBack( ConversionEntry(thU32Name) );
		m_BaseTypeConversionTable[thU8Name].PushBack( ConversionEntry(thU64Name) );

		m_BaseTypeConversionTable[thU8Name].PushBack( ConversionEntry(thBoolName) );

		m_BaseTypeConversionTable[thU8Name].PushBack( ConversionEntry(thF32Name, false, true) );
		m_BaseTypeConversionTable[thU8Name].PushBack( ConversionEntry(thF64Name, false, true) );
	}

	//ThU16
	{
		m_BaseTypeConversionTable[thU16Name].PushBack( ConversionEntry(thI8Name, true, true) );
		m_BaseTypeConversionTable[thU16Name].PushBack( ConversionEntry(thI16Name, false, true) );
		m_BaseTypeConversionTable[thU16Name].PushBack( ConversionEntry(thI32Name, false, true) );
		m_BaseTypeConversionTable[thU16Name].PushBack( ConversionEntry(thI64Name, false, true) );

		m_BaseTypeConversionTable[thU16Name].PushBack( ConversionEntry(thU8Name, true) );
		m_BaseTypeConversionTable[thU16Name].PushBack( ConversionEntry(thU32Name) );
		m_BaseTypeConversionTable[thU16Name].PushBack( ConversionEntry(thU64Name) );

		m_BaseTypeConversionTable[thU16Name].PushBack( ConversionEntry(thBoolName) );

		m_BaseTypeConversionTable[thU16Name].PushBack( ConversionEntry(thF32Name, false, true) );
		m_BaseTypeConversionTable[thU16Name].PushBack( ConversionEntry(thF64Name, false, true) );
	}

	//ThU32
	{
		m_BaseTypeConversionTable[thU32Name].PushBack( ConversionEntry(thI8Name, true, true) );
		m_BaseTypeConversionTable[thU32Name].PushBack( ConversionEntry(thI16Name, true, true) );
		m_BaseTypeConversionTable[thU32Name].PushBack( ConversionEntry(thI32Name, false, true) );
		m_BaseTypeConversionTable[thU32Name].PushBack( ConversionEntry(thI64Name, false, true) );

		m_BaseTypeConversionTable[thU32Name].PushBack( ConversionEntry(thU8Name, true) );
		m_BaseTypeConversionTable[thU32Name].PushBack( ConversionEntry(thU16Name, true) );
		m_BaseTypeConversionTable[thU32Name].PushBack( ConversionEntry(thU64Name) );

		m_BaseTypeConversionTable[thU32Name].PushBack( ConversionEntry(thBoolName) );

		m_BaseTypeConversionTable[thU32Name].PushBack( ConversionEntry(thF32Name, false, true) );
		m_BaseTypeConversionTable[thU32Name].PushBack( ConversionEntry(thF64Name, false, true) );
	}

	//ThU64
	{
		m_BaseTypeConversionTable[thU64Name].PushBack( ConversionEntry(thI8Name, true, true) );
		m_BaseTypeConversionTable[thU64Name].PushBack( ConversionEntry(thI16Name, true, true) );
		m_BaseTypeConversionTable[thU64Name].PushBack( ConversionEntry(thI32Name, true, true) );
		m_BaseTypeConversionTable[thU64Name].PushBack( ConversionEntry(thI64Name, false, true) );

		m_BaseTypeConversionTable[thU64Name].PushBack( ConversionEntry(thU8Name, true) );
		m_BaseTypeConversionTable[thU64Name].PushBack( ConversionEntry(thU16Name, true) );
		m_BaseTypeConversionTable[thU64Name].PushBack( ConversionEntry(thU32Name, true) );

		m_BaseTypeConversionTable[thU64Name].PushBack( ConversionEntry(thBoolName) );

		m_BaseTypeConversionTable[thU64Name].PushBack( ConversionEntry(thF32Name, false, true) );
		m_BaseTypeConversionTable[thU64Name].PushBack( ConversionEntry(thF64Name, false, true) );
	}

	//ThF32
	{
		m_BaseTypeConversionTable[thF32Name].PushBack( ConversionEntry(thI8Name, true) );
		m_BaseTypeConversionTable[thF32Name].PushBack( ConversionEntry(thI16Name, true) );
		m_BaseTypeConversionTable[thF32Name].PushBack( ConversionEntry(thI32Name, true) );
		m_BaseTypeConversionTable[thF32Name].PushBack( ConversionEntry(thI64Name, true) );

		m_BaseTypeConversionTable[thF32Name].PushBack( ConversionEntry(thU8Name, true, true) );
		m_BaseTypeConversionTable[thF32Name].PushBack( ConversionEntry(thU16Name, true, true) );
		m_BaseTypeConversionTable[thF32Name].PushBack( ConversionEntry(thU32Name, true, true) );
		m_BaseTypeConversionTable[thF32Name].PushBack( ConversionEntry(thU64Name, true, true) );

		m_BaseTypeConversionTable[thF32Name].PushBack( ConversionEntry(thBoolName, true) );

		m_BaseTypeConversionTable[thF32Name].PushBack( ConversionEntry(thF64Name) );
	}

	//ThF64
	{
		m_BaseTypeConversionTable[thF64Name].PushBack( ConversionEntry(thI8Name, true) );
		m_BaseTypeConversionTable[thF64Name].PushBack( ConversionEntry(thI16Name, true) );
		m_BaseTypeConversionTable[thF64Name].PushBack( ConversionEntry(thI32Name, true) );
		m_BaseTypeConversionTable[thF64Name].PushBack( ConversionEntry(thI64Name, true) );

		m_BaseTypeConversionTable[thF64Name].PushBack( ConversionEntry(thU8Name, true, true) );
		m_BaseTypeConversionTable[thF64Name].PushBack( ConversionEntry(thU16Name, true, true) );
		m_BaseTypeConversionTable[thF64Name].PushBack( ConversionEntry(thU32Name, true, true) );
		m_BaseTypeConversionTable[thF64Name].PushBack( ConversionEntry(thU64Name, true, true) );

		m_BaseTypeConversionTable[thF64Name].PushBack( ConversionEntry(thBoolName, true) );

		m_BaseTypeConversionTable[thF64Name].PushBack( ConversionEntry(thF32Name, true) );
	}

	//ThBool
	{
		m_BaseTypeConversionTable[thBoolName].PushBack( ConversionEntry(thI8Name) );
		m_BaseTypeConversionTable[thBoolName].PushBack( ConversionEntry(thI16Name) );
		m_BaseTypeConversionTable[thBoolName].PushBack( ConversionEntry(thI32Name) );
		m_BaseTypeConversionTable[thBoolName].PushBack( ConversionEntry(thI64Name) );

		m_BaseTypeConversionTable[thBoolName].PushBack( ConversionEntry(thU8Name) );
		m_BaseTypeConversionTable[thBoolName].PushBack( ConversionEntry(thU16Name) );
		m_BaseTypeConversionTable[thBoolName].PushBack( ConversionEntry(thU32Name) );
		m_BaseTypeConversionTable[thBoolName].PushBack( ConversionEntry(thU64Name) );

		m_BaseTypeConversionTable[thBoolName].PushBack( ConversionEntry(thBoolName) );

		m_BaseTypeConversionTable[thBoolName].PushBack( ConversionEntry(thF32Name) );
		m_BaseTypeConversionTable[thBoolName].PushBack( ConversionEntry(thF64Name) );
	}

	//ThVec2
	{
		m_BaseTypeConversionTable[thVec2Name].PushBack( ConversionEntry(thVec2dName) );
	}

	//ThVec2d
	{
		m_BaseTypeConversionTable[thVec2dName].PushBack( ConversionEntry(thVec2Name, true) );
	}

	//ThVec3
	{
		m_BaseTypeConversionTable[thVec3Name].PushBack( ConversionEntry(thVec3dName) );
	}

	//ThVec3d
	{
		m_BaseTypeConversionTable[thVec3dName].PushBack( ConversionEntry(thVec3Name, true) );
	}

	//ThVec4
	{
		m_BaseTypeConversionTable[thVec4Name].PushBack( ConversionEntry(thVec4dName) );
	}

	//ThVec4d
	{
		m_BaseTypeConversionTable[thVec4dName].PushBack( ConversionEntry(thVec4Name, true) );
	}

	//ThMat2x2
	{
		m_BaseTypeConversionTable[thMat2x2Name].PushBack( ConversionEntry(thMat2x2dName) );
	}

	//ThMat2x2d
	{
		m_BaseTypeConversionTable[thMat2x2dName].PushBack( ConversionEntry(thMat2x2Name, true) );
	}

	//ThMat3x3
	{
		m_BaseTypeConversionTable[thMat3x3Name].PushBack( ConversionEntry(thMat3x3dName) );
	}

	//ThMat3x3d
	{
		m_BaseTypeConversionTable[thMat3x3dName].PushBack( ConversionEntry(thMat3x3Name, true) );
	}

	//ThMat4x4
	{
		m_BaseTypeConversionTable[thMat4x4Name].PushBack( ConversionEntry(thMat4x4dName) );
	}

	//ThMat4x4d
	{
		m_BaseTypeConversionTable[thMat4x4dName].PushBack( ConversionEntry(thMat4x4Name, true) );
	}

	//ThQuat
	{
		m_BaseTypeConversionTable[thQuatName].PushBack( ConversionEntry(thQuatdName) );
	}

	//ThQuatd
	{
		m_BaseTypeConversionTable[thQuatdName].PushBack( ConversionEntry(thQuatName, true) );
	}

	//ThString
	{
		m_BaseTypeConversionTable[thStringName].PushBack( ConversionEntry(thWideStringName) );
	}
}

ThiType* ThXmlArchiveReader::GetType(void)const
{
	return ThType<ThXmlArchiveReader>::Instance();
}

void ThXmlArchiveReader::PushNode(xml_node* node)
{
	if (node)
		m_NodeStack.PushBack(node);
}

ThXmlArchiveReader::xml_node* ThXmlArchiveReader::PopNode()
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

void ThXmlArchiveReader::Load(ThVector<ThiEntityPtr>& entities, ThiDataStreamPtr& stream)
{
	ThSize bufSize = stream->GetSize();

	if (bufSize == 0)
		return;

	ThI8* buffer = new ThI8[bufSize];

	stream->Read(buffer, bufSize);

	m_Document.parse<rapidxml::parse_declaration_node | rapidxml::parse_no_data_nodes>(buffer);

	m_EntitiesRootNode = m_Document.first_node("EntitiesRoot");

	xml_node* curRootEntity = m_EntitiesRootNode->first_node("Entity");

	while (curRootEntity)
	{
		xml_attribute* isRootAttr = curRootEntity->first_attribute("IsRoot");

		if (isRootAttr)
		{
			ThiEntity* entityInst = ThXmlArchiveReaderUtils::CreateEntity(curRootEntity);

			if (entityInst)
			{
				ThU64 id = ThXmlArchiveReaderUtils::GetId(curRootEntity);

				entityInst->Deserialize(this, ThUUID(id));
				entities.PushBack(entityInst);
			}
		}

		curRootEntity = curRootEntity->next_sibling("Entity");
	}

	delete[] buffer;
	Reset();
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThI64& val)
{
	return ThXmlArchiveReaderUtils::ReadBasicTypeField(this, name, val);
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThI32& val)
{
	return ThXmlArchiveReaderUtils::ReadBasicTypeField(this, name, val);
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThI16& val)
{
	return ThXmlArchiveReaderUtils::ReadBasicTypeField(this, name, val);
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThI8& val)
{
	return ThXmlArchiveReaderUtils::ReadBasicTypeField(this, name, val);
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThU64& val)
{
	return ThXmlArchiveReaderUtils::ReadBasicTypeField(this, name, val);
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThU32& val)
{
	return ThXmlArchiveReaderUtils::ReadBasicTypeField(this, name, val);
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThU16& val)
{
	return ThXmlArchiveReaderUtils::ReadBasicTypeField(this, name, val);
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThU8& val)
{
	return ThXmlArchiveReaderUtils::ReadBasicTypeField(this, name, val);
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThF64& val)
{
	return ThXmlArchiveReaderUtils::ReadBasicTypeField(this, name, val);
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThF32& val)
{
	return ThXmlArchiveReaderUtils::ReadBasicTypeField(this, name, val);
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThBool& val)
{
	return ThXmlArchiveReaderUtils::ReadBasicTypeField(this, name, val);
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThU16String& val)
{
	THOR_ASSERT(0, "Not Implemented");
	return false;
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThWideString& val)
{
	xml_node* fieldNode = ThXmlArchiveReaderUtils::FindFieldNode(m_CurrentSubcontainerNode, "Field", name);

	if (fieldNode)
	{
		ConversionCheckResult check = IsBaseTypeConvertibleTo(ThXmlArchiveReaderUtils::GetTypeName(fieldNode), ThType<ThWideString>::Instance()->GetName());
		ThXmlArchiveReaderUtils::LogConversionInfo(fieldNode, name, check);

		if (check.m_IsConvertible)
		{
			const ThI8* value = ThXmlArchiveReaderUtils::GetValue(fieldNode, "Value");

			if (value)
			{
				val.clear();
				utf8::utf8to16(value, value + strlen(value), std::back_inserter(val));
				return true;
			}
			else
			{
				ThXmlArchiveReaderUtils::LogParseFailedInfo(fieldNode, name);
			}
		}		
	}

	return false;
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThString& val)
{
	xml_node* fieldNode = ThXmlArchiveReaderUtils::FindFieldNode(m_CurrentSubcontainerNode, "Field", name);

	if (fieldNode)
	{
		ConversionCheckResult check = IsBaseTypeConvertibleTo(ThXmlArchiveReaderUtils::GetTypeName(fieldNode), ThType<ThString>::Instance()->GetName());
		ThXmlArchiveReaderUtils::LogConversionInfo(fieldNode, name, check);

		if (check.m_IsConvertible)
		{
			const ThI8* value = ThXmlArchiveReaderUtils::GetValue(fieldNode, "Value");

			if (value)
			{
				val = value;
				return true;
			}
			else
			{
				ThXmlArchiveReaderUtils::LogParseFailedInfo(fieldNode, name);
			}
		}
	}

	return false;
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThVec2& val)
{
	return ThXmlArchiveReaderUtils::ReadVectorTypeField(this, name, val);
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThVec3& val)
{
	return ThXmlArchiveReaderUtils::ReadVectorTypeField(this, name, val);
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThVec4& val)
{
	return ThXmlArchiveReaderUtils::ReadVectorTypeField(this, name, val);
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThVec2d& val)
{
	return ThXmlArchiveReaderUtils::ReadVectorTypeField(this, name, val);
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThVec3d& val)
{
	return ThXmlArchiveReaderUtils::ReadVectorTypeField(this, name, val);
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThVec4d& val)
{
	return ThXmlArchiveReaderUtils::ReadVectorTypeField(this, name, val);
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThMat2x2& val)
{
	return ThXmlArchiveReaderUtils::ReadMatrixTypeField(this, name, val);
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThMat3x3& val)
{
	return ThXmlArchiveReaderUtils::ReadMatrixTypeField(this, name, val);
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThMat4x4& val)
{
	return ThXmlArchiveReaderUtils::ReadMatrixTypeField(this, name, val);
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThMat2x2d& val)
{
	return ThXmlArchiveReaderUtils::ReadMatrixTypeField(this, name, val);
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThMat3x3d& val)
{
	return ThXmlArchiveReaderUtils::ReadMatrixTypeField(this, name, val);
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThMat4x4d& val)
{
	return ThXmlArchiveReaderUtils::ReadMatrixTypeField(this, name, val);
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThQuat& val)
{
	return ThXmlArchiveReaderUtils::ReadVectorTypeField(this, name, val);
}

ThBool ThXmlArchiveReader::ReadField(const ThI8* name, ThQuatd& val)
{
	return ThXmlArchiveReaderUtils::ReadVectorTypeField(this, name, val);
}

ThBool ThXmlArchiveReader::ReadBeginStructureField(const ThI8* name)
{
	xml_node* fieldNode = ThXmlArchiveReaderUtils::FindFieldNode(m_CurrentSubcontainerNode, "StructureField", name);

	if (fieldNode)
	{
		PushNode(m_CurrentContainerNode);
		m_CurrentContainerNode = fieldNode;
		return true;
	}

	return false;
}

void ThXmlArchiveReader::ReadEndStructureField(const char* name)
{
	m_CurrentContainerNode = PopNode();
}

ThBool ThXmlArchiveReader::ReadBeginSubstructure(const ThI8* name)
{
	xml_node* substructureRoot = ThXmlArchiveReaderUtils::FindSubcontainerNode(m_CurrentContainerNode, name, "Substructure");

	if (substructureRoot)
	{
		PushNode(m_CurrentSubcontainerNode);
		m_CurrentSubcontainerNode = substructureRoot;
		return true;
	}

	return false;
}

void ThXmlArchiveReader::ReadEndSubstructure(const ThI8* name)
{
	m_CurrentSubcontainerNode = PopNode();
}

ThBool ThXmlArchiveReader::ReadBeginListField(const ThI8* name, const ThiType* itemType, ThSize& size)
{
	xml_node* fieldNode = ThXmlArchiveReaderUtils::FindFieldNode(m_CurrentSubcontainerNode, "ListField", name);

	if (fieldNode)
	{
		const ThI8* type = ThXmlArchiveReaderUtils::GetTypeName(fieldNode);
		ConversionCheckResult check = IsBaseTypeConvertibleTo(type, itemType->GetName());
		ThXmlArchiveReaderUtils::LogConversionInfo(fieldNode, name, check);

		if (check.m_IsConvertible)
		{
			PushNode(m_CurrentSubcontainerNode);
			m_CurrentSubcontainerNode = fieldNode;
			size = ThXmlArchiveReaderUtils::GetSize(fieldNode);
			return true;
		}
	}

	return false;
}

void ThXmlArchiveReader::ReadEndListField(const ThI8* name, const ThiType* itemType)
{
	m_CurrentSubcontainerNode = PopNode();
}

ThBool ThXmlArchiveReader::ReadBeginMapField(const ThI8* name, const ThiType* keyType, const ThiType* valueType, ThSize& size)
{
	xml_node* fieldNode = ThXmlArchiveReaderUtils::FindFieldNode(m_CurrentSubcontainerNode, "MapField", name);

	if (fieldNode)
	{
		const ThI8* keytype = ThXmlArchiveReaderUtils::GetKeyTypeName(fieldNode);
		const ThI8* valuetype = ThXmlArchiveReaderUtils::GetValueTypeName(fieldNode);
		ConversionCheckResult checkKey = IsBaseTypeConvertibleTo(keytype, keyType->GetName());
		ConversionCheckResult checkValue = IsBaseTypeConvertibleTo(valuetype, valueType->GetName());
		ThXmlArchiveReaderUtils::LogConversionInfo(fieldNode, name, checkKey);
		ThXmlArchiveReaderUtils::LogConversionInfo(fieldNode, name, checkValue);

		if (checkKey.m_IsConvertible && checkValue.m_IsConvertible)
		{
			PushNode(m_CurrentSubcontainerNode);
			m_CurrentSubcontainerNode = fieldNode;
			size = ThXmlArchiveReaderUtils::GetSize(fieldNode);
			return true;
		}
	}

	return false;
}

void ThXmlArchiveReader::ReadEndMapField(const ThI8* name, const ThiType* keyType, const ThiType* valueType)
{
	m_CurrentSubcontainerNode = PopNode();
}

void ThXmlArchiveReader::ReadBeginEntity(const ThiEntity* entity, const ThUUID& uuid)
{
	m_DeserializedEntities.Insert(entity, true);
	m_DeserializedEntitiesById.Insert(uuid.Get(), const_cast<ThiEntity*>(entity));

	PushNode(m_CurrentContainerNode);

	m_CurrentContainerNode = ThXmlArchiveReaderUtils::FindEntityNode(m_EntitiesRootNode, uuid);

	if (!m_CurrentContainerNode)
		ThXmlArchiveReaderUtils::LogEntityNotFound(uuid);
}

void ThXmlArchiveReader::ReadEndEntity(const ThiEntity* entity)
{
	m_CurrentContainerNode = PopNode();
}

ThBool ThXmlArchiveReader::ReadBeginSubentity(const ThI8* entityType)
{
	xml_node* subentityRoot = ThXmlArchiveReaderUtils::FindSubcontainerNode(m_CurrentContainerNode, entityType, "Subentity");
	
	if (subentityRoot)
	{
		PushNode(m_CurrentSubcontainerNode);
		m_CurrentSubcontainerNode = subentityRoot;
		return true;
	}

	return false;
}

void ThXmlArchiveReader::ReadEndSubentity(const ThI8* entityType)
{
	m_CurrentSubcontainerNode = PopNode();
}

ThiEntity* ThXmlArchiveReader::ReadReferenceField(const ThI8* name, const ThiType* refType, ThUUID& uuid)
{
	return ThXmlArchiveReaderUtils::ReadReferenceField(this, name, "RefField", refType, uuid);
}

ThiEntity* ThXmlArchiveReader::ReadWeakReferenceField(const ThI8* name, const ThiType* refType, ThUUID& uuid)
{
	return ThXmlArchiveReaderUtils::ReadReferenceField(this, name, "WeakRefField", refType, uuid);
}

ThBool ThXmlArchiveReader::ReadEnumField(const ThI8* name, const ThI8* enumType, ThU32& value)
{
	xml_node* fieldNode = ThXmlArchiveReaderUtils::FindFieldNode(m_CurrentSubcontainerNode, "Field", name);

	if (fieldNode)
	{
		const ThI8* typeName = ThXmlArchiveReaderUtils::GetTypeName(fieldNode);

		if (!strcmp(typeName, enumType))
		{
			if(!ThStringUtilities::Parse(ThXmlArchiveReaderUtils::GetValue(fieldNode, "Value"), value))
			{
				ThXmlArchiveReaderUtils::LogParseFailedInfo(fieldNode, name);
			}
			else
			{
				return true;
			}
		}
		else
		{
			ThXmlArchiveReaderUtils::LogInvalidEnumTypeInfo(fieldNode, name);
		}
	}

	return false;
}

ThBool ThXmlArchiveReader::IsEntityDeserialized(const ThiEntity* entity)
{
	return m_DeserializedEntities.Find(const_cast<ThiEntity*>(entity)) != m_DeserializedEntities.End();
}

}