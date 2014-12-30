grammar DataForge;

options
{
	backtrack=true;
	memoize=true;
	//output=AST;
	//ASTLabelType=ThorAST;
	language=CSharp2;
	k=2;
}

tokens
{
	//keywords	
	CONST='const';
	STRUCT='struct';
	ENUM='enum';
	IMPORTS='imports';
	PACKAGE='package';
	PROFILE='profile';
	ENTITY='entity';
	LIST='list';
	MAP='map';
	REF='ref';
	WEAKREF='weak_ref';
	TRUE='true';
	FALSE='false';
	//field/struct options
	REPLICATED='replicated';
	RUNTIME_KIND='runtime_kind';
	RTK_SIMPLE='rtk_simple';
	RTK_SIMPLE_THREAD_SAFE='rtk_simple_thread_safe';
	RTK_DUAL_BUFFER='rtk_dual_buffer';
	NOSERIALIZE='no_serialize';
	//punctuation
	SEMICOLON=';';
	LEFT_ANGLE='<';
	RIGHT_ANGLE='>';
	LEFT_PAREN='(';
	RIGHT_PAREN=')';
	DOT='.';
	COMMA=',';
	COLON=':';
	LEFT_BRACE ='{';
	RIGHT_BRACE='}';
	LEFT_BRACKET='[';
	RIGHT_BRACKET=']';
	//operators
	LEFT_OP='<<';
	RIGHT_OP='>>';
	AND_OP='&&';
	OR_OP='||';
	BANG='!';
	EQUAL='=';
	DASH='-';
	PLUS='+';
	STAR='*';
	SLASH='/';
	PERCENT='%';	
	//types
	BOOL='bool';
	FLOAT='float';
	DOUBLE='double';
	REAL='real';
	INT64='int64';
	INT32='int32';
	INT16='int16';
	INT8='int8';
	UINT64='uint64';
	UINT32='uint32';
	UINT16='uint16';
	UINT8='uint8';
	STRING='string';
	CSTRING='cstring';
		
	VEC2='vec2';
	VEC3='vec3';
	VEC4='vec4';	
	MAT2X2='mat2x2';
	MAT3X3='mat3x3';
	MAT4X4='mat4x4';
	QUAT='quat';
	
	VEC2F='vec2f';
	VEC3F='vec3f';
	VEC4F='vec4f';	
	MAT2X2F='mat2x2f';
	MAT3X3F='mat3x3f';
	MAT4X4F='mat4x4f';
	QUATF='quatf';
	
	VEC2D='vec2d';
	VEC3D='vec3d';
	VEC4D='vec4d';	
	MAT2X2D='mat2x2d';
	MAT3X3D='mat3x3d';
	MAT4X4D='mat4x4d';
	QUATD='quatd';
	
	//
	CPP='cpp';
	LIB_HEADER='lib_header';
	LIB_MACROS='lib_macros';
}

@header{
	using Thor.DataForge;
	using System.Collections.Generic;
	using System.Globalization;
}

@members{
	public Compiler compiler;
	
	private void ProcessEnumItemDecl(EnumDeclaration ed, string name, int val, IToken token, ref int enumValue) 
	{
		if(val < 0)
			enumValue++;
		else
		{
			if(val <= enumValue)
				compiler.InvalidEnumValuesOrder(token);
				
			enumValue = val;
		}				
				
		ed.AddValue(name, enumValue);
	}	
}

@rulecatch
{
	catch (RecognitionException e) 
	{
		throw e;
	}
}

fragment	
LETTER	
	: 'A'..'Z'
	| 'a'..'z'	
	| '_'
	;

fragment
DIGIT	:	'0'..'9'
	;

fragment
HEX	:	'a'..'f'
	|	'A'..'F'
	|	'0'..'9'
	;

fragment
EXPONENT:	('E'|'e') ('+' | '-')+ DIGIT+
	;

INTCONSTANT
	:	'0' ('x'|'X') HEX+	
	|	('0' | '1'..'9') DIGIT*
	;

