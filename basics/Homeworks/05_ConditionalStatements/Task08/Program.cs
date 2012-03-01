using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task08
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that, depending on the user's choice inputs int, double or string variable.
            //If the variable is integer or double, increases it with 1. 
            //If the variable is string, appends "*" at its end. 
            //The program must show the value of that variable as a console output. Use switch statement.

            Console.WriteLine("At your choice enter integer, double or string");
            int intNumb = 0;
            double doubleNumb = 0;
            string str = "";
            string input;
            string type;
            
            input = Console.ReadLine();
            if(int.TryParse(input, out intNumb)){
                type = "int";
            }
            else if (double.TryParse(input, out doubleNumb))
            {
                type = "double";
            }
            else
            {
                str = input;
                type = "string";
            }

            switch (type)
            {
                case "int": intNumb += 1; Console.WriteLine("Your choice was type:  {0} {1}",intNumb.GetType(),intNumb); break;
                case "double": doubleNumb += 1; Console.WriteLine("Your choice was type:  {0} {1}", doubleNumb.GetType(), doubleNumb); break;
                case "string": str += "*"; Console.WriteLine("Your choice was type:  {0} {1}", str.GetType(), str); break;
            }

        }
    }
}
