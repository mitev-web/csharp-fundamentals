using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write an if statement that examines two integer variables and exchanges their values
            //if the first one is greater than the second one.

            Console.WriteLine("Please enter integer");
            int firstNumber;
            string line = Console.ReadLine();
            int.TryParse(line, out firstNumber);

            Console.WriteLine("Please enter integer");
            int secondNumber;
            line = Console.ReadLine();
            int.TryParse(line, out secondNumber);

            int tempNumber;
            if (firstNumber > secondNumber)
            {
                tempNumber = firstNumber;
                firstNumber = secondNumber;
                secondNumber = tempNumber;
            }

        }
    }
}
