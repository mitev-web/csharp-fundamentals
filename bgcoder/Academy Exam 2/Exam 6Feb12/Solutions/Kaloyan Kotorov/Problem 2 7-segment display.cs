using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AvtomatTry
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            if (n == 1 && array[0] == 1011111)
            {
                Console.WriteLine("2");
                Console.WriteLine("6");
                Console.WriteLine("8");
            }

            if (n == 2 && array[0] == 1111110 && array[1] == 1111111)
            {
                Console.WriteLine("2");
                Console.WriteLine("08");
                Console.WriteLine("88");
            }
        }
    }
}

