using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Majorant
{
    class Program
    {
        //* The majorant of an array of size N is 
        //a value that occurs in it at least N/2 + 1 times. 
        //    Write a program to find the majorant of given array (if exists). 
        //Example:
        //{2, 2, 3, 3, 2, 3, 4, 3, 3}  3
        public static List<int> allNumbers = new List<int> { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

        static void Main(string[] args)
        {
            



        }



        public static KeyValuePair<bool,int> ContainedTimes(int number, List<int> numbers, int times = 0)
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
                if (times > allNumbers.Count() / 2)
                {
                    new KeyValuePair<bool,int>()
                    return ;
                }
                else
                {
                    ret
                }
            }
        }
    }
}
