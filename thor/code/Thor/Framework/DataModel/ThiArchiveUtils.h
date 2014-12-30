#pragma once

#include <Thor/Framework/DataModel/ThiArchiveReader.h>
#include <Thor/Framework/DataModel/ThiArchiveWriter.h>

namespace Thor
{

struct ThiArchiveUtils
{
	template <class EntityT, class ArchiveT>
	static ThRefPtr<EntityT> LoadSingleEntity(ArchiveT& archive, ThiDataStreamPtr stream)
	{
		ThRefPtr<EntityT> result;

		ThVector<ThiEntityPtr> ent;
		archive.Load(ent, stream);

		if (ent.Size() == 1)
		{
			result = TypeCast<EntityT>(ent[0].GetPtr());
		}

		return result;
	}

	template <class EntityT, class ArchiveT>
	static ThBool SaveSingleEntity(ThRefPtr<EntityT> entity, ArchiveT& archive, ThiDataStreamPtr stream)
	{
		ThVector<ThiEntityPtr> entities;
		entities.PushBack(entity);
		archive.Save(entities, stream);
		return true;
	}
};

}