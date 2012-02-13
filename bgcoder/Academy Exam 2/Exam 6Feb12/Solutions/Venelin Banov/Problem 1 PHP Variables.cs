using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PHPVariabes
{
    class Program
    {
        static List<string> lines = new List<string>();
        static List<string> variables = new List<string>();
        static int t;

        static void FindVariables(string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '$')
                {
                    if (i != 0)
                    {
                        if (line[i - 1] == '\u005c')
                        {
                            break;
                        }
                    }
                    int variableIndex = line.IndexOf('$');

                    string possibleVariable = line.Substring(variableIndex);
                    possibleVariable = possibleVariable.Trim('$');
                    line = possibleVariable;
                    int variableEnd = 0;
                    bool isVariableSign = false;
                    for (int j = 0; j < possibleVariable.Length; j++)
                    {
                        if ((char.IsLetter(possibleVariable[j]) == true) | (char.IsNumber(possibleVariable[j]) == true) | 
                            (possibleVariable[j] == '_'))
                        {
                            isVariableSign = true;
                        }
                        else
                        {
                            isVariableSign = false;
                        }
                        
                        if (isVariableSign == false)
                        {
                            variableEnd = j;
                            break;
                        }
                        if (j == possibleVariable.Length - 1)
                        {
                            variableEnd = j+1;
                        }
                    }


                    string var = possibleVariable.Substring(0, variableEnd);
                    variables.Add(var);
                    i = 0;
                }
            }
        }


        static void CheckLines(string line)
        {
            int length = line.Length - 1;
            if (length > 1)
            {
                if (((line[0] == '/') & (line[1] == '/')) || ((line[0] == '/') & (line[1]) == '*') ||
                    ((line[length] == '/') & line[length - 1] == '*') || (line[0] == '#'))
                {
                    lines.Remove(line);
                    CheckLines(lines[t]);
                }
            }
        }
        static void Main(string[] args)
        {
            for (int i = 0; ; i++)
            {
                string k = Console.ReadLine();
                lines.Add(k);
                if (k == "?>")
                {
                    break;
                }
            }
            //string s = Console.ReadLine();
            //lines.Add(s);
            //lines.Add("this is $comment");
            //lines.Add("$valid_var = ...{$valid_var56}");
            //lines.Add("$just3 = Just another var $Just... $just=$code");
            lines.Remove("<?php");
            lines.Remove("?>");
            
            for (t = 0; t < lines.Count; t++)
            {
                try
                {
                    CheckLines(lines[t]);
                    FindVariables(lines[t]);
                }
                catch (ArgumentOutOfRangeException fe)
                {
                    Console.Error.WriteLine("\nMessage: " + fe.Message);
                }
                catch (IndexOutOfRangeException fe)
                {
                    Console.Error.WriteLine("\nMessage: " + fe.Message);
                }
            }
            variables.Sort();
            for (int i = 0; i < variables.Count; i++)
            {
                for (int j = 1; j + i < variables.Count; j++)
                {
                    if (variables[i] == variables[i + j])
                    {
                        variables.Remove(variables[i]);
                        i--;
                        break;
                    }
                }
            }
            foreach (string variable in variables)
            {
                variable.Trim();
            }
            int length = variables.Count;
            Console.WriteLine(length);
            foreach (string variable in variables)
            {
                Console.WriteLine(variable);
            }

        }
    }
}