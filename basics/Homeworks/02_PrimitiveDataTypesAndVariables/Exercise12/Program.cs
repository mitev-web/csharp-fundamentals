using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise12
{
    class Program
    {
        static void Main(string[] args)
        {
            //Find online more information about ASCII (American Standard Code for Information Interchange)
            //and write a program that prints the entire ASCII table of characters on the console.

            for (int i = 0; i < 127; i++)
            {
                Console.Write((char)i);
            }

        }
    }
}