fragment
EscapeSequence
    :   '\\' ('b'|'t'|'n'|'f'|'r'|'\"'|'\''|'\\')
    ;

STRING_LITERAL
    :  '"' ( EscapeSequence | ~('\\'|'"') )* '"'
    ;
	
FLOATCONSTANT
	:	DIGIT+ EXPONENT
	|	DIGIT+ '.' DIGIT* EXPONENT?
	|	'.' DIGIT+ EXPONENT?
	;	

IDENTIFIER
	:	LETTER (LETTER|DIGIT)*
	;	


WS  :  (' '|'\r'|'\t'|'\n')+ {$channel=HIDDEN;}
    ;

COMMENT
    :   '/*' ( options {greedy=false;} : . )* '*/' {$channel=HIDDEN;}
    ;

LINE_COMMENT
    : '//' ~('\n'|'\r')* '\r'? '\n' {$channel=HIDDEN;}
    ;

types returns[BaseType type]
@init{$type = new BaseType();}
	:	BOOL	{$type.Type=eType.BOOL; $type.Token=$BOOL;}
	|	FLOAT	{$type.Type=eType.FLOAT; $type.Token=$FLOAT;}
	|	DOUBLE	{$type.Type=eType.DOUBLE; $type.Token=$DOUBLE;}
	|	REAL	{$type.Type=eType.REAL; $type.Token=$REAL;}
	|	INT64	{$type.Type=eType.INT64; $type.Token=$INT64;}
	|	INT32	{$type.Type=eType.INT32; $type.Token=$INT32;}
	|	INT16	{$type.Type=eType.INT16; $type.Token=$INT16;}
	|	INT8	{$type.Type=eType.INT8; $type.Token=$INT8;}
	|	UINT64	{$type.Type=eType.UINT64; $type.Token=$UINT64;}
	|	UINT32	{$type.Type=eType.UINT32; $type.Token=$UINT32;}
	|	UINT16	{$type.Type=eType.UINT16; $type.Token=$UINT16;}
	|	UINT8	{$type.Type=eType.UINT8; $type.Token=$UINT8;}
	|	STRING	{$type.Type=eType.STRING; $type.Token=$STRING;}
	|	CSTRING	{$type.Type=eType.CSTRING; $type.Token=$CSTRING;}
	|	VEC2	{$type.Type=eType.VEC2; $type.Token=$VEC2;}
	|	VEC3	{$type.Type=eType.VEC3; $type.Token=$VEC3;}
	|	VEC4	{$type.Type=eType.VEC4; $type.Token=$VEC4;}
	|	MAT2X2	{$type.Type=eType.MAT2X2; $type.Token=$MAT2X2;}
	|	MAT3X3	{$type.Type=eType.MAT3X3; $type.Token=$MAT3X3;}
	|	MAT4X4	{$type.Type=eType.MAT4X4; $type.Token=$MAT4X4;}
	|	QUAT	{$type.Type=eType.QUAT; $type.Token=$QUAT;}
	|	VEC2F	{$type.Type=eType.VEC2F; $type.Token=$VEC2F;}
	|	VEC3F	{$type.Type=eType.VEC3F; $type.Token=$VEC3F;}
	|	VEC4F	{$type.Type=eType.VEC4F; $type.Token=$VEC4F;}
	|	MAT2X2F	{$type.Type=eType.MAT2X2F; $type.Token=$MAT2X2F;}
	|	MAT3X3F	{$type.Type=eType.MAT3X3F; $type.Token=$MAT3X3F;}
	|	MAT4X4F	{$type.Type=eType.MAT4X4F; $type.Token=$MAT4X4F;}
	|	QUATF	{$type.Type=eType.QUATF; $type.Token=$QUATF;}
	|	VEC2D	{$type.Type=eType.VEC2D; $type.Token=$VEC2D;}
	|	VEC3D	{$type.Type=eType.VEC3D; $type.Token=$VEC3D;}
	|	VEC4D	{$type.Type=eType.VEC4D; $type.Token=$VEC4D;}
	|	MAT2X2D	{$type.Type=eType.MAT2X2D; $type.Token=$MAT2X2D;}
	|	MAT3X3D	{$type.Type=eType.MAT3X3D; $type.Token=$MAT3X3D;}
	|	MAT4X4D	{$type.Type=eType.MAT4X4D; $type.Token=$MAT4X4D;}
	|	QUATD	{$type.Type=eType.QUATD; $type.Token=$QUATD;}
	//| 	IDENTIFIER	{$type.Type=eType.CUSTOM; $type.Token=$IDENTIFIER;}
	|	(pq=IDENTIFIER DOT {$type.PackageNameQualifier = $pq.Text;})* tn=IDENTIFIER {$type.Type=eType.CUSTOM; $type.Token=$tn;}
	;
	
