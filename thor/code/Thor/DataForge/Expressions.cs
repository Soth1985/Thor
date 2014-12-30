using System;
using System.IO;
using System.Collections.Generic;

namespace Thor.DataForge
{

public abstract class Expression:Symbol
{
    public abstract bool Evaluate();
}

public class ValueExpression:Expression
{
    private SymbolConstant m_Constant;

    public SymbolConstant Constant
    {
        get
        {
            return m_Constant;
        }

        set
        {
            m_Constant = value;
        }
    }

    public override bool Evaluate()
    {
        bool result = Compiler.Instance.Options.Defines.Contains(m_Constant.Name);

        if (m_Constant.UnaryOp == eUnaryOp.LogicNot)
            result = !result;

        return result;
    }
}

public class ExpressionRoot : Expression
{
    private Expression m_Root;

    public Expression Root
    {
        get
        {
            return m_Root;
        }

        set
        {
            m_Root = value;
        }
    }

    public override bool Evaluate()
    {
        return Root.Evaluate();
    }
}

public abstract class BinaryExpression:Expression
{
    Expression m_Leaf1;
    Expression m_Leaf2;   

    public Expression Leaf1
    {
        get
        {
            return m_Leaf1;
        }

        set
        {
            m_Leaf1 = value;
        }
    }

    public Expression Leaf2
    {
        get
        {
            return m_Leaf2;
        }

        set
        {
            m_Leaf2 = value;
        }
    }
}

public class AndExpression:BinaryExpression
{
    public override bool Evaluate()
    {
        return Leaf1.Evaluate() && Leaf2.Evaluate();
    }
}

public class OrExpression : BinaryExpression
{
    public override bool Evaluate()
    {
        return Leaf1.Evaluate() || Leaf2.Evaluate();
    }
}

}