using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    class HelloWorld
    {
        static void Main(string[] args)
        {
            //Write a method that asks the user for his name and prints “Hello, <name>” (for example, “Hello, Peter!”). Write a program to test this method.

            Hello();
            
        }
        public static void Hello(){

            Console.WriteLine("What's your name");
            string name = Console.ReadLine();

            Console.WriteLine("Hello {0} !", name);
        }
    }
}
