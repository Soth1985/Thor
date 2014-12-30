// $ANTLR 3.2 Sep 23, 2009 12:02:23 E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g 2013-07-03 07:26:53

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;


public partial class DataForgeLexer : Lexer {
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
    public const int QUATD = 80;
    public const int INT32 = 51;
    public const int REAL = 49;
    public const int AND_OP = 37;
    public const int QUATF = 73;
    public const int RTK_SIMPLE = 19;
    public const int INTCONSTANT = 88;
    public const int WS = 93;
    public const int FLOATCONSTANT = 91;
    public const int RTK_SIMPLE_THREAD_SAFE = 20;
    public const int LEFT_PAREN = 26;
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
    public const int LIB_MACROS = 83;
    public const int WEAKREF = 14;
    public const int STRING = 58;

    // delegates
    // delegators

    public DataForgeLexer() 
    {
		InitializeCyclicDFAs();
    }
    public DataForgeLexer(ICharStream input)
		: this(input, null) {
    }
    public DataForgeLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state) {
		InitializeCyclicDFAs(); 

    }
    
    override public string GrammarFileName
    {
    	get { return "E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g";} 
    }

    // $ANTLR start "CONST"
    public void mCONST() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = CONST;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:7:7: ( 'const' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:7:9: 'const'
            {
            	Match("const"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "CONST"

    // $ANTLR start "STRUCT"
    public void mSTRUCT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = STRUCT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:8:8: ( 'struct' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:8:10: 'struct'
            {
            	Match("struct"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "STRUCT"

    // $ANTLR start "ENUM"
    public void mENUM() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = ENUM;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:9:6: ( 'enum' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:9:8: 'enum'
            {
            	Match("enum"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "ENUM"

    // $ANTLR start "IMPORTS"
    public void mIMPORTS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = IMPORTS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:10:9: ( 'imports' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:10:11: 'imports'
            {
            	Match("imports"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "IMPORTS"

    // $ANTLR start "PACKAGE"
    public void mPACKAGE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = PACKAGE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:11:9: ( 'package' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:11:11: 'package'
            {
            	Match("package"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "PACKAGE"

    // $ANTLR start "PROFILE"
    public void mPROFILE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = PROFILE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:12:9: ( 'profile' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:12:11: 'profile'
            {
            	Match("profile"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "PROFILE"

    // $ANTLR start "ENTITY"
    public void mENTITY() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = ENTITY;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:13:8: ( 'entity' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:13:10: 'entity'
            {
            	Match("entity"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "ENTITY"

    // $ANTLR start "LIST"
    public void mLIST() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LIST;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:14:6: ( 'list' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:14:8: 'list'
            {
            	Match("list"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LIST"

    // $ANTLR start "MAP"
    public void mMAP() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MAP;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:15:5: ( 'map' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:15:7: 'map'
            {
            	Match("map"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "MAP"

    // $ANTLR start "REF"
    public void mREF() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = REF;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:16:5: ( 'ref' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:16:7: 'ref'
            {
            	Match("ref"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "REF"

    // $ANTLR start "WEAKREF"
    public void mWEAKREF() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = WEAKREF;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:17:9: ( 'weak_ref' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:17:11: 'weak_ref'
            {
            	Match("weak_ref"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "WEAKREF"

    // $ANTLR start "TRUE"
    public void mTRUE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = TRUE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:18:6: ( 'true' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:18:8: 'true'
            {
            	Match("true"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "TRUE"

    // $ANTLR start "FALSE"
    public void mFALSE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = FALSE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:19:7: ( 'false' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:19:9: 'false'
            {
            	Match("false"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "FALSE"

    // $ANTLR start "REPLICATED"
    public void mREPLICATED() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = REPLICATED;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:20:12: ( 'replicated' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:20:14: 'replicated'
            {
            	Match("replicated"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "REPLICATED"

    // $ANTLR start "RUNTIME_KIND"
    public void mRUNTIME_KIND() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = RUNTIME_KIND;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:21:14: ( 'runtime_kind' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:21:16: 'runtime_kind'
            {
            	Match("runtime_kind"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "RUNTIME_KIND"

    // $ANTLR start "RTK_SIMPLE"
    public void mRTK_SIMPLE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = RTK_SIMPLE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:22:12: ( 'rtk_simple' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:22:14: 'rtk_simple'
            {
            	Match("rtk_simple"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "RTK_SIMPLE"

    // $ANTLR start "RTK_SIMPLE_THREAD_SAFE"
    public void mRTK_SIMPLE_THREAD_SAFE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = RTK_SIMPLE_THREAD_SAFE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:23:24: ( 'rtk_simple_thread_safe' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:23:26: 'rtk_simple_thread_safe'
            {
            	Match("rtk_simple_thread_safe"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "RTK_SIMPLE_THREAD_SAFE"

    // $ANTLR start "RTK_DUAL_BUFFER"
    public void mRTK_DUAL_BUFFER() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = RTK_DUAL_BUFFER;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:24:17: ( 'rtk_dual_buffer' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:24:19: 'rtk_dual_buffer'
            {
            	Match("rtk_dual_buffer"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "RTK_DUAL_BUFFER"

    // $ANTLR start "NOSERIALIZE"
    public void mNOSERIALIZE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NOSERIALIZE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:25:13: ( 'no_serialize' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:25:15: 'no_serialize'
            {
            	Match("no_serialize"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "NOSERIALIZE"

    // $ANTLR start "SEMICOLON"
    public void mSEMICOLON() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = SEMICOLON;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:26:11: ( ';' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:26:13: ';'
            {
            	Match(';'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "SEMICOLON"

    // $ANTLR start "LEFT_ANGLE"
    public void mLEFT_ANGLE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LEFT_ANGLE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:27:12: ( '<' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:27:14: '<'
            {
            	Match('<'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LEFT_ANGLE"

    // $ANTLR start "RIGHT_ANGLE"
    public void mRIGHT_ANGLE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = RIGHT_ANGLE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:28:13: ( '>' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:28:15: '>'
            {
            	Match('>'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "RIGHT_ANGLE"

    // $ANTLR start "LEFT_PAREN"
    public void mLEFT_PAREN() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LEFT_PAREN;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:29:12: ( '(' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:29:14: '('
            {
            	Match('('); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LEFT_PAREN"

    // $ANTLR start "RIGHT_PAREN"
    public void mRIGHT_PAREN() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = RIGHT_PAREN;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:30:13: ( ')' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:30:15: ')'
            {
            	Match(')'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "RIGHT_PAREN"

    // $ANTLR start "DOT"
    public void mDOT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DOT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:31:5: ( '.' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:31:7: '.'
            {
            	Match('.'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "DOT"

    // $ANTLR start "COMMA"
    public void mCOMMA() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = COMMA;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:32:7: ( ',' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:32:9: ','
            {
            	Match(','); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "COMMA"

    // $ANTLR start "COLON"
    public void mCOLON() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = COLON;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:33:7: ( ':' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:33:9: ':'
            {
            	Match(':'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "COLON"

    // $ANTLR start "LEFT_BRACE"
    public void mLEFT_BRACE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LEFT_BRACE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:34:12: ( '{' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:34:14: '{'
            {
            	Match('{'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LEFT_BRACE"

    // $ANTLR start "RIGHT_BRACE"
    public void mRIGHT_BRACE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = RIGHT_BRACE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:35:13: ( '}' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:35:15: '}'
            {
            	Match('}'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "RIGHT_BRACE"

    // $ANTLR start "LEFT_BRACKET"
    public void mLEFT_BRACKET() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LEFT_BRACKET;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:36:14: ( '[' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:36:16: '['
            {
            	Match('['); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LEFT_BRACKET"

    // $ANTLR start "RIGHT_BRACKET"
    public void mRIGHT_BRACKET() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = RIGHT_BRACKET;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:37:15: ( ']' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:37:17: ']'
            {
            	Match(']'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "RIGHT_BRACKET"

    // $ANTLR start "LEFT_OP"
    public void mLEFT_OP() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LEFT_OP;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:38:9: ( '<<' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:38:11: '<<'
            {
            	Match("<<"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LEFT_OP"

    // $ANTLR start "RIGHT_OP"
    public void mRIGHT_OP() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = RIGHT_OP;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:39:10: ( '>>' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:39:12: '>>'
            {
            	Match(">>"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "RIGHT_OP"

    // $ANTLR start "AND_OP"
    public void mAND_OP() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = AND_OP;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:40:8: ( '&&' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:40:10: '&&'
            {
            	Match("&&"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "AND_OP"

    // $ANTLR start "OR_OP"
    public void mOR_OP() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = OR_OP;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:41:7: ( '||' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:41:9: '||'
            {
            	Match("||"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "OR_OP"

    // $ANTLR start "BANG"
    public void mBANG() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = BANG;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:42:6: ( '!' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:42:8: '!'
            {
            	Match('!'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "BANG"

    // $ANTLR start "EQUAL"
    public void mEQUAL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = EQUAL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:43:7: ( '=' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:43:9: '='
            {
            	Match('='); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "EQUAL"

    // $ANTLR start "DASH"
    public void mDASH() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DASH;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:44:6: ( '-' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:44:8: '-'
            {
            	Match('-'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "DASH"

    // $ANTLR start "PLUS"
    public void mPLUS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = PLUS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:45:6: ( '+' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:45:8: '+'
            {
            	Match('+'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "PLUS"

    // $ANTLR start "STAR"
    public void mSTAR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = STAR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:46:6: ( '*' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:46:8: '*'
            {
            	Match('*'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "STAR"

    // $ANTLR start "SLASH"
    public void mSLASH() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = SLASH;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:47:7: ( '/' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:47:9: '/'
            {
            	Match('/'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "SLASH"

    // $ANTLR start "PERCENT"
    public void mPERCENT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = PERCENT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:48:9: ( '%' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:48:11: '%'
            {
            	Match('%'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "PERCENT"

    // $ANTLR start "BOOL"
    public void mBOOL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = BOOL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:49:6: ( 'bool' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:49:8: 'bool'
            {
            	Match("bool"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "BOOL"

    // $ANTLR start "FLOAT"
    public void mFLOAT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = FLOAT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:50:7: ( 'float' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:50:9: 'float'
            {
            	Match("float"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "FLOAT"

    // $ANTLR start "DOUBLE"
    public void mDOUBLE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DOUBLE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:51:8: ( 'double' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:51:10: 'double'
            {
            	Match("double"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "DOUBLE"

    // $ANTLR start "REAL"
    public void mREAL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = REAL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:52:6: ( 'real' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:52:8: 'real'
            {
            	Match("real"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "REAL"

    // $ANTLR start "INT64"
    public void mINT64() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = INT64;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:53:7: ( 'int64' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:53:9: 'int64'
            {
            	Match("int64"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "INT64"

    // $ANTLR start "INT32"
    public void mINT32() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = INT32;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:54:7: ( 'int32' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:54:9: 'int32'
            {
            	Match("int32"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "INT32"

    // $ANTLR start "INT16"
    public void mINT16() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = INT16;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:55:7: ( 'int16' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:55:9: 'int16'
            {
            	Match("int16"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "INT16"

    // $ANTLR start "INT8"
    public void mINT8() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = INT8;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:56:6: ( 'int8' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:56:8: 'int8'
            {
            	Match("int8"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "INT8"

    // $ANTLR start "UINT64"
    public void mUINT64() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = UINT64;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:57:8: ( 'uint64' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:57:10: 'uint64'
            {
            	Match("uint64"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "UINT64"

    // $ANTLR start "UINT32"
    public void mUINT32() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = UINT32;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:58:8: ( 'uint32' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:58:10: 'uint32'
            {
            	Match("uint32"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "UINT32"

    // $ANTLR start "UINT16"
    public void mUINT16() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = UINT16;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:59:8: ( 'uint16' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:59:10: 'uint16'
            {
            	Match("uint16"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "UINT16"

    // $ANTLR start "UINT8"
    public void mUINT8() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = UINT8;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:60:7: ( 'uint8' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:60:9: 'uint8'
            {
            	Match("uint8"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "UINT8"

    // $ANTLR start "STRING"
    public void mSTRING() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = STRING;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:61:8: ( 'string' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:61:10: 'string'
            {
            	Match("string"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "STRING"

    // $ANTLR start "CSTRING"
    public void mCSTRING() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = CSTRING;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:62:9: ( 'cstring' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:62:11: 'cstring'
            {
            	Match("cstring"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "CSTRING"

    // $ANTLR start "VEC2"
    public void mVEC2() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = VEC2;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:63:6: ( 'vec2' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:63:8: 'vec2'
            {
            	Match("vec2"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "VEC2"

    // $ANTLR start "VEC3"
    public void mVEC3() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = VEC3;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:64:6: ( 'vec3' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:64:8: 'vec3'
            {
            	Match("vec3"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "VEC3"

    // $ANTLR start "VEC4"
    public void mVEC4() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = VEC4;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:65:6: ( 'vec4' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:65:8: 'vec4'
            {
            	Match("vec4"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "VEC4"

    // $ANTLR start "MAT2X2"
    public void mMAT2X2() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MAT2X2;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:66:8: ( 'mat2x2' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:66:10: 'mat2x2'
            {
            	Match("mat2x2"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "MAT2X2"

    // $ANTLR start "MAT3X3"
    public void mMAT3X3() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MAT3X3;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:67:8: ( 'mat3x3' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:67:10: 'mat3x3'
            {
            	Match("mat3x3"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "MAT3X3"

    // $ANTLR start "MAT4X4"
    public void mMAT4X4() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MAT4X4;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:68:8: ( 'mat4x4' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:68:10: 'mat4x4'
            {
            	Match("mat4x4"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "MAT4X4"

    // $ANTLR start "QUAT"
    public void mQUAT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = QUAT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:69:6: ( 'quat' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:69:8: 'quat'
            {
            	Match("quat"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "QUAT"

    // $ANTLR start "VEC2F"
    public void mVEC2F() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = VEC2F;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:70:7: ( 'vec2f' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:70:9: 'vec2f'
            {
            	Match("vec2f"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "VEC2F"

    // $ANTLR start "VEC3F"
    public void mVEC3F() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = VEC3F;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:71:7: ( 'vec3f' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:71:9: 'vec3f'
            {
            	Match("vec3f"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "VEC3F"

    // $ANTLR start "VEC4F"
    public void mVEC4F() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = VEC4F;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:72:7: ( 'vec4f' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:72:9: 'vec4f'
            {
            	Match("vec4f"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "VEC4F"

    // $ANTLR start "MAT2X2F"
    public void mMAT2X2F() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MAT2X2F;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:73:9: ( 'mat2x2f' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:73:11: 'mat2x2f'
            {
            	Match("mat2x2f"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "MAT2X2F"

    // $ANTLR start "MAT3X3F"
    public void mMAT3X3F() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MAT3X3F;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:74:9: ( 'mat3x3f' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:74:11: 'mat3x3f'
            {
            	Match("mat3x3f"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "MAT3X3F"

    // $ANTLR start "MAT4X4F"
    public void mMAT4X4F() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MAT4X4F;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:75:9: ( 'mat4x4f' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:75:11: 'mat4x4f'
            {
            	Match("mat4x4f"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "MAT4X4F"

    // $ANTLR start "QUATF"
    public void mQUATF() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = QUATF;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:76:7: ( 'quatf' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:76:9: 'quatf'
            {
            	Match("quatf"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "QUATF"

    // $ANTLR start "VEC2D"
    public void mVEC2D() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = VEC2D;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:77:7: ( 'vec2d' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:77:9: 'vec2d'
            {
            	Match("vec2d"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "VEC2D"

    // $ANTLR start "VEC3D"
    public void mVEC3D() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = VEC3D;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:78:7: ( 'vec3d' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:78:9: 'vec3d'
            {
            	Match("vec3d"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "VEC3D"

    // $ANTLR start "VEC4D"
    public void mVEC4D() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = VEC4D;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:79:7: ( 'vec4d' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:79:9: 'vec4d'
            {
            	Match("vec4d"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "VEC4D"

    // $ANTLR start "MAT2X2D"
    public void mMAT2X2D() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MAT2X2D;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:80:9: ( 'mat2x2d' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:80:11: 'mat2x2d'
            {
            	Match("mat2x2d"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "MAT2X2D"

    // $ANTLR start "MAT3X3D"
    public void mMAT3X3D() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MAT3X3D;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:81:9: ( 'mat3x3d' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:81:11: 'mat3x3d'
            {
            	Match("mat3x3d"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "MAT3X3D"

    // $ANTLR start "MAT4X4D"
    public void mMAT4X4D() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MAT4X4D;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:82:9: ( 'mat4x4d' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:82:11: 'mat4x4d'
            {
            	Match("mat4x4d"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "MAT4X4D"

    // $ANTLR start "QUATD"
    public void mQUATD() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = QUATD;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:83:7: ( 'quatd' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:83:9: 'quatd'
            {
            	Match("quatd"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "QUATD"

    // $ANTLR start "CPP"
    public void mCPP() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = CPP;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:84:5: ( 'cpp' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:84:7: 'cpp'
            {
            	Match("cpp"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "CPP"

    // $ANTLR start "LIB_HEADER"
    public void mLIB_HEADER() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LIB_HEADER;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:85:12: ( 'lib_header' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:85:14: 'lib_header'
            {
            	Match("lib_header"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LIB_HEADER"

    // $ANTLR start "LIB_MACROS"
    public void mLIB_MACROS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LIB_MACROS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:86:12: ( 'lib_macros' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:86:14: 'lib_macros'
            {
            	Match("lib_macros"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LIB_MACROS"

    // $ANTLR start "LETTER"
    public void mLETTER() // throws RecognitionException [2]
    {
    		try
    		{
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:142:2: ( 'A' .. 'Z' | 'a' .. 'z' | '_' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:
            {
            	if ( (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || input.LA(1) == '_' || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "LETTER"

    // $ANTLR start "DIGIT"
    public void mDIGIT() // throws RecognitionException [2]
    {
    		try
    		{
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:148:7: ( '0' .. '9' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:148:9: '0' .. '9'
            {
            	MatchRange('0','9'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "DIGIT"

    // $ANTLR start "HEX"
    public void mHEX() // throws RecognitionException [2]
    {
    		try
    		{
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:152:5: ( 'a' .. 'f' | 'A' .. 'F' | '0' .. '9' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:
            {
            	if ( (input.LA(1) >= '0' && input.LA(1) <= '9') || (input.LA(1) >= 'A' && input.LA(1) <= 'F') || (input.LA(1) >= 'a' && input.LA(1) <= 'f') ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "HEX"

    // $ANTLR start "EXPONENT"
    public void mEXPONENT() // throws RecognitionException [2]
    {
    		try
    		{
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:158:9: ( ( 'E' | 'e' ) ( '+' | '-' )+ ( DIGIT )+ )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:158:11: ( 'E' | 'e' ) ( '+' | '-' )+ ( DIGIT )+
            {
            	if ( input.LA(1) == 'E' || input.LA(1) == 'e' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}

            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:158:21: ( '+' | '-' )+
            	int cnt1 = 0;
            	do 
            	{
            	    int alt1 = 2;
            	    int LA1_0 = input.LA(1);

            	    if ( (LA1_0 == '+' || LA1_0 == '-') )
            	    {
            	        alt1 = 1;
            	    }


            	    switch (alt1) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:
            			    {
            			    	if ( input.LA(1) == '+' || input.LA(1) == '-' ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    if ( cnt1 >= 1 ) goto loop1;
            		            EarlyExitException eee1 =
            		                new EarlyExitException(1, input);
            		            throw eee1;
            	    }
            	    cnt1++;
            	} while (true);

            	loop1:
            		;	// Stops C# compiler whining that label 'loop1' has no statements

            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:158:34: ( DIGIT )+
            	int cnt2 = 0;
            	do 
            	{
            	    int alt2 = 2;
            	    int LA2_0 = input.LA(1);

            	    if ( ((LA2_0 >= '0' && LA2_0 <= '9')) )
            	    {
            	        alt2 = 1;
            	    }


            	    switch (alt2) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:158:34: DIGIT
            			    {
            			    	mDIGIT(); 

            			    }
            			    break;

            			default:
            			    if ( cnt2 >= 1 ) goto loop2;
            		            EarlyExitException eee2 =
            		                new EarlyExitException(2, input);
            		            throw eee2;
            	    }
            	    cnt2++;
            	} while (true);

            	loop2:
            		;	// Stops C# compiler whining that label 'loop2' has no statements


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "EXPONENT"

    // $ANTLR start "INTCONSTANT"
    public void mINTCONSTANT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = INTCONSTANT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:162:2: ( '0' ( 'x' | 'X' ) ( HEX )+ | ( '0' | '1' .. '9' ) ( DIGIT )* )
            int alt5 = 2;
            int LA5_0 = input.LA(1);

            if ( (LA5_0 == '0') )
            {
                int LA5_1 = input.LA(2);

                if ( (LA5_1 == 'X' || LA5_1 == 'x') )
                {
                    alt5 = 1;
                }
                else 
                {
                    alt5 = 2;}
            }
            else if ( ((LA5_0 >= '1' && LA5_0 <= '9')) )
            {
                alt5 = 2;
            }
            else 
            {
                NoViableAltException nvae_d5s0 =
                    new NoViableAltException("", 5, 0, input);

                throw nvae_d5s0;
            }
            switch (alt5) 
            {
                case 1 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:162:4: '0' ( 'x' | 'X' ) ( HEX )+
                    {
                    	Match('0'); 
                    	if ( input.LA(1) == 'X' || input.LA(1) == 'x' ) 
                    	{
                    	    input.Consume();

                    	}
                    	else 
                    	{
                    	    MismatchedSetException mse = new MismatchedSetException(null,input);
                    	    Recover(mse);
                    	    throw mse;}

                    	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:162:18: ( HEX )+
                    	int cnt3 = 0;
                    	do 
                    	{
                    	    int alt3 = 2;
                    	    int LA3_0 = input.LA(1);

                    	    if ( ((LA3_0 >= '0' && LA3_0 <= '9') || (LA3_0 >= 'A' && LA3_0 <= 'F') || (LA3_0 >= 'a' && LA3_0 <= 'f')) )
                    	    {
                    	        alt3 = 1;
                    	    }


                    	    switch (alt3) 
                    		{
                    			case 1 :
                    			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:162:18: HEX
                    			    {
                    			    	mHEX(); 

                    			    }
                    			    break;

                    			default:
                    			    if ( cnt3 >= 1 ) goto loop3;
                    		            EarlyExitException eee3 =
                    		                new EarlyExitException(3, input);
                    		            throw eee3;
                    	    }
                    	    cnt3++;
                    	} while (true);

                    	loop3:
                    		;	// Stops C# compiler whining that label 'loop3' has no statements


                    }
                    break;
                case 2 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:163:4: ( '0' | '1' .. '9' ) ( DIGIT )*
                    {
                    	if ( (input.LA(1) >= '0' && input.LA(1) <= '9') ) 
                    	{
                    	    input.Consume();

                    	}
                    	else 
                    	{
                    	    MismatchedSetException mse = new MismatchedSetException(null,input);
                    	    Recover(mse);
                    	    throw mse;}

                    	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:163:21: ( DIGIT )*
                    	do 
                    	{
                    	    int alt4 = 2;
                    	    int LA4_0 = input.LA(1);

                    	    if ( ((LA4_0 >= '0' && LA4_0 <= '9')) )
                    	    {
                    	        alt4 = 1;
                    	    }


                    	    switch (alt4) 
                    		{
                    			case 1 :
                    			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:163:21: DIGIT
                    			    {
                    			    	mDIGIT(); 

                    			    }
                    			    break;

                    			default:
                    			    goto loop4;
                    	    }
                    	} while (true);

                    	loop4:
                    		;	// Stops C# compiler whining that label 'loop4' has no statements


                    }
                    break;

            }
            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "INTCONSTANT"

    // $ANTLR start "EscapeSequence"
    public void mEscapeSequence() // throws RecognitionException [2]
    {
    		try
    		{
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:168:5: ( '\\\\' ( 'b' | 't' | 'n' | 'f' | 'r' | '\\\"' | '\\'' | '\\\\' ) )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:168:9: '\\\\' ( 'b' | 't' | 'n' | 'f' | 'r' | '\\\"' | '\\'' | '\\\\' )
            {
            	Match('\\'); 
            	if ( input.LA(1) == '\"' || input.LA(1) == '\'' || input.LA(1) == '\\' || input.LA(1) == 'b' || input.LA(1) == 'f' || input.LA(1) == 'n' || input.LA(1) == 'r' || input.LA(1) == 't' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "EscapeSequence"

    // $ANTLR start "STRING_LITERAL"
    public void mSTRING_LITERAL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = STRING_LITERAL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:172:5: ( '\"' ( EscapeSequence | ~ ( '\\\\' | '\"' ) )* '\"' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:172:8: '\"' ( EscapeSequence | ~ ( '\\\\' | '\"' ) )* '\"'
            {
            	Match('\"'); 
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:172:12: ( EscapeSequence | ~ ( '\\\\' | '\"' ) )*
            	do 
            	{
            	    int alt6 = 3;
            	    int LA6_0 = input.LA(1);

            	    if ( (LA6_0 == '\\') )
            	    {
            	        alt6 = 1;
            	    }
            	    else if ( ((LA6_0 >= '\u0000' && LA6_0 <= '!') || (LA6_0 >= '#' && LA6_0 <= '[') || (LA6_0 >= ']' && LA6_0 <= '\uFFFF')) )
            	    {
            	        alt6 = 2;
            	    }


            	    switch (alt6) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:172:14: EscapeSequence
            			    {
            			    	mEscapeSequence(); 

            			    }
            			    break;
            			case 2 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:172:31: ~ ( '\\\\' | '\"' )
            			    {
            			    	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '!') || (input.LA(1) >= '#' && input.LA(1) <= '[') || (input.LA(1) >= ']' && input.LA(1) <= '\uFFFF') ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    goto loop6;
            	    }
            	} while (true);

            	loop6:
            		;	// Stops C# compiler whining that label 'loop6' has no statements

            	Match('\"'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "STRING_LITERAL"

    // $ANTLR start "FLOATCONSTANT"
    public void mFLOATCONSTANT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = FLOATCONSTANT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:176:2: ( ( DIGIT )+ EXPONENT | ( DIGIT )+ '.' ( DIGIT )* ( EXPONENT )? | '.' ( DIGIT )+ ( EXPONENT )? )
            int alt13 = 3;
            alt13 = dfa13.Predict(input);
            switch (alt13) 
            {
                case 1 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:176:4: ( DIGIT )+ EXPONENT
                    {
                    	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:176:4: ( DIGIT )+
                    	int cnt7 = 0;
                    	do 
                    	{
                    	    int alt7 = 2;
                    	    int LA7_0 = input.LA(1);

                    	    if ( ((LA7_0 >= '0' && LA7_0 <= '9')) )
                    	    {
                    	        alt7 = 1;
                    	    }


                    	    switch (alt7) 
                    		{
                    			case 1 :
                    			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:176:4: DIGIT
                    			    {
                    			    	mDIGIT(); 

                    			    }
                    			    break;

                    			default:
                    			    if ( cnt7 >= 1 ) goto loop7;
                    		            EarlyExitException eee7 =
                    		                new EarlyExitException(7, input);
                    		            throw eee7;
                    	    }
                    	    cnt7++;
                    	} while (true);

                    	loop7:
                    		;	// Stops C# compiler whining that label 'loop7' has no statements

                    	mEXPONENT(); 

                    }
                    break;
                case 2 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:177:4: ( DIGIT )+ '.' ( DIGIT )* ( EXPONENT )?
                    {
                    	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:177:4: ( DIGIT )+
                    	int cnt8 = 0;
                    	do 
                    	{
                    	    int alt8 = 2;
                    	    int LA8_0 = input.LA(1);

                    	    if ( ((LA8_0 >= '0' && LA8_0 <= '9')) )
                    	    {
                    	        alt8 = 1;
                    	    }


                    	    switch (alt8) 
                    		{
                    			case 1 :
                    			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:177:4: DIGIT
                    			    {
                    			    	mDIGIT(); 

                    			    }
                    			    break;

                    			default:
                    			    if ( cnt8 >= 1 ) goto loop8;
                    		            EarlyExitException eee8 =
                    		                new EarlyExitException(8, input);
                    		            throw eee8;
                    	    }
                    	    cnt8++;
                    	} while (true);

                    	loop8:
                    		;	// Stops C# compiler whining that label 'loop8' has no statements

                    	Match('.'); 
                    	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:177:15: ( DIGIT )*
                    	do 
                    	{
                    	    int alt9 = 2;
                    	    int LA9_0 = input.LA(1);

                    	    if ( ((LA9_0 >= '0' && LA9_0 <= '9')) )
                    	    {
                    	        alt9 = 1;
                    	    }


                    	    switch (alt9) 
                    		{
                    			case 1 :
                    			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:177:15: DIGIT
                    			    {
                    			    	mDIGIT(); 

                    			    }
                    			    break;

                    			default:
                    			    goto loop9;
                    	    }
                    	} while (true);

                    	loop9:
                    		;	// Stops C# compiler whining that label 'loop9' has no statements

                    	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:177:22: ( EXPONENT )?
                    	int alt10 = 2;
                    	int LA10_0 = input.LA(1);

                    	if ( (LA10_0 == 'E' || LA10_0 == 'e') )
                    	{
                    	    alt10 = 1;
                    	}
                    	switch (alt10) 
                    	{
                    	    case 1 :
                    	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:177:22: EXPONENT
                    	        {
                    	        	mEXPONENT(); 

                    	        }
                    	        break;

                    	}


                    }
                    break;
                case 3 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:178:4: '.' ( DIGIT )+ ( EXPONENT )?
                    {
                    	Match('.'); 
                    	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:178:8: ( DIGIT )+
                    	int cnt11 = 0;
                    	do 
                    	{
                    	    int alt11 = 2;
                    	    int LA11_0 = input.LA(1);

                    	    if ( ((LA11_0 >= '0' && LA11_0 <= '9')) )
                    	    {
                    	        alt11 = 1;
                    	    }


                    	    switch (alt11) 
                    		{
                    			case 1 :
                    			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:178:8: DIGIT
                    			    {
                    			    	mDIGIT(); 

                    			    }
                    			    break;

                    			default:
                    			    if ( cnt11 >= 1 ) goto loop11;
                    		            EarlyExitException eee11 =
                    		                new EarlyExitException(11, input);
                    		            throw eee11;
                    	    }
                    	    cnt11++;
                    	} while (true);

                    	loop11:
                    		;	// Stops C# compiler whining that label 'loop11' has no statements

                    	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:178:15: ( EXPONENT )?
                    	int alt12 = 2;
                    	int LA12_0 = input.LA(1);

                    	if ( (LA12_0 == 'E' || LA12_0 == 'e') )
                    	{
                    	    alt12 = 1;
                    	}
                    	switch (alt12) 
                    	{
                    	    case 1 :
                    	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:178:15: EXPONENT
                    	        {
                    	        	mEXPONENT(); 

                    	        }
                    	        break;

                    	}


                    }
                    break;

            }
            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "FLOATCONSTANT"

    // $ANTLR start "IDENTIFIER"
    public void mIDENTIFIER() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = IDENTIFIER;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:182:2: ( LETTER ( LETTER | DIGIT )* )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:182:4: LETTER ( LETTER | DIGIT )*
            {
            	mLETTER(); 
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:182:11: ( LETTER | DIGIT )*
            	do 
            	{
            	    int alt14 = 2;
            	    int LA14_0 = input.LA(1);

            	    if ( ((LA14_0 >= '0' && LA14_0 <= '9') || (LA14_0 >= 'A' && LA14_0 <= 'Z') || LA14_0 == '_' || (LA14_0 >= 'a' && LA14_0 <= 'z')) )
            	    {
            	        alt14 = 1;
            	    }


            	    switch (alt14) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:
            			    {
            			    	if ( (input.LA(1) >= '0' && input.LA(1) <= '9') || (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || input.LA(1) == '_' || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    goto loop14;
            	    }
            	} while (true);

            	loop14:
            		;	// Stops C# compiler whining that label 'loop14' has no statements


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "IDENTIFIER"

    // $ANTLR start "WS"
    public void mWS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = WS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:186:5: ( ( ' ' | '\\r' | '\\t' | '\\n' )+ )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:186:8: ( ' ' | '\\r' | '\\t' | '\\n' )+
            {
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:186:8: ( ' ' | '\\r' | '\\t' | '\\n' )+
            	int cnt15 = 0;
            	do 
            	{
            	    int alt15 = 2;
            	    int LA15_0 = input.LA(1);

            	    if ( ((LA15_0 >= '\t' && LA15_0 <= '\n') || LA15_0 == '\r' || LA15_0 == ' ') )
            	    {
            	        alt15 = 1;
            	    }


            	    switch (alt15) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:
            			    {
            			    	if ( (input.LA(1) >= '\t' && input.LA(1) <= '\n') || input.LA(1) == '\r' || input.LA(1) == ' ' ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    if ( cnt15 >= 1 ) goto loop15;
            		            EarlyExitException eee15 =
            		                new EarlyExitException(15, input);
            		            throw eee15;
            	    }
            	    cnt15++;
            	} while (true);

            	loop15:
            		;	// Stops C# compiler whining that label 'loop15' has no statements

            	_channel=HIDDEN;

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "WS"

    // $ANTLR start "COMMENT"
    public void mCOMMENT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = COMMENT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:190:5: ( '/*' ( options {greedy=false; } : . )* '*/' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:190:9: '/*' ( options {greedy=false; } : . )* '*/'
            {
            	Match("/*"); 

            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:190:14: ( options {greedy=false; } : . )*
            	do 
            	{
            	    int alt16 = 2;
            	    int LA16_0 = input.LA(1);

            	    if ( (LA16_0 == '*') )
            	    {
            	        int LA16_1 = input.LA(2);

            	        if ( (LA16_1 == '/') )
            	        {
            	            alt16 = 2;
            	        }
            	        else if ( ((LA16_1 >= '\u0000' && LA16_1 <= '.') || (LA16_1 >= '0' && LA16_1 <= '\uFFFF')) )
            	        {
            	            alt16 = 1;
            	        }


            	    }
            	    else if ( ((LA16_0 >= '\u0000' && LA16_0 <= ')') || (LA16_0 >= '+' && LA16_0 <= '\uFFFF')) )
            	    {
            	        alt16 = 1;
            	    }


            	    switch (alt16) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:190:42: .
            			    {
            			    	MatchAny(); 

            			    }
            			    break;

            			default:
            			    goto loop16;
            	    }
            	} while (true);

            	loop16:
            		;	// Stops C# compiler whining that label 'loop16' has no statements

            	Match("*/"); 

            	_channel=HIDDEN;

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "COMMENT"

    // $ANTLR start "LINE_COMMENT"
    public void mLINE_COMMENT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LINE_COMMENT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:194:5: ( '//' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:194:7: '//' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n'
            {
            	Match("//"); 

            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:194:12: (~ ( '\\n' | '\\r' ) )*
            	do 
            	{
            	    int alt17 = 2;
            	    int LA17_0 = input.LA(1);

            	    if ( ((LA17_0 >= '\u0000' && LA17_0 <= '\t') || (LA17_0 >= '\u000B' && LA17_0 <= '\f') || (LA17_0 >= '\u000E' && LA17_0 <= '\uFFFF')) )
            	    {
            	        alt17 = 1;
            	    }


            	    switch (alt17) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:194:12: ~ ( '\\n' | '\\r' )
            			    {
            			    	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\t') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\f') || (input.LA(1) >= '\u000E' && input.LA(1) <= '\uFFFF') ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    goto loop17;
            	    }
            	} while (true);

            	loop17:
            		;	// Stops C# compiler whining that label 'loop17' has no statements

            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:194:26: ( '\\r' )?
            	int alt18 = 2;
            	int LA18_0 = input.LA(1);

            	if ( (LA18_0 == '\r') )
            	{
            	    alt18 = 1;
            	}
            	switch (alt18) 
            	{
            	    case 1 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:194:26: '\\r'
            	        {
            	        	Match('\r'); 

            	        }
            	        break;

            	}

            	Match('\n'); 
            	_channel=HIDDEN;

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LINE_COMMENT"

    override public void mTokens() // throws RecognitionException 
    {
        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:8: ( CONST | STRUCT | ENUM | IMPORTS | PACKAGE | PROFILE | ENTITY | LIST | MAP | REF | WEAKREF | TRUE | FALSE | REPLICATED | RUNTIME_KIND | RTK_SIMPLE | RTK_SIMPLE_THREAD_SAFE | RTK_DUAL_BUFFER | NOSERIALIZE | SEMICOLON | LEFT_ANGLE | RIGHT_ANGLE | LEFT_PAREN | RIGHT_PAREN | DOT | COMMA | COLON | LEFT_BRACE | RIGHT_BRACE | LEFT_BRACKET | RIGHT_BRACKET | LEFT_OP | RIGHT_OP | AND_OP | OR_OP | BANG | EQUAL | DASH | PLUS | STAR | SLASH | PERCENT | BOOL | FLOAT | DOUBLE | REAL | INT64 | INT32 | INT16 | INT8 | UINT64 | UINT32 | UINT16 | UINT8 | STRING | CSTRING | VEC2 | VEC3 | VEC4 | MAT2X2 | MAT3X3 | MAT4X4 | QUAT | VEC2F | VEC3F | VEC4F | MAT2X2F | MAT3X3F | MAT4X4F | QUATF | VEC2D | VEC3D | VEC4D | MAT2X2D | MAT3X3D | MAT4X4D | QUATD | CPP | LIB_HEADER | LIB_MACROS | INTCONSTANT | STRING_LITERAL | FLOATCONSTANT | IDENTIFIER | WS | COMMENT | LINE_COMMENT )
        int alt19 = 87;
        alt19 = dfa19.Predict(input);
        switch (alt19) 
        {
            case 1 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:10: CONST
                {
                	mCONST(); 

                }
                break;
            case 2 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:16: STRUCT
                {
                	mSTRUCT(); 

                }
                break;
            case 3 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:23: ENUM
                {
                	mENUM(); 

                }
                break;
            case 4 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:28: IMPORTS
                {
                	mIMPORTS(); 

                }
                break;
            case 5 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:36: PACKAGE
                {
                	mPACKAGE(); 

                }
                break;
            case 6 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:44: PROFILE
                {
                	mPROFILE(); 

                }
                break;
            case 7 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:52: ENTITY
                {
                	mENTITY(); 

                }
                break;
            case 8 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:59: LIST
                {
                	mLIST(); 

                }
                break;
            case 9 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:64: MAP
                {
                	mMAP(); 

                }
                break;
            case 10 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:68: REF
                {
                	mREF(); 

                }
                break;
            case 11 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:72: WEAKREF
                {
                	mWEAKREF(); 

                }
                break;
            case 12 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:80: TRUE
                {
                	mTRUE(); 

                }
                break;
            case 13 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:85: FALSE
                {
                	mFALSE(); 

                }
                break;
            case 14 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:91: REPLICATED
                {
                	mREPLICATED(); 

                }
                break;
            case 15 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:102: RUNTIME_KIND
                {
                	mRUNTIME_KIND(); 

                }
                break;
            case 16 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:115: RTK_SIMPLE
                {
                	mRTK_SIMPLE(); 

                }
                break;
            case 17 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:126: RTK_SIMPLE_THREAD_SAFE
                {
                	mRTK_SIMPLE_THREAD_SAFE(); 

                }
                break;
            case 18 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:149: RTK_DUAL_BUFFER
                {
                	mRTK_DUAL_BUFFER(); 

                }
                break;
            case 19 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:165: NOSERIALIZE
                {
                	mNOSERIALIZE(); 

                }
                break;
            case 20 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:177: SEMICOLON
                {
                	mSEMICOLON(); 

                }
                break;
            case 21 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:187: LEFT_ANGLE
                {
                	mLEFT_ANGLE(); 

                }
                break;
            case 22 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:198: RIGHT_ANGLE
                {
                	mRIGHT_ANGLE(); 

                }
                break;
            case 23 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:210: LEFT_PAREN
                {
                	mLEFT_PAREN(); 

                }
                break;
            case 24 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:221: RIGHT_PAREN
                {
                	mRIGHT_PAREN(); 

                }
                break;
            case 25 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:233: DOT
                {
                	mDOT(); 

                }
                break;
            case 26 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:237: COMMA
                {
                	mCOMMA(); 

                }
                break;
            case 27 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:243: COLON
                {
                	mCOLON(); 

                }
                break;
            case 28 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:249: LEFT_BRACE
                {
                	mLEFT_BRACE(); 

                }
                break;
            case 29 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:260: RIGHT_BRACE
                {
                	mRIGHT_BRACE(); 

                }
                break;
            case 30 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:272: LEFT_BRACKET
                {
                	mLEFT_BRACKET(); 

                }
                break;
            case 31 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:285: RIGHT_BRACKET
                {
                	mRIGHT_BRACKET(); 

                }
                break;
            case 32 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:299: LEFT_OP
                {
                	mLEFT_OP(); 

                }
                break;
            case 33 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:307: RIGHT_OP
                {
                	mRIGHT_OP(); 

                }
                break;
            case 34 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:316: AND_OP
                {
                	mAND_OP(); 

                }
                break;
            case 35 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:323: OR_OP
                {
                	mOR_OP(); 

                }
                break;
            case 36 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:329: BANG
                {
                	mBANG(); 

                }
                break;
            case 37 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:334: EQUAL
                {
                	mEQUAL(); 

                }
                break;
            case 38 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:340: DASH
                {
                	mDASH(); 

                }
                break;
            case 39 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:345: PLUS
                {
                	mPLUS(); 

                }
                break;
            case 40 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:350: STAR
                {
                	mSTAR(); 

                }
                break;
            case 41 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:355: SLASH
                {
                	mSLASH(); 

                }
                break;
            case 42 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:361: PERCENT
                {
                	mPERCENT(); 

                }
                break;
            case 43 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:369: BOOL
                {
                	mBOOL(); 

                }
                break;
            case 44 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:374: FLOAT
                {
                	mFLOAT(); 

                }
                break;
            case 45 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:380: DOUBLE
                {
                	mDOUBLE(); 

                }
                break;
            case 46 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:387: REAL
                {
                	mREAL(); 

                }
                break;
            case 47 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:392: INT64
                {
                	mINT64(); 

                }
                break;
            case 48 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:398: INT32
                {
                	mINT32(); 

                }
                break;
            case 49 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:404: INT16
                {
                	mINT16(); 

                }
                break;
            case 50 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:410: INT8
                {
                	mINT8(); 

                }
                break;
            case 51 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:415: UINT64
                {
                	mUINT64(); 

                }
                break;
            case 52 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:422: UINT32
                {
                	mUINT32(); 

                }
                break;
            case 53 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:429: UINT16
                {
                	mUINT16(); 

                }
                break;
            case 54 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:436: UINT8
                {
                	mUINT8(); 

                }
                break;
            case 55 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:442: STRING
                {
                	mSTRING(); 

                }
                break;
            case 56 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:449: CSTRING
                {
                	mCSTRING(); 

                }
                break;
            case 57 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:457: VEC2
                {
                	mVEC2(); 

                }
                break;
            case 58 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:462: VEC3
                {
                	mVEC3(); 

                }
                break;
            case 59 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:467: VEC4
                {
                	mVEC4(); 

                }
                break;
            case 60 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:472: MAT2X2
                {
                	mMAT2X2(); 

                }
                break;
            case 61 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:479: MAT3X3
                {
                	mMAT3X3(); 

                }
                break;
            case 62 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:486: MAT4X4
                {
                	mMAT4X4(); 

                }
                break;
            case 63 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:493: QUAT
                {
                	mQUAT(); 

                }
                break;
            case 64 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:498: VEC2F
                {
                	mVEC2F(); 

                }
                break;
            case 65 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:504: VEC3F
                {
                	mVEC3F(); 

                }
                break;
            case 66 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:510: VEC4F
                {
                	mVEC4F(); 

                }
                break;
            case 67 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:516: MAT2X2F
                {
                	mMAT2X2F(); 

                }
                break;
            case 68 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:524: MAT3X3F
                {
                	mMAT3X3F(); 

                }
                break;
            case 69 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:532: MAT4X4F
                {
                	mMAT4X4F(); 

                }
                break;
            case 70 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:540: QUATF
                {
                	mQUATF(); 

                }
                break;
            case 71 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:546: VEC2D
                {
                	mVEC2D(); 

                }
                break;
            case 72 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:552: VEC3D
                {
                	mVEC3D(); 

                }
                break;
            case 73 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:558: VEC4D
                {
                	mVEC4D(); 

                }
                break;
            case 74 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:564: MAT2X2D
                {
                	mMAT2X2D(); 

                }
                break;
            case 75 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:572: MAT3X3D
                {
                	mMAT3X3D(); 

                }
                break;
            case 76 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:580: MAT4X4D
                {
                	mMAT4X4D(); 

                }
                break;
            case 77 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:588: QUATD
                {
                	mQUATD(); 

                }
                break;
            case 78 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:594: CPP
                {
                	mCPP(); 

                }
                break;
            case 79 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:598: LIB_HEADER
                {
                	mLIB_HEADER(); 

                }
                break;
            case 80 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:609: LIB_MACROS
                {
                	mLIB_MACROS(); 

                }
                break;
            case 81 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:620: INTCONSTANT
                {
                	mINTCONSTANT(); 

                }
                break;
            case 82 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:632: STRING_LITERAL
                {
                	mSTRING_LITERAL(); 

                }
                break;
            case 83 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:647: FLOATCONSTANT
                {
                	mFLOATCONSTANT(); 

                }
                break;
            case 84 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:661: IDENTIFIER
                {
                	mIDENTIFIER(); 

                }
                break;
            case 85 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:672: WS
                {
                	mWS(); 

                }
                break;
            case 86 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:675: COMMENT
                {
                	mCOMMENT(); 

                }
                break;
            case 87 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForge.g:1:683: LINE_COMMENT
                {
                	mLINE_COMMENT(); 

                }
                break;

        }

    }


    protected DFA13 dfa13;
    protected DFA19 dfa19;
	private void InitializeCyclicDFAs()
	{
	    this.dfa13 = new DFA13(this);
	    this.dfa19 = new DFA19(this);
	}

    const string DFA13_eotS =
        "\x05\uffff";
    const string DFA13_eofS =
        "\x05\uffff";
    const string DFA13_minS =
        "\x02\x2e\x03\uffff";
    const string DFA13_maxS =
        "\x01\x39\x01\x65\x03\uffff";
    const string DFA13_acceptS =
        "\x02\uffff\x01\x03\x01\x02\x01\x01";
    const string DFA13_specialS =
        "\x05\uffff}>";
    static readonly string[] DFA13_transitionS = {
            "\x01\x02\x01\uffff\x0a\x01",
            "\x01\x03\x01\uffff\x0a\x01\x0b\uffff\x01\x04\x1f\uffff\x01"+
            "\x04",
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
            get { return "175:1: FLOATCONSTANT : ( ( DIGIT )+ EXPONENT | ( DIGIT )+ '.' ( DIGIT )* ( EXPONENT )? | '.' ( DIGIT )+ ( EXPONENT )? );"; }
        }

    }

    const string DFA19_eotS =
        "\x01\uffff\x0c\x2a\x01\uffff\x01\x40\x01\x42\x02\uffff\x01\x43"+
        "\x0d\uffff\x01\x47\x01\uffff\x05\x2a\x02\x4d\x03\uffff\x13\x2a\x09"+
        "\uffff\x05\x2a\x01\uffff\x01\x4d\x02\x2a\x01\x6e\x09\x2a\x01\x7c"+
        "\x01\x2a\x01\u0080\x10\x2a\x01\uffff\x02\x2a\x01\u0095\x05\x2a\x01"+
        "\u009b\x02\x2a\x01\u009e\x01\x2a\x01\uffff\x03\x2a\x01\uffff\x01"+
        "\x2a\x01\u00a5\x03\x2a\x01\u00aa\x03\x2a\x01\u00ae\x02\x2a\x01\u00b6"+
        "\x01\u00b9\x01\u00bc\x01\u00bf\x01\u00c0\x03\x2a\x01\uffff\x02\x2a"+
        "\x01\u00c6\x01\u00c7\x01\u00c8\x01\uffff\x02\x2a\x01\uffff\x06\x2a"+
        "\x01\uffff\x04\x2a\x01\uffff\x01\u00d5\x01\u00d6\x01\x2a\x01\uffff"+
        "\x04\x2a\x01\u00dc\x01\u00dd\x01\u00de\x01\uffff\x01\u00df\x01\u00e0"+
        "\x01\uffff\x01\u00e1\x01\u00e2\x01\uffff\x01\u00e3\x01\u00e4\x02"+
        "\uffff\x01\x2a\x01\u00e6\x01\u00e7\x01\u00e8\x01\x2a\x03\uffff\x04"+
        "\x2a\x01\u00f0\x01\u00f3\x01\u00f6\x05\x2a\x02\uffff\x01\x2a\x01"+
        "\u00fd\x01\u00fe\x01\u00ff\x01\u0100\x09\uffff\x01\u0101\x03\uffff"+
        "\x01\u0102\x01\u0103\x01\u0104\x02\x2a\x01\u0107\x01\u0108\x01\uffff"+
        "\x01\u0109\x01\u010a\x01\uffff\x01\u010b\x01\u010c\x01\uffff\x06"+
        "\x2a\x08\uffff\x02\x2a\x06\uffff\x04\x2a\x01\u0119\x07\x2a\x01\uffff"+
        "\x01\x2a\x01\u0122\x01\u0123\x01\u0124\x01\x2a\x01\u0127\x02\x2a"+
        "\x03\uffff\x02\x2a\x01\uffff\x02\x2a\x01\u012e\x02\x2a\x01\u0131"+
        "\x01\uffff\x02\x2a\x01\uffff\x03\x2a\x01\u0137\x01\x2a\x01\uffff"+
        "\x05\x2a\x01\u013e\x01\uffff";
    const string DFA19_eofS =
        "\u013f\uffff";
    const string DFA19_minS =
        "\x01\x09\x01\x6f\x01\x74\x01\x6e\x01\x6d\x01\x61\x01\x69\x01\x61"+
        "\x02\x65\x01\x72\x01\x61\x01\x6f\x01\uffff\x01\x3c\x01\x3e\x02\uffff"+
        "\x01\x30\x0d\uffff\x01\x2a\x01\uffff\x02\x6f\x01\x69\x01\x65\x01"+
        "\x75\x02\x2e\x03\uffff\x01\x6e\x01\x74\x01\x70\x01\x72\x01\x74\x01"+
        "\x70\x01\x74\x01\x63\x01\x6f\x01\x62\x01\x70\x01\x61\x01\x6e\x01"+
        "\x6b\x01\x61\x01\x75\x01\x6c\x01\x6f\x01\x5f\x09\uffff\x01\x6f\x01"+
        "\x75\x01\x6e\x01\x63\x01\x61\x01\uffff\x01\x2e\x01\x73\x01\x72\x01"+
        "\x30\x01\x69\x01\x6d\x01\x69\x01\x6f\x01\x31\x01\x6b\x01\x66\x01"+
        "\x74\x01\x5f\x01\x30\x01\x32\x01\x30\x02\x6c\x01\x74\x01\x5f\x01"+
        "\x6b\x01\x65\x01\x73\x01\x61\x01\x73\x01\x6c\x01\x62\x01\x74\x01"+
        "\x32\x02\x74\x01\x69\x01\uffff\x01\x63\x01\x6e\x01\x30\x01\x74\x01"+
        "\x72\x01\x34\x01\x32\x01\x36\x01\x30\x01\x61\x01\x69\x01\x30\x01"+
        "\x68\x01\uffff\x03\x78\x01\uffff\x01\x69\x01\x30\x01\x69\x01\x64"+
        "\x01\x5f\x01\x30\x01\x65\x01\x74\x01\x65\x01\x30\x01\x6c\x01\x31"+
        "\x05\x30\x01\x6e\x01\x74\x01\x67\x01\uffff\x01\x79\x01\x74\x03\x30"+
        "\x01\uffff\x01\x67\x01\x6c\x01\uffff\x01\x65\x01\x61\x01\x32\x01"+
        "\x33\x01\x34\x01\x63\x01\uffff\x01\x6d\x01\x69\x01\x75\x01\x72\x01"+
        "\uffff\x02\x30\x01\x72\x01\uffff\x01\x65\x01\x34\x01\x32\x01\x36"+
        "\x03\x30\x01\uffff\x02\x30\x01\uffff\x02\x30\x01\uffff\x02\x30\x02"+
        "\uffff\x01\x67\x03\x30\x01\x73\x03\uffff\x02\x65\x01\x61\x01\x63"+
        "\x03\x30\x01\x61\x01\x65\x01\x6d\x01\x61\x01\x65\x02\uffff\x01\x69"+
        "\x04\x30\x09\uffff\x01\x30\x03\uffff\x03\x30\x01\x64\x01\x72\x02"+
        "\x30\x01\uffff\x02\x30\x01\uffff\x02\x30\x01\uffff\x01\x74\x01\x5f"+
        "\x01\x70\x01\x6c\x01\x66\x01\x61\x08\uffff\x01\x65\x01\x6f\x06\uffff"+
        "\x01\x65\x01\x6b\x01\x6c\x01\x5f\x01\x30\x01\x6c\x01\x72\x01\x73"+
        "\x01\x64\x01\x69\x01\x65\x01\x62\x01\uffff\x01\x69\x03\x30\x01\x6e"+
        "\x01\x30\x01\x75\x01\x7a\x03\uffff\x01\x64\x01\x74\x01\uffff\x01"+
        "\x66\x01\x65\x01\x30\x01\x68\x01\x66\x01\x30\x01\uffff\x01\x72\x01"+
        "\x65\x01\uffff\x01\x65\x01\x72\x01\x61\x01\x30\x01\x64\x01\uffff"+
        "\x01\x5f\x01\x73\x01\x61\x01\x66\x01\x65\x01\x30\x01\uffff";
    const string DFA19_maxS =
        "\x01\x7d\x01\x73\x01\x74\x02\x6e\x01\x72\x01\x69\x01\x61\x01\x75"+
        "\x01\x65\x01\x72\x01\x6c\x01\x6f\x01\uffff\x01\x3c\x01\x3e\x02\uffff"+
        "\x01\x39\x0d\uffff\x01\x2f\x01\uffff\x02\x6f\x01\x69\x01\x65\x01"+
        "\x75\x02\x65\x03\uffff\x01\x6e\x01\x74\x01\x70\x01\x72\x01\x75\x01"+
        "\x70\x01\x74\x01\x63\x01\x6f\x01\x73\x01\x74\x01\x70\x01\x6e\x01"+
        "\x6b\x01\x61\x01\x75\x01\x6c\x01\x6f\x01\x5f\x09\uffff\x01\x6f\x01"+
        "\x75\x01\x6e\x01\x63\x01\x61\x01\uffff\x01\x65\x01\x73\x01\x72\x01"+
        "\x7a\x01\x75\x01\x6d\x01\x69\x01\x6f\x01\x38\x01\x6b\x01\x66\x01"+
        "\x74\x01\x5f\x01\x7a\x01\x34\x01\x7a\x02\x6c\x01\x74\x01\x5f\x01"+
        "\x6b\x01\x65\x01\x73\x01\x61\x01\x73\x01\x6c\x01\x62\x01\x74\x01"+
        "\x34\x02\x74\x01\x69\x01\uffff\x01\x63\x01\x6e\x01\x7a\x01\x74\x01"+
        "\x72\x01\x34\x01\x32\x01\x36\x01\x7a\x01\x61\x01\x69\x01\x7a\x01"+
        "\x6d\x01\uffff\x03\x78\x01\uffff\x01\x69\x01\x7a\x01\x69\x01\x73"+
        "\x01\x5f\x01\x7a\x01\x65\x01\x74\x01\x65\x01\x7a\x01\x6c\x01\x38"+
        "\x05\x7a\x01\x6e\x01\x74\x01\x67\x01\uffff\x01\x79\x01\x74\x03\x7a"+
        "\x01\uffff\x01\x67\x01\x6c\x01\uffff\x01\x65\x01\x61\x01\x32\x01"+
        "\x33\x01\x34\x01\x63\x01\uffff\x01\x6d\x01\x69\x01\x75\x01\x72\x01"+
        "\uffff\x02\x7a\x01\x72\x01\uffff\x01\x65\x01\x34\x01\x32\x01\x36"+
        "\x03\x7a\x01\uffff\x02\x7a\x01\uffff\x02\x7a\x01\uffff\x02\x7a\x02"+
        "\uffff\x01\x67\x03\x7a\x01\x73\x03\uffff\x02\x65\x01\x61\x01\x63"+
        "\x03\x7a\x01\x61\x01\x65\x01\x6d\x01\x61\x01\x65\x02\uffff\x01\x69"+
        "\x04\x7a\x09\uffff\x01\x7a\x03\uffff\x03\x7a\x01\x64\x01\x72\x02"+
        "\x7a\x01\uffff\x02\x7a\x01\uffff\x02\x7a\x01\uffff\x01\x74\x01\x5f"+
        "\x01\x70\x01\x6c\x01\x66\x01\x61\x08\uffff\x01\x65\x01\x6f\x06\uffff"+
        "\x01\x65\x01\x6b\x01\x6c\x01\x5f\x01\x7a\x01\x6c\x01\x72\x01\x73"+
        "\x01\x64\x01\x69\x01\x65\x01\x62\x01\uffff\x01\x69\x03\x7a\x01\x6e"+
        "\x01\x7a\x01\x75\x01\x7a\x03\uffff\x01\x64\x01\x74\x01\uffff\x01"+
        "\x66\x01\x65\x01\x7a\x01\x68\x01\x66\x01\x7a\x01\uffff\x01\x72\x01"+
        "\x65\x01\uffff\x01\x65\x01\x72\x01\x61\x01\x7a\x01\x64\x01\uffff"+
        "\x01\x5f\x01\x73\x01\x61\x01\x66\x01\x65\x01\x7a\x01\uffff";
    const string DFA19_acceptS =
        "\x0d\uffff\x01\x14\x02\uffff\x01\x17\x01\x18\x01\uffff\x01\x1a"+
        "\x01\x1b\x01\x1c\x01\x1d\x01\x1e\x01\x1f\x01\x22\x01\x23\x01\x24"+
        "\x01\x25\x01\x26\x01\x27\x01\x28\x01\uffff\x01\x2a\x07\uffff\x01"+
        "\x52\x01\x54\x01\x55\x13\uffff\x01\x20\x01\x15\x01\x21\x01\x16\x01"+
        "\x19\x01\x53\x01\x56\x01\x57\x01\x29\x05\uffff\x01\x51\x20\uffff"+
        "\x01\x4e\x0d\uffff\x01\x09\x03\uffff\x01\x0a\x14\uffff\x01\x03\x05"+
        "\uffff\x01\x32\x02\uffff\x01\x08\x06\uffff\x01\x2e\x04\uffff\x01"+
        "\x0c\x03\uffff\x01\x2b\x07\uffff\x01\x39\x02\uffff\x01\x3a\x02\uffff"+
        "\x01\x3b\x02\uffff\x01\x3f\x01\x01\x05\uffff\x01\x2f\x01\x30\x01"+
        "\x31\x0c\uffff\x01\x0d\x01\x2c\x05\uffff\x01\x36\x01\x40\x01\x47"+
        "\x01\x41\x01\x48\x01\x42\x01\x49\x01\x46\x01\x4d\x01\uffff\x01\x02"+
        "\x01\x37\x01\x07\x07\uffff\x01\x3c\x02\uffff\x01\x3d\x02\uffff\x01"+
        "\x3e\x06\uffff\x01\x2d\x01\x33\x01\x34\x01\x35\x01\x38\x01\x04\x01"+
        "\x05\x01\x06\x02\uffff\x01\x43\x01\x4a\x01\x44\x01\x4b\x01\x45\x01"+
        "\x4c\x0c\uffff\x01\x0b\x08\uffff\x01\x4f\x01\x50\x01\x0e\x02\uffff"+
        "\x01\x10\x06\uffff\x01\x0f\x02\uffff\x01\x13\x05\uffff\x01\x12\x06"+
        "\uffff\x01\x11";
    const string DFA19_specialS =
        "\u013f\uffff}>";
    static readonly string[] DFA19_transitionS = {
            "\x02\x2b\x02\uffff\x01\x2b\x12\uffff\x01\x2b\x01\x1b\x01\x29"+
            "\x02\uffff\x01\x21\x01\x19\x01\uffff\x01\x10\x01\x11\x01\x1f"+
            "\x01\x1e\x01\x13\x01\x1d\x01\x12\x01\x20\x01\x27\x09\x28\x01"+
            "\x14\x01\x0d\x01\x0e\x01\x1c\x01\x0f\x02\uffff\x1a\x2a\x01\x17"+
            "\x01\uffff\x01\x18\x01\uffff\x01\x2a\x01\uffff\x01\x2a\x01\x22"+
            "\x01\x01\x01\x23\x01\x03\x01\x0b\x02\x2a\x01\x04\x02\x2a\x01"+
            "\x06\x01\x07\x01\x0c\x01\x2a\x01\x05\x01\x26\x01\x08\x01\x02"+
            "\x01\x0a\x01\x24\x01\x25\x01\x09\x03\x2a\x01\x15\x01\x1a\x01"+
            "\x16",
            "\x01\x2c\x01\x2e\x02\uffff\x01\x2d",
            "\x01\x2f",
            "\x01\x30",
            "\x01\x31\x01\x32",
            "\x01\x33\x10\uffff\x01\x34",
            "\x01\x35",
            "\x01\x36",
            "\x01\x37\x0e\uffff\x01\x39\x01\x38",
            "\x01\x3a",
            "\x01\x3b",
            "\x01\x3c\x0a\uffff\x01\x3d",
            "\x01\x3e",
            "",
            "\x01\x3f",
            "\x01\x41",
            "",
            "",
            "\x0a\x44",
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
            "\x01\x45\x04\uffff\x01\x46",
            "",
            "\x01\x48",
            "\x01\x49",
            "\x01\x4a",
            "\x01\x4b",
            "\x01\x4c",
            "\x01\x44\x01\uffff\x0a\x4e\x0b\uffff\x01\x44\x1f\uffff\x01"+
            "\x44",
            "\x01\x44\x01\uffff\x0a\x4e\x0b\uffff\x01\x44\x1f\uffff\x01"+
            "\x44",
            "",
            "",
            "",
            "\x01\x4f",
            "\x01\x50",
            "\x01\x51",
            "\x01\x52",
            "\x01\x54\x01\x53",
            "\x01\x55",
            "\x01\x56",
            "\x01\x57",
            "\x01\x58",
            "\x01\x5a\x10\uffff\x01\x59",
            "\x01\x5b\x03\uffff\x01\x5c",
            "\x01\x5f\x04\uffff\x01\x5d\x09\uffff\x01\x5e",
            "\x01\x60",
            "\x01\x61",
            "\x01\x62",
            "\x01\x63",
            "\x01\x64",
            "\x01\x65",
            "\x01\x66",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\x67",
            "\x01\x68",
            "\x01\x69",
            "\x01\x6a",
            "\x01\x6b",
            "",
            "\x01\x44\x01\uffff\x0a\x4e\x0b\uffff\x01\x44\x1f\uffff\x01"+
            "\x44",
            "\x01\x6c",
            "\x01\x6d",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x01\x70\x0b\uffff\x01\x6f",
            "\x01\x71",
            "\x01\x72",
            "\x01\x73",
            "\x01\x76\x01\uffff\x01\x75\x02\uffff\x01\x74\x01\uffff\x01"+
            "\x77",
            "\x01\x78",
            "\x01\x79",
            "\x01\x7a",
            "\x01\x7b",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x01\x7d\x01\x7e\x01\x7f",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x01\u0081",
            "\x01\u0082",
            "\x01\u0083",
            "\x01\u0084",
            "\x01\u0085",
            "\x01\u0086",
            "\x01\u0087",
            "\x01\u0088",
            "\x01\u0089",
            "\x01\u008a",
            "\x01\u008b",
            "\x01\u008c",
            "\x01\u008d\x01\u008e\x01\u008f",
            "\x01\u0090",
            "\x01\u0091",
            "\x01\u0092",
            "",
            "\x01\u0093",
            "\x01\u0094",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x01\u0096",
            "\x01\u0097",
            "\x01\u0098",
            "\x01\u0099",
            "\x01\u009a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x01\u009c",
            "\x01\u009d",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x01\u009f\x04\uffff\x01\u00a0",
            "",
            "\x01\u00a1",
            "\x01\u00a2",
            "\x01\u00a3",
            "",
            "\x01\u00a4",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x01\u00a6",
            "\x01\u00a8\x0e\uffff\x01\u00a7",
            "\x01\u00a9",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x01\u00ab",
            "\x01\u00ac",
            "\x01\u00ad",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x01\u00af",
            "\x01\u00b2\x01\uffff\x01\u00b1\x02\uffff\x01\u00b0\x01\uffff"+
            "\x01\u00b3",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x03"+
            "\x2a\x01\u00b5\x01\x2a\x01\u00b4\x14\x2a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x03"+
            "\x2a\x01\u00b8\x01\x2a\x01\u00b7\x14\x2a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x03"+
            "\x2a\x01\u00bb\x01\x2a\x01\u00ba\x14\x2a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x03"+
            "\x2a\x01\u00be\x01\x2a\x01\u00bd\x14\x2a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x01\u00c1",
            "\x01\u00c2",
            "\x01\u00c3",
            "",
            "\x01\u00c4",
            "\x01\u00c5",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "",
            "\x01\u00c9",
            "\x01\u00ca",
            "",
            "\x01\u00cb",
            "\x01\u00cc",
            "\x01\u00cd",
            "\x01\u00ce",
            "\x01\u00cf",
            "\x01\u00d0",
            "",
            "\x01\u00d1",
            "\x01\u00d2",
            "\x01\u00d3",
            "\x01\u00d4",
            "",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x01\u00d7",
            "",
            "\x01\u00d8",
            "\x01\u00d9",
            "\x01\u00da",
            "\x01\u00db",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "",
            "",
            "\x01\u00e5",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x01\u00e9",
            "",
            "",
            "",
            "\x01\u00ea",
            "\x01\u00eb",
            "\x01\u00ec",
            "\x01\u00ed",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x03"+
            "\x2a\x01\u00ef\x01\x2a\x01\u00ee\x14\x2a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x03"+
            "\x2a\x01\u00f2\x01\x2a\x01\u00f1\x14\x2a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x03"+
            "\x2a\x01\u00f5\x01\x2a\x01\u00f4\x14\x2a",
            "\x01\u00f7",
            "\x01\u00f8",
            "\x01\u00f9",
            "\x01\u00fa",
            "\x01\u00fb",
            "",
            "",
            "\x01\u00fc",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "",
            "",
            "",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x01\u0105",
            "\x01\u0106",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "",
            "\x01\u010d",
            "\x01\u010e",
            "\x01\u010f",
            "\x01\u0110",
            "\x01\u0111",
            "\x01\u0112",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\u0113",
            "\x01\u0114",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\u0115",
            "\x01\u0116",
            "\x01\u0117",
            "\x01\u0118",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x01\u011a",
            "\x01\u011b",
            "\x01\u011c",
            "\x01\u011d",
            "\x01\u011e",
            "\x01\u011f",
            "\x01\u0120",
            "",
            "\x01\u0121",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x01\u0125",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\u0126\x01\uffff\x1a"+
            "\x2a",
            "\x01\u0128",
            "\x01\u0129",
            "",
            "",
            "",
            "\x01\u012a",
            "\x01\u012b",
            "",
            "\x01\u012c",
            "\x01\u012d",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x01\u012f",
            "\x01\u0130",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "",
            "\x01\u0132",
            "\x01\u0133",
            "",
            "\x01\u0134",
            "\x01\u0135",
            "\x01\u0136",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            "\x01\u0138",
            "",
            "\x01\u0139",
            "\x01\u013a",
            "\x01\u013b",
            "\x01\u013c",
            "\x01\u013d",
            "\x0a\x2a\x07\uffff\x1a\x2a\x04\uffff\x01\x2a\x01\uffff\x1a"+
            "\x2a",
            ""
    };

    static readonly short[] DFA19_eot = DFA.UnpackEncodedString(DFA19_eotS);
    static readonly short[] DFA19_eof = DFA.UnpackEncodedString(DFA19_eofS);
    static readonly char[] DFA19_min = DFA.UnpackEncodedStringToUnsignedChars(DFA19_minS);
    static readonly char[] DFA19_max = DFA.UnpackEncodedStringToUnsignedChars(DFA19_maxS);
    static readonly short[] DFA19_accept = DFA.UnpackEncodedString(DFA19_acceptS);
    static readonly short[] DFA19_special = DFA.UnpackEncodedString(DFA19_specialS);
    static readonly short[][] DFA19_transition = DFA.UnpackEncodedStringArray(DFA19_transitionS);

    protected class DFA19 : DFA
    {
        public DFA19(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 19;
            this.eot = DFA19_eot;
            this.eof = DFA19_eof;
            this.min = DFA19_min;
            this.max = DFA19_max;
            this.accept = DFA19_accept;
            this.special = DFA19_special;
            this.transition = DFA19_transition;

        }

        override public string Description
        {
            get { return "1:1: Tokens : ( CONST | STRUCT | ENUM | IMPORTS | PACKAGE | PROFILE | ENTITY | LIST | MAP | REF | WEAKREF | TRUE | FALSE | REPLICATED | RUNTIME_KIND | RTK_SIMPLE | RTK_SIMPLE_THREAD_SAFE | RTK_DUAL_BUFFER | NOSERIALIZE | SEMICOLON | LEFT_ANGLE | RIGHT_ANGLE | LEFT_PAREN | RIGHT_PAREN | DOT | COMMA | COLON | LEFT_BRACE | RIGHT_BRACE | LEFT_BRACKET | RIGHT_BRACKET | LEFT_OP | RIGHT_OP | AND_OP | OR_OP | BANG | EQUAL | DASH | PLUS | STAR | SLASH | PERCENT | BOOL | FLOAT | DOUBLE | REAL | INT64 | INT32 | INT16 | INT8 | UINT64 | UINT32 | UINT16 | UINT8 | STRING | CSTRING | VEC2 | VEC3 | VEC4 | MAT2X2 | MAT3X3 | MAT4X4 | QUAT | VEC2F | VEC3F | VEC4F | MAT2X2F | MAT3X3F | MAT4X4F | QUATF | VEC2D | VEC3D | VEC4D | MAT2X2D | MAT3X3D | MAT4X4D | QUATD | CPP | LIB_HEADER | LIB_MACROS | INTCONSTANT | STRING_LITERAL | FLOATCONSTANT | IDENTIFIER | WS | COMMENT | LINE_COMMENT );"; }
        }

    }

 
    
}
