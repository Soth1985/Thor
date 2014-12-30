#include <Thor/Framework/DataModel/ThDataModel.h>
#include <Thor/Framework/FileSystem/LibFileSystem.h>
#include <Thor/Protocol/Test/TestProtocol.h>

using namespace Thor;

ThiFileSystemPtr fs = ThFileSystemFactory::Instance().CreateFileSystem( eFileSystemType::PhysFS );

void TestThListField()
{
	ThI32Field i(10);
	ThI32Field j(i);
	ThI32Field k;
	ThListSimpleField<ThI32Field> lst;
	ThListSimpleField<ThWideStringField> lst2;
	ThListSimpleField<ThListSimpleField<ThI32Field>> lst1;
	ThListSimpleField< ThListSimpleField< ThHandleField< ThiEntity > > > lst3;
	ThListSimpleField< ThMapSimpleField< ThI32Field, ThI32Field > > lst5;

	ThiType* t = lst1.GetItemFieldType();

	ThListDualBufferField<ThI32Field> lst4;

	lst4.PushBackItemValue(8);
	lst4.PushBackItemValue(9);
	lst4.PushBackItemValue(10);
	lst4.PushBackItemValue(1);
	lst4.PushBackItemValue(0);
	Private::ThiFieldInternalAccess::Push(&lst4);
	lst4.SetItemValue(0, 77);
	lst4.Erase(1);
	Private::ThiFieldInternalAccess::Push(&lst4);
	lst4.Sort();
	Private::ThiFieldInternalAccess::Push(&lst4);
}

void TestThMapField()
{
	ThMapSimpleField<ThI32Field, ThWideStringField> m1;
	ThMapSimpleField<ThStringField, ThListDualBufferField<ThI32Field> > m2;

	ThMapDualBufferField<ThStringField, ThI32Field> m3;
	ThMapDualBufferField<ThStringField, ThListDualBufferField<ThI32Field> > m4;

	m3.SetItemValue("a", 1);
	m3.SetItemValue("b", 2);
	m3.SetItemValue("b", 3);
	m3.SetItemValue("b", 4);
	m3.SetItemValue("c", 7);
	Private::ThiFieldInternalAccess::Push(&m3);
	m3.SetItemValue("a", 5);
	m3.SetItemValue("b",6);
	Private::ThiFieldInternalAccess::Push(&m3);
	m3.Erase("c");
	Private::ThiFieldInternalAccess::Push(&m3);
}

void TestXmlArchiveWrite()
{
	ThVector<ThiEntityPtr> entities;
	Test::TestEntityPtr ent = new Test::TestEntity();
	Test::TestEntity2Ptr ent2 = new Test::TestEntity2();
	Test::TestEntity2Ptr ent3 = new Test::TestEntity2();
	ent2->refTest = ent;
	ent2->weakrefTest = ent;
	ent3->refTest = ent;

	entities.PushBack(ent2);
	entities.PushBack(ent3);
	//entities.PushBack(ent);

	ThVector<int> l;
	l.PushBack(0);
	l.PushBack(1);
	l.PushBack(88);
	ent->structTest.i = 9;
	ent->structTest.l.AssignValue(l);

	ThHashMap<ThString, ThString> m;
	m["a"] = "b";
	m["e"] = "r";
	m["u"] = "t";
	m["v"] = "a";
	
	ent->mapTest.AssignValue(m);
	ent->enumTest = Test::eTestEnum::val3;
	ent->i64 = 64;
	ent->i32 = 32;
	ent->i16 = 16;
	ent->i8 = 8;
	ent->f = 2.0f;
	ent->d = 3.0;
	ent->r = 0.0f;
	ent->b = true;
	ent->cstr = "Test";
	ent->wstr = L"Тест";
	ent->v2 = ThVec2(0.0f, 1.0f);
	ent->v2d = ThVec2d(2.0, 3.0);
	ent->v2f = ThVec2(4.0f, 5.0f);

	ent->v3 = ThVec3(0.0f, 1.0f, 2.0f);
	ent->v3d = ThVec3d(3.0, 4.0, 5.0);
	ent->v3f = ThVec3(6.0f, 7.0f, 8.0f);

	ent->v4 = ThVec4(0.0f, 1.0f, 2.0f, 3.0f);
	ent->v4d = ThVec4d(4.0, 5.0, 6.0, 7.0);
	ent->v4f = ThVec4(8.0f, 9.0f, 10.0f, 11.0f);

	ent->q = ThQuat(3.0f, 2.0f, 1.0f, 0.0f);
	ent->qd = ThQuatd(2.0, 3.0, 4.0, 5.0);
	ent->qf = ThQuat(0.0f, 1.0f, 4.77f, 4.9765f);

	ent->m2x2 = ThMat2x2(0.0f, 1.0f, 2.0f, 3.0f);
	ent->m2x2d = ThMat2x2d(1.34, 1.67, 2.567, 3.88655657);
	ent->m2x2f = ThMat2x2(0.546f, 1.5767f, 2.67655f, 3.6788f);

	ent->m3x3 = ThMat3x3(0.0f, 1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f, 7.0f, 8.0f);
	ent->m3x3d = ThMat3x3d(0.0, 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0);
	ent->m3x3f = ThMat3x3(0.0f, 1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f, 7.0f, 8.0f);

	ent->m4x4 = ThMat4x4(0.0f, 1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f, 7.0f, 8.0f, 9.0f, 10.0f, 11.0f, 12.0f, 13.0f, 14.0f, 15.0f);
	ent->m4x4d = ThMat4x4d(0.0, 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0, 11.0, 12.0, 13.0, 14.0, 15.0);
	ent->m4x4f = ThMat4x4(0.0f, 1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f, 7.0f, 8.0f, 9.0f, 10.0f, 11.0f, 12.0f, 13.0f, 14.0f, 15.0f);

	Private::ThiEntityInternalAccess::Push(ent.GetPtr());
	Private::ThiEntityInternalAccess::Push(ent2.GetPtr());
	Private::ThiEntityInternalAccess::Push(ent3.GetPtr());
	
	ThiFileStreamPtr file = fs->OpenFile("test1.xml", eStreamMode::WriteMode, eFileWriteMode::Truncate);
	ThXmlArchiveWriter xmlWriter;
	xmlWriter.Save(entities, ThiDataStreamPtr(file));
}

void TestXmlArchiveRead()
{
	ThiFileStreamPtr file = fs->OpenFile("test1.xml", eStreamMode::ReadMode);
	ThXmlArchiveReader xmlReader;
	ThVector<ThiEntityPtr> entities;
	xmlReader.Load(entities, ThiDataStreamPtr(file));
}

int main()
{
	auto sz1 = sizeof ThI32SimpleField;
	auto sz2 = sizeof ThI32SimpleFieldThreadSafe;
	auto sz3 = sizeof ThI32Field;
	auto sz4 = sizeof ThListDualBufferField<ThI32Field>;
	auto sz5 = sizeof tbb::concurrent_vector<ThI32Field>;
	auto sz6 = sizeof ThMapDualBufferField<ThI32Field, ThI32Field>;
	auto sz7 = sizeof tbb::concurrent_hash_map<ThI32Field, ThI32Field>;
	auto sz8 = sizeof ThRefPtrDualBufferField<Test::TestEntity2>;
	auto sz9 = sizeof Test::TestEntity;
	//TestThMapField();
	//TestThListField();
	TestXmlArchiveWrite();
	TestXmlArchiveRead();

	return 0;
}