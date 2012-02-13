using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Task1PHPVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> variables = new SortedDictionary<string, int>();

            bool inMultiLineComment = false;
            bool inString = false;
            bool inVariable = false;
            bool inSingleQuotedString = false;

            string line = string.Empty;
            while ((line = Console.ReadLine()) != "?>")
            {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < line.Length; j++)
                {
                    if (inVariable)
                    {
                        sb.Append(line[j]);
                        if (j + 1 < line.Length && !(char.IsLetterOrDigit(line[j + 1]) || line[j + 1] == '_'))
                        {
                            string varName = sb.ToString();
                            if (!variables.ContainsKey(varName))
                            {
                                variables.Add(varName, 1);
                            }
                            sb.Clear();
                            inVariable = false;
                            continue;
                        }
                        if (j + 1 >= line.Length)
                        {
                            string varName = sb.ToString();
                            if (!variables.ContainsKey(varName))
                            {
                                variables.Add(varName, 1);
                            }
                            sb.Clear();
                            inVariable = false;
                            continue;
                        }
                    }
                    if (inString)
                    {
                        if (line[j] == '\\' && j + 1 < line.Length && line[j + 1] == '\"')
                        {
                            j++;
                            continue;
                        }
                        if (line[j] == '\\' && j + 1 < line.Length && line[j + 1] == '\'')
                        {
                            j++;
                            continue;
                        }
                        if (line[j] == '\\' && j + 1 < line.Length && line[j + 1] == '$')
                        {
                            j++;
                            continue;
                        }
                        if (line[j] == '{' && j + 1 < line.Length && line[j + 1] == '$')
                        {
                            inVariable = true;
                            j++;
                            continue;
                        }
                        if (line[j] == '$' && j + 1 < line.Length && (char.IsLetter(line[j + 1]) || line[j + 1] == '_'))
                        {
                            inVariable = true;
                            continue;
                        }
                        if (line[j] == '\"' && !inSingleQuotedString)
                        {
                            inString = false;
                            continue;
                        }
                        if (line[j] == '\'' && inSingleQuotedString)
                        {
                            inString = false;
                            inSingleQuotedString = false;
                            continue;
                        }
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
                            j += 2;
                            continue;
                        }
                    }

                    if (line[j] == '#')
                    {
                        break;
                    }

                    if (line[j] == '$' && j + 1 < line.Length && (char.IsLetter(line[j + 1]) || line[j + 1] == '_'))
                    {
                        inVariable = true;
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
                }
            }

            Console.WriteLine(variables.Count);
            foreach (KeyValuePair<string, int> var in variables)
            {
                Console.WriteLine(var.Key);
            }
        }
    }
}
