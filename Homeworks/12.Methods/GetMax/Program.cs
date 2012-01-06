using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetMax
{
    class Program
    {
        //Write a method GetMax() with two parameters that returns the bigger of two integers. 
        //Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().

        static void Main(string[] args)
        {
            int a = 5;
            int b = 6;
            int c = 7;
            Console.WriteLine(GetMax(5,7,11)); 
        }

        public static int GetMax(int a, int b, int c){

            int biggest = a;
            if (b > biggest) biggest = b;
            if (c > biggest) biggest = c;
            return biggest;

        }
    }
}
