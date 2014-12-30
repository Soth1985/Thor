#include <Thor/Framework/ThObjectTableInternal.h>

namespace Thor
{
//----------------------------------------------------------------------------------------
//
//					ThObjectTable
//
//----------------------------------------------------------------------------------------
ThiRtti* ThObjectTable::GetObject(ThU32 handle)
{
	return ThObjectTableImpl::Instance().GetObject(handle);
}

ThU32 ThObjectTable::GetObjectHandle(const ThUUID& uuid)
{
	return ThObjectTableImpl::Instance().GetObjectHandle(uuid);
}

}