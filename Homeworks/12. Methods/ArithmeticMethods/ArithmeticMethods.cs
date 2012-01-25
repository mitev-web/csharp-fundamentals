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
            decimal[] numbers = { 2, 4, 5, 4, -4, 0, 13, 43, 13, 55, 33, -99 };

            Console.WriteLine(GetMin(numbers));
        }

        private static T GetMin<T>(T[] arr) where T : IComparable<T>
        {
            T min = default(T);
            foreach (T item in arr)
            {
                if (item.CompareTo(min) < 0)
                {
                    min = item;
                }
            }
            return min;
        }

        private static object GetMax<T>(T[] arr) where T : IComparable<T>
        {
            T max = default(T);
            foreach (T item in arr)
            {
                if (item.CompareTo(max) > 0)
                {
                    max = item;
                }
            }
            return max;
        }

        private static T GetAverage<T>(T[] arr)
        {
            dynamic sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            dynamic result = sum / arr.Length;
            return result;
        }

        private static T GetSum<T>(T[] arr)
        {
            dynamic sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }
    }
}