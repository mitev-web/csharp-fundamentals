using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ExtractHTML
{
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


            string pattern = @".*<title>(?<title>.*)</title>.*<body>(?<body>.*)</body>";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(htmlPage);
            foreach (Match match in matches)
            {
                Console.WriteLine("Title Tag:");

                Console.WriteLine(match.Groups["title"]);
                Console.WriteLine("Body Tag:");
                Console.Write(match.Groups["body"]);

      
            }


        }
    }
}

