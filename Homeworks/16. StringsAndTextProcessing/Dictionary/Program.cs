using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dictionary
{
    class Program
    {

        // A dictionary is stored as a sequence of text lines
        //containing words and their explanations. 
        //Write a program that enters a word and translates it by using the dictionary. Sample dictionary: 

        //        .NET – platform for applications from Microsoft
        //CLR – managed execution environment for .NET
        //namespace – hierarchical organization of classes

        static void Main(string[] args)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            dict.Add(".NET", "platform for applications from Microsoft");
            dict.Add("CLR", "managed execution environment for .NET");
            dict.Add("namespace", "hierarchical organization of classes");

            string word = Console.ReadLine();

            if (dict.ContainsKey(word))
            {
                Console.WriteLine(dict[word]);
            }
                
        }
    }
}
