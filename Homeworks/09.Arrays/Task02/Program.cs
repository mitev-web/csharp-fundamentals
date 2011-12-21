using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that reads two arrays from the console and 
            //compares them element by element.
            Console.WriteLine("enter size of the arrays");
            uint size = 0;
            uint.TryParse(Console.ReadLine(), out size);
            int[] array1 = new int[size];
            int[] array2 = new int[size];

            for (int i = 0; i < size; i++)
            {
                array1[i] = int.Parse(Console.ReadLine());
                array2[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("array1 element {0}: {1} \n array2 element {0}: {2}", i, array1[i], array2[i]);
            }
        }
    }
}
