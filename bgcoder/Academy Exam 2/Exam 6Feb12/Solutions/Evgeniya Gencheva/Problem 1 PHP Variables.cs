using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
 
namespace PHPvariables
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> code = Input();
            List<string> variables = FindVariables(code);
            Output(variables);
        }
        public static void Output(List<string> allVar)
        {
            for (int i = 0; i < allVar.Count; i++)
            {
                allVar[i] = allVar[i].Replace('$', ' ').Trim();
            }
            List<string> result = MySort(allVar);
            Console.WriteLine(result.Count);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
        public static List<string> MySort(List<string> allVar)
        {
            allVar.RemoveAll(t => t == "");
            List<string> _vars = new List<string>();
            _vars = allVar.FindAll(t => t[0] == '_');
            List<string> sorted = new List<string>();
            _vars.Sort(StringComparer.Ordinal);
            allVar.Sort(StringComparer.Ordinal);
            sorted.AddRange(_vars);
            sorted.AddRange(allVar);
            sorted.RemoveAll(t => t == "");
            sorted = sorted.Distinct().ToList();
            return sorted;
        }
        public static List<string> Input()
        {
            List<string> input = new List<string>();
            //StreamReader sr = new StreamReader(@"C:\Users\User\Desktop\test.txt");
            //while (sr.EndOfStream == false)
            //{
            //    input.Add(sr.ReadLine());
            //}
            //sr.Dispose();
            string line = Console.ReadLine();
            do
            {
                input.Add(line.Trim());
                line = Console.ReadLine();
            }
            while (line != "?>");
            return input;
        }
        public static List<string> FindVariables(List<string> code)
        {
            StringBuilder sb = new StringBuilder();
            List<string> variables = new List<string>();
            bool isComment = false;
            bool isInString = false;
            bool isInMultilineComment = false;
            bool isVariable = false;
            for (int i = 0; i < code.Count; i++)
            {
                string line = code[i];
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == '$' && isInMultilineComment == false && isInString == false)
                    {
                        if (j == 0)
                        {
                            isVariable = true;
                            sb.Append(line[j]);
                        }
                        else if (j >= 1 && line[j - 1] == '\\')
                        {
                            isVariable = false;
                            continue;
                        }
                        else if(j < line.Length - 1)
                        {
                            if (Regex.IsMatch(line[j + 1].ToString(), @"^[a-zA-Z_]+$") == true)
                            {
                                isVariable = true;
                                sb.Append(line[j]);
                            }
                        }
                    }
                    else if (isVariable == true)
                    {
                        if (Regex.IsMatch(line[j].ToString(), @"^[a-zA-Z0-9_]+$") == false)
                        {
                            isVariable = false;
                        }
                        else if (j == line.Length - 1)
                        {
                            sb.Append(line[j]);
                            isVariable = false;
                        }
                        else
                        {
                            sb.Append(line[j]);
                            continue;
                        }
                    }
                    if (isVariable == false)
                    {
                        sb.Append(" ");
                    }
 
                    //one line comment
                    if (line[j] == '#')
                    {
                        isComment = true;
                        break;
                    }
                    if (line[j] == '/' && j <= (line.Length - 2))
                    {
                        if (line[j + 1] == '/')
                        {
                            isComment = true;
                            break;
                        }
                    }/*
                    //string
                    if (line[j] == '"')
                    {
                        if (j > 0 && line[j - 1] == '\\')
                        {
                            continue;
                        }
                        else if (isInString == false)
                        {
                            isInString = true;
                            continue;
                        }
                        else
                        {
                            isInString = false;
                            continue;
                        }
                    }
                    if (line[j] == '\'')
                    {
                        if (j > 0 && line[j - 1] == '\\')
                        {
                            continue;
                        }
                        else if (isInString == false)
                        {
                            isInString = true;
                            continue;
                        }
                        else
                        {
                            isInString = false;
                            continue;
                        }
                    }*/
                    //multiline comment
                    if (!isInMultilineComment && j + 1 < line.Length && line[j] == '/' && line[j + 1] == '*')
                    {
                        isInMultilineComment = true;
                        j++;
                        continue;
                    }
                    if (isInMultilineComment && j + 1 < line.Length && line[j] == '*' && line[j + 1] == '/')
                    {
                        isInMultilineComment = false;
                        j++;
                        continue;
                    }
                    if (isInMultilineComment)
                    {
                        continue;
                    }
                     
                }
            }
            string allVar = sb.ToString();
            char[] d = { ' ' };
            variables = allVar.Split(d, StringSplitOptions.RemoveEmptyEntries).ToList();
            return variables;
        }
    }
}