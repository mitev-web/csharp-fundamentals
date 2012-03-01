using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise11
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare  two integer variables and assign them with 5 and 10 and after that exchange their values.
            int firstNumber = 5;
            int secondNumber = 10;
            int tempNumber;

            tempNumber = firstNumber;
            firstNumber = secondNumber;
            secondNumber = tempNumber;

            Console.WriteLine("value of firstNumber is {0}, value of secondNumber is {1}", firstNumber, secondNumber);

        }
    }
}
