grammar DataForgeProject;

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
	TRUE='true';
	FALSE='false';	
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
	//options
	FILES='files';
	INCLUDES='includes';
	OUTPUTDIR='output_dir';
	DEFINES='defines';
	REALTYPE='real_type';
	FILENAMEPOSTFIX = 'filename_postfix';
	RUNTIME_KIND='runtime_kind';
	RTK_SIMPLE='rtk_simple';
	RTK_SIMPLE_THREAD_SAFE='rtk_simple_thread_safe';
	RTK_DUAL_BUFFER='rtk_dual_buffer';
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
	FLOAT='float';
	DOUBLE='double';
	
}

@header{
	using Thor.DataForge;
	using System.Collections.Generic;
	using System.IO;
}

@members{
	public ProjectOptions data;	
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

fragment
FLOATSUFFIX 
	:	('f'|'F')
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
	:	DIGIT+ EXPONENT FLOATSUFFIX?
	|	DIGIT+ '.' DIGIT* EXPONENT? FLOATSUFFIX?
	|	'.' DIGIT+ EXPONENT? FLOATSUFFIX?
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
    
string_list returns[List<string> strings]
@init{strings = new List<string>();}
	:	str1=STRING_LITERAL {strings.Add( Utilities.TrimQuotes( $str1.text ) );} 
		(COMMA str2=STRING_LITERAL {strings.Add( Utilities.TrimQuotes( $str2.text ) );} )*
	;
	
files_option
	:	FILES EQUAL sl=string_list 
		{
			foreach(var s in $sl.strings)
			{
				data.Files.Add(s);
			}
		}
	;
	
includes_option
	:	INCLUDES EQUAL sl=string_list
		{
			foreach(var s in $sl.strings)
			{
				data.Includes.Add(Path.GetFullPath(s));
			}
		}
	;
	
output_dir_option
	:	OUTPUTDIR EQUAL dir=STRING_LITERAL {data.OutputDir = Utilities.TrimQuotes($dir.text);}
	;
	
identifier_list returns[List<string> strings]
@init{strings = new List<string>();}
	: 	str1=IDENTIFIER {strings.Add($str1.text);}
		(COMMA str2=IDENTIFIER {strings.Add($str2.text);} )*
	;
	
defines_option
	:	DEFINES EQUAL il=identifier_list
		{
			foreach(var s in $il.strings)
			{
				data.Defines.Add(s);
			}
		}
	;
	
real_type_option
	:	REALTYPE EQUAL (f=FLOAT|DOUBLE)
		{
			if(f!=null)
				data.RealType=eRealType.Float;
			else
				data.RealType=eRealType.Double;
		}
	;
	
filename_postfix_option
	:	FILENAMEPOSTFIX EQUAL p=STRING_LITERAL
		{
			data.FilenamePostfix = Utilities.TrimQuotes($p.text);
		}
	;
	
runtime_kind_option
	:	t=RUNTIME_KIND EQUAL (s=RTK_SIMPLE | ts=RTK_SIMPLE_THREAD_SAFE | db=RTK_DUAL_BUFFER) 
		{			
			if (s != null)
				data.RuntimeKind = eRuntimeKind.Simple;
			else if (ts != null)
				data.RuntimeKind = eRuntimeKind.SimpleThreadSafe;
			else
				data.RuntimeKind = eRuntimeKind.DualBuffer;
		}
	;
	
option
	:(	files_option
	|	includes_option
	|	output_dir_option
	|	defines_option
	|	runtime_kind_option
	|	filename_postfix_option
	|	real_type_option)
	SEMICOLON
	;
	
option_list
	:	option*
	;
    
project
	:	IDENTIFIER LEFT_BRACE option_list RIGHT_BRACE
	;