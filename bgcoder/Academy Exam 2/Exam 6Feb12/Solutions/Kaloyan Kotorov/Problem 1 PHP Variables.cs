using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRealTest2
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder inputPHP = new StringBuilder();
            string inputLine = "";
            while (inputLine != "?>")
            {
                inputLine = Console.ReadLine();
                inputPHP.AppendLine(inputLine);
            }
            bool isInComment = false;
            bool isInVariable = false;
            bool oneSlashState = false;
            bool twoStarState = false;
            bool isInStringState = false;
            bool escaped = false;
            int escapedCounter = 0;
            int slashCounter = 0;
            int starCounter = 0;
            int singleCommaCounter = 0;
            int doubleCommaCounter = 0;
            StringBuilder variable = new StringBuilder();
            List<string> variables = new List<string>();

            foreach (char ch in inputPHP.ToString())
            {
                if (isInComment == false && isInStringState == false && isInVariable == false)
                {
                    //IsInCommentState
                    
                    if (oneSlashState == true)
                    {
                        if (ch == '/')
                        {
                            isInComment = true;
                            slashCounter = 2;
                        }
                        if (ch == '*')
                        {
                            isInComment = true;
                            starCounter = 1;
                        }
                        else
                        {
                            oneSlashState = false;
                        }
                    }
                    if (ch == '/')
                    {
                        oneSlashState = true;
                    }
                    if (ch == '#')
                    {
                        isInComment = true;
                        slashCounter = 2;
                    }
                    //IsInStringState
                    if (ch == '\'')
                    {
                        isInStringState = true;
                        singleCommaCounter = 1;
                    }
                    if (ch == '\"')
                    {
                        isInStringState = true;
                        doubleCommaCounter = 1;
                    }
                    //IsInVariable
                    if (ch == '$')
                    {
                        isInVariable = true;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (isInComment == true)
                {
                    if (ch == '\n' && slashCounter == 2)
                    {
                        isInComment = false;
                        slashCounter = 0;
                    }
                    if (twoStarState == true)
                    {
                        if (ch == '/')
                        {
                            isInComment = false;
                            starCounter = 0;
                        }
                        else
                        {
                            twoStarState = false;
                        }
                    }
                    if (ch == '*' && starCounter == 1)
                    {
                        twoStarState = true;
                    }
                    
                }

                

                if (isInStringState == true)
                {
                    if (ch == '\\')
                    {
                        escaped = true;
                    }
                    if (escaped == true)
                    {
                        escapedCounter++;
                    }
                    if (escapedCounter == 2)
                    {
                        escaped = false;
                    }
                    if (ch == '$' && escaped == false && escapedCounter == 0)
                    {
                        isInVariable = true;
                    }
                    if (ch == '$' && escaped == false && escapedCounter == 2)
                    {
                        escapedCounter = 0;
                    }
                    
                    if (ch == '\'' && singleCommaCounter == 1)
                    {
                        isInStringState = false;
                        singleCommaCounter = 0;
                    }
                    if (ch == '\"' && doubleCommaCounter == 1)
                    {
                        isInStringState = false;
                        doubleCommaCounter = 0;
                    }
                }

                if (isInVariable == true)
                {
                    if (ch == '$')
                    {
                        continue;
                    }
                    if ((ch >= '0' && ch <= '9') || (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || ch == '_')
                    {
                        variable.Append(ch);
                    }
                    else
                    {
                        isInVariable = false;
                        variables.Add(variable.ToString());
                        variable.Clear();
                    }
                }
            }
            
            variables.Sort();
            List<string> theRealVars = variables.Distinct().ToList();
            Console.WriteLine(theRealVars.Count);
            foreach (string var in theRealVars)
            {
                Console.WriteLine(var);
            }
        }
    }
}