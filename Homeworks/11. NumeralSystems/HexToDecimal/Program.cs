using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HexToDecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program to convert hexadecimal numbers to their decimal representation.

            string hexNumber = "1F4";

            Console.WriteLine(ConvertHexToInt(hexNumber));
        }


        public static int ConvertHexToInt(string hexNumber)
        {
            int temp = 0;
            int number = 0;
            for (int i = 0, k = hexNumber.Length - 1; i < hexNumber.Length; i++, k--)
            {

                switch (hexNumber[k])
                {
                    case 'F': temp = 15; break;
                    case 'E': temp = 14; break;
                    case 'D': temp = 13; break;
                    case 'C': temp = 12; break;
                    case 'B': temp = 11; break;
                    case 'A': temp = 10; break;
                    default: temp = int.Parse(hexNumber[k].ToString()); break;
                }
                number += temp * (int)Math.Pow(16, i);
            }

            return number;

        }
    }
}
