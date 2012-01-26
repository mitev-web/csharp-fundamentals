using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ExtractEmails
{
    class Program
    {
        //Write a program for extracting all the email addresses from given text.
        //All substrings that match the format <identifier>@<host>… <domain> 
        //should be recognized as emails.

        static void Main(string[] args)
        {
            string text = "Also visit <a href=www.devbg.org>" +
              " dd orum</a> to discuss pesho@abv.bg the courses.</p> Also visit mary.ana@gmail.com <a href=www.devbg.org>" +
              " our forum</a> seliandur@yahoo.com to discuss the courses.</p>";

            string[] words = text.Split(' ');

            foreach (var item in words)
            {
                if (isEmail(item))
                {
                    Console.WriteLine(item);
                }
            }

        }

        public static bool isEmail(string word)
        {
            string pattern = @"[a-z0-9]{3,15}@(.*?)\.([a-z]{2,4})";
            Regex regex = new Regex(pattern);

            if (regex.IsMatch(word))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
