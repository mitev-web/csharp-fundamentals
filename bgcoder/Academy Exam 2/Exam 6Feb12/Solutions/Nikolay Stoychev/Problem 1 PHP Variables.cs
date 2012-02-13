using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        StringBuilder code = new StringBuilder();
        //int linesCount = int.Parse(Console.ReadLine());

        bool inMultiLineComment = false;
        bool inString = false;
        bool inMultilineString = false;
        bool inSingleQuotedString = false;


        //for (int i = 1; i <= linesCount; i++)
        int i = 0;
        //StreamReader reader = new StreamReader("in.txt");
        string line = Console.ReadLine();
        while (line != "?>")
        {
            i++;
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
                        //code.Append("\\\"");
                        j++;
                        continue;
                    }
                    if (line[j] == '\\' && j + 1 < line.Length && line[j + 1] == '\'')
                    {
                        //code.Append("\\\'");
                        j++;
                        continue;
                    }
                    if (line[j] == '\"' && !inSingleQuotedString)
                    {
                        inString = false;
                        inMultilineString = false;
                        //code.Append('\"');
                        continue;
                    }
                    if (line[j] == '\'' && inSingleQuotedString)
                    {
                        inString = false;
                        inSingleQuotedString = false;
                        //code.Append('\'');
                        continue;
                    }
                    //code.Append(line[j]);
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

            if (!inMultiLineComment)
            { 
                code.AppendLine(); 
            }

            line = Console.ReadLine();
        }
        //reader.Close();
        Regex regex = new Regex("[$]{1}([a-zA-Z_]+)");
        List<string> list = new List<string>();
        StringReader sr = new StringReader(code.ToString());
        string lineToPrint = null;
        while ((lineToPrint = sr.ReadLine()) != null)
        {
            if (!string.IsNullOrWhiteSpace(lineToPrint))
            {
                foreach (var match in regex.Matches(lineToPrint))
                {
                    if (!list.Contains(match.ToString()))
                    {
                        list.Add(match.ToString());
                    }
                }
            }
        }

        Console.WriteLine(list.Count);
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
}