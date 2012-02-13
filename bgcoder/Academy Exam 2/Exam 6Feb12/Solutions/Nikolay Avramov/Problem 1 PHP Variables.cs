using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace Exaam2
{
    class PhP
    {
        static bool isValid = true;

        static List<string> SortMe(List<string> input)
        {
            List<string> newList = new List<string>(); 
            try
            {
                newList =
                    input.OrderByDescending(p => p[0] == '_').
                    ThenBy (p => p[1]).
                    ThenBy (p => p[0]). 
                    ToList();
            }
            catch (System.IndexOutOfRangeException)
            {
                return (newList);
            }
            return (newList);
        }

        static bool Validation(char var)
        {
            isValid = true;
                
            if ((var < '0' )||( var > '9' && var < 'A')||(var > 'Z' && var <'a'&& var != '_' )||(var >'z'))
            {
                isValid = false;
            }
            return (isValid);
        }

        static void Main(string[] args)
        {
            string input = null;
            

            StringBuilder str = new StringBuilder(input);
            while (input != "?>")
            {
                input = Console.ReadLine();
                str.Append(input);
                str.Append("\r\n");
            }
            StringBuilder vars = new StringBuilder();
            List<string> MyList = new List<string>();

            char currentChar;
            bool stringMode = false;
            bool commentMode = false;
            
            for (int i = 0; i < str.Length; i++)
			{
                currentChar = str[i];
                if ((currentChar == '"'||(currentChar == 39))&&!commentMode&&!stringMode)
                {
                    stringMode = true;
                }
                else if ((currentChar == '"' || (currentChar == 39)) && stringMode)
                {
                    stringMode = false;
                }
                else if ((currentChar == '#' || (currentChar == '/' && str[i + 1] == '/')) && !stringMode)
                {
                    
                    while (currentChar != '\n')
                    {
                        i++;
                        currentChar = str[i];
                    }
                    commentMode = false;
                }
                else if (currentChar == '/' && str[i + 1] == '*' && !commentMode)
                {
                    i += 2;
                    currentChar = str[i];
                    while (currentChar != '*' && str[i + 1] != '/')
                    {
                        i++;
                        currentChar = str[i];
                    }
                    currentChar = str[i + 2];
                    commentMode = false;
                }
                // Append the chars of the variables
                if ((currentChar == '$' && !commentMode) && str[i - 1] != 92 && str[i - 2] != 92)
                {
                    
                    i++;
                    currentChar = str[i];
                    while (Validation(currentChar))
	                {
                        vars.Append(currentChar);
                        i++;
                        currentChar = str[i];
	                }
                    if (MyList.IndexOf(vars.ToString()) < 0)
                    {
                        MyList.Add(vars.ToString());
                    }
                    vars.Clear();
                    i--;
                    
                }

            }
            string[] arr = new string[MyList.Count];
            if (MyList.Count != 0)
            {
                arr = SortMe(MyList).ToArray();
            }
            Console.WriteLine(MyList.Count);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            
        }
    }
}
