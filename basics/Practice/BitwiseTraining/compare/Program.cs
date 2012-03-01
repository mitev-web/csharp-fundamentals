using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace compare
{
    class Program
    {
        static void Main(string[] args)
        {
            int x=  4;
            int y = -6;


            bool f = ((x ^ y) < 0);

            if (f)
            {
                Console.WriteLine("x and y have opposite signs");

            }
            else
            {
                Console.WriteLine("x and y have same signs");
            }
        }
    }
}
