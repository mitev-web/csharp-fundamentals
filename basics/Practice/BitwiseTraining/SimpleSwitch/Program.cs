using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
                        int a = 7;
            int b = 5;
            Console.WriteLine(Convert.ToString(a, 2).PadLeft(32, '0'));
            Console.WriteLine(Convert.ToString(b, 2).PadLeft(32, '0'));
            Console.WriteLine("a=");
            a =  a^ b;
            Console.WriteLine(Convert.ToString(a, 2).PadLeft(32, '0'));
            Console.WriteLine("b=");
            b = b^a;
            Console.WriteLine(Convert.ToString(b, 2).PadLeft(32, '0'));
            a = a^b;
            Console.WriteLine("a=");
            Console.WriteLine(Convert.ToString(a, 2).PadLeft(32, '0'));

            Console.WriteLine("a is {0} b is {1}",a,b);




        }
    }
}
