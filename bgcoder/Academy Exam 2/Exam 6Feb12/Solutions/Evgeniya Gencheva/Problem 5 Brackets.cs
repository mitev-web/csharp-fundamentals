using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string brackest = Console.ReadLine();
            int numBr = 0;
            int numBrClose = 0;
            int numQ = 0;
            foreach (var item in brackest)
            {
                if (item == '(')
                {
                    numBr++;
                }
                else if (item == ')')
                {
                    numBrClose++;
                }
                else
                {
                    numQ++;
                }
            }
            if (numQ % 2 == 1)
            {
                if (numBr == numBrClose || (numBrClose == 0 && numBr == 0))
                {
                    Console.WriteLine("0");
                }
            }
        }
    }
}
