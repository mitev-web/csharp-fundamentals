using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackReverseNumbers
{
    class Program
    {
        //Write a program that reads N integers
        //from the console and reverses them
        //using a stack. Use the Stack<int> class.

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

            Stack<int> stack = new Stack<int>();
            foreach (var item in numbers)
            {
                stack.Push(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        
        }
    }
}
