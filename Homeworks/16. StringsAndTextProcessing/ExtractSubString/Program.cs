using System;
using System.Linq;

namespace ExtractSubString
{
    class Program
    {
        //Write a program that extracts from a given text all sentences containing given word.
        //Example: The word is "in". The text is:
        //We are living in a yellow submarine. We don't have anything else. 
        //Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.

        //The expected result is:
        //We are living in a yellow submarine.
        //We will move out of it in 5 days.

        //Consider that the sentences are separated by "." and the words – by non-letter symbols.

        static void Main(string[] args)
        {
            string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            string[] sentences = text.Split('.');

            foreach (string sentence in sentences)
            {
                string[] words = sentence.Split(' ');

                if(words.Contains("in")){
                    Console.WriteLine(sentence);
                }
            }

        }
    }
}
