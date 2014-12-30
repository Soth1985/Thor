using System;
using System.IO;
using System.Collections.Generic;
using Antlr.Runtime;

namespace Thor.DataForge
{
/**
        <summary> Enumerates supported data types. </summary>
*/
public enum eType
{
    TYPESBEGIN,

    BOOL,
	
    FPTYPESBEGIN,
    FLOAT,
	DOUBLE,
	REAL,
    FPTYPESEND,

    INTEGERTYPESBEGIN,
    INT64,
    INT32,
	INT16,
	INT8,
    UINT64,
	UINT32,
	UINT16,
	UINT8,
    INTEGERTYPESEND,

	STRING,
    CSTRING,

    BASICTYPESEND,
		
	VEC2,
	VEC3,
	VEC4,	
	MAT2X2,
	MAT3X3,
	MAT4X4,
	QUAT,
	
	VEC2F,
	VEC3F,
	VEC4F,	
	MAT2X2F,
	MAT3X3F,
	MAT4X4F,
	QUATF,
	
	VEC2D,
	VEC3D,
	VEC4D,	
	MAT2X2D,
	MAT3X3D,
	MAT4X4D,
	QUATD,

    BUILTINTYPESEND,

    MAP,
    LIST,
    REF,
    WEAKREF,
    CUSTOM
}

/**
        <summary> This class is used to track the location of the language constructs. </summary>
*/
public abstract class Symbol
{
    private IToken m_Token = null;
    private string m_File = null;
    private Package m_Package = null;

    public Symbol()
    {
        m_File = Compiler.Instance.CurrentFile;
        m_Package = Compiler.Instance.CurrentPackage;
    }

    public Package Package
    {
        get
        {
            return m_Package;
        }
    }

    /**
        <summary> Symbol`s token. </summary>
    */
    public IToken Token
    {
        get
        {
            return m_Token;
        }

        set
        {
            m_Token = value;
        }
    }

    /**
        <summary> Token text. </summary>
    */
    public string Text
    {
        get
        {
            return m_Token.Text;
        }
    }

    /**
        <summary> File line where this symbol is located. </summary>
    */
    public int Line
    {
        get
        {
            return m_Token.Line;
        }
    }

    /**
        <summary> Name of the file where this symbol resides. </summary>
    */
    public string FileName
    {
        get
        {
            return m_File;
        }
    }
}

/**
        <summary> Represents simple built in types and acts as a base class for more complex types. </summary>
*/
public class BaseType: Symbol
{
    private eType   m_Type = eType.CUSTOM;
    private string m_PackageNameQualifier = string.Empty;

    /**
        <summary> Types`s description. </summary>
    */
    public eType Type
    {
        get
        {
            return m_Type;
        }

        set
        {
            m_Type = value;
        }
    }

    /**
        <summary> Type name. </summary>
    */
    public string Name
    {
        get
        {
            return this.Text;
        }
    }

    public string PackageNameQualifier
    {
        get
        {
            return m_PackageNameQualifier;
        }

        set
        {
            if (m_PackageNameQualifier == string.Empty)
                m_PackageNameQualifier = value;
            else
                m_PackageNameQualifier = m_PackageNameQualifier + "." + value;
        }
    }

    public string FullName
    {
        get 
        {
            if (m_PackageNameQualifier == string.Empty)
                return Name;
            else
                return PackageNameQualifier + "." + Name;
        }
    }

    public string FullNameCPP
    {
        get 
        {
            return FullName.Replace(".", "::");
        }
    }

    /**
        <summary> Returns true if this is a built in type. </summary>
    */
    public bool IsBuiltIn
    {
        get
        {
            return m_Type < eType.BUILTINTYPESEND;
        }
    }
}

/**
    <summary> Represents map type. </summary>
*/
public class MapType: BaseType
{
    private BaseType    m_KeyType;
    private BaseType    m_ValueType;

    public MapType()
    {
        this.Type = eType.MAP;
    }

    /**
        <summary> Type of the map`s key. </summary>
    */
    public BaseType KeyType
    {
        get
        {
            return m_KeyType;
        }

        set
        {
            m_KeyType = value;
            Compiler.Instance.CheckSupportedMapKeyType(this);
        }
    }

    /**
        <summary> Type of the map`s value. </summary>
    */
    public BaseType ValueType
    {
        get
        {
            return m_ValueType;
        }

        set
        {
            m_ValueType = value;
        }
    }
}

/**
        <summary> Represents list type. </summary>
*/
public class ListType : BaseType
{
    private BaseType m_ContainedType;

    public ListType()
    {
        this.Type = eType.LIST;
    }

    /**
        <summary> Type of the items contained in the list. </summary>
    */
    public BaseType ContainedType
    {
        get
        {
            return m_ContainedType;
        }

        set
        {
            m_ContainedType = value;
        }
    }
}

/**
        <summary> Represents ref type. </summary>
*/
public class RefType : BaseType
{
    private BaseType m_ContainedType;

    public RefType()
    {
        this.Type = eType.REF;
    }

    /**
        <summary> Referenced type. </summary>
    */
    public BaseType ContainedType
    {
        get
        {
            return m_ContainedType;
        }

        set
        {
            m_ContainedType = value;
        }
    }
}

public class WeakRefType : BaseType
{
    private BaseType m_ContainedType;

    public WeakRefType()
    {
        this.Type = eType.WEAKREF;
    }

    /**
        <summary> Referenced type. </summary>
    */
    public BaseType ContainedType
    {
        get
        {
            return m_ContainedType;
        }

        set
        {
            m_ContainedType = value;
        }
    }
}

/**
        <summary> Represents a data item contained inside a struct, field or entity. </summary>
*/
public class DataField : Symbol
{
    private BaseType        m_Type;
    private Initializer     m_Initializer;
    private List<Option>    m_Options;

    /**
        <summary> Name of the field. </summary>
    */
    public string Name
    {
        get
        {
            return this.Text;
        }
    }

    /**
        <summary> Type of the field. </summary>
    */
    public BaseType Type
    {
        get
        {
            return m_Type;
        }

        set
        {
            m_Type = value;
        }
    }

    /**
        <summary> Initial value of the field. </summary>
    */
    public Initializer Initter
    {
        get
        {
            return m_Initializer;
        }

        set
        {
            m_Initializer = value;
        }
    }

    /**
        <summary> Options assigned to this field. </summary>
    */
    public List<Option> Options
    {
        get
        {
            return m_Options;
        }

        set
        {
            m_Options = value;
        }
    }

    public bool IsBuiltIn
    {
        get
        {
            return m_Type.IsBuiltIn;
        }
    }

    public eType TypeEnum
    {
        get
        {
            return Type.Type;
        }
    }
}

}