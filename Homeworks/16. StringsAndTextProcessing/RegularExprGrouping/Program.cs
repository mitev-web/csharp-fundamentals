using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ReplaceRegions
{
    class ReplaceRegions
    {
        //You are given a text. Write a program that changes 
        //the text in all regions surrounded by the tags 
        //<upcase> and </upcase> to uppercase. 
        //The tags cannot be nested. Example:
        static void Main(string[] args)
        {
            string text = "You are given a text. <upcase>Write a program that changes " +
                          "the text in all regions surrounded by the tags to uppercase.</upcase> ererer ";

            string pattern = @"(?<normalTextStart>.*)<upcase>(?<upperText>.*)</upcase>(?<normalTextEnd>.*)";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);
            foreach (Match match in matches)
            {
                Console.Write(match.Groups["normalTextStart"]);
                Console.Write(match.Groups["upperText"].ToString().ToUpper());
                Console.Write(match.Groups["normalTextEnd"]);
            }
        }
    }
}