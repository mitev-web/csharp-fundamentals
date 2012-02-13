using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5.Brackets_v2
{
    class Program
    {
        static void Main (string[] args)
        {
            string input = Console.ReadLine ();
            int n = input.Length;
            int variants = n/2 - 1;
            Console.WriteLine (variants);
        }
    }
}
