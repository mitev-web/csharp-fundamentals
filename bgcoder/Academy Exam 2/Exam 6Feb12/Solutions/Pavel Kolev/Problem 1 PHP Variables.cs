using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _1___PHP_vars
{
    class Program
    {
        static void Main(string[] args)
        {
           string php = CleanCode();
          // Console.WriteLine(php);
           // string php = @"<?php 
                        //        $browser = $_SERVER['HTTP_USER_AGENT']  ;
                        //        $arr = array();
                        //        $arr[$zero] = $browser
                        //            var_dump($arr);
                        //?>";
            //int numOfLines = php.Where(x => x == '\n').Count();
            //Console.WriteLine(numOfLines + 1);
            //string cleaned = CleanCode(php, numOfLines + 1);
            //Console.WriteLine(cleaned);
           List<string> variables = new List<string>();
           for (int i = 1; i < php.Length; i++)
           {
               int start = php.IndexOf("$", i);
               if(start>=0 && php[start-1]=='\\')
               {
                   i = start;
                   continue;
               }
               int end = start + 1;
               int tempS = start;
               while (true)
               {
                   char ch = php[tempS + 1];
                       if (char.IsLetterOrDigit(ch) || ch == '_')
                       {
                           end++;
                       }
                       else
                       {
                           break;
                       }
                   tempS++;
               }

               if (start >= 0 && end >= 0)
               {
                   string temp = php.Substring(start + 1, end - start-1);
                   if (!variables.Contains(temp))
                   {
                       variables.Add(temp);
                   }
                   i = end;
               }
               else break;
           }
           variables.Sort(StringComparer.Ordinal);
           Console.WriteLine(variables.Count);
           foreach (var variable in variables)
           {
               Console.WriteLine(variable);
           }
        }
        static string CleanCode()
        {
            StringBuilder code = new StringBuilder();
            bool inMultiLineComment = false;
            bool inString = false;
            bool inMultilineString = false;
            bool inSingleQuotedString = false;
            bool canContinue = true;
            string line =  string.Empty;
            do
            {
            Start:
                line = Console.ReadLine();
                 if (line.Length == 0)
                    {
                        goto Start;
                      }
                int k = 0;
                for (int j = 0; j < line.Length; j++)
                {
                    if (inMultilineString)
                    {
                        if (line[j] == '\"' && j + 1 < line.Length && line[j + 1] == '\"')
                        {
                            code.Append("\"\"");
                            j++;
                            continue;
                        }
                    }
                    if (inString)
                    {
                        if (line[j] == '\\' && j + 1 < line.Length && line[j + 1] == '\"')
                        {
                            code.Append("\\\"");
                            j++;
                            continue;
                        }
                        if (line[j] == '\\' && j + 1 < line.Length && line[j + 1] == '\'')
                        {
                            code.Append("\\\'");
                            j++;
                            continue;
                        }
                        if (line[j] == '\"' && !inSingleQuotedString)
                        {
                            inString = false;
                            inMultilineString = false;
                            code.Append('\"');
                            continue;
                        }
                        if (line[j] == '\'' && inSingleQuotedString)
                        {
                            inString = false;
                            inSingleQuotedString = false;
                            code.Append('\'');
                            continue;
                        }
                        code.Append(line[j]);
                        continue;
                    }

                    // Multiline comments
                    if (!inMultiLineComment && j + 1 < line.Length && line[j] == '/' && line[j + 1] == '*')
                    {
                        inMultiLineComment = true;
                        j++;
                        continue;
                    }
                    if (inMultiLineComment && j + 1 < line.Length && line[j] == '*' && line[j + 1] == '/')
                    {
                        inMultiLineComment = false;
                        j++;
                        continue;
                    }
                    if (inMultiLineComment)
                    {
                        continue;
                    }

                    // One line comment
                    if (line[j] == '/' && j + 1 < line.Length && line[j + 1] == '/')
                    {
                        if (j + 2 >= line.Length || line[j + 2] != '/')
                        {
                            break;
                        }
                        else
                        {
                            // Inline documentation (///)
                            code.Append("///");
                            j += 2;
                            continue;
                        }
                    }
                    if (line[j] == '#' && j + 1 < line.Length)
                    {
                         break;
                    }

                    if (line[j] == '@' && j + 1 < line.Length && line[j + 1] == '\"')
                    {
                        inString = true;
                        inMultilineString = true;
                        j++;
                        code.Append("@\"");
                        continue;
                    }

                    if (line[j] == '\"')
                    {
                        inString = true;
                    }

                    if (line[j] == '\'')
                    {
                        inString = true;
                        inSingleQuotedString = true;
                    }
                    if (!inMultiLineComment)
                    {

                    }

                    code.Append(line[j]);
                }
                //empty
          
                if (!inMultiLineComment) code.AppendLine();
            } while (line.Length>0 && line[line.Length - 1] != '>' && line[line.Length - 2] != '?');
            code = code.Remove(code.Length-1,1);
            return code.ToString();
        }
    }
}
