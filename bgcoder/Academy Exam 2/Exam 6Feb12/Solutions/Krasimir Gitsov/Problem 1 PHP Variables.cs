using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _01_Problem
{
   class Program
   {
      static void Main()
      {
         string inputString = Console.ReadLine();
         Dictionary<int, string> phpCode = new Dictionary<int, string>();
         Dictionary<int, string> vars = new Dictionary<int, string>();
         int i = 0;
         int e = 0;
         for (int q= 0;; q++)
         {
            if (inputString == "?>")
            {
               break;
            }
            inputString = Console.ReadLine();
            phpCode.Add(i, inputString);
            i++;
         }
         bool varInComment = false;
         bool varInMultiComment = false;
         bool varInString = false;
         for (int j = 0; j < i; j++)
         {
            string temp = "";
            phpCode.TryGetValue(j, out temp);
            for (int k = 0; k < temp.Length; k++)
            {
               if (!varInString && temp[k] == '#')
               {
                  k++;
                  break;
               }
               if (!varInMultiComment && k + 1 < temp.Length && temp[k] == '/' && temp[k + 1] == '*')
               {
                  varInMultiComment = true;
                  k++;
                  continue;
               }
               if (temp[k] == '/' && j + 1 < temp.Length && temp[k + 1] == '/')
               {
                  break;
               }
               if (varInMultiComment && k + 1 < temp.Length && temp[k] == '*' && temp[k + 1] == '/')
               {
                  varInMultiComment = false;
                  k++;
                  continue;
               }
               if (!varInString && temp[k] == '\"')
               {
                  varInString = true;
               }
               if (varInString && temp[k] == '\"')
               {
                  varInString = true;
               }

               if (temp[k] == '$' && !varInComment && !varInMultiComment && varInString)
               {
                  if (k - 1 >= 0 && k - 1 < temp.Length && temp[k - 1] == '\\')
                  {
                     continue;
                  }
                  else
                  {
                     StringBuilder var = new StringBuilder();
                     for (int t = k; t < temp.Length; t++)
                     {
                        if (temp[t] == '=' || temp[t] == ' ' || temp[t] == '['
                        || temp[t] == ';' || temp[t] == '}' || temp[t] == ')'
                        || temp[t] == ',' || temp[t] == '\"' || temp[t] == '.'
                        || temp[t] == '{' || temp[t] == ']' || temp[t] == '\'')
                        {
                           break;
                        }
                        else
                        {
                           var.Append(temp[t].ToString());
                           k++;
                        }
                     }
                     if (vars.ContainsValue(var.ToString()))
                     {
                        continue;
                     }
                     else
                     {
                        vars.Add(e, var.ToString());
                        e++;
                        continue;
                     }
                  }
               }
               else if (temp[k] == '$' && !varInComment && !varInMultiComment && !varInString)
               {
                  StringBuilder var = new StringBuilder();
                  for (int t = k; t < temp.Length; t++)
                  {
                     if (temp[t] == '=' || temp[t] == ' ' || temp[t] == '['
                        || temp[t] == ';' || temp[t] == '}' || temp[t] == ')'
                        || temp[t] == ',' || temp[t] == '\"' || temp[t] == '.' 
                        || temp[t] == '{' || temp[t] == ']' || temp[t] == '\'')
                     {
                        break;
                     }
                     else
                     {
                        var.Append(temp[t].ToString());
                        k++;
                     }
                  }
                  if (vars.ContainsValue(var.ToString()))
                  {
                     continue;
                  }
                  else
                  {
                     vars.Add(e, var.ToString());
                     e++;
                     continue;
                  }
                  
               }
            }
         }
         Console.WriteLine(e);
         var sortedDict = (from entry in vars
                           orderby entry.Value ascending
                           select entry);
         foreach (KeyValuePair<int, string> kvp in sortedDict)
         {
            Console.WriteLine("{0}", kvp.Value.Remove(0, 1));
         }
      }
   }
}
