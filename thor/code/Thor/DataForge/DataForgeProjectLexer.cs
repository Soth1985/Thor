// $ANTLR 3.2 Sep 23, 2009 12:02:23 E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g 2013-07-03 17:53:23

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;


public partial class DataForgeProjectLexer : Lexer {
    public const int EXPONENT = 44;
    public const int STAR = 36;
    public const int FILES = 18;
    public const int RTK_DUAL_BUFFER = 27;
    public const int LETTER = 41;
    public const int FILENAMEPOSTFIX = 23;
    public const int LEFT_BRACKET = 16;
    public const int FLOAT = 39;
    public const int EOF = -1;
    public const int INCLUDES = 19;
    public const int RIGHT_PAREN = 10;
    public const int SLASH = 37;
    public const int STRING_LITERAL = 48;
    public const int COMMA = 12;
    public const int HEX = 43;
    public const int OUTPUTDIR = 20;
    public const int IDENTIFIER = 50;
    public const int EQUAL = 33;
    public const int RIGHT_BRACKET = 17;
    public const int DOUBLE = 40;
    public const int PLUS = 35;
    public const int RIGHT_OP = 29;
    public const int FLOATSUFFIX = 45;
    public const int DIGIT = 42;
    public const int COMMENT = 52;
    public const int DOT = 11;
    public const int RIGHT_BRACE = 15;
    public const int OR_OP = 31;
    public const int PERCENT = 38;
    public const int DASH = 34;
    public const int LINE_COMMENT = 53;
    public const int SEMICOLON = 6;
    public const int BANG = 32;
    public const int TRUE = 4;
    public const int REALTYPE = 22;
    public const int DEFINES = 21;
    public const int RUNTIME_KIND = 24;
    public const int COLON = 13;
    public const int AND_OP = 30;
    public const int RTK_SIMPLE = 25;
    public const int INTCONSTANT = 46;
    public const int WS = 51;
    public const int FLOATCONSTANT = 49;
    public const int LEFT_BRACE = 14;
    public const int LEFT_OP = 28;
    public const int RTK_SIMPLE_THREAD_SAFE = 26;
    public const int LEFT_PAREN = 9;
    public const int LEFT_ANGLE = 7;
    public const int FALSE = 5;
    public const int RIGHT_ANGLE = 8;
    public const int EscapeSequence = 47;

    // delegates
    // delegators

