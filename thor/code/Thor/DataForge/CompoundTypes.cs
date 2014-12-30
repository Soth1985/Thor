using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Antlr.StringTemplate;
using Antlr.StringTemplate.Language;
using System.Globalization;


namespace Thor.DataForge
{

public class EnumDeclaration:BaseType
{
    private Dictionary<string, int> m_Values = new Dictionary<string, int>();
    private StringTemplate m_Header;
    private StringTemplate m_Source;

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

    public Dictionary<string, int> Values
    {
        get
        {
            return m_Values;
        }
    }

    public int GetValue(string name)
    {
        int result = 0;

        if (m_Values.TryGetValue(name, out result))
            return result;
        else return -1;
    }

    public void AddValue(string name, int val)
    {
        try
        {
            m_Values.Add(name, val);
        }
        catch(System.ArgumentException)
        {
            Compiler.Instance.DuplicateEnumField(this, name);
        }
    }

    public string EnumName
    {
        get
        {
            return Text;
        }
    }

    public void GenerateTemplates(Package package, StringTemplateGroup group)
    {
        m_Header = group.GetInstanceOf("enumH");
        m_Source = group.GetInstanceOf("enumCPP");

        int i = 0;

        foreach (var item in Values)
        {
            StringTemplate enumItem = group.GetInstanceOf("enumItem");
            enumItem.SetAttribute("name", item.Key);
            enumItem.SetAttribute("value", item.Value);
            enumItem.SetAttribute("index", i);
            ++i;
            m_Header.SetAttribute("enumItems", enumItem);
            m_Source.SetAttribute("enumItems", enumItem);
        }

        m_Header.SetAttribute("name", Name);
        m_Source.SetAttribute("name", Name);
        m_Header.SetAttribute("package", package.NameCPP);
        m_Source.SetAttribute("package", package.NameCPP);

        GeneratedFileDesc desc = Compiler.Instance.GetGeneratedFileDesc(FileName);
        m_Header.SetAttribute("libMacros", desc.LibMacros);

        //string strH = enumH.ToString();
        //string strCPP = enumCPP.ToString();
    }
}

class FieldContext
{
    private bool m_IsMap;
    private bool m_IsRef;
    private bool m_IsList;

    public bool IsMap
    {
        get
        {
            return m_IsMap;
        }

        set
        {
            m_IsMap = value;
        }
    }

    public bool IsRef
    {
        get
        {
            return m_IsRef;
        }

        set
        {
            m_IsRef = value;
        }
    }

    public bool IsList
    {
        get
        {
            return m_IsList;
        }

        set
        {
            m_IsList = value;
        }
    }
}

class InitializerContext
{
    private eType m_ExpectedType1 = eType.BUILTINTYPESEND;
    private eType m_ExpectedType2 = eType.BUILTINTYPESEND;
    private StringTemplate m_Template;

    public InitializerContext(StringTemplateGroup group)
    {
        m_Template = group.GetInstanceOf("initter");
    }

    public eType ExpectedType1
    {
        get
        {
            return m_ExpectedType1;
        }

        set
        {
            m_ExpectedType1 = value;
        }
    }

    public eType ExpectedType2
    {
        get
        {
            return m_ExpectedType2;
        }

        set
        {
            m_ExpectedType2 = value;
        }
    }

    public StringTemplate Template
    {
        get 
        {
            return m_Template;
        }
    }

    public bool IsTypeExpected(eType type)
    {
        return type == ExpectedType1 || type == ExpectedType2;
    }
}

public abstract class CompoundTypeDeclaration<T> : BaseType
{
    private Dictionary<string, DataField>   m_Fields = new Dictionary<string, DataField>();
    private CompoundTypeDeclaration<T>      m_Parent = null;
    private List<Option>                    m_Options = null;
    private DataField                       m_CurrentField = null;
    private StringTemplate                  m_FieldH = null;
    private StringTemplate                  m_FieldCPP = null;
    protected StringTemplate                m_Header = null;
    protected StringTemplate                m_Source = null;
    protected StringTemplateGroup           m_TemplateGroup = null;
    private bool                            m_IsTemplateGenerated = false;
    private bool                            m_IsCodeGenerated = false;

