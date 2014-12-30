// $ANTLR 3.2 Sep 23, 2009 12:02:23 E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g 2013-07-03 17:53:23

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


	using Thor.DataForge;
	using System.Collections.Generic;
	using System.IO;


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;

using IDictionary	= System.Collections.IDictionary;
using Hashtable 	= System.Collections.Hashtable;
public partial class DataForgeProjectParser : Parser
{
    public static readonly string[] tokenNames = new string[] 
	{
        "<invalid>", 
		"<EOR>", 
		"<DOWN>", 
		"<UP>", 
		"TRUE", 
		"FALSE", 
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
		"FILES", 
		"INCLUDES", 
		"OUTPUTDIR", 
		"DEFINES", 
		"REALTYPE", 
		"FILENAMEPOSTFIX", 
		"RUNTIME_KIND", 
		"RTK_SIMPLE", 
		"RTK_SIMPLE_THREAD_SAFE", 
		"RTK_DUAL_BUFFER", 
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
		"FLOAT", 
		"DOUBLE", 
		"LETTER", 
		"DIGIT", 
		"HEX", 
		"EXPONENT", 
		"FLOATSUFFIX", 
		"INTCONSTANT", 
		"EscapeSequence", 
		"STRING_LITERAL", 
		"FLOATCONSTANT", 
		"IDENTIFIER", 
		"WS", 
		"COMMENT", 
		"LINE_COMMENT"
    };

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
    public const int STRING_LITERAL = 48;
    public const int SLASH = 37;
    public const int HEX = 43;
    public const int COMMA = 12;
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
    public const int WS = 51;
    public const int INTCONSTANT = 46;
    public const int FLOATCONSTANT = 49;
    public const int LEFT_BRACE = 14;
    public const int LEFT_PAREN = 9;
    public const int RTK_SIMPLE_THREAD_SAFE = 26;
    public const int LEFT_OP = 28;
    public const int LEFT_ANGLE = 7;
    public const int RIGHT_ANGLE = 8;
    public const int FALSE = 5;
    public const int EscapeSequence = 47;

    // delegates
    // delegators



        public DataForgeProjectParser(ITokenStream input)
    		: this(input, new RecognizerSharedState()) {
        }

        public DataForgeProjectParser(ITokenStream input, RecognizerSharedState state)
    		: base(input, state) {
            InitializeCyclicDFAs();
            this.state.ruleMemo = new Hashtable[24+1];
             
             
        }
        

    override public string[] TokenNames {
		get { return DataForgeProjectParser.tokenNames; }
    }

    override public string GrammarFileName {
		get { return "E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g"; }
    }


    	public ProjectOptions data;	



