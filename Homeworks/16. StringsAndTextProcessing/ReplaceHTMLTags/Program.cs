using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ReplaceHTMLTags
{
    class Program
    {
        //Write a program that replaces in a HTML document
        //given as string all the tags <a href="…">…</a>
        //with corresponding tags [URL=…]…/URL]. Sample HTML fragment:
        //<p>Please visit <a href="http://academy.telerik. com">our site</a>

        //to choose a training course. Also visit <a href="www.devbg.org">
        //our forum</a> to discuss the courses.</p>

        //<p>Please visit [URL=http://academy.telerik. com]our site[/URL] to 
        //choose a training course. Also visit [URL=www.devbg.org]our forum[/URL] 
        //to discuss the courses.</p>
        static void Main(string[] args)
        {
            string text = "Also visit <a href=www.devbg.org>" +
                          " dd orum</a> to discuss the courses.</p> Also visit <a href=www.devbg.org>" +
                          " our forum</a> to discuss the courses.</p>";


            //string regex = @"((www\.|(http|https|ftp|news|file)+\:\/\/)[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])";
            //Regex r = new Regex(regex, RegexOptions.IgnoreCase);
            //return r.Replace(msg, "<a href=\"$1\" title=\"Click to open in a new window or tab\" target=\"&#95;blank\">$1</a>").Replace("href=\"www", "href=\"http://www");

            string pattern = @"<a href=(.*)>(.*)</a>";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);



            text = Regex.Replace(text, pattern, "[URL=$1]$2[/URL]");

            Console.WriteLine(text);
           
        }
    }
}