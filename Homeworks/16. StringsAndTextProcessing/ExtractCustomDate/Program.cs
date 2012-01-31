using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ExtractCustomDate
{
    class Program
    {
        //Write a program that extracts from a given text
        //all the dates that match the format DD.MM.YYYY.
        //Display them in the standard date format for Canada.
        static void Main(string[] args)
        {
            string text = "sdfsdfsdf 22.11.2012 sdfkspdofkpsdof 30.11.2010 sdf";

            string pattern = @"[0-3][0-9]\.[0-1][0-9]\.[0-9]{4}";

            Regex regex = new Regex(pattern); 

            foreach (var item in regex.Matches(text))
            {
                Console.WriteLine(item);
            }
        }
    }
} 