string_list returns[List<string> strings]
@init{$strings = new List<string>();}
	:	str1=STRING_LITERAL {$strings.Add( Utilities.TrimQuotes( $str1.text ) );} 
		(COMMA str2=STRING_LITERAL {$strings.Add( Utilities.TrimQuotes( $str2.text ) );} )*
	;

package_identifier returns[List<string> strings]
@init{$strings = new List<string>();}
	: 	str1=IDENTIFIER {$strings.Add($str1.text);}
		(DOT str2=IDENTIFIER {$strings.Add($str2.text);} )*
	;
//imports
imports
	:	IMPORTS LEFT_BRACE sl=string_list RIGHT_BRACE
		{
			foreach(var s in $sl.strings)
			{
				string curFile = compiler.CurrentFile;
				compiler.ParseFile(s);
				compiler.AddImportedFile(curFile, compiler.GetFilePath(s));
			}
		}
	;
	
//cpp
lib_header_option 
	:	LIB_HEADER EQUAL ho=STRING_LITERAL SEMICOLON
		{
			GeneratedFileDesc desc = Compiler.Instance.GetGeneratedFileDesc(Compiler.Instance.CurrentFile);
			desc.LibHeader = Utilities.TrimQuotes($ho.Text);
		}
	;
	
lib_macros_option
	:	LIB_MACROS EQUAL m=STRING_LITERAL SEMICOLON
		{
			GeneratedFileDesc desc = Compiler.Instance.GetGeneratedFileDesc(Compiler.Instance.CurrentFile);
			desc.LibMacros = Utilities.TrimQuotes($m.Text);
		}
	;
	
lib_option
	:	lib_header_option lib_macros_option
	;	

cpp
	:
		CPP LEFT_BRACE lib_option RIGHT_BRACE
	;
//package
package_rule
	:	PACKAGE p=package_identifier SEMICOLON
		{
			compiler.CurrentPackage = compiler.RootPackage.AddChildPackage($p.strings);			
		}
	;
//enum
enum_specifier
@init{EnumDeclaration ed=new EnumDeclaration();}
	:	ENUM id=IDENTIFIER {ed.Token=$id;} LEFT_BRACE 
		enum_declaration_list[ed] 
		{			
			compiler.CurrentPackage.AddEnumeration(ed);
		}
		RIGHT_BRACE
	;
	
enum_declaration_list[EnumDeclaration ed]
@init{int enumValue=-1;}
	:	edecl1=enum_declaration {ProcessEnumItemDecl($ed,$edecl1.name,$edecl1.val,$edecl1.token,ref enumValue);}
		(
			COMMA edecl2=enum_declaration {ProcessEnumItemDecl($ed,$edecl2.name,$edecl2.val,$edecl2.token,ref enumValue);}			
		)*;
	
enum_declaration returns[string name, int val, IToken token]
@init{$val=-1;}
	:	i=IDENTIFIER 				{$name=$i.text; $val=-1; $token=$i;}	
	|	i=IDENTIFIER EQUAL c1=INTCONSTANT ((lo=LEFT_OP | ro=RIGHT_OP) c2=INTCONSTANT)?
		{
			$name=$i.text;			
			$token=$i;
			int shiftVal = Int32.Parse($c1.text, CultureInfo.InvariantCulture);
			$val=shiftVal;
			
			if(lo!=null || ro!=null)
			{
				int bitsToShift = Int32.Parse($c2.text, CultureInfo.InvariantCulture);
			
				if(lo!=null)
					$val = shiftVal << bitsToShift;
				else
					$val = shiftVal >> bitsToShift;
			}
		}
	;
	
