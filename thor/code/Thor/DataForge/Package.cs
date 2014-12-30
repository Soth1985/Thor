using System;
using System.IO;
using System.Collections.Generic;
using Antlr.StringTemplate;

namespace Thor.DataForge
{

/**
   <summary> Represents a package in the target language and contains the data types declared there. </summary>
*/
public class Package
{
    /**
        <summary> Parent of this package, if null - means this is the root. </summary>
    */
    private Package         m_Parent = null;    

    /**
        <summary> Children packages. </summary>
    */
    private List<Package>   m_Children = new List<Package>();    
    private string          m_Name = string.Empty;

    private Dictionary<string, DataField>           m_Constants = new Dictionary<string, DataField>();
    private Dictionary<string, EnumDeclaration>     m_Enumerations = new Dictionary<string, EnumDeclaration>();
    private Dictionary<string, StructDeclaration>   m_Structures = new Dictionary<string, StructDeclaration>();
    private Dictionary<string, EntityDeclaration>   m_Entities = new Dictionary<string, EntityDeclaration>();

    public Package()
    {
        //
    }

    public Package(Package parent, string name)
    {
        m_Parent = parent;
        m_Name = name;       
    }

    /**
        <summary> Fully qualified name of the package. </summary>
    */
    public string Name
    {
        get
        {
            return m_Name;
        }
    }

    public string NameCPP
    {
        get 
        {
            return m_Name.Replace(".", "::");
        }
    }

    public string[] NameSplit
    {
        get 
        {
            return m_Name.Split(new char[]{'.'}, StringSplitOptions.RemoveEmptyEntries);
        }
    }

    /**
        <summary> Constants defined inside this package. </summary>
    */
    public Dictionary<string, DataField> Constants
    {
        get
        {
            return m_Constants;
        }
    }

    /**
        <summary> Used to add an appropriate data structure into the package and to report duplicate declarations. </summary>
    */
    public void AddConstant(DataField c)
    {
        try
        {
            m_Constants.Add(c.Name, c);
        }
        catch (System.ArgumentException)
        {
            Compiler.Instance.DuplicateConstant(c);
        }
    }

    /**
        <summary> Enumerations defined inside this package. </summary>
    */
    public Dictionary<string, EnumDeclaration> Enumerations
    {
        get
        {
            return m_Enumerations;
        }
    }

    /**
        <summary> Used to add an appropriate data structure into the package and to report duplicate declarations. </summary>
    */
    public void AddEnumeration(EnumDeclaration d)
    {
        try
        {
            m_Enumerations.Add(d.Name, d);
        }
        catch (System.ArgumentException)
        {
            Compiler.Instance.DuplicateEnumeration(d);
        }
    }

    /**
        <summary> Structures defined inside this package. </summary>
    */
    public Dictionary<string, StructDeclaration> Structures
    {
        get
        {
            return m_Structures;
        }
    }

    /**
        <summary> Used to add an appropriate data structure into the package and to report duplicate declarations. </summary>
    */
    public void AddStructure(StructDeclaration d)
    {
        try
        {
            m_Structures.Add(d.Name, d);
        }
        catch (System.ArgumentException)
        {
            Compiler.Instance.DuplicateStructure(d);
        }
    }

    /**
        <summary> Entities defined inside this package. </summary>
    */
    public Dictionary<string, EntityDeclaration> Entities
    {
        get
        {
            return m_Entities;
        }
    }

    /**
        <summary> Used to add an appropriate data structure into the package and to report duplicate declarations. </summary>
    */
    public void AddEntity(EntityDeclaration d)
    {
        try
        {
            m_Entities.Add(d.Name, d);
        }
        catch (System.ArgumentException)
        {
            Compiler.Instance.DuplicateEntity(d);
        }
    }

    /**
        <summary> Looks for a child package with the specified full name (does not seek for it in the children of the children). </summary>
    */
    private Package FindChildPackage(string name)
    {
        return m_Children.Find( n => n.Name == name );
    }

    /**
        <summary> Adds a new child package, including intermediate packages. </summary>
     *  <example> AddChildPackage("a","b","c") will create a chain of packages
     *  root->a->b->c; if any of the a,b,c packages existed before they will not
     *  be created anew
     *  </example>
     *  <param name="nameParts"> Parts of the package name("a","b","c" in case of package a.b.c). </param>
    */
    public Package AddChildPackage(List<string> nameParts)
    {
        if (m_Parent != null)
            throw new Exception("AddChildPackage should be invoked only by the root package");

        if (nameParts.Count == 0)
            throw new Exception("Empty package name");

        Package result = AddPackage(null, nameParts);
        
        return result;
    }

