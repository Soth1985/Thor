#pragma once

#include <Thor/ThorMath/FixedVector.h>
#include <Thor/ThorMath/FixedMatrix.h>
#include <Thor/ThorMath/Quaternion.h>
#include <Thor/Framework/DataModel/ThiField.h>
#include <Thor/Framework/DataModel/ThFieldTraits.h>

namespace Thor
{

namespace Private
{
	template<class T>
	class ThiDualBufferField : public ThiFieldProxy<true>
	{
	public:

		typedef T ValueType;

		operator T()
		{
			return GetValue();
		}

		ThiDualBufferField()
		{
			m_Flags.SetFlag(true, Private::eFieldFlags::IsDefaultValue);
		}

		ThiDualBufferField(const T& value)
			:
		m_Value(value)
		{
			m_Flags.SetFlag(true, Private::eFieldFlags::IsDefaultValue);
		}

		ThiDualBufferField(const ThiDualBufferField& other)
			:
		ThiFieldProxy<true>(other),
		m_Value(other.m_Value)
		{
			
		}

		const ThiDualBufferField& operator=(const ThiDualBufferField& other)
		{
			SetValue(other.GetValue());
			return *this;
		}

		const ThiDualBufferField& operator=(const T& other)
		{
			SetValue(other);
			return *this;
		}

		ThBool operator==(const T& other)const
		{
			return m_Value == other;
		}

		ThBool operator!=(const T& other)const
		{
			return m_Value != other;
		}

		ThBool operator==(const ThiDualBufferField& other)const
		{
			return m_Value == other.GetValue();
		}

		ThBool operator!=(const ThiDualBufferField& other)const
		{
			return m_Value != other.GetValue();
		}

		void SetValue(const T& value)
		{
			ScopedLock lock;
			InitScopedLock(lock);

			SetDirty(true);
			m_NewValue = value;
		}

		const T& GetValue()const
		{
			return m_Value;
		}

		THOR_DM_VIRTUAL ThiType*		GetType()const
		{
			return ThType< ThiDualBufferField<T> >::Instance();
		}

		THOR_DM_VIRTUAL void Serialize(ThiArchiveWriter* archive, const ThI8* fieldName)const
		{
			archive->WriteField(fieldName, m_Value);
		}

		THOR_DM_VIRTUAL void Deserialize(ThiArchiveReader* archive, const ThI8* fieldName)
		{
			if (archive->ReadField(fieldName, m_Value))
				SetIsDefault(false);
		}

		ThBool IsDirty()const
		{
			return m_Flags.CheckFlag(Private::eFieldFlags::IsDirty);
		}

		ThBool IsDefaultValue()const
		{
			return m_Flags.CheckFlag(Private::eFieldFlags::IsDefaultValue);
		}

	protected:

		void SetDirty(ThBool val)
		{
			m_Flags.SetFlag(val, Private::eFieldFlags::IsDirty);
			m_Flags.SetFlag(false, Private::eFieldFlags::IsDefaultValue);
		}

		void SetIsDefault(ThBool val)
		{
			m_Flags.SetFlag(val, Private::eFieldFlags::IsDefaultValue);
		}

		THOR_DM_VIRTUAL void Push()
		{
			if (IsDirty())
			{
				m_Value = m_NewValue;
				SetDirty(false);
			}
		}
	private:

	#ifdef THOR_DM_THIFIELD_NOVIRTUALS
		friend struct Private::ThiFieldInternalAccess;
	#endif

		ThFlags8 m_Flags;
		T m_Value;
		T m_NewValue;
	};

	template<class T, bool ThreadSafe = false>
	class ThiSimpleField : public ThiFieldProxy<ThreadSafe>
	{
	public:

		typedef T ValueType;

		operator T()
		{
			return GetValue();
		}

		ThiSimpleField()
		{

		}

		ThiSimpleField(const T& value)
			:
		m_Value(value)
		{

		}

