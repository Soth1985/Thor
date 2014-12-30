#pragma once

#include <Thor/Framework/FrameworkFwd.h>
#include <Thor/Protocol/ThFrameworkProtocol/ThFrameworkProtocol.h>

namespace Thor
{
//----------------------------------------------------------------------------------------
//
//					ThiWorld
//
//----------------------------------------------------------------------------------------
class THOR_FRAMEWORK_DLL ThiWorld: public ThiRtti
{
public:

	virtual ThFrameworkRootEntity*		GetRootEntity() = 0;

	template <class T>
	ThRefPtr<T> CreateEntity()
	{
		T* entity = new T();
		OnEntityCreated(entity);
		return entity;
	}

protected:

	friend class ThiEntity; 

	virtual void OnEntityCreated(ThiEntity* entity) = 0;
};

}