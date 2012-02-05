using System;
using System.Linq;

namespace IntegerException
{
    class Program
    {
        //Write a program that reads an integer number and
        //calculates and prints its square root. If the
        //number is invalid or negative, print "Invalid number".
        //In all cases finally print "Good bye". Use try-catch-finally.

        static void Main(string[] args)
        {
            try
            {
                int N = int.Parse(Console.ReadLine());
                Console.WriteLine(Math.Sqrt(N));
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid number");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Bye bye!");
            }
        }
    }
}