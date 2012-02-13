using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PHPVariables
{
    class PHPVariables
    {

        static StringBuilder code;
        static Dictionary<string, bool> containedVariables;
        
        static void Main(string[] args)
        {
            //ReadInput();
            AuthorReadInput();
            
            // Count variables
            containedVariables = new Dictionary<string, bool>();

            for (int index = 0; index < code.Length; index++)
            {
                if (code[index] == '$' && code[index+1] != ' ' && index+1 < code.Length)
                {
                    if (code[index-1] == '\\' && index-1 >= 0)
                    {
                        if (code[index - 2] != '\\' && index - 2 >= 0)
                        {
                            continue;
                        }
                    }
                    if (code[index - 1] == '$' && index - 1 >= 0)
                    {
                        continue;
                    }
                    if (IsValidFirstSymbol(code[index+1]) && index+1 < code.Length)
                    {
                        StringBuilder newVariable = new StringBuilder();
                        while (IsValidSymbol(code[index+1]))
                        {
                            newVariable.Append(code[index+1]);
                            index++;
                        }

                        if (CheckForLetter(newVariable) == true)
                        {
                            if (containedVariables.ContainsKey(newVariable.ToString()) == false)
                            {
                                containedVariables.Add(newVariable.ToString(), true);    
                            }
                        }
                    }
                }
            }

            PrintResult();
        }

        private static void PrintResult()
        {
            // Write result
            Console.WriteLine(containedVariables.Count);

            var sortedResult = containedVariables.Keys.ToList();
            sortedResult.Sort(StringComparer.Ordinal);
            foreach (var key in sortedResult)
            {
                Console.WriteLine("{0}", key);
            }
        }

        private static void AuthorReadInput()
        {
            code = new StringBuilder();

            bool inMultiLineComment = false;
            bool inString = false;
            bool inMultilineString = false;
            bool inSingleQuotedString = false;

            string line = "";
            while (line.Equals("?>") == false)
            {
                line = Console.ReadLine();

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

                    // One line comment //
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

                    // One line commetn #
                    if (line[j] == '#')
                    {
                        if (j + 1 >= line.Length || line[j + 2] != '/')
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


                    code.Append(line[j]);
                }

                if (!inMultiLineComment) code.AppendLine();
            }

            //Console.WriteLine(code);
        }

        private static bool IsValidFirstSymbol(char symbol)
        {
            if ((symbol == '_') || (symbol >= 'a' && symbol <= 'z') || (symbol >= 'A' && symbol <= 'Z'))
                return true;
            else
                return false;
        }

        private static bool IsValidSymbol(char symbol)
        {
            if ((symbol == '_') || (symbol >= 'a' && symbol <= 'z') || (symbol >= 'A' && symbol <= 'Z') || (symbol >= '0' && symbol <= '9'))
                return true;
            else
                return false;
        }

        private static bool CheckForLetter(StringBuilder input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if ((input[i] >= 'a' || input[i] <= 'A') || (input[i] >= 'A' && input[i] <= 'Z'))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
