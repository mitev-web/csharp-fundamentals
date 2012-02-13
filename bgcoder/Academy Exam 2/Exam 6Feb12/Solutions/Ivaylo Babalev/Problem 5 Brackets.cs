using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            int length = expression.Length;
            int[] possibilities = new int[500];

            possibilities[2] = 0;
            int k = 2;
            for (int i = 4; i < possibilities.Length; i+=2)
            {
                possibilities[i] = possibilities[i-2] + k;
                k++;
            }

            if (!(expression.Contains('(') || expression.Contains(')')))
            {
                Console.WriteLine(possibilities[length]);
            }
        }
    }
}
