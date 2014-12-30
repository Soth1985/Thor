using System;
using System.IO;
using System.Collections.Generic;

namespace Thor.DataForge
{

public enum eRuntimeKind
{
    Simple,
    SimpleThreadSafe,
    DualBuffer
}

public abstract class Option: Symbol
{
    public string Name
    {
        get
        {
            return Text;
        }
    }
}

public abstract class GenericOption<T> : Option
{
    private T m_Value;

    public T Value
    {
        get
        {
            return m_Value;
        }

        set
        {
            m_Value = value;
        }
    }
}

public class SerializableOption : GenericOption<bool>
{
    //
}

public class ReplicatedOption : GenericOption<bool>
{
    //
}

public class DirectAccessOption : GenericOption<bool>
{
    //
}

public class CommitBufferOption : GenericOption<int>
{
    //
}

public class MutexOption : GenericOption<int>
{
    //
}

public class ProfileOption : Option
{
    private Expression m_Expression;

    public Expression Expr
    {
        get
        {
            return m_Expression;
        }

        set
        {
            m_Expression = value;
        }
    }
}

public class RuntimeKindOption : GenericOption<eRuntimeKind> 
{

}

public class NoSerializeOption : Option
{

}

}