    // $ANTLR start "string_list"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:132:1: string_list returns [List<string> strings] : str1= STRING_LITERAL ( COMMA str2= STRING_LITERAL )* ;
    public List<string> string_list() // throws RecognitionException [1]
    {   
        List<string> strings = default(List<string>);
        int string_list_StartIndex = input.Index();
        IToken str1 = null;
        IToken str2 = null;

        strings = new List<string>();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 1) ) 
    	    {
    	    	return strings; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:134:2: (str1= STRING_LITERAL ( COMMA str2= STRING_LITERAL )* )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:134:4: str1= STRING_LITERAL ( COMMA str2= STRING_LITERAL )*
            {
            	str1=(IToken)Match(input,STRING_LITERAL,FOLLOW_STRING_LITERAL_in_string_list705); if (state.failed) return strings;
            	if ( (state.backtracking==0) )
            	{
            	  strings.Add( Utilities.TrimQuotes( ((str1 != null) ? str1.Text : null) ) );
            	}
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:135:3: ( COMMA str2= STRING_LITERAL )*
            	do 
            	{
            	    int alt1 = 2;
            	    int LA1_0 = input.LA(1);

            	    if ( (LA1_0 == COMMA) )
            	    {
            	        alt1 = 1;
            	    }


            	    switch (alt1) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:135:4: COMMA str2= STRING_LITERAL
            			    {
            			    	Match(input,COMMA,FOLLOW_COMMA_in_string_list713); if (state.failed) return strings;
            			    	str2=(IToken)Match(input,STRING_LITERAL,FOLLOW_STRING_LITERAL_in_string_list717); if (state.failed) return strings;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	  strings.Add( Utilities.TrimQuotes( ((str2 != null) ? str2.Text : null) ) );
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop1;
            	    }
            	} while (true);

            	loop1:
            		;	// Stops C# compiler whining that label 'loop1' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 1, string_list_StartIndex); 
            }
        }
        return strings;
    }
    // $ANTLR end "string_list"


    // $ANTLR start "files_option"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:138:1: files_option : FILES EQUAL sl= string_list ;
    public void files_option() // throws RecognitionException [1]
    {   
        int files_option_StartIndex = input.Index();
        List<string> sl = default(List<string>);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 2) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:139:2: ( FILES EQUAL sl= string_list )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:139:4: FILES EQUAL sl= string_list
            {
            	Match(input,FILES,FOLLOW_FILES_in_files_option734); if (state.failed) return ;
            	Match(input,EQUAL,FOLLOW_EQUAL_in_files_option736); if (state.failed) return ;
            	PushFollow(FOLLOW_string_list_in_files_option740);
            	sl = string_list();
            	state.followingStackPointer--;
            	if (state.failed) return ;
            	if ( (state.backtracking==0) )
            	{

            	  			foreach(var s in sl)
            	  			{
            	  				data.Files.Add(s);
            	  			}
            	  		
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 2, files_option_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "files_option"


    // $ANTLR start "includes_option"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:148:1: includes_option : INCLUDES EQUAL sl= string_list ;
    public void includes_option() // throws RecognitionException [1]
    {   
        int includes_option_StartIndex = input.Index();
        List<string> sl = default(List<string>);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 3) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:149:2: ( INCLUDES EQUAL sl= string_list )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:149:4: INCLUDES EQUAL sl= string_list
            {
            	Match(input,INCLUDES,FOLLOW_INCLUDES_in_includes_option757); if (state.failed) return ;
            	Match(input,EQUAL,FOLLOW_EQUAL_in_includes_option759); if (state.failed) return ;
            	PushFollow(FOLLOW_string_list_in_includes_option763);
            	sl = string_list();
            	state.followingStackPointer--;
            	if (state.failed) return ;
            	if ( (state.backtracking==0) )
            	{

            	  			foreach(var s in sl)
            	  			{
            	  				data.Includes.Add(Path.GetFullPath(s));
            	  			}
            	  		
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 3, includes_option_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "includes_option"


    // $ANTLR start "output_dir_option"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:158:1: output_dir_option : OUTPUTDIR EQUAL dir= STRING_LITERAL ;
    public void output_dir_option() // throws RecognitionException [1]
    {   
        int output_dir_option_StartIndex = input.Index();
        IToken dir = null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 4) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:159:2: ( OUTPUTDIR EQUAL dir= STRING_LITERAL )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:159:4: OUTPUTDIR EQUAL dir= STRING_LITERAL
            {
            	Match(input,OUTPUTDIR,FOLLOW_OUTPUTDIR_in_output_dir_option779); if (state.failed) return ;
            	Match(input,EQUAL,FOLLOW_EQUAL_in_output_dir_option781); if (state.failed) return ;
            	dir=(IToken)Match(input,STRING_LITERAL,FOLLOW_STRING_LITERAL_in_output_dir_option785); if (state.failed) return ;
            	if ( (state.backtracking==0) )
            	{
            	  data.OutputDir = Utilities.TrimQuotes(((dir != null) ? dir.Text : null));
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 4, output_dir_option_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "output_dir_option"


    // $ANTLR start "identifier_list"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:162:1: identifier_list returns [List<string> strings] : str1= IDENTIFIER ( COMMA str2= IDENTIFIER )* ;
    public List<string> identifier_list() // throws RecognitionException [1]
    {   
        List<string> strings = default(List<string>);
        int identifier_list_StartIndex = input.Index();
        IToken str1 = null;
        IToken str2 = null;

        strings = new List<string>();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 5) ) 
    	    {
    	    	return strings; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:164:2: (str1= IDENTIFIER ( COMMA str2= IDENTIFIER )* )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:164:5: str1= IDENTIFIER ( COMMA str2= IDENTIFIER )*
            {
            	str1=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_identifier_list809); if (state.failed) return strings;
            	if ( (state.backtracking==0) )
            	{
            	  strings.Add(((str1 != null) ? str1.Text : null));
            	}
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:165:3: ( COMMA str2= IDENTIFIER )*
            	do 
            	{
            	    int alt2 = 2;
            	    int LA2_0 = input.LA(1);

            	    if ( (LA2_0 == COMMA) )
            	    {
            	        alt2 = 1;
            	    }


            	    switch (alt2) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:165:4: COMMA str2= IDENTIFIER
            			    {
            			    	Match(input,COMMA,FOLLOW_COMMA_in_identifier_list816); if (state.failed) return strings;
            			    	str2=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_identifier_list820); if (state.failed) return strings;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	  strings.Add(((str2 != null) ? str2.Text : null));
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop2;
            	    }
            	} while (true);

            	loop2:
            		;	// Stops C# compiler whining that label 'loop2' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 5, identifier_list_StartIndex); 
            }
        }
        return strings;
    }
    // $ANTLR end "identifier_list"


    // $ANTLR start "defines_option"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:168:1: defines_option : DEFINES EQUAL il= identifier_list ;
    public void defines_option() // throws RecognitionException [1]
    {   
        int defines_option_StartIndex = input.Index();
        List<string> il = default(List<string>);


        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 6) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:169:2: ( DEFINES EQUAL il= identifier_list )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:169:4: DEFINES EQUAL il= identifier_list
            {
            	Match(input,DEFINES,FOLLOW_DEFINES_in_defines_option837); if (state.failed) return ;
            	Match(input,EQUAL,FOLLOW_EQUAL_in_defines_option839); if (state.failed) return ;
            	PushFollow(FOLLOW_identifier_list_in_defines_option843);
            	il = identifier_list();
            	state.followingStackPointer--;
            	if (state.failed) return ;
            	if ( (state.backtracking==0) )
            	{

            	  			foreach(var s in il)
            	  			{
            	  				data.Defines.Add(s);
            	  			}
            	  		
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 6, defines_option_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "defines_option"


    // $ANTLR start "real_type_option"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:178:1: real_type_option : REALTYPE EQUAL (f= FLOAT | DOUBLE ) ;
    public void real_type_option() // throws RecognitionException [1]
    {   
        int real_type_option_StartIndex = input.Index();
        IToken f = null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 7) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:179:2: ( REALTYPE EQUAL (f= FLOAT | DOUBLE ) )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:179:4: REALTYPE EQUAL (f= FLOAT | DOUBLE )
            {
            	Match(input,REALTYPE,FOLLOW_REALTYPE_in_real_type_option859); if (state.failed) return ;
            	Match(input,EQUAL,FOLLOW_EQUAL_in_real_type_option861); if (state.failed) return ;
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:179:19: (f= FLOAT | DOUBLE )
            	int alt3 = 2;
            	int LA3_0 = input.LA(1);

            	if ( (LA3_0 == FLOAT) )
            	{
            	    alt3 = 1;
            	}
            	else if ( (LA3_0 == DOUBLE) )
            	{
            	    alt3 = 2;
            	}
            	else 
            	{
            	    if ( state.backtracking > 0 ) {state.failed = true; return ;}
            	    NoViableAltException nvae_d3s0 =
            	        new NoViableAltException("", 3, 0, input);

            	    throw nvae_d3s0;
            	}
            	switch (alt3) 
            	{
            	    case 1 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:179:20: f= FLOAT
            	        {
            	        	f=(IToken)Match(input,FLOAT,FOLLOW_FLOAT_in_real_type_option866); if (state.failed) return ;

            	        }
            	        break;
            	    case 2 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:179:28: DOUBLE
            	        {
            	        	Match(input,DOUBLE,FOLLOW_DOUBLE_in_real_type_option868); if (state.failed) return ;

            	        }
            	        break;

            	}

            	if ( (state.backtracking==0) )
            	{

            	  			if(f!=null)
            	  				data.RealType=eRealType.Float;
            	  			else
            	  				data.RealType=eRealType.Double;
            	  		
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 7, real_type_option_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "real_type_option"


    // $ANTLR start "filename_postfix_option"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:188:1: filename_postfix_option : FILENAMEPOSTFIX EQUAL p= STRING_LITERAL ;
    public void filename_postfix_option() // throws RecognitionException [1]
    {   
        int filename_postfix_option_StartIndex = input.Index();
        IToken p = null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 8) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:189:2: ( FILENAMEPOSTFIX EQUAL p= STRING_LITERAL )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:189:4: FILENAMEPOSTFIX EQUAL p= STRING_LITERAL
            {
            	Match(input,FILENAMEPOSTFIX,FOLLOW_FILENAMEPOSTFIX_in_filename_postfix_option885); if (state.failed) return ;
            	Match(input,EQUAL,FOLLOW_EQUAL_in_filename_postfix_option887); if (state.failed) return ;
            	p=(IToken)Match(input,STRING_LITERAL,FOLLOW_STRING_LITERAL_in_filename_postfix_option891); if (state.failed) return ;
            	if ( (state.backtracking==0) )
            	{

            	  			data.FilenamePostfix = Utilities.TrimQuotes(((p != null) ? p.Text : null));
            	  		
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 8, filename_postfix_option_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "filename_postfix_option"


    // $ANTLR start "runtime_kind_option"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:195:1: runtime_kind_option : t= RUNTIME_KIND EQUAL (s= RTK_SIMPLE | ts= RTK_SIMPLE_THREAD_SAFE | db= RTK_DUAL_BUFFER ) ;
    public void runtime_kind_option() // throws RecognitionException [1]
    {   
        int runtime_kind_option_StartIndex = input.Index();
        IToken t = null;
        IToken s = null;
        IToken ts = null;
        IToken db = null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 9) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:196:2: (t= RUNTIME_KIND EQUAL (s= RTK_SIMPLE | ts= RTK_SIMPLE_THREAD_SAFE | db= RTK_DUAL_BUFFER ) )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:196:4: t= RUNTIME_KIND EQUAL (s= RTK_SIMPLE | ts= RTK_SIMPLE_THREAD_SAFE | db= RTK_DUAL_BUFFER )
            {
            	t=(IToken)Match(input,RUNTIME_KIND,FOLLOW_RUNTIME_KIND_in_runtime_kind_option909); if (state.failed) return ;
            	Match(input,EQUAL,FOLLOW_EQUAL_in_runtime_kind_option911); if (state.failed) return ;
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:196:25: (s= RTK_SIMPLE | ts= RTK_SIMPLE_THREAD_SAFE | db= RTK_DUAL_BUFFER )
            	int alt4 = 3;
            	switch ( input.LA(1) ) 
            	{
            	case RTK_SIMPLE:
            		{
            	    alt4 = 1;
            	    }
            	    break;
            	case RTK_SIMPLE_THREAD_SAFE:
            		{
            	    alt4 = 2;
            	    }
            	    break;
            	case RTK_DUAL_BUFFER:
            		{
            	    alt4 = 3;
            	    }
            	    break;
            		default:
            		    if ( state.backtracking > 0 ) {state.failed = true; return ;}
            		    NoViableAltException nvae_d4s0 =
            		        new NoViableAltException("", 4, 0, input);

            		    throw nvae_d4s0;
            	}

            	switch (alt4) 
            	{
            	    case 1 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:196:26: s= RTK_SIMPLE
            	        {
            	        	s=(IToken)Match(input,RTK_SIMPLE,FOLLOW_RTK_SIMPLE_in_runtime_kind_option916); if (state.failed) return ;

            	        }
            	        break;
            	    case 2 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:196:41: ts= RTK_SIMPLE_THREAD_SAFE
            	        {
            	        	ts=(IToken)Match(input,RTK_SIMPLE_THREAD_SAFE,FOLLOW_RTK_SIMPLE_THREAD_SAFE_in_runtime_kind_option922); if (state.failed) return ;

            	        }
            	        break;
            	    case 3 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:196:69: db= RTK_DUAL_BUFFER
            	        {
            	        	db=(IToken)Match(input,RTK_DUAL_BUFFER,FOLLOW_RTK_DUAL_BUFFER_in_runtime_kind_option928); if (state.failed) return ;

            	        }
            	        break;

            	}

            	if ( (state.backtracking==0) )
            	{
            	  			
            	  			if (s != null)
            	  				data.RuntimeKind = eRuntimeKind.Simple;
            	  			else if (ts != null)
            	  				data.RuntimeKind = eRuntimeKind.SimpleThreadSafe;
            	  			else
            	  				data.RuntimeKind = eRuntimeKind.DualBuffer;
            	  		
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 9, runtime_kind_option_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "runtime_kind_option"


    // $ANTLR start "option"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:207:1: option : ( files_option | includes_option | output_dir_option | defines_option | runtime_kind_option | filename_postfix_option | real_type_option ) SEMICOLON ;
    public void option() // throws RecognitionException [1]
    {   
        int option_StartIndex = input.Index();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 10) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:208:2: ( ( files_option | includes_option | output_dir_option | defines_option | runtime_kind_option | filename_postfix_option | real_type_option ) SEMICOLON )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:208:3: ( files_option | includes_option | output_dir_option | defines_option | runtime_kind_option | filename_postfix_option | real_type_option ) SEMICOLON
            {
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:208:3: ( files_option | includes_option | output_dir_option | defines_option | runtime_kind_option | filename_postfix_option | real_type_option )
            	int alt5 = 7;
            	switch ( input.LA(1) ) 
            	{
            	case FILES:
            		{
            	    alt5 = 1;
            	    }
            	    break;
            	case INCLUDES:
            		{
            	    alt5 = 2;
            	    }
            	    break;
            	case OUTPUTDIR:
            		{
            	    alt5 = 3;
            	    }
            	    break;
            	case DEFINES:
            		{
            	    alt5 = 4;
            	    }
            	    break;
            	case RUNTIME_KIND:
            		{
            	    alt5 = 5;
            	    }
            	    break;
            	case FILENAMEPOSTFIX:
            		{
            	    alt5 = 6;
            	    }
            	    break;
            	case REALTYPE:
            		{
            	    alt5 = 7;
            	    }
            	    break;
            		default:
            		    if ( state.backtracking > 0 ) {state.failed = true; return ;}
            		    NoViableAltException nvae_d5s0 =
            		        new NoViableAltException("", 5, 0, input);

            		    throw nvae_d5s0;
            	}

            	switch (alt5) 
            	{
            	    case 1 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:208:5: files_option
            	        {
            	        	PushFollow(FOLLOW_files_option_in_option947);
            	        	files_option();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return ;

            	        }
            	        break;
            	    case 2 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:209:4: includes_option
            	        {
            	        	PushFollow(FOLLOW_includes_option_in_option952);
            	        	includes_option();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return ;

            	        }
            	        break;
            	    case 3 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:210:4: output_dir_option
            	        {
            	        	PushFollow(FOLLOW_output_dir_option_in_option957);
            	        	output_dir_option();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return ;

            	        }
            	        break;
            	    case 4 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:211:4: defines_option
            	        {
            	        	PushFollow(FOLLOW_defines_option_in_option962);
            	        	defines_option();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return ;

            	        }
            	        break;
            	    case 5 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:212:4: runtime_kind_option
            	        {
            	        	PushFollow(FOLLOW_runtime_kind_option_in_option967);
            	        	runtime_kind_option();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return ;

            	        }
            	        break;
            	    case 6 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:213:4: filename_postfix_option
            	        {
            	        	PushFollow(FOLLOW_filename_postfix_option_in_option972);
            	        	filename_postfix_option();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return ;

            	        }
            	        break;
            	    case 7 :
            	        // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:214:4: real_type_option
            	        {
            	        	PushFollow(FOLLOW_real_type_option_in_option977);
            	        	real_type_option();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return ;

            	        }
            	        break;

            	}

            	Match(input,SEMICOLON,FOLLOW_SEMICOLON_in_option981); if (state.failed) return ;

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 10, option_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "option"


    // $ANTLR start "option_list"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:218:1: option_list : ( option )* ;
    public void option_list() // throws RecognitionException [1]
    {   
        int option_list_StartIndex = input.Index();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 11) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:219:2: ( ( option )* )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:219:4: ( option )*
            {
            	// E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:219:4: ( option )*
            	do 
            	{
            	    int alt6 = 2;
            	    int LA6_0 = input.LA(1);

            	    if ( ((LA6_0 >= FILES && LA6_0 <= RUNTIME_KIND)) )
            	    {
            	        alt6 = 1;
            	    }


            	    switch (alt6) 
            		{
            			case 1 :
            			    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:0:0: option
            			    {
            			    	PushFollow(FOLLOW_option_in_option_list993);
            			    	option();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return ;

            			    }
            			    break;

            			default:
            			    goto loop6;
            	    }
            	} while (true);

            	loop6:
            		;	// Stops C# compiler whining that label 'loop6' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 11, option_list_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "option_list"


    // $ANTLR start "project"
    // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:222:1: project : IDENTIFIER LEFT_BRACE option_list RIGHT_BRACE ;
    public void project() // throws RecognitionException [1]
    {   
        int project_StartIndex = input.Index();
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 12) ) 
    	    {
    	    	return ; 
    	    }
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:223:2: ( IDENTIFIER LEFT_BRACE option_list RIGHT_BRACE )
            // E:\\Programming\\Projects\\Thor\\trunk\\code\\Thor\\DataForge\\DataForgeProject.g:223:4: IDENTIFIER LEFT_BRACE option_list RIGHT_BRACE
            {
            	Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_project1009); if (state.failed) return ;
            	Match(input,LEFT_BRACE,FOLLOW_LEFT_BRACE_in_project1011); if (state.failed) return ;
            	PushFollow(FOLLOW_option_list_in_project1013);
            	option_list();
            	state.followingStackPointer--;
            	if (state.failed) return ;
            	Match(input,RIGHT_BRACE,FOLLOW_RIGHT_BRACE_in_project1015); if (state.failed) return ;

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 12, project_StartIndex); 
            }
        }
        return ;
    }
    // $ANTLR end "project"

    // Delegated rules


	private void InitializeCyclicDFAs()
	{
	}

 

    public static readonly BitSet FOLLOW_STRING_LITERAL_in_string_list705 = new BitSet(new ulong[]{0x0000000000001002UL});
    public static readonly BitSet FOLLOW_COMMA_in_string_list713 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_STRING_LITERAL_in_string_list717 = new BitSet(new ulong[]{0x0000000000001002UL});
    public static readonly BitSet FOLLOW_FILES_in_files_option734 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_EQUAL_in_files_option736 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_string_list_in_files_option740 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_INCLUDES_in_includes_option757 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_EQUAL_in_includes_option759 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_string_list_in_includes_option763 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_OUTPUTDIR_in_output_dir_option779 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_EQUAL_in_output_dir_option781 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_STRING_LITERAL_in_output_dir_option785 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_identifier_list809 = new BitSet(new ulong[]{0x0000000000001002UL});
    public static readonly BitSet FOLLOW_COMMA_in_identifier_list816 = new BitSet(new ulong[]{0x0004000000000000UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_identifier_list820 = new BitSet(new ulong[]{0x0000000000001002UL});
    public static readonly BitSet FOLLOW_DEFINES_in_defines_option837 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_EQUAL_in_defines_option839 = new BitSet(new ulong[]{0x0004000000000000UL});
    public static readonly BitSet FOLLOW_identifier_list_in_defines_option843 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_REALTYPE_in_real_type_option859 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_EQUAL_in_real_type_option861 = new BitSet(new ulong[]{0x0000018000000000UL});
    public static readonly BitSet FOLLOW_FLOAT_in_real_type_option866 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DOUBLE_in_real_type_option868 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FILENAMEPOSTFIX_in_filename_postfix_option885 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_EQUAL_in_filename_postfix_option887 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_STRING_LITERAL_in_filename_postfix_option891 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_RUNTIME_KIND_in_runtime_kind_option909 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_EQUAL_in_runtime_kind_option911 = new BitSet(new ulong[]{0x000000000E000000UL});
    public static readonly BitSet FOLLOW_RTK_SIMPLE_in_runtime_kind_option916 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_RTK_SIMPLE_THREAD_SAFE_in_runtime_kind_option922 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_RTK_DUAL_BUFFER_in_runtime_kind_option928 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_files_option_in_option947 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_includes_option_in_option952 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_output_dir_option_in_option957 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_defines_option_in_option962 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_runtime_kind_option_in_option967 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_filename_postfix_option_in_option972 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_real_type_option_in_option977 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_SEMICOLON_in_option981 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_option_in_option_list993 = new BitSet(new ulong[]{0x0000000001FC0002UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_project1009 = new BitSet(new ulong[]{0x0000000000004000UL});
    public static readonly BitSet FOLLOW_LEFT_BRACE_in_project1011 = new BitSet(new ulong[]{0x0000000001FC0000UL});
    public static readonly BitSet FOLLOW_option_list_in_project1013 = new BitSet(new ulong[]{0x0000000000008000UL});
    public static readonly BitSet FOLLOW_RIGHT_BRACE_in_project1015 = new BitSet(new ulong[]{0x0000000000000002UL});

}
