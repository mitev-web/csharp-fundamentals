using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PHPVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            string code = "";
            string newLine = Environment.NewLine;
            string currentLine = "";
            int newLineIndex = 0;
            StringBuilder codeLines = new StringBuilder();
            string varName = "";
            int varCount = 0;
            int varIndex = 0;
            List<string> listOfVariables = new List<string>();

            while (Console.ReadLine() == "?>")
            {
                codeLines = codeLines.Append(Console.ReadLine());
            }
            code = codeLines.ToString();
            code += "?>";

            if(code.IndexOf("/*") != -1 &&  code.IndexOf("*/") != -1)
            {
                while(code.IndexOf("/*") == -1)
                {
                    code.Remove(code.IndexOf("/*"),code.IndexOf("*/")-code.IndexOf("/*"));
                }
            }

            newLineIndex = code.IndexOf(newLine);

            while(currentLine == "?>")
            {
                newLineIndex++;
                currentLine = code.Substring(newLineIndex,code.IndexOf(newLine,newLineIndex) - newLineIndex);

                if(currentLine.IndexOf("//") == 0 || currentLine[0] == '#')
                {
                   continue;
                }
                while (currentLine.IndexOf('$',varCount) == -1)
                 {
                     if (currentLine[currentLine.IndexOf('$') - 1] == '\\')
                     {
                         continue;
                     }
                     varIndex = currentLine.IndexOf('$', varIndex) + 1;
                    while ((currentLine[varIndex] >= '0' && currentLine[varIndex] <= '9') || (currentLine[varIndex] >= 'A' && currentLine[varIndex] <= 'Z') || (currentLine[varIndex] >= 'a' && currentLine[varIndex] <= 'z') || currentLine[varIndex] == '_')
                    {
                        varIndex++;
                    }
                    varName = currentLine.Substring(currentLine.IndexOf('$') + 1, varIndex-1);
                    listOfVariables.Add(varName);
                    varCount++;
                 }
                
                
            }

            for (int i = 0; i < listOfVariables.Count; i++)
            {
                Console.WriteLine(listOfVariables[i]);
            }
        }
    }
}