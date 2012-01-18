using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegerException
{
    class Program
    {
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
