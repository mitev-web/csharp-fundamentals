using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CountDistinctChars
{
    class Program
    {
        //Write a program that reads a string from the 
        //console and prints all different letters 
        //in the string along with information 
        //how many times each letter is found. 
        static void Main(string[] args)
        {
            string text = "Also visit <a href=www.devbg.org>" +
                          " dd orum</a> to discuss ABA pesho@abv.bg the courses.</p> Also visit mary.ana@gmail.com <a href=www.devbg.org>" +
                          " our forum</a> andes1sedna seliandur@yahoo.com to fafa discuss affathe courses.</p>";
            char[] alpha = "abcdefghijklmnopqrstuvwxyzxABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            Dictionary<char, int> dict = new Dictionary<char, int>();

            foreach (char item in text)
            {
                if (alpha.Contains(item))
                {
                    if (dict.ContainsKey(item))
                    {
                        dict[item]++;
                    }
                    else
                    {
                        dict.Add(item, 1);
                    }
                }
            }

            foreach (var item in dict)
            {
                Console.WriteLine("The letter {0} exists {1} times", item.Key, item.Value);
            }
        }
    }
}