enum_field returns[EnumConstant enumConst]
@init{$enumConst = new EnumConstant();}
	:	(pq=IDENTIFIER DOT {$enumConst.PackageNameQualifier = $pq.Text;})* ename=IDENTIFIER COLON COLON eval=IDENTIFIER
		{
			$enumConst.Token = $ename;
			$enumConst.TextVal = $eval.text;
		}
	;
//declarations	
simple_declaration returns[DataField field]
	:	t=types id=IDENTIFIER
		{
			$field = new DataField();
			$field.Type=$t.type;
			$field.Token=$id;
		}
	;

list_declaration returns[DataField field]
	:	lt=list_type name=IDENTIFIER
		{
			$field = new DataField();			
			$field.Type=$lt.type;
			$field.Token=$name;
		}
	;
	
list_type returns[BaseType type]
	:	LIST LEFT_ANGLE (subT=subcontainer_types | valT=types) RIGHT_ANGLE
		{
			ListType listType = new ListType();
			
			if(subT!=null)
				listType.ContainedType = $subT.type;
				
			if(valT!=null)
				listType.ContainedType = $valT.type;
				
			listType.Token=$LIST;
			$type = listType;
		}
	;
	
map_type returns[BaseType type]
	:	MAP LEFT_ANGLE keyT=types COMMA (subT=subcontainer_types | valT=types) RIGHT_ANGLE
		{
			MapType mapType = new MapType();
			mapType.KeyType = $keyT.type;
			
			if (subT != null)
				mapType.ValueType = $subT.type;
				
			if (valT != null)
				mapType.ValueType = $valT.type;
				
			mapType.Token=$MAP;
			$type=mapType;
		}
	;
	
reference_type returns[BaseType type]
	:	REF LEFT_ANGLE t=types RIGHT_ANGLE
		{
			RefType refType = new RefType();
			refType.ContainedType = $t.type;
			refType.Token=$REF;
			$type = refType;
		}
	;
	
reference_declaration returns[DataField field]
	:	rt=reference_type name=IDENTIFIER
		{
			$field = new DataField();
			RefType refType = new RefType();
			$field.Type=$rt.type;
			$field.Token=$name;
		}
	;
	
weak_reference_type returns[BaseType type]
	:	WEAKREF LEFT_ANGLE t=types RIGHT_ANGLE
		{
			WeakRefType refType = new WeakRefType();
			refType.ContainedType = $t.type;
			refType.Token=$WEAKREF;
			$type = refType;
		}
	;
	
weak_reference_declaration returns[DataField field]
	:	rt=weak_reference_type name=IDENTIFIER
		{
			$field = new DataField();
			WeakRefType refType = new WeakRefType();
			$field.Type=$rt.type;
			$field.Token=$name;
		}
	;
	
subcontainer_types returns[BaseType type]
	: lt=list_type		{$type = $lt.type;}
	| mt=map_type		{$type = $mt.type;}
	| rt=reference_type 	{$type = $rt.type;}
	| wt=weak_reference_type{$type = $wt.type;}
	;
	
map_declaration returns[DataField field]
	:	t=map_type name=IDENTIFIER
		{
			$field = new DataField();
			$field.Type=$t.type;
			$field.Token=$name;
		}
	;
	
declaration returns[DataField field]
	:	sd=simple_declaration		{$field=$sd.field;}
	|	rd=reference_declaration	{$field=$rd.field;}
	|	wd=weak_reference_declaration	{$field=$wd.field;}
	|	ld=list_declaration		{$field=$ld.field;}
	|	md=map_declaration		{$field=$md.field;}
	;
