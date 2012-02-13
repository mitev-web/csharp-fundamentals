using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PHP_Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder code = new StringBuilder();

            bool inMultiLineComment = false;
            bool inVariable = false;
            bool isValid = false;
            bool notLastLine = true;

            while (notLastLine)
            {
                string line = Console.ReadLine();
                if (line == "?>")
                {
                    notLastLine = false;
                }
                else
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
                        if ((line[j] == '#' && (j - 1 >= 0) && (line[j - 1] != '\\')) || (line[j] == '#' && j == 0) || (line[j] == '/' && j + 1 < line.Length && line[j + 1] == '/' && (j + 2 >= line.Length || line[j + 2] != '/')))
                        {
                            break;
                        }
                        // Variable start and not escaped

                        if ((line[j] == '$' && (j - 1 >= 0) && (line[j - 1] != '\\')) || (line[j] == '$' && j == 0) || (line[j] == '$' && (j - 2 >= 0) && (line[j - 1] == '\\') && (line[j - 2] == '\\')))
                        {
                            code.Append(line[j]);
                            inVariable = true;
                            continue;
                        }
                        if (char.IsDigit(line[j]) || char.IsLetter(line[j]) || line[j] == '_')
                        {
                            isValid = true;
                        }
                        else { isValid = false; inVariable = false; }

                        if (inVariable && isValid)
                        {
                            code.Append(line[j]);
                        }

                    }
                }
            }

            string variables = code.ToString();

            string[] var = variables.Split('$');
            string[] vars = RemoveDuplicates(var);

            Console.WriteLine(vars.Length - 1);
            Array.Sort(vars);
            for (int i = 1; i < vars.Length; i++)
            {
                Console.WriteLine(vars[i]);
            }
        }

             public static string[] RemoveDuplicates(string[] s)
            {
                HashSet<string> set = new HashSet<string>(s);
                string[] result = new string[set.Count];
                set.CopyTo(result);
                return result;
            }

        }
    }