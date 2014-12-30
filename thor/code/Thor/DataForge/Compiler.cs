using System;
using System.IO;
using System.Collections.Generic;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using Antlr.StringTemplate;
using Antlr.StringTemplate.Language;

namespace Thor.DataForge
{

public enum eCompilerMessageSeverity
{
    Error,
    Warning
}

public class CompileException : Exception
{
    public CompileException(string message)
        : base(message)
    {

    }
}

public class Compiler
{
    private ProjectOptions      m_Options;
    private Package             m_RootPackage;
    private Package             m_CurrentPackage;
    private Stack<string>       m_ParsedFilesStack;
    private List<string>        m_ParsedFiles;
    private static Compiler     m_Instance = new Compiler();
    private bool                m_StageFailed;
    private StringTemplateGroup m_StringTemplateGroup;
    private Dictionary<string, List<Tuple<string, bool>>> m_ImportMap = new Dictionary<string, List<Tuple<string, bool>>>();
    private Dictionary<string, GeneratedFileDesc> m_GeneratedFiles = new Dictionary<string, GeneratedFileDesc>(); 

    private Compiler()
    {
        m_Options = new ProjectOptions();
        m_RootPackage = new Package();
        m_CurrentPackage = m_RootPackage;
        m_ParsedFilesStack = new Stack<string>();
        m_ParsedFiles = new List<string>();
        m_StageFailed = false;
    }

    public List<Tuple<string, bool>> GetImportedFiles(string target)
    {
        List<Tuple<string, bool>> result = null;

        if (m_ImportMap.TryGetValue(target, out result))
            return result;
        else
            return null;
    }

    public GeneratedFileDesc GetGeneratedFileDesc(string name)
    {
        GeneratedFileDesc desc = null;

        if (!m_GeneratedFiles.TryGetValue(name, out desc))
        {
            desc = new GeneratedFileDesc();
            m_GeneratedFiles.Add(name, desc);
        }

        return desc;
    }

    public bool IsFileInImports(string target, string file)
    {
        if (target == file)
            return true;

        List<Tuple<string, bool>> flist = null;

        if (m_ImportMap.TryGetValue(target, out flist))
        {
            if (flist.Find(it => it.Item1 == GetFilePath(file)) != null)
                return true;
        }

        return false;
    }

    public void AddImportedFile(string target, string path, bool inFileScope = true)
    {
        path = Path.GetFullPath(path);
        AddImportedFileImpl(target, path, inFileScope);

        List<Tuple<string, bool>> files= null;

        if (m_ImportMap.TryGetValue(path, out files))
        {
            foreach (var f in files)
            {
                AddImportedFile(target, f.Item1, false);
            }
        }
    }

    private void AddImportedFileImpl(string target, string path, bool inFileScope)
    {
        List<Tuple<string, bool>> files = null;

        if (m_ImportMap.TryGetValue(target, out files))
        {
            if (files.Find(it => it.Item1 == path) == null)
                files.Add(new Tuple<string, bool>(path, inFileScope));
        }
        else
        {
            files = new List<Tuple<string, bool>>();
            files.Add(new Tuple<string, bool>(path, inFileScope));
            m_ImportMap.Add(target, files);
        }
    }

    public static Compiler Instance
    {
        get
        {
            return m_Instance;
        }
    }

    public void LoadTemplateGroup(string path)
    {
        string template = File.ReadAllText(path);
        m_StringTemplateGroup = new StringTemplateGroup(new StringReader(template));
    }

    //Compiler errors and checkers
    public void WriteErrorFileLine(eCompilerMessageSeverity sev, IToken token)
    {
        if (sev == eCompilerMessageSeverity.Error)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.White;
        }

        m_StageFailed = true;

        if (token != null)
            Utilities.Log.WriteLine(sev + " -> file: " + CurrentFile + " line: " + token.Line);

        Console.ResetColor();
    }

    public void WriteErrorFileLine(eCompilerMessageSeverity sev, Symbol sym)
    {
        if (sev == eCompilerMessageSeverity.Error)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.White;
        }

        m_StageFailed = true;