//options
replicated_option returns[ReplicatedOption opt]
@init{$opt=new ReplicatedOption();}
	:	t=REPLICATED EQUAL (TRUE|f=FALSE)
		{
			$opt.Token=$t;
			
			if(f==null)
				$opt.Value=true;
			else
				$opt.Value=false;
		}
	;
	
profile_option returns[ProfileOption opt]
@init{$opt=new ProfileOption();}
	:	t=PROFILE EQUAL exp=expression
		{
			$opt.Token=$t;
			$opt.Expr=$exp.expr;
		}
	;

runtime_kind_field_option returns[RuntimeKindOption opt]
@init{$opt=new RuntimeKindOption();}
	:	t=RUNTIME_KIND EQUAL (s=RTK_SIMPLE | ts=RTK_SIMPLE_THREAD_SAFE | db=RTK_DUAL_BUFFER) 
		{
			$opt.Token = $t;
			
			if (s != null)
				$opt.Value = eRuntimeKind.Simple;
			else if (ts != null)
				$opt.Value = eRuntimeKind.SimpleThreadSafe;
			else
				$opt.Value = eRuntimeKind.DualBuffer;
		}
	;
	
compound_type_options returns[Option opt]
	:	p=profile_option	{$opt=$p.opt;}
	|	rtk=runtime_kind_field_option {$opt=$rtk.opt;}
	|	nos=no_serialize_option {$opt=$nos.opt;}
	;
	
compound_type_options_list returns[List<Option> options]
@init{$options=new List<Option>();}
	:	o1=compound_type_options {$options.Add($o1.opt);} (COMMA o2=compound_type_options {$options.Add($o2.opt);} )*
	;
	
no_serialize_option returns[Option opt]
@init{$opt = new NoSerializeOption();}
	: 	t=NOSERIALIZE
		{
			$opt.Token = $t;
		}
	;
	
struct_options returns[Option opt]
	:	o3=replicated_option	{$opt=$o3.opt;}
	|	o4=profile_option	{$opt=$o4.opt;}
	|	o5=no_serialize_option  {$opt=$o5.opt;}
	;
	
struct_options_list returns[List<Option> options]
@init{$options=new List<Option>();}
	:	o1=struct_options {$options.Add($o1.opt);} (COMMA o2=struct_options {$options.Add($o2.opt);} )*
	;
	
entity_options returns[Option opt]
	:	o5=profile_option		{$opt=$o5.opt;}
	|	o6=no_serialize_option  	{$opt=$o6.opt;}
	;
	
entity_options_list returns[List<Option> options]
@init{$options=new List<Option>();}
	:	o1=entity_options {$options.Add($o1.opt);} (COMMA o2=entity_options {options.Add($o2.opt);} )*
	;
//const
constant_declaration
	:	CONST t=types id=IDENTIFIER EQUAL u=unary_expression SEMICOLON
		{
			DataField val = new DataField();
			val.Token=$id;
			val.Type=$t.type;
			val.Initter=$u.initter;
			compiler.CheckConstantType(val);
			compiler.CurrentPackage.AddConstant(val);
		}
	;
	
named_constant returns[SymbolConstant cnt]
@init{$cnt = new SymbolConstant();}
	:	(pq=IDENTIFIER DOT {$cnt.PackageNameQualifier = $pq.Text;})* id=IDENTIFIER {$cnt.Token=$id;}
	;

simple_constant returns[IConstant constant]
@init{$constant=null;}
	:	t0=TRUE			{BoolConstant cnt = new BoolConstant(); cnt.Value = true; cnt.Token = $t0; $constant = cnt;}
	|	t1=FALSE		{BoolConstant cnt = new BoolConstant(); cnt.Value = false; cnt.Token = $t1; $constant = cnt;}
	|	i=INTCONSTANT		{Int32Constant cnt = new Int32Constant(); cnt.Value = Int32.Parse($i.text, CultureInfo.InvariantCulture); cnt.Token = $i; $constant = cnt;}
	|	f=FLOATCONSTANT		{DoubleConstant cnt = new DoubleConstant(); cnt.Value = Single.Parse($f.text, CultureInfo.InvariantCulture); cnt.Token = $f; $constant = cnt;}
	|	s=STRING_LITERAL	{StringConstant cnt = new StringConstant(); cnt.Value =$s.text; cnt.Token = $s; $constant = cnt;}
	|	ef=enum_field		{$constant = $ef.enumConst;}
	|	nc=named_constant	{$constant = $nc.cnt;}
	;

