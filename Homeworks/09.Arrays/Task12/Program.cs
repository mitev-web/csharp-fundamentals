using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task12
{
    class Program
    {
        static void Main(string[] args)
        {
           // Write a program that creates an array containing all letters from the alphabet
           //(A-Z). Read a word from the console and print the index of each of its letters 
           // in the array.


            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string word = Console.ReadLine();

            word = word.ToUpper();

            foreach (char c in word)
            {

                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (c == alphabet[i])
                    {
                        Console.WriteLine("index of {0} is {1}", c, i);
                    }
                }

            }
        }
    }
}
