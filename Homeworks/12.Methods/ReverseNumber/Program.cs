using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReverseNumber
{
    class Program
    {
        //Write a method that reverses the digits of given decimal number. Example: 256  652

        static void Main(string[] args)
        {
            int number = 242719;
            Console.WriteLine(ReverseNumber(number));
        }


        public static int ReverseNumber(int number)
        {

            string reversed = "";
            while (number > 0)
            {
                reversed += number % 10;
                number /= 10;
            }

            return int.Parse(reversed);

        }
    }
}