    public DataForgeProjectLexer() 
    {
		InitializeCyclicDFAs();
    }
    public DataForgeProjectLexer(ICharStream input)
		: this(input, null) {
    }
    public DataForgeProjectLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state) {
		InitializeCyclicDFAs(); 

    }
    
    override public string GrammarFileName
    {
    	get { return "E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g";} 
    }

    // $ANTLR start "TRUE"
    public void mTRUE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = TRUE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:7:6: ( 'true' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:7:8: 'true'
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:8:7: ( 'false' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:8:9: 'false'
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

    // $ANTLR start "SEMICOLON"
    public void mSEMICOLON() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = SEMICOLON;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:9:11: ( ';' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:9:13: ';'
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:10:12: ( '<' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:10:14: '<'
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:11:13: ( '>' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:11:15: '>'
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:12:12: ( '(' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:12:14: '('
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:13:13: ( ')' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:13:15: ')'
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:14:5: ( '.' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:14:7: '.'
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:15:7: ( ',' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:15:9: ','
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:16:7: ( ':' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:16:9: ':'
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:17:12: ( '{' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:17:14: '{'
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:18:13: ( '}' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:18:15: '}'
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:19:14: ( '[' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:19:16: '['
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:20:15: ( ']' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:20:17: ']'
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

    // $ANTLR start "FILES"
    public void mFILES() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = FILES;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:21:7: ( 'files' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:21:9: 'files'
            {
            	Match("files"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "FILES"

    // $ANTLR start "INCLUDES"
    public void mINCLUDES() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = INCLUDES;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:22:10: ( 'includes' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:22:12: 'includes'
            {
            	Match("includes"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "INCLUDES"

    // $ANTLR start "OUTPUTDIR"
    public void mOUTPUTDIR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = OUTPUTDIR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:23:11: ( 'output_dir' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:23:13: 'output_dir'
            {
            	Match("output_dir"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "OUTPUTDIR"

    // $ANTLR start "DEFINES"
    public void mDEFINES() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DEFINES;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:24:9: ( 'defines' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:24:11: 'defines'
            {
            	Match("defines"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "DEFINES"

    // $ANTLR start "REALTYPE"
    public void mREALTYPE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = REALTYPE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:25:10: ( 'real_type' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:25:12: 'real_type'
            {
            	Match("real_type"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "REALTYPE"

    // $ANTLR start "FILENAMEPOSTFIX"
    public void mFILENAMEPOSTFIX() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = FILENAMEPOSTFIX;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:26:17: ( 'filename_postfix' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:26:19: 'filename_postfix'
            {
            	Match("filename_postfix"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "FILENAMEPOSTFIX"

    // $ANTLR start "RUNTIME_KIND"
    public void mRUNTIME_KIND() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = RUNTIME_KIND;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:27:14: ( 'runtime_kind' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:27:16: 'runtime_kind'
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:28:12: ( 'rtk_simple' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:28:14: 'rtk_simple'
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:29:24: ( 'rtk_simple_thread_safe' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:29:26: 'rtk_simple_thread_safe'
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:30:17: ( 'rtk_dual_buffer' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:30:19: 'rtk_dual_buffer'
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

    // $ANTLR start "LEFT_OP"
    public void mLEFT_OP() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LEFT_OP;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:31:9: ( '<<' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:31:11: '<<'
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:32:10: ( '>>' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:32:12: '>>'
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:33:8: ( '&&' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:33:10: '&&'
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:34:7: ( '||' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:34:9: '||'
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:35:6: ( '!' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:35:8: '!'
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:36:7: ( '=' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:36:9: '='
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:37:6: ( '-' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:37:8: '-'
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:38:6: ( '+' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:38:8: '+'
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:39:6: ( '*' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:39:8: '*'
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:40:7: ( '/' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:40:9: '/'
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:41:9: ( '%' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:41:11: '%'
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

    // $ANTLR start "FLOAT"
    public void mFLOAT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = FLOAT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:42:7: ( 'float' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:42:9: 'float'
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:43:8: ( 'double' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:43:10: 'double'
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

    // $ANTLR start "LETTER"
    public void mLETTER() // throws RecognitionException [2]
    {
    		try
    		{
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:72:2: ( 'A' .. 'Z' | 'a' .. 'z' | '_' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:78:7: ( '0' .. '9' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:78:9: '0' .. '9'
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:82:5: ( 'a' .. 'f' | 'A' .. 'F' | '0' .. '9' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:88:9: ( ( 'E' | 'e' ) ( '+' | '-' )+ ( DIGIT )+ )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:88:11: ( 'E' | 'e' ) ( '+' | '-' )+ ( DIGIT )+
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

            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:88:21: ( '+' | '-' )+
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
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:
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

            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:88:34: ( DIGIT )+
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
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:88:34: DIGIT
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

    // $ANTLR start "FLOATSUFFIX"
    public void mFLOATSUFFIX() // throws RecognitionException [2]
    {
    		try
    		{
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:93:2: ( ( 'f' | 'F' ) )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:93:4: ( 'f' | 'F' )
            {
            	if ( input.LA(1) == 'F' || input.LA(1) == 'f' ) 
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
    // $ANTLR end "FLOATSUFFIX"

    // $ANTLR start "INTCONSTANT"
    public void mINTCONSTANT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = INTCONSTANT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:97:2: ( '0' ( 'x' | 'X' ) ( HEX )+ | ( '0' | '1' .. '9' ) ( DIGIT )* )
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
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:97:4: '0' ( 'x' | 'X' ) ( HEX )+
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

                    	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:97:18: ( HEX )+
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
                    			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:97:18: HEX
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
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:98:4: ( '0' | '1' .. '9' ) ( DIGIT )*
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

                    	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:98:21: ( DIGIT )*
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
                    			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:98:21: DIGIT
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:103:5: ( '\\\\' ( 'b' | 't' | 'n' | 'f' | 'r' | '\\\"' | '\\'' | '\\\\' ) )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:103:9: '\\\\' ( 'b' | 't' | 'n' | 'f' | 'r' | '\\\"' | '\\'' | '\\\\' )
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:107:5: ( '\"' ( EscapeSequence | ~ ( '\\\\' | '\"' ) )* '\"' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:107:8: '\"' ( EscapeSequence | ~ ( '\\\\' | '\"' ) )* '\"'
            {
            	Match('\"'); 
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:107:12: ( EscapeSequence | ~ ( '\\\\' | '\"' ) )*
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
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:107:14: EscapeSequence
            			    {
            			    	mEscapeSequence(); 

            			    }
            			    break;
            			case 2 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:107:31: ~ ( '\\\\' | '\"' )
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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:111:2: ( ( DIGIT )+ EXPONENT ( FLOATSUFFIX )? | ( DIGIT )+ '.' ( DIGIT )* ( EXPONENT )? ( FLOATSUFFIX )? | '.' ( DIGIT )+ ( EXPONENT )? ( FLOATSUFFIX )? )
            int alt16 = 3;
            alt16 = dfa16.Predict(input);
            switch (alt16) 
            {
                case 1 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:111:4: ( DIGIT )+ EXPONENT ( FLOATSUFFIX )?
                    {
                    	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:111:4: ( DIGIT )+
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
                    			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:111:4: DIGIT
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
                    	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:111:20: ( FLOATSUFFIX )?
                    	int alt8 = 2;
                    	int LA8_0 = input.LA(1);

                    	if ( (LA8_0 == 'F' || LA8_0 == 'f') )
                    	{
                    	    alt8 = 1;
                    	}
                    	switch (alt8) 
                    	{
                    	    case 1 :
                    	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:111:20: FLOATSUFFIX
                    	        {
                    	        	mFLOATSUFFIX(); 

                    	        }
                    	        break;

                    	}


                    }
                    break;
                case 2 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:112:4: ( DIGIT )+ '.' ( DIGIT )* ( EXPONENT )? ( FLOATSUFFIX )?
                    {
                    	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:112:4: ( DIGIT )+
                    	int cnt9 = 0;
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
                    			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:112:4: DIGIT
                    			    {
                    			    	mDIGIT(); 

                    			    }
                    			    break;

                    			default:
                    			    if ( cnt9 >= 1 ) goto loop9;
                    		            EarlyExitException eee9 =
                    		                new EarlyExitException(9, input);
                    		            throw eee9;
                    	    }
                    	    cnt9++;
                    	} while (true);

                    	loop9:
                    		;	// Stops C# compiler whining that label 'loop9' has no statements

                    	Match('.'); 
                    	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:112:15: ( DIGIT )*
                    	do 
                    	{
                    	    int alt10 = 2;
                    	    int LA10_0 = input.LA(1);

                    	    if ( ((LA10_0 >= '0' && LA10_0 <= '9')) )
                    	    {
                    	        alt10 = 1;
                    	    }


                    	    switch (alt10) 
                    		{
                    			case 1 :
                    			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:112:15: DIGIT
                    			    {
                    			    	mDIGIT(); 

                    			    }
                    			    break;

                    			default:
                    			    goto loop10;
                    	    }
                    	} while (true);

                    	loop10:
                    		;	// Stops C# compiler whining that label 'loop10' has no statements

                    	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:112:22: ( EXPONENT )?
                    	int alt11 = 2;
                    	int LA11_0 = input.LA(1);

                    	if ( (LA11_0 == 'E' || LA11_0 == 'e') )
                    	{
                    	    alt11 = 1;
                    	}
                    	switch (alt11) 
                    	{
                    	    case 1 :
                    	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:112:22: EXPONENT
                    	        {
                    	        	mEXPONENT(); 

                    	        }
                    	        break;

                    	}

                    	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:112:32: ( FLOATSUFFIX )?
                    	int alt12 = 2;
                    	int LA12_0 = input.LA(1);

                    	if ( (LA12_0 == 'F' || LA12_0 == 'f') )
                    	{
                    	    alt12 = 1;
                    	}
                    	switch (alt12) 
                    	{
                    	    case 1 :
                    	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:112:32: FLOATSUFFIX
                    	        {
                    	        	mFLOATSUFFIX(); 

                    	        }
                    	        break;

                    	}


                    }
                    break;
                case 3 :
                    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:113:4: '.' ( DIGIT )+ ( EXPONENT )? ( FLOATSUFFIX )?
                    {
                    	Match('.'); 
                    	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:113:8: ( DIGIT )+
                    	int cnt13 = 0;
                    	do 
                    	{
                    	    int alt13 = 2;
                    	    int LA13_0 = input.LA(1);

                    	    if ( ((LA13_0 >= '0' && LA13_0 <= '9')) )
                    	    {
                    	        alt13 = 1;
                    	    }


                    	    switch (alt13) 
                    		{
                    			case 1 :
                    			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:113:8: DIGIT
                    			    {
                    			    	mDIGIT(); 

                    			    }
                    			    break;

                    			default:
                    			    if ( cnt13 >= 1 ) goto loop13;
                    		            EarlyExitException eee13 =
                    		                new EarlyExitException(13, input);
                    		            throw eee13;
                    	    }
                    	    cnt13++;
                    	} while (true);

                    	loop13:
                    		;	// Stops C# compiler whining that label 'loop13' has no statements

                    	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:113:15: ( EXPONENT )?
                    	int alt14 = 2;
                    	int LA14_0 = input.LA(1);

                    	if ( (LA14_0 == 'E' || LA14_0 == 'e') )
                    	{
                    	    alt14 = 1;
                    	}
                    	switch (alt14) 
                    	{
                    	    case 1 :
                    	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:113:15: EXPONENT
                    	        {
                    	        	mEXPONENT(); 

                    	        }
                    	        break;

                    	}

                    	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:113:25: ( FLOATSUFFIX )?
                    	int alt15 = 2;
                    	int LA15_0 = input.LA(1);

                    	if ( (LA15_0 == 'F' || LA15_0 == 'f') )
                    	{
                    	    alt15 = 1;
                    	}
                    	switch (alt15) 
                    	{
                    	    case 1 :
                    	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:113:25: FLOATSUFFIX
                    	        {
                    	        	mFLOATSUFFIX(); 

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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:117:2: ( LETTER ( LETTER | DIGIT )* )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:117:4: LETTER ( LETTER | DIGIT )*
            {
            	mLETTER(); 
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:117:11: ( LETTER | DIGIT )*
            	do 
            	{
            	    int alt17 = 2;
            	    int LA17_0 = input.LA(1);

            	    if ( ((LA17_0 >= '0' && LA17_0 <= '9') || (LA17_0 >= 'A' && LA17_0 <= 'Z') || LA17_0 == '_' || (LA17_0 >= 'a' && LA17_0 <= 'z')) )
            	    {
            	        alt17 = 1;
            	    }


            	    switch (alt17) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:
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
            			    goto loop17;
            	    }
            	} while (true);

            	loop17:
            		;	// Stops C# compiler whining that label 'loop17' has no statements


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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:121:5: ( ( ' ' | '\\r' | '\\t' | '\\n' )+ )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:121:8: ( ' ' | '\\r' | '\\t' | '\\n' )+
            {
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:121:8: ( ' ' | '\\r' | '\\t' | '\\n' )+
            	int cnt18 = 0;
            	do 
            	{
            	    int alt18 = 2;
            	    int LA18_0 = input.LA(1);

            	    if ( ((LA18_0 >= '\t' && LA18_0 <= '\n') || LA18_0 == '\r' || LA18_0 == ' ') )
            	    {
            	        alt18 = 1;
            	    }


            	    switch (alt18) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:
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
            			    if ( cnt18 >= 1 ) goto loop18;
            		            EarlyExitException eee18 =
            		                new EarlyExitException(18, input);
            		            throw eee18;
            	    }
            	    cnt18++;
            	} while (true);

            	loop18:
            		;	// Stops C# compiler whining that label 'loop18' has no statements

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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:125:5: ( '/*' ( options {greedy=false; } : . )* '*/' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:125:9: '/*' ( options {greedy=false; } : . )* '*/'
            {
            	Match("/*"); 

            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:125:14: ( options {greedy=false; } : . )*
            	do 
            	{
            	    int alt19 = 2;
            	    int LA19_0 = input.LA(1);

            	    if ( (LA19_0 == '*') )
            	    {
            	        int LA19_1 = input.LA(2);

            	        if ( (LA19_1 == '/') )
            	        {
            	            alt19 = 2;
            	        }
            	        else if ( ((LA19_1 >= '\u0000' && LA19_1 <= '.') || (LA19_1 >= '0' && LA19_1 <= '\uFFFF')) )
            	        {
            	            alt19 = 1;
            	        }


            	    }
            	    else if ( ((LA19_0 >= '\u0000' && LA19_0 <= ')') || (LA19_0 >= '+' && LA19_0 <= '\uFFFF')) )
            	    {
            	        alt19 = 1;
            	    }


            	    switch (alt19) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:125:42: .
            			    {
            			    	MatchAny(); 

            			    }
            			    break;

            			default:
            			    goto loop19;
            	    }
            	} while (true);

            	loop19:
            		;	// Stops C# compiler whining that label 'loop19' has no statements

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
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:129:5: ( '//' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n' )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:129:7: '//' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n'
            {
            	Match("//"); 

            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:129:12: (~ ( '\\n' | '\\r' ) )*
            	do 
            	{
            	    int alt20 = 2;
            	    int LA20_0 = input.LA(1);

            	    if ( ((LA20_0 >= '\u0000' && LA20_0 <= '\t') || (LA20_0 >= '\u000B' && LA20_0 <= '\f') || (LA20_0 >= '\u000E' && LA20_0 <= '\uFFFF')) )
            	    {
            	        alt20 = 1;
            	    }


            	    switch (alt20) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:129:12: ~ ( '\\n' | '\\r' )
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
            			    goto loop20;
            	    }
            	} while (true);

            	loop20:
            		;	// Stops C# compiler whining that label 'loop20' has no statements

            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:129:26: ( '\\r' )?
            	int alt21 = 2;
            	int LA21_0 = input.LA(1);

            	if ( (LA21_0 == '\r') )
            	{
            	    alt21 = 1;
            	}
            	switch (alt21) 
            	{
            	    case 1 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:129:26: '\\r'
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
        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:8: ( TRUE | FALSE | SEMICOLON | LEFT_ANGLE | RIGHT_ANGLE | LEFT_PAREN | RIGHT_PAREN | DOT | COMMA | COLON | LEFT_BRACE | RIGHT_BRACE | LEFT_BRACKET | RIGHT_BRACKET | FILES | INCLUDES | OUTPUTDIR | DEFINES | REALTYPE | FILENAMEPOSTFIX | RUNTIME_KIND | RTK_SIMPLE | RTK_SIMPLE_THREAD_SAFE | RTK_DUAL_BUFFER | LEFT_OP | RIGHT_OP | AND_OP | OR_OP | BANG | EQUAL | DASH | PLUS | STAR | SLASH | PERCENT | FLOAT | DOUBLE | INTCONSTANT | STRING_LITERAL | FLOATCONSTANT | IDENTIFIER | WS | COMMENT | LINE_COMMENT )
        int alt22 = 44;
        alt22 = dfa22.Predict(input);
        switch (alt22) 
        {
            case 1 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:10: TRUE
                {
                	mTRUE(); 

                }
                break;
            case 2 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:15: FALSE
                {
                	mFALSE(); 

                }
                break;
            case 3 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:21: SEMICOLON
                {
                	mSEMICOLON(); 

                }
                break;
            case 4 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:31: LEFT_ANGLE
                {
                	mLEFT_ANGLE(); 

                }
                break;
            case 5 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:42: RIGHT_ANGLE
                {
                	mRIGHT_ANGLE(); 

                }
                break;
            case 6 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:54: LEFT_PAREN
                {
                	mLEFT_PAREN(); 

                }
                break;
            case 7 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:65: RIGHT_PAREN
                {
                	mRIGHT_PAREN(); 

                }
                break;
            case 8 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:77: DOT
                {
                	mDOT(); 

                }
                break;
            case 9 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:81: COMMA
                {
                	mCOMMA(); 

                }
                break;
            case 10 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:87: COLON
                {
                	mCOLON(); 

                }
                break;
            case 11 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:93: LEFT_BRACE
                {
                	mLEFT_BRACE(); 

                }
                break;
            case 12 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:104: RIGHT_BRACE
                {
                	mRIGHT_BRACE(); 

                }
                break;
            case 13 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:116: LEFT_BRACKET
                {
                	mLEFT_BRACKET(); 

                }
                break;
            case 14 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:129: RIGHT_BRACKET
                {
                	mRIGHT_BRACKET(); 

                }
                break;
            case 15 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:143: FILES
                {
                	mFILES(); 

                }
                break;
            case 16 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:149: INCLUDES
                {
                	mINCLUDES(); 

                }
                break;
            case 17 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:158: OUTPUTDIR
                {
                	mOUTPUTDIR(); 

                }
                break;
            case 18 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:168: DEFINES
                {
                	mDEFINES(); 

                }
                break;
            case 19 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:176: REALTYPE
                {
                	mREALTYPE(); 

                }
                break;
            case 20 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:185: FILENAMEPOSTFIX
                {
                	mFILENAMEPOSTFIX(); 

                }
                break;
            case 21 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:201: RUNTIME_KIND
                {
                	mRUNTIME_KIND(); 

                }
                break;
            case 22 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:214: RTK_SIMPLE
                {
                	mRTK_SIMPLE(); 

                }
                break;
            case 23 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:225: RTK_SIMPLE_THREAD_SAFE
                {
                	mRTK_SIMPLE_THREAD_SAFE(); 

                }
                break;
            case 24 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:248: RTK_DUAL_BUFFER
                {
                	mRTK_DUAL_BUFFER(); 

                }
                break;
            case 25 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:264: LEFT_OP
                {
                	mLEFT_OP(); 

                }
                break;
            case 26 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:272: RIGHT_OP
                {
                	mRIGHT_OP(); 

                }
                break;
            case 27 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:281: AND_OP
                {
                	mAND_OP(); 

                }
                break;
            case 28 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:288: OR_OP
                {
                	mOR_OP(); 

                }
                break;
            case 29 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:294: BANG
                {
                	mBANG(); 

                }
                break;
            case 30 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:299: EQUAL
                {
                	mEQUAL(); 

                }
                break;
            case 31 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:305: DASH
                {
                	mDASH(); 

                }
                break;
            case 32 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:310: PLUS
                {
                	mPLUS(); 

                }
                break;
            case 33 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:315: STAR
                {
                	mSTAR(); 

                }
                break;
            case 34 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:320: SLASH
                {
                	mSLASH(); 

                }
                break;
            case 35 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:326: PERCENT
                {
                	mPERCENT(); 

                }
                break;
            case 36 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:334: FLOAT
                {
                	mFLOAT(); 

                }
                break;
            case 37 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:340: DOUBLE
                {
                	mDOUBLE(); 

                }
                break;
            case 38 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:347: INTCONSTANT
                {
                	mINTCONSTANT(); 

                }
                break;
            case 39 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:359: STRING_LITERAL
                {
                	mSTRING_LITERAL(); 

                }
                break;
            case 40 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:374: FLOATCONSTANT
                {
                	mFLOATCONSTANT(); 

                }
                break;
            case 41 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:388: IDENTIFIER
                {
                	mIDENTIFIER(); 

                }
                break;
            case 42 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:399: WS
                {
                	mWS(); 

                }
                break;
            case 43 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:402: COMMENT
                {
                	mCOMMENT(); 

                }
                break;
            case 44 :
                // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:1:410: LINE_COMMENT
                {
                	mLINE_COMMENT(); 

                }
                break;

        }

    }


    protected DFA16 dfa16;
    protected DFA22 dfa22;
	private void InitializeCyclicDFAs()
	{
	    this.dfa16 = new DFA16(this);
	    this.dfa22 = new DFA22(this);
	}

    const string DFA16_eotS =
        "\x05\uffff";
    const string DFA16_eofS =
        "\x05\uffff";
    const string DFA16_minS =
        "\x02\x2e\x03\uffff";
    const string DFA16_maxS =
        "\x01\x39\x01\x65\x03\uffff";
    const string DFA16_acceptS =
        "\x02\uffff\x01\x03\x01\x01\x01\x02";
    const string DFA16_specialS =
        "\x05\uffff}>";
    static readonly string[] DFA16_transitionS = {
            "\x01\x02\x01\uffff\x0a\x01",
            "\x01\x04\x01\uffff\x0a\x01\x0b\uffff\x01\x03\x1f\uffff\x01"+
            "\x03",
            "",
            "",
            ""
    };

    static readonly short[] DFA16_eot = DFA.UnpackEncodedString(DFA16_eotS);
    static readonly short[] DFA16_eof = DFA.UnpackEncodedString(DFA16_eofS);
    static readonly char[] DFA16_min = DFA.UnpackEncodedStringToUnsignedChars(DFA16_minS);
    static readonly char[] DFA16_max = DFA.UnpackEncodedStringToUnsignedChars(DFA16_maxS);
    static readonly short[] DFA16_accept = DFA.UnpackEncodedString(DFA16_acceptS);
    static readonly short[] DFA16_special = DFA.UnpackEncodedString(DFA16_specialS);
    static readonly short[][] DFA16_transition = DFA.UnpackEncodedStringArray(DFA16_transitionS);

    protected class DFA16 : DFA
    {
        public DFA16(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 16;
            this.eot = DFA16_eot;
            this.eof = DFA16_eof;
            this.min = DFA16_min;
            this.max = DFA16_max;
            this.accept = DFA16_accept;
            this.special = DFA16_special;
            this.transition = DFA16_transition;

        }

        override public string Description
        {
            get { return "110:1: FLOATCONSTANT : ( ( DIGIT )+ EXPONENT ( FLOATSUFFIX )? | ( DIGIT )+ '.' ( DIGIT )* ( EXPONENT )? ( FLOATSUFFIX )? | '.' ( DIGIT )+ ( EXPONENT )? ( FLOATSUFFIX )? );"; }
        }

    }

    const string DFA22_eotS =
        "\x01\uffff\x02\x1f\x01\uffff\x01\x26\x01\x28\x02\uffff\x01\x2a"+
        "\x06\uffff\x04\x1f\x07\uffff\x01\x34\x01\uffff\x02\x35\x03\uffff"+
        "\x04\x1f\x06\uffff\x07\x1f\x04\uffff\x01\x35\x0b\x1f\x01\x4d\x0a"+
        "\x1f\x01\uffff\x01\x5a\x01\x5b\x01\x1f\x01\x5d\x08\x1f\x02\uffff"+
        "\x01\x1f\x01\uffff\x03\x1f\x01\x6a\x07\x1f\x01\x72\x01\uffff\x05"+
        "\x1f\x01\x78\x01\x1f\x01\uffff\x05\x1f\x01\uffff\x01\x1f\x01\u0080"+
        "\x04\x1f\x01\u0085\x01\uffff\x01\x1f\x01\u0088\x02\x1f\x01\uffff"+
        "\x02\x1f\x01\uffff\x02\x1f\x01\u008f\x03\x1f\x01\uffff\x07\x1f\x01"+
        "\u009a\x01\u009b\x01\x1f\x02\uffff\x05\x1f\x01\u00a2\x01\uffff";
    const string DFA22_eofS =
        "\u00a3\uffff";
    const string DFA22_minS =
        "\x01\x09\x01\x72\x01\x61\x01\uffff\x01\x3c\x01\x3e\x02\uffff\x01"+
        "\x30\x06\uffff\x01\x6e\x01\x75\x02\x65\x07\uffff\x01\x2a\x01\uffff"+
        "\x02\x2e\x03\uffff\x01\x75\x02\x6c\x01\x6f\x06\uffff\x01\x63\x01"+
        "\x74\x01\x66\x01\x75\x01\x61\x01\x6e\x01\x6b\x04\uffff\x01\x2e\x01"+
        "\x65\x01\x73\x01\x65\x01\x61\x01\x6c\x01\x70\x01\x69\x01\x62\x01"+
        "\x6c\x01\x74\x01\x5f\x01\x30\x01\x65\x01\x6e\x01\x74\x02\x75\x01"+
        "\x6e\x01\x6c\x01\x5f\x01\x69\x01\x64\x01\uffff\x02\x30\x01\x61\x01"+
        "\x30\x01\x64\x01\x74\x02\x65\x01\x74\x01\x6d\x01\x69\x01\x75\x02"+
        "\uffff\x01\x6d\x01\uffff\x01\x65\x01\x5f\x01\x73\x01\x30\x01\x79"+
        "\x01\x65\x01\x6d\x01\x61\x01\x65\x01\x73\x01\x64\x01\x30\x01\uffff"+
        "\x01\x70\x01\x5f\x01\x70\x01\x6c\x01\x5f\x01\x30\x01\x69\x01\uffff"+
        "\x01\x65\x01\x6b\x01\x6c\x01\x5f\x01\x70\x01\uffff\x01\x72\x01\x30"+
        "\x01\x69\x01\x65\x01\x62\x01\x6f\x01\x30\x01\uffff\x01\x6e\x01\x30"+
        "\x01\x75\x01\x73\x01\uffff\x01\x64\x01\x74\x01\uffff\x01\x66\x01"+
        "\x74\x01\x30\x01\x68\x02\x66\x01\uffff\x01\x72\x01\x65\x01\x69\x01"+
        "\x65\x01\x72\x01\x78\x01\x61\x02\x30\x01\x64\x02\uffff\x01\x5f\x01"+
        "\x73\x01\x61\x01\x66\x01\x65\x01\x30\x01\uffff";
    const string DFA22_maxS =
        "\x01\x7d\x01\x72\x01\x6c\x01\uffff\x01\x3c\x01\x3e\x02\uffff\x01"+
        "\x39\x06\uffff\x01\x6e\x01\x75\x01\x6f\x01\x75\x07\uffff\x01\x2f"+
        "\x01\uffff\x02\x65\x03\uffff\x01\x75\x02\x6c\x01\x6f\x06\uffff\x01"+
        "\x63\x01\x74\x01\x66\x01\x75\x01\x61\x01\x6e\x01\x6b\x04\uffff\x02"+
        "\x65\x01\x73\x01\x65\x01\x61\x01\x6c\x01\x70\x01\x69\x01\x62\x01"+
        "\x6c\x01\x74\x01\x5f\x01\x7a\x01\x65\x01\x73\x01\x74\x02\x75\x01"+
        "\x6e\x01\x6c\x01\x5f\x01\x69\x01\x73\x01\uffff\x02\x7a\x01\x61\x01"+
        "\x7a\x01\x64\x01\x74\x02\x65\x01\x74\x01\x6d\x01\x69\x01\x75\x02"+
        "\uffff\x01\x6d\x01\uffff\x01\x65\x01\x5f\x01\x73\x01\x7a\x01\x79"+
        "\x01\x65\x01\x6d\x01\x61\x01\x65\x01\x73\x01\x64\x01\x7a\x01\uffff"+
        "\x01\x70\x01\x5f\x01\x70\x01\x6c\x01\x5f\x01\x7a\x01\x69\x01\uffff"+
        "\x01\x65\x01\x6b\x01\x6c\x01\x5f\x01\x70\x01\uffff\x01\x72\x01\x7a"+
        "\x01\x69\x01\x65\x01\x62\x01\x6f\x01\x7a\x01\uffff\x01\x6e\x01\x7a"+
        "\x01\x75\x01\x73\x01\uffff\x01\x64\x01\x74\x01\uffff\x01\x66\x01"+
        "\x74\x01\x7a\x01\x68\x02\x66\x01\uffff\x01\x72\x01\x65\x01\x69\x01"+
        "\x65\x01\x72\x01\x78\x01\x61\x02\x7a\x01\x64\x02\uffff\x01\x5f\x01"+
        "\x73\x01\x61\x01\x66\x01\x65\x01\x7a\x01\uffff";
    const string DFA22_acceptS =
        "\x03\uffff\x01\x03\x02\uffff\x01\x06\x01\x07\x01\uffff\x01\x09"+
        "\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x01\x0e\x04\uffff\x01\x1b\x01\x1c"+
        "\x01\x1d\x01\x1e\x01\x1f\x01\x20\x01\x21\x01\uffff\x01\x23\x02\uffff"+
        "\x01\x27\x01\x29\x01\x2a\x04\uffff\x01\x19\x01\x04\x01\x1a\x01\x05"+
        "\x01\x28\x01\x08\x07\uffff\x01\x2b\x01\x2c\x01\x22\x01\x26\x17\uffff"+
        "\x01\x01\x0c\uffff\x01\x02\x01\x0f\x01\uffff\x01\x24\x0c\uffff\x01"+
        "\x25\x07\uffff\x01\x12\x05\uffff\x01\x10\x07\uffff\x01\x13\x04\uffff"+
        "\x01\x11\x02\uffff\x01\x16\x06\uffff\x01\x15\x0a\uffff\x01\x18\x01"+
        "\x14\x06\uffff\x01\x17";
    const string DFA22_specialS =
        "\u00a3\uffff}>";
    static readonly string[] DFA22_transitionS = {
            "\x02\x20\x02\uffff\x01\x20\x12\uffff\x01\x20\x01\x15\x01\x1e"+
            "\x02\uffff\x01\x1b\x01\x13\x01\uffff\x01\x06\x01\x07\x01\x19"+
            "\x01\x18\x01\x09\x01\x17\x01\x08\x01\x1a\x01\x1c\x09\x1d\x01"+
            "\x0a\x01\x03\x01\x04\x01\x16\x01\x05\x02\uffff\x1a\x1f\x01\x0d"+
            "\x01\uffff\x01\x0e\x01\uffff\x01\x1f\x01\uffff\x03\x1f\x01\x11"+
            "\x01\x1f\x01\x02\x02\x1f\x01\x0f\x05\x1f\x01\x10\x02\x1f\x01"+
            "\x12\x01\x1f\x01\x01\x06\x1f\x01\x0b\x01\x14\x01\x0c",
            "\x01\x21",
            "\x01\x22\x07\uffff\x01\x23\x02\uffff\x01\x24",
            "",
            "\x01\x25",
            "\x01\x27",
            "",
            "",
            "\x0a\x29",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\x2b",
            "\x01\x2c",
            "\x01\x2d\x09\uffff\x01\x2e",
            "\x01\x2f\x0e\uffff\x01\x31\x01\x30",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\x32\x04\uffff\x01\x33",
            "",
            "\x01\x29\x01\uffff\x0a\x36\x0b\uffff\x01\x29\x1f\uffff\x01"+
            "\x29",
            "\x01\x29\x01\uffff\x0a\x36\x0b\uffff\x01\x29\x1f\uffff\x01"+
            "\x29",
            "",
            "",
            "",
            "\x01\x37",
            "\x01\x38",
            "\x01\x39",
            "\x01\x3a",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\x3b",
            "\x01\x3c",
            "\x01\x3d",
            "\x01\x3e",
            "\x01\x3f",
            "\x01\x40",
            "\x01\x41",
            "",
            "",
            "",
            "",
            "\x01\x29\x01\uffff\x0a\x36\x0b\uffff\x01\x29\x1f\uffff\x01"+
            "\x29",
            "\x01\x42",
            "\x01\x43",
            "\x01\x44",
            "\x01\x45",
            "\x01\x46",
            "\x01\x47",
            "\x01\x48",
            "\x01\x49",
            "\x01\x4a",
            "\x01\x4b",
            "\x01\x4c",
            "\x0a\x1f\x07\uffff\x1a\x1f\x04\uffff\x01\x1f\x01\uffff\x1a"+
            "\x1f",
            "\x01\x4e",
            "\x01\x50\x04\uffff\x01\x4f",
            "\x01\x51",
            "\x01\x52",
            "\x01\x53",
            "\x01\x54",
            "\x01\x55",
            "\x01\x56",
            "\x01\x57",
            "\x01\x59\x0e\uffff\x01\x58",
            "",
            "\x0a\x1f\x07\uffff\x1a\x1f\x04\uffff\x01\x1f\x01\uffff\x1a"+
            "\x1f",
            "\x0a\x1f\x07\uffff\x1a\x1f\x04\uffff\x01\x1f\x01\uffff\x1a"+
            "\x1f",
            "\x01\x5c",
            "\x0a\x1f\x07\uffff\x1a\x1f\x04\uffff\x01\x1f\x01\uffff\x1a"+
            "\x1f",
            "\x01\x5e",
            "\x01\x5f",
            "\x01\x60",
            "\x01\x61",
            "\x01\x62",
            "\x01\x63",
            "\x01\x64",
            "\x01\x65",
            "",
            "",
            "\x01\x66",
            "",
            "\x01\x67",
            "\x01\x68",
            "\x01\x69",
            "\x0a\x1f\x07\uffff\x1a\x1f\x04\uffff\x01\x1f\x01\uffff\x1a"+
            "\x1f",
            "\x01\x6b",
            "\x01\x6c",
            "\x01\x6d",
            "\x01\x6e",
            "\x01\x6f",
            "\x01\x70",
            "\x01\x71",
            "\x0a\x1f\x07\uffff\x1a\x1f\x04\uffff\x01\x1f\x01\uffff\x1a"+
            "\x1f",
            "",
            "\x01\x73",
            "\x01\x74",
            "\x01\x75",
            "\x01\x76",
            "\x01\x77",
            "\x0a\x1f\x07\uffff\x1a\x1f\x04\uffff\x01\x1f\x01\uffff\x1a"+
            "\x1f",
            "\x01\x79",
            "",
            "\x01\x7a",
            "\x01\x7b",
            "\x01\x7c",
            "\x01\x7d",
            "\x01\x7e",
            "",
            "\x01\x7f",
            "\x0a\x1f\x07\uffff\x1a\x1f\x04\uffff\x01\x1f\x01\uffff\x1a"+
            "\x1f",
            "\x01\u0081",
            "\x01\u0082",
            "\x01\u0083",
            "\x01\u0084",
            "\x0a\x1f\x07\uffff\x1a\x1f\x04\uffff\x01\x1f\x01\uffff\x1a"+
            "\x1f",
            "",
            "\x01\u0086",
            "\x0a\x1f\x07\uffff\x1a\x1f\x04\uffff\x01\u0087\x01\uffff\x1a"+
            "\x1f",
            "\x01\u0089",
            "\x01\u008a",
            "",
            "\x01\u008b",
            "\x01\u008c",
            "",
            "\x01\u008d",
            "\x01\u008e",
            "\x0a\x1f\x07\uffff\x1a\x1f\x04\uffff\x01\x1f\x01\uffff\x1a"+
            "\x1f",
            "\x01\u0090",
            "\x01\u0091",
            "\x01\u0092",
            "",
            "\x01\u0093",
            "\x01\u0094",
            "\x01\u0095",
            "\x01\u0096",
            "\x01\u0097",
            "\x01\u0098",
            "\x01\u0099",
            "\x0a\x1f\x07\uffff\x1a\x1f\x04\uffff\x01\x1f\x01\uffff\x1a"+
            "\x1f",
            "\x0a\x1f\x07\uffff\x1a\x1f\x04\uffff\x01\x1f\x01\uffff\x1a"+
            "\x1f",
            "\x01\u009c",
            "",
            "",
            "\x01\u009d",
            "\x01\u009e",
            "\x01\u009f",
            "\x01\u00a0",
            "\x01\u00a1",
            "\x0a\x1f\x07\uffff\x1a\x1f\x04\uffff\x01\x1f\x01\uffff\x1a"+
            "\x1f",
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
            get { return "1:1: Tokens : ( TRUE | FALSE | SEMICOLON | LEFT_ANGLE | RIGHT_ANGLE | LEFT_PAREN | RIGHT_PAREN | DOT | COMMA | COLON | LEFT_BRACE | RIGHT_BRACE | LEFT_BRACKET | RIGHT_BRACKET | FILES | INCLUDES | OUTPUTDIR | DEFINES | REALTYPE | FILENAMEPOSTFIX | RUNTIME_KIND | RTK_SIMPLE | RTK_SIMPLE_THREAD_SAFE | RTK_DUAL_BUFFER | LEFT_OP | RIGHT_OP | AND_OP | OR_OP | BANG | EQUAL | DASH | PLUS | STAR | SLASH | PERCENT | FLOAT | DOUBLE | INTCONSTANT | STRING_LITERAL | FLOATCONSTANT | IDENTIFIER | WS | COMMENT | LINE_COMMENT );"; }
        }

    }

 
    
}
