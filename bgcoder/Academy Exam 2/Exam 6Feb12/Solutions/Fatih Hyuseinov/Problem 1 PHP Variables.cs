using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_PHP
{
    class Program
    {
        static void Main(string[] args)
        {
            string reader = null;
            string text = null;

            do
            {
                reader = Console.ReadLine();
                text = string.Concat(text, reader);
            } while (reader != "?>");


//            string text = @"<?php
//# this is $comment
//$valid_var =' ""text""...{$vvv}';
//$just=""just $Just.."";$just=$code
//?>";

           // string text = @"a""$mimi""";


//            string text = @"<?php
///* $var1 */
//$kar3  = ""some string \ $tvar4""; $skara
//echo $Var5; echo(""$foo,$bar"");
// com $Var2'
//?>";


//            string text = @"<?php
///* bir ""  "" */
//$edno echi(""$pet"")
//// iki
//$dve
//# uc
//$tri
//?>
//";
            int kavichki = 0;
            bool inArray = false;
            bool smallComment = false;
            bool bigComment = false;
            bool enter = false;
            int begin = 0;
            int end = 0;
            string vari = null;
            List<string> variables = new List<string>();
            int comCounter = 0;
            int starcounter = 0;
            bool inString = false;
            bool escaping = false;


            for (int i = 0; i < text.Length; i++)
            {
                vari = null;
                enter = false;

                if (!smallComment && !bigComment && !inString && text[i]=='(')
                {
                    inArray=true;
                    continue;
                }
                else if (inArray && text[i]==')')
	            {
		            inArray=false;
                    continue;
	            }
                else if (!inString && comCounter == 1 && text[i] == '/')
                {
                    smallComment = true;
                    comCounter = 0;
                    //continue;
                }
                else if (!inString && comCounter == 1 && text[i] == '*')
                {
                    bigComment = true;
                    comCounter = 0;
                    //continue;
                }
                else if (!inString && text[i] == '/')
                {
                    comCounter = 1;
                }
                else if (!inString  && text[i] == '#')
                {
                    smallComment = true;
                    comCounter = 0;
                    //continue;
                }


                else if (!inString && text[i] == '\n' && smallComment)
                {
                    smallComment = false;
                    comCounter = 0;
                    //continue;
                }
                else if (!inString && text[i] == '*' && bigComment)
                {
                    starcounter = 1;
                    comCounter = 0;
                }
                else if (!inString && bigComment && starcounter == 1 && text[i] == '/')
                {
                    bigComment = false;
                    comCounter = 0;
                    //continue;
                }
                
                else if (!inArray && (!inString && text[i]=='\''))
                {
                    if (!bigComment && !smallComment)
                    {
                        inString = true;
                        kavichki = 1;
                    }
                }
                else if (!inArray && (!inString &&  text[i]=='"'))
                {
                    inString = true;
                    kavichki = 2;
                }
                else if (inString && text[i]=='$' && text[i-1]!='\\')
                {
                    enter = true;
                    vari = null;
                    begin = i + 1;
                    end = i + 1;
                    for (int j = i + 2; j < text.Length; j++)
                    {
                        if (text[j] != '_' && !char.IsLetter(text[j]) && text[j] != '0' && text[j] != '1' && text[j] != '2' && text[j] != '3' && text[j] != '4' && text[j] != '5' && text[j] != '6' && text[j] != '7' && text[j] != '8' && text[j] != '9')
                        {
                            end = j;
                            break;
                        }
                    }


                }


                else if (text[i]=='$' && !smallComment && !bigComment && !inString)
                {
                    enter = true;
                    vari = null;
                    begin = i+1;
                    end = i + 1;
                    for (int j = i+2; j < text.Length; j++)
                    {
                        if (text[j]!='_' && !char.IsLetter(text[j]) && text[j]!='0' &&text[j]!='1' &&text[j]!='2' &&text[j]!='3' &&text[j]!='4' &&text[j]!='5' &&text[j]!='6' &&text[j]!='7' &&text[j]!='8' &&text[j]!='9')
                        {
                            end=j;
                            break;
                        }
                    }
                }
                else if (!inArray && inString)
                {
                    if (text[i] == '"' && kavichki == 2)
                    {
                        inString = false;

                        continue;

                    }

                    else if (text[i] == '\'' && kavichki == 1)
                    {
                        inString = false;
                        continue;
                    }

                }
                if (enter)
                {
                    vari = null;
                    for (int w = begin; w < end; w++)
                                { vari = string.Concat(vari, text[w]); }

                      variables.Add(vari);
                
                }
                
                
                




            }

            

            for (int i = 0; i < variables.Count; i++)
            {
                for (int j = 0; j < variables.Count; j++)
                {
                    if (i!=j && variables[i]==variables[j])
                    {
                     //   variables[i] = "0";
                        variables.Remove(variables[i]);
                    }
                }
            }
            int counter = 0;
            for (int i = 0; i < variables.Count; i++)
            {
                if (variables[i]!="0")
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
            variables.Sort();
            for (int i = 0; i < variables.Count; i++)
            {
                if (variables[i]!="0")
                {
                    Console.WriteLine(variables[i]);
                }
            }

            


        }
    }
}
