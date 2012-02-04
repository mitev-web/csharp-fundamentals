using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace B_RegexEmails
{
    class ExtractEmailAddresses
    {
        static void Main(string[] args)
        {

            string text = @"Yesterday I was @thebar and saw strange man with T-shirt which says i.am.not@home. I asked him for his email and he said something like a@m.e. I said myemail@example.com and he finally gave his real email which was stupid@somewhere.he.he.";
            List<string> extracted = new List<string>();
            Regex regEx = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}\b", RegexOptions.IgnoreCase);
            Match match = regEx.Match(text);

            while (match.Success)
            {
                extracted.Add(match.Value);
                match = regEx.Match(text, match.Index + match.Length);
            }

            foreach (var email in extracted)
            {
                Console.WriteLine(email);
            }
        }
    }
}
