using System;
using System.Linq;


namespace DecimalToBinary
{
    class Program
    {
        static void Main(string[] args)
            //Write a program to convert 
            //decimal numbers to their binary representation.
        {
            int number = 17;

            Console.WriteLine(ConvertIntToBinary(number));

        }


        static string ConvertIntToBinary(int number)
        {
            string binaryNumber = "";

            while (number > 0)
            {
                binaryNumber += number % 2;
                number /= 2;
            }

            char[] arr = binaryNumber.ToCharArray();
            Array.Reverse(arr);

            return new string(arr);
        }

    }
}
