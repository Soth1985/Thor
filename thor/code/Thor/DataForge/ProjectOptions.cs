using System;
using System.IO;
using System.Collections.Generic;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using Antlr.StringTemplate;
using Antlr.StringTemplate.Language;

namespace Thor.DataForge
{

public enum eRealType
{
    Float,
    Double
}

/**
<summary> This class is responsible for parsing project files. </summary>
*/
public class ProjectOptions
{
    private HashSet<string> m_Files;
    private HashSet<string> m_Includes;
    private HashSet<string> m_Defines;
    private string m_OutputDir;
    private string m_FilenamePostfix = string.Empty;
    private eRealType m_RealType;
    private eRuntimeKind m_RuntimeKind = eRuntimeKind.DualBuffer;

    /**
    <summary> Initializes require class fields. </summary>
    */
    private void Init()
    {
        m_Files = new HashSet<string>();
        m_Includes = new HashSet<string>();
        m_Defines = new HashSet<string>();
        m_OutputDir = null;
        m_RealType = eRealType.Float;
    }

    /**
    <summary> Files to be parsed by the <see cref="Compiler"></see>. </summary>
    */
    public HashSet<string> Files
    {
        get
        {
            return m_Files;
        }
    }

    /**
    <summary> Paths to seek for files included with "import" keyword. </summary>
    */
    public HashSet<string> Includes
    {
        get
        {
            return m_Includes;
        }
    }

    /**
    <summary> Defined symbols which are used by the "profile" option. </summary>
    */
    public HashSet<string> Defines
    {
        get
        {
            return m_Defines;
        }
    }

    /**
    <summary> Path where the <see cref="Compiler"></see> output will be generated. </summary>
    */
    public string OutputDir
    {
        get
        {
            return m_OutputDir;
        }

        set
        {
            m_OutputDir = value;
        }
    }

    public string FilenamePostfix
    {
        get
        {
            return m_FilenamePostfix;
        }

        set
        {
            m_FilenamePostfix = value;
        }
    }

    public eRuntimeKind RuntimeKind
    {
        get
        {
            return m_RuntimeKind;
        }

        set
        {
            m_RuntimeKind = value;
        }
    }

    /**
    <summary> How to interpret "real" type, as float or as double. </summary>
    */
    public eRealType RealType
    {
        get
        {
            return m_RealType;
        }

        set
        {
            m_RealType = value;
        }
    }

    /**
        <summary> Parses project file. </summary>     
     *  <param name="path"> Path to the project. </param>
    */
    public void Parse(string path)
    {
        Init();

        try
        {
            Utilities.Log.WriteLine("Loading project " + path);
            ICharStream input = new ANTLRFileStream(path);
            Parse(input);
            Utilities.Log.WriteLine("Done");
        }
        catch (Exception e)
        {
            Utilities.Log.PrintExceptionInfo(e);
        }

    }

    private void Parse(ICharStream input)
    {
        try
        {
            DataForgeProjectLexer lex = new DataForgeProjectLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lex);
            DataForgeProjectParser parser = new DataForgeProjectParser(tokens);
            parser.data = this;
            parser.project();
            PostProcess();
        }
        catch (RecognitionException re)
        {
            Utilities.Log.PrintExceptionInfo(re);
        }
        catch (Exception e)
        {
            Utilities.Log.PrintExceptionInfo(e);
        }
    }

    private void PostProcess()
    {
        
    }
}

}