using System;
using System.Linq;

namespace StringToUnicodeChars
{
    class Program
    {
        //Write a program that converts a string to a 
        //sequence of C# Unicode character literals. Use format strings. Sample input:

        //Hi!
        //Expected output:
        //\u0048\u0069\u0021



        static void Main(string[] args)
        {
            Console.Write("Enter a string: ");
            string inputLine = Console.ReadLine();
            int[] array = new int[inputLine.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (int)inputLine[i];
            }
            string result = "";
            foreach (int item in array)
            {
                string temp = string.Format("\\u{0:X4}", item);
                result = result + temp;
            }
            Console.WriteLine("Result: {0}", result);
        }
    }
}
