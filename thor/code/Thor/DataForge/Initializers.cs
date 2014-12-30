using System;
using System.IO;
using System.Collections.Generic;


namespace Thor.DataForge
{

public abstract class Initializer
{
    public abstract int Count
    {
        get;
    }

}

public class SimpleInitializer: Initializer
{
    private List<IConstant>     m_ConstantList = new List<IConstant>();

    public override int Count
    {
        get
        {
            return m_ConstantList.Count;
        }
    }

    public List<IConstant> Constants
    {
        get
        {
            return m_ConstantList;
        }
    }

    public void ApplyUnaryOp(eUnaryOp op)
    {
        foreach (var v in m_ConstantList)
        {
            v.ApplyUnaryOp(op);
        }
    }
}

public class InitializerNamed: Initializer
{
    Initializer m_Initter;
    string m_Name;

    public override int Count
    {
        get
        {
            return 1;
        }
    }

    public string Name
    {
        get
        {
            return m_Name;
        }

        set
        {
            m_Name=value;
        }
    }

    public Initializer Initter
    {
        get
        {
            return m_Initter;
        }

        set
        {
            m_Initter = value;
        }
    }
}

public class InitializerList : Initializer
{
    private List<Initializer> m_Initters = new List<Initializer>();

    public override int Count
    {
        get
        {
            return m_Initters.Count;
        }
    }

    public List<Initializer> Initters
    {
        get
        {
            return m_Initters;
        }
    }
}

}