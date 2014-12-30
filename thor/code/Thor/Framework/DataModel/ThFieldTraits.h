#pragma once

namespace Thor
{
	//----------------------------------------------------------------------------------------
	//
	//					ThListSortCompare
	//
	//----------------------------------------------------------------------------------------
	template <class T>
	struct ThFieldTraits
	{
		typedef T FieldType;
		typedef T ValueType;
		enum eSort{ListSortEnabled = 0};
	};

	//----------------------------------------------------------------------------------------
	//
	//					ThListSortCompare
	//
	//----------------------------------------------------------------------------------------
	template <class T>
	struct ThListSortCompare
	{
		ThBool operator()(const T& a, const T& b)
		{
			return a < b;
		}
	};
}