		ThiSimpleField(const ThiSimpleField& other)
			:
		ThiFieldProxy<ThreadSafe>(other),
		m_Value(other.m_Value)
		{
			
		}

		const ThiSimpleField& operator=(const ThiSimpleField& other)
		{
			SetValue(other.GetValue());
			return *this;
		}

		const ThiSimpleField& operator=(const T& other)
		{
			SetValue(other);
			return *this;
		}

		ThBool operator==(const T& other)const
		{
			return m_Value == other;
		}

		ThBool operator!=(const T& other)const
		{
			return m_Value != other;
		}

		ThBool operator==(const ThiSimpleField& other)const
		{
			return m_Value == other.GetValue();
		}

		ThBool operator!=(const ThiSimpleField& other)const
		{
			return m_Value != other.GetValue();
		}

		void SetValue(const T& value)
		{
			//SetDirty(true);
			ScopedLock lock;
			InitScopedLock(lock);

			m_Value = value;
		}

		const T& GetValue()const
		{
			ScopedLock lock;
			InitScopedLock(lock);

			return m_Value;
		}

		THOR_DM_VIRTUAL ThiType*		GetType()const
		{
			return ThType< ThiDualBufferField<T> >::Instance();
		}

		THOR_DM_VIRTUAL void Serialize(ThiArchiveWriter* archive, const ThI8* fieldName)const
		{
			archive->WriteField(fieldName, m_Value);
		}

		THOR_DM_VIRTUAL void Deserialize(ThiArchiveReader* archive, const ThI8* fieldName)
		{
			archive->ReadField(fieldName, m_Value);
		}

		ThBool IsDirty()const
		{
			return true;
		}

		ThBool IsDefaultValue()const
		{
			return false;
		}

	protected:

		THOR_DM_VIRTUAL void Push()
		{
			//SetDirty(false);
		}

	private:
		
	#ifdef THOR_DM_THIFIELD_NOVIRTUALS
		friend struct Private::ThiFieldInternalAccess;
	#endif

