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
            Console.WriteLine("Na kolko godini si chado?");
            string line = Console.ReadLine();
            int age;
            int.TryParse(line, out age);

            int yearsToAdd = 10;
            int newAge = age + yearsToAdd;

            Console.WriteLine("Sled {0} godini ste si na {1}", yearsToAdd, newAge);


        }
    }
}
