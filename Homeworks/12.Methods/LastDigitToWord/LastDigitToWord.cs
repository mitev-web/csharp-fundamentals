using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LastDigitToWord
{
    class ConvLastDigitToWord
    {
        static void Main(string[] args)
        {
            //Write a method that returns the last digit of given integer as an English word. 
            //Examples: 512  "two", 1024  "four", 12309  "nine".

            int number = 325;

            Console.WriteLine(LastDigitToWord(325));
        }

        public static string LastDigitToWord(int number)
        {
            int lastDigit = number % 10;

            switch (lastDigit)
            {
                case 1: return "one"; break;
                case 2: return "two"; break;
                case 3: return "three"; break;
                case 4: return "four"; break;
                case 5: return "five"; break;
                case 6: return "six"; break;
                case 7: return "seven"; break;
                case 8: return "eight"; break;
                case 9: return "nine"; break;
                case 0: return "zero"; break;
            }

            return "";
        }
    }
}
