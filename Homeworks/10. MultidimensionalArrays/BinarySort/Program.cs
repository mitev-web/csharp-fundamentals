using System;
using System.Linq;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program, that reads from the console an array
            //    of N integers and an integer K, sorts the array and 
            //using the method Array.BinSearch() finds the largest number 
            //in the array which is ≤ K. 


            int k = 77;

            int[] array = { 3, 25, 42, 55, 68, 72 };

            

            Array.Sort(array);
            int position = Array.BinarySearch(array, k);
            Console.WriteLine(position);


              if (k < array[0])
             {
                Console.WriteLine("There is no such number.");
            }
            else
            {
                if (position < 0)
                    position = -2 - position;
                Console.Write("The number is: ");
                Console.WriteLine(array[position]);
            }

        }
    }
}
