using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ExtractHTML
{
    //Write a program that extracts from given
    //HTML file its title (if available), and 
    //its body text without the HTML tags. Example:

    class Program
    {
        static void Main(string[] args)
        {
         
            string htmlPage =
                             "<html>" +
                             "<head><title>News</title></head>" +
                             "<body><p><a href=\"http://academy.telerik.com\">Telerik" +
                             "Academy</a>aims to provide free real-world practical" +
                             "training for young people who want to turn into" +
                             "skillful .NET software engineers.</p></body>" +
                             "</html>";

            string pattern = @".*<title>(?<title>.*)</title>.*<body>(?<body>.*<[^>]*>.*)</body>";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(htmlPage);
            string body = string.Empty;
            string title = string.Empty;

            foreach (Match match in matches)
            {
                title = match.Groups["title"].ToString();
                Console.WriteLine();
                body = match.Groups["body"].ToString();
            }
            Console.Write("Title Tag: ");
            Console.WriteLine(title);
            Console.Write("Body Tag: ");
            Console.WriteLine(Regex.Replace(body, @"</?(?:.*?)(.|\n)*?>", ""));

                
            //Console.WriteLine(RemoveAllTags(htmlPage));


        }
        private static string RemoveAllTags(string str)
        {
            string strWithoutTags = Regex.Replace(str, @"<[^>]*>",
                  " ");
            return strWithoutTags;
        }
    }

}