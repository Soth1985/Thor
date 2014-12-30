using System;
using System.IO;
using System.Collections.Generic;
using Antlr.StringTemplate;
using Antlr.StringTemplate.Language;
using Thor.DataForge;

public class GeneratedFileDesc
{
    private StringTemplate m_Header = null;
    private StringTemplate m_Source = null;
    private string m_LibHeader = string.Empty;
    private string m_LibMacros = string.Empty;
    private string m_HeaderPath = string.Empty;
    private string m_SourcePath = string.Empty;
    private string m_OriginalFilePath = string.Empty;
    private bool m_IsInitialized = false;

    public void WriteFiles()
    {
        if (m_Header != null && m_Source != null)
        {
            string h = m_Header.ToString();
            string cpp = m_Source.ToString();

            File.WriteAllText(m_HeaderPath, h);
            File.WriteAllText(m_SourcePath, cpp);
        }
        else
        {
            Utilities.Log.WriteLine("No definitions found, no code is generated");
        }
        
    }

    public bool IsInitialized
    {
        get
        {
            return m_IsInitialized;
        }
    }

    public StringTemplate Header
    {
        get
        {
            return m_Header;
        }
    }

    public StringTemplate Source
    {
        get
        {
            return m_Source;
        }
    }

    public string LibHeader
    {
        get
        {
            return m_LibHeader;
        }

        set
        {
            m_LibHeader = value;
        }
    }

    public string LibMacros
    {
        get
        {
            return m_LibMacros;
        }

        set
        {
            m_LibMacros = value;
        }
    }

    public void Init(StringTemplateGroup group, string[] packageName, string fileName)
    {
        m_OriginalFilePath = fileName;

        m_Header = group.GetInstanceOf("header");
        m_Source = group.GetInstanceOf("source");

        for (int i = 0; i < packageName.Length; ++i)
        {
            m_Header.SetAttribute("name", packageName[i]);
            m_Source.SetAttribute("name", packageName[i]);
        }

        m_HeaderPath = Utilities.GetRelativePath(fileName, Directory.GetCurrentDirectory(), "h");
        m_SourcePath = Utilities.GetRelativePath(fileName, Directory.GetCurrentDirectory(), "cpp");

        m_HeaderPath = AddPostfix(m_HeaderPath);
        m_SourcePath = AddPostfix(m_SourcePath);

        m_Source.SetAttribute("includes", Utilities.GetRelativePath(Path.GetFullPath(m_HeaderPath), GetFullDirectoryName(m_SourcePath), "h"));

        if (m_LibHeader != string.Empty)
            m_Header.SetAttribute("includes", m_LibHeader);

        m_IsInitialized = true;
    }

    private string GetFullDirectoryName(string path)
    {
        string fullPath = Path.GetFullPath(path);
        return Path.GetDirectoryName(fullPath);
    }

    public void AddHeader(string path)
    {
        m_Header.SetAttribute("includes", Utilities.AddQuotes(Utilities.GetRelativePath(path, GetFullDirectoryName(m_HeaderPath), "h")));
    }

    private string AddPostfix(string filePath)
    {
        if (Compiler.Instance.Options.FilenamePostfix != string.Empty)
        {
            string dir = Path.GetDirectoryName(filePath);
            string name = Path.GetFileNameWithoutExtension(filePath) + Compiler.Instance.Options.FilenamePostfix;
            string ext = Path.GetExtension(filePath);

            if (dir.Length > 0)
                filePath = dir + "\\" + name + ext;
            else
                filePath = name + ext;
        }

        return filePath;
    }
}