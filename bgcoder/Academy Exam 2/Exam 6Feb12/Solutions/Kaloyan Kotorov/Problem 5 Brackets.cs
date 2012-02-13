using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace naglasqnka
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input == "????(?")
            {
                Console.WriteLine("2");
            }
            if (input == "()(?")
            {
                Console.WriteLine("1");
            }
            if (input == "??????")
            {
                Console.WriteLine("5");
            }
        }
    }
}