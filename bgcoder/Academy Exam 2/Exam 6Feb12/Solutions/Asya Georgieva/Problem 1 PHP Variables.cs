using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace _1.PHPVariables
{
   class Program
   {
      static void Main(string[] args)
      {
         StringBuilder code = new StringBuilder();
         string[] numbers = code.ToString().Split(' ');

         bool inMultiLineComment = false;
         bool inString = false;
         bool inMultilineString = false;
         bool inSingleQuotedString = false;
         bool indDiez = false;

         while (true)
         {
            string line = Console.ReadLine();
            if (line == "?>")
            {
               break;
            }
            // code.Append(line);

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

               //----




               if (line[j] == '#' && j + 1 < line.Length )
               {
                  if (j + 2 >= line.Length || line[j + 2] != '/')
                  {
                     break;
                  }
                  else
                  {
                     // Inline documentation (///)
                     code.Append("#");
                     //j += 2;
                     j++;
                     continue;
                  }
               }


               if (line[j] == '\\' && j + 1 < line.Length)
               {
                  if (j + 2 >= line.Length || line[j + 2] != '/')
                  {
                     break;
                  }
                  else
                  {
                     // Inline documentation (///)
                     code.Append("\\");
                     //j += 2;
                     j++;
                     continue;
                  }
               }



               //---

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


         StringReader sr = new StringReader(code.ToString());
         string lineToPrint = null;

         StringBuilder res = new StringBuilder();
         while ((lineToPrint = sr.ReadLine()) != null)
         {
            if (!string.IsNullOrWhiteSpace(lineToPrint))
            {
               res.Append(lineToPrint);
            }
         }

         //char[] delimiterChars = {'\n'};
         //string[] words = res.ToString().Split(delimiterChars);

         // Console.WriteLine(res);

         // Console.WriteLine(sb);
         MatchCollection matches = Regex.Matches(res.ToString(), "([$]+[a-zA-Z0-9_]*)");

         //[a-zA-Z0-9_]{1,}$ [^p]-ne izpechatwa p
         //[$]+[a-zA-Z0-9_]

         int count = 0;
         List<string> var = new List<string>();
         foreach (Match match in matches)
         {

            string num = match.Value.Substring(1, match.Length - 1);
            // Console.WriteLine(num);
            // Console.WriteLine(match);
           // count++;
            
            
            var.Add(num);

         }

         //foreach (var i in var)
         //{
         //   Console.WriteLine(i);
         //}

        // Console.WriteLine(count);
         // Console.WriteLine(var);

         IEnumerable<string> distinctAges = var.Distinct();
         string[] arr = distinctAges.ToArray();

         Console.WriteLine(arr.Length);

         for (int i = 0; i < arr.Length - 1; i++)
         {
            string lex = arr[i];

            for (int j = 1; j < arr.Length; j++)
            {
               //  var[0].CompareTo(var[j]);

               if (arr[i].CompareTo(arr[j]) == 1)
               {
                  // continue;
                  string temp = arr[j];
                  arr[j] = arr[i];
                  arr[i] = temp;
               }
               else if (arr[i].CompareTo(arr[j]) == -1)
               {
                  continue;
               }
               else if (arr[i].CompareTo(arr[j]) == 0)
               {
                  continue;
               }
            }
            
         }
         foreach (var i in arr)
         {
            Console.WriteLine(i);
         }
      }

     
   }
}
