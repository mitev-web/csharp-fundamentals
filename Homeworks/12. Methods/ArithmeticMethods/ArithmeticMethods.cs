using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArithmeticMethods
{
    class ArithmeticMethods
    {
        static void Main(string[] args)
        {

            decimal[] numbers = { 2, 4, 5, -4, 0, 13, 43, 13, 55, -99 };


            Console.WriteLine(GetMin(numbers));
        }


        private static T GetMin<T>(T[] arr)
        {
            return arr.Min();
        }

        private static object GetMax<T>(T[] arr)
        {
            return arr.Max();
        }

        //private static T GetAverage<T>(T[] arr)
        //{
        //    return arr.Average();
        //}

        //private static double GetSum<T>(T[] arr)
        //{
        //    return arr.Sum();
        //}
    }
}
