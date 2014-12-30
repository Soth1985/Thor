#pragma once

#include <Thor/Framework/FrameworkFwd.h>

namespace Thor
{

typedef ThDelegate<ThiAsyncResultPtr> ThiAsyncResultCallback;
//----------------------------------------------------------------------------------------
//
//					ThiAsyncResult
//
//----------------------------------------------------------------------------------------
class THOR_FRAMEWORK_DLL ThiAsyncResult: public ThiObject
{
public:	

	virtual ThBool IsComplete()const=0;
	virtual ThBool Cancel()=0;

};

}