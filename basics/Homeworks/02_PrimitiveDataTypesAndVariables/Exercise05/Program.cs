using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise05
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare a character variable and assign it with the symbol that has Unicode code 72.
            //Hint: first use the Windows Calculator to find the hexadecimal representation of 72.

            char newChar;
            //in hex
            //newChar = '\u048f';

            //in unicode
            newChar = '\u0072';
   

            Console.WriteLine("The character is {0}", newChar);
        }
    }
}
