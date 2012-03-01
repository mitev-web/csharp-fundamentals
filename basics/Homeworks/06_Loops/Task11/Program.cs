using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task11
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that prints all possible cards from a standard deck 
            //of 52 cards (without jokers). The cards should be printed with their 
            //English names. Use nested for loops and switch-case.

            string[] cardTypes = new String[] { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };

            foreach (string card in cardTypes)
            {
                for (int i = 0; i < 4; i++)
                {
                    switch (i)
                    {
                        case 0: Console.WriteLine("{0} of Spades", card); break;
                        case 1: Console.WriteLine("{0} of Hearths", card); break;
                        case 2: Console.WriteLine("{0} of Diamonds", card); break;
                        case 3: Console.WriteLine("{0} of Clubs", card); break;
                    }
                }

            }
        }
    }
}
