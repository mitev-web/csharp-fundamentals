using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReverseString
{
    class Program
    {
        //Describe the strings in C#. What is typical for the string data type? D
        //    escribe the most important methods of the String class.
        //

        //Write a program that reads a string, 
        //reverses it and prints it on the console. Example: "sample"  "elpmas".

        static void Main(string[] args)
        {
            Console.WriteLine(StringReverse("sample"));
        }

        public static string StringReverse(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = s.Length - 1; i >= 0; i--)
                sb.Append(s[i]);
            return sb.ToString();
        }

    }
}