    /**
       <see cref="AddChildPackage"> </see>
     * <param name="prevPackageName"> Contains the concatenated parts of previously processed packages. </param>
    */
    private Package AddPackage(string prevPackageName, List<string> nameParts)
    {
        string name = null;
        //build package name
        if (prevPackageName == null)
            name = nameParts[0];
        else
        {
            name = prevPackageName + "." + nameParts[0];
        }

        Package result = FindChildPackage(name);

        //package does not exist -> create it
        if (result == null)
        {
            result = new Package(this, name);
            m_Children.Add(result);
        }

        if (nameParts.Count > 1)
            result = result.AddPackage(name, nameParts.GetRange(1, nameParts.Count - 1));

        return result;
    }

    private GeneratedFileDesc GetGeneratedFile(StringTemplateGroup group, string fileName)
    {
        GeneratedFileDesc desc = Compiler.Instance.GetGeneratedFileDesc(fileName);

        if (!desc.IsInitialized)
        {
            desc.Init(group, NameSplit, fileName);

            var importedFiles = Compiler.Instance.GetImportedFiles(fileName);

            if (importedFiles != null)
            {
                foreach (var i in importedFiles)
                {
                    if (i.Item2)
                        desc.AddHeader(i.Item1);
                }
            }
        }

        return desc;
    }

    private void GenerateEntityStructCode<T>(CompoundTypeDeclaration<T> decl, StringTemplateGroup group)
    {
        if (!decl.IsCodeGenerated)
        {
            if (decl.Parent != null && decl.Parent.Package == this)
            {
                GenerateEntityStructCode(decl.Parent, group);
            }

            decl.IsCodeGenerated = true;

            if (decl.Header != null && decl.Source != null)
            {
                GeneratedFileDesc desc = GetGeneratedFile(group, decl.FileName);
                StringTemplate forwardDeclaration = group.GetInstanceOf("forwardDeclaration");
                forwardDeclaration.SetAttribute("name", decl.FullNameCPP);

                if (decl as EntityDeclaration != null)
                    forwardDeclaration.SetAttribute("isEntity", true);

                desc.Header.SetAttribute("forwardDeclarations", forwardDeclaration);
                desc.Header.SetAttribute("declarations", decl.Header);
                AddRttiDeclaration(group, desc, decl);
                desc.Source.SetAttribute("declarations", decl.Source);
            }            
        }        
    }

    private void AddRttiDeclaration(StringTemplateGroup group, GeneratedFileDesc desc, BaseType t)
    {
        EnumDeclaration ed = t as EnumDeclaration;

        if (ed == null)
        {
            StringTemplate rttiDeclatation = group.GetInstanceOf("rttiDeclaration");
            rttiDeclatation.SetAttribute("package", t.Package.NameCPP);
            rttiDeclatation.SetAttribute("name", t.Name);
            desc.Header.SetAttribute("rttiDeclarations", rttiDeclatation);

            StructDeclaration sd = t as StructDeclaration;

            if (sd == null)
            {
                StringTemplate deserializationConstructor = group.GetInstanceOf("deserializationConstructor");
                deserializationConstructor.SetAttribute("package", t.Package.NameCPP);
                deserializationConstructor.SetAttribute("name", t.Name);
                desc.Header.SetAttribute("deserializationConstructors", deserializationConstructor);
            }            
        }
        else
        {
            StringTemplate rttiDeclatation = group.GetInstanceOf("rttiDeclaration");
            rttiDeclatation.SetAttribute("package", t.Package.NameCPP);
            rttiDeclatation.SetAttribute("name", t.Name);
            desc.Header.SetAttribute("rttiDeclarations", rttiDeclatation);
            rttiDeclatation = group.GetInstanceOf("rttiDeclaration");
            rttiDeclatation.SetAttribute("package", t.Package.NameCPP);
            rttiDeclatation.SetAttribute("name", t.Name + "Simple");
            desc.Header.SetAttribute("rttiDeclarations", rttiDeclatation);
            rttiDeclatation = group.GetInstanceOf("rttiDeclaration");
            rttiDeclatation.SetAttribute("package", t.Package.NameCPP);
            rttiDeclatation.SetAttribute("name", t.Name + "SimpleThreadSafe");
            desc.Header.SetAttribute("rttiDeclarations", rttiDeclatation);
        }
        
    }

