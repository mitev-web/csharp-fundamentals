using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryToDecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program to convert binary 
            //numbers to their decimal representation.


            string binaryNumber = "11111111";

      
            Console.WriteLine(ConvertBinaryToInt(binaryNumber));
        }


        public static int ConvertBinaryToInt(string binaryNumber)
        {
            int number = 0;
            int k = binaryNumber.Length-1;
            int temp = 0;

            for (int i = 0; i < binaryNumber.Length; i++, k--)
            {
                temp = 2*int.Parse(binaryNumber[k].ToString());
                number += (int)Math.Pow(temp, i);
            }
            return number;
        }
    }
}
