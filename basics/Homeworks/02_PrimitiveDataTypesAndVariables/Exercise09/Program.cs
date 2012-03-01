using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise09
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that prints an isosceles triangle of 9 copyright symbols ©. 
            //Use Windows Character Map to find the Unicode code of the © symbol.

            char copyright = '\u00A9';

            Console.WriteLine("  {0}", copyright);
            Console.WriteLine(" {0} {0}", copyright);
            Console.WriteLine("{0} {0} {0}", copyright);

        }
    }
}
