using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise04
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare an integer variable and assign it with the value 254 in hexadecimal format. 
            //Use Windows Calculator to find its hexadecimal representation.

            string hexValue = "FE";
            int decimalNumber = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);

            Console.WriteLine("the number {0} in hex format is equal to {1} in decimal format", hexValue, decimalNumber);

        }
    }
}
