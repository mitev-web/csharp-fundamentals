using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncreasingOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            bool input = true;
            List<int> numbers = new List<int>();
            int temp = 0;
            while (input)
            {
                if (int.TryParse(Console.ReadLine(), out temp))
                {
                    numbers.Add(temp);
                }
                else
                {
                    input = false;
                }
            }


            numbers = (from s in numbers
                     orderby s ascending
                     select s).ToList();

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
