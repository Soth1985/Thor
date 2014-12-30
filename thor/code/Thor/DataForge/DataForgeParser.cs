// $ANTLR 3.2 Sep 23, 2009 12:02:23 E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g 2013-07-03 07:26:53

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


	using Thor.DataForge;
	using System.Collections.Generic;
	using System.Globalization;


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;

using IDictionary	= System.Collections.IDictionary;
using Hashtable 	= System.Collections.Hashtable;
public partial class DataForgeParser : Parser
{
    public static readonly string[] tokenNames = new string[] 
	{
        "<invalid>", 
		"<EOR>", 
		"<DOWN>", 
		"<UP>", 
		"CONST", 
		"STRUCT", 
		"ENUM", 
		"IMPORTS", 
		"PACKAGE", 
		"PROFILE", 
		"ENTITY", 
		"LIST", 
		"MAP", 
		"REF", 
		"WEAKREF", 
		"TRUE", 
		"FALSE", 
		"REPLICATED", 
		"RUNTIME_KIND", 
		"RTK_SIMPLE", 
		"RTK_SIMPLE_THREAD_SAFE", 
		"RTK_DUAL_BUFFER", 
		"NOSERIALIZE", 
		"SEMICOLON", 
		"LEFT_ANGLE", 
		"RIGHT_ANGLE", 
		"LEFT_PAREN", 
		"RIGHT_PAREN", 
		"DOT", 
		"COMMA", 
		"COLON", 
		"LEFT_BRACE", 
		"RIGHT_BRACE", 
		"LEFT_BRACKET", 
		"RIGHT_BRACKET", 
		"LEFT_OP", 
		"RIGHT_OP", 
		"AND_OP", 
		"OR_OP", 
		"BANG", 
		"EQUAL", 
		"DASH", 
		"PLUS", 
		"STAR", 
		"SLASH", 
		"PERCENT", 
		"BOOL", 
		"FLOAT", 
		"DOUBLE", 
		"REAL", 
		"INT64", 
		"INT32", 
		"INT16", 
		"INT8", 
		"UINT64", 
		"UINT32", 
		"UINT16", 
		"UINT8", 
		"STRING", 
		"CSTRING", 
		"VEC2", 
		"VEC3", 
		"VEC4", 
		"MAT2X2", 
		"MAT3X3", 
		"MAT4X4", 
		"QUAT", 
		"VEC2F", 
		"VEC3F", 
		"VEC4F", 
		"MAT2X2F", 
		"MAT3X3F", 
		"MAT4X4F", 
		"QUATF", 
		"VEC2D", 
		"VEC3D", 
		"VEC4D", 
		"MAT2X2D", 
		"MAT3X3D", 
		"MAT4X4D", 
		"QUATD", 
		"CPP", 
		"LIB_HEADER", 
		"LIB_MACROS", 
		"LETTER", 
		"DIGIT", 
		"HEX", 
		"EXPONENT", 
		"INTCONSTANT", 
		"EscapeSequence", 
		"STRING_LITERAL", 
		"FLOATCONSTANT", 
		"IDENTIFIER", 
		"WS", 
		"COMMENT", 
		"LINE_COMMENT"
    };

    public const int PACKAGE = 8;
    public const int EXPONENT = 87;
    public const int STAR = 43;
    public const int MAT4X4 = 65;
    public const int LETTER = 84;
    public const int CONST = 4;
    public const int NOSERIALIZE = 22;
    public const int INT8 = 53;
    public const int MAT2X2 = 63;
    public const int VEC4D = 76;
    public const int VEC4F = 69;
    public const int EOF = -1;
    public const int STRING_LITERAL = 90;
    public const int RIGHT_BRACKET = 34;
    public const int UINT16 = 56;
    public const int DOUBLE = 48;
    public const int COMMENT = 94;
    public const int INT16 = 52;
    public const int RIGHT_BRACE = 32;
    public const int OR_OP = 38;
    public const int LINE_COMMENT = 95;
    public const int LIB_HEADER = 82;
    public const int BOOL = 46;
    public const int SEMICOLON = 23;
    public const int LIST = 11;
    public const int UINT64 = 54;
    public const int INT32 = 51;
    public const int QUATD = 80;
    public const int AND_OP = 37;
    public const int REAL = 49;
    public const int RTK_SIMPLE = 19;
    public const int QUATF = 73;
    public const int WS = 93;
    public const int INTCONSTANT = 88;
    public const int FLOATCONSTANT = 91;
    public const int LEFT_PAREN = 26;
    public const int RTK_SIMPLE_THREAD_SAFE = 20;
    public const int IMPORTS = 7;
    public const int CSTRING = 59;
    public const int RIGHT_ANGLE = 25;
    public const int FALSE = 16;
    public const int EscapeSequence = 89;
    public const int UINT8 = 57;
    public const int RTK_DUAL_BUFFER = 21;
    public const int REPLICATED = 17;
    public const int MAT4X4D = 79;
    public const int MAT4X4F = 72;
    public const int MAT3X3 = 64;
    public const int LEFT_BRACKET = 33;
    public const int PROFILE = 9;
    public const int FLOAT = 47;
    public const int ENTITY = 10;
    public const int VEC4 = 62;
    public const int RIGHT_PAREN = 27;
    public const int SLASH = 44;
    public const int COMMA = 29;
    public const int HEX = 86;
    public const int IDENTIFIER = 92;
    public const int EQUAL = 40;
    public const int MAT3X3F = 71;
    public const int QUAT = 66;
    public const int PLUS = 42;
    public const int RIGHT_OP = 36;
    public const int DIGIT = 85;
    public const int DOT = 28;
    public const int MAT3X3D = 78;
    public const int CPP = 81;
    public const int PERCENT = 45;
    public const int DASH = 41;
    public const int VEC2F = 67;
    public const int INT64 = 50;
    public const int VEC2D = 74;
    public const int STRUCT = 5;
    public const int BANG = 39;
    public const int MAT2X2D = 77;
    public const int TRUE = 15;
    public const int MAT2X2F = 70;
    public const int RUNTIME_KIND = 18;
    public const int REF = 13;
    public const int COLON = 30;
    public const int ENUM = 6;
    public const int VEC2 = 60;
    public const int VEC3 = 61;
    public const int VEC3D = 75;
    public const int VEC3F = 68;
    public const int LEFT_BRACE = 31;
    public const int MAP = 12;
    public const int LEFT_OP = 35;
    public const int UINT32 = 55;
    public const int LEFT_ANGLE = 24;
    public const int WEAKREF = 14;
    public const int LIB_MACROS = 83;
    public const int STRING = 58;

    // delegates
    // delegators



        public DataForgeParser(ITokenStream input)
    		: this(input, new RecognizerSharedState()) {
        }

        public DataForgeParser(ITokenStream input, RecognizerSharedState state)
    		: base(input, state) {
            InitializeCyclicDFAs();
            this.state.ruleMemo = new Hashtable[163+1];
             
             
        }
        

    override public string[] TokenNames {
		get { return DataForgeParser.tokenNames; }
    }

    override public string GrammarFileName {
		get { return "E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g"; }
    }


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



