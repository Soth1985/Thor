#pragma once

#include <Thor/Framework/FrameworkFwd.h>
#include <Thor/Framework/ThDelegate.h>
#include <Thor/Framework/ThFlags.h>

namespace Thor
{
//----------------------------------------------------------------------------------------
//
//					TheFailedToCreateWindow
//
//----------------------------------------------------------------------------------------
class TheFailedToCreateWindow:public ThException
{
public:
	TheFailedToCreateWindow();
};
//----------------------------------------------------------------------------------------
//
//					eWindowStyle
//
//----------------------------------------------------------------------------------------
struct eWindowStyle
{
	enum Val
	{
		HasBorderAndCaption,
		CanvasOnly
	};
};
//----------------------------------------------------------------------------------------
//
//					eMouseButton
//
//----------------------------------------------------------------------------------------
struct eMouseButton
{
	enum Val
	{
		Right	= 1<<0,
		Middle	= 1<<1,
		Left	= 1<<2
	};
};
//----------------------------------------------------------------------------------------
//
//					eAcceleratorKey
//
//----------------------------------------------------------------------------------------
struct eAcceleratorKey
{
	enum Val
	{
		LShift	= 1<<0,
		RShift	= 1<<1,
		LAlt	= 1<<2,
		RAlt	= 1<<3,
		LCtrl	= 1<<4,
		RCtrl	= 1<<5
	};
};
//----------------------------------------------------------------------------------------
//
//					ThiSystemWindow
//
//----------------------------------------------------------------------------------------
class THOR_FRAMEWORK_DLL ThiSystemWindow:public ThiObject
{
public:	

	virtual void	Show()=0;
	virtual void	Hide()=0;
	virtual void	Minimize()=0;
	virtual void	Maximize()=0;
	virtual void	ShowCursor()=0;
	virtual void	HideCursor()=0;
	virtual void	SetCursor(const ThString& cursor)=0;
	virtual void	SetIcon(const ThString& icon)=0;
	virtual void	SetStyle(eWindowStyle::Val style)=0;
	virtual void	SetClientArea(ThF32 width, ThF32 height)=0;
	virtual void	SetWindowPos(ThF32 x, ThF32 y)=0;
	virtual void	SetCaption(const ThString& caption)=0;
	virtual ThF32	GetWidth()const=0;
	virtual ThF32	GetHeight()const=0;
	virtual ThF32	GetClientWidth()const=0;
	virtual ThF32	GetClientHeight()const=0;
	virtual void*   GetWindowHandle()const=0;

	ThDelegate<>											md_OnCreate;
	ThDelegate<>											md_OnDestroy;
	ThDelegate<>											md_OnPaint;
	ThDelegate<eMouseButton::Val, ThFlags32, ThF32, ThF32>	md_OnMouseButtonDown;// button, accelerators, x, y
	ThDelegate<eMouseButton::Val, ThFlags32, ThF32, ThF32>	md_OnMouseButtonUp;// button, accelerators, x, y
	ThDelegate<ThFlags32, ThF32, ThF32>						md_OnMouseMove;//accelerators x y
	ThDelegate<ThFlags32, ThF32, ThF32, ThF32>				md_OnMouseWheel;//accelerators delta x y
	ThDelegate<ThF32, ThF32>								md_OnSize;//width height
};

}