constant_list returns[SimpleInitializer initter]
@init{$initter=new SimpleInitializer();}
	:	s1=simple_constant {$initter.Constants.Add($s1.constant);}
		(COMMA s2=simple_constant {$initter.Constants.Add($s2.constant);} )*
	;
	
constant returns[SimpleInitializer initter]
@init{$initter=null;}
	:	sc=simple_constant {$initter = new SimpleInitializer(); $initter.Constants.Add($sc.constant);}
	|	LEFT_BRACE cl=constant_list RIGHT_BRACE {$initter=$cl.initter;}
	;
//initializers
list_initializer returns[Initializer initter]
	:	LEFT_BRACE 
		(ue=unary_expression{$initter=$ue.initter;} | il=initializer_list{$initter=$il.initter;} )
		RIGHT_BRACE
	;
	
list_initializer_list returns[Initializer initter]
@init{InitializerList list = new InitializerList();$initter=list;}
	:	li1=list_initializer {list.Initters.Add($li1.initter);} (COMMA li2=list_initializer {list.Initters.Add($li2.initter);})*
	;
	
map_initializer returns[Initializer initter]
@init{InitializerNamed named=new InitializerNamed();$initter=named;}
	:	LEFT_BRACE id=STRING_LITERAL {named.Name=Utilities.TrimQuotes($id.text);} COLON
			(ue=unary_expression{named.Initter=$ue.initter;}
		|	il=initializer_list{named.Initter=$il.initter;} )
		RIGHT_BRACE		
	;
		
map_initializer_list returns[Initializer initter]
@init{InitializerList list = new InitializerList();$initter=list;}
	:	mi1=map_initializer {list.Initters.Add($mi1.initter);} (COMMA mi2=map_initializer {list.Initters.Add($mi2.initter);} )*
	;
	
simple_initializer returns[Initializer initter]
	:	ue=unary_expression		{$initter=$ue.initter;}
	|	mi=map_initializer_list		{$initter=$mi.initter;}
	|	li=list_initializer_list	{$initter=$li.initter;}
	;
	
named_initializer returns[Initializer initter]
@init{InitializerNamed ini=new InitializerNamed();$initter=ini;}
	:	id=IDENTIFIER EQUAL si=simple_initializer
		{
			ini.Name=$id.text;
			ini.Initter=$si.initter;
		}
	;

initializer returns[Initializer initter]
	:	ni=named_initializer	{$initter=$ni.initter;}
	|	si=simple_initializer	{$initter=$si.initter;}
	;

initializer_list returns[Initializer initter]
@init{InitializerList list=null;}
	:	ini1=initializer {$initter=$ini1.initter;}
		(
			COMMA ini2=initializer
			{
				if(list==null)
				{
					list=new InitializerList();
					list.Initters.Add($initter);
					$initter=list;
				}
				
				list.Initters.Add($ini2.initter);				
			}
		)*	
	;
	
initializer_root returns[Initializer initter]
	:	LEFT_BRACE ini1=initializer RIGHT_BRACE		{$initter=$ini1.initter;}
	|	ini2=initializer				{$initter=$ini2.initter;}
	;
//struct
struct_specifier
@init{StructDeclaration dec = new StructDeclaration();}
	:	STRUCT id=IDENTIFIER {dec.Token = $id;} (COLON parent=types)? (LEFT_BRACKET opt=compound_type_options_list RIGHT_BRACKET)? LEFT_BRACE struct_declaration_list[dec] RIGHT_BRACE
		{	
			compiler.CurrentPackage.AddStructure(dec);
			
			if(parent!=null)
			{
				StructDeclaration pdecl=new StructDeclaration();
				pdecl.SetType($parent.type);
				dec.Parent=pdecl;
			}
			
			dec.Options=$opt.options;
		}
	;

