using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sort 3 real values in descending order using nested if statements.

            double a = 12.123;
            double b = -131.23;
            double c = 3;

            if (a > b && a > c)
            {
                if (b > c)
                {
                    Console.WriteLine("{0:F2} {1:F2} {2:F2}", a, b, c);
                }
                else
                {
                    Console.WriteLine("{0:F2} {1:F2} {2:F2}", a, c, b);

                }

            }
            else if (b > a & b > c)
            {
                if (a > c)
                {
                    Console.WriteLine("{0:F2} {1:F2} {2:F2}", b, a, c);
                }
                else
                {
                    Console.WriteLine("{0:F2} {1:F2} {2:F2}", b, c, a);
                }

            }
            else
            {
                if (b > a)
                {
                    Console.WriteLine("{0:F2} {1:F2} {2:F2}", c, b, a);
                }
                else
                {
                    Console.WriteLine("{0:F2} {1:F2} {2:F2}", c, a, b);
                }

            }
        }
    }
}
