using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemoveOddOccurance
{
    class Program
    {
        //Write a program that removes from given 
        //sequence all numbers that occur odd 
        //number of times. Example:

        //{4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2}  {5, 3, 3, 5}

        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            numbers = (from e in numbers where ContainedTimes(e, numbers) % 2 == 0 select e).ToList();

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
        }

        public static int ContainedTimes(int number, List<int> numbers, int times = 0)
        {
            List<int> tempNumbers = new List<int>();
            tempNumbers.AddRange(numbers);

            if (tempNumbers.Contains(number))
            {
                tempNumbers.Remove(number);
                return ContainedTimes(number, tempNumbers, ++times);
            }
            else
            {
                return times;
            }
        }
    }
}