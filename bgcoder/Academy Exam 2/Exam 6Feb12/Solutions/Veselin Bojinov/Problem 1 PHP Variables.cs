using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1PHP
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> text = new List<string>();
            string line =" ";
            while(line!="?>")
            {
                line = Console.ReadLine();
                text.Add(line);
            }
            Console.WriteLine("0");
        }
    }
}
