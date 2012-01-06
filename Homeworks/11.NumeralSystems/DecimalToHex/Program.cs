using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecimalToHex
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program to convert decimal numbers
            //to their hexadecimal representation.

            int number = 41314;

            Console.WriteLine(ConvertDecimalToHex(number));
        }


        public static string ConvertDecimalToHex(int number)
        {
           

            string hexNumber = "";

            while (number > 0)
            {

                switch (number % 16)
                {
                    case 15: hexNumber += 'F'; break;
                    case 14: hexNumber += 'E'; break;
                    case 13: hexNumber += 'D'; break;
                    case 12: hexNumber += 'C'; break;
                    case 11: hexNumber += 'B'; break;
                    case 10: hexNumber += 'A'; break;
                    default: hexNumber += number % 16; break;
                }
          
              number /= 16;
            }

            char[] arr = hexNumber.ToCharArray();
            Array.Reverse(arr);

            return new string (arr);


        }
    }
}