    public void GenerateCode(StringTemplateGroup group)
    {
        foreach (var enumeration in Enumerations)
        {
            GeneratedFileDesc desc = GetGeneratedFile(group, enumeration.Value.FileName);
            desc.Header.SetAttribute("declarations", enumeration.Value.Header);
            desc.Source.SetAttribute("declarations", enumeration.Value.Source);
            AddRttiDeclaration(group, desc, enumeration.Value);
        }

        foreach (var st in Structures)
        {
            GenerateEntityStructCode(st.Value, group);
        }

        foreach (var entity in Entities)
        {
            GenerateEntityStructCode(entity.Value, group);
        }

        foreach (var p in m_Children)
        {
            p.GenerateCode(group);
        }
    }

    public void GenerateTemplates(StringTemplateGroup group)
    {
        try
        {
            foreach (var enumeration in Enumerations)
            {
                enumeration.Value.GenerateTemplates(this, group);
            }

            foreach (var entity in Entities)
            {
                entity.Value.GenerateTemplates(this, group);
            }

            foreach (var st in Structures)
            {
                st.Value.GenerateTemplates(this, group);
            }

            foreach (var child in m_Children)
            {
                child.GenerateTemplates(group);
            }
        }
        catch (CompileException ex)
        {
            Utilities.Log.WriteLine("Aborting compilation");
        }       
    }

    private bool ProcessTypeName(string typeName, out string packageQualifier, out string name)
    {
        int idx = typeName.LastIndexOf('.');
        packageQualifier = string.Empty;
        name = string.Empty;

        if (idx != -1)
        {
            packageQualifier = typeName.Substring(0, idx);
            name = typeName.Substring(idx + 1);

            if (packageQualifier != m_Name)
                return false;
        }
        else
        {
            name = typeName;
        }

        return true;
    }

    public DataField FindConstant(string constantName)
    {
        string packageQualifier;
        string name;

        if (!ProcessTypeName(constantName, out packageQualifier, out name))
            return null;

        DataField constant = null;

        if (m_Constants.TryGetValue(name, out constant))
            return constant;

        return null;
    }

    public DataField FindConstantUp(string constantName)
    {
        DataField result = FindConstant(constantName);

        if (result == null && m_Parent != null)
            result = m_Parent.FindConstantUp(constantName);

        return result;
    }

    public DataField FindConstantDown(string constantName)
    {
        DataField result = FindConstant(constantName);

        if (result == null)
        {
            foreach (var p in m_Children)
            {
                result = p.FindConstantUp(constantName);

                if (result != null)
                    break;
            }
        }

        return result;
    }

    public BaseType FindSymbol(string typeName)
    {
        string packageQualifier;
        string name;

        if (!ProcessTypeName(typeName, out packageQualifier, out name))
            return null;

        EnumDeclaration ed = null;

        if(Enumerations.TryGetValue(name, out ed))
            return ed;

        StructDeclaration sd = null;

        if(Structures.TryGetValue(name, out sd))
            return sd;

        EntityDeclaration entd = null;

        if(Entities.TryGetValue(name, out entd))
            return entd;

        return null;
    }

    public BaseType FindSymbolUp(string typeName)
    {
        BaseType result = FindSymbol(typeName);

        if (result == null && m_Parent != null)
            result = m_Parent.FindSymbolUp(typeName);

        return result;
    }

    public BaseType FindSymbolDown(string typeName)
    {
        BaseType result = FindSymbol(typeName);

        if (result == null)
        {
            foreach (var p in m_Children)
            {
                result = p.FindSymbolDown(typeName);

                if (result != null)
                    break;
            }
        }

        return result;
    }

    public BaseType FindSymbolUpDown(string typeName)
    {
        BaseType result = FindSymbol(typeName);

        if (result == null && m_Parent != null)
            result = m_Parent.FindSymbolUp(typeName);

        if (result == null)
        {
            foreach (var p in m_Children)
            {
                result = p.FindSymbolDown(typeName);

                if (result != null)
                    break;
            }
        }

        return result;
    }

    public void Preprocess()
    {
        try
        {
            foreach (var s in Structures)
            {
                s.Value.Preprocess();
            }

            foreach (var e in Entities)
            {
                e.Value.Preprocess();
            }

            foreach (var p in m_Children)
                p.Preprocess();
        }
        catch (CompileException ex)
        {
            Utilities.Log.WriteLine("Aborting compilation");
        }        
    }
}

}