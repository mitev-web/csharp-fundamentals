using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.PHPVariables
{
    class PHPVariables
    {
        public enum State {Nothing, Variable, RightBackslash, StringSingleQuote,
            StringDoubleQuote ,CommentLine, CommentStar};
        static void Main(string[] args)
        {
           /* string phpCode = @"<?php
    $browser = $_SERVER['HTTP_USER_AGENT']  ;
    $arr=   array();
    $arr[$zero] =$browser;
      var_dump($arr);
?>";*/
          //  string phpCode = "<?php\n/* This is $var1 in comments */\n$var3 = \"SomeString \\$var4 with var escaped.\";\necho $var5; echo(\"$foo,$bar\");\n// Another comment with variable $var2\n?>";
          //string phpCode = "<?php\n# this is $comment\n$valid_var='\"text\"...{$valid_var}';\n$just=\"Just another var $Just...\";$just=$code;\n?>";
            
            StringBuilder phpCodeTemp = new StringBuilder();

            for (; ; )
            {
                string line = Console.ReadLine();
                phpCodeTemp.Append(line);
                phpCodeTemp.Append('\n');
                if (line == "?>")
                {
                    break;
                }
            }

            string phpCode = phpCodeTemp.ToString();
            
            State state = State.Nothing;
            State oldState = state;
            string[] variables = new string[10000];
            int countVariables = 0;
            char oldChar = ' ';
            char oldestChar = ' ';
            StringBuilder currentVariable = new StringBuilder();

            for (int i = 0; i < phpCode.Length; i++)
            {
                char currentChar = phpCode[i];
                
                switch (state)
                {
                    case State.Nothing:
                        switch (currentChar)
	                    {
                            case '$':
                                state = State.Variable;
                                break;
                            case '/':
                                state = State.RightBackslash;
                                break;
                            case '\'':
                                state = State.StringSingleQuote;
                                break;
                            case '\"':
                                state = State.StringDoubleQuote;
                                break;
                            case '#':
                                state = State.CommentLine;
                                break;
                            default:
                                state = State.Nothing;
                                break;
	                    }
                        break;
                    case State.Variable:
                        if (currentChar == '_' || Char.IsLetterOrDigit(currentChar))
	                    {
		                    state = State.Variable;
                            currentVariable = currentVariable.Append(currentChar);
	                    }
                        else if (currentChar == '/')
                        {
                            state = State.RightBackslash;
                            variables = WriteToArray(variables, currentVariable.ToString());
                            currentVariable.Clear();
                        }
                        else if(currentChar == '#')
                        {
                            state = State.CommentLine;
                            variables = WriteToArray(variables, currentVariable.ToString());
                            currentVariable.Clear();
                        }
                        else
                        {
                            state = oldState;
                            if ( (currentChar == '\"' && oldState==State.StringDoubleQuote)
                                || (currentChar=='\'' && oldState == State.StringSingleQuote))
                            {
                                state = State.Nothing;
                            }
                            variables = WriteToArray(variables, currentVariable.ToString());
                            currentVariable.Clear();
                        }
                        break;
                    case State.RightBackslash:
                        switch (currentChar)
                    	{
                            case '$':
                                state = State.Variable;
                                
                                break;
                            case '/':
                                state = State.CommentLine;
                                break;
                            case '#':
                                state = State.CommentLine;
                                break;
                            case '*':
                                state = State.CommentStar;
                                break;
                            default:
                                state = State.Nothing;
                                break;
	                    }
                        break;
                    case State.CommentLine:
                        if (currentChar == '\n')
                        {
                            state = State.Nothing;
                        }
                        if (currentChar == '$')
                        {
                            state = State.CommentLine;
                        }
                        break;
                    default:
                        state = State.CommentLine;
                        break;
                    case State.CommentStar:
                        if (currentChar == '/' && oldChar == '*')
                        {
                            state = State.Nothing;
                        }
                        break;
                    case State.StringSingleQuote:
                        if (currentChar == '\'' && (oldChar != '\\' || oldestChar == '\\') )
	                    {
		                    state = State.Nothing;     
	                    }
                        else if(currentChar == '$' && (oldChar != '\\' || oldestChar == '\\'))
	                    {
                            state = State.Variable;
	                    }
                        break;
                    case State.StringDoubleQuote:
                        if (currentChar == '\"' && (oldChar != '\\' || oldestChar == '\\') )
	                    {
		                    state = State.Nothing;     
	                    }
                        else if(currentChar == '$' && (oldChar != '\\' || oldestChar == '\\'))
	                    {
                            state = State.Variable;
	                    }
                        break;
                }

                

                //Console.WriteLine("{0} {1}", currentChar, state);

                if (i != 0)
                {
                    oldestChar = oldChar;
                }

                oldChar = currentChar;
                if (state != State.Variable)
                {
                    oldState = state;
                }
                
            }

            for (int i = 0; i < variables.Length; i++)
            {
                if (variables[i]==null)
                {
                    break;
                }
                countVariables++;
            }

            string[] variablesFinal = new string[countVariables];

            Array.Copy(variables, variablesFinal, countVariables);

            Console.WriteLine(countVariables);

            Array.Sort(variablesFinal, StringComparer.Ordinal);

            for (int i = 0; i < variablesFinal.Length; i++)
            {
                Console.WriteLine(variablesFinal[i]);
            }
        }

        public static string[] WriteToArray(string[] variables, string currentVariable)
        {
            int flag = 0;
            for (int i = 0; i < variables.Length; i++)
            {
                if (String.Compare(variables[i], currentVariable) == 0)
                {
                    flag = 1;
                }
                if (flag != 1 && variables[i] == null)
                {
                    variables[i]=currentVariable;
                    return variables;
                }
            }
            return variables;
        }
    }
}
