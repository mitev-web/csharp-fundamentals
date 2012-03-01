using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write an expression that calculates rectangle’s area by given width and height.
            int width;
            int height;
            Console.WriteLine("Please enter retangle's width");
            string line = Console.ReadLine();
            int.TryParse(line, out width);
            Console.WriteLine("Please enter retangle's height");
            line = Console.ReadLine();
            int.TryParse(line, out height);

            Console.WriteLine("The rectangle's area is {0}", width * height);


        }
    }
}