        if (sym != null)
            Utilities.Log.WriteLine(sev + " -> file: " + sym.FileName + " line: " + sym.Line);

        Console.ResetColor();
    }

    public void InvalidConstantType(DataField val)
    {
        WriteErrorFileLine(eCompilerMessageSeverity.Error, val.Token);
        Utilities.Log.WriteLine("\tConstant can only be of a built in type. Invalid type " + val.Name + ".");
    }

    public void InvalidEnumValuesOrder(IToken token)
    {
        WriteErrorFileLine(eCompilerMessageSeverity.Error, token);
        Utilities.Log.WriteLine("\tEnumerations must declare their values in ascending order, token: " + token.Text + ".");
    }

    public void InvalidUnaryOp(eUnaryOp op, IToken token)
    {
        WriteErrorFileLine(eCompilerMessageSeverity.Error, token);
        Utilities.Log.WriteLine("\tUnary operation " + op + " cannot be applied to this type.");
    }

    public void InvalidProfileExpression(IToken token)
    {
        WriteErrorFileLine(eCompilerMessageSeverity.Error, token);
        Utilities.Log.WriteLine("\tProfile option expressions can only use symbolic values as its operands (something like SYM).");
    }

    public void CheckProfileExpression(Expression expr, IToken token)
    {
        if(expr==null)
        {
            InvalidProfileExpression(token);
        }
    }

    public void DuplicateEnumField(EnumDeclaration e, string fieldName)
    {
        WriteErrorFileLine(eCompilerMessageSeverity.Error, e.Token);
        Utilities.Log.WriteLine("\tEnum " + e.Name + " contains duplicate fields named " + fieldName + ".");
    }

    public void DuplicateDataField<T>(CompoundTypeDeclaration<T> decl, DataField field)
    {
        WriteErrorFileLine(eCompilerMessageSeverity.Error, field.Token);
        Utilities.Log.WriteLine("\tData type " + decl.Name + " contains duplicate fields named " + field.Name + ".");
    }

    public void DuplicateConstant(DataField field)
    {
        WriteErrorFileLine(eCompilerMessageSeverity.Error, field.Token);
        Utilities.Log.WriteLine("\tConstant " + field.Name + " is already declared.");
    }

    public void DuplicateEnumeration(EnumDeclaration decl)
    {
        WriteErrorFileLine(eCompilerMessageSeverity.Error, decl.Token);
        Utilities.Log.WriteLine("\tEnumeration " + decl.Name + " is already declared.");
    }

    public void DuplicateStructure(StructDeclaration decl)
    {
        WriteErrorFileLine(eCompilerMessageSeverity.Error, decl.Token);
        Utilities.Log.WriteLine("\tStructure " + decl.Name + " is already declared.");
    }

    public void DuplicateEntity(EntityDeclaration decl)
    {
        WriteErrorFileLine(eCompilerMessageSeverity.Error, decl.Token);
        Utilities.Log.WriteLine("\tEntity " + decl.Name + " is already declared.");
    }
    ///
    public void TypeNotFound(BaseType type)
    {
        WriteErrorFileLine(eCompilerMessageSeverity.Error, type);
        Utilities.Log.WriteLine("\tType " + type.FullName + " is not found in current scope.");
    }

    public void TypeNotInProfile(BaseType type)
    {
        WriteErrorFileLine(eCompilerMessageSeverity.Error, type);
        Utilities.Log.WriteLine("\tType " + type.FullName + " is not found in current scope, it is defined but not in the current compilation profile.");
    }

    public void EntityFieldDeclared(BaseType type, BaseType field)
    {
        WriteErrorFileLine(eCompilerMessageSeverity.Error, type);
        Utilities.Log.WriteLine("\tType " + type.FullName + " has an entity field of type " + field.Name + ", only references to entities are allowed.");
    }

    public void TypeNotImported(BaseType type, string file)
    {
        WriteErrorFileLine(eCompilerMessageSeverity.Error, type);
        Utilities.Log.WriteLine("\tType " + type.FullName + " is defined in " + type.FileName + " but not imported in " + file + ".");
    }

    public void EntityNotFound(EntityDeclaration type)
    {
        WriteErrorFileLine(eCompilerMessageSeverity.Error, type);
        Utilities.Log.WriteLine("\tEntity " + type.Parent.FullName + " does not exist.");
    }

    public void StructureNotFound(StructDeclaration type)
    {
        WriteErrorFileLine(eCompilerMessageSeverity.Error, type);
        Utilities.Log.WriteLine("\tStructure " + type.Parent.FullName + " does not exist.");
    }

    public void CheckConstantType(DataField val)
    {
        if (!val.Type.IsBuiltIn)
        {
            InvalidConstantType(val);
        }
    }

    public void InvalidFieldInitializer(DataField field, int numRequiredConstants)
    {
        WriteErrorFileLine(eCompilerMessageSeverity.Error, field.Type);
        Utilities.Log.WriteLine("\tField " + field.Name + " has invalid number of constants in it`s initializer, expecting " + numRequiredConstants + ".");
    }

    public void InitializerNotSupported(DataField field)
    {
        WriteErrorFileLine(eCompilerMessageSeverity.Error, field.Type);
        Utilities.Log.WriteLine("\tField " + field.Name + " cannot have initializers.");
    }

    public void EnumHasNoSuchValue(DataField field, EnumDeclaration ed, string val)
    {
        WriteErrorFileLine(eCompilerMessageSeverity.Error, field.Type);
        Utilities.Log.WriteLine("\tField " + field.Name + " references value " + val + " which enum " + ed.FullName + " does not have.");
    }
    
    public void InvalidEnumInitializer(DataField field)
    {
        WriteErrorFileLine(eCompilerMessageSeverity.Error, field.Type);
        Utilities.Log.WriteLine("\tField " + field.Name + " has invalid enum initializer.");
    }

    public void ConstantNotFound(SymbolConstant cnt)
    {
        WriteErrorFileLine(eCompilerMessageSeverity.Error, cnt);
        Utilities.Log.WriteLine("\tConstant " + cnt.Name + " is not found in current scope.");
    }

    public void FileNotFound(string fileName)
    {
        WriteErrorFileLine(eCompilerMessageSeverity.Error, (IToken)null);
        Utilities.Log.WriteLine("\tFile " + fileName + " does not exist.");
    }

    public void CheckSupportedMapKeyType(MapType map)
    {
        if (map.KeyType.Type > eType.BASICTYPESEND)
        {
            WriteErrorFileLine(eCompilerMessageSeverity.Error, map.Token);
            Utilities.Log.WriteLine("\tMap field " + map.Name + " has unsupported key value, only basic types can be map keys.");
        }
    }

    public Package CurrentPackage
    {
        get
        {
            return m_CurrentPackage;
        }

        set
        {
            m_CurrentPackage = value;
        }
    }

    public Package RootPackage
    {
        get
        {
            return m_RootPackage;
        }
    }

    public string CurrentFile
    {
        get
        {
            return m_ParsedFilesStack.Peek();
        }
    }

    public ProjectOptions Options
    {
        get
        {
            return m_Options;
        }
    }

    public void ParseFile(string fileName)
    {
        try
        {
            fileName = GetFilePath(fileName);

            if (m_ParsedFiles.Contains(fileName))
                return;

            m_ParsedFiles.Add(fileName);

            //init state
            Package prevPackage = m_CurrentPackage;
            m_ParsedFilesStack.Push(fileName);
            //parse file            
            ICharStream input = new ANTLRFileStream(fileName);
            DataForgeLexer lex = new DataForgeLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lex);
            DataForgeParser parser = new DataForgeParser(tokens);
            Utilities.Log.WriteLine("Parsing file " + fileName);
            parser.compiler = this;
            parser.translation_unit();
            if (parser.Failed())
                m_StageFailed = true;
            Utilities.Log.WriteLine("Done " + fileName);
            //restore state
            m_ParsedFilesStack.Pop();//remove file name from the stack used to report filename in error messages
            m_CurrentPackage = prevPackage;
        }
        catch (RecognitionException re)
        {
            WriteErrorFileLine(eCompilerMessageSeverity.Error, re.Token);
            Utilities.Log.WriteLine("Parsing error, last token " + re.Token);
            Utilities.Log.PrintExceptionInfo(re);
        }
        catch (Exception e)
        {
            m_StageFailed = true;
            Utilities.Log.PrintExceptionInfo(e);
        }
    }

    private void SetupRealTypeTables()
    {
        if (m_Options.RealType == eRealType.Float)
        {
            var valueTypeMap = m_StringTemplateGroup.GetMap("valueTypeMap");
            var typeMapDualBuffer = m_StringTemplateGroup.GetMap("typeMapDualBuffer");
            var typeMapSimple = m_StringTemplateGroup.GetMap("typeMapSimple");
            var typeMapSimpleThreadSafe = m_StringTemplateGroup.GetMap("typeMapSimpleThreadSafe");
            var defaultValues = m_StringTemplateGroup.GetMap("defaultValues");

            valueTypeMap["real"] = "ThF32";
            typeMapDualBuffer["real"] = "ThF32Field";
            typeMapSimple["real"] = "ThF32SimpleField";
            typeMapSimpleThreadSafe["real"] = "ThF32SimpleFieldThreadSafe";
            defaultValues["real"] = "0.0f";

            valueTypeMap["vec2"] = "ThVec2";
            typeMapDualBuffer["vec2"] = "ThVec2Field";
            typeMapSimple["vec2"] = "ThVec2SimpleField";
            typeMapSimpleThreadSafe["vec2"] = "ThVec2SimpleFieldThreadSafe";

            valueTypeMap["vec3"] = "ThVec3";
            typeMapDualBuffer["vec3"] = "ThVec3Field";
            typeMapSimple["vec3"] = "ThVec3SimpleField";
            typeMapSimpleThreadSafe["vec3"] = "ThVec3SimpleFieldThreadSafe";

            valueTypeMap["vec4"] = "ThVec4";
            typeMapDualBuffer["vec4"] = "ThVec4Field";
            typeMapSimple["vec4"] = "ThVec4SimpleField";
            typeMapSimpleThreadSafe["vec4"] = "ThVec4SimpleFieldThreadSafe";

            valueTypeMap["mat2x2"] = "ThMat2x2";
            typeMapDualBuffer["mat2x2"] = "ThMat2x2Field";
            typeMapSimple["mat2x2"] = "ThMat2x2SimpleField";
            typeMapSimpleThreadSafe["mat2x2"] = "ThMat2x2SimpleFieldThreadSafe";

            valueTypeMap["mat3x3"] = "ThMat3x3";
            typeMapDualBuffer["mat3x3"] = "ThMat3x3Field";
            typeMapSimple["mat3x3"] = "ThMat3x3SimpleField";
            typeMapSimpleThreadSafe["mat3x3"] = "ThMat3x3SimpleFieldThreadSafe";

            valueTypeMap["mat4x4"] = "ThMat4x4";
            typeMapDualBuffer["mat4x4"] = "ThMat4x4Field";
            typeMapSimple["mat4x4"] = "ThMat4x4SimpleField";
            typeMapSimpleThreadSafe["mat4x4"] = "ThMat4x4SimpleFieldThreadSafe";

            valueTypeMap["quat"] = "ThQuat";
            typeMapDualBuffer["quat"] = "ThQuatField";
            typeMapSimple["quat"] = "ThQuatSimpleField";
            typeMapSimpleThreadSafe["quat"] = "ThQuatSimpleFieldThreadSafe";
        }
        else if (m_Options.RealType == eRealType.Double)
        {
            var valueTypeMap = m_StringTemplateGroup.GetMap("valueTypeMap");
            var typeMapDualBuffer = m_StringTemplateGroup.GetMap("typeMapDualBuffer");
            var typeMapSimple = m_StringTemplateGroup.GetMap("typeMapSimple");
            var typeMapSimpleThreadSafe = m_StringTemplateGroup.GetMap("typeMapSimpleThreadSafe");
            var defaultValues = m_StringTemplateGroup.GetMap("defaultValues");

            valueTypeMap["real"] = "ThF64";
            typeMapDualBuffer["real"] = "ThF64Field";
            typeMapSimple["real"] = "ThF64SimpleField";
            typeMapSimpleThreadSafe["real"] = "ThF64SimpleFieldThreadSafe";
            defaultValues["real"] = "0.0";

            valueTypeMap["vec2"] = "ThVec2d";
            typeMapDualBuffer["vec2"] = "ThVec2dField";
            typeMapSimple["vec2"] = "ThVec2dSimpleField";
            typeMapSimpleThreadSafe["vec2"] = "ThVec2dSimpleFieldThreadSafe";

            valueTypeMap["vec3"] = "ThVec3d";
            typeMapDualBuffer["vec3"] = "ThVec3dField";
            typeMapSimple["vec3"] = "ThVec3dSimpleField";
            typeMapSimpleThreadSafe["vec3"] = "ThVec3dSimpleFieldThreadSafe";

            valueTypeMap["vec4"] = "ThVec4d";
            typeMapDualBuffer["vec4"] = "ThVec4dField";
            typeMapSimple["vec4"] = "ThVec4dSimpleField";
            typeMapSimpleThreadSafe["vec4"] = "ThVec4dSimpleFieldThreadSafe";

            valueTypeMap["mat2x2"] = "ThMat2x2d";
            typeMapDualBuffer["mat2x2"] = "ThMat2x2dField";
            typeMapSimple["mat2x2"] = "ThMat2x2dSimpleField";
            typeMapSimpleThreadSafe["mat2x2"] = "ThMat2x2dSimpleFieldThreadSafe";

            valueTypeMap["mat3x3"] = "ThMat3x3d";
            typeMapDualBuffer["mat3x3"] = "ThMat3x3dField";
            typeMapSimple["mat3x3"] = "ThMat3x3dSimpleField";
            typeMapSimpleThreadSafe["mat3x3"] = "ThMat3x3dSimpleFieldThreadSafe";

            valueTypeMap["mat4x4"] = "ThMat4x4d";
            typeMapDualBuffer["mat4x4"] = "ThMat4x4dField";
            typeMapSimple["mat4x4"] = "ThMat4x4dSimpleField";
            typeMapSimpleThreadSafe["mat4x4"] = "ThMat4x4dSimpleFieldThreadSafe";

            valueTypeMap["quat"] = "ThQuatd";
            typeMapDualBuffer["quat"] = "ThQuatdField";
            typeMapSimple["quat"] = "ThQuatdSimpleField";
            typeMapSimpleThreadSafe["quat"] = "ThQuatdSimpleFieldThreadSafe";
        }
    }

    public void BuildProject(string projectName)
    {
        m_Options.Parse(projectName);

        SetupRealTypeTables();

        foreach(var f in m_Options.Files)
        {
            try
            {
                ParseFile(f);               
            }
            catch(Exception e)
            {
                Utilities.Log.PrintExceptionInfo(e);
            }
        }
       
        if(!m_StageFailed)
        {
            RootPackage.Preprocess();
            RootPackage.GenerateTemplates(m_StringTemplateGroup);
        }
        else
        {
            Utilities.Log.WriteLine("Parsing stage failed, compilation can not continue");
            return;
        }

        if (!m_StageFailed)
        {
            RootPackage.GenerateCode(m_StringTemplateGroup);

            foreach (var gen in m_GeneratedFiles)
            {
                gen.Value.WriteFiles();
            }
        }
        else
        {
            Utilities.Log.WriteLine("Template generation stage failed, compilation can not continue.");
            return;
        }

        if (!m_StageFailed)
        {
            Utilities.Log.WriteLine("Compilation succedeed.");
        }
    }

    public string GetFilePath(string filePath)
    {
        string fullPath = Path.GetFullPath(filePath);

        if (File.Exists(fullPath))
            return fullPath;
       
        foreach (var inc in m_Options.Includes)
        {
            fullPath = Path.Combine(inc, filePath);

            if (File.Exists(fullPath))
                return fullPath;
        }

        FileNotFound(filePath);

        return null;
    }
}

}