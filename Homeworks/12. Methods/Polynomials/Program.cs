using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polynomials
{
    class Program
    {
        // Write a method that adds two polynomials. Represent them as arrays of their coefficients as in the example below:
        //		x2 + 5 = 1x2 + 0x + 5 -> 5 0 1
        //Extend the program to support also subtraction and multiplication of polynomials.
        static void Main(string[] args)
        {
            Console.Write("Polynome 1 (highest POW)= ");
            int n = int.Parse(Console.ReadLine());
            int[] ar1 = new int[n + 1];
            for (int i = 0; i < ar1.Length; i++)
            {
                Console.Write("X^{0}= ", i);
                ar1[i] = int.Parse(Console.ReadLine());
            }
            PrintPoly(ar1);
            Console.WriteLine();
            Console.Write("Polynome 2 (highest POW)= ");
            int m = int.Parse(Console.ReadLine());
            int[] ar2 = new int[m + 1];
            for (int i = 0; i < ar2.Length; i++)
            {
                Console.Write("X^{0}= ", i);
                ar2[i] = int.Parse(Console.ReadLine());
            }
            PrintPoly(ar2);
            Console.WriteLine();
            int[] ar3;
            ar3 = MultiplyPoly(ar1, ar2);
            PrintPoly(ar3);
            Console.ReadLine();
        }

        private static void PrintPoly(int[] array)
        {
            int count = 0;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] != 0)
                {
                    if (count == 0 || i == 0)
                    {
                        if (count == 0)
                        {
                            count++;
                            Console.Write("{0}X^{1}", array[i], i);
                        }
                        else if (array[i] > 0)
                        {
                            Console.Write("+{0}", array[i]);
                        }
                        else
                            Console.Write("{0}", array[i]);
                    }
                    else if (array[i] > 0)
                    {
                        Console.Write("+{0}X^{1}", array[i], i);
                    }
                    else
                        Console.Write("{0}X^{1}", array[i], i);
                }
            }
            Console.WriteLine();
        }

        public static int[] SumPoly(int[] polinome1, int[] polinome2)
        {
            int[] sumPolyArr = new int[Math.Max(polinome1.Length, polinome2.Length)];
            for (int i = 0; i < Math.Min(polinome1.Length, polinome2.Length); i++)
            {
                sumPolyArr[i] = polinome1[i] + polinome2[i];
            }
            if (polinome1.Length > polinome2.Length)
            {
                Array.Copy(polinome1, polinome2.Length, sumPolyArr, polinome2.Length, polinome1.Length - polinome2.Length);
            }
            if (polinome1.Length < polinome2.Length)
            {
                Array.Copy(polinome2, polinome1.Length, sumPolyArr, polinome1.Length, polinome2.Length - polinome1.Length);
            }
            return sumPolyArr;
        }

        public static int[] SubtractPoly(int[] polinome1, int[] polinome2)
        {
            for (int i = 0; i < polinome2.Length; i++)
            {
                polinome2[i] = -1 * polinome2[i];
            }
            return SumPoly(polinome1, polinome2);
        }

        public static int[] MultiplyPoly(int[] polinome1, int[] polinome2)
        {
            int[] multiply = new int[polinome1.Length + polinome2.Length];
            int[] temp = new int[polinome1.Length + polinome2.Length];
            for (int i = 0; i < polinome2.Length; i++)
            {
                for (int j = 0; j < polinome1.Length; j++)
                {
                    temp[i + j] = polinome1[i] * polinome2[j];
                }
                multiply = SumPoly(multiply, temp);

                for (int k = 0; k < temp.Length; k++)
                {
                    temp[k] = 0;
                }
            }
            return multiply;
        }
    }
}