struct_declaration_list[StructDeclaration d]
	:	struct_declaration[$d]*
	;

struct_declaration[StructDeclaration d]
	:	decl=declaration (EQUAL ini=initializer_root)? (LEFT_BRACKET opt=struct_options_list RIGHT_BRACKET)? SEMICOLON
		{
			$d.AddField($decl.field);
			$decl.field.Options=$opt.options;
			$decl.field.Initter=$ini.initter;
		}
	;
//entity
entity_specifier
@init{EntityDeclaration dec = new EntityDeclaration();}
	:	ENTITY id=IDENTIFIER {dec.Token = $id;} (COLON parent=types)? (LEFT_BRACKET opt=compound_type_options_list RIGHT_BRACKET)? LEFT_BRACE entity_declaration_list[dec] RIGHT_BRACE
	{			
			compiler.CurrentPackage.AddEntity(dec);
			
			if(parent!=null)
			{
				EntityDeclaration pdecl=new EntityDeclaration();
				pdecl.SetType($parent.type);
				dec.Parent=pdecl;
			}
			
			dec.Options=$opt.options;
	}
	;

entity_declaration_list[EntityDeclaration d]
	:	entity_declaration[$d]*
	;

entity_declaration[EntityDeclaration d]
	:	decl=declaration (EQUAL ini=initializer_root)? (LEFT_BRACKET opt=entity_options_list RIGHT_BRACKET)? SEMICOLON
		{
			$d.AddField($decl.field);
			$decl.field.Options=$opt.options;
			$decl.field.Initter=$ini.initter;
		}
	;
//expressions
unary_expression returns[SimpleInitializer initter, Expression expr]
@init{$initter=null;}
@after
{
	//create an expression node with a named symbol, it is used in profile option expression evaluation	
	if($initter!=null && $initter.Count == 1)
	{
		SymbolConstant sym = $initter.Constants[0] as SymbolConstant;
		if(sym != null)
		{
			ValueExpression val=new ValueExpression();
			val.Token = sym.Token;
			val.Constant = sym;
			$expr = val;
		}
	}
}
	:	c=constant				{$initter=$c.initter;}
	| 	op=unary_operator cnt=constant		{$initter=$cnt.initter; $initter.ApplyUnaryOp($op.op);}
	;

unary_operator returns[eUnaryOp op]
@init{$op=eUnaryOp.Unknown;}
	:	BANG	{$op=eUnaryOp.LogicNot;}
	| 	DASH	{$op=eUnaryOp.Negate;}
//	| 	PLUS	
	;
	
logical_and_expression returns[Expression expr]
	:	u=unary_expression {$expr=$u.expr;compiler.CheckProfileExpression($expr,$start);}
		(
			op=AND_OP u1=unary_expression
			{
				AndExpression e = new AndExpression();
				e.Token=$op;
				e.Leaf1=$expr;
				e.Leaf2=$u1.expr;
				compiler.CheckProfileExpression(e.Leaf2,e.Token);
				$expr=e;
			}
		)*
	;

logical_or_expression returns[Expression expr]
	:	l=logical_and_expression {$expr=$l.expr;}
		(
			op=OR_OP l1=logical_and_expression
			{
				OrExpression e = new OrExpression();
				e.Token=$op;
				e.Leaf1=$expr;
				e.Leaf2=$l1.expr;				
				$expr=e;
			}
		)*
	;
	
expression returns[Expression expr]
@init{ExpressionRoot root = new ExpressionRoot(); $expr = root;}
	:	ex=logical_or_expression {root.Root=$ex.expr;}
	;
//root rules
data_structures
	:	constant_declaration
	|	enum_specifier
	|	struct_specifier
	|	entity_specifier
	;

translation_unit
	:	package_rule? imports? cpp? data_structures*
	;
