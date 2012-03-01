using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task12
{
    class Program
    {
        static void Main(string[] args)
        {
            //We are given integer number n, value v (v=0 or 1) and a position p. 
            //Write a sequence of operators that modifies n to hold the value v at the position p from the binary representation of n.

            Console.WriteLine("Please enter integer");
            int n;
            string line = Console.ReadLine();
            int.TryParse(line, out n);

            Console.WriteLine("binary repr of n");
            Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));

            Console.WriteLine("Please enter value 1 or 0");
            byte v;
            line = Console.ReadLine();
            byte.TryParse(line, out v);


            Console.WriteLine("Please enter position p");
            byte p;
            line = Console.ReadLine();
            byte.TryParse(line, out p);

            if (v == 0)
            {
                n &= ~(1 << p);
            }
            else
            {
                n |=  (1 << p);
            }
 
            Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));
        }
    }
}
