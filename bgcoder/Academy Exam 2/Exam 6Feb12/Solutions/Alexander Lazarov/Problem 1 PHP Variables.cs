using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Problem_1_CSharp_Clean_Code
{
    class Program
    {
        static void Main()
        {
            StringBuilder code = new StringBuilder();

            bool inMultiLineComment = false;
            bool inString = false;
            bool inMultilineString = false;
            bool inSingleQuotedString = false;
            int count = 0;
            string check = "?>";
            for (int i = 1; i <= 100; i++)
            {
                string line = Console.ReadLine();
                if (line != check)
                {
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
                else
                {
                    goto Next;
                }
            }
        Next:
            StringReader sr = new StringReader(code.ToString());
            string str = code.ToString();


            
            string printSentences = @"[\$* $]";
            StringBuilder PrintWords = new StringBuilder(); 
             Regex r = new Regex(printSentences, RegexOptions.IgnoreCase);

      // Match the regular expression pattern against a text string.
      Match m = r.Match(str);
      int matchCount = 0;
      while (m.Success) 
      {
          count++;
         for (int i = 1; i <= 2; i++) 
         {
            Group g = m.Groups[i];
            CaptureCollection cc = g.Captures;
            for (int j = 0; j < cc.Count; j++)
            {
                Capture c = cc[j];
                PrintWords.Append(c);
            }
            
           
         }
         m = m.NextMatch();
      }
            Console.WriteLine(count);
            StringReader read = new StringReader(PrintWords.ToString());
            string lineToPrint = null;
            while ((lineToPrint = read.ReadLine()) != null)
            {
                if (!string.IsNullOrWhiteSpace(lineToPrint))
                {
                    Console.WriteLine(lineToPrint);
                }
            }
        }
    }
}