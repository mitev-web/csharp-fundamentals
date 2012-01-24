using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FillString
{
    class Program
    {
        //Write a program that reads from the console a string of maximum 20 characters. 
        //If the length of the string is less than 20, the rest of the characters 
        //should be filled with '*'. Print the result string into the console.

        static void Main(string[] args)
        {
            string name = "pesho";
            StringBuilder sb = new StringBuilder();
            if (name.Length < 20)
            {

                sb.Append(name);
                for (int i = 0; i < 20-name.Length; i++)
                {
                    sb.Append("*");
                }

            }
            Console.WriteLine(sb.ToString());

        }
    }
}
