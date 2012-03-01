using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise13
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a program that assigns null values to an integer and to double variables. 
            //Try to print them on the console, try to add some values or the null literal to them and see the result.

            int? testInt = null;
            double? testDouble = null;

            Console.WriteLine("integer value = {0}, double value = {1}", testInt, testDouble);
            testInt = testInt+5;

            testDouble = 22.01;
            Console.WriteLine("integer value = {0}, double value = {1}", testInt, testDouble);

        }
    }
}