		T m_Value;
	};
}

typedef Private::ThiDualBufferField<ThI64>	ThI64Field;
typedef Private::ThiDualBufferField<ThI32>	ThI32Field;
typedef Private::ThiDualBufferField<ThI16>	ThI16Field;
typedef Private::ThiDualBufferField<ThI8>	ThI8Field;
typedef Private::ThiDualBufferField<ThU64>	ThU64Field;
typedef Private::ThiDualBufferField<ThU32>	ThU32Field;
typedef Private::ThiDualBufferField<ThU16>	ThU16Field;
typedef Private::ThiDualBufferField<ThU8>	ThU8Field;
typedef Private::ThiDualBufferField<ThF32>	ThF32Field;
typedef Private::ThiDualBufferField<ThF64>	ThF64Field;
typedef Private::ThiDualBufferField<ThBool>  ThBoolField;
typedef Private::ThiDualBufferField<ThVec2>	ThVec2Field;
typedef Private::ThiDualBufferField<ThVec3>	ThVec3Field;
typedef Private::ThiDualBufferField<ThVec4>	ThVec4Field;
typedef Private::ThiDualBufferField<ThVec2d>	ThVec2dField;
typedef Private::ThiDualBufferField<ThVec3d>	ThVec3dField;
typedef Private::ThiDualBufferField<ThVec4d>	ThVec4dField;
typedef Private::ThiDualBufferField<ThMat2x2>	ThMat2x2Field;
typedef Private::ThiDualBufferField<ThMat3x3>	ThMat3x3Field;
typedef Private::ThiDualBufferField<ThMat4x4>	ThMat4x4Field;
typedef Private::ThiDualBufferField<ThMat2x2d>	ThMat2x2dField;
typedef Private::ThiDualBufferField<ThMat3x3d>	ThMat3x3dField;
typedef Private::ThiDualBufferField<ThMat4x4d>	ThMat4x4dField;
typedef Private::ThiDualBufferField<ThQuat>	ThQuatField;
typedef Private::ThiDualBufferField<ThQuatd>	ThQuatdField;
typedef Private::ThiDualBufferField<ThU16String> ThU16StringField;
typedef Private::ThiDualBufferField<ThString> ThStringField;
typedef Private::ThiDualBufferField<ThWideString> ThWideStringField;

//simple fields
typedef Private::ThiSimpleField<ThI64, false>	ThI64SimpleField;
typedef Private::ThiSimpleField<ThI32, false>	ThI32SimpleField;
typedef Private::ThiSimpleField<ThI16, false>	ThI16SimpleField;
typedef Private::ThiSimpleField<ThI8, false>	ThI8SimpleField;
typedef Private::ThiSimpleField<ThU64, false>	ThU64SimpleField;
typedef Private::ThiSimpleField<ThU32, false>	ThU32SimpleField;
typedef Private::ThiSimpleField<ThU16, false>	ThU16SimpleField;
typedef Private::ThiSimpleField<ThU8, false>	ThU8SimpleField;
typedef Private::ThiSimpleField<ThF32, false>	ThF32SimpleField;
typedef Private::ThiSimpleField<ThF64, false>	ThF64SimpleField;
typedef Private::ThiSimpleField<ThBool, false> ThBoolSimpleField;
typedef Private::ThiSimpleField<ThVec2, false>	ThVec2SimpleField;
typedef Private::ThiSimpleField<ThVec3, false>	ThVec3SimpleField;
typedef Private::ThiSimpleField<ThVec4, false>	ThVec4SimpleField;
typedef Private::ThiSimpleField<ThVec2d, false>	ThVec2dSimpleField;
typedef Private::ThiSimpleField<ThVec3d, false>	ThVec3dSimpleField;
typedef Private::ThiSimpleField<ThVec4d, false>	ThVec4dSimpleField;
typedef Private::ThiSimpleField<ThMat2x2, false>	ThMat2x2SimpleField;
typedef Private::ThiSimpleField<ThMat3x3, false>	ThMat3x3SimpleField;
typedef Private::ThiSimpleField<ThMat4x4, false>	ThMat4x4SimpleField;
typedef Private::ThiSimpleField<ThMat2x2d, false>	ThMat2x2dSimpleField;
typedef Private::ThiSimpleField<ThMat3x3d, false>	ThMat3x3dSimpleField;
typedef Private::ThiSimpleField<ThMat4x4d, false>	ThMat4x4dSimpleField;
typedef Private::ThiSimpleField<ThQuat, false>	ThQuatSimpleField;
typedef Private::ThiSimpleField<ThQuatd, false>	ThQuatdSimpleField;
typedef Private::ThiSimpleField<ThU16String, false> ThU16StringSimpleField;
typedef Private::ThiSimpleField<ThString, false> ThStringSimpleField;
typedef Private::ThiSimpleField<ThWideString, false> ThWideStringSimpleField;

//simple fields thread safe
typedef Private::ThiSimpleField<ThI64, true>	ThI64SimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThI32, true>	ThI32SimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThI16, true>	ThI16SimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThI8, true>	ThI8SimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThU64, true>	ThU64SimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThU32, true>	ThU32SimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThU16, true>	ThU16SimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThU8, true>	ThU8SimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThF32, true>	ThF32SimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThF64, true>	ThF64SimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThBool, true> ThBoolSimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThVec2, true>	ThVec2SimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThVec3, true>	ThVec3SimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThVec4, true>	ThVec4SimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThVec2d, true>	ThVec2dSimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThVec3d, true>	ThVec3dSimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThVec4d, true>	ThVec4dSimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThMat2x2, true>	ThMat2x2SimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThMat3x3, true>	ThMat3x3SimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThMat4x4, true>	ThMat4x4SimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThMat2x2d, true>	ThMat2x2dSimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThMat3x3d, true>	ThMat3x3dSimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThMat4x4d, true>	ThMat4x4dSimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThQuat, true>	ThQuatSimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThQuatd, true>	ThQuatdSimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThU16String, true> ThU16StringSimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThString, true> ThStringSimpleFieldThreadSafe;
typedef Private::ThiSimpleField<ThWideString, true> ThWideStringSimpleFieldThreadSafe;

THOR_DECL_TYPE(Thor::ThI64Field);
THOR_DECL_TYPE(Thor::ThI32Field);
THOR_DECL_TYPE(Thor::ThI16Field);
THOR_DECL_TYPE(Thor::ThI8Field);
THOR_DECL_TYPE(Thor::ThU64Field);
THOR_DECL_TYPE(Thor::ThU32Field);
THOR_DECL_TYPE(Thor::ThU16Field);
THOR_DECL_TYPE(Thor::ThU8Field);
THOR_DECL_TYPE(Thor::ThF32Field);
THOR_DECL_TYPE(Thor::ThF64Field);
THOR_DECL_TYPE(Thor::ThBoolField);
THOR_DECL_TYPE(Thor::ThU16StringField);
THOR_DECL_TYPE(Thor::ThStringField);
THOR_DECL_TYPE(Thor::ThWideStringField);
THOR_DECL_TYPE(Thor::ThVec2Field);
THOR_DECL_TYPE(Thor::ThVec3Field);
THOR_DECL_TYPE(Thor::ThVec4Field);
THOR_DECL_TYPE(Thor::ThVec2dField);
THOR_DECL_TYPE(Thor::ThVec3dField);
THOR_DECL_TYPE(Thor::ThVec4dField);
THOR_DECL_TYPE(Thor::ThMat2x2Field);
THOR_DECL_TYPE(Thor::ThMat3x3Field);
THOR_DECL_TYPE(Thor::ThMat4x4Field);
THOR_DECL_TYPE(Thor::ThMat2x2dField);
THOR_DECL_TYPE(Thor::ThMat3x3dField);
THOR_DECL_TYPE(Thor::ThMat4x4dField);
THOR_DECL_TYPE(Thor::ThQuatField);
THOR_DECL_TYPE(Thor::ThQuatdField);

template <class T>
struct ThFieldTraits< Private::ThiDualBufferField<T> >
{
	typedef Private::ThiDualBufferField<T> FieldType;
	typedef T ValueType;
	enum eSort{ListSortEnabled = 1};
};

template <class T, bool ThreadSafe>
struct ThFieldTraits< Private::ThiSimpleField<T, ThreadSafe> >
{
	typedef Private::ThiDualBufferField<T> FieldType;
	typedef T ValueType;
	enum eSort{ListSortEnabled = 1};
};

template <>
struct ThFieldTraits< Private::ThiDualBufferField<ThMat2x2> >
{
	typedef Private::ThiDualBufferField<ThMat2x2> FieldType;
	typedef ThMat2x2 ValueType;
	enum eSort{ListSortEnabled = 0};
};

template <>
struct ThFieldTraits< Private::ThiDualBufferField<ThMat2x2d> >
{
	typedef Private::ThiDualBufferField<ThMat2x2d> FieldType;
	typedef ThMat2x2d ValueType;
	enum eSort{ListSortEnabled = 0};
};

template <>
struct ThFieldTraits< Private::ThiDualBufferField<ThMat3x3> >
{
	typedef Private::ThiDualBufferField<ThMat3x3> FieldType;
	typedef ThMat3x3 ValueType;
	enum eSort{ListSortEnabled = 0};
};

template <>
struct ThFieldTraits< Private::ThiDualBufferField<ThMat3x3d> >
{
	typedef Private::ThiDualBufferField<ThMat3x3d> FieldType;
	typedef ThMat3x3d ValueType;
	enum eSort{ListSortEnabled = 0};
};

template <>
struct ThFieldTraits< Private::ThiDualBufferField<ThMat4x4> >
{
	typedef Private::ThiDualBufferField<ThMat4x4> FieldType;
	typedef ThMat4x4 ValueType;
	enum eSort{ListSortEnabled = 0};
};

template <>
struct ThFieldTraits< Private::ThiDualBufferField<ThMat4x4d> >
{
	typedef Private::ThiDualBufferField<ThMat4x4d> FieldType;
	typedef ThMat4x4d ValueType;
	enum eSort{ListSortEnabled = 0};
};

//SimpleField
template <>
struct ThFieldTraits< Private::ThiSimpleField<ThMat2x2, false> >
{
	typedef Private::ThiDualBufferField<ThMat2x2> FieldType;
	typedef ThMat2x2 ValueType;
	enum eSort{ListSortEnabled = 0};
};

template <>
struct ThFieldTraits< Private::ThiSimpleField<ThMat2x2d, false> >
{
	typedef Private::ThiDualBufferField<ThMat2x2d> FieldType;
	typedef ThMat2x2d ValueType;
	enum eSort{ListSortEnabled = 0};
};

template <>
struct ThFieldTraits< Private::ThiSimpleField<ThMat3x3, false> >
{
	typedef Private::ThiDualBufferField<ThMat3x3> FieldType;
	typedef ThMat3x3 ValueType;
	enum eSort{ListSortEnabled = 0};
};

template <>
struct ThFieldTraits< Private::ThiSimpleField<ThMat3x3d, false> >
{
	typedef Private::ThiDualBufferField<ThMat3x3d> FieldType;
	typedef ThMat3x3d ValueType;
	enum eSort{ListSortEnabled = 0};
};

template <>
struct ThFieldTraits< Private::ThiSimpleField<ThMat4x4, false> >
{
	typedef Private::ThiDualBufferField<ThMat4x4> FieldType;
	typedef ThMat4x4 ValueType;
	enum eSort{ListSortEnabled = 0};
};

template <>
struct ThFieldTraits< Private::ThiSimpleField<ThMat4x4d, false> >
{
	typedef Private::ThiDualBufferField<ThMat4x4d> FieldType;
	typedef ThMat4x4d ValueType;
	enum eSort{ListSortEnabled = 0};
};

//SimpleFieldThreadSafe
template <>
struct ThFieldTraits< Private::ThiSimpleField<ThMat2x2, true> >
{
	typedef Private::ThiDualBufferField<ThMat2x2> FieldType;
	typedef ThMat2x2 ValueType;
	enum eSort{ListSortEnabled = 0};
};

template <>
struct ThFieldTraits< Private::ThiSimpleField<ThMat2x2d, true> >
{
	typedef Private::ThiDualBufferField<ThMat2x2d> FieldType;
	typedef ThMat2x2d ValueType;
	enum eSort{ListSortEnabled = 0};
};

template <>
struct ThFieldTraits< Private::ThiSimpleField<ThMat3x3, true> >
{
	typedef Private::ThiDualBufferField<ThMat3x3> FieldType;
	typedef ThMat3x3 ValueType;
	enum eSort{ListSortEnabled = 0};
};

template <>
struct ThFieldTraits< Private::ThiSimpleField<ThMat3x3d, true> >
{
	typedef Private::ThiDualBufferField<ThMat3x3d> FieldType;
	typedef ThMat3x3d ValueType;
	enum eSort{ListSortEnabled = 0};
};

template <>
struct ThFieldTraits< Private::ThiSimpleField<ThMat4x4, true> >
{
	typedef Private::ThiDualBufferField<ThMat4x4> FieldType;
	typedef ThMat4x4 ValueType;
	enum eSort{ListSortEnabled = 0};
};

template <>
struct ThFieldTraits< Private::ThiSimpleField<ThMat4x4d, true> >
{
	typedef Private::ThiDualBufferField<ThMat4x4d> FieldType;
	typedef ThMat4x4d ValueType;
	enum eSort{ListSortEnabled = 0};
};

}