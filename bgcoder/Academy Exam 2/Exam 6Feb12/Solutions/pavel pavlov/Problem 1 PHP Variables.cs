using System;
using System.Collections.Generic;
  
namespace PHP_Variables
{
    class PHPVariables
    {
        static void Main()
        {
            string[] phpCode = new string[20000];
            List<string> variables = new List<string>();
            phpCode = ReadText();
  
            for (int row = 0; row < phpCode.Length; row++)
            {
                phpCode[row] = CleanLine(phpCode[row]);
                variables.Add(FindVariable(phpCode[row]));
            }
  
            variables = SplitListOfVariables(variables);
  
            variables = RemoveRepeatedElements(variables);
  
            Console.WriteLine(variables.Count);
            foreach (var item in variables)
            {
                Console.WriteLine(item);
            }
        }
  
        private static string[] ReadText()
        {
            string[] code = new string[20000];
            code[0] = "start";
            int row = 0;
            while (code[row] != "?>")
            {
                row++;
                code[row] = Console.ReadLine();
            }
            return code;
        }
  
        private static List<string> RemoveRepeatedElements(List<string> variables)
        {
            for (int i = 0; i < variables.Count - 1; )
            {
                if ((variables[i] == "") || (variables[i] == variables[i + 1]))
                {
                    variables.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
            return variables;
        }
  
        private static List<string> SplitListOfVariables(List<string> variables)
        {
            string[] variablesString = variables.ToArray();
  
            List<string> variablesList = new List<string>();
  
            for (int i = 0; i < variablesString.Length; i++)
            {
                string[] variableArray = variablesString[i].Split('.');
  
                for (int j = 0; j < variableArray.Length; j++)
                {
                    variablesList.Add(variableArray[j]);
                }
            }
  
            variablesList.Sort();
  
            return variablesList;
        }
  
        private static string FindVariable(string code)
        {
            if (code == null)
            {
                return "";
            }
            int chrIndex = code.IndexOf('$');
            if (chrIndex < 0)
            {
                return "";
            }
            code = code.Remove(chrIndex, 1);
            string variable = null;
            string allPossibleChars = "_aAbBcCdDeEfFgGhHjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ1234567890" ;
            /*builds the name of the variable symbol by symbol*/
            for (int i = chrIndex; i < code.Length; i++)
            {
                if (allPossibleChars.IndexOf(code[i]) >= 0)
                {
                    variable += code[i];
                }
                else
                {
                    /*marks end of varaible name*/
                    variable += '.';
  
                    /*search for next variable*/
                    i = code.IndexOf('$');
                      
                    if (i == -1)
                    {
                        break;
                    }
                    code = code.Remove(i, 1);
                    i--;
                }
            }
            return variable;
        }
  
        private static bool multiLineCommentActive = false;
  
        private static string StripMultiLineComment(string code)
        {
            int chrIndex;
  
            if ((code == null) || (code == ""))
                return "";
  
            if (multiLineCommentActive)
            {
                /* Search for end of multi-line comment */
                chrIndex = code.IndexOf("*/");
  
                if (chrIndex > 0)
                {
                    multiLineCommentActive = false;
  
                    return code.Remove(0, chrIndex + 2);
                }
  
                return "";
            }
  
            /* Search for start of multi-line comment */
            chrIndex = code.IndexOf("/*");
  
            if (chrIndex > 0)
            {
                multiLineCommentActive = true;
  
                return code.Substring(0, chrIndex) + StripMultiLineComment(code.Remove(chrIndex));
            }
  
            return code;
        }
  
        private static string StripSingleLineComment(string code)
        {
            int commentBegin;
  
            if ((code == null) || (code == ""))
                return "";
  
            commentBegin = code.IndexOf("//");
            if (commentBegin == -1)
            {
                commentBegin = code.IndexOf('#');
            }
  
            if (commentBegin > 0)
            {
                code = code.Remove(commentBegin);
            }
  
            return code;
        }
  
        private static string CleanLine(string code)
        {
            code = StripSingleLineComment(code);
              
            code = StripMultiLineComment(code);
  
            return code;
        }
    }
}