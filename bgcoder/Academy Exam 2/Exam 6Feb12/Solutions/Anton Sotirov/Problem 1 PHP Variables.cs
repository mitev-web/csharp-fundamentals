using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace problem1_PHP
{
    class Program
    {
        static List<string> variables = new List<string>();

        static string InComment(string line)
        {
            int index = 0;
            bool unComment = false;
            while (!unComment)
            {
                index=line.IndexOf("*/");
                if (index >= 0)
                {
                    unComment = true;
                }
                else
                {
                    line = Console.ReadLine();
                }
            }
            return line.Substring(index+2);
        }
        static string InStringSingle(string lineInput)
        {
            string line = lineInput;
            
            int index = 0;
            char stringChar = '\'';
            bool foundExit = false;
            while (!foundExit)
            {
                string p = "\\\\\\$";
                Regex reg = new Regex(p);
                line = reg.Replace(line, "");

                string endIndexPattern = "(?<!\\\\)" + stringChar;
                reg = new Regex(endIndexPattern);
                Match endString = reg.Match(line);

                if (endString.Success)
                {
                    index = endString.Index + 1;
                    foundExit = true;
                }
                else
                {
                    index = line.Length;
                }
                string pattern = "(?<=\\$)[A-Za-z0-9_]*";

                reg = new Regex(pattern);

                foreach (var item in reg.Matches(line.Substring(0, index)))
                {
                    variables.Add(item.ToString());
                }
                if (!foundExit)
                {
                    line = Console.ReadLine();
                }
            }
            return line.Substring(index);
        }
        static string InStringDouble(string lineInput)
        {
            string line = lineInput;

            int index = 0;
            char stringChar = '\"';
            bool foundExit = false;
            while (!foundExit)
            {
                string p = "\\\\\\$";
                Regex reg = new Regex(p);
                line = reg.Replace(line, "");

                string endIndexPattern = "(?<!\\\\)" + stringChar;
                reg = new Regex(endIndexPattern);
                Match endString = reg.Match(line);

                if (endString.Success)
                {
                    index = endString.Index + 1;
                    foundExit = true;
                }
                else
                {
                    index = line.Length;
                }
                string pattern = "(?<=\\$)[A-Za-z0-9_]*";

                reg = new Regex(pattern);

                foreach (var item in reg.Matches(line.Substring(0, index)))
                {
                    variables.Add(item.ToString());
                }
                if (!foundExit)
                {
                    line = Console.ReadLine();
                }
            }
            return line.Substring(index);
        }
        static int Min(params int[] a)
        {
            int min = int.MaxValue;
            int minIndex = 0;
            for (int i = 0; i < a.Length;i++ )
            {
                int item = a[i];
                if (min > item && item>=0)
                {
                    min = item;
                    minIndex = i;
                }
            }
            return minIndex;
        }
        static void Main(string[] args)
        {  
            Console.ReadLine();//read <?php>
            string line;

            line = Console.ReadLine();                
            do
            {
                string lineToSearch;
                string lineToCheck;
                bool hasMore = true;
                while (hasMore)
                {
                    if (line == "")
                        break;
                    int commentLine = line.IndexOf("//");
                    int commentLine2 = line.IndexOf("#");
                    int comment = line.IndexOf("/*");
                    int singleQ = line.IndexOf('\'');
                    int doubleQ = line.IndexOf('"');
                    int[] a = { commentLine, commentLine2, comment, singleQ, doubleQ };
                    int index = Min(a);
                    if (a[index] == -1)
                    {
                        lineToSearch = line;
                        hasMore = false;
                    }
                    else
                    {
                        lineToSearch = line.Substring(0, a[index]);
                    }
                    lineToCheck = line.Substring(a[index] + 1, line.Length - a[index] - 1);
                    string pattern = "(?<=\\$)[A-Za-z0-9_]*";
                    Regex reg = new Regex(pattern);
                    MatchCollection matches = reg.Matches(lineToSearch);                    
                    foreach (var item in matches)
                    {
                        if (variables.Contains(item.ToString())) continue;
                        variables.Add(item.ToString());
                    }
                    switch (index)
                    {
                        case 0:
                            hasMore = false;
                            break;
                        case 1:

                            break;
                        case 2:
                            line=InComment(line.Substring(a[index] + 2));
                            break;
                        case 3:
                            line = InStringSingle(lineToCheck);
                            break;
                        case 4:
                            line = InStringDouble(lineToCheck);
                            break;
                        default:
                            break;
                    }
                }       
                line = Console.ReadLine();
            } while (line != "?>");
            variables.Sort();
            Console.WriteLine(variables.Count);
            foreach (var item in variables)
            {
                Console.WriteLine(item);
            }
        }
    }
}
