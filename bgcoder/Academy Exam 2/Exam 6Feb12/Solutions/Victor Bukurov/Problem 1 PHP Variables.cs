using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PHP_Variables
{
    class Program
    {
        static bool inMultilineComment = false;
        static bool inSingleQuotedString = false;
        static bool inDoubleQuotedString = false;
        static bool inInlineComment = false;
        static List<string> variables = new List<string>(10001);
        static char[] charsToSearch = { '/', '#', '$', '\"', '\''};
        static void Main(string[] args)
        {
            Console.ReadLine();
            string line;
            while ((line = Console.ReadLine()) != "?>")
            {
                CheckLine(line);
            }
            Console.WriteLine(variables.Count);
            variables.Sort();
            foreach (var item in variables)
            {
                Console.WriteLine(item);
            }
        }

        static void CheckLine(string line)
        {
            inInlineComment = false;
            int index = line.IndexOfAny(charsToSearch);
            while (index != -1)
            {
                switch (line[index])
                {
                    case '/': DeleteCharEncountered(index, line); break;
                    case '#': CommentCharEncountered(index, line); break;
                    case '\'': SingleQuoteCharEncountered(index, line); break;
                    case '\"': DoubleQuoteCharEncountered(index, line); break;
                    case '$': DollarSignEncountered(index, line); break;
                }
                if (inInlineComment)
	            {
		             break;
	            }

                index++;
                if (index >= line.Length)
                {
                    break;
                }
                else
                {
                    index = line.IndexOfAny(charsToSearch, index);
                }
            }
        }

        private static void DollarSignEncountered(int index, string line)
        {
            if (inMultilineComment)
            {
                return;
            }
            if (inSingleQuotedString || inDoubleQuotedString)
            {
                if (IsEscaped(index, line))
                {
                    return;
                }
            }
            VariableFound(index, line);
        }

        private static void DoubleQuoteCharEncountered(int index, string line)
        {
            if (inMultilineComment || inSingleQuotedString)
            {
                return;
            }
            if (inDoubleQuotedString)
            {
                if (IsEscaped(index, line))
                {
                    return;
                }
                inDoubleQuotedString = false;
            }
            else
            {
                inDoubleQuotedString = true;
            }
        }

        private static void SingleQuoteCharEncountered(int index, string line)
        {
            if (inMultilineComment || inDoubleQuotedString)
            {
                return;
            }
            if (inSingleQuotedString)
            {
                if (IsEscaped(index, line))
                {
                    return;
                }
                inSingleQuotedString = false;
            }
            else
            {
                inSingleQuotedString = true;
            }  
        }

        private static void CommentCharEncountered(int index, string line)
        {
            if (inSingleQuotedString || inDoubleQuotedString || inMultilineComment)
            {
                return;
            }
            inInlineComment = true;
        }

        private static void DeleteCharEncountered(int index, string line)
        {
            if (inSingleQuotedString || inDoubleQuotedString)
            {
                return;   
            }
            if (inMultilineComment)
            {
                if (index > 0 && line[index - 1] == '*')
                {
                    inMultilineComment = false;
                }
                return;
            }
            if (index < line.Length - 1 && line[index + 1] == '*')
            {
                inMultilineComment = true;
                return;
            }
            if (index < line.Length - 1 && line[index + 1] == '/')
            {
                inInlineComment = true;
            }
        }

        private static bool IsEscaped(int index, string line)
        {
            int count = 0;
            index--;
            while (index >= 0 && line[index] == '\\')
            {
                count++;
                index--;
            }
            if (count % 2 == 0)
            {
                return false;
            }
            return true;
        }

        private static void VariableFound(int index, string line)
        {
            StringBuilder var = new StringBuilder();
            index++;
            while (index < line.Length && (char.IsLetter(line[index]) || char.IsDigit(line[index]) || line[index] == '_'))
            {
                var.Append(line[index]);
                index++;
            }
            string result = var.ToString();
            if (!variables.Contains(result))
            {
                variables.Add(result);
            }
        }
    }
}