    public bool IsCodeGenerated
    {
        get
        {
            return m_IsCodeGenerated;
        }

        set
        {
            m_IsCodeGenerated = value;
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

    public Dictionary<string, DataField> Fields
    {
        get
        {
            return m_Fields;
        }
    }

    public void SetType(BaseType type)
    {
        Type = type.Type;
        PackageNameQualifier = type.PackageNameQualifier;
        Token = type.Token;
    }

    public void AddField(DataField field)
    {
        try
        {
            if (m_Parent != null)
            {
                if (m_Parent.Fields.ContainsKey(field.Name))
                {
                    throw new System.ArgumentException();
                }
            }
            m_Fields.Add(field.Name, field);
        }
        catch (System.ArgumentException)
        {
            Compiler.Instance.DuplicateDataField(this,field);
        }
    }

    public CompoundTypeDeclaration<T> Parent
    {
        get
        {
            return m_Parent;
        }

        set
        {
            m_Parent = value;
        }
    }

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

    public int LastParentFieldIndex
    {
        get 
        {
            if (m_Parent != null)
                return m_Parent.LastParentFieldIndex + m_Parent.Fields.Count;

            return 0;
        }
    }

    private bool ProcessConstant(IConstant c, InitializerContext ic)
    {
        if (ic.IsTypeExpected(eType.INT32))
        {
            Int32Constant integerConstant = c as Int32Constant;
            
            if (integerConstant != null)
            {
                ic.Template.SetAttribute("constants", integerConstant.Value.ToString(CultureInfo.InvariantCulture));
                return true;
            }            
        }

        if (ic.IsTypeExpected(eType.DOUBLE))
        {
            DoubleConstant doubleConstant = c as DoubleConstant;

            if (doubleConstant != null)
            {
                ic.Template.SetAttribute("constants", doubleConstant.Value.ToString(CultureInfo.InvariantCulture));
                return true;
            }
        }

        if (ic.IsTypeExpected(eType.STRING))
        {
            StringConstant stringConstant = c as StringConstant;

            if (stringConstant != null)
            {
                if (m_CurrentField.Type.Type == eType.STRING)
                    ic.Template.SetAttribute("constants", "L" + stringConstant.Value);
                else
                    ic.Template.SetAttribute("constants", stringConstant.Value);

                return true;
            }
        }

        return false;
    }

    private void ProcessSimpleInitializer(SimpleInitializer initializer, int numRequiredConstants, InitializerContext ic)
    {
        foreach (var c in initializer.Constants)
        {
            if (!ProcessConstant(c, ic))
            {
                BaseType fieldType = MapType(m_CurrentField.Type);

                //enum constant
                EnumDeclaration ed = fieldType as EnumDeclaration;

                if (ed != null)
                {
                    EnumConstant ec = c as EnumConstant;

                    if (ec != null)
                    {
                        int val = ed.GetValue(ec.TextVal);

                        if (val != -1)
                            ic.Template.SetAttribute("constants", val);
                        else
                            Compiler.Instance.EnumHasNoSuchValue(m_CurrentField, ed, ec.TextVal);
                    }
                    else
                    {
                        Compiler.Instance.InvalidEnumInitializer(m_CurrentField);
                    }

                    break;
                }

                //named constant
                SymbolConstant sc = c as SymbolConstant;

                if (sc != null)
                {
                    DataField mappedConstant = MapConstant(sc);

                    if (mappedConstant != null)
                    {
                        ProcessInitializer(mappedConstant.Initter, numRequiredConstants, ic);
                    }
                    else
                    {
                        Compiler.Instance.ConstantNotFound(sc);
                    }
                }
            }
        }
    }

    private void ProcessDefaultValue(InitializerContext ic)
    {        
        IDictionary defaultValues = m_TemplateGroup.GetMap("defaultValues");

        foreach (System.Collections.DictionaryEntry p in defaultValues)
        {
            if ((string)p.Key == m_CurrentField.Type.Name)
            {
                ic.Template.SetAttribute("constants", p.Value.ToString());
                return;
            }
        }
    }

    private void ProcessInitializer(Initializer initializer, int numRequiredConstants, InitializerContext ic)
    {
        if (initializer.Count != numRequiredConstants)
        {
            Compiler.Instance.InvalidFieldInitializer(m_CurrentField, numRequiredConstants);
            return;
        }

        SimpleInitializer si = initializer as SimpleInitializer;

        if (si != null)
            ProcessSimpleInitializer(si, numRequiredConstants, ic);
    }

    private eRuntimeKind GetRuntimeKind(DataField f)
    {
        RuntimeKindOption options = Utilities.GetOption<RuntimeKindOption>(f.Options);

        if (options != null)
            return options.Value;

        options = Utilities.GetOption<RuntimeKindOption>(Options);

        if (options != null)
            return options.Value;

        return Compiler.Instance.Options.RuntimeKind;
    }

    private bool IsFieldInProfile(DataField f)
    {
        ProfileOption po = Utilities.GetOption<ProfileOption>(f.Options);

        if (po != null)
            return po.Expr.Evaluate();

        return true;
    }

    protected bool IsInProfile()
    {
        if (Parent != null)
        {
            bool result = Parent.IsInProfile();

            if (!result)
                return false;
        }

        ProfileOption po = Utilities.GetOption<ProfileOption>(Options);

        if (po != null)
            return po.Expr.Evaluate();

        return true;
    }

    private bool IsNoSerializeField(DataField f)
    {
        if (Utilities.GetOption<NoSerializeOption>(f.Options) != null)
            return true;

        return false;
    }

    private void ProcessBuiltInType(BaseType type, ref string typeName, FieldContext fc)
    {
        IDictionary typeMap = null;

        eRuntimeKind rtk = GetRuntimeKind(m_CurrentField);
        
        if (rtk == eRuntimeKind.Simple)
            typeMap = m_TemplateGroup.GetMap("typeMapSimple");
        else if (rtk == eRuntimeKind.SimpleThreadSafe)
            typeMap = m_TemplateGroup.GetMap("typeMapSimpleThreadSafe");
        else if (rtk == eRuntimeKind.DualBuffer)
            typeMap = m_TemplateGroup.GetMap("typeMapDualBuffer");

        typeName = type.Name;

        foreach (System.Collections.DictionaryEntry p in typeMap)
        {
            if ((string)p.Key == type.Name)
            {
                typeName = p.Value.ToString();
                break;
            }
        }

        InitializerContext ic = new InitializerContext(m_TemplateGroup);

        if (m_CurrentField.Initter != null)
        {
            int numRequiredConstants = 0;

            if (type.Type == eType.BOOL)
            {
                ic.ExpectedType1 = eType.BOOL;
                numRequiredConstants = 1;
            }
            else if (type.Type == eType.STRING || type.Type == eType.CSTRING)
            {
                ic.ExpectedType1 = eType.STRING;
                ic.ExpectedType2 = eType.CSTRING;
                numRequiredConstants = 1;
            }
            else if (type.Type > eType.INTEGERTYPESBEGIN && type.Type < eType.INTEGERTYPESEND)
            {
                ic.ExpectedType1 = eType.INT32;
                numRequiredConstants = 1;
            }
            else if (type.Type > eType.FPTYPESBEGIN && type.Type < eType.FPTYPESEND)
            {
                ic.ExpectedType1 = eType.INT32;
                ic.ExpectedType2 = eType.DOUBLE;
                numRequiredConstants = 1;
            }
            else if (type.Type > eType.BASICTYPESEND && type.Type < eType.BUILTINTYPESEND)
            {
                ic.ExpectedType1 = eType.INT32;
                ic.ExpectedType2 = eType.DOUBLE;
                numRequiredConstants = 1;
            }

            switch (type.Type)
            {
                case eType.VEC2:
                case eType.VEC2F:
                case eType.VEC2D:
                    {
                        numRequiredConstants = 2;
                        break;
                    }

                case eType.VEC3:
                case eType.VEC3D:
                case eType.VEC3F:
                    {
                        numRequiredConstants = 3;
                        break;
                    }

                case eType.VEC4:
                case eType.VEC4D:
                case eType.VEC4F:
                case eType.QUAT:
                case eType.QUATD:
                case eType.QUATF:
                case eType.MAT2X2:
                case eType.MAT2X2D:
                case eType.MAT2X2F:
                    {
                        numRequiredConstants = 4;
                        break;
                    }

                case eType.MAT3X3:
                case eType.MAT3X3D:
                case eType.MAT3X3F:
                    {
                        numRequiredConstants = 9;
                        break;
                    }

                case eType.MAT4X4:
                case eType.MAT4X4D:
                case eType.MAT4X4F:
                    {
                        numRequiredConstants = 16;
                        break;
                    }
            }

            if (numRequiredConstants > 0 && !fc.IsList && !fc.IsMap && !fc.IsRef)
            {
                ProcessInitializer(m_CurrentField.Initter, numRequiredConstants, ic);
            }
            else
                Compiler.Instance.InitializerNotSupported(m_CurrentField);

            var valueTypeMap = m_TemplateGroup.GetMap("valueTypeMap");

            foreach (System.Collections.DictionaryEntry p in valueTypeMap)
            {
                if ((string)p.Key == type.Name)
                {
                    ic.Template.SetAttribute("type",p.Value.ToString());
                    break;
                }
            }

            m_FieldCPP.SetAttribute("initVal", ic.Template);
        }
        else
        {
            ProcessDefaultValue(ic);
            m_FieldCPP.SetAttribute("initVal", ic.Template);
        }
    }

    private void ProcessMap(MapType type, ref string typeName, FieldContext fc)
    {
        m_FieldH.SetAttribute("isMap", true);
        m_FieldCPP.SetAttribute("isMap", true);

        fc.IsMap = true;

        string keyType = string.Empty;
        string valueType = string.Empty;
        ProcessType(type.KeyType, ref keyType, fc);
        ProcessType(type.ValueType, ref valueType, fc);

        eRuntimeKind rtk = GetRuntimeKind(m_CurrentField);

        if (rtk == eRuntimeKind.Simple)
            typeName = "ThMapSimpleField< " + keyType + ", " + valueType + ", false>";
        else if (rtk == eRuntimeKind.SimpleThreadSafe)
            typeName = "ThMapSimpleField< " + keyType + ", " + valueType + ", true>";
        else if (rtk == eRuntimeKind.DualBuffer)
            typeName = "ThMapDualBufferField< " + keyType + ", " + valueType + " >";
    }

    private void ProcessList(ListType type, ref string typeName, FieldContext fc)
    {
        m_FieldH.SetAttribute("isList", true);
        m_FieldCPP.SetAttribute("isList", true);

        fc.IsList = true;

        string itemType = string.Empty;
        ProcessType(type.ContainedType, ref itemType, fc);

        eRuntimeKind rtk = GetRuntimeKind(m_CurrentField);

        if (rtk == eRuntimeKind.Simple)
            typeName = "ThListSimpleField< " + itemType + ", false>";
        else if (rtk == eRuntimeKind.SimpleThreadSafe)
            typeName = "ThListSimpleField< " + itemType + ", true>";
        else if (rtk == eRuntimeKind.DualBuffer)
            typeName = "ThListDualBufferField< " + itemType + " >";
    }

    private void ProcessReference(RefType type, ref string typeName, FieldContext fc)
    {
        m_FieldH.SetAttribute("isRef", true);
        m_FieldCPP.SetAttribute("isRef", true);

        fc.IsRef = true;

        string refType = null;
        ProcessType(type.ContainedType, ref refType, fc);

        eRuntimeKind rtk = GetRuntimeKind(m_CurrentField);

        if (rtk == eRuntimeKind.Simple)
            typeName = "ThRefPtrSimpleField< " + refType + ", false>";
        else if (rtk == eRuntimeKind.SimpleThreadSafe)
            typeName = "ThRefPtrSimpleField< " + refType + ", true>";
        else if (rtk == eRuntimeKind.DualBuffer)
            typeName = "ThRefPtrDualBufferField< " + refType + " >";
    }

    private void ProcessWeakReference(WeakRefType type, ref string typeName, FieldContext fc)
    {
        m_FieldH.SetAttribute("isWeakRef", true);
        m_FieldCPP.SetAttribute("isWeakRef", true);

        fc.IsRef = true;

        string refType = null;
        ProcessType(type.ContainedType, ref refType, fc);

        eRuntimeKind rtk = GetRuntimeKind(m_CurrentField);

        if (rtk == eRuntimeKind.Simple)
            typeName = "ThWeakPtrSimpleField< " + refType + ", false>";
        else if (rtk == eRuntimeKind.SimpleThreadSafe)
            typeName = "ThWeakPtrSimpleField< " + refType + ", true>";
        else if (rtk == eRuntimeKind.DualBuffer)
            typeName = "ThWeakPtrDualBufferField< " + refType + " >";
    }

    private void ProcessCustom(BaseType type, ref string typeName, FieldContext fc)
    {
        Symbol sym = null;
        
        if (type.PackageNameQualifier == string.Empty)
            sym = Package.FindSymbolUp(type.FullName);
        else
            sym = Compiler.Instance.RootPackage.FindSymbolDown(type.FullName);

        if (sym != null)
        {
            if (!Compiler.Instance.IsFileInImports(FileName, sym.FileName))
                Compiler.Instance.TypeNotImported(sym as BaseType, FileName);

            EntityDeclaration entityDecl = sym as EntityDeclaration;

            if (entityDecl != null)
            {
                if(!fc.IsRef)
                    Compiler.Instance.EntityFieldDeclared(this, type);

                if (!entityDecl.IsInProfile())
                    Compiler.Instance.TypeNotInProfile(type);
            }

            StructDeclaration structDecl = sym as StructDeclaration;

            if (structDecl != null)
            {
                if (!structDecl.IsInProfile())
                    Compiler.Instance.TypeNotInProfile(type);

                if (!fc.IsList && !fc.IsMap)
                {
                    m_FieldH.SetAttribute("isStruct", true);
                    m_FieldCPP.SetAttribute("isStruct", true);
                }                
            }

            EnumDeclaration enumDecl = sym as EnumDeclaration;

            if (enumDecl != null)
            {
                eRuntimeKind rtk = GetRuntimeKind(m_CurrentField);

                if (rtk == eRuntimeKind.Simple)
                    typeName = string.Format("{0}Simple", type.FullNameCPP);
                else if (rtk == eRuntimeKind.SimpleThreadSafe)
                    typeName = string.Format("{0}SimpleThreadSafe", type.FullNameCPP);
                else if (rtk == eRuntimeKind.DualBuffer)
                    typeName = type.FullNameCPP;
            }
            else
                typeName = type.FullNameCPP;

            if (m_CurrentField.Initter != null)
            {
                InitializerContext ic = new InitializerContext(m_TemplateGroup);
                ProcessInitializer(m_CurrentField.Initter, 1, ic);
                m_FieldCPP.SetAttribute("initVal", ic.Template);
            }
        }
        else
        {
            Compiler.Instance.TypeNotFound(type);
            //throw new CompileException("Type not found");
        }
    }

    protected BaseType MapType(BaseType type)
    {
        BaseType result = null;

        if (type.PackageNameQualifier == string.Empty)
            result = Package.FindSymbolUp(type.FullName);
        else
            result = Compiler.Instance.RootPackage.FindSymbolDown(type.FullName);

        return result;
    }

    protected DataField MapConstant(BaseType constant)
    {
        DataField result = null;

        if (constant.PackageNameQualifier == string.Empty)
            result = Package.FindConstantUp(constant.FullName);
        else
            result = Compiler.Instance.RootPackage.FindConstantDown(constant.FullName);

        return result;
    }

    private void ProcessType(BaseType type, ref string typeName, FieldContext fc)
    {
        if (type.IsBuiltIn)
        {
            ProcessBuiltInType(type, ref typeName, fc);
        }
        else if (type.Type == eType.LIST)
        {
            ProcessList(type as ListType, ref typeName, fc);
        }
        else if (type.Type == eType.MAP)
        {
            ProcessMap(type as MapType, ref typeName, fc);
        }
        else if (type.Type == eType.REF)
        {
            ProcessReference(type as RefType, ref typeName, fc);
        }
        else if (type.Type == eType.WEAKREF)
        {
            ProcessWeakReference(type as WeakRefType, ref typeName, fc);
        }
        else if (type.Type == eType.CUSTOM)
        {
            ProcessCustom(type, ref typeName, fc);
        }
    }

    public void GenerateFields(Package package, StringTemplate h, StringTemplate cpp, StringTemplateGroup group)
    {
        int index = LastParentFieldIndex;

        foreach (var f in m_Fields)
        {
            if (!IsFieldInProfile(f.Value))
                continue;

            m_FieldH = group.GetInstanceOf("fieldH");
            m_FieldCPP = group.GetInstanceOf("fieldCPP");
            m_CurrentField = f.Value;

            m_FieldH.SetAttribute("name", f.Value.Name);
            m_FieldCPP.SetAttribute("name", f.Value.Name);
            m_FieldCPP.SetAttribute("index", index);
            m_FieldH.SetAttribute("package", package.NameCPP);
            m_FieldCPP.SetAttribute("package", package.NameCPP);

            string typeName = null;

            ProcessType(f.Value.Type, ref typeName, new FieldContext());

            if (typeName != null)
            {
                m_FieldH.SetAttribute("type", typeName);
                m_FieldCPP.SetAttribute("type", typeName);
            }

            h.SetAttribute("fields", m_FieldH);
            cpp.SetAttribute("fields", m_FieldCPP);

            if (IsNoSerializeField(f.Value))
                m_FieldCPP.SetAttribute("noSerialize", true);

            ++index;
        }
    }

    public void GenerateParentTypeInfo(StringTemplate h, StringTemplate cpp)
    {
        if (Parent != null)
        {
            h.SetAttribute("base", Parent.Header);
            cpp.SetAttribute("base", Parent.Source);
        }        
    }

    public abstract void Preprocess();

    public void GenerateTemplates(Package package, StringTemplateGroup group)
    {
        if (!IsInProfile())
        {
            m_IsTemplateGenerated = true;
            return;
        }

        m_TemplateGroup = group;

        if (!m_IsTemplateGenerated)
        {
            m_IsTemplateGenerated = true;

            if (Parent != null)
                Parent.GenerateTemplates(package, group);

            GenerateTemplatesImpl(package, group);
        }
    }

    protected abstract void GenerateTemplatesImpl(Package package, StringTemplateGroup group);
}

public class StructDeclaration:CompoundTypeDeclaration<StructDeclaration>
{

    public override void Preprocess()
    {
        if (Parent != null)
        {
            BaseType pc = MapType(Parent);

            StructDeclaration sd = pc as StructDeclaration;

            if (sd != null)
            {
                if (!Compiler.Instance.IsFileInImports(FileName, sd.FileName))
                    Compiler.Instance.TypeNotImported(sd, FileName);

                Parent = sd;
            }
            else
            {
                Compiler.Instance.StructureNotFound(this);
                //throw new CompileException("StructureNotFound");
            }
        }
    }

    protected override void GenerateTemplatesImpl(Package package, StringTemplateGroup group)
    {
        m_Header = group.GetInstanceOf("structH");
        m_Source = group.GetInstanceOf("structCPP");

        m_Header.SetAttribute("package", package.NameCPP);
        m_Source.SetAttribute("package", package.NameCPP);

        m_Header.SetAttribute("name", Name);
        m_Source.SetAttribute("name", Name);

        GeneratedFileDesc desc = Compiler.Instance.GetGeneratedFileDesc(FileName);

        m_Header.SetAttribute("libMacros", desc.LibMacros);

        GenerateFields(package, m_Header, m_Source, group);
        GenerateParentTypeInfo(m_Header, m_Source);

        string h = m_Header.ToString();
        string cpp = m_Source.ToString();
    }
}

public class EntityDeclaration : CompoundTypeDeclaration<EntityDeclaration>
{
    public override void Preprocess()
    {
        if (Parent != null)
        {
            Symbol pc = MapType(Parent);

            EntityDeclaration ed = pc as EntityDeclaration;

            if (ed != null)
            {
                if (!Compiler.Instance.IsFileInImports(FileName, ed.FileName))
                    Compiler.Instance.TypeNotImported(ed, FileName);

                Parent = ed;
            }
            else
            {
                Compiler.Instance.EntityNotFound(this);
                //throw new CompileException("EntityNotFound");
            }
        }
    }

    protected override void GenerateTemplatesImpl(Package package, StringTemplateGroup group)
    {
        m_Header = group.GetInstanceOf("entityH");
        m_Source = group.GetInstanceOf("entityCPP");

        m_Header.SetAttribute("package", package.NameCPP);
        m_Source.SetAttribute("package", package.NameCPP);

        m_Header.SetAttribute("name", Name);
        m_Source.SetAttribute("name", Name);

        GeneratedFileDesc desc = Compiler.Instance.GetGeneratedFileDesc(FileName);

        m_Header.SetAttribute("libMacros", desc.LibMacros);

        GenerateFields(package, m_Header, m_Source, group);
        GenerateParentTypeInfo(m_Header, m_Source);

        string h = m_Header.ToString();
        string cpp = m_Source.ToString();
    }
}

}