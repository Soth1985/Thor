using System;
using System.IO;
using System.Collections.Generic;


namespace Thor.DataForge
{

public enum eUnaryOp
{
    LogicNot,
    Negate,
    Unknown
}

public interface IConstant
{
    void ApplyUnaryOp(eUnaryOp op);
}

public abstract class SimpleConstant<T>: BaseType, IConstant
{
    protected T m_Value;

    void IConstant.ApplyUnaryOp(eUnaryOp op)
    {
        ApplyUnaryOp(op);
    }

    protected virtual void ApplyUnaryOp(eUnaryOp op)
    {
        Compiler.Instance.InvalidUnaryOp(op, Token);
        throw new Exception("Unary operation not supported");
    }

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

    public string ValueText
    {
        get
        {
            return Value.ToString();
        }
    }
}

public class Int32Constant:SimpleConstant<Int32>
{
    public Int32Constant()
    {
        Type = eType.INT32;
    }

    protected override void ApplyUnaryOp(eUnaryOp op)
    {
        if (op == eUnaryOp.Negate)
            m_Value = -m_Value;
        else
            base.ApplyUnaryOp(op);
    }
}

public class DoubleConstant : SimpleConstant<double>
{
    public DoubleConstant()
    {
        Type = eType.DOUBLE;
    }

    protected override void ApplyUnaryOp(eUnaryOp op)
    {
        if (op == eUnaryOp.Negate)
            m_Value = -m_Value;
        else
            base.ApplyUnaryOp(op);
    }
}

public class BoolConstant : SimpleConstant<bool>
{
    public BoolConstant()
    {
        Type = eType.BOOL;
    }

    protected override void ApplyUnaryOp(eUnaryOp op)
    {
        if (op == eUnaryOp.LogicNot)
            m_Value = !m_Value;
        else
            base.ApplyUnaryOp(op);
    }
}

public class StringConstant: SimpleConstant<string>
{
    public StringConstant()
    {
        Type = eType.STRING;
    }
}

public class EnumConstant : BaseType, IConstant
{
    private string  m_TextVal;

    void IConstant.ApplyUnaryOp(eUnaryOp op)
    {
        Compiler.Instance.InvalidUnaryOp(op, Token);
        throw new Exception("Unary operation not supported");
    }

    public string EnumName
    {
        get
        {
            return Text;
        }
    }

    public string TextVal
    {
        get
        {
            return m_TextVal;
        }

        set
        {
            m_TextVal = value;
        }
    }
}

public class SymbolConstant : BaseType, IConstant
{
    private eUnaryOp m_UnaryOp = eUnaryOp.Unknown;

    void IConstant.ApplyUnaryOp(eUnaryOp op)
    {
        m_UnaryOp = op;
    }

    public string SymbolName
    {
        get
        {
            return Text;
        }
    }

    public eUnaryOp UnaryOp
    {
        get
        {
            return m_UnaryOp;
        }
    }
}

}