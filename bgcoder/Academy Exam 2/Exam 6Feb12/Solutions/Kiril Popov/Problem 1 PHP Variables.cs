using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace P1.PHPVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            //bool inArrayDec = false;
            bool inString = false;
            bool inMultilineCom = false;
            bool inSinglelineCom = false;
            bool inSingleQuotedStr = false;
            bool inDoubleQuotedStr = false;
            bool inVariableDec = false;
            StringBuilder variable = new StringBuilder();
            SortedDictionary<string, int> phpVars = new SortedDictionary<string, int>();
           // using (StreamReader reader = new StreamReader("..\\..\\Input2.txt"))
           // {
                string line = Console.ReadLine();
                while ((line = Console.ReadLine()) != "?>")
                {                   
                    inSinglelineCom = false;
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (((line[i] == '#') || ((i < line.Length - 1) && line[i] == '/' && line[i+1] == '/')) && inString == false && inSinglelineCom == false)
                        {
                            if (line[i] == '#' && (i > 0 && line[i - 1] != '\\'))
                            {
                                continue;
                            }
                            inSinglelineCom = true;
                            continue;
                        }
                        else if (((line[i] == '/') && (i < (line.Length - 1)) && (line[i + 1] == '*')) && (inMultilineCom == false ) && inString == false && inSinglelineCom == false) //!                                           
                        {
                            i++;
                            inMultilineCom = true;
                            continue;
                        }
                        else if ((line[i] == '*') && (i < (line.Length - 1)) && line[i + 1] == '/' && inMultilineCom == true && inString == false)
                        {
                            inMultilineCom = false;
                            inSinglelineCom = false;
                            continue;
                        }
                        else if (line[i] == '\'' && inSinglelineCom == false && inMultilineCom == false && inSingleQuotedStr == false && inDoubleQuotedStr == false)
                        {
                            if (i > 0 && line[i - 1] == '\\')
                            {
                                continue;
                            }
                            inSingleQuotedStr = true;
                            inString = true;
                            continue;
                        }
                        else if (line[i] == '\'' && inSinglelineCom == false && inMultilineCom == false && inSingleQuotedStr == true && inDoubleQuotedStr == false) /////!!!
                        {
                            if (i > 0 && line[i - 1] == '\\')
                            {
                                continue;
                            }
                            inSingleQuotedStr = false;
                            inString = false;
                        }
                        else if (line[i] == '"' && inSingleQuotedStr == false && inMultilineCom == false && inSinglelineCom == false && inDoubleQuotedStr == false)
                        {
                            if (i > 0 && line[i - 1] == '\\')
                            {
                                continue;
                            }                       
                            inString = true;
                            inDoubleQuotedStr = true;                            
                            continue;
                        }
                        else if (line[i] == '"' && inSingleQuotedStr == false && inMultilineCom == false && inSinglelineCom == false && inDoubleQuotedStr == true)
                        {
                            if (i > 0 && line[i - 1] == '\\')
                            {
                                continue;
                            }
                            inString = false;
                            inDoubleQuotedStr = false;
                        }
                        else if (line[i] == '$' && inSinglelineCom == false && inMultilineCom == false && inVariableDec == false)
                        {
                            if (i > 0 && line[i - 1] == '\\')
                            {
                                continue;
                            }
                            if (i < line.Length - 1 && (char.IsLetter(line[i + 1]) || line[i + 1] == '_'))
                            {
                                inVariableDec = true;
                            }
                            continue;
                        }
                        else if (inVariableDec == true && (char.IsLetterOrDigit(line[i]) == false && line[i] != '_'))
                        {
                            inVariableDec = false;
                            if (phpVars.ContainsKey(variable.ToString()) == false)
                            {
                                phpVars.Add(variable.ToString(), 1);
                            }
                            variable.Clear();
                        }

                        if (inVariableDec == true && (char.IsLetterOrDigit(line[i]) || line[i] == '_' ))
                        {
                            variable.Append(line[i]);
                        }                       
                    }
                }
            //}
            Console.WriteLine(phpVars.Count);
            foreach (var var in phpVars)
            {
                Console.WriteLine(var.Key);
            }
        }
    }
}
