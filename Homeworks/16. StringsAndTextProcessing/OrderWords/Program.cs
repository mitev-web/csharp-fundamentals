using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderWords
{
    class Words
    {
        //Write a program that reads a list of words,
        //separated by spaces and prints the list in an alphabetical order.
        static void Main(string[] args)
        {
            string[] words = "ala bala nica pesho e mekica".Split(' ');
            Array.Sort(words);

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }


    }
}