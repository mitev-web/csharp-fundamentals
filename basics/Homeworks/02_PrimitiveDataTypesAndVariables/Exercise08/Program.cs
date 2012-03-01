using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise08
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare two string variables and assign them with following value:
            //The "use" of quotations causes difficulties.
            //Do the above in two different ways: with and without using quoted strings.

            string firstWay = "The \"use\" of quotations causes difficulties.";
            string secondWay = @"The ""use"" of quotations causes difficulties.";

            Console.WriteLine("{0} \n{1}", firstWay, secondWay);

        }
    }
}
