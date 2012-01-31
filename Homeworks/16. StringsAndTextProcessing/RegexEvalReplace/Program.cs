using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace RegexEvalReplace
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
                          " our blog</a> to discuss the courses.</p>yo";

            string pattern = @"(.*?)<a href=(.*?)>(.*?)</a>(.*?)";

            Regex regex = new Regex(pattern);

            MatchEvaluator eval = new MatchEvaluator(Replace);
            string result = regex.Replace(text, eval);

            Console.WriteLine(result);
        }


        static string Replace(Match m)
        {
            return m.Result("$1[URL=$2]$3[/URL]$4");
        }
    }
}
