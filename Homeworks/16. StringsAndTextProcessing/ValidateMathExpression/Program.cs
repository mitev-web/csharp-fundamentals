using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidateMathExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            List<char> openBrackets = new List<char>();
            List<char> closedBrackets = new List<char>();
            foreach (char c in expression)
            {
                if (c == '(')
                {
                    openBrackets.Add(c);
                }
                else if (c == ')')
                {
                    closedBrackets.Add(c);
                }
            }

            if (closedBrackets.Count != openBrackets.Count)
            {
                Console.WriteLine("invalid expression");
            }
            else
            {
                Console.WriteLine("there is possibility for this expression being correct");
            }
        }
    }
}
