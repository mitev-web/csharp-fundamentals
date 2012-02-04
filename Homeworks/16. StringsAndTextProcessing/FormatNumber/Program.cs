using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormatNumber
{
    class Program
    {
        //Write a program that reads a number and prints it as a decimal number, 
        //hexadecimal number, percentage and in scientific notation. 
        //Format the output aligned right in 15 symbols.

        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            string inputStr = Console.ReadLine();
            int number = int.Parse(inputStr);
            string decOutput = String.Format("{0,15:D}", number);
            Console.WriteLine("{0}(dec)", decOutput);
            string hexOutput = String.Format("{0,15:X}", number);
            Console.WriteLine("{0}(hex)", hexOutput);
            string perOutput = String.Format("{0,15:P2}", number);
            Console.WriteLine("{0}", perOutput);
            string scientOutput = String.Format("{0,15:#.##e+00}", number);
            Console.WriteLine("{0}", scientOutput);
        }
    }
}
