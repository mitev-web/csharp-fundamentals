using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShortToBinary
{
    class ShortToBinary
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter signed 16bit integer: ");
            string inputStr = Console.ReadLine();
            short number = short.Parse(inputStr);
            StringBuilder result = new StringBuilder();
            if (number >= 0)
            {
                int workingNum = number;
                for (int i = 0; i < 16; i++)
                {
                    int temp = workingNum % 2;
                    workingNum = workingNum / 2;
                    result.Insert(0, temp);
                }
            }
            else
            {
                int workingNum = Math.Abs(number) - 1;
                for (int i = 0; i < 16; i++)
                {
                    int temp = workingNum % 2;
                    workingNum = workingNum / 2;
                    if (temp == 0)
                    {
                        result.Insert(0, '1');
                    }
                    else
                    {
                        result.Insert(0, '0');
                    }
                }
            }
            Console.WriteLine("In Binary {0} equals {1}", inputStr, result.ToString());
        }
    }
}
