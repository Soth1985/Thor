#include <Thor/Framework/ThiSystemWindow.h>

namespace Thor
{

THOR_REG_TYPE(ThiSystemWindow, THOR_TYPELIST_1(ThiObject));	
//----------------------------------------------------------------------------------------
//
//					TheFailedToCreateWindow
//
//----------------------------------------------------------------------------------------
TheFailedToCreateWindow::TheFailedToCreateWindow()
	:
ThException("Failed to create a system window")
{
	//
}

}