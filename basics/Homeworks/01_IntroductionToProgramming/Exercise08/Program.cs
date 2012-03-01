using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise08
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 12345;
            int square = (int)Math.Pow(number, 2);

            Console.WriteLine("Square of {0} is {1}", number, square);

        }
    }
}
