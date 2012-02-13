using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PHP_Variable
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder brackets = new StringBuilder(Console.ReadLine());
            int br = brackets.Length;
            int counter = 0;
            int counterO = 0;
            int counterC = 0;

            if (brackets[0] == '?')
            {
                brackets.Replace('?', '(', 0, 1);
            }
            if (brackets[brackets.Length - 1] == '?')
            {
                brackets.Replace('?', ')', brackets.Length - 1, 1);
            }
            for (int i = 0; i < brackets.Length; i++)
            {
                if (brackets[i] == '(')
                {
                    counterO++;
                }
                if (brackets[i] == ')')
                {
                    counterC++;
                }
                if (counterO == counterC)
                {
                    counter = (counterC+counterO)/2;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
