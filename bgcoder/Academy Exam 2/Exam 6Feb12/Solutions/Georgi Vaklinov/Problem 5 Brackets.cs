using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string input = Console.ReadLine();

            int count = 0;
            foreach (var ch in input)
            {
                if (ch == '?')
                {
                    count++;
                }
            }
            Console.WriteLine(count / 3 + input.Length - count);
        }}}