    // $ANTLR start "types"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:197:1: types returns [BaseType type] : ( BOOL | FLOAT | DOUBLE | REAL | INT64 | INT32 | INT16 | INT8 | UINT64 | UINT32 | UINT16 | UINT8 | STRING | CSTRING | VEC2 | VEC3 | VEC4 | MAT2X2 | MAT3X3 | MAT4X4 | QUAT | VEC2F | VEC3F | VEC4F | MAT2X2F | MAT3X3F | MAT4X4F | QUATF | VEC2D | VEC3D | VEC4D | MAT2X2D | MAT3X3D | MAT4X4D | QUATD | (pq= IDENTIFIER DOT )* tn= IDENTIFIER );
    public BaseType types() // throws RecognitionException [1]
    {   
        BaseType type = default(BaseType);
        int types_StartIndex = input.Index();
        IToken pq = null;
        IToken tn = null;
        IToken BOOL1 = null;
        IToken FLOAT2 = null;
        IToken DOUBLE3 = null;
        IToken REAL4 = null;
        IToken INT645 = null;
        IToken INT326 = null;
        IToken INT167 = null;
        IToken INT88 = null;
        IToken UINT649 = null;
        IToken UINT3210 = null;
        IToken UINT1611 = null;
        IToken UINT812 = null;
        IToken STRING13 = null;
        IToken CSTRING14 = null;
        IToken VEC215 = null;
        IToken VEC316 = null;
        IToken VEC417 = null;
        IToken MAT2X218 = null;
        IToken MAT3X319 = null;
        IToken MAT4X420 = null;
        IToken QUAT21 = null;
        IToken VEC2F22 = null;
        IToken VEC3F23 = null;
        IToken VEC4F24 = null;
        IToken MAT2X2F25 = null;
        IToken MAT3X3F26 = null;
        IToken MAT4X4F27 = null;
        IToken QUATF28 = null;
        IToken VEC2D29 = null;
        IToken VEC3D30 = null;
        IToken VEC4D31 = null;
        IToken MAT2X2D32 = null;
        IToken MAT3X3D33 = null;
        IToken MAT4X4D34 = null;
        IToken QUATD35 = null;

        type =  new BaseType();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 1) ) 
    	    {
    	    	return type; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:199:2: ( BOOL | FLOAT | DOUBLE | REAL | INT64 | INT32 | INT16 | INT8 | UINT64 | UINT32 | UINT16 | UINT8 | STRING | CSTRING | VEC2 | VEC3 | VEC4 | MAT2X2 | MAT3X3 | MAT4X4 | QUAT | VEC2F | VEC3F | VEC4F | MAT2X2F | MAT3X3F | MAT4X4F | QUATF | VEC2D | VEC3D | VEC4D | MAT2X2D | MAT3X3D | MAT4X4D | QUATD | (pq= IDENTIFIER DOT )* tn= IDENTIFIER )
            int alt2 = 36;
            alt2 = dfa2.Predict(input);
            switch (alt2) 
            {
                case 1 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:199:4: BOOL
                    {
                    	BOOL1=(IToken)Match(input,BOOL,FOLLOW_BOOL_in_types947); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.BOOL; type.Token=BOOL1;
                    	}

                    }
                    break;
                case 2 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:200:4: FLOAT
                    {
                    	FLOAT2=(IToken)Match(input,FLOAT,FOLLOW_FLOAT_in_types954); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.FLOAT; type.Token=FLOAT2;
                    	}

                    }
                    break;
                case 3 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:201:4: DOUBLE
                    {
                    	DOUBLE3=(IToken)Match(input,DOUBLE,FOLLOW_DOUBLE_in_types961); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.DOUBLE; type.Token=DOUBLE3;
                    	}

                    }
                    break;
                case 4 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:202:4: REAL
                    {
                    	REAL4=(IToken)Match(input,REAL,FOLLOW_REAL_in_types968); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.REAL; type.Token=REAL4;
                    	}

                    }
                    break;
                case 5 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:203:4: INT64
                    {
                    	INT645=(IToken)Match(input,INT64,FOLLOW_INT64_in_types975); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.INT64; type.Token=INT645;
                    	}

                    }
                    break;
                case 6 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:204:4: INT32
                    {
                    	INT326=(IToken)Match(input,INT32,FOLLOW_INT32_in_types982); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.INT32; type.Token=INT326;
                    	}

                    }
                    break;
                case 7 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:205:4: INT16
                    {
                    	INT167=(IToken)Match(input,INT16,FOLLOW_INT16_in_types989); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.INT16; type.Token=INT167;
                    	}

                    }
                    break;
                case 8 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:206:4: INT8
                    {
                    	INT88=(IToken)Match(input,INT8,FOLLOW_INT8_in_types996); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.INT8; type.Token=INT88;
                    	}

                    }
                    break;
                case 9 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:207:4: UINT64
                    {
                    	UINT649=(IToken)Match(input,UINT64,FOLLOW_UINT64_in_types1003); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.UINT64; type.Token=UINT649;
                    	}

                    }
                    break;
                case 10 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:208:4: UINT32
                    {
                    	UINT3210=(IToken)Match(input,UINT32,FOLLOW_UINT32_in_types1010); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.UINT32; type.Token=UINT3210;
                    	}

                    }
                    break;
                case 11 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:209:4: UINT16
                    {
                    	UINT1611=(IToken)Match(input,UINT16,FOLLOW_UINT16_in_types1017); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.UINT16; type.Token=UINT1611;
                    	}

                    }
                    break;
                case 12 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:210:4: UINT8
                    {
                    	UINT812=(IToken)Match(input,UINT8,FOLLOW_UINT8_in_types1024); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.UINT8; type.Token=UINT812;
                    	}

                    }
                    break;
                case 13 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:211:4: STRING
                    {
                    	STRING13=(IToken)Match(input,STRING,FOLLOW_STRING_in_types1031); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.STRING; type.Token=STRING13;
                    	}

                    }
                    break;
                case 14 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:212:4: CSTRING
                    {
                    	CSTRING14=(IToken)Match(input,CSTRING,FOLLOW_CSTRING_in_types1038); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.CSTRING; type.Token=CSTRING14;
                    	}

                    }
                    break;
                case 15 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:213:4: VEC2
                    {
                    	VEC215=(IToken)Match(input,VEC2,FOLLOW_VEC2_in_types1045); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.VEC2; type.Token=VEC215;
                    	}

                    }
                    break;
                case 16 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:214:4: VEC3
                    {
                    	VEC316=(IToken)Match(input,VEC3,FOLLOW_VEC3_in_types1052); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.VEC3; type.Token=VEC316;
                    	}

                    }
                    break;
                case 17 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:215:4: VEC4
                    {
                    	VEC417=(IToken)Match(input,VEC4,FOLLOW_VEC4_in_types1059); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.VEC4; type.Token=VEC417;
                    	}

                    }
                    break;
                case 18 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:216:4: MAT2X2
                    {
                    	MAT2X218=(IToken)Match(input,MAT2X2,FOLLOW_MAT2X2_in_types1066); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.MAT2X2; type.Token=MAT2X218;
                    	}

                    }
                    break;
                case 19 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:217:4: MAT3X3
                    {
                    	MAT3X319=(IToken)Match(input,MAT3X3,FOLLOW_MAT3X3_in_types1073); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.MAT3X3; type.Token=MAT3X319;
                    	}

                    }
                    break;
                case 20 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:218:4: MAT4X4
                    {
                    	MAT4X420=(IToken)Match(input,MAT4X4,FOLLOW_MAT4X4_in_types1080); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.MAT4X4; type.Token=MAT4X420;
                    	}

                    }
                    break;
                case 21 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:219:4: QUAT
                    {
                    	QUAT21=(IToken)Match(input,QUAT,FOLLOW_QUAT_in_types1087); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.QUAT; type.Token=QUAT21;
                    	}

                    }
                    break;
                case 22 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:220:4: VEC2F
                    {
                    	VEC2F22=(IToken)Match(input,VEC2F,FOLLOW_VEC2F_in_types1094); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.VEC2F; type.Token=VEC2F22;
                    	}

                    }
                    break;
                case 23 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:221:4: VEC3F
                    {
                    	VEC3F23=(IToken)Match(input,VEC3F,FOLLOW_VEC3F_in_types1101); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.VEC3F; type.Token=VEC3F23;
                    	}

                    }
                    break;
                case 24 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:222:4: VEC4F
                    {
                    	VEC4F24=(IToken)Match(input,VEC4F,FOLLOW_VEC4F_in_types1108); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.VEC4F; type.Token=VEC4F24;
                    	}

                    }
                    break;
                case 25 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:223:4: MAT2X2F
                    {
                    	MAT2X2F25=(IToken)Match(input,MAT2X2F,FOLLOW_MAT2X2F_in_types1115); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.MAT2X2F; type.Token=MAT2X2F25;
                    	}

                    }
                    break;
                case 26 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:224:4: MAT3X3F
                    {
                    	MAT3X3F26=(IToken)Match(input,MAT3X3F,FOLLOW_MAT3X3F_in_types1122); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.MAT3X3F; type.Token=MAT3X3F26;
                    	}

                    }
                    break;
                case 27 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:225:4: MAT4X4F
                    {
                    	MAT4X4F27=(IToken)Match(input,MAT4X4F,FOLLOW_MAT4X4F_in_types1129); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.MAT4X4F; type.Token=MAT4X4F27;
                    	}

                    }
                    break;
                case 28 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:226:4: QUATF
                    {
                    	QUATF28=(IToken)Match(input,QUATF,FOLLOW_QUATF_in_types1136); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.QUATF; type.Token=QUATF28;
                    	}

                    }
                    break;
                case 29 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:227:4: VEC2D
                    {
                    	VEC2D29=(IToken)Match(input,VEC2D,FOLLOW_VEC2D_in_types1143); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.VEC2D; type.Token=VEC2D29;
                    	}

                    }
                    break;
                case 30 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:228:4: VEC3D
                    {
                    	VEC3D30=(IToken)Match(input,VEC3D,FOLLOW_VEC3D_in_types1150); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.VEC3D; type.Token=VEC3D30;
                    	}

                    }
                    break;
                case 31 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:229:4: VEC4D
                    {
                    	VEC4D31=(IToken)Match(input,VEC4D,FOLLOW_VEC4D_in_types1157); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.VEC4D; type.Token=VEC4D31;
                    	}

                    }
                    break;
                case 32 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:230:4: MAT2X2D
                    {
                    	MAT2X2D32=(IToken)Match(input,MAT2X2D,FOLLOW_MAT2X2D_in_types1164); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.MAT2X2D; type.Token=MAT2X2D32;
                    	}

                    }
                    break;
                case 33 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:231:4: MAT3X3D
                    {
                    	MAT3X3D33=(IToken)Match(input,MAT3X3D,FOLLOW_MAT3X3D_in_types1171); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.MAT3X3D; type.Token=MAT3X3D33;
                    	}

                    }
                    break;
                case 34 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:232:4: MAT4X4D
                    {
                    	MAT4X4D34=(IToken)Match(input,MAT4X4D,FOLLOW_MAT4X4D_in_types1178); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.MAT4X4D; type.Token=MAT4X4D34;
                    	}

                    }
                    break;
                case 35 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:233:4: QUATD
                    {
                    	QUATD35=(IToken)Match(input,QUATD,FOLLOW_QUATD_in_types1185); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.QUATD; type.Token=QUATD35;
                    	}

                    }
                    break;
                case 36 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:235:4: (pq= IDENTIFIER DOT )* tn= IDENTIFIER
                    {
                    	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:235:4: (pq= IDENTIFIER DOT )*
                    	do 
                    	{
                    	    int alt1 = 2;
                    	    int LA1_0 = input.LA(1);

                    	    if ( (LA1_0 == IDENTIFIER) )
                    	    {
                    	        int LA1_1 = input.LA(2);

                    	        if ( (LA1_1 == DOT) )
                    	        {
                    	            alt1 = 1;
                    	        }


                    	    }


                    	    switch (alt1) 
                    		{
                    			case 1 :
                    			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:235:5: pq= IDENTIFIER DOT
                    			    {
                    			    	pq=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_types1197); if (state.failed) return type;
                    			    	Match(input,DOT,FOLLOW_DOT_in_types1199); if (state.failed) return type;
                    			    	if ( (state.backtracking==0) )
                    			    	{
                    			    	  type.PackageNameQualifier = pq.Text;
                    			    	}

                    			    }
                    			    break;

                    			default:
                    			    goto loop1;
                    	    }
                    	} while (true);

                    	loop1:
                    		;	// Stops C# compiler whining that label 'loop1' has no statements

                    	tn=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_types1207); if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type.Type=eType.CUSTOM; type.Token=tn;
                    	}

                    }
                    break;

            }
        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 1, types_StartIndex); 
            }
        }
        return type;
    }
    // $ANTLR end "types"


    // $ANTLR start "string_list"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:238:1: string_list returns [List<string> strings] : str1= STRING_LITERAL ( COMMA str2= STRING_LITERAL )* ;
    public List<string> string_list() // throws RecognitionException [1]
    {   
        List<string> strings = default(List<string>);
        int string_list_StartIndex = input.Index();
        IToken str1 = null;
        IToken str2 = null;

        strings =  new List<string>();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 2) ) 
    	    {
    	    	return strings; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:240:2: (str1= STRING_LITERAL ( COMMA str2= STRING_LITERAL )* )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:240:4: str1= STRING_LITERAL ( COMMA str2= STRING_LITERAL )*
            {
            	str1=(IToken)Match(input,STRING_LITERAL,FOLLOW_STRING_LITERAL_in_string_list1230); if (state.failed) return strings;
            	if ( (state.backtracking==0) )
            	{
            	  strings.Add( Utilities.TrimQuotes( ((str1 != null) ? str1.Text : null) ) );
            	}
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:241:3: ( COMMA str2= STRING_LITERAL )*
            	do 
            	{
            	    int alt3 = 2;
            	    int LA3_0 = input.LA(1);

            	    if ( (LA3_0 == COMMA) )
            	    {
            	        alt3 = 1;
            	    }


            	    switch (alt3) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:241:4: COMMA str2= STRING_LITERAL
            			    {
            			    	Match(input,COMMA,FOLLOW_COMMA_in_string_list1238); if (state.failed) return strings;
            			    	str2=(IToken)Match(input,STRING_LITERAL,FOLLOW_STRING_LITERAL_in_string_list1242); if (state.failed) return strings;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	  strings.Add( Utilities.TrimQuotes( ((str2 != null) ? str2.Text : null) ) );
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop3;
            	    }
            	} while (true);

            	loop3:
            		;	// Stops C# compiler whining that label 'loop3' has no statements


            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 2, string_list_StartIndex); 
            }
        }
        return strings;
    }
    // $ANTLR end "string_list"


    // $ANTLR start "package_identifier"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:244:1: package_identifier returns [List<string> strings] : str1= IDENTIFIER ( DOT str2= IDENTIFIER )* ;
    public List<string> package_identifier() // throws RecognitionException [1]
    {   
        List<string> strings = default(List<string>);
        int package_identifier_StartIndex = input.Index();
        IToken str1 = null;
        IToken str2 = null;

        strings =  new List<string>();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 3) ) 
    	    {
    	    	return strings; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:246:2: (str1= IDENTIFIER ( DOT str2= IDENTIFIER )* )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:246:5: str1= IDENTIFIER ( DOT str2= IDENTIFIER )*
            {
            	str1=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_package_identifier1268); if (state.failed) return strings;
            	if ( (state.backtracking==0) )
            	{
            	  strings.Add(((str1 != null) ? str1.Text : null));
            	}
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:247:3: ( DOT str2= IDENTIFIER )*
            	do 
            	{
            	    int alt4 = 2;
            	    int LA4_0 = input.LA(1);

            	    if ( (LA4_0 == DOT) )
            	    {
            	        alt4 = 1;
            	    }


            	    switch (alt4) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:247:4: DOT str2= IDENTIFIER
            			    {
            			    	Match(input,DOT,FOLLOW_DOT_in_package_identifier1275); if (state.failed) return strings;
            			    	str2=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_package_identifier1279); if (state.failed) return strings;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	  strings.Add(((str2 != null) ? str2.Text : null));
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop4;
            	    }
            	} while (true);

            	loop4:
            		;	// Stops C# compiler whining that label 'loop4' has no statements


            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 3, package_identifier_StartIndex); 
            }
        }
        return strings;
    }
    // $ANTLR end "package_identifier"


    // $ANTLR start "imports"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:250:1: imports : IMPORTS LEFT_BRACE sl= string_list RIGHT_BRACE ;
    public void imports() // throws RecognitionException [1]
    {   
        int imports_StartIndex = input.Index();
        List<string> sl = default(List<string>);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 4) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:251:2: ( IMPORTS LEFT_BRACE sl= string_list RIGHT_BRACE )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:251:4: IMPORTS LEFT_BRACE sl= string_list RIGHT_BRACE
            {
            	Match(input,IMPORTS,FOLLOW_IMPORTS_in_imports1295); if (state.failed) return ;
            	Match(input,LEFT_BRACE,FOLLOW_LEFT_BRACE_in_imports1297); if (state.failed) return ;
            	PushFollow(FOLLOW_string_list_in_imports1301);
            	sl = string_list();
            	state.followingStackPointer--;
            	if (state.failed) return ;
            	Match(input,RIGHT_BRACE,FOLLOW_RIGHT_BRACE_in_imports1303); if (state.failed) return ;
            	if ( (state.backtracking==0) )
            	{

            	  			foreach(var s in sl)
            	  			{
            	  				string curFile = compiler.CurrentFile;
            	  				compiler.ParseFile(s);
            	  				compiler.AddImportedFile(curFile, compiler.GetFilePath(s));
            	  			}
            	  		
            	}

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 4, imports_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "imports"


    // $ANTLR start "lib_header_option"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:263:1: lib_header_option : LIB_HEADER EQUAL ho= STRING_LITERAL SEMICOLON ;
    public void lib_header_option() // throws RecognitionException [1]
    {   
        int lib_header_option_StartIndex = input.Index();
        IToken ho = null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 5) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:264:2: ( LIB_HEADER EQUAL ho= STRING_LITERAL SEMICOLON )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:264:4: LIB_HEADER EQUAL ho= STRING_LITERAL SEMICOLON
            {
            	Match(input,LIB_HEADER,FOLLOW_LIB_HEADER_in_lib_header_option1321); if (state.failed) return ;
            	Match(input,EQUAL,FOLLOW_EQUAL_in_lib_header_option1323); if (state.failed) return ;
            	ho=(IToken)Match(input,STRING_LITERAL,FOLLOW_STRING_LITERAL_in_lib_header_option1327); if (state.failed) return ;
            	Match(input,SEMICOLON,FOLLOW_SEMICOLON_in_lib_header_option1329); if (state.failed) return ;
            	if ( (state.backtracking==0) )
            	{

            	  			GeneratedFileDesc desc = Compiler.Instance.GetGeneratedFileDesc(Compiler.Instance.CurrentFile);
            	  			desc.LibHeader = Utilities.TrimQuotes(ho.Text);
            	  		
            	}

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 5, lib_header_option_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "lib_header_option"


    // $ANTLR start "lib_macros_option"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:271:1: lib_macros_option : LIB_MACROS EQUAL m= STRING_LITERAL SEMICOLON ;
    public void lib_macros_option() // throws RecognitionException [1]
    {   
        int lib_macros_option_StartIndex = input.Index();
        IToken m = null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 6) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:272:2: ( LIB_MACROS EQUAL m= STRING_LITERAL SEMICOLON )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:272:4: LIB_MACROS EQUAL m= STRING_LITERAL SEMICOLON
            {
            	Match(input,LIB_MACROS,FOLLOW_LIB_MACROS_in_lib_macros_option1345); if (state.failed) return ;
            	Match(input,EQUAL,FOLLOW_EQUAL_in_lib_macros_option1347); if (state.failed) return ;
            	m=(IToken)Match(input,STRING_LITERAL,FOLLOW_STRING_LITERAL_in_lib_macros_option1351); if (state.failed) return ;
            	Match(input,SEMICOLON,FOLLOW_SEMICOLON_in_lib_macros_option1353); if (state.failed) return ;
            	if ( (state.backtracking==0) )
            	{

            	  			GeneratedFileDesc desc = Compiler.Instance.GetGeneratedFileDesc(Compiler.Instance.CurrentFile);
            	  			desc.LibMacros = Utilities.TrimQuotes(m.Text);
            	  		
            	}

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 6, lib_macros_option_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "lib_macros_option"


    // $ANTLR start "lib_option"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:279:1: lib_option : lib_header_option lib_macros_option ;
    public void lib_option() // throws RecognitionException [1]
    {   
        int lib_option_StartIndex = input.Index();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 7) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:280:2: ( lib_header_option lib_macros_option )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:280:4: lib_header_option lib_macros_option
            {
            	PushFollow(FOLLOW_lib_header_option_in_lib_option1369);
            	lib_header_option();
            	state.followingStackPointer--;
            	if (state.failed) return ;
            	PushFollow(FOLLOW_lib_macros_option_in_lib_option1371);
            	lib_macros_option();
            	state.followingStackPointer--;
            	if (state.failed) return ;

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 7, lib_option_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "lib_option"


    // $ANTLR start "cpp"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:283:1: cpp : CPP LEFT_BRACE lib_option RIGHT_BRACE ;
    public void cpp() // throws RecognitionException [1]
    {   
        int cpp_StartIndex = input.Index();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 8) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:284:2: ( CPP LEFT_BRACE lib_option RIGHT_BRACE )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:285:3: CPP LEFT_BRACE lib_option RIGHT_BRACE
            {
            	Match(input,CPP,FOLLOW_CPP_in_cpp1385); if (state.failed) return ;
            	Match(input,LEFT_BRACE,FOLLOW_LEFT_BRACE_in_cpp1387); if (state.failed) return ;
            	PushFollow(FOLLOW_lib_option_in_cpp1389);
            	lib_option();
            	state.followingStackPointer--;
            	if (state.failed) return ;
            	Match(input,RIGHT_BRACE,FOLLOW_RIGHT_BRACE_in_cpp1391); if (state.failed) return ;

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 8, cpp_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "cpp"


    // $ANTLR start "package_rule"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:288:1: package_rule : PACKAGE p= package_identifier SEMICOLON ;
    public void package_rule() // throws RecognitionException [1]
    {   
        int package_rule_StartIndex = input.Index();
        List<string> p = default(List<string>);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 9) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:289:2: ( PACKAGE p= package_identifier SEMICOLON )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:289:4: PACKAGE p= package_identifier SEMICOLON
            {
            	Match(input,PACKAGE,FOLLOW_PACKAGE_in_package_rule1402); if (state.failed) return ;
            	PushFollow(FOLLOW_package_identifier_in_package_rule1406);
            	p = package_identifier();
            	state.followingStackPointer--;
            	if (state.failed) return ;
            	Match(input,SEMICOLON,FOLLOW_SEMICOLON_in_package_rule1408); if (state.failed) return ;
            	if ( (state.backtracking==0) )
            	{

            	  			compiler.CurrentPackage = compiler.RootPackage.AddChildPackage(p);			
            	  		
            	}

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 9, package_rule_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "package_rule"


    // $ANTLR start "enum_specifier"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:295:1: enum_specifier : ENUM id= IDENTIFIER LEFT_BRACE enum_declaration_list[ed] RIGHT_BRACE ;
    public void enum_specifier() // throws RecognitionException [1]
    {   
        int enum_specifier_StartIndex = input.Index();
        IToken id = null;

        EnumDeclaration ed=new EnumDeclaration();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 10) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:297:2: ( ENUM id= IDENTIFIER LEFT_BRACE enum_declaration_list[ed] RIGHT_BRACE )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:297:4: ENUM id= IDENTIFIER LEFT_BRACE enum_declaration_list[ed] RIGHT_BRACE
            {
            	Match(input,ENUM,FOLLOW_ENUM_in_enum_specifier1427); if (state.failed) return ;
            	id=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_enum_specifier1431); if (state.failed) return ;
            	if ( (state.backtracking==0) )
            	{
            	  ed.Token=id;
            	}
            	Match(input,LEFT_BRACE,FOLLOW_LEFT_BRACE_in_enum_specifier1435); if (state.failed) return ;
            	PushFollow(FOLLOW_enum_declaration_list_in_enum_specifier1440);
            	enum_declaration_list(ed);
            	state.followingStackPointer--;
            	if (state.failed) return ;
            	if ( (state.backtracking==0) )
            	{
            	  			
            	  			compiler.CurrentPackage.AddEnumeration(ed);
            	  		
            	}
            	Match(input,RIGHT_BRACE,FOLLOW_RIGHT_BRACE_in_enum_specifier1450); if (state.failed) return ;

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 10, enum_specifier_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "enum_specifier"


    // $ANTLR start "enum_declaration_list"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:305:1: enum_declaration_list[EnumDeclaration ed] : edecl1= enum_declaration ( COMMA edecl2= enum_declaration )* ;
    public void enum_declaration_list(EnumDeclaration ed) // throws RecognitionException [1]
    {   
        int enum_declaration_list_StartIndex = input.Index();
        DataForgeParser.enum_declaration_return edecl1 = default(DataForgeParser.enum_declaration_return);

        DataForgeParser.enum_declaration_return edecl2 = default(DataForgeParser.enum_declaration_return);


        int enumValue=-1;
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 11) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:307:2: (edecl1= enum_declaration ( COMMA edecl2= enum_declaration )* )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:307:4: edecl1= enum_declaration ( COMMA edecl2= enum_declaration )*
            {
            	PushFollow(FOLLOW_enum_declaration_in_enum_declaration_list1469);
            	edecl1 = enum_declaration();
            	state.followingStackPointer--;
            	if (state.failed) return ;
            	if ( (state.backtracking==0) )
            	{
            	  ProcessEnumItemDecl(ed,((edecl1 != null) ? edecl1.name : default(string)),((edecl1 != null) ? edecl1.val : default(int)),((edecl1 != null) ? edecl1.token : default(IToken)),ref enumValue);
            	}
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:308:3: ( COMMA edecl2= enum_declaration )*
            	do 
            	{
            	    int alt5 = 2;
            	    int LA5_0 = input.LA(1);

            	    if ( (LA5_0 == COMMA) )
            	    {
            	        alt5 = 1;
            	    }


            	    switch (alt5) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:309:4: COMMA edecl2= enum_declaration
            			    {
            			    	Match(input,COMMA,FOLLOW_COMMA_in_enum_declaration_list1480); if (state.failed) return ;
            			    	PushFollow(FOLLOW_enum_declaration_in_enum_declaration_list1484);
            			    	edecl2 = enum_declaration();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return ;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	  ProcessEnumItemDecl(ed,((edecl2 != null) ? edecl2.name : default(string)),((edecl2 != null) ? edecl2.val : default(int)),((edecl2 != null) ? edecl2.token : default(IToken)),ref enumValue);
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop5;
            	    }
            	} while (true);

            	loop5:
            		;	// Stops C# compiler whining that label 'loop5' has no statements


            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 11, enum_declaration_list_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "enum_declaration_list"

    public class enum_declaration_return : ParserRuleReturnScope
    {
        public string name;
        public int val;
        public IToken token;
    };

    // $ANTLR start "enum_declaration"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:312:1: enum_declaration returns [string name, int val, IToken token] : (i= IDENTIFIER | i= IDENTIFIER EQUAL c1= INTCONSTANT ( (lo= LEFT_OP | ro= RIGHT_OP ) c2= INTCONSTANT )? );
    public DataForgeParser.enum_declaration_return enum_declaration() // throws RecognitionException [1]
    {   
        DataForgeParser.enum_declaration_return retval = new DataForgeParser.enum_declaration_return();
        retval.Start = input.LT(1);
        int enum_declaration_StartIndex = input.Index();
        IToken i = null;
        IToken c1 = null;
        IToken lo = null;
        IToken ro = null;
        IToken c2 = null;

        retval.val = -1;
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 12) ) 
    	    {
    	    	return retval; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:314:2: (i= IDENTIFIER | i= IDENTIFIER EQUAL c1= INTCONSTANT ( (lo= LEFT_OP | ro= RIGHT_OP ) c2= INTCONSTANT )? )
            int alt8 = 2;
            int LA8_0 = input.LA(1);

            if ( (LA8_0 == IDENTIFIER) )
            {
                int LA8_1 = input.LA(2);

                if ( (LA8_1 == EQUAL) )
                {
                    alt8 = 2;
                }
                else if ( (LA8_1 == EOF || LA8_1 == COMMA || LA8_1 == RIGHT_BRACE) )
                {
                    alt8 = 1;
                }
                else 
                {
                    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
                    NoViableAltException nvae_d8s1 =
                        new NoViableAltException("", 8, 1, input);

                    throw nvae_d8s1;
                }
            }
            else 
            {
                if ( state.backtracking > 0 ) {state.failed = true; return retval;}
                NoViableAltException nvae_d8s0 =
                    new NoViableAltException("", 8, 0, input);

                throw nvae_d8s0;
            }
            switch (alt8) 
            {
                case 1 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:314:4: i= IDENTIFIER
                    {
                    	i=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_enum_declaration1513); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{
                    	  retval.name = ((i != null) ? i.Text : null); retval.val = -1; retval.token = i;
                    	}

                    }
                    break;
                case 2 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:315:4: i= IDENTIFIER EQUAL c1= INTCONSTANT ( (lo= LEFT_OP | ro= RIGHT_OP ) c2= INTCONSTANT )?
                    {
                    	i=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_enum_declaration1527); if (state.failed) return retval;
                    	Match(input,EQUAL,FOLLOW_EQUAL_in_enum_declaration1529); if (state.failed) return retval;
                    	c1=(IToken)Match(input,INTCONSTANT,FOLLOW_INTCONSTANT_in_enum_declaration1533); if (state.failed) return retval;
                    	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:315:38: ( (lo= LEFT_OP | ro= RIGHT_OP ) c2= INTCONSTANT )?
                    	int alt7 = 2;
                    	int LA7_0 = input.LA(1);

                    	if ( ((LA7_0 >= LEFT_OP && LA7_0 <= RIGHT_OP)) )
                    	{
                    	    alt7 = 1;
                    	}
                    	switch (alt7) 
                    	{
                    	    case 1 :
                    	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:315:39: (lo= LEFT_OP | ro= RIGHT_OP ) c2= INTCONSTANT
                    	        {
                    	        	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:315:39: (lo= LEFT_OP | ro= RIGHT_OP )
                    	        	int alt6 = 2;
                    	        	int LA6_0 = input.LA(1);

                    	        	if ( (LA6_0 == LEFT_OP) )
                    	        	{
                    	        	    alt6 = 1;
                    	        	}
                    	        	else if ( (LA6_0 == RIGHT_OP) )
                    	        	{
                    	        	    alt6 = 2;
                    	        	}
                    	        	else 
                    	        	{
                    	        	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
                    	        	    NoViableAltException nvae_d6s0 =
                    	        	        new NoViableAltException("", 6, 0, input);

                    	        	    throw nvae_d6s0;
                    	        	}
                    	        	switch (alt6) 
                    	        	{
                    	        	    case 1 :
                    	        	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:315:40: lo= LEFT_OP
                    	        	        {
                    	        	        	lo=(IToken)Match(input,LEFT_OP,FOLLOW_LEFT_OP_in_enum_declaration1539); if (state.failed) return retval;

                    	        	        }
                    	        	        break;
                    	        	    case 2 :
                    	        	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:315:53: ro= RIGHT_OP
                    	        	        {
                    	        	        	ro=(IToken)Match(input,RIGHT_OP,FOLLOW_RIGHT_OP_in_enum_declaration1545); if (state.failed) return retval;

                    	        	        }
                    	        	        break;

                    	        	}

                    	        	c2=(IToken)Match(input,INTCONSTANT,FOLLOW_INTCONSTANT_in_enum_declaration1550); if (state.failed) return retval;

                    	        }
                    	        break;

                    	}

                    	if ( (state.backtracking==0) )
                    	{

                    	  			retval.name = ((i != null) ? i.Text : null);			
                    	  			retval.token = i;
                    	  			int shiftVal = Int32.Parse(((c1 != null) ? c1.Text : null), CultureInfo.InvariantCulture);
                    	  			retval.val = shiftVal;
                    	  			
                    	  			if(lo!=null || ro!=null)
                    	  			{
                    	  				int bitsToShift = Int32.Parse(((c2 != null) ? c2.Text : null), CultureInfo.InvariantCulture);
                    	  			
                    	  				if(lo!=null)
                    	  					retval.val =  shiftVal << bitsToShift;
                    	  				else
                    	  					retval.val =  shiftVal >> bitsToShift;
                    	  			}
                    	  		
                    	}

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 12, enum_declaration_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "enum_declaration"


    // $ANTLR start "enum_field"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:334:1: enum_field returns [EnumConstant enumConst] : (pq= IDENTIFIER DOT )* ename= IDENTIFIER COLON COLON eval= IDENTIFIER ;
    public EnumConstant enum_field() // throws RecognitionException [1]
    {   
        EnumConstant enumConst = default(EnumConstant);
        int enum_field_StartIndex = input.Index();
        IToken pq = null;
        IToken ename = null;
        IToken eval = null;

        enumConst =  new EnumConstant();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 13) ) 
    	    {
    	    	return enumConst; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:336:2: ( (pq= IDENTIFIER DOT )* ename= IDENTIFIER COLON COLON eval= IDENTIFIER )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:336:4: (pq= IDENTIFIER DOT )* ename= IDENTIFIER COLON COLON eval= IDENTIFIER
            {
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:336:4: (pq= IDENTIFIER DOT )*
            	do 
            	{
            	    int alt9 = 2;
            	    int LA9_0 = input.LA(1);

            	    if ( (LA9_0 == IDENTIFIER) )
            	    {
            	        int LA9_1 = input.LA(2);

            	        if ( (LA9_1 == DOT) )
            	        {
            	            alt9 = 1;
            	        }


            	    }


            	    switch (alt9) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:336:5: pq= IDENTIFIER DOT
            			    {
            			    	pq=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_enum_field1578); if (state.failed) return enumConst;
            			    	Match(input,DOT,FOLLOW_DOT_in_enum_field1580); if (state.failed) return enumConst;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	  enumConst.PackageNameQualifier = pq.Text;
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop9;
            	    }
            	} while (true);

            	loop9:
            		;	// Stops C# compiler whining that label 'loop9' has no statements

            	ename=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_enum_field1588); if (state.failed) return enumConst;
            	Match(input,COLON,FOLLOW_COLON_in_enum_field1590); if (state.failed) return enumConst;
            	Match(input,COLON,FOLLOW_COLON_in_enum_field1592); if (state.failed) return enumConst;
            	eval=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_enum_field1596); if (state.failed) return enumConst;
            	if ( (state.backtracking==0) )
            	{

            	  			enumConst.Token = ename;
            	  			enumConst.TextVal = ((eval != null) ? eval.Text : null);
            	  		
            	}

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 13, enum_field_StartIndex); 
            }
        }
        return enumConst;
    }
    // $ANTLR end "enum_field"


    // $ANTLR start "simple_declaration"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:343:1: simple_declaration returns [DataField field] : t= types id= IDENTIFIER ;
    public DataField simple_declaration() // throws RecognitionException [1]
    {   
        DataField field = default(DataField);
        int simple_declaration_StartIndex = input.Index();
        IToken id = null;
        BaseType t = default(BaseType);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 14) ) 
    	    {
    	    	return field; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:344:2: (t= types id= IDENTIFIER )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:344:4: t= types id= IDENTIFIER
            {
            	PushFollow(FOLLOW_types_in_simple_declaration1616);
            	t = types();
            	state.followingStackPointer--;
            	if (state.failed) return field;
            	id=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_simple_declaration1620); if (state.failed) return field;
            	if ( (state.backtracking==0) )
            	{

            	  			field =  new DataField();
            	  			field.Type=t;
            	  			field.Token=id;
            	  		
            	}

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 14, simple_declaration_StartIndex); 
            }
        }
        return field;
    }
    // $ANTLR end "simple_declaration"


    // $ANTLR start "list_declaration"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:352:1: list_declaration returns [DataField field] : lt= list_type name= IDENTIFIER ;
    public DataField list_declaration() // throws RecognitionException [1]
    {   
        DataField field = default(DataField);
        int list_declaration_StartIndex = input.Index();
        IToken name = null;
        BaseType lt = default(BaseType);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 15) ) 
    	    {
    	    	return field; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:353:2: (lt= list_type name= IDENTIFIER )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:353:4: lt= list_type name= IDENTIFIER
            {
            	PushFollow(FOLLOW_list_type_in_list_declaration1640);
            	lt = list_type();
            	state.followingStackPointer--;
            	if (state.failed) return field;
            	name=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_list_declaration1644); if (state.failed) return field;
            	if ( (state.backtracking==0) )
            	{

            	  			field =  new DataField();			
            	  			field.Type=lt;
            	  			field.Token=name;
            	  		
            	}

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 15, list_declaration_StartIndex); 
            }
        }
        return field;
    }
    // $ANTLR end "list_declaration"


    // $ANTLR start "list_type"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:361:1: list_type returns [BaseType type] : LIST LEFT_ANGLE (subT= subcontainer_types | valT= types ) RIGHT_ANGLE ;
    public BaseType list_type() // throws RecognitionException [1]
    {   
        BaseType type = default(BaseType);
        int list_type_StartIndex = input.Index();
        IToken LIST36 = null;
        BaseType subT = default(BaseType);

        BaseType valT = default(BaseType);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 16) ) 
    	    {
    	    	return type; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:362:2: ( LIST LEFT_ANGLE (subT= subcontainer_types | valT= types ) RIGHT_ANGLE )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:362:4: LIST LEFT_ANGLE (subT= subcontainer_types | valT= types ) RIGHT_ANGLE
            {
            	LIST36=(IToken)Match(input,LIST,FOLLOW_LIST_in_list_type1663); if (state.failed) return type;
            	Match(input,LEFT_ANGLE,FOLLOW_LEFT_ANGLE_in_list_type1665); if (state.failed) return type;
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:362:20: (subT= subcontainer_types | valT= types )
            	int alt10 = 2;
            	alt10 = dfa10.Predict(input);
            	switch (alt10) 
            	{
            	    case 1 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:362:21: subT= subcontainer_types
            	        {
            	        	PushFollow(FOLLOW_subcontainer_types_in_list_type1670);
            	        	subT = subcontainer_types();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return type;

            	        }
            	        break;
            	    case 2 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:362:47: valT= types
            	        {
            	        	PushFollow(FOLLOW_types_in_list_type1676);
            	        	valT = types();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return type;

            	        }
            	        break;

            	}

            	Match(input,RIGHT_ANGLE,FOLLOW_RIGHT_ANGLE_in_list_type1679); if (state.failed) return type;
            	if ( (state.backtracking==0) )
            	{

            	  			ListType listType = new ListType();
            	  			
            	  			if(subT!=null)
            	  				listType.ContainedType = subT;
            	  				
            	  			if(valT!=null)
            	  				listType.ContainedType = valT;
            	  				
            	  			listType.Token=LIST36;
            	  			type =  listType;
            	  		
            	}

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 16, list_type_StartIndex); 
            }
        }
        return type;
    }
    // $ANTLR end "list_type"


    // $ANTLR start "map_type"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:377:1: map_type returns [BaseType type] : MAP LEFT_ANGLE keyT= types COMMA (subT= subcontainer_types | valT= types ) RIGHT_ANGLE ;
    public BaseType map_type() // throws RecognitionException [1]
    {   
        BaseType type = default(BaseType);
        int map_type_StartIndex = input.Index();
        IToken MAP37 = null;
        BaseType keyT = default(BaseType);

        BaseType subT = default(BaseType);

        BaseType valT = default(BaseType);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 17) ) 
    	    {
    	    	return type; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:378:2: ( MAP LEFT_ANGLE keyT= types COMMA (subT= subcontainer_types | valT= types ) RIGHT_ANGLE )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:378:4: MAP LEFT_ANGLE keyT= types COMMA (subT= subcontainer_types | valT= types ) RIGHT_ANGLE
            {
            	MAP37=(IToken)Match(input,MAP,FOLLOW_MAP_in_map_type1698); if (state.failed) return type;
            	Match(input,LEFT_ANGLE,FOLLOW_LEFT_ANGLE_in_map_type1700); if (state.failed) return type;
            	PushFollow(FOLLOW_types_in_map_type1704);
            	keyT = types();
            	state.followingStackPointer--;
            	if (state.failed) return type;
            	Match(input,COMMA,FOLLOW_COMMA_in_map_type1706); if (state.failed) return type;
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:378:36: (subT= subcontainer_types | valT= types )
            	int alt11 = 2;
            	alt11 = dfa11.Predict(input);
            	switch (alt11) 
            	{
            	    case 1 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:378:37: subT= subcontainer_types
            	        {
            	        	PushFollow(FOLLOW_subcontainer_types_in_map_type1711);
            	        	subT = subcontainer_types();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return type;

            	        }
            	        break;
            	    case 2 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:378:63: valT= types
            	        {
            	        	PushFollow(FOLLOW_types_in_map_type1717);
            	        	valT = types();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return type;

            	        }
            	        break;

            	}

            	Match(input,RIGHT_ANGLE,FOLLOW_RIGHT_ANGLE_in_map_type1720); if (state.failed) return type;
            	if ( (state.backtracking==0) )
            	{

            	  			MapType mapType = new MapType();
            	  			mapType.KeyType = keyT;
            	  			
            	  			if (subT != null)
            	  				mapType.ValueType = subT;
            	  				
            	  			if (valT != null)
            	  				mapType.ValueType = valT;
            	  				
            	  			mapType.Token=MAP37;
            	  			type = mapType;
            	  		
            	}

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 17, map_type_StartIndex); 
            }
        }
        return type;
    }
    // $ANTLR end "map_type"


    // $ANTLR start "reference_type"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:394:1: reference_type returns [BaseType type] : REF LEFT_ANGLE t= types RIGHT_ANGLE ;
    public BaseType reference_type() // throws RecognitionException [1]
    {   
        BaseType type = default(BaseType);
        int reference_type_StartIndex = input.Index();
        IToken REF38 = null;
        BaseType t = default(BaseType);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 18) ) 
    	    {
    	    	return type; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:395:2: ( REF LEFT_ANGLE t= types RIGHT_ANGLE )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:395:4: REF LEFT_ANGLE t= types RIGHT_ANGLE
            {
            	REF38=(IToken)Match(input,REF,FOLLOW_REF_in_reference_type1739); if (state.failed) return type;
            	Match(input,LEFT_ANGLE,FOLLOW_LEFT_ANGLE_in_reference_type1741); if (state.failed) return type;
            	PushFollow(FOLLOW_types_in_reference_type1745);
            	t = types();
            	state.followingStackPointer--;
            	if (state.failed) return type;
            	Match(input,RIGHT_ANGLE,FOLLOW_RIGHT_ANGLE_in_reference_type1747); if (state.failed) return type;
            	if ( (state.backtracking==0) )
            	{

            	  			RefType refType = new RefType();
            	  			refType.ContainedType = t;
            	  			refType.Token=REF38;
            	  			type =  refType;
            	  		
            	}

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 18, reference_type_StartIndex); 
            }
        }
        return type;
    }
    // $ANTLR end "reference_type"


    // $ANTLR start "reference_declaration"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:404:1: reference_declaration returns [DataField field] : rt= reference_type name= IDENTIFIER ;
    public DataField reference_declaration() // throws RecognitionException [1]
    {   
        DataField field = default(DataField);
        int reference_declaration_StartIndex = input.Index();
        IToken name = null;
        BaseType rt = default(BaseType);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 19) ) 
    	    {
    	    	return field; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:405:2: (rt= reference_type name= IDENTIFIER )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:405:4: rt= reference_type name= IDENTIFIER
            {
            	PushFollow(FOLLOW_reference_type_in_reference_declaration1768);
            	rt = reference_type();
            	state.followingStackPointer--;
            	if (state.failed) return field;
            	name=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_reference_declaration1772); if (state.failed) return field;
            	if ( (state.backtracking==0) )
            	{

            	  			field =  new DataField();
            	  			RefType refType = new RefType();
            	  			field.Type=rt;
            	  			field.Token=name;
            	  		
            	}

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 19, reference_declaration_StartIndex); 
            }
        }
        return field;
    }
    // $ANTLR end "reference_declaration"


    // $ANTLR start "weak_reference_type"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:414:1: weak_reference_type returns [BaseType type] : WEAKREF LEFT_ANGLE t= types RIGHT_ANGLE ;
    public BaseType weak_reference_type() // throws RecognitionException [1]
    {   
        BaseType type = default(BaseType);
        int weak_reference_type_StartIndex = input.Index();
        IToken WEAKREF39 = null;
        BaseType t = default(BaseType);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 20) ) 
    	    {
    	    	return type; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:415:2: ( WEAKREF LEFT_ANGLE t= types RIGHT_ANGLE )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:415:4: WEAKREF LEFT_ANGLE t= types RIGHT_ANGLE
            {
            	WEAKREF39=(IToken)Match(input,WEAKREF,FOLLOW_WEAKREF_in_weak_reference_type1791); if (state.failed) return type;
            	Match(input,LEFT_ANGLE,FOLLOW_LEFT_ANGLE_in_weak_reference_type1793); if (state.failed) return type;
            	PushFollow(FOLLOW_types_in_weak_reference_type1797);
            	t = types();
            	state.followingStackPointer--;
            	if (state.failed) return type;
            	Match(input,RIGHT_ANGLE,FOLLOW_RIGHT_ANGLE_in_weak_reference_type1799); if (state.failed) return type;
            	if ( (state.backtracking==0) )
            	{

            	  			WeakRefType refType = new WeakRefType();
            	  			refType.ContainedType = t;
            	  			refType.Token=WEAKREF39;
            	  			type =  refType;
            	  		
            	}

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 20, weak_reference_type_StartIndex); 
            }
        }
        return type;
    }
    // $ANTLR end "weak_reference_type"


    // $ANTLR start "weak_reference_declaration"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:424:1: weak_reference_declaration returns [DataField field] : rt= weak_reference_type name= IDENTIFIER ;
    public DataField weak_reference_declaration() // throws RecognitionException [1]
    {   
        DataField field = default(DataField);
        int weak_reference_declaration_StartIndex = input.Index();
        IToken name = null;
        BaseType rt = default(BaseType);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 21) ) 
    	    {
    	    	return field; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:425:2: (rt= weak_reference_type name= IDENTIFIER )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:425:4: rt= weak_reference_type name= IDENTIFIER
            {
            	PushFollow(FOLLOW_weak_reference_type_in_weak_reference_declaration1820);
            	rt = weak_reference_type();
            	state.followingStackPointer--;
            	if (state.failed) return field;
            	name=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_weak_reference_declaration1824); if (state.failed) return field;
            	if ( (state.backtracking==0) )
            	{

            	  			field =  new DataField();
            	  			WeakRefType refType = new WeakRefType();
            	  			field.Type=rt;
            	  			field.Token=name;
            	  		
            	}

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 21, weak_reference_declaration_StartIndex); 
            }
        }
        return field;
    }
    // $ANTLR end "weak_reference_declaration"


    // $ANTLR start "subcontainer_types"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:434:1: subcontainer_types returns [BaseType type] : (lt= list_type | mt= map_type | rt= reference_type | wt= weak_reference_type );
    public BaseType subcontainer_types() // throws RecognitionException [1]
    {   
        BaseType type = default(BaseType);
        int subcontainer_types_StartIndex = input.Index();
        BaseType lt = default(BaseType);

        BaseType mt = default(BaseType);

        BaseType rt = default(BaseType);

        BaseType wt = default(BaseType);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 22) ) 
    	    {
    	    	return type; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:435:2: (lt= list_type | mt= map_type | rt= reference_type | wt= weak_reference_type )
            int alt12 = 4;
            switch ( input.LA(1) ) 
            {
            case LIST:
            	{
                alt12 = 1;
                }
                break;
            case MAP:
            	{
                alt12 = 2;
                }
                break;
            case REF:
            	{
                alt12 = 3;
                }
                break;
            case WEAKREF:
            	{
                alt12 = 4;
                }
                break;
            	default:
            	    if ( state.backtracking > 0 ) {state.failed = true; return type;}
            	    NoViableAltException nvae_d12s0 =
            	        new NoViableAltException("", 12, 0, input);

            	    throw nvae_d12s0;
            }

            switch (alt12) 
            {
                case 1 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:435:4: lt= list_type
                    {
                    	PushFollow(FOLLOW_list_type_in_subcontainer_types1845);
                    	lt = list_type();
                    	state.followingStackPointer--;
                    	if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type =  lt;
                    	}

                    }
                    break;
                case 2 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:436:4: mt= map_type
                    {
                    	PushFollow(FOLLOW_map_type_in_subcontainer_types1855);
                    	mt = map_type();
                    	state.followingStackPointer--;
                    	if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type =  mt;
                    	}

                    }
                    break;
                case 3 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:437:4: rt= reference_type
                    {
                    	PushFollow(FOLLOW_reference_type_in_subcontainer_types1865);
                    	rt = reference_type();
                    	state.followingStackPointer--;
                    	if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type =  rt;
                    	}

                    }
                    break;
                case 4 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:438:4: wt= weak_reference_type
                    {
                    	PushFollow(FOLLOW_weak_reference_type_in_subcontainer_types1875);
                    	wt = weak_reference_type();
                    	state.followingStackPointer--;
                    	if (state.failed) return type;
                    	if ( (state.backtracking==0) )
                    	{
                    	  type =  wt;
                    	}

                    }
                    break;

            }
        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 22, subcontainer_types_StartIndex); 
            }
        }
        return type;
    }
    // $ANTLR end "subcontainer_types"


    // $ANTLR start "map_declaration"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:441:1: map_declaration returns [DataField field] : t= map_type name= IDENTIFIER ;
    public DataField map_declaration() // throws RecognitionException [1]
    {   
        DataField field = default(DataField);
        int map_declaration_StartIndex = input.Index();
        IToken name = null;
        BaseType t = default(BaseType);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 23) ) 
    	    {
    	    	return field; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:442:2: (t= map_type name= IDENTIFIER )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:442:4: t= map_type name= IDENTIFIER
            {
            	PushFollow(FOLLOW_map_type_in_map_declaration1893);
            	t = map_type();
            	state.followingStackPointer--;
            	if (state.failed) return field;
            	name=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_map_declaration1897); if (state.failed) return field;
            	if ( (state.backtracking==0) )
            	{

            	  			field =  new DataField();
            	  			field.Type=t;
            	  			field.Token=name;
            	  		
            	}

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 23, map_declaration_StartIndex); 
            }
        }
        return field;
    }
    // $ANTLR end "map_declaration"


    // $ANTLR start "declaration"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:450:1: declaration returns [DataField field] : (sd= simple_declaration | rd= reference_declaration | wd= weak_reference_declaration | ld= list_declaration | md= map_declaration );
    public DataField declaration() // throws RecognitionException [1]
    {   
        DataField field = default(DataField);
        int declaration_StartIndex = input.Index();
        DataField sd = default(DataField);

        DataField rd = default(DataField);

        DataField wd = default(DataField);

        DataField ld = default(DataField);

        DataField md = default(DataField);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 24) ) 
    	    {
    	    	return field; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:451:2: (sd= simple_declaration | rd= reference_declaration | wd= weak_reference_declaration | ld= list_declaration | md= map_declaration )
            int alt13 = 5;
            alt13 = dfa13.Predict(input);
            switch (alt13) 
            {
                case 1 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:451:4: sd= simple_declaration
                    {
                    	PushFollow(FOLLOW_simple_declaration_in_declaration1918);
                    	sd = simple_declaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return field;
                    	if ( (state.backtracking==0) )
                    	{
                    	  field = sd;
                    	}

                    }
                    break;
                case 2 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:452:4: rd= reference_declaration
                    {
                    	PushFollow(FOLLOW_reference_declaration_in_declaration1928);
                    	rd = reference_declaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return field;
                    	if ( (state.backtracking==0) )
                    	{
                    	  field = rd;
                    	}

                    }
                    break;
                case 3 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:453:4: wd= weak_reference_declaration
                    {
                    	PushFollow(FOLLOW_weak_reference_declaration_in_declaration1937);
                    	wd = weak_reference_declaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return field;
                    	if ( (state.backtracking==0) )
                    	{
                    	  field = wd;
                    	}

                    }
                    break;
                case 4 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:454:4: ld= list_declaration
                    {
                    	PushFollow(FOLLOW_list_declaration_in_declaration1946);
                    	ld = list_declaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return field;
                    	if ( (state.backtracking==0) )
                    	{
                    	  field = ld;
                    	}

                    }
                    break;
                case 5 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:455:4: md= map_declaration
                    {
                    	PushFollow(FOLLOW_map_declaration_in_declaration1956);
                    	md = map_declaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return field;
                    	if ( (state.backtracking==0) )
                    	{
                    	  field = md;
                    	}

                    }
                    break;

            }
        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 24, declaration_StartIndex); 
            }
        }
        return field;
    }
    // $ANTLR end "declaration"


    // $ANTLR start "replicated_option"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:458:1: replicated_option returns [ReplicatedOption opt] : t= REPLICATED EQUAL ( TRUE | f= FALSE ) ;
    public ReplicatedOption replicated_option() // throws RecognitionException [1]
    {   
        ReplicatedOption opt = default(ReplicatedOption);
        int replicated_option_StartIndex = input.Index();
        IToken t = null;
        IToken f = null;

        opt = new ReplicatedOption();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 25) ) 
    	    {
    	    	return opt; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:460:2: (t= REPLICATED EQUAL ( TRUE | f= FALSE ) )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:460:4: t= REPLICATED EQUAL ( TRUE | f= FALSE )
            {
            	t=(IToken)Match(input,REPLICATED,FOLLOW_REPLICATED_in_replicated_option1979); if (state.failed) return opt;
            	Match(input,EQUAL,FOLLOW_EQUAL_in_replicated_option1981); if (state.failed) return opt;
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:460:23: ( TRUE | f= FALSE )
            	int alt14 = 2;
            	int LA14_0 = input.LA(1);

            	if ( (LA14_0 == TRUE) )
            	{
            	    alt14 = 1;
            	}
            	else if ( (LA14_0 == FALSE) )
            	{
            	    alt14 = 2;
            	}
            	else 
            	{
            	    if ( state.backtracking > 0 ) {state.failed = true; return opt;}
            	    NoViableAltException nvae_d14s0 =
            	        new NoViableAltException("", 14, 0, input);

            	    throw nvae_d14s0;
            	}
            	switch (alt14) 
            	{
            	    case 1 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:460:24: TRUE
            	        {
            	        	Match(input,TRUE,FOLLOW_TRUE_in_replicated_option1984); if (state.failed) return opt;

            	        }
            	        break;
            	    case 2 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:460:29: f= FALSE
            	        {
            	        	f=(IToken)Match(input,FALSE,FOLLOW_FALSE_in_replicated_option1988); if (state.failed) return opt;

            	        }
            	        break;

            	}

            	if ( (state.backtracking==0) )
            	{

            	  			opt.Token=t;
            	  			
            	  			if(f==null)
            	  				opt.Value=true;
            	  			else
            	  				opt.Value=false;
            	  		
            	}

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 25, replicated_option_StartIndex); 
            }
        }
        return opt;
    }
    // $ANTLR end "replicated_option"


    // $ANTLR start "profile_option"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:471:1: profile_option returns [ProfileOption opt] : t= PROFILE EQUAL exp= expression ;
    public ProfileOption profile_option() // throws RecognitionException [1]
    {   
        ProfileOption opt = default(ProfileOption);
        int profile_option_StartIndex = input.Index();
        IToken t = null;
        Expression exp = default(Expression);


        opt = new ProfileOption();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 26) ) 
    	    {
    	    	return opt; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:473:2: (t= PROFILE EQUAL exp= expression )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:473:4: t= PROFILE EQUAL exp= expression
            {
            	t=(IToken)Match(input,PROFILE,FOLLOW_PROFILE_in_profile_option2014); if (state.failed) return opt;
            	Match(input,EQUAL,FOLLOW_EQUAL_in_profile_option2016); if (state.failed) return opt;
            	PushFollow(FOLLOW_expression_in_profile_option2020);
            	exp = expression();
            	state.followingStackPointer--;
            	if (state.failed) return opt;
            	if ( (state.backtracking==0) )
            	{

            	  			opt.Token=t;
            	  			opt.Expr=exp;
            	  		
            	}

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 26, profile_option_StartIndex); 
            }
        }
        return opt;
    }
    // $ANTLR end "profile_option"


    // $ANTLR start "runtime_kind_field_option"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:480:1: runtime_kind_field_option returns [RuntimeKindOption opt] : t= RUNTIME_KIND EQUAL (s= RTK_SIMPLE | ts= RTK_SIMPLE_THREAD_SAFE | db= RTK_DUAL_BUFFER ) ;
    public RuntimeKindOption runtime_kind_field_option() // throws RecognitionException [1]
    {   
        RuntimeKindOption opt = default(RuntimeKindOption);
        int runtime_kind_field_option_StartIndex = input.Index();
        IToken t = null;
        IToken s = null;
        IToken ts = null;
        IToken db = null;

        opt = new RuntimeKindOption();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 27) ) 
    	    {
    	    	return opt; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:482:2: (t= RUNTIME_KIND EQUAL (s= RTK_SIMPLE | ts= RTK_SIMPLE_THREAD_SAFE | db= RTK_DUAL_BUFFER ) )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:482:4: t= RUNTIME_KIND EQUAL (s= RTK_SIMPLE | ts= RTK_SIMPLE_THREAD_SAFE | db= RTK_DUAL_BUFFER )
            {
            	t=(IToken)Match(input,RUNTIME_KIND,FOLLOW_RUNTIME_KIND_in_runtime_kind_field_option2044); if (state.failed) return opt;
            	Match(input,EQUAL,FOLLOW_EQUAL_in_runtime_kind_field_option2046); if (state.failed) return opt;
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:482:25: (s= RTK_SIMPLE | ts= RTK_SIMPLE_THREAD_SAFE | db= RTK_DUAL_BUFFER )
            	int alt15 = 3;
            	switch ( input.LA(1) ) 
            	{
            	case RTK_SIMPLE:
            		{
            	    alt15 = 1;
            	    }
            	    break;
            	case RTK_SIMPLE_THREAD_SAFE:
            		{
            	    alt15 = 2;
            	    }
            	    break;
            	case RTK_DUAL_BUFFER:
            		{
            	    alt15 = 3;
            	    }
            	    break;
            		default:
            		    if ( state.backtracking > 0 ) {state.failed = true; return opt;}
            		    NoViableAltException nvae_d15s0 =
            		        new NoViableAltException("", 15, 0, input);

            		    throw nvae_d15s0;
            	}

            	switch (alt15) 
            	{
            	    case 1 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:482:26: s= RTK_SIMPLE
            	        {
            	        	s=(IToken)Match(input,RTK_SIMPLE,FOLLOW_RTK_SIMPLE_in_runtime_kind_field_option2051); if (state.failed) return opt;

            	        }
            	        break;
            	    case 2 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:482:41: ts= RTK_SIMPLE_THREAD_SAFE
            	        {
            	        	ts=(IToken)Match(input,RTK_SIMPLE_THREAD_SAFE,FOLLOW_RTK_SIMPLE_THREAD_SAFE_in_runtime_kind_field_option2057); if (state.failed) return opt;

            	        }
            	        break;
            	    case 3 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:482:69: db= RTK_DUAL_BUFFER
            	        {
            	        	db=(IToken)Match(input,RTK_DUAL_BUFFER,FOLLOW_RTK_DUAL_BUFFER_in_runtime_kind_field_option2063); if (state.failed) return opt;

            	        }
            	        break;

            	}

            	if ( (state.backtracking==0) )
            	{

            	  			opt.Token = t;
            	  			
            	  			if (s != null)
            	  				opt.Value = eRuntimeKind.Simple;
            	  			else if (ts != null)
            	  				opt.Value = eRuntimeKind.SimpleThreadSafe;
            	  			else
            	  				opt.Value = eRuntimeKind.DualBuffer;
            	  		
            	}

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 27, runtime_kind_field_option_StartIndex); 
            }
        }
        return opt;
    }
    // $ANTLR end "runtime_kind_field_option"


    // $ANTLR start "compound_type_options"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:495:1: compound_type_options returns [Option opt] : (p= profile_option | rtk= runtime_kind_field_option | nos= no_serialize_option );
    public Option compound_type_options() // throws RecognitionException [1]
    {   
        Option opt = default(Option);
        int compound_type_options_StartIndex = input.Index();
        ProfileOption p = default(ProfileOption);

        RuntimeKindOption rtk = default(RuntimeKindOption);

        Option nos = default(Option);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 28) ) 
    	    {
    	    	return opt; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:496:2: (p= profile_option | rtk= runtime_kind_field_option | nos= no_serialize_option )
            int alt16 = 3;
            switch ( input.LA(1) ) 
            {
            case PROFILE:
            	{
                alt16 = 1;
                }
                break;
            case RUNTIME_KIND:
            	{
                alt16 = 2;
                }
                break;
            case NOSERIALIZE:
            	{
                alt16 = 3;
                }
                break;
            	default:
            	    if ( state.backtracking > 0 ) {state.failed = true; return opt;}
            	    NoViableAltException nvae_d16s0 =
            	        new NoViableAltException("", 16, 0, input);

            	    throw nvae_d16s0;
            }

            switch (alt16) 
            {
                case 1 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:496:4: p= profile_option
                    {
                    	PushFollow(FOLLOW_profile_option_in_compound_type_options2086);
                    	p = profile_option();
                    	state.followingStackPointer--;
                    	if (state.failed) return opt;
                    	if ( (state.backtracking==0) )
                    	{
                    	  opt = p;
                    	}

                    }
                    break;
                case 2 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:497:4: rtk= runtime_kind_field_option
                    {
                    	PushFollow(FOLLOW_runtime_kind_field_option_in_compound_type_options2095);
                    	rtk = runtime_kind_field_option();
                    	state.followingStackPointer--;
                    	if (state.failed) return opt;
                    	if ( (state.backtracking==0) )
                    	{
                    	  opt = rtk;
                    	}

                    }
                    break;
                case 3 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:498:4: nos= no_serialize_option
                    {
                    	PushFollow(FOLLOW_no_serialize_option_in_compound_type_options2104);
                    	nos = no_serialize_option();
                    	state.followingStackPointer--;
                    	if (state.failed) return opt;
                    	if ( (state.backtracking==0) )
                    	{
                    	  opt = nos;
                    	}

                    }
                    break;

            }
        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 28, compound_type_options_StartIndex); 
            }
        }
        return opt;
    }
    // $ANTLR end "compound_type_options"


    // $ANTLR start "compound_type_options_list"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:501:1: compound_type_options_list returns [List<Option> options] : o1= compound_type_options ( COMMA o2= compound_type_options )* ;
    public List<Option> compound_type_options_list() // throws RecognitionException [1]
    {   
        List<Option> options = default(List<Option>);
        int compound_type_options_list_StartIndex = input.Index();
        Option o1 = default(Option);

        Option o2 = default(Option);


        options = new List<Option>();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 29) ) 
    	    {
    	    	return options; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:503:2: (o1= compound_type_options ( COMMA o2= compound_type_options )* )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:503:4: o1= compound_type_options ( COMMA o2= compound_type_options )*
            {
            	PushFollow(FOLLOW_compound_type_options_in_compound_type_options_list2127);
            	o1 = compound_type_options();
            	state.followingStackPointer--;
            	if (state.failed) return options;
            	if ( (state.backtracking==0) )
            	{
            	  options.Add(o1);
            	}
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:503:54: ( COMMA o2= compound_type_options )*
            	do 
            	{
            	    int alt17 = 2;
            	    int LA17_0 = input.LA(1);

            	    if ( (LA17_0 == COMMA) )
            	    {
            	        alt17 = 1;
            	    }


            	    switch (alt17) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:503:55: COMMA o2= compound_type_options
            			    {
            			    	Match(input,COMMA,FOLLOW_COMMA_in_compound_type_options_list2132); if (state.failed) return options;
            			    	PushFollow(FOLLOW_compound_type_options_in_compound_type_options_list2136);
            			    	o2 = compound_type_options();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return options;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	  options.Add(o2);
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop17;
            	    }
            	} while (true);

            	loop17:
            		;	// Stops C# compiler whining that label 'loop17' has no statements


            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 29, compound_type_options_list_StartIndex); 
            }
        }
        return options;
    }
    // $ANTLR end "compound_type_options_list"


    // $ANTLR start "no_serialize_option"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:506:1: no_serialize_option returns [Option opt] : t= NOSERIALIZE ;
    public Option no_serialize_option() // throws RecognitionException [1]
    {   
        Option opt = default(Option);
        int no_serialize_option_StartIndex = input.Index();
        IToken t = null;

        opt =  new NoSerializeOption();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 30) ) 
    	    {
    	    	return opt; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:508:2: (t= NOSERIALIZE )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:508:5: t= NOSERIALIZE
            {
            	t=(IToken)Match(input,NOSERIALIZE,FOLLOW_NOSERIALIZE_in_no_serialize_option2163); if (state.failed) return opt;
            	if ( (state.backtracking==0) )
            	{

            	  			opt.Token = t;
            	  		
            	}

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 30, no_serialize_option_StartIndex); 
            }
        }
        return opt;
    }
    // $ANTLR end "no_serialize_option"


    // $ANTLR start "struct_options"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:514:1: struct_options returns [Option opt] : (o3= replicated_option | o4= profile_option | o5= no_serialize_option );
    public Option struct_options() // throws RecognitionException [1]
    {   
        Option opt = default(Option);
        int struct_options_StartIndex = input.Index();
        ReplicatedOption o3 = default(ReplicatedOption);

        ProfileOption o4 = default(ProfileOption);

        Option o5 = default(Option);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 31) ) 
    	    {
    	    	return opt; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:515:2: (o3= replicated_option | o4= profile_option | o5= no_serialize_option )
            int alt18 = 3;
            switch ( input.LA(1) ) 
            {
            case REPLICATED:
            	{
                alt18 = 1;
                }
                break;
            case PROFILE:
            	{
                alt18 = 2;
                }
                break;
            case NOSERIALIZE:
            	{
                alt18 = 3;
                }
                break;
            	default:
            	    if ( state.backtracking > 0 ) {state.failed = true; return opt;}
            	    NoViableAltException nvae_d18s0 =
            	        new NoViableAltException("", 18, 0, input);

            	    throw nvae_d18s0;
            }

            switch (alt18) 
            {
                case 1 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:515:4: o3= replicated_option
                    {
                    	PushFollow(FOLLOW_replicated_option_in_struct_options2184);
                    	o3 = replicated_option();
                    	state.followingStackPointer--;
                    	if (state.failed) return opt;
                    	if ( (state.backtracking==0) )
                    	{
                    	  opt = o3;
                    	}

                    }
                    break;
                case 2 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:516:4: o4= profile_option
                    {
                    	PushFollow(FOLLOW_profile_option_in_struct_options2193);
                    	o4 = profile_option();
                    	state.followingStackPointer--;
                    	if (state.failed) return opt;
                    	if ( (state.backtracking==0) )
                    	{
                    	  opt = o4;
                    	}

                    }
                    break;
                case 3 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:517:4: o5= no_serialize_option
                    {
                    	PushFollow(FOLLOW_no_serialize_option_in_struct_options2202);
                    	o5 = no_serialize_option();
                    	state.followingStackPointer--;
                    	if (state.failed) return opt;
                    	if ( (state.backtracking==0) )
                    	{
                    	  opt = o5;
                    	}

                    }
                    break;

            }
        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 31, struct_options_StartIndex); 
            }
        }
        return opt;
    }
    // $ANTLR end "struct_options"


    // $ANTLR start "struct_options_list"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:520:1: struct_options_list returns [List<Option> options] : o1= struct_options ( COMMA o2= struct_options )* ;
    public List<Option> struct_options_list() // throws RecognitionException [1]
    {   
        List<Option> options = default(List<Option>);
        int struct_options_list_StartIndex = input.Index();
        Option o1 = default(Option);

        Option o2 = default(Option);


        options = new List<Option>();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 32) ) 
    	    {
    	    	return options; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:522:2: (o1= struct_options ( COMMA o2= struct_options )* )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:522:4: o1= struct_options ( COMMA o2= struct_options )*
            {
            	PushFollow(FOLLOW_struct_options_in_struct_options_list2226);
            	o1 = struct_options();
            	state.followingStackPointer--;
            	if (state.failed) return options;
            	if ( (state.backtracking==0) )
            	{
            	  options.Add(o1);
            	}
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:522:47: ( COMMA o2= struct_options )*
            	do 
            	{
            	    int alt19 = 2;
            	    int LA19_0 = input.LA(1);

            	    if ( (LA19_0 == COMMA) )
            	    {
            	        alt19 = 1;
            	    }


            	    switch (alt19) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:522:48: COMMA o2= struct_options
            			    {
            			    	Match(input,COMMA,FOLLOW_COMMA_in_struct_options_list2231); if (state.failed) return options;
            			    	PushFollow(FOLLOW_struct_options_in_struct_options_list2235);
            			    	o2 = struct_options();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return options;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	  options.Add(o2);
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop19;
            	    }
            	} while (true);

            	loop19:
            		;	// Stops C# compiler whining that label 'loop19' has no statements


            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 32, struct_options_list_StartIndex); 
            }
        }
        return options;
    }
    // $ANTLR end "struct_options_list"


    // $ANTLR start "entity_options"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:525:1: entity_options returns [Option opt] : (o5= profile_option | o6= no_serialize_option );
    public Option entity_options() // throws RecognitionException [1]
    {   
        Option opt = default(Option);
        int entity_options_StartIndex = input.Index();
        ProfileOption o5 = default(ProfileOption);

        Option o6 = default(Option);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 33) ) 
    	    {
    	    	return opt; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:526:2: (o5= profile_option | o6= no_serialize_option )
            int alt20 = 2;
            int LA20_0 = input.LA(1);

            if ( (LA20_0 == PROFILE) )
            {
                alt20 = 1;
            }
            else if ( (LA20_0 == NOSERIALIZE) )
            {
                alt20 = 2;
            }
            else 
            {
                if ( state.backtracking > 0 ) {state.failed = true; return opt;}
                NoViableAltException nvae_d20s0 =
                    new NoViableAltException("", 20, 0, input);

                throw nvae_d20s0;
            }
            switch (alt20) 
            {
                case 1 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:526:4: o5= profile_option
                    {
                    	PushFollow(FOLLOW_profile_option_in_entity_options2257);
                    	o5 = profile_option();
                    	state.followingStackPointer--;
                    	if (state.failed) return opt;
                    	if ( (state.backtracking==0) )
                    	{
                    	  opt = o5;
                    	}

                    }
                    break;
                case 2 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:527:4: o6= no_serialize_option
                    {
                    	PushFollow(FOLLOW_no_serialize_option_in_entity_options2267);
                    	o6 = no_serialize_option();
                    	state.followingStackPointer--;
                    	if (state.failed) return opt;
                    	if ( (state.backtracking==0) )
                    	{
                    	  opt = o6;
                    	}

                    }
                    break;

            }
        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 33, entity_options_StartIndex); 
            }
        }
        return opt;
    }
    // $ANTLR end "entity_options"


    // $ANTLR start "entity_options_list"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:530:1: entity_options_list returns [List<Option> options] : o1= entity_options ( COMMA o2= entity_options )* ;
    public List<Option> entity_options_list() // throws RecognitionException [1]
    {   
        List<Option> options = default(List<Option>);
        int entity_options_list_StartIndex = input.Index();
        Option o1 = default(Option);

        Option o2 = default(Option);


        options = new List<Option>();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 34) ) 
    	    {
    	    	return options; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:532:2: (o1= entity_options ( COMMA o2= entity_options )* )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:532:4: o1= entity_options ( COMMA o2= entity_options )*
            {
            	PushFollow(FOLLOW_entity_options_in_entity_options_list2292);
            	o1 = entity_options();
            	state.followingStackPointer--;
            	if (state.failed) return options;
            	if ( (state.backtracking==0) )
            	{
            	  options.Add(o1);
            	}
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:532:47: ( COMMA o2= entity_options )*
            	do 
            	{
            	    int alt21 = 2;
            	    int LA21_0 = input.LA(1);

            	    if ( (LA21_0 == COMMA) )
            	    {
            	        alt21 = 1;
            	    }


            	    switch (alt21) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:532:48: COMMA o2= entity_options
            			    {
            			    	Match(input,COMMA,FOLLOW_COMMA_in_entity_options_list2297); if (state.failed) return options;
            			    	PushFollow(FOLLOW_entity_options_in_entity_options_list2301);
            			    	o2 = entity_options();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return options;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	  options.Add(o2);
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop21;
            	    }
            	} while (true);

            	loop21:
            		;	// Stops C# compiler whining that label 'loop21' has no statements


            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 34, entity_options_list_StartIndex); 
            }
        }
        return options;
    }
    // $ANTLR end "entity_options_list"


    // $ANTLR start "constant_declaration"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:535:1: constant_declaration : CONST t= types id= IDENTIFIER EQUAL u= unary_expression SEMICOLON ;
    public void constant_declaration() // throws RecognitionException [1]
    {   
        int constant_declaration_StartIndex = input.Index();
        IToken id = null;
        BaseType t = default(BaseType);

        DataForgeParser.unary_expression_return u = default(DataForgeParser.unary_expression_return);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 35) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:536:2: ( CONST t= types id= IDENTIFIER EQUAL u= unary_expression SEMICOLON )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:536:4: CONST t= types id= IDENTIFIER EQUAL u= unary_expression SEMICOLON
            {
            	Match(input,CONST,FOLLOW_CONST_in_constant_declaration2317); if (state.failed) return ;
            	PushFollow(FOLLOW_types_in_constant_declaration2321);
            	t = types();
            	state.followingStackPointer--;
            	if (state.failed) return ;
            	id=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_constant_declaration2325); if (state.failed) return ;
            	Match(input,EQUAL,FOLLOW_EQUAL_in_constant_declaration2327); if (state.failed) return ;
            	PushFollow(FOLLOW_unary_expression_in_constant_declaration2331);
            	u = unary_expression();
            	state.followingStackPointer--;
            	if (state.failed) return ;
            	Match(input,SEMICOLON,FOLLOW_SEMICOLON_in_constant_declaration2333); if (state.failed) return ;
            	if ( (state.backtracking==0) )
            	{

            	  			DataField val = new DataField();
            	  			val.Token=id;
            	  			val.Type=t;
            	  			val.Initter=((u != null) ? u.initter : default(SimpleInitializer));
            	  			compiler.CheckConstantType(val);
            	  			compiler.CurrentPackage.AddConstant(val);
            	  		
            	}

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 35, constant_declaration_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "constant_declaration"


    // $ANTLR start "named_constant"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:547:1: named_constant returns [SymbolConstant cnt] : (pq= IDENTIFIER DOT )* id= IDENTIFIER ;
    public SymbolConstant named_constant() // throws RecognitionException [1]
    {   
        SymbolConstant cnt = default(SymbolConstant);
        int named_constant_StartIndex = input.Index();
        IToken pq = null;
        IToken id = null;

        cnt =  new SymbolConstant();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 36) ) 
    	    {
    	    	return cnt; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:549:2: ( (pq= IDENTIFIER DOT )* id= IDENTIFIER )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:549:4: (pq= IDENTIFIER DOT )* id= IDENTIFIER
            {
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:549:4: (pq= IDENTIFIER DOT )*
            	do 
            	{
            	    int alt22 = 2;
            	    alt22 = dfa22.Predict(input);
            	    switch (alt22) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:549:5: pq= IDENTIFIER DOT
            			    {
            			    	pq=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_named_constant2359); if (state.failed) return cnt;
            			    	Match(input,DOT,FOLLOW_DOT_in_named_constant2361); if (state.failed) return cnt;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	  cnt.PackageNameQualifier = pq.Text;
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop22;
            	    }
            	} while (true);

            	loop22:
            		;	// Stops C# compiler whining that label 'loop22' has no statements

            	id=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_named_constant2369); if (state.failed) return cnt;
            	if ( (state.backtracking==0) )
            	{
            	  cnt.Token=id;
            	}

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 36, named_constant_StartIndex); 
            }
        }
        return cnt;
    }
    // $ANTLR end "named_constant"


    // $ANTLR start "simple_constant"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:552:1: simple_constant returns [IConstant constant] : (t0= TRUE | t1= FALSE | i= INTCONSTANT | f= FLOATCONSTANT | s= STRING_LITERAL | ef= enum_field | nc= named_constant );
    public IConstant simple_constant() // throws RecognitionException [1]
    {   
        IConstant constant = default(IConstant);
        int simple_constant_StartIndex = input.Index();
        IToken t0 = null;
        IToken t1 = null;
        IToken i = null;
        IToken f = null;
        IToken s = null;
        EnumConstant ef = default(EnumConstant);

        SymbolConstant nc = default(SymbolConstant);


        constant = null;
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 37) ) 
    	    {
    	    	return constant; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:554:2: (t0= TRUE | t1= FALSE | i= INTCONSTANT | f= FLOATCONSTANT | s= STRING_LITERAL | ef= enum_field | nc= named_constant )
            int alt23 = 7;
            alt23 = dfa23.Predict(input);
            switch (alt23) 
            {
                case 1 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:554:4: t0= TRUE
                    {
                    	t0=(IToken)Match(input,TRUE,FOLLOW_TRUE_in_simple_constant2391); if (state.failed) return constant;
                    	if ( (state.backtracking==0) )
                    	{
                    	  BoolConstant cnt = new BoolConstant(); cnt.Value = true; cnt.Token = t0; constant =  cnt;
                    	}

                    }
                    break;
                case 2 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:555:4: t1= FALSE
                    {
                    	t1=(IToken)Match(input,FALSE,FOLLOW_FALSE_in_simple_constant2402); if (state.failed) return constant;
                    	if ( (state.backtracking==0) )
                    	{
                    	  BoolConstant cnt = new BoolConstant(); cnt.Value = false; cnt.Token = t1; constant =  cnt;
                    	}

                    }
                    break;
                case 3 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:556:4: i= INTCONSTANT
                    {
                    	i=(IToken)Match(input,INTCONSTANT,FOLLOW_INTCONSTANT_in_simple_constant2412); if (state.failed) return constant;
                    	if ( (state.backtracking==0) )
                    	{
                    	  Int32Constant cnt = new Int32Constant(); cnt.Value = Int32.Parse(((i != null) ? i.Text : null), CultureInfo.InvariantCulture); cnt.Token = i; constant =  cnt;
                    	}

                    }
                    break;
                case 4 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:557:4: f= FLOATCONSTANT
                    {
                    	f=(IToken)Match(input,FLOATCONSTANT,FOLLOW_FLOATCONSTANT_in_simple_constant2422); if (state.failed) return constant;
                    	if ( (state.backtracking==0) )
                    	{
                    	  DoubleConstant cnt = new DoubleConstant(); cnt.Value = Single.Parse(((f != null) ? f.Text : null), CultureInfo.InvariantCulture); cnt.Token = f; constant =  cnt;
                    	}

                    }
                    break;
                case 5 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:558:4: s= STRING_LITERAL
                    {
                    	s=(IToken)Match(input,STRING_LITERAL,FOLLOW_STRING_LITERAL_in_simple_constant2432); if (state.failed) return constant;
                    	if ( (state.backtracking==0) )
                    	{
                    	  StringConstant cnt = new StringConstant(); cnt.Value =((s != null) ? s.Text : null); cnt.Token = s; constant =  cnt;
                    	}

                    }
                    break;
                case 6 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:559:4: ef= enum_field
                    {
                    	PushFollow(FOLLOW_enum_field_in_simple_constant2441);
                    	ef = enum_field();
                    	state.followingStackPointer--;
                    	if (state.failed) return constant;
                    	if ( (state.backtracking==0) )
                    	{
                    	  constant =  ef;
                    	}

                    }
                    break;
                case 7 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:560:4: nc= named_constant
                    {
                    	PushFollow(FOLLOW_named_constant_in_simple_constant2451);
                    	nc = named_constant();
                    	state.followingStackPointer--;
                    	if (state.failed) return constant;
                    	if ( (state.backtracking==0) )
                    	{
                    	  constant =  nc;
                    	}

                    }
                    break;

            }
        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 37, simple_constant_StartIndex); 
            }
        }
        return constant;
    }
    // $ANTLR end "simple_constant"


    // $ANTLR start "constant_list"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:563:1: constant_list returns [SimpleInitializer initter] : s1= simple_constant ( COMMA s2= simple_constant )* ;
    public SimpleInitializer constant_list() // throws RecognitionException [1]
    {   
        SimpleInitializer initter = default(SimpleInitializer);
        int constant_list_StartIndex = input.Index();
        IConstant s1 = default(IConstant);

        IConstant s2 = default(IConstant);


        initter = new SimpleInitializer();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 38) ) 
    	    {
    	    	return initter; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:565:2: (s1= simple_constant ( COMMA s2= simple_constant )* )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:565:4: s1= simple_constant ( COMMA s2= simple_constant )*
            {
            	PushFollow(FOLLOW_simple_constant_in_constant_list2473);
            	s1 = simple_constant();
            	state.followingStackPointer--;
            	if (state.failed) return initter;
            	if ( (state.backtracking==0) )
            	{
            	  initter.Constants.Add(s1);
            	}
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:566:3: ( COMMA s2= simple_constant )*
            	do 
            	{
            	    int alt24 = 2;
            	    int LA24_0 = input.LA(1);

            	    if ( (LA24_0 == COMMA) )
            	    {
            	        alt24 = 1;
            	    }


            	    switch (alt24) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:566:4: COMMA s2= simple_constant
            			    {
            			    	Match(input,COMMA,FOLLOW_COMMA_in_constant_list2480); if (state.failed) return initter;
            			    	PushFollow(FOLLOW_simple_constant_in_constant_list2484);
            			    	s2 = simple_constant();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return initter;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	  initter.Constants.Add(s2);
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop24;
            	    }
            	} while (true);

            	loop24:
            		;	// Stops C# compiler whining that label 'loop24' has no statements


            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 38, constant_list_StartIndex); 
            }
        }
        return initter;
    }
    // $ANTLR end "constant_list"


    // $ANTLR start "constant"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:569:1: constant returns [SimpleInitializer initter] : (sc= simple_constant | LEFT_BRACE cl= constant_list RIGHT_BRACE );
    public SimpleInitializer constant() // throws RecognitionException [1]
    {   
        SimpleInitializer initter = default(SimpleInitializer);
        int constant_StartIndex = input.Index();
        IConstant sc = default(IConstant);

        SimpleInitializer cl = default(SimpleInitializer);


        initter = null;
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 39) ) 
    	    {
    	    	return initter; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:571:2: (sc= simple_constant | LEFT_BRACE cl= constant_list RIGHT_BRACE )
            int alt25 = 2;
            int LA25_0 = input.LA(1);

            if ( ((LA25_0 >= TRUE && LA25_0 <= FALSE) || LA25_0 == INTCONSTANT || (LA25_0 >= STRING_LITERAL && LA25_0 <= IDENTIFIER)) )
            {
                alt25 = 1;
            }
            else if ( (LA25_0 == LEFT_BRACE) )
            {
                alt25 = 2;
            }
            else 
            {
                if ( state.backtracking > 0 ) {state.failed = true; return initter;}
                NoViableAltException nvae_d25s0 =
                    new NoViableAltException("", 25, 0, input);

                throw nvae_d25s0;
            }
            switch (alt25) 
            {
                case 1 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:571:4: sc= simple_constant
                    {
                    	PushFollow(FOLLOW_simple_constant_in_constant2510);
                    	sc = simple_constant();
                    	state.followingStackPointer--;
                    	if (state.failed) return initter;
                    	if ( (state.backtracking==0) )
                    	{
                    	  initter =  new SimpleInitializer(); initter.Constants.Add(sc);
                    	}

                    }
                    break;
                case 2 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:572:4: LEFT_BRACE cl= constant_list RIGHT_BRACE
                    {
                    	Match(input,LEFT_BRACE,FOLLOW_LEFT_BRACE_in_constant2517); if (state.failed) return initter;
                    	PushFollow(FOLLOW_constant_list_in_constant2521);
                    	cl = constant_list();
                    	state.followingStackPointer--;
                    	if (state.failed) return initter;
                    	Match(input,RIGHT_BRACE,FOLLOW_RIGHT_BRACE_in_constant2523); if (state.failed) return initter;
                    	if ( (state.backtracking==0) )
                    	{
                    	  initter = cl;
                    	}

                    }
                    break;

            }
        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 39, constant_StartIndex); 
            }
        }
        return initter;
    }
    // $ANTLR end "constant"


    // $ANTLR start "list_initializer"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:575:1: list_initializer returns [Initializer initter] : LEFT_BRACE (ue= unary_expression | il= initializer_list ) RIGHT_BRACE ;
    public Initializer list_initializer() // throws RecognitionException [1]
    {   
        Initializer initter = default(Initializer);
        int list_initializer_StartIndex = input.Index();
        DataForgeParser.unary_expression_return ue = default(DataForgeParser.unary_expression_return);

        Initializer il = default(Initializer);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 40) ) 
    	    {
    	    	return initter; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:576:2: ( LEFT_BRACE (ue= unary_expression | il= initializer_list ) RIGHT_BRACE )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:576:4: LEFT_BRACE (ue= unary_expression | il= initializer_list ) RIGHT_BRACE
            {
            	Match(input,LEFT_BRACE,FOLLOW_LEFT_BRACE_in_list_initializer2539); if (state.failed) return initter;
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:577:3: (ue= unary_expression | il= initializer_list )
            	int alt26 = 2;
            	alt26 = dfa26.Predict(input);
            	switch (alt26) 
            	{
            	    case 1 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:577:4: ue= unary_expression
            	        {
            	        	PushFollow(FOLLOW_unary_expression_in_list_initializer2547);
            	        	ue = unary_expression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return initter;
            	        	if ( (state.backtracking==0) )
            	        	{
            	        	  initter = ((ue != null) ? ue.initter : default(SimpleInitializer));
            	        	}

            	        }
            	        break;
            	    case 2 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:577:49: il= initializer_list
            	        {
            	        	PushFollow(FOLLOW_initializer_list_in_list_initializer2554);
            	        	il = initializer_list();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return initter;
            	        	if ( (state.backtracking==0) )
            	        	{
            	        	  initter = il;
            	        	}

            	        }
            	        break;

            	}

            	Match(input,RIGHT_BRACE,FOLLOW_RIGHT_BRACE_in_list_initializer2561); if (state.failed) return initter;

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 40, list_initializer_StartIndex); 
            }
        }
        return initter;
    }
    // $ANTLR end "list_initializer"


    // $ANTLR start "list_initializer_list"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:581:1: list_initializer_list returns [Initializer initter] : li1= list_initializer ( COMMA li2= list_initializer )* ;
    public Initializer list_initializer_list() // throws RecognitionException [1]
    {   
        Initializer initter = default(Initializer);
        int list_initializer_list_StartIndex = input.Index();
        Initializer li1 = default(Initializer);

        Initializer li2 = default(Initializer);


        InitializerList list = new InitializerList();initter = list;
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 41) ) 
    	    {
    	    	return initter; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:583:2: (li1= list_initializer ( COMMA li2= list_initializer )* )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:583:4: li1= list_initializer ( COMMA li2= list_initializer )*
            {
            	PushFollow(FOLLOW_list_initializer_in_list_initializer_list2582);
            	li1 = list_initializer();
            	state.followingStackPointer--;
            	if (state.failed) return initter;
            	if ( (state.backtracking==0) )
            	{
            	  list.Initters.Add(li1);
            	}
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:583:60: ( COMMA li2= list_initializer )*
            	do 
            	{
            	    int alt27 = 2;
            	    alt27 = dfa27.Predict(input);
            	    switch (alt27) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:583:61: COMMA li2= list_initializer
            			    {
            			    	Match(input,COMMA,FOLLOW_COMMA_in_list_initializer_list2587); if (state.failed) return initter;
            			    	PushFollow(FOLLOW_list_initializer_in_list_initializer_list2591);
            			    	li2 = list_initializer();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return initter;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	  list.Initters.Add(li2);
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop27;
            	    }
            	} while (true);

            	loop27:
            		;	// Stops C# compiler whining that label 'loop27' has no statements


            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 41, list_initializer_list_StartIndex); 
            }
        }
        return initter;
    }
    // $ANTLR end "list_initializer_list"


    // $ANTLR start "map_initializer"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:586:1: map_initializer returns [Initializer initter] : LEFT_BRACE id= STRING_LITERAL COLON (ue= unary_expression | il= initializer_list ) RIGHT_BRACE ;
    public Initializer map_initializer() // throws RecognitionException [1]
    {   
        Initializer initter = default(Initializer);
        int map_initializer_StartIndex = input.Index();
        IToken id = null;
        DataForgeParser.unary_expression_return ue = default(DataForgeParser.unary_expression_return);

        Initializer il = default(Initializer);


        InitializerNamed named=new InitializerNamed();initter = named;
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 42) ) 
    	    {
    	    	return initter; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:588:2: ( LEFT_BRACE id= STRING_LITERAL COLON (ue= unary_expression | il= initializer_list ) RIGHT_BRACE )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:588:4: LEFT_BRACE id= STRING_LITERAL COLON (ue= unary_expression | il= initializer_list ) RIGHT_BRACE
            {
            	Match(input,LEFT_BRACE,FOLLOW_LEFT_BRACE_in_map_initializer2614); if (state.failed) return initter;
            	id=(IToken)Match(input,STRING_LITERAL,FOLLOW_STRING_LITERAL_in_map_initializer2618); if (state.failed) return initter;
            	if ( (state.backtracking==0) )
            	{
            	  named.Name=Utilities.TrimQuotes(((id != null) ? id.Text : null));
            	}
            	Match(input,COLON,FOLLOW_COLON_in_map_initializer2622); if (state.failed) return initter;
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:589:4: (ue= unary_expression | il= initializer_list )
            	int alt28 = 2;
            	alt28 = dfa28.Predict(input);
            	switch (alt28) 
            	{
            	    case 1 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:589:5: ue= unary_expression
            	        {
            	        	PushFollow(FOLLOW_unary_expression_in_map_initializer2630);
            	        	ue = unary_expression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return initter;
            	        	if ( (state.backtracking==0) )
            	        	{
            	        	  named.Initter=((ue != null) ? ue.initter : default(SimpleInitializer));
            	        	}

            	        }
            	        break;
            	    case 2 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:590:5: il= initializer_list
            	        {
            	        	PushFollow(FOLLOW_initializer_list_in_map_initializer2639);
            	        	il = initializer_list();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return initter;
            	        	if ( (state.backtracking==0) )
            	        	{
            	        	  named.Initter=il;
            	        	}

            	        }
            	        break;

            	}

            	Match(input,RIGHT_BRACE,FOLLOW_RIGHT_BRACE_in_map_initializer2646); if (state.failed) return initter;

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 42, map_initializer_StartIndex); 
            }
        }
        return initter;
    }
    // $ANTLR end "map_initializer"


    // $ANTLR start "map_initializer_list"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:594:1: map_initializer_list returns [Initializer initter] : mi1= map_initializer ( COMMA mi2= map_initializer )* ;
    public Initializer map_initializer_list() // throws RecognitionException [1]
    {   
        Initializer initter = default(Initializer);
        int map_initializer_list_StartIndex = input.Index();
        Initializer mi1 = default(Initializer);

        Initializer mi2 = default(Initializer);


        InitializerList list = new InitializerList();initter = list;
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 43) ) 
    	    {
    	    	return initter; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:596:2: (mi1= map_initializer ( COMMA mi2= map_initializer )* )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:596:4: mi1= map_initializer ( COMMA mi2= map_initializer )*
            {
            	PushFollow(FOLLOW_map_initializer_in_map_initializer_list2670);
            	mi1 = map_initializer();
            	state.followingStackPointer--;
            	if (state.failed) return initter;
            	if ( (state.backtracking==0) )
            	{
            	  list.Initters.Add(mi1);
            	}
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:596:59: ( COMMA mi2= map_initializer )*
            	do 
            	{
            	    int alt29 = 2;
            	    alt29 = dfa29.Predict(input);
            	    switch (alt29) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:596:60: COMMA mi2= map_initializer
            			    {
            			    	Match(input,COMMA,FOLLOW_COMMA_in_map_initializer_list2675); if (state.failed) return initter;
            			    	PushFollow(FOLLOW_map_initializer_in_map_initializer_list2679);
            			    	mi2 = map_initializer();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return initter;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	  list.Initters.Add(mi2);
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop29;
            	    }
            	} while (true);

            	loop29:
            		;	// Stops C# compiler whining that label 'loop29' has no statements


            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 43, map_initializer_list_StartIndex); 
            }
        }
        return initter;
    }
    // $ANTLR end "map_initializer_list"


    // $ANTLR start "simple_initializer"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:599:1: simple_initializer returns [Initializer initter] : (ue= unary_expression | mi= map_initializer_list | li= list_initializer_list );
    public Initializer simple_initializer() // throws RecognitionException [1]
    {   
        Initializer initter = default(Initializer);
        int simple_initializer_StartIndex = input.Index();
        DataForgeParser.unary_expression_return ue = default(DataForgeParser.unary_expression_return);

        Initializer mi = default(Initializer);

        Initializer li = default(Initializer);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 44) ) 
    	    {
    	    	return initter; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:600:2: (ue= unary_expression | mi= map_initializer_list | li= list_initializer_list )
            int alt30 = 3;
            alt30 = dfa30.Predict(input);
            switch (alt30) 
            {
                case 1 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:600:4: ue= unary_expression
                    {
                    	PushFollow(FOLLOW_unary_expression_in_simple_initializer2701);
                    	ue = unary_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return initter;
                    	if ( (state.backtracking==0) )
                    	{
                    	  initter = ((ue != null) ? ue.initter : default(SimpleInitializer));
                    	}

                    }
                    break;
                case 2 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:601:4: mi= map_initializer_list
                    {
                    	PushFollow(FOLLOW_map_initializer_list_in_simple_initializer2711);
                    	mi = map_initializer_list();
                    	state.followingStackPointer--;
                    	if (state.failed) return initter;
                    	if ( (state.backtracking==0) )
                    	{
                    	  initter = mi;
                    	}

                    }
                    break;
                case 3 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:602:4: li= list_initializer_list
                    {
                    	PushFollow(FOLLOW_list_initializer_list_in_simple_initializer2721);
                    	li = list_initializer_list();
                    	state.followingStackPointer--;
                    	if (state.failed) return initter;
                    	if ( (state.backtracking==0) )
                    	{
                    	  initter = li;
                    	}

                    }
                    break;

            }
        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 44, simple_initializer_StartIndex); 
            }
        }
        return initter;
    }
    // $ANTLR end "simple_initializer"


    // $ANTLR start "named_initializer"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:605:1: named_initializer returns [Initializer initter] : id= IDENTIFIER EQUAL si= simple_initializer ;
    public Initializer named_initializer() // throws RecognitionException [1]
    {   
        Initializer initter = default(Initializer);
        int named_initializer_StartIndex = input.Index();
        IToken id = null;
        Initializer si = default(Initializer);


        InitializerNamed ini=new InitializerNamed();initter = ini;
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 45) ) 
    	    {
    	    	return initter; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:607:2: (id= IDENTIFIER EQUAL si= simple_initializer )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:607:4: id= IDENTIFIER EQUAL si= simple_initializer
            {
            	id=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_named_initializer2744); if (state.failed) return initter;
            	Match(input,EQUAL,FOLLOW_EQUAL_in_named_initializer2746); if (state.failed) return initter;
            	PushFollow(FOLLOW_simple_initializer_in_named_initializer2750);
            	si = simple_initializer();
            	state.followingStackPointer--;
            	if (state.failed) return initter;
            	if ( (state.backtracking==0) )
            	{

            	  			ini.Name=((id != null) ? id.Text : null);
            	  			ini.Initter=si;
            	  		
            	}

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 45, named_initializer_StartIndex); 
            }
        }
        return initter;
    }
    // $ANTLR end "named_initializer"


    // $ANTLR start "initializer"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:614:1: initializer returns [Initializer initter] : (ni= named_initializer | si= simple_initializer );
    public Initializer initializer() // throws RecognitionException [1]
    {   
        Initializer initter = default(Initializer);
        int initializer_StartIndex = input.Index();
        Initializer ni = default(Initializer);

        Initializer si = default(Initializer);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 46) ) 
    	    {
    	    	return initter; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:615:2: (ni= named_initializer | si= simple_initializer )
            int alt31 = 2;
            alt31 = dfa31.Predict(input);
            switch (alt31) 
            {
                case 1 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:615:4: ni= named_initializer
                    {
                    	PushFollow(FOLLOW_named_initializer_in_initializer2770);
                    	ni = named_initializer();
                    	state.followingStackPointer--;
                    	if (state.failed) return initter;
                    	if ( (state.backtracking==0) )
                    	{
                    	  initter = ni;
                    	}

                    }
                    break;
                case 2 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:616:4: si= simple_initializer
                    {
                    	PushFollow(FOLLOW_simple_initializer_in_initializer2779);
                    	si = simple_initializer();
                    	state.followingStackPointer--;
                    	if (state.failed) return initter;
                    	if ( (state.backtracking==0) )
                    	{
                    	  initter = si;
                    	}

                    }
                    break;

            }
        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 46, initializer_StartIndex); 
            }
        }
        return initter;
    }
    // $ANTLR end "initializer"


    // $ANTLR start "initializer_list"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:619:1: initializer_list returns [Initializer initter] : ini1= initializer ( COMMA ini2= initializer )* ;
    public Initializer initializer_list() // throws RecognitionException [1]
    {   
        Initializer initter = default(Initializer);
        int initializer_list_StartIndex = input.Index();
        Initializer ini1 = default(Initializer);

        Initializer ini2 = default(Initializer);


        InitializerList list=null;
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 47) ) 
    	    {
    	    	return initter; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:621:2: (ini1= initializer ( COMMA ini2= initializer )* )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:621:4: ini1= initializer ( COMMA ini2= initializer )*
            {
            	PushFollow(FOLLOW_initializer_in_initializer_list2801);
            	ini1 = initializer();
            	state.followingStackPointer--;
            	if (state.failed) return initter;
            	if ( (state.backtracking==0) )
            	{
            	  initter = ini1;
            	}
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:622:3: ( COMMA ini2= initializer )*
            	do 
            	{
            	    int alt32 = 2;
            	    int LA32_0 = input.LA(1);

            	    if ( (LA32_0 == COMMA) )
            	    {
            	        alt32 = 1;
            	    }


            	    switch (alt32) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:623:4: COMMA ini2= initializer
            			    {
            			    	Match(input,COMMA,FOLLOW_COMMA_in_initializer_list2812); if (state.failed) return initter;
            			    	PushFollow(FOLLOW_initializer_in_initializer_list2816);
            			    	ini2 = initializer();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return initter;
            			    	if ( (state.backtracking==0) )
            			    	{

            			    	  				if(list==null)
            			    	  				{
            			    	  					list=new InitializerList();
            			    	  					list.Initters.Add(initter);
            			    	  					initter = list;
            			    	  				}
            			    	  				
            			    	  				list.Initters.Add(ini2);				
            			    	  			
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop32;
            	    }
            	} while (true);

            	loop32:
            		;	// Stops C# compiler whining that label 'loop32' has no statements


            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 47, initializer_list_StartIndex); 
            }
        }
        return initter;
    }
    // $ANTLR end "initializer_list"


    // $ANTLR start "initializer_root"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:637:1: initializer_root returns [Initializer initter] : ( LEFT_BRACE ini1= initializer RIGHT_BRACE | ini2= initializer );
    public Initializer initializer_root() // throws RecognitionException [1]
    {   
        Initializer initter = default(Initializer);
        int initializer_root_StartIndex = input.Index();
        Initializer ini1 = default(Initializer);

        Initializer ini2 = default(Initializer);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 48) ) 
    	    {
    	    	return initter; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:638:2: ( LEFT_BRACE ini1= initializer RIGHT_BRACE | ini2= initializer )
            int alt33 = 2;
            alt33 = dfa33.Predict(input);
            switch (alt33) 
            {
                case 1 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:638:4: LEFT_BRACE ini1= initializer RIGHT_BRACE
                    {
                    	Match(input,LEFT_BRACE,FOLLOW_LEFT_BRACE_in_initializer_root2842); if (state.failed) return initter;
                    	PushFollow(FOLLOW_initializer_in_initializer_root2846);
                    	ini1 = initializer();
                    	state.followingStackPointer--;
                    	if (state.failed) return initter;
                    	Match(input,RIGHT_BRACE,FOLLOW_RIGHT_BRACE_in_initializer_root2848); if (state.failed) return initter;
                    	if ( (state.backtracking==0) )
                    	{
                    	  initter = ini1;
                    	}

                    }
                    break;
                case 2 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:639:4: ini2= initializer
                    {
                    	PushFollow(FOLLOW_initializer_in_initializer_root2858);
                    	ini2 = initializer();
                    	state.followingStackPointer--;
                    	if (state.failed) return initter;
                    	if ( (state.backtracking==0) )
                    	{
                    	  initter = ini2;
                    	}

                    }
                    break;

            }
        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 48, initializer_root_StartIndex); 
            }
        }
        return initter;
    }
    // $ANTLR end "initializer_root"


    // $ANTLR start "struct_specifier"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:642:1: struct_specifier : STRUCT id= IDENTIFIER ( COLON parent= types )? ( LEFT_BRACKET opt= compound_type_options_list RIGHT_BRACKET )? LEFT_BRACE struct_declaration_list[dec] RIGHT_BRACE ;
    public void struct_specifier() // throws RecognitionException [1]
    {   
        int struct_specifier_StartIndex = input.Index();
        IToken id = null;
        BaseType parent = default(BaseType);

        List<Option> opt = default(List<Option>);


        StructDeclaration dec = new StructDeclaration();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 49) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:644:2: ( STRUCT id= IDENTIFIER ( COLON parent= types )? ( LEFT_BRACKET opt= compound_type_options_list RIGHT_BRACKET )? LEFT_BRACE struct_declaration_list[dec] RIGHT_BRACE )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:644:4: STRUCT id= IDENTIFIER ( COLON parent= types )? ( LEFT_BRACKET opt= compound_type_options_list RIGHT_BRACKET )? LEFT_BRACE struct_declaration_list[dec] RIGHT_BRACE
            {
            	Match(input,STRUCT,FOLLOW_STRUCT_in_struct_specifier2878); if (state.failed) return ;
            	id=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_struct_specifier2882); if (state.failed) return ;
            	if ( (state.backtracking==0) )
            	{
            	  dec.Token = id;
            	}
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:644:44: ( COLON parent= types )?
            	int alt34 = 2;
            	int LA34_0 = input.LA(1);

            	if ( (LA34_0 == COLON) )
            	{
            	    alt34 = 1;
            	}
            	switch (alt34) 
            	{
            	    case 1 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:644:45: COLON parent= types
            	        {
            	        	Match(input,COLON,FOLLOW_COLON_in_struct_specifier2887); if (state.failed) return ;
            	        	PushFollow(FOLLOW_types_in_struct_specifier2891);
            	        	parent = types();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return ;

            	        }
            	        break;

            	}

            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:644:66: ( LEFT_BRACKET opt= compound_type_options_list RIGHT_BRACKET )?
            	int alt35 = 2;
            	int LA35_0 = input.LA(1);

            	if ( (LA35_0 == LEFT_BRACKET) )
            	{
            	    alt35 = 1;
            	}
            	switch (alt35) 
            	{
            	    case 1 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:644:67: LEFT_BRACKET opt= compound_type_options_list RIGHT_BRACKET
            	        {
            	        	Match(input,LEFT_BRACKET,FOLLOW_LEFT_BRACKET_in_struct_specifier2896); if (state.failed) return ;
            	        	PushFollow(FOLLOW_compound_type_options_list_in_struct_specifier2900);
            	        	opt = compound_type_options_list();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return ;
            	        	Match(input,RIGHT_BRACKET,FOLLOW_RIGHT_BRACKET_in_struct_specifier2902); if (state.failed) return ;

            	        }
            	        break;

            	}

            	Match(input,LEFT_BRACE,FOLLOW_LEFT_BRACE_in_struct_specifier2906); if (state.failed) return ;
            	PushFollow(FOLLOW_struct_declaration_list_in_struct_specifier2908);
            	struct_declaration_list(dec);
            	state.followingStackPointer--;
            	if (state.failed) return ;
            	Match(input,RIGHT_BRACE,FOLLOW_RIGHT_BRACE_in_struct_specifier2911); if (state.failed) return ;
            	if ( (state.backtracking==0) )
            	{
            	  	
            	  			compiler.CurrentPackage.AddStructure(dec);
            	  			
            	  			if(parent!=null)
            	  			{
            	  				StructDeclaration pdecl=new StructDeclaration();
            	  				pdecl.SetType(parent);
            	  				dec.Parent=pdecl;
            	  			}
            	  			
            	  			dec.Options=opt;
            	  		
            	}

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 49, struct_specifier_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "struct_specifier"


    // $ANTLR start "struct_declaration_list"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:659:1: struct_declaration_list[StructDeclaration d] : ( struct_declaration[$d] )* ;
    public void struct_declaration_list(StructDeclaration d) // throws RecognitionException [1]
    {   
        int struct_declaration_list_StartIndex = input.Index();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 50) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:660:2: ( ( struct_declaration[$d] )* )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:660:4: ( struct_declaration[$d] )*
            {
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:660:4: ( struct_declaration[$d] )*
            	do 
            	{
            	    int alt36 = 2;
            	    alt36 = dfa36.Predict(input);
            	    switch (alt36) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:0:0: struct_declaration[$d]
            			    {
            			    	PushFollow(FOLLOW_struct_declaration_in_struct_declaration_list2927);
            			    	struct_declaration(d);
            			    	state.followingStackPointer--;
            			    	if (state.failed) return ;

            			    }
            			    break;

            			default:
            			    goto loop36;
            	    }
            	} while (true);

            	loop36:
            		;	// Stops C# compiler whining that label 'loop36' has no statements


            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 50, struct_declaration_list_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "struct_declaration_list"


    // $ANTLR start "struct_declaration"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:663:1: struct_declaration[StructDeclaration d] : decl= declaration ( EQUAL ini= initializer_root )? ( LEFT_BRACKET opt= struct_options_list RIGHT_BRACKET )? SEMICOLON ;
    public void struct_declaration(StructDeclaration d) // throws RecognitionException [1]
    {   
        int struct_declaration_StartIndex = input.Index();
        DataField decl = default(DataField);

        Initializer ini = default(Initializer);

        List<Option> opt = default(List<Option>);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 51) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:664:2: (decl= declaration ( EQUAL ini= initializer_root )? ( LEFT_BRACKET opt= struct_options_list RIGHT_BRACKET )? SEMICOLON )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:664:4: decl= declaration ( EQUAL ini= initializer_root )? ( LEFT_BRACKET opt= struct_options_list RIGHT_BRACKET )? SEMICOLON
            {
            	PushFollow(FOLLOW_declaration_in_struct_declaration2943);
            	decl = declaration();
            	state.followingStackPointer--;
            	if (state.failed) return ;
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:664:21: ( EQUAL ini= initializer_root )?
            	int alt37 = 2;
            	int LA37_0 = input.LA(1);

            	if ( (LA37_0 == EQUAL) )
            	{
            	    alt37 = 1;
            	}
            	switch (alt37) 
            	{
            	    case 1 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:664:22: EQUAL ini= initializer_root
            	        {
            	        	Match(input,EQUAL,FOLLOW_EQUAL_in_struct_declaration2946); if (state.failed) return ;
            	        	PushFollow(FOLLOW_initializer_root_in_struct_declaration2950);
            	        	ini = initializer_root();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return ;

            	        }
            	        break;

            	}

            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:664:51: ( LEFT_BRACKET opt= struct_options_list RIGHT_BRACKET )?
            	int alt38 = 2;
            	int LA38_0 = input.LA(1);

            	if ( (LA38_0 == LEFT_BRACKET) )
            	{
            	    alt38 = 1;
            	}
            	switch (alt38) 
            	{
            	    case 1 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:664:52: LEFT_BRACKET opt= struct_options_list RIGHT_BRACKET
            	        {
            	        	Match(input,LEFT_BRACKET,FOLLOW_LEFT_BRACKET_in_struct_declaration2955); if (state.failed) return ;
            	        	PushFollow(FOLLOW_struct_options_list_in_struct_declaration2959);
            	        	opt = struct_options_list();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return ;
            	        	Match(input,RIGHT_BRACKET,FOLLOW_RIGHT_BRACKET_in_struct_declaration2961); if (state.failed) return ;

            	        }
            	        break;

            	}

            	Match(input,SEMICOLON,FOLLOW_SEMICOLON_in_struct_declaration2965); if (state.failed) return ;
            	if ( (state.backtracking==0) )
            	{

            	  			d.AddField(decl);
            	  			decl.Options=opt;
            	  			decl.Initter=ini;
            	  		
            	}

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 51, struct_declaration_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "struct_declaration"


    // $ANTLR start "entity_specifier"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:672:1: entity_specifier : ENTITY id= IDENTIFIER ( COLON parent= types )? ( LEFT_BRACKET opt= compound_type_options_list RIGHT_BRACKET )? LEFT_BRACE entity_declaration_list[dec] RIGHT_BRACE ;
    public void entity_specifier() // throws RecognitionException [1]
    {   
        int entity_specifier_StartIndex = input.Index();
        IToken id = null;
        BaseType parent = default(BaseType);

        List<Option> opt = default(List<Option>);


        EntityDeclaration dec = new EntityDeclaration();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 52) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:674:2: ( ENTITY id= IDENTIFIER ( COLON parent= types )? ( LEFT_BRACKET opt= compound_type_options_list RIGHT_BRACKET )? LEFT_BRACE entity_declaration_list[dec] RIGHT_BRACE )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:674:4: ENTITY id= IDENTIFIER ( COLON parent= types )? ( LEFT_BRACKET opt= compound_type_options_list RIGHT_BRACKET )? LEFT_BRACE entity_declaration_list[dec] RIGHT_BRACE
            {
            	Match(input,ENTITY,FOLLOW_ENTITY_in_entity_specifier2984); if (state.failed) return ;
            	id=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_entity_specifier2988); if (state.failed) return ;
            	if ( (state.backtracking==0) )
            	{
            	  dec.Token = id;
            	}
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:674:44: ( COLON parent= types )?
            	int alt39 = 2;
            	int LA39_0 = input.LA(1);

            	if ( (LA39_0 == COLON) )
            	{
            	    alt39 = 1;
            	}
            	switch (alt39) 
            	{
            	    case 1 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:674:45: COLON parent= types
            	        {
            	        	Match(input,COLON,FOLLOW_COLON_in_entity_specifier2993); if (state.failed) return ;
            	        	PushFollow(FOLLOW_types_in_entity_specifier2997);
            	        	parent = types();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return ;

            	        }
            	        break;

            	}

            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:674:66: ( LEFT_BRACKET opt= compound_type_options_list RIGHT_BRACKET )?
            	int alt40 = 2;
            	int LA40_0 = input.LA(1);

            	if ( (LA40_0 == LEFT_BRACKET) )
            	{
            	    alt40 = 1;
            	}
            	switch (alt40) 
            	{
            	    case 1 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:674:67: LEFT_BRACKET opt= compound_type_options_list RIGHT_BRACKET
            	        {
            	        	Match(input,LEFT_BRACKET,FOLLOW_LEFT_BRACKET_in_entity_specifier3002); if (state.failed) return ;
            	        	PushFollow(FOLLOW_compound_type_options_list_in_entity_specifier3006);
            	        	opt = compound_type_options_list();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return ;
            	        	Match(input,RIGHT_BRACKET,FOLLOW_RIGHT_BRACKET_in_entity_specifier3008); if (state.failed) return ;

            	        }
            	        break;

            	}

            	Match(input,LEFT_BRACE,FOLLOW_LEFT_BRACE_in_entity_specifier3012); if (state.failed) return ;
            	PushFollow(FOLLOW_entity_declaration_list_in_entity_specifier3014);
            	entity_declaration_list(dec);
            	state.followingStackPointer--;
            	if (state.failed) return ;
            	Match(input,RIGHT_BRACE,FOLLOW_RIGHT_BRACE_in_entity_specifier3017); if (state.failed) return ;
            	if ( (state.backtracking==0) )
            	{
            	  			
            	  			compiler.CurrentPackage.AddEntity(dec);
            	  			
            	  			if(parent!=null)
            	  			{
            	  				EntityDeclaration pdecl=new EntityDeclaration();
            	  				pdecl.SetType(parent);
            	  				dec.Parent=pdecl;
            	  			}
            	  			
            	  			dec.Options=opt;
            	  	
            	}

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 52, entity_specifier_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "entity_specifier"


    // $ANTLR start "entity_declaration_list"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:689:1: entity_declaration_list[EntityDeclaration d] : ( entity_declaration[$d] )* ;
    public void entity_declaration_list(EntityDeclaration d) // throws RecognitionException [1]
    {   
        int entity_declaration_list_StartIndex = input.Index();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 53) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:690:2: ( ( entity_declaration[$d] )* )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:690:4: ( entity_declaration[$d] )*
            {
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:690:4: ( entity_declaration[$d] )*
            	do 
            	{
            	    int alt41 = 2;
            	    alt41 = dfa41.Predict(input);
            	    switch (alt41) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:0:0: entity_declaration[$d]
            			    {
            			    	PushFollow(FOLLOW_entity_declaration_in_entity_declaration_list3032);
            			    	entity_declaration(d);
            			    	state.followingStackPointer--;
            			    	if (state.failed) return ;

            			    }
            			    break;

            			default:
            			    goto loop41;
            	    }
            	} while (true);

            	loop41:
            		;	// Stops C# compiler whining that label 'loop41' has no statements


            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 53, entity_declaration_list_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "entity_declaration_list"


    // $ANTLR start "entity_declaration"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:693:1: entity_declaration[EntityDeclaration d] : decl= declaration ( EQUAL ini= initializer_root )? ( LEFT_BRACKET opt= entity_options_list RIGHT_BRACKET )? SEMICOLON ;
    public void entity_declaration(EntityDeclaration d) // throws RecognitionException [1]
    {   
        int entity_declaration_StartIndex = input.Index();
        DataField decl = default(DataField);

        Initializer ini = default(Initializer);

        List<Option> opt = default(List<Option>);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 54) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:694:2: (decl= declaration ( EQUAL ini= initializer_root )? ( LEFT_BRACKET opt= entity_options_list RIGHT_BRACKET )? SEMICOLON )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:694:4: decl= declaration ( EQUAL ini= initializer_root )? ( LEFT_BRACKET opt= entity_options_list RIGHT_BRACKET )? SEMICOLON
            {
            	PushFollow(FOLLOW_declaration_in_entity_declaration3048);
            	decl = declaration();
            	state.followingStackPointer--;
            	if (state.failed) return ;
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:694:21: ( EQUAL ini= initializer_root )?
            	int alt42 = 2;
            	int LA42_0 = input.LA(1);

            	if ( (LA42_0 == EQUAL) )
            	{
            	    alt42 = 1;
            	}
            	switch (alt42) 
            	{
            	    case 1 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:694:22: EQUAL ini= initializer_root
            	        {
            	        	Match(input,EQUAL,FOLLOW_EQUAL_in_entity_declaration3051); if (state.failed) return ;
            	        	PushFollow(FOLLOW_initializer_root_in_entity_declaration3055);
            	        	ini = initializer_root();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return ;

            	        }
            	        break;

            	}

            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:694:51: ( LEFT_BRACKET opt= entity_options_list RIGHT_BRACKET )?
            	int alt43 = 2;
            	int LA43_0 = input.LA(1);

            	if ( (LA43_0 == LEFT_BRACKET) )
            	{
            	    alt43 = 1;
            	}
            	switch (alt43) 
            	{
            	    case 1 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:694:52: LEFT_BRACKET opt= entity_options_list RIGHT_BRACKET
            	        {
            	        	Match(input,LEFT_BRACKET,FOLLOW_LEFT_BRACKET_in_entity_declaration3060); if (state.failed) return ;
            	        	PushFollow(FOLLOW_entity_options_list_in_entity_declaration3064);
            	        	opt = entity_options_list();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return ;
            	        	Match(input,RIGHT_BRACKET,FOLLOW_RIGHT_BRACKET_in_entity_declaration3066); if (state.failed) return ;

            	        }
            	        break;

            	}

            	Match(input,SEMICOLON,FOLLOW_SEMICOLON_in_entity_declaration3070); if (state.failed) return ;
            	if ( (state.backtracking==0) )
            	{

            	  			d.AddField(decl);
            	  			decl.Options=opt;
            	  			decl.Initter=ini;
            	  		
            	}

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 54, entity_declaration_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "entity_declaration"

    public class unary_expression_return : ParserRuleReturnScope
    {
        public SimpleInitializer initter;
        public Expression expr;
    };

    // $ANTLR start "unary_expression"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:702:1: unary_expression returns [SimpleInitializer initter, Expression expr] : (c= constant | op= unary_operator cnt= constant );
    public DataForgeParser.unary_expression_return unary_expression() // throws RecognitionException [1]
    {   
        DataForgeParser.unary_expression_return retval = new DataForgeParser.unary_expression_return();
        retval.Start = input.LT(1);
        int unary_expression_StartIndex = input.Index();
        SimpleInitializer c = default(SimpleInitializer);

        eUnaryOp op = default(eUnaryOp);

        SimpleInitializer cnt = default(SimpleInitializer);


        retval.initter = null;
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 55) ) 
    	    {
    	    	return retval; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:719:2: (c= constant | op= unary_operator cnt= constant )
            int alt44 = 2;
            alt44 = dfa44.Predict(input);
            switch (alt44) 
            {
                case 1 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:719:4: c= constant
                    {
                    	PushFollow(FOLLOW_constant_in_unary_expression3099);
                    	c = constant();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{
                    	  retval.initter = c;
                    	}

                    }
                    break;
                case 2 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:720:5: op= unary_operator cnt= constant
                    {
                    	PushFollow(FOLLOW_unary_operator_in_unary_expression3112);
                    	op = unary_operator();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	PushFollow(FOLLOW_constant_in_unary_expression3116);
                    	cnt = constant();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{
                    	  retval.initter = cnt; retval.initter.ApplyUnaryOp(op);
                    	}

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {

              	//create an expression node with a named symbol, it is used in profile option expression evaluation	
              	if(retval.initter!=null && retval.initter.Count == 1)
              	{
              		SymbolConstant sym = retval.initter.Constants[0] as SymbolConstant;
              		if(sym != null)
              		{
              			ValueExpression val=new ValueExpression();
              			val.Token = sym.Token;
              			val.Constant = sym;
              			retval.expr =  val;
              		}
              	}

            }
        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 55, unary_expression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "unary_expression"


    // $ANTLR start "unary_operator"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:723:1: unary_operator returns [eUnaryOp op] : ( BANG | DASH );
    public eUnaryOp unary_operator() // throws RecognitionException [1]
    {   
        eUnaryOp op = default(eUnaryOp);
        int unary_operator_StartIndex = input.Index();
        op = eUnaryOp.Unknown;
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 56) ) 
    	    {
    	    	return op; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:725:2: ( BANG | DASH )
            int alt45 = 2;
            int LA45_0 = input.LA(1);

            if ( (LA45_0 == BANG) )
            {
                alt45 = 1;
            }
            else if ( (LA45_0 == DASH) )
            {
                alt45 = 2;
            }
            else 
            {
                if ( state.backtracking > 0 ) {state.failed = true; return op;}
                NoViableAltException nvae_d45s0 =
                    new NoViableAltException("", 45, 0, input);

                throw nvae_d45s0;
            }
            switch (alt45) 
            {
                case 1 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:725:4: BANG
                    {
                    	Match(input,BANG,FOLLOW_BANG_in_unary_operator3137); if (state.failed) return op;
                    	if ( (state.backtracking==0) )
                    	{
                    	  op = eUnaryOp.LogicNot;
                    	}

                    }
                    break;
                case 2 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:726:5: DASH
                    {
                    	Match(input,DASH,FOLLOW_DASH_in_unary_operator3145); if (state.failed) return op;
                    	if ( (state.backtracking==0) )
                    	{
                    	  op = eUnaryOp.Negate;
                    	}

                    }
                    break;

            }
        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 56, unary_operator_StartIndex); 
            }
        }
        return op;
    }
    // $ANTLR end "unary_operator"

    public class logical_and_expression_return : ParserRuleReturnScope
    {
        public Expression expr;
    };

    // $ANTLR start "logical_and_expression"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:730:1: logical_and_expression returns [Expression expr] : u= unary_expression (op= AND_OP u1= unary_expression )* ;
    public DataForgeParser.logical_and_expression_return logical_and_expression() // throws RecognitionException [1]
    {   
        DataForgeParser.logical_and_expression_return retval = new DataForgeParser.logical_and_expression_return();
        retval.Start = input.LT(1);
        int logical_and_expression_StartIndex = input.Index();
        IToken op = null;
        DataForgeParser.unary_expression_return u = default(DataForgeParser.unary_expression_return);

        DataForgeParser.unary_expression_return u1 = default(DataForgeParser.unary_expression_return);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 57) ) 
    	    {
    	    	return retval; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:731:2: (u= unary_expression (op= AND_OP u1= unary_expression )* )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:731:4: u= unary_expression (op= AND_OP u1= unary_expression )*
            {
            	PushFollow(FOLLOW_unary_expression_in_logical_and_expression3165);
            	u = unary_expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( (state.backtracking==0) )
            	{
            	  retval.expr = ((u != null) ? u.expr : default(Expression));compiler.CheckProfileExpression(retval.expr,((IToken)retval.Start));
            	}
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:732:3: (op= AND_OP u1= unary_expression )*
            	do 
            	{
            	    int alt46 = 2;
            	    int LA46_0 = input.LA(1);

            	    if ( (LA46_0 == AND_OP) )
            	    {
            	        alt46 = 1;
            	    }


            	    switch (alt46) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:733:4: op= AND_OP u1= unary_expression
            			    {
            			    	op=(IToken)Match(input,AND_OP,FOLLOW_AND_OP_in_logical_and_expression3178); if (state.failed) return retval;
            			    	PushFollow(FOLLOW_unary_expression_in_logical_and_expression3182);
            			    	u1 = unary_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( (state.backtracking==0) )
            			    	{

            			    	  				AndExpression e = new AndExpression();
            			    	  				e.Token=op;
            			    	  				e.Leaf1=retval.expr;
            			    	  				e.Leaf2=((u1 != null) ? u1.expr : default(Expression));
            			    	  				compiler.CheckProfileExpression(e.Leaf2,e.Token);
            			    	  				retval.expr = e;
            			    	  			
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop46;
            	    }
            	} while (true);

            	loop46:
            		;	// Stops C# compiler whining that label 'loop46' has no statements


            }

            retval.Stop = input.LT(-1);

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 57, logical_and_expression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "logical_and_expression"


    // $ANTLR start "logical_or_expression"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:745:1: logical_or_expression returns [Expression expr] : l= logical_and_expression (op= OR_OP l1= logical_and_expression )* ;
    public Expression logical_or_expression() // throws RecognitionException [1]
    {   
        Expression expr = default(Expression);
        int logical_or_expression_StartIndex = input.Index();
        IToken op = null;
        DataForgeParser.logical_and_expression_return l = default(DataForgeParser.logical_and_expression_return);

        DataForgeParser.logical_and_expression_return l1 = default(DataForgeParser.logical_and_expression_return);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 58) ) 
    	    {
    	    	return expr; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:746:2: (l= logical_and_expression (op= OR_OP l1= logical_and_expression )* )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:746:4: l= logical_and_expression (op= OR_OP l1= logical_and_expression )*
            {
            	PushFollow(FOLLOW_logical_and_expression_in_logical_or_expression3208);
            	l = logical_and_expression();
            	state.followingStackPointer--;
            	if (state.failed) return expr;
            	if ( (state.backtracking==0) )
            	{
            	  expr = ((l != null) ? l.expr : default(Expression));
            	}
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:747:3: (op= OR_OP l1= logical_and_expression )*
            	do 
            	{
            	    int alt47 = 2;
            	    int LA47_0 = input.LA(1);

            	    if ( (LA47_0 == OR_OP) )
            	    {
            	        alt47 = 1;
            	    }


            	    switch (alt47) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:748:4: op= OR_OP l1= logical_and_expression
            			    {
            			    	op=(IToken)Match(input,OR_OP,FOLLOW_OR_OP_in_logical_or_expression3221); if (state.failed) return expr;
            			    	PushFollow(FOLLOW_logical_and_expression_in_logical_or_expression3225);
            			    	l1 = logical_and_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return expr;
            			    	if ( (state.backtracking==0) )
            			    	{

            			    	  				OrExpression e = new OrExpression();
            			    	  				e.Token=op;
            			    	  				e.Leaf1=expr;
            			    	  				e.Leaf2=((l1 != null) ? l1.expr : default(Expression));				
            			    	  				expr = e;
            			    	  			
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop47;
            	    }
            	} while (true);

            	loop47:
            		;	// Stops C# compiler whining that label 'loop47' has no statements


            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 58, logical_or_expression_StartIndex); 
            }
        }
        return expr;
    }
    // $ANTLR end "logical_or_expression"


    // $ANTLR start "expression"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:759:1: expression returns [Expression expr] : ex= logical_or_expression ;
    public Expression expression() // throws RecognitionException [1]
    {   
        Expression expr = default(Expression);
        int expression_StartIndex = input.Index();
        Expression ex = default(Expression);


        ExpressionRoot root = new ExpressionRoot(); expr =  root;
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 59) ) 
    	    {
    	    	return expr; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:761:2: (ex= logical_or_expression )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:761:4: ex= logical_or_expression
            {
            	PushFollow(FOLLOW_logical_or_expression_in_expression3256);
            	ex = logical_or_expression();
            	state.followingStackPointer--;
            	if (state.failed) return expr;
            	if ( (state.backtracking==0) )
            	{
            	  root.Root=ex;
            	}

            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 59, expression_StartIndex); 
            }
        }
        return expr;
    }
    // $ANTLR end "expression"


    // $ANTLR start "data_structures"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:764:1: data_structures : ( constant_declaration | enum_specifier | struct_specifier | entity_specifier );
    public void data_structures() // throws RecognitionException [1]
    {   
        int data_structures_StartIndex = input.Index();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 60) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:765:2: ( constant_declaration | enum_specifier | struct_specifier | entity_specifier )
            int alt48 = 4;
            switch ( input.LA(1) ) 
            {
            case CONST:
            	{
                alt48 = 1;
                }
                break;
            case ENUM:
            	{
                alt48 = 2;
                }
                break;
            case STRUCT:
            	{
                alt48 = 3;
                }
                break;
            case ENTITY:
            	{
                alt48 = 4;
                }
                break;
            	default:
            	    if ( state.backtracking > 0 ) {state.failed = true; return ;}
            	    NoViableAltException nvae_d48s0 =
            	        new NoViableAltException("", 48, 0, input);

            	    throw nvae_d48s0;
            }

            switch (alt48) 
            {
                case 1 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:765:4: constant_declaration
                    {
                    	PushFollow(FOLLOW_constant_declaration_in_data_structures3269);
                    	constant_declaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return ;

                    }
                    break;
                case 2 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:766:4: enum_specifier
                    {
                    	PushFollow(FOLLOW_enum_specifier_in_data_structures3274);
                    	enum_specifier();
                    	state.followingStackPointer--;
                    	if (state.failed) return ;

                    }
                    break;
                case 3 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:767:4: struct_specifier
                    {
                    	PushFollow(FOLLOW_struct_specifier_in_data_structures3279);
                    	struct_specifier();
                    	state.followingStackPointer--;
                    	if (state.failed) return ;

                    }
                    break;
                case 4 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:768:4: entity_specifier
                    {
                    	PushFollow(FOLLOW_entity_specifier_in_data_structures3284);
                    	entity_specifier();
                    	state.followingStackPointer--;
                    	if (state.failed) return ;

                    }
                    break;

            }
        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 60, data_structures_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "data_structures"


    // $ANTLR start "translation_unit"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:771:1: translation_unit : ( package_rule )? ( imports )? ( cpp )? ( data_structures )* ;
    public void translation_unit() // throws RecognitionException [1]
    {   
        int translation_unit_StartIndex = input.Index();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 61) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:772:2: ( ( package_rule )? ( imports )? ( cpp )? ( data_structures )* )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:772:4: ( package_rule )? ( imports )? ( cpp )? ( data_structures )*
            {
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:772:4: ( package_rule )?
            	int alt49 = 2;
            	int LA49_0 = input.LA(1);

            	if ( (LA49_0 == PACKAGE) )
            	{
            	    alt49 = 1;
            	}
            	switch (alt49) 
            	{
            	    case 1 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:0:0: package_rule
            	        {
            	        	PushFollow(FOLLOW_package_rule_in_translation_unit3295);
            	        	package_rule();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return ;

            	        }
            	        break;

            	}

            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:772:18: ( imports )?
            	int alt50 = 2;
            	int LA50_0 = input.LA(1);

            	if ( (LA50_0 == IMPORTS) )
            	{
            	    alt50 = 1;
            	}
            	switch (alt50) 
            	{
            	    case 1 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:0:0: imports
            	        {
            	        	PushFollow(FOLLOW_imports_in_translation_unit3298);
            	        	imports();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return ;

            	        }
            	        break;

            	}

            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:772:27: ( cpp )?
            	int alt51 = 2;
            	int LA51_0 = input.LA(1);

            	if ( (LA51_0 == CPP) )
            	{
            	    alt51 = 1;
            	}
            	switch (alt51) 
            	{
            	    case 1 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:0:0: cpp
            	        {
            	        	PushFollow(FOLLOW_cpp_in_translation_unit3301);
            	        	cpp();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return ;

            	        }
            	        break;

            	}

            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:772:32: ( data_structures )*
            	do 
            	{
            	    int alt52 = 2;
            	    int LA52_0 = input.LA(1);

            	    if ( ((LA52_0 >= CONST && LA52_0 <= ENUM) || LA52_0 == ENTITY) )
            	    {
            	        alt52 = 1;
            	    }


            	    switch (alt52) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:0:0: data_structures
            			    {
            			    	PushFollow(FOLLOW_data_structures_in_translation_unit3304);
            			    	data_structures();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return ;

            			    }
            			    break;

            			default:
            			    goto loop52;
            	    }
            	} while (true);

            	loop52:
            		;	// Stops C# compiler whining that label 'loop52' has no statements


            }

        }

        	catch (RecognitionException e) 
        	{
        		throw e;
        	}
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 61, translation_unit_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "translation_unit"

    // $ANTLR start "synpred70_DataForge"
    public void synpred70_DataForge_fragment() {
        EnumConstant ef = default(EnumConstant);


        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:559:4: (ef= enum_field )
        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:559:4: ef= enum_field
        {
        	PushFollow(FOLLOW_enum_field_in_synpred70_DataForge2441);
        	ef = enum_field();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred70_DataForge"

    // $ANTLR start "synpred73_DataForge"
    public void synpred73_DataForge_fragment() {
        DataForgeParser.unary_expression_return ue = default(DataForgeParser.unary_expression_return);


        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:577:4: (ue= unary_expression )
        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:577:4: ue= unary_expression
        {
        	PushFollow(FOLLOW_unary_expression_in_synpred73_DataForge2547);
        	ue = unary_expression();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred73_DataForge"

    // $ANTLR start "synpred74_DataForge"
    public void synpred74_DataForge_fragment() {
        Initializer li2 = default(Initializer);


        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:583:61: ( COMMA li2= list_initializer )
        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:583:61: COMMA li2= list_initializer
        {
        	Match(input,COMMA,FOLLOW_COMMA_in_synpred74_DataForge2587); if (state.failed) return ;
        	PushFollow(FOLLOW_list_initializer_in_synpred74_DataForge2591);
        	li2 = list_initializer();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred74_DataForge"

    // $ANTLR start "synpred75_DataForge"
    public void synpred75_DataForge_fragment() {
        DataForgeParser.unary_expression_return ue = default(DataForgeParser.unary_expression_return);


        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:589:5: (ue= unary_expression )
        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:589:5: ue= unary_expression
        {
        	PushFollow(FOLLOW_unary_expression_in_synpred75_DataForge2630);
        	ue = unary_expression();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred75_DataForge"

    // $ANTLR start "synpred76_DataForge"
    public void synpred76_DataForge_fragment() {
        Initializer mi2 = default(Initializer);


        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:596:60: ( COMMA mi2= map_initializer )
        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:596:60: COMMA mi2= map_initializer
        {
        	Match(input,COMMA,FOLLOW_COMMA_in_synpred76_DataForge2675); if (state.failed) return ;
        	PushFollow(FOLLOW_map_initializer_in_synpred76_DataForge2679);
        	mi2 = map_initializer();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred76_DataForge"

    // $ANTLR start "synpred77_DataForge"
    public void synpred77_DataForge_fragment() {
        DataForgeParser.unary_expression_return ue = default(DataForgeParser.unary_expression_return);


        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:600:4: (ue= unary_expression )
        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:600:4: ue= unary_expression
        {
        	PushFollow(FOLLOW_unary_expression_in_synpred77_DataForge2701);
        	ue = unary_expression();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred77_DataForge"

    // $ANTLR start "synpred78_DataForge"
    public void synpred78_DataForge_fragment() {
        Initializer mi = default(Initializer);


        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:601:4: (mi= map_initializer_list )
        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:601:4: mi= map_initializer_list
        {
        	PushFollow(FOLLOW_map_initializer_list_in_synpred78_DataForge2711);
        	mi = map_initializer_list();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred78_DataForge"

    // $ANTLR start "synpred81_DataForge"
    public void synpred81_DataForge_fragment() {
        Initializer ini1 = default(Initializer);


        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:638:4: ( LEFT_BRACE ini1= initializer RIGHT_BRACE )
        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:638:4: LEFT_BRACE ini1= initializer RIGHT_BRACE
        {
        	Match(input,LEFT_BRACE,FOLLOW_LEFT_BRACE_in_synpred81_DataForge2842); if (state.failed) return ;
        	PushFollow(FOLLOW_initializer_in_synpred81_DataForge2846);
        	ini1 = initializer();
        	state.followingStackPointer--;
        	if (state.failed) return ;
        	Match(input,RIGHT_BRACE,FOLLOW_RIGHT_BRACE_in_synpred81_DataForge2848); if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred81_DataForge"

    // Delegated rules

   	public bool synpred76_DataForge() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred76_DataForge_fragment(); // can never throw exception
   	    }
   	    catch (RecognitionException re) 
   	    {
   	        Console.Error.WriteLine("impossible: "+re);
   	    }
   	    bool success = !state.failed;
   	    input.Rewind(start);
   	    state.backtracking--;
   	    state.failed = false;
   	    return success;
   	}
   	public bool synpred73_DataForge() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred73_DataForge_fragment(); // can never throw exception
   	    }
   	    catch (RecognitionException re) 
   	    {
   	        Console.Error.WriteLine("impossible: "+re);
   	    }
   	    bool success = !state.failed;
   	    input.Rewind(start);
   	    state.backtracking--;
   	    state.failed = false;
   	    return success;
   	}
   	public bool synpred75_DataForge() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred75_DataForge_fragment(); // can never throw exception
   	    }
   	    catch (RecognitionException re) 
   	    {
   	        Console.Error.WriteLine("impossible: "+re);
   	    }
   	    bool success = !state.failed;
   	    input.Rewind(start);
   	    state.backtracking--;
   	    state.failed = false;
   	    return success;
   	}
   	public bool synpred81_DataForge() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred81_DataForge_fragment(); // can never throw exception
   	    }
   	    catch (RecognitionException re) 
   	    {
   	        Console.Error.WriteLine("impossible: "+re);
   	    }
   	    bool success = !state.failed;
   	    input.Rewind(start);
   	    state.backtracking--;
   	    state.failed = false;
   	    return success;
   	}
   	public bool synpred74_DataForge() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred74_DataForge_fragment(); // can never throw exception
   	    }
   	    catch (RecognitionException re) 
   	    {
   	        Console.Error.WriteLine("impossible: "+re);
   	    }
   	    bool success = !state.failed;
   	    input.Rewind(start);
   	    state.backtracking--;
   	    state.failed = false;
   	    return success;
   	}
   	public bool synpred70_DataForge() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred70_DataForge_fragment(); // can never throw exception
   	    }
   	    catch (RecognitionException re) 
   	    {
   	        Console.Error.WriteLine("impossible: "+re);
   	    }
   	    bool success = !state.failed;
   	    input.Rewind(start);
   	    state.backtracking--;
   	    state.failed = false;
   	    return success;
   	}
   	public bool synpred78_DataForge() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred78_DataForge_fragment(); // can never throw exception
   	    }
   	    catch (RecognitionException re) 
   	    {
   	        Console.Error.WriteLine("impossible: "+re);
   	    }
   	    bool success = !state.failed;
   	    input.Rewind(start);
   	    state.backtracking--;
   	    state.failed = false;
   	    return success;
   	}
   	public bool synpred77_DataForge() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred77_DataForge_fragment(); // can never throw exception
   	    }
   	    catch (RecognitionException re) 
   	    {
   	        Console.Error.WriteLine("impossible: "+re);
   	    }
   	    bool success = !state.failed;
   	    input.Rewind(start);
   	    state.backtracking--;
   	    state.failed = false;
   	    return success;
   	}


   	protected DFA2 dfa2;
   	protected DFA10 dfa10;
   	protected DFA11 dfa11;
   	protected DFA13 dfa13;
   	protected DFA22 dfa22;
   	protected DFA23 dfa23;
   	protected DFA26 dfa26;
   	protected DFA27 dfa27;
   	protected DFA28 dfa28;
   	protected DFA29 dfa29;
   	protected DFA30 dfa30;
   	protected DFA31 dfa31;
   	protected DFA33 dfa33;
   	protected DFA36 dfa36;
   	protected DFA41 dfa41;
   	protected DFA44 dfa44;
	private void InitializeCyclicDFAs()
	{
    	this.dfa2 = new DFA2(this);
    	this.dfa10 = new DFA10(this);
    	this.dfa11 = new DFA11(this);
    	this.dfa13 = new DFA13(this);
    	this.dfa22 = new DFA22(this);
    	this.dfa23 = new DFA23(this);
    	this.dfa26 = new DFA26(this);
    	this.dfa27 = new DFA27(this);
    	this.dfa28 = new DFA28(this);
    	this.dfa29 = new DFA29(this);
    	this.dfa30 = new DFA30(this);
    	this.dfa31 = new DFA31(this);
    	this.dfa33 = new DFA33(this);
    	this.dfa36 = new DFA36(this);
    	this.dfa41 = new DFA41(this);
    	this.dfa44 = new DFA44(this);
	    this.dfa23.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA23_SpecialStateTransition);
	    this.dfa26.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA26_SpecialStateTransition);
	    this.dfa27.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA27_SpecialStateTransition);
	    this.dfa28.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA28_SpecialStateTransition);
	    this.dfa29.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA29_SpecialStateTransition);
	    this.dfa30.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA30_SpecialStateTransition);
	    this.dfa33.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA33_SpecialStateTransition);
	}

    const string DFA2_eotS =
        "\x25\uffff";
    const string DFA2_eofS =
        "\x25\uffff";
    const string DFA2_minS =
        "\x01\x2e\x24\uffff";
    const string DFA2_maxS =
        "\x01\x5c\x24\uffff";
    const string DFA2_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
        "\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x01\x0e\x01"+
        "\x0f\x01\x10\x01\x11\x01\x12\x01\x13\x01\x14\x01\x15\x01\x16\x01"+
        "\x17\x01\x18\x01\x19\x01\x1a\x01\x1b\x01\x1c\x01\x1d\x01\x1e\x01"+
        "\x1f\x01\x20\x01\x21\x01\x22\x01\x23\x01\x24";
    const string DFA2_specialS =
        "\x25\uffff}>";
    static readonly string[] DFA2_transitionS = {
            "\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01\x07\x01"+
            "\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x01\x0e\x01\x0f"+
            "\x01\x10\x01\x11\x01\x12\x01\x13\x01\x14\x01\x15\x01\x16\x01"+
            "\x17\x01\x18\x01\x19\x01\x1a\x01\x1b\x01\x1c\x01\x1d\x01\x1e"+
            "\x01\x1f\x01\x20\x01\x21\x01\x22\x01\x23\x0b\uffff\x01\x24",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA2_eot = DFA.UnpackEncodedString(DFA2_eotS);
    static readonly short[] DFA2_eof = DFA.UnpackEncodedString(DFA2_eofS);
    static readonly char[] DFA2_min = DFA.UnpackEncodedStringToUnsignedChars(DFA2_minS);
    static readonly char[] DFA2_max = DFA.UnpackEncodedStringToUnsignedChars(DFA2_maxS);
    static readonly short[] DFA2_accept = DFA.UnpackEncodedString(DFA2_acceptS);
    static readonly short[] DFA2_special = DFA.UnpackEncodedString(DFA2_specialS);
    static readonly short[][] DFA2_transition = DFA.UnpackEncodedStringArray(DFA2_transitionS);

    protected class DFA2 : DFA
    {
        public DFA2(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 2;
            this.eot = DFA2_eot;
            this.eof = DFA2_eof;
            this.min = DFA2_min;
            this.max = DFA2_max;
            this.accept = DFA2_accept;
            this.special = DFA2_special;
            this.transition = DFA2_transition;

        }

        override public string Description
        {
            get { return "197:1: types returns [BaseType type] : ( BOOL | FLOAT | DOUBLE | REAL | INT64 | INT32 | INT16 | INT8 | UINT64 | UINT32 | UINT16 | UINT8 | STRING | CSTRING | VEC2 | VEC3 | VEC4 | MAT2X2 | MAT3X3 | MAT4X4 | QUAT | VEC2F | VEC3F | VEC4F | MAT2X2F | MAT3X3F | MAT4X4F | QUATF | VEC2D | VEC3D | VEC4D | MAT2X2D | MAT3X3D | MAT4X4D | QUATD | (pq= IDENTIFIER DOT )* tn= IDENTIFIER );"; }
        }

    }

    const string DFA10_eotS =
        "\x29\uffff";
    const string DFA10_eofS =
        "\x29\uffff";
    const string DFA10_minS =
        "\x01\x0b\x28\uffff";
    const string DFA10_maxS =
        "\x01\x5c\x28\uffff";
    const string DFA10_acceptS =
        "\x01\uffff\x01\x01\x03\uffff\x01\x02\x23\uffff";
    const string DFA10_specialS =
        "\x29\uffff}>";
    static readonly string[] DFA10_transitionS = {
            "\x04\x01\x1f\uffff\x23\x05\x0b\uffff\x01\x05",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA10_eot = DFA.UnpackEncodedString(DFA10_eotS);
    static readonly short[] DFA10_eof = DFA.UnpackEncodedString(DFA10_eofS);
    static readonly char[] DFA10_min = DFA.UnpackEncodedStringToUnsignedChars(DFA10_minS);
    static readonly char[] DFA10_max = DFA.UnpackEncodedStringToUnsignedChars(DFA10_maxS);
    static readonly short[] DFA10_accept = DFA.UnpackEncodedString(DFA10_acceptS);
    static readonly short[] DFA10_special = DFA.UnpackEncodedString(DFA10_specialS);
    static readonly short[][] DFA10_transition = DFA.UnpackEncodedStringArray(DFA10_transitionS);

    protected class DFA10 : DFA
    {
        public DFA10(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 10;
            this.eot = DFA10_eot;
            this.eof = DFA10_eof;
            this.min = DFA10_min;
            this.max = DFA10_max;
            this.accept = DFA10_accept;
            this.special = DFA10_special;
            this.transition = DFA10_transition;

        }

        override public string Description
        {
            get { return "362:20: (subT= subcontainer_types | valT= types )"; }
        }

    }

    const string DFA11_eotS =
        "\x29\uffff";
    const string DFA11_eofS =
        "\x29\uffff";
    const string DFA11_minS =
        "\x01\x0b\x28\uffff";
    const string DFA11_maxS =
        "\x01\x5c\x28\uffff";
    const string DFA11_acceptS =
        "\x01\uffff\x01\x01\x03\uffff\x01\x02\x23\uffff";
    const string DFA11_specialS =
        "\x29\uffff}>";
    static readonly string[] DFA11_transitionS = {
            "\x04\x01\x1f\uffff\x23\x05\x0b\uffff\x01\x05",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA11_eot = DFA.UnpackEncodedString(DFA11_eotS);
    static readonly short[] DFA11_eof = DFA.UnpackEncodedString(DFA11_eofS);
    static readonly char[] DFA11_min = DFA.UnpackEncodedStringToUnsignedChars(DFA11_minS);
    static readonly char[] DFA11_max = DFA.UnpackEncodedStringToUnsignedChars(DFA11_maxS);
    static readonly short[] DFA11_accept = DFA.UnpackEncodedString(DFA11_acceptS);
    static readonly short[] DFA11_special = DFA.UnpackEncodedString(DFA11_specialS);
    static readonly short[][] DFA11_transition = DFA.UnpackEncodedStringArray(DFA11_transitionS);

    protected class DFA11 : DFA
    {
        public DFA11(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 11;
            this.eot = DFA11_eot;
            this.eof = DFA11_eof;
            this.min = DFA11_min;
            this.max = DFA11_max;
            this.accept = DFA11_accept;
            this.special = DFA11_special;
            this.transition = DFA11_transition;

        }

        override public string Description
        {
            get { return "378:36: (subT= subcontainer_types | valT= types )"; }
        }

    }

    const string DFA13_eotS =
        "\x29\uffff";
    const string DFA13_eofS =
        "\x29\uffff";
    const string DFA13_minS =
        "\x01\x0b\x28\uffff";
    const string DFA13_maxS =
        "\x01\x5c\x28\uffff";
    const string DFA13_acceptS =
        "\x01\uffff\x01\x01\x23\uffff\x01\x02\x01\x03\x01\x04\x01\x05";
    const string DFA13_specialS =
        "\x29\uffff}>";
    static readonly string[] DFA13_transitionS = {
            "\x01\x27\x01\x28\x01\x25\x01\x26\x1f\uffff\x23\x01\x0b\uffff"+
            "\x01\x01",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA13_eot = DFA.UnpackEncodedString(DFA13_eotS);
    static readonly short[] DFA13_eof = DFA.UnpackEncodedString(DFA13_eofS);
    static readonly char[] DFA13_min = DFA.UnpackEncodedStringToUnsignedChars(DFA13_minS);
    static readonly char[] DFA13_max = DFA.UnpackEncodedStringToUnsignedChars(DFA13_maxS);
    static readonly short[] DFA13_accept = DFA.UnpackEncodedString(DFA13_acceptS);
    static readonly short[] DFA13_special = DFA.UnpackEncodedString(DFA13_specialS);
    static readonly short[][] DFA13_transition = DFA.UnpackEncodedStringArray(DFA13_transitionS);

    protected class DFA13 : DFA
    {
        public DFA13(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 13;
            this.eot = DFA13_eot;
            this.eof = DFA13_eof;
            this.min = DFA13_min;
            this.max = DFA13_max;
            this.accept = DFA13_accept;
            this.special = DFA13_special;
            this.transition = DFA13_transition;

        }

        override public string Description
        {
            get { return "450:1: declaration returns [DataField field] : (sd= simple_declaration | rd= reference_declaration | wd= weak_reference_declaration | ld= list_declaration | md= map_declaration );"; }
        }

    }

    const string DFA22_eotS =
        "\x0b\uffff";
    const string DFA22_eofS =
        "\x01\uffff\x01\x03\x09\uffff";
    const string DFA22_minS =
        "\x01\x5c\x01\x17\x09\uffff";
    const string DFA22_maxS =
        "\x01\x5c\x01\x26\x09\uffff";
    const string DFA22_acceptS =
        "\x02\uffff\x01\x01\x01\x02\x07\uffff";
    const string DFA22_specialS =
        "\x0b\uffff}>";
    static readonly string[] DFA22_transitionS = {
            "\x01\x01",
            "\x01\x03\x04\uffff\x01\x02\x01\x03\x02\uffff\x03\x03\x02\uffff"+
            "\x02\x03",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA22_eot = DFA.UnpackEncodedString(DFA22_eotS);
    static readonly short[] DFA22_eof = DFA.UnpackEncodedString(DFA22_eofS);
    static readonly char[] DFA22_min = DFA.UnpackEncodedStringToUnsignedChars(DFA22_minS);
    static readonly char[] DFA22_max = DFA.UnpackEncodedStringToUnsignedChars(DFA22_maxS);
    static readonly short[] DFA22_accept = DFA.UnpackEncodedString(DFA22_acceptS);
    static readonly short[] DFA22_special = DFA.UnpackEncodedString(DFA22_specialS);
    static readonly short[][] DFA22_transition = DFA.UnpackEncodedStringArray(DFA22_transitionS);

    protected class DFA22 : DFA
    {
        public DFA22(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 22;
            this.eot = DFA22_eot;
            this.eof = DFA22_eof;
            this.min = DFA22_min;
            this.max = DFA22_max;
            this.accept = DFA22_accept;
            this.special = DFA22_special;
            this.transition = DFA22_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 549:4: (pq= IDENTIFIER DOT )*"; }
        }

    }

    const string DFA23_eotS =
        "\x11\uffff";
    const string DFA23_eofS =
        "\x06\uffff\x01\x09\x0a\uffff";
    const string DFA23_minS =
        "\x01\x0f\x05\uffff\x01\x17\x01\x00\x09\uffff";
    const string DFA23_maxS =
        "\x01\x5c\x05\uffff\x01\x26\x01\x00\x09\uffff";
    const string DFA23_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x02\uffff\x01"+
        "\x06\x01\x07\x07\uffff";
    const string DFA23_specialS =
        "\x07\uffff\x01\x00\x09\uffff}>";
    static readonly string[] DFA23_transitionS = {
            "\x01\x01\x01\x02\x47\uffff\x01\x03\x01\uffff\x01\x05\x01\x04"+
            "\x01\x06",
            "",
            "",
            "",
            "",
            "",
            "\x01\x09\x04\uffff\x01\x07\x01\x09\x01\x08\x01\uffff\x03\x09"+
            "\x02\uffff\x02\x09",
            "\x01\uffff",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA23_eot = DFA.UnpackEncodedString(DFA23_eotS);
    static readonly short[] DFA23_eof = DFA.UnpackEncodedString(DFA23_eofS);
    static readonly char[] DFA23_min = DFA.UnpackEncodedStringToUnsignedChars(DFA23_minS);
    static readonly char[] DFA23_max = DFA.UnpackEncodedStringToUnsignedChars(DFA23_maxS);
    static readonly short[] DFA23_accept = DFA.UnpackEncodedString(DFA23_acceptS);
    static readonly short[] DFA23_special = DFA.UnpackEncodedString(DFA23_specialS);
    static readonly short[][] DFA23_transition = DFA.UnpackEncodedStringArray(DFA23_transitionS);

    protected class DFA23 : DFA
    {
        public DFA23(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 23;
            this.eot = DFA23_eot;
            this.eof = DFA23_eof;
            this.min = DFA23_min;
            this.max = DFA23_max;
            this.accept = DFA23_accept;
            this.special = DFA23_special;
            this.transition = DFA23_transition;

        }

        override public string Description
        {
            get { return "552:1: simple_constant returns [IConstant constant] : (t0= TRUE | t1= FALSE | i= INTCONSTANT | f= FLOATCONSTANT | s= STRING_LITERAL | ef= enum_field | nc= named_constant );"; }
        }

    }


    protected internal int DFA23_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA23_7 = input.LA(1);

                   	 
                   	int index23_7 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred70_DataForge()) ) { s = 8; }

                   	else if ( (true) ) { s = 9; }

                   	 
                   	input.Seek(index23_7);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae23 =
            new NoViableAltException(dfa.Description, 23, _s, input);
        dfa.Error(nvae23);
        throw nvae23;
    }
    const string DFA26_eotS =
        "\x32\uffff";
    const string DFA26_eofS =
        "\x32\uffff";
    const string DFA26_minS =
        "\x01\x0f\x06\x00\x03\x0f\x11\uffff\x06\x00\x03\uffff\x0e\x00";
    const string DFA26_maxS =
        "\x01\x5c\x06\x00\x03\x5c\x11\uffff\x06\x00\x03\uffff\x0e\x00";
    const string DFA26_acceptS =
        "\x0c\uffff\x01\x01\x01\x02\x24\uffff";
    const string DFA26_specialS =
        "\x01\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x14"+
        "\uffff\x01\x06\x01\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x03\uffff"+
        "\x01\x0c\x01\x0d\x01\x0e\x01\x0f\x01\x10\x01\x11\x01\x12\x01\x13"+
        "\x01\x14\x01\x15\x01\x16\x01\x17\x01\x18\x01\x19}>";
    static readonly string[] DFA26_transitionS = {
            "\x01\x01\x01\x02\x0e\uffff\x01\x07\x07\uffff\x01\x08\x01\uffff"+
            "\x01\x09\x2e\uffff\x01\x03\x01\uffff\x01\x05\x01\x04\x01\x06",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\x1c\x01\x1d\x0e\uffff\x01\x0d\x07\uffff\x01\x0d\x01\uffff"+
            "\x01\x0d\x2e\uffff\x01\x1e\x01\uffff\x01\x1b\x01\x1f\x01\x20",
            "\x01\x24\x01\x25\x0e\uffff\x01\x2a\x38\uffff\x01\x26\x01\uffff"+
            "\x01\x28\x01\x27\x01\x29",
            "\x01\x2b\x01\x2c\x0e\uffff\x01\x31\x38\uffff\x01\x2d\x01\uffff"+
            "\x01\x2f\x01\x2e\x01\x30",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "",
            "",
            "",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff"
    };

    static readonly short[] DFA26_eot = DFA.UnpackEncodedString(DFA26_eotS);
    static readonly short[] DFA26_eof = DFA.UnpackEncodedString(DFA26_eofS);
    static readonly char[] DFA26_min = DFA.UnpackEncodedStringToUnsignedChars(DFA26_minS);
    static readonly char[] DFA26_max = DFA.UnpackEncodedStringToUnsignedChars(DFA26_maxS);
    static readonly short[] DFA26_accept = DFA.UnpackEncodedString(DFA26_acceptS);
    static readonly short[] DFA26_special = DFA.UnpackEncodedString(DFA26_specialS);
    static readonly short[][] DFA26_transition = DFA.UnpackEncodedStringArray(DFA26_transitionS);

    protected class DFA26 : DFA
    {
        public DFA26(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 26;
            this.eot = DFA26_eot;
            this.eof = DFA26_eof;
            this.min = DFA26_min;
            this.max = DFA26_max;
            this.accept = DFA26_accept;
            this.special = DFA26_special;
            this.transition = DFA26_transition;

        }

        override public string Description
        {
            get { return "577:3: (ue= unary_expression | il= initializer_list )"; }
        }

    }


    protected internal int DFA26_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA26_1 = input.LA(1);

                   	 
                   	int index26_1 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred73_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index26_1);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA26_2 = input.LA(1);

                   	 
                   	int index26_2 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred73_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index26_2);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 2 : 
                   	int LA26_3 = input.LA(1);

                   	 
                   	int index26_3 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred73_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index26_3);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 3 : 
                   	int LA26_4 = input.LA(1);

                   	 
                   	int index26_4 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred73_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index26_4);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 4 : 
                   	int LA26_5 = input.LA(1);

                   	 
                   	int index26_5 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred73_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index26_5);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 5 : 
                   	int LA26_6 = input.LA(1);

                   	 
                   	int index26_6 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred73_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index26_6);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 6 : 
                   	int LA26_27 = input.LA(1);

                   	 
                   	int index26_27 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred73_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index26_27);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 7 : 
                   	int LA26_28 = input.LA(1);

                   	 
                   	int index26_28 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred73_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index26_28);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 8 : 
                   	int LA26_29 = input.LA(1);

                   	 
                   	int index26_29 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred73_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index26_29);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 9 : 
                   	int LA26_30 = input.LA(1);

                   	 
                   	int index26_30 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred73_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index26_30);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 10 : 
                   	int LA26_31 = input.LA(1);

                   	 
                   	int index26_31 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred73_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index26_31);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 11 : 
                   	int LA26_32 = input.LA(1);

                   	 
                   	int index26_32 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred73_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index26_32);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 12 : 
                   	int LA26_36 = input.LA(1);

                   	 
                   	int index26_36 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred73_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index26_36);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 13 : 
                   	int LA26_37 = input.LA(1);

                   	 
                   	int index26_37 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred73_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index26_37);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 14 : 
                   	int LA26_38 = input.LA(1);

                   	 
                   	int index26_38 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred73_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index26_38);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 15 : 
                   	int LA26_39 = input.LA(1);

                   	 
                   	int index26_39 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred73_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index26_39);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 16 : 
                   	int LA26_40 = input.LA(1);

                   	 
                   	int index26_40 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred73_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index26_40);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 17 : 
                   	int LA26_41 = input.LA(1);

                   	 
                   	int index26_41 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred73_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index26_41);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 18 : 
                   	int LA26_42 = input.LA(1);

                   	 
                   	int index26_42 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred73_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index26_42);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 19 : 
                   	int LA26_43 = input.LA(1);

                   	 
                   	int index26_43 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred73_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index26_43);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 20 : 
                   	int LA26_44 = input.LA(1);

                   	 
                   	int index26_44 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred73_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index26_44);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 21 : 
                   	int LA26_45 = input.LA(1);

                   	 
                   	int index26_45 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred73_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index26_45);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 22 : 
                   	int LA26_46 = input.LA(1);

                   	 
                   	int index26_46 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred73_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index26_46);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 23 : 
                   	int LA26_47 = input.LA(1);

                   	 
                   	int index26_47 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred73_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index26_47);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 24 : 
                   	int LA26_48 = input.LA(1);

                   	 
                   	int index26_48 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred73_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index26_48);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 25 : 
                   	int LA26_49 = input.LA(1);

                   	 
                   	int index26_49 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred73_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index26_49);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae26 =
            new NoViableAltException(dfa.Description, 26, _s, input);
        dfa.Error(nvae26);
        throw nvae26;
    }
    const string DFA27_eotS =
        "\x10\uffff";
    const string DFA27_eofS =
        "\x01\x02\x0f\uffff";
    const string DFA27_minS =
        "\x01\x17\x01\x0f\x0a\uffff\x01\x00\x03\uffff";
    const string DFA27_maxS =
        "\x01\x21\x01\x5c\x0a\uffff\x01\x00\x03\uffff";
    const string DFA27_acceptS =
        "\x02\uffff\x01\x02\x0c\uffff\x01\x01";
    const string DFA27_specialS =
        "\x0c\uffff\x01\x00\x03\uffff}>";
    static readonly string[] DFA27_transitionS = {
            "\x01\x02\x05\uffff\x01\x01\x02\uffff\x02\x02",
            "\x02\x02\x0e\uffff\x01\x0c\x07\uffff\x01\x02\x01\uffff\x01"+
            "\x02\x2e\uffff\x01\x02\x01\uffff\x03\x02",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\uffff",
            "",
            "",
            ""
    };

    static readonly short[] DFA27_eot = DFA.UnpackEncodedString(DFA27_eotS);
    static readonly short[] DFA27_eof = DFA.UnpackEncodedString(DFA27_eofS);
    static readonly char[] DFA27_min = DFA.UnpackEncodedStringToUnsignedChars(DFA27_minS);
    static readonly char[] DFA27_max = DFA.UnpackEncodedStringToUnsignedChars(DFA27_maxS);
    static readonly short[] DFA27_accept = DFA.UnpackEncodedString(DFA27_acceptS);
    static readonly short[] DFA27_special = DFA.UnpackEncodedString(DFA27_specialS);
    static readonly short[][] DFA27_transition = DFA.UnpackEncodedStringArray(DFA27_transitionS);

    protected class DFA27 : DFA
    {
        public DFA27(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 27;
            this.eot = DFA27_eot;
            this.eof = DFA27_eof;
            this.min = DFA27_min;
            this.max = DFA27_max;
            this.accept = DFA27_accept;
            this.special = DFA27_special;
            this.transition = DFA27_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 583:60: ( COMMA li2= list_initializer )*"; }
        }

    }


    protected internal int DFA27_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA27_12 = input.LA(1);

                   	 
                   	int index27_12 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred74_DataForge()) ) { s = 15; }

                   	else if ( (true) ) { s = 2; }

                   	 
                   	input.Seek(index27_12);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae27 =
            new NoViableAltException(dfa.Description, 27, _s, input);
        dfa.Error(nvae27);
        throw nvae27;
    }
    const string DFA28_eotS =
        "\x32\uffff";
    const string DFA28_eofS =
        "\x32\uffff";
    const string DFA28_minS =
        "\x01\x0f\x06\x00\x03\x0f\x11\uffff\x06\x00\x03\uffff\x0e\x00";
    const string DFA28_maxS =
        "\x01\x5c\x06\x00\x03\x5c\x11\uffff\x06\x00\x03\uffff\x0e\x00";
    const string DFA28_acceptS =
        "\x0c\uffff\x01\x01\x01\x02\x24\uffff";
    const string DFA28_specialS =
        "\x01\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x14"+
        "\uffff\x01\x06\x01\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x03\uffff"+
        "\x01\x0c\x01\x0d\x01\x0e\x01\x0f\x01\x10\x01\x11\x01\x12\x01\x13"+
        "\x01\x14\x01\x15\x01\x16\x01\x17\x01\x18\x01\x19}>";
    static readonly string[] DFA28_transitionS = {
            "\x01\x01\x01\x02\x0e\uffff\x01\x07\x07\uffff\x01\x08\x01\uffff"+
            "\x01\x09\x2e\uffff\x01\x03\x01\uffff\x01\x05\x01\x04\x01\x06",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\x1c\x01\x1d\x0e\uffff\x01\x0d\x07\uffff\x01\x0d\x01\uffff"+
            "\x01\x0d\x2e\uffff\x01\x1e\x01\uffff\x01\x1b\x01\x1f\x01\x20",
            "\x01\x24\x01\x25\x0e\uffff\x01\x2a\x38\uffff\x01\x26\x01\uffff"+
            "\x01\x28\x01\x27\x01\x29",
            "\x01\x2b\x01\x2c\x0e\uffff\x01\x31\x38\uffff\x01\x2d\x01\uffff"+
            "\x01\x2f\x01\x2e\x01\x30",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "",
            "",
            "",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff"
    };

    static readonly short[] DFA28_eot = DFA.UnpackEncodedString(DFA28_eotS);
    static readonly short[] DFA28_eof = DFA.UnpackEncodedString(DFA28_eofS);
    static readonly char[] DFA28_min = DFA.UnpackEncodedStringToUnsignedChars(DFA28_minS);
    static readonly char[] DFA28_max = DFA.UnpackEncodedStringToUnsignedChars(DFA28_maxS);
    static readonly short[] DFA28_accept = DFA.UnpackEncodedString(DFA28_acceptS);
    static readonly short[] DFA28_special = DFA.UnpackEncodedString(DFA28_specialS);
    static readonly short[][] DFA28_transition = DFA.UnpackEncodedStringArray(DFA28_transitionS);

    protected class DFA28 : DFA
    {
        public DFA28(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 28;
            this.eot = DFA28_eot;
            this.eof = DFA28_eof;
            this.min = DFA28_min;
            this.max = DFA28_max;
            this.accept = DFA28_accept;
            this.special = DFA28_special;
            this.transition = DFA28_transition;

        }

        override public string Description
        {
            get { return "589:4: (ue= unary_expression | il= initializer_list )"; }
        }

    }


    protected internal int DFA28_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA28_1 = input.LA(1);

                   	 
                   	int index28_1 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred75_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index28_1);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA28_2 = input.LA(1);

                   	 
                   	int index28_2 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred75_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index28_2);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 2 : 
                   	int LA28_3 = input.LA(1);

                   	 
                   	int index28_3 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred75_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index28_3);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 3 : 
                   	int LA28_4 = input.LA(1);

                   	 
                   	int index28_4 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred75_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index28_4);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 4 : 
                   	int LA28_5 = input.LA(1);

                   	 
                   	int index28_5 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred75_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index28_5);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 5 : 
                   	int LA28_6 = input.LA(1);

                   	 
                   	int index28_6 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred75_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index28_6);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 6 : 
                   	int LA28_27 = input.LA(1);

                   	 
                   	int index28_27 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred75_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index28_27);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 7 : 
                   	int LA28_28 = input.LA(1);

                   	 
                   	int index28_28 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred75_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index28_28);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 8 : 
                   	int LA28_29 = input.LA(1);

                   	 
                   	int index28_29 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred75_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index28_29);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 9 : 
                   	int LA28_30 = input.LA(1);

                   	 
                   	int index28_30 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred75_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index28_30);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 10 : 
                   	int LA28_31 = input.LA(1);

                   	 
                   	int index28_31 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred75_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index28_31);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 11 : 
                   	int LA28_32 = input.LA(1);

                   	 
                   	int index28_32 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred75_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index28_32);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 12 : 
                   	int LA28_36 = input.LA(1);

                   	 
                   	int index28_36 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred75_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index28_36);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 13 : 
                   	int LA28_37 = input.LA(1);

                   	 
                   	int index28_37 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred75_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index28_37);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 14 : 
                   	int LA28_38 = input.LA(1);

                   	 
                   	int index28_38 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred75_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index28_38);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 15 : 
                   	int LA28_39 = input.LA(1);

                   	 
                   	int index28_39 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred75_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index28_39);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 16 : 
                   	int LA28_40 = input.LA(1);

                   	 
                   	int index28_40 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred75_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index28_40);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 17 : 
                   	int LA28_41 = input.LA(1);

                   	 
                   	int index28_41 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred75_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index28_41);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 18 : 
                   	int LA28_42 = input.LA(1);

                   	 
                   	int index28_42 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred75_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index28_42);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 19 : 
                   	int LA28_43 = input.LA(1);

                   	 
                   	int index28_43 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred75_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index28_43);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 20 : 
                   	int LA28_44 = input.LA(1);

                   	 
                   	int index28_44 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred75_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index28_44);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 21 : 
                   	int LA28_45 = input.LA(1);

                   	 
                   	int index28_45 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred75_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index28_45);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 22 : 
                   	int LA28_46 = input.LA(1);

                   	 
                   	int index28_46 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred75_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index28_46);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 23 : 
                   	int LA28_47 = input.LA(1);

                   	 
                   	int index28_47 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred75_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index28_47);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 24 : 
                   	int LA28_48 = input.LA(1);

                   	 
                   	int index28_48 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred75_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index28_48);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 25 : 
                   	int LA28_49 = input.LA(1);

                   	 
                   	int index28_49 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred75_DataForge()) ) { s = 12; }

                   	else if ( (true) ) { s = 13; }

                   	 
                   	input.Seek(index28_49);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae28 =
            new NoViableAltException(dfa.Description, 28, _s, input);
        dfa.Error(nvae28);
        throw nvae28;
    }
    const string DFA29_eotS =
        "\x10\uffff";
    const string DFA29_eofS =
        "\x01\x02\x0f\uffff";
    const string DFA29_minS =
        "\x01\x17\x01\x0f\x0a\uffff\x01\x00\x03\uffff";
    const string DFA29_maxS =
        "\x01\x21\x01\x5c\x0a\uffff\x01\x00\x03\uffff";
    const string DFA29_acceptS =
        "\x02\uffff\x01\x02\x0c\uffff\x01\x01";
    const string DFA29_specialS =
        "\x0c\uffff\x01\x00\x03\uffff}>";
    static readonly string[] DFA29_transitionS = {
            "\x01\x02\x05\uffff\x01\x01\x02\uffff\x02\x02",
            "\x02\x02\x0e\uffff\x01\x0c\x07\uffff\x01\x02\x01\uffff\x01"+
            "\x02\x2e\uffff\x01\x02\x01\uffff\x03\x02",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\uffff",
            "",
            "",
            ""
    };

    static readonly short[] DFA29_eot = DFA.UnpackEncodedString(DFA29_eotS);
    static readonly short[] DFA29_eof = DFA.UnpackEncodedString(DFA29_eofS);
    static readonly char[] DFA29_min = DFA.UnpackEncodedStringToUnsignedChars(DFA29_minS);
    static readonly char[] DFA29_max = DFA.UnpackEncodedStringToUnsignedChars(DFA29_maxS);
    static readonly short[] DFA29_accept = DFA.UnpackEncodedString(DFA29_acceptS);
    static readonly short[] DFA29_special = DFA.UnpackEncodedString(DFA29_specialS);
    static readonly short[][] DFA29_transition = DFA.UnpackEncodedStringArray(DFA29_transitionS);

    protected class DFA29 : DFA
    {
        public DFA29(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 29;
            this.eot = DFA29_eot;
            this.eof = DFA29_eof;
            this.min = DFA29_min;
            this.max = DFA29_max;
            this.accept = DFA29_accept;
            this.special = DFA29_special;
            this.transition = DFA29_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 596:59: ( COMMA mi2= map_initializer )*"; }
        }

    }


    protected internal int DFA29_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA29_12 = input.LA(1);

                   	 
                   	int index29_12 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred76_DataForge()) ) { s = 15; }

                   	else if ( (true) ) { s = 2; }

                   	 
                   	input.Seek(index29_12);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae29 =
            new NoViableAltException(dfa.Description, 29, _s, input);
        dfa.Error(nvae29);
        throw nvae29;
    }
    const string DFA30_eotS =
        "\x14\uffff";
    const string DFA30_eofS =
        "\x14\uffff";
    const string DFA30_minS =
        "\x01\x0f\x06\uffff\x01\x0f\x02\uffff\x06\x00\x04\uffff";
    const string DFA30_maxS =
        "\x01\x5c\x06\uffff\x01\x5c\x02\uffff\x06\x00\x04\uffff";
    const string DFA30_acceptS =
        "\x01\uffff\x01\x01\x0e\uffff\x01\x03\x02\uffff\x01\x02";
    const string DFA30_specialS =
        "\x0a\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x04"+
        "\uffff}>";
    static readonly string[] DFA30_transitionS = {
            "\x02\x01\x0e\uffff\x01\x07\x07\uffff\x01\x01\x01\uffff\x01"+
            "\x01\x2e\uffff\x01\x01\x01\uffff\x03\x01",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\x0b\x01\x0c\x0e\uffff\x01\x10\x07\uffff\x01\x10\x01\uffff"+
            "\x01\x10\x2e\uffff\x01\x0d\x01\uffff\x01\x0a\x01\x0e\x01\x0f",
            "",
            "",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA30_eot = DFA.UnpackEncodedString(DFA30_eotS);
    static readonly short[] DFA30_eof = DFA.UnpackEncodedString(DFA30_eofS);
    static readonly char[] DFA30_min = DFA.UnpackEncodedStringToUnsignedChars(DFA30_minS);
    static readonly char[] DFA30_max = DFA.UnpackEncodedStringToUnsignedChars(DFA30_maxS);
    static readonly short[] DFA30_accept = DFA.UnpackEncodedString(DFA30_acceptS);
    static readonly short[] DFA30_special = DFA.UnpackEncodedString(DFA30_specialS);
    static readonly short[][] DFA30_transition = DFA.UnpackEncodedStringArray(DFA30_transitionS);

    protected class DFA30 : DFA
    {
        public DFA30(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 30;
            this.eot = DFA30_eot;
            this.eof = DFA30_eof;
            this.min = DFA30_min;
            this.max = DFA30_max;
            this.accept = DFA30_accept;
            this.special = DFA30_special;
            this.transition = DFA30_transition;

        }

        override public string Description
        {
            get { return "599:1: simple_initializer returns [Initializer initter] : (ue= unary_expression | mi= map_initializer_list | li= list_initializer_list );"; }
        }

    }


    protected internal int DFA30_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA30_10 = input.LA(1);

                   	 
                   	int index30_10 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred77_DataForge()) ) { s = 1; }

                   	else if ( (synpred78_DataForge()) ) { s = 19; }

                   	else if ( (true) ) { s = 16; }

                   	 
                   	input.Seek(index30_10);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA30_11 = input.LA(1);

                   	 
                   	int index30_11 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred77_DataForge()) ) { s = 1; }

                   	else if ( (true) ) { s = 16; }

                   	 
                   	input.Seek(index30_11);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 2 : 
                   	int LA30_12 = input.LA(1);

                   	 
                   	int index30_12 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred77_DataForge()) ) { s = 1; }

                   	else if ( (true) ) { s = 16; }

                   	 
                   	input.Seek(index30_12);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 3 : 
                   	int LA30_13 = input.LA(1);

                   	 
                   	int index30_13 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred77_DataForge()) ) { s = 1; }

                   	else if ( (true) ) { s = 16; }

                   	 
                   	input.Seek(index30_13);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 4 : 
                   	int LA30_14 = input.LA(1);

                   	 
                   	int index30_14 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred77_DataForge()) ) { s = 1; }

                   	else if ( (true) ) { s = 16; }

                   	 
                   	input.Seek(index30_14);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 5 : 
                   	int LA30_15 = input.LA(1);

                   	 
                   	int index30_15 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred77_DataForge()) ) { s = 1; }

                   	else if ( (true) ) { s = 16; }

                   	 
                   	input.Seek(index30_15);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae30 =
            new NoViableAltException(dfa.Description, 30, _s, input);
        dfa.Error(nvae30);
        throw nvae30;
    }
    const string DFA31_eotS =
        "\x12\uffff";
    const string DFA31_eofS =
        "\x01\uffff\x01\x02\x10\uffff";
    const string DFA31_minS =
        "\x01\x0f\x01\x17\x10\uffff";
    const string DFA31_maxS =
        "\x01\x5c\x01\x28\x10\uffff";
    const string DFA31_acceptS =
        "\x02\uffff\x01\x02\x07\uffff\x01\x01\x07\uffff";
    const string DFA31_specialS =
        "\x12\uffff}>";
    static readonly string[] DFA31_transitionS = {
            "\x02\x02\x0e\uffff\x01\x02\x07\uffff\x01\x02\x01\uffff\x01"+
            "\x02\x2e\uffff\x01\x02\x01\uffff\x02\x02\x01\x01",
            "\x01\x02\x04\uffff\x03\x02\x01\uffff\x02\x02\x06\uffff\x01"+
            "\x0a",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA31_eot = DFA.UnpackEncodedString(DFA31_eotS);
    static readonly short[] DFA31_eof = DFA.UnpackEncodedString(DFA31_eofS);
    static readonly char[] DFA31_min = DFA.UnpackEncodedStringToUnsignedChars(DFA31_minS);
    static readonly char[] DFA31_max = DFA.UnpackEncodedStringToUnsignedChars(DFA31_maxS);
    static readonly short[] DFA31_accept = DFA.UnpackEncodedString(DFA31_acceptS);
    static readonly short[] DFA31_special = DFA.UnpackEncodedString(DFA31_specialS);
    static readonly short[][] DFA31_transition = DFA.UnpackEncodedStringArray(DFA31_transitionS);

    protected class DFA31 : DFA
    {
        public DFA31(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 31;
            this.eot = DFA31_eot;
            this.eof = DFA31_eof;
            this.min = DFA31_min;
            this.max = DFA31_max;
            this.accept = DFA31_accept;
            this.special = DFA31_special;
            this.transition = DFA31_transition;

        }

        override public string Description
        {
            get { return "614:1: initializer returns [Initializer initter] : (ni= named_initializer | si= simple_initializer );"; }
        }

    }

    const string DFA33_eotS =
        "\x14\uffff";
    const string DFA33_eofS =
        "\x14\uffff";
    const string DFA33_minS =
        "\x02\x0f\x08\uffff\x09\x00\x01\uffff";
    const string DFA33_maxS =
        "\x02\x5c\x08\uffff\x09\x00\x01\uffff";
    const string DFA33_acceptS =
        "\x02\uffff\x01\x02\x10\uffff\x01\x01";
    const string DFA33_specialS =
        "\x0a\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01"+
        "\x06\x01\x07\x01\x08\x01\uffff}>";
    static readonly string[] DFA33_transitionS = {
            "\x02\x02\x0e\uffff\x01\x01\x07\uffff\x01\x02\x01\uffff\x01"+
            "\x02\x2e\uffff\x01\x02\x01\uffff\x03\x02",
            "\x01\x0b\x01\x0c\x0e\uffff\x01\x10\x07\uffff\x01\x11\x01\uffff"+
            "\x01\x12\x2e\uffff\x01\x0d\x01\uffff\x01\x0a\x01\x0e\x01\x0f",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            ""
    };

    static readonly short[] DFA33_eot = DFA.UnpackEncodedString(DFA33_eotS);
    static readonly short[] DFA33_eof = DFA.UnpackEncodedString(DFA33_eofS);
    static readonly char[] DFA33_min = DFA.UnpackEncodedStringToUnsignedChars(DFA33_minS);
    static readonly char[] DFA33_max = DFA.UnpackEncodedStringToUnsignedChars(DFA33_maxS);
    static readonly short[] DFA33_accept = DFA.UnpackEncodedString(DFA33_acceptS);
    static readonly short[] DFA33_special = DFA.UnpackEncodedString(DFA33_specialS);
    static readonly short[][] DFA33_transition = DFA.UnpackEncodedStringArray(DFA33_transitionS);

    protected class DFA33 : DFA
    {
        public DFA33(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 33;
            this.eot = DFA33_eot;
            this.eof = DFA33_eof;
            this.min = DFA33_min;
            this.max = DFA33_max;
            this.accept = DFA33_accept;
            this.special = DFA33_special;
            this.transition = DFA33_transition;

        }

        override public string Description
        {
            get { return "637:1: initializer_root returns [Initializer initter] : ( LEFT_BRACE ini1= initializer RIGHT_BRACE | ini2= initializer );"; }
        }

    }


    protected internal int DFA33_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA33_10 = input.LA(1);

                   	 
                   	int index33_10 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred81_DataForge()) ) { s = 19; }

                   	else if ( (true) ) { s = 2; }

                   	 
                   	input.Seek(index33_10);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA33_11 = input.LA(1);

                   	 
                   	int index33_11 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred81_DataForge()) ) { s = 19; }

                   	else if ( (true) ) { s = 2; }

                   	 
                   	input.Seek(index33_11);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 2 : 
                   	int LA33_12 = input.LA(1);

                   	 
                   	int index33_12 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred81_DataForge()) ) { s = 19; }

                   	else if ( (true) ) { s = 2; }

                   	 
                   	input.Seek(index33_12);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 3 : 
                   	int LA33_13 = input.LA(1);

                   	 
                   	int index33_13 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred81_DataForge()) ) { s = 19; }

                   	else if ( (true) ) { s = 2; }

                   	 
                   	input.Seek(index33_13);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 4 : 
                   	int LA33_14 = input.LA(1);

                   	 
                   	int index33_14 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred81_DataForge()) ) { s = 19; }

                   	else if ( (true) ) { s = 2; }

                   	 
                   	input.Seek(index33_14);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 5 : 
                   	int LA33_15 = input.LA(1);

                   	 
                   	int index33_15 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred81_DataForge()) ) { s = 19; }

                   	else if ( (true) ) { s = 2; }

                   	 
                   	input.Seek(index33_15);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 6 : 
                   	int LA33_16 = input.LA(1);

                   	 
                   	int index33_16 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred81_DataForge()) ) { s = 19; }

                   	else if ( (true) ) { s = 2; }

                   	 
                   	input.Seek(index33_16);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 7 : 
                   	int LA33_17 = input.LA(1);

                   	 
                   	int index33_17 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred81_DataForge()) ) { s = 19; }

                   	else if ( (true) ) { s = 2; }

                   	 
                   	input.Seek(index33_17);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 8 : 
                   	int LA33_18 = input.LA(1);

                   	 
                   	int index33_18 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred81_DataForge()) ) { s = 19; }

                   	else if ( (true) ) { s = 2; }

                   	 
                   	input.Seek(index33_18);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae33 =
            new NoViableAltException(dfa.Description, 33, _s, input);
        dfa.Error(nvae33);
        throw nvae33;
    }
    const string DFA36_eotS =
        "\x2a\uffff";
    const string DFA36_eofS =
        "\x2a\uffff";
    const string DFA36_minS =
        "\x01\x0b\x29\uffff";
    const string DFA36_maxS =
        "\x01\x5c\x29\uffff";
    const string DFA36_acceptS =
        "\x01\uffff\x01\x02\x01\x01\x27\uffff";
    const string DFA36_specialS =
        "\x2a\uffff}>";
    static readonly string[] DFA36_transitionS = {
            "\x04\x02\x11\uffff\x01\x01\x0d\uffff\x23\x02\x0b\uffff\x01"+
            "\x02",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA36_eot = DFA.UnpackEncodedString(DFA36_eotS);
    static readonly short[] DFA36_eof = DFA.UnpackEncodedString(DFA36_eofS);
    static readonly char[] DFA36_min = DFA.UnpackEncodedStringToUnsignedChars(DFA36_minS);
    static readonly char[] DFA36_max = DFA.UnpackEncodedStringToUnsignedChars(DFA36_maxS);
    static readonly short[] DFA36_accept = DFA.UnpackEncodedString(DFA36_acceptS);
    static readonly short[] DFA36_special = DFA.UnpackEncodedString(DFA36_specialS);
    static readonly short[][] DFA36_transition = DFA.UnpackEncodedStringArray(DFA36_transitionS);

    protected class DFA36 : DFA
    {
        public DFA36(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 36;
            this.eot = DFA36_eot;
            this.eof = DFA36_eof;
            this.min = DFA36_min;
            this.max = DFA36_max;
            this.accept = DFA36_accept;
            this.special = DFA36_special;
            this.transition = DFA36_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 660:4: ( struct_declaration[$d] )*"; }
        }

    }

    const string DFA41_eotS =
        "\x2a\uffff";
    const string DFA41_eofS =
        "\x2a\uffff";
    const string DFA41_minS =
        "\x01\x0b\x29\uffff";
    const string DFA41_maxS =
        "\x01\x5c\x29\uffff";
    const string DFA41_acceptS =
        "\x01\uffff\x01\x02\x01\x01\x27\uffff";
    const string DFA41_specialS =
        "\x2a\uffff}>";
    static readonly string[] DFA41_transitionS = {
            "\x04\x02\x11\uffff\x01\x01\x0d\uffff\x23\x02\x0b\uffff\x01"+
            "\x02",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA41_eot = DFA.UnpackEncodedString(DFA41_eotS);
    static readonly short[] DFA41_eof = DFA.UnpackEncodedString(DFA41_eofS);
    static readonly char[] DFA41_min = DFA.UnpackEncodedStringToUnsignedChars(DFA41_minS);
    static readonly char[] DFA41_max = DFA.UnpackEncodedStringToUnsignedChars(DFA41_maxS);
    static readonly short[] DFA41_accept = DFA.UnpackEncodedString(DFA41_acceptS);
    static readonly short[] DFA41_special = DFA.UnpackEncodedString(DFA41_specialS);
    static readonly short[][] DFA41_transition = DFA.UnpackEncodedStringArray(DFA41_transitionS);

    protected class DFA41 : DFA
    {
        public DFA41(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 41;
            this.eot = DFA41_eot;
            this.eof = DFA41_eof;
            this.min = DFA41_min;
            this.max = DFA41_max;
            this.accept = DFA41_accept;
            this.special = DFA41_special;
            this.transition = DFA41_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 690:4: ( entity_declaration[$d] )*"; }
        }

    }

    const string DFA44_eotS =
        "\x0a\uffff";
    const string DFA44_eofS =
        "\x0a\uffff";
    const string DFA44_minS =
        "\x01\x0f\x09\uffff";
    const string DFA44_maxS =
        "\x01\x5c\x09\uffff";
    const string DFA44_acceptS =
        "\x01\uffff\x01\x01\x06\uffff\x01\x02\x01\uffff";
    const string DFA44_specialS =
        "\x0a\uffff}>";
    static readonly string[] DFA44_transitionS = {
            "\x02\x01\x0e\uffff\x01\x01\x07\uffff\x01\x08\x01\uffff\x01"+
            "\x08\x2e\uffff\x01\x01\x01\uffff\x03\x01",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA44_eot = DFA.UnpackEncodedString(DFA44_eotS);
    static readonly short[] DFA44_eof = DFA.UnpackEncodedString(DFA44_eofS);
    static readonly char[] DFA44_min = DFA.UnpackEncodedStringToUnsignedChars(DFA44_minS);
    static readonly char[] DFA44_max = DFA.UnpackEncodedStringToUnsignedChars(DFA44_maxS);
    static readonly short[] DFA44_accept = DFA.UnpackEncodedString(DFA44_acceptS);
    static readonly short[] DFA44_special = DFA.UnpackEncodedString(DFA44_specialS);
    static readonly short[][] DFA44_transition = DFA.UnpackEncodedStringArray(DFA44_transitionS);

    protected class DFA44 : DFA
    {
        public DFA44(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 44;
            this.eot = DFA44_eot;
            this.eof = DFA44_eof;
            this.min = DFA44_min;
            this.max = DFA44_max;
            this.accept = DFA44_accept;
            this.special = DFA44_special;
            this.transition = DFA44_transition;

        }

        override public string Description
        {
            get { return "702:1: unary_expression returns [SimpleInitializer initter, Expression expr] : (c= constant | op= unary_operator cnt= constant );"; }
        }

    }

 

    public static readonly BitSet FOLLOW_BOOL_in_types947 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FLOAT_in_types954 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DOUBLE_in_types961 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_REAL_in_types968 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_INT64_in_types975 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_INT32_in_types982 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_INT16_in_types989 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_INT8_in_types996 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_UINT64_in_types1003 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_UINT32_in_types1010 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_UINT16_in_types1017 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_UINT8_in_types1024 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_STRING_in_types1031 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_CSTRING_in_types1038 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_VEC2_in_types1045 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_VEC3_in_types1052 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_VEC4_in_types1059 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MAT2X2_in_types1066 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MAT3X3_in_types1073 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MAT4X4_in_types1080 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_QUAT_in_types1087 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_VEC2F_in_types1094 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_VEC3F_in_types1101 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_VEC4F_in_types1108 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MAT2X2F_in_types1115 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MAT3X3F_in_types1122 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MAT4X4F_in_types1129 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_QUATF_in_types1136 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_VEC2D_in_types1143 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_VEC3D_in_types1150 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_VEC4D_in_types1157 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MAT2X2D_in_types1164 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MAT3X3D_in_types1171 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MAT4X4D_in_types1178 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_QUATD_in_types1185 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_types1197 = new BitSet(new ulong[]{0x0000000010000000UL});
    public static readonly BitSet FOLLOW_DOT_in_types1199 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_types1207 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_STRING_LITERAL_in_string_list1230 = new BitSet(new ulong[]{0x0000000020000002UL});
    public static readonly BitSet FOLLOW_COMMA_in_string_list1238 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004000000UL});
    public static readonly BitSet FOLLOW_STRING_LITERAL_in_string_list1242 = new BitSet(new ulong[]{0x0000000020000002UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_package_identifier1268 = new BitSet(new ulong[]{0x0000000010000002UL});
    public static readonly BitSet FOLLOW_DOT_in_package_identifier1275 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_package_identifier1279 = new BitSet(new ulong[]{0x0000000010000002UL});
    public static readonly BitSet FOLLOW_IMPORTS_in_imports1295 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_LEFT_BRACE_in_imports1297 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004000000UL});
    public static readonly BitSet FOLLOW_string_list_in_imports1301 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_RIGHT_BRACE_in_imports1303 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LIB_HEADER_in_lib_header_option1321 = new BitSet(new ulong[]{0x0000010000000000UL});
    public static readonly BitSet FOLLOW_EQUAL_in_lib_header_option1323 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004000000UL});
    public static readonly BitSet FOLLOW_STRING_LITERAL_in_lib_header_option1327 = new BitSet(new ulong[]{0x0000000000800000UL});
    public static readonly BitSet FOLLOW_SEMICOLON_in_lib_header_option1329 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LIB_MACROS_in_lib_macros_option1345 = new BitSet(new ulong[]{0x0000010000000000UL});
    public static readonly BitSet FOLLOW_EQUAL_in_lib_macros_option1347 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004000000UL});
    public static readonly BitSet FOLLOW_STRING_LITERAL_in_lib_macros_option1351 = new BitSet(new ulong[]{0x0000000000800000UL});
    public static readonly BitSet FOLLOW_SEMICOLON_in_lib_macros_option1353 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_lib_header_option_in_lib_option1369 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000080000UL});
    public static readonly BitSet FOLLOW_lib_macros_option_in_lib_option1371 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_CPP_in_cpp1385 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_LEFT_BRACE_in_cpp1387 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
    public static readonly BitSet FOLLOW_lib_option_in_cpp1389 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_RIGHT_BRACE_in_cpp1391 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_PACKAGE_in_package_rule1402 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_package_identifier_in_package_rule1406 = new BitSet(new ulong[]{0x0000000000800000UL});
    public static readonly BitSet FOLLOW_SEMICOLON_in_package_rule1408 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ENUM_in_enum_specifier1427 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_enum_specifier1431 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_LEFT_BRACE_in_enum_specifier1435 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_enum_declaration_list_in_enum_specifier1440 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_RIGHT_BRACE_in_enum_specifier1450 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_enum_declaration_in_enum_declaration_list1469 = new BitSet(new ulong[]{0x0000000020000002UL});
    public static readonly BitSet FOLLOW_COMMA_in_enum_declaration_list1480 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_enum_declaration_in_enum_declaration_list1484 = new BitSet(new ulong[]{0x0000000020000002UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_enum_declaration1513 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_enum_declaration1527 = new BitSet(new ulong[]{0x0000010000000000UL});
    public static readonly BitSet FOLLOW_EQUAL_in_enum_declaration1529 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000001000000UL});
    public static readonly BitSet FOLLOW_INTCONSTANT_in_enum_declaration1533 = new BitSet(new ulong[]{0x0000001800000002UL});
    public static readonly BitSet FOLLOW_LEFT_OP_in_enum_declaration1539 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000001000000UL});
    public static readonly BitSet FOLLOW_RIGHT_OP_in_enum_declaration1545 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000001000000UL});
    public static readonly BitSet FOLLOW_INTCONSTANT_in_enum_declaration1550 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_enum_field1578 = new BitSet(new ulong[]{0x0000000010000000UL});
    public static readonly BitSet FOLLOW_DOT_in_enum_field1580 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_enum_field1588 = new BitSet(new ulong[]{0x0000000040000000UL});
    public static readonly BitSet FOLLOW_COLON_in_enum_field1590 = new BitSet(new ulong[]{0x0000000040000000UL});
    public static readonly BitSet FOLLOW_COLON_in_enum_field1592 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_enum_field1596 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_types_in_simple_declaration1616 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_simple_declaration1620 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_list_type_in_list_declaration1640 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_list_declaration1644 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LIST_in_list_type1663 = new BitSet(new ulong[]{0x0000000001000000UL});
    public static readonly BitSet FOLLOW_LEFT_ANGLE_in_list_type1665 = new BitSet(new ulong[]{0xFFFFC00000007800UL,0x000000001001FFFFUL});
    public static readonly BitSet FOLLOW_subcontainer_types_in_list_type1670 = new BitSet(new ulong[]{0x0000000002000000UL});
    public static readonly BitSet FOLLOW_types_in_list_type1676 = new BitSet(new ulong[]{0x0000000002000000UL});
    public static readonly BitSet FOLLOW_RIGHT_ANGLE_in_list_type1679 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MAP_in_map_type1698 = new BitSet(new ulong[]{0x0000000001000000UL});
    public static readonly BitSet FOLLOW_LEFT_ANGLE_in_map_type1700 = new BitSet(new ulong[]{0xFFFFC00000007800UL,0x000000001001FFFFUL});
    public static readonly BitSet FOLLOW_types_in_map_type1704 = new BitSet(new ulong[]{0x0000000020000000UL});
    public static readonly BitSet FOLLOW_COMMA_in_map_type1706 = new BitSet(new ulong[]{0xFFFFC00000007800UL,0x000000001001FFFFUL});
    public static readonly BitSet FOLLOW_subcontainer_types_in_map_type1711 = new BitSet(new ulong[]{0x0000000002000000UL});
    public static readonly BitSet FOLLOW_types_in_map_type1717 = new BitSet(new ulong[]{0x0000000002000000UL});
    public static readonly BitSet FOLLOW_RIGHT_ANGLE_in_map_type1720 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_REF_in_reference_type1739 = new BitSet(new ulong[]{0x0000000001000000UL});
    public static readonly BitSet FOLLOW_LEFT_ANGLE_in_reference_type1741 = new BitSet(new ulong[]{0xFFFFC00000007800UL,0x000000001001FFFFUL});
    public static readonly BitSet FOLLOW_types_in_reference_type1745 = new BitSet(new ulong[]{0x0000000002000000UL});
    public static readonly BitSet FOLLOW_RIGHT_ANGLE_in_reference_type1747 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_reference_type_in_reference_declaration1768 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_reference_declaration1772 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_WEAKREF_in_weak_reference_type1791 = new BitSet(new ulong[]{0x0000000001000000UL});
    public static readonly BitSet FOLLOW_LEFT_ANGLE_in_weak_reference_type1793 = new BitSet(new ulong[]{0xFFFFC00000007800UL,0x000000001001FFFFUL});
    public static readonly BitSet FOLLOW_types_in_weak_reference_type1797 = new BitSet(new ulong[]{0x0000000002000000UL});
    public static readonly BitSet FOLLOW_RIGHT_ANGLE_in_weak_reference_type1799 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_weak_reference_type_in_weak_reference_declaration1820 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_weak_reference_declaration1824 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_list_type_in_subcontainer_types1845 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_map_type_in_subcontainer_types1855 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_reference_type_in_subcontainer_types1865 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_weak_reference_type_in_subcontainer_types1875 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_map_type_in_map_declaration1893 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_map_declaration1897 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_simple_declaration_in_declaration1918 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_reference_declaration_in_declaration1928 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_weak_reference_declaration_in_declaration1937 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_list_declaration_in_declaration1946 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_map_declaration_in_declaration1956 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_REPLICATED_in_replicated_option1979 = new BitSet(new ulong[]{0x0000010000000000UL});
    public static readonly BitSet FOLLOW_EQUAL_in_replicated_option1981 = new BitSet(new ulong[]{0x0000000000018000UL});
    public static readonly BitSet FOLLOW_TRUE_in_replicated_option1984 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FALSE_in_replicated_option1988 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_PROFILE_in_profile_option2014 = new BitSet(new ulong[]{0x0000010000000000UL});
    public static readonly BitSet FOLLOW_EQUAL_in_profile_option2016 = new BitSet(new ulong[]{0x0000028080018000UL,0x000000001D000000UL});
    public static readonly BitSet FOLLOW_expression_in_profile_option2020 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_RUNTIME_KIND_in_runtime_kind_field_option2044 = new BitSet(new ulong[]{0x0000010000000000UL});
    public static readonly BitSet FOLLOW_EQUAL_in_runtime_kind_field_option2046 = new BitSet(new ulong[]{0x0000000000380000UL});
    public static readonly BitSet FOLLOW_RTK_SIMPLE_in_runtime_kind_field_option2051 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_RTK_SIMPLE_THREAD_SAFE_in_runtime_kind_field_option2057 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_RTK_DUAL_BUFFER_in_runtime_kind_field_option2063 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_profile_option_in_compound_type_options2086 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_runtime_kind_field_option_in_compound_type_options2095 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_no_serialize_option_in_compound_type_options2104 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_compound_type_options_in_compound_type_options_list2127 = new BitSet(new ulong[]{0x0000000020000002UL});
    public static readonly BitSet FOLLOW_COMMA_in_compound_type_options_list2132 = new BitSet(new ulong[]{0x0000000000440200UL});
    public static readonly BitSet FOLLOW_compound_type_options_in_compound_type_options_list2136 = new BitSet(new ulong[]{0x0000000020000002UL});
    public static readonly BitSet FOLLOW_NOSERIALIZE_in_no_serialize_option2163 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_replicated_option_in_struct_options2184 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_profile_option_in_struct_options2193 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_no_serialize_option_in_struct_options2202 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_struct_options_in_struct_options_list2226 = new BitSet(new ulong[]{0x0000000020000002UL});
    public static readonly BitSet FOLLOW_COMMA_in_struct_options_list2231 = new BitSet(new ulong[]{0x0000000000460200UL});
    public static readonly BitSet FOLLOW_struct_options_in_struct_options_list2235 = new BitSet(new ulong[]{0x0000000020000002UL});
    public static readonly BitSet FOLLOW_profile_option_in_entity_options2257 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_no_serialize_option_in_entity_options2267 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_entity_options_in_entity_options_list2292 = new BitSet(new ulong[]{0x0000000020000002UL});
    public static readonly BitSet FOLLOW_COMMA_in_entity_options_list2297 = new BitSet(new ulong[]{0x0000000000440200UL});
    public static readonly BitSet FOLLOW_entity_options_in_entity_options_list2301 = new BitSet(new ulong[]{0x0000000020000002UL});
    public static readonly BitSet FOLLOW_CONST_in_constant_declaration2317 = new BitSet(new ulong[]{0xFFFFC00000007800UL,0x000000001001FFFFUL});
    public static readonly BitSet FOLLOW_types_in_constant_declaration2321 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_constant_declaration2325 = new BitSet(new ulong[]{0x0000010000000000UL});
    public static readonly BitSet FOLLOW_EQUAL_in_constant_declaration2327 = new BitSet(new ulong[]{0x0000028080018000UL,0x000000001D000000UL});
    public static readonly BitSet FOLLOW_unary_expression_in_constant_declaration2331 = new BitSet(new ulong[]{0x0000000000800000UL});
    public static readonly BitSet FOLLOW_SEMICOLON_in_constant_declaration2333 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_named_constant2359 = new BitSet(new ulong[]{0x0000000010000000UL});
    public static readonly BitSet FOLLOW_DOT_in_named_constant2361 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_named_constant2369 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_TRUE_in_simple_constant2391 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FALSE_in_simple_constant2402 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_INTCONSTANT_in_simple_constant2412 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FLOATCONSTANT_in_simple_constant2422 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_STRING_LITERAL_in_simple_constant2432 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_enum_field_in_simple_constant2441 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_named_constant_in_simple_constant2451 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_simple_constant_in_constant_list2473 = new BitSet(new ulong[]{0x0000000020000002UL});
    public static readonly BitSet FOLLOW_COMMA_in_constant_list2480 = new BitSet(new ulong[]{0x0000000000018000UL,0x000000001D000000UL});
    public static readonly BitSet FOLLOW_simple_constant_in_constant_list2484 = new BitSet(new ulong[]{0x0000000020000002UL});
    public static readonly BitSet FOLLOW_simple_constant_in_constant2510 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LEFT_BRACE_in_constant2517 = new BitSet(new ulong[]{0x0000000000018000UL,0x000000001D000000UL});
    public static readonly BitSet FOLLOW_constant_list_in_constant2521 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_RIGHT_BRACE_in_constant2523 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LEFT_BRACE_in_list_initializer2539 = new BitSet(new ulong[]{0x0000028080018000UL,0x000000001D000000UL});
    public static readonly BitSet FOLLOW_unary_expression_in_list_initializer2547 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_initializer_list_in_list_initializer2554 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_RIGHT_BRACE_in_list_initializer2561 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_list_initializer_in_list_initializer_list2582 = new BitSet(new ulong[]{0x0000000020000002UL});
    public static readonly BitSet FOLLOW_COMMA_in_list_initializer_list2587 = new BitSet(new ulong[]{0x0000028080018000UL,0x000000001D000000UL});
    public static readonly BitSet FOLLOW_list_initializer_in_list_initializer_list2591 = new BitSet(new ulong[]{0x0000000020000002UL});
    public static readonly BitSet FOLLOW_LEFT_BRACE_in_map_initializer2614 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004000000UL});
    public static readonly BitSet FOLLOW_STRING_LITERAL_in_map_initializer2618 = new BitSet(new ulong[]{0x0000000040000000UL});
    public static readonly BitSet FOLLOW_COLON_in_map_initializer2622 = new BitSet(new ulong[]{0x0000028080018000UL,0x000000001D000000UL});
    public static readonly BitSet FOLLOW_unary_expression_in_map_initializer2630 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_initializer_list_in_map_initializer2639 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_RIGHT_BRACE_in_map_initializer2646 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_map_initializer_in_map_initializer_list2670 = new BitSet(new ulong[]{0x0000000020000002UL});
    public static readonly BitSet FOLLOW_COMMA_in_map_initializer_list2675 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_map_initializer_in_map_initializer_list2679 = new BitSet(new ulong[]{0x0000000020000002UL});
    public static readonly BitSet FOLLOW_unary_expression_in_simple_initializer2701 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_map_initializer_list_in_simple_initializer2711 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_list_initializer_list_in_simple_initializer2721 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_named_initializer2744 = new BitSet(new ulong[]{0x0000010000000000UL});
    public static readonly BitSet FOLLOW_EQUAL_in_named_initializer2746 = new BitSet(new ulong[]{0x0000028080018000UL,0x000000001D000000UL});
    public static readonly BitSet FOLLOW_simple_initializer_in_named_initializer2750 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_named_initializer_in_initializer2770 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_simple_initializer_in_initializer2779 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_initializer_in_initializer_list2801 = new BitSet(new ulong[]{0x0000000020000002UL});
    public static readonly BitSet FOLLOW_COMMA_in_initializer_list2812 = new BitSet(new ulong[]{0x0000028080018000UL,0x000000001D000000UL});
    public static readonly BitSet FOLLOW_initializer_in_initializer_list2816 = new BitSet(new ulong[]{0x0000000020000002UL});
    public static readonly BitSet FOLLOW_LEFT_BRACE_in_initializer_root2842 = new BitSet(new ulong[]{0x0000028080018000UL,0x000000001D000000UL});
    public static readonly BitSet FOLLOW_initializer_in_initializer_root2846 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_RIGHT_BRACE_in_initializer_root2848 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_initializer_in_initializer_root2858 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_STRUCT_in_struct_specifier2878 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_struct_specifier2882 = new BitSet(new ulong[]{0x00000002C0000000UL});
    public static readonly BitSet FOLLOW_COLON_in_struct_specifier2887 = new BitSet(new ulong[]{0xFFFFC00000007800UL,0x000000001001FFFFUL});
    public static readonly BitSet FOLLOW_types_in_struct_specifier2891 = new BitSet(new ulong[]{0x0000000280000000UL});
    public static readonly BitSet FOLLOW_LEFT_BRACKET_in_struct_specifier2896 = new BitSet(new ulong[]{0x0000000000440200UL});
    public static readonly BitSet FOLLOW_compound_type_options_list_in_struct_specifier2900 = new BitSet(new ulong[]{0x0000000400000000UL});
    public static readonly BitSet FOLLOW_RIGHT_BRACKET_in_struct_specifier2902 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_LEFT_BRACE_in_struct_specifier2906 = new BitSet(new ulong[]{0xFFFFC00100007800UL,0x000000001001FFFFUL});
    public static readonly BitSet FOLLOW_struct_declaration_list_in_struct_specifier2908 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_RIGHT_BRACE_in_struct_specifier2911 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_struct_declaration_in_struct_declaration_list2927 = new BitSet(new ulong[]{0xFFFFC00000007802UL,0x000000001001FFFFUL});
    public static readonly BitSet FOLLOW_declaration_in_struct_declaration2943 = new BitSet(new ulong[]{0x0000010200800000UL});
    public static readonly BitSet FOLLOW_EQUAL_in_struct_declaration2946 = new BitSet(new ulong[]{0x0000028080018000UL,0x000000001D000000UL});
    public static readonly BitSet FOLLOW_initializer_root_in_struct_declaration2950 = new BitSet(new ulong[]{0x0000000200800000UL});
    public static readonly BitSet FOLLOW_LEFT_BRACKET_in_struct_declaration2955 = new BitSet(new ulong[]{0x0000000000460200UL});
    public static readonly BitSet FOLLOW_struct_options_list_in_struct_declaration2959 = new BitSet(new ulong[]{0x0000000400000000UL});
    public static readonly BitSet FOLLOW_RIGHT_BRACKET_in_struct_declaration2961 = new BitSet(new ulong[]{0x0000000000800000UL});
    public static readonly BitSet FOLLOW_SEMICOLON_in_struct_declaration2965 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ENTITY_in_entity_specifier2984 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_entity_specifier2988 = new BitSet(new ulong[]{0x00000002C0000000UL});
    public static readonly BitSet FOLLOW_COLON_in_entity_specifier2993 = new BitSet(new ulong[]{0xFFFFC00000007800UL,0x000000001001FFFFUL});
    public static readonly BitSet FOLLOW_types_in_entity_specifier2997 = new BitSet(new ulong[]{0x0000000280000000UL});
    public static readonly BitSet FOLLOW_LEFT_BRACKET_in_entity_specifier3002 = new BitSet(new ulong[]{0x0000000000440200UL});
    public static readonly BitSet FOLLOW_compound_type_options_list_in_entity_specifier3006 = new BitSet(new ulong[]{0x0000000400000000UL});
    public static readonly BitSet FOLLOW_RIGHT_BRACKET_in_entity_specifier3008 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_LEFT_BRACE_in_entity_specifier3012 = new BitSet(new ulong[]{0xFFFFC00100007800UL,0x000000001001FFFFUL});
    public static readonly BitSet FOLLOW_entity_declaration_list_in_entity_specifier3014 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_RIGHT_BRACE_in_entity_specifier3017 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_entity_declaration_in_entity_declaration_list3032 = new BitSet(new ulong[]{0xFFFFC00000007802UL,0x000000001001FFFFUL});
    public static readonly BitSet FOLLOW_declaration_in_entity_declaration3048 = new BitSet(new ulong[]{0x0000010200800000UL});
    public static readonly BitSet FOLLOW_EQUAL_in_entity_declaration3051 = new BitSet(new ulong[]{0x0000028080018000UL,0x000000001D000000UL});
    public static readonly BitSet FOLLOW_initializer_root_in_entity_declaration3055 = new BitSet(new ulong[]{0x0000000200800000UL});
    public static readonly BitSet FOLLOW_LEFT_BRACKET_in_entity_declaration3060 = new BitSet(new ulong[]{0x0000000000440200UL});
    public static readonly BitSet FOLLOW_entity_options_list_in_entity_declaration3064 = new BitSet(new ulong[]{0x0000000400000000UL});
    public static readonly BitSet FOLLOW_RIGHT_BRACKET_in_entity_declaration3066 = new BitSet(new ulong[]{0x0000000000800000UL});
    public static readonly BitSet FOLLOW_SEMICOLON_in_entity_declaration3070 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_constant_in_unary_expression3099 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_unary_operator_in_unary_expression3112 = new BitSet(new ulong[]{0x0000000080018000UL,0x000000001D000000UL});
    public static readonly BitSet FOLLOW_constant_in_unary_expression3116 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_BANG_in_unary_operator3137 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DASH_in_unary_operator3145 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_unary_expression_in_logical_and_expression3165 = new BitSet(new ulong[]{0x0000002000000002UL});
    public static readonly BitSet FOLLOW_AND_OP_in_logical_and_expression3178 = new BitSet(new ulong[]{0x0000028080018000UL,0x000000001D000000UL});
    public static readonly BitSet FOLLOW_unary_expression_in_logical_and_expression3182 = new BitSet(new ulong[]{0x0000002000000002UL});
    public static readonly BitSet FOLLOW_logical_and_expression_in_logical_or_expression3208 = new BitSet(new ulong[]{0x0000004000000002UL});
    public static readonly BitSet FOLLOW_OR_OP_in_logical_or_expression3221 = new BitSet(new ulong[]{0x0000028080018000UL,0x000000001D000000UL});
    public static readonly BitSet FOLLOW_logical_and_expression_in_logical_or_expression3225 = new BitSet(new ulong[]{0x0000004000000002UL});
    public static readonly BitSet FOLLOW_logical_or_expression_in_expression3256 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_constant_declaration_in_data_structures3269 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_enum_specifier_in_data_structures3274 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_struct_specifier_in_data_structures3279 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_entity_specifier_in_data_structures3284 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_package_rule_in_translation_unit3295 = new BitSet(new ulong[]{0x00000000000004F2UL,0x0000000000020000UL});
    public static readonly BitSet FOLLOW_imports_in_translation_unit3298 = new BitSet(new ulong[]{0x0000000000000472UL,0x0000000000020000UL});
    public static readonly BitSet FOLLOW_cpp_in_translation_unit3301 = new BitSet(new ulong[]{0x0000000000000472UL});
    public static readonly BitSet FOLLOW_data_structures_in_translation_unit3304 = new BitSet(new ulong[]{0x0000000000000472UL});
    public static readonly BitSet FOLLOW_enum_field_in_synpred70_DataForge2441 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_unary_expression_in_synpred73_DataForge2547 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_COMMA_in_synpred74_DataForge2587 = new BitSet(new ulong[]{0x0000028080018000UL,0x000000001D000000UL});
    public static readonly BitSet FOLLOW_list_initializer_in_synpred74_DataForge2591 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_unary_expression_in_synpred75_DataForge2630 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_COMMA_in_synpred76_DataForge2675 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_map_initializer_in_synpred76_DataForge2679 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_unary_expression_in_synpred77_DataForge2701 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_map_initializer_list_in_synpred78_DataForge2711 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LEFT_BRACE_in_synpred81_DataForge2842 = new BitSet(new ulong[]{0x0000028080018000UL,0x000000001D000000UL});
    public static readonly BitSet FOLLOW_initializer_in_synpred81_DataForge2846 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_RIGHT_BRACE_in_synpred81_DataForge2848 = new BitSet(new ulong[]{0x0000000000000002UL});

}
