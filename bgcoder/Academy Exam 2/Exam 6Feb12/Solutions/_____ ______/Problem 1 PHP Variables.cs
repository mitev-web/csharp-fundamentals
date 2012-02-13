using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1
{
    class PHPVariables
    {
        static void Main()
        {
            StringBuilder input = new StringBuilder();
            string inputLine = Console.ReadLine();
            while (inputLine != "?>")
            {
                input.Append("\n");
                input.Append(inputLine);
                inputLine = Console.ReadLine();
            }
            //string thePHPCode = "<?php $browser = $_SERVER['HTTP_USER_AGENT']    ; $arr = array(); $arr[$zero]    = $browser;    var_dump($arr);  ?>";
            //string thePHPCode = "<?php /* This is $var1 in comments */ \n $var3 = \"Some string \\$var4 with var escaped. \"; \n echo $var5; echo(\"$foo,$bar\"); \n // Another comment with variable $var2";
            //string thePHPCode = "<?php \n # this is $comment \n $valid_var='\"text\"'...{$valid_var}'; \n $just=\"Just another var $Just...\";$just=$code;\n?>";
            string thePHPCode = input.ToString();
            bool isVar = false;
            bool inComment = false;
            bool escaped = false;
            bool inString1 = false;
            bool inString2 = false;
            StringBuilder varPHP = new StringBuilder();
            List<string> allVars = new List<string>();
            foreach (char symbol in thePHPCode)
            {
                //comments 
                if (symbol == '#' || symbol == '/')
                {
                    inComment = true;
                    continue;
                }
                if (inComment == true)
                {
                    if (symbol == '\n' || symbol == '/')
                    {
                        inComment = false;
                        continue;
                    }
                    
                }
                //strings
                if (symbol == '"' && inString1 != true)
                {
                    inString1 = true;
                    continue;
                }
                if (inString1 == true)
                {
                    if (symbol == '\\')
                    {
                        escaped = true;
                    }
                    if (escaped == true && symbol == ' ')
                    {
                        escaped = false;
                        //what if we have an escaped var, and after that a non-escaped var?
                    }
                    if (symbol == '"')
                    {
                        inString1 = false;
                        escaped = false;
                        continue;
                    }
                }
                //other strings
                if (symbol == '\'' && inString2 != true)
                {
                    inString2 = true;
                    continue;
                }
                if (inString2 == true)
                {
                    if (symbol == '\\')
                    {
                        escaped = true;
                    }
                    if (escaped == true && symbol == ' ')
                    {
                        escaped = false;
                        //what if we have an escaped var, and after that a non-escaped var?
                    }
                    if (symbol == '\'')
                    {
                        inString2 = false;
                        escaped = false;
                        continue;
                    }
                }
                //vars
                if (symbol == '$' && inComment != true && escaped != true)
                {
                    isVar = true;
                    continue;
                }
                if (isVar == true)
                {
                    if (symbol != ' ' && symbol != '=' && symbol != '[' && symbol != ']' && symbol != '(' && symbol != ')' && symbol != '{' && symbol != '}' && symbol != ';' && symbol != ',' && symbol != '"' && symbol != '\'' && symbol != '\'' && symbol != '.')
                    {
                        varPHP.Append(symbol);
                    }
                    else
                    {
                        bool contains = allVars.Contains(varPHP.ToString());
                        if (contains == false)
                        {
                            allVars.Add(varPHP.ToString());
                        }
                        varPHP.Clear();
                        isVar = false;
                    }
                     
                }
            }
            Console.WriteLine(allVars.Count);
            allVars.Sort();
            for (int i = 0; i < allVars.Count; i++)
            {
                Console.WriteLine(allVars[i]);
            }
            
        }
    }
}
