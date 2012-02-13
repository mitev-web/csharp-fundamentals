using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace _01.PHP_Variables
{
    class Program
    {
        static void Main()
        {
            StringBuilder code = new StringBuilder();
            List<string> variables = new List<string>();

            int variablesCounter = 0;
            bool inMultiLineComment = false;
            string line = string.Empty;
            //char[] delimiters = { ',', '(', ')', '[', ']', '.', '\"', ' ', ';', '='
            //                    , '}', '{', '\'', '^', '\t', '\r', '\n', '+', '-', '*'
            //                    , '/', '%', '<', '>', '%', '<', '>', };

            char[] delimiters = new char[64];
            for (int i = 0, j = 0; i < 128; i++, j++)
            {
                if (i==36)
                {
                    i = 37;
                }
                if (i==48)
                {
                    i = 58;
                }
                if (i==65)
                {
                    i = 91;
                }
                if (i==95)
                {
                    i = 96;
                }
                if (i == 97)
                {
                    i = 123;
                }
                delimiters[j] = (char)i;
            }

            while((line=Console.ReadLine()) != "?>")
            {

                for (int j = 0; j < line.Length; j++)
                {
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

                    //one line # comment
                    if (line[j] == '#')
                    {
                        break;
                    }
                    code.Append(line[j]);
                }

                if (!inMultiLineComment) code.AppendLine();
            }

            StringReader sr = new StringReader(code.ToString());
            string lineToPrint = null;
            int variableLenght = Int32.MaxValue;
            while ((lineToPrint = sr.ReadLine()) != null)
            {
                if (!string.IsNullOrWhiteSpace(lineToPrint))
                {
                    int dollar = -1;
                    for (int i = 0; i < lineToPrint.Length; i++)
                    {
                        dollar = lineToPrint.IndexOf('$',i);
                        if (dollar>0 && lineToPrint[dollar-1] == '\\')
                        {
                            continue;
                        }
                        int spaceAfterDollar;
                        if (dollar != -1)
                        {
                            string tempVariable = string.Empty;
                            string variable = string.Empty;
                            variableLenght = Int32.MaxValue;
                            for (int j = 0; j < delimiters.Length; j++)
                            {
                                if ((spaceAfterDollar = lineToPrint.IndexOf(delimiters[j], dollar)) != -1)
                                {
                                    tempVariable = lineToPrint.Substring(dollar + 1, spaceAfterDollar - dollar-1);
                                    if (variableLenght>tempVariable.Length)
                                    {
                                        variableLenght = tempVariable.Length;
                                        variable = tempVariable;
                                    }
                                    
                                }
                            }
                            if (!variables.Contains(variable) && variable != string.Empty)
                            {
                                variables.Add(variable);
                                variablesCounter++;
                                continue;
                            }
                        }
                    }
                }
            }

            variables.Sort();
            Console.WriteLine(variablesCounter);
            foreach (var item in variables)
            {
                Console.WriteLine(item);
            }


        }
    }
}
