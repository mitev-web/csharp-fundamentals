using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {

            string text = Console.ReadLine();
            string[] words = text.Split('-');
            string name = words[0].Trim();
            string[] names = name.Split(' ');

            string fname = names[0];
            string lname = names[1];

            string position = words[1].Trim();

            Console.WriteLine(fname);
            Console.WriteLine(lname);
            Console.WriteLine(position);

        }
    }
}
