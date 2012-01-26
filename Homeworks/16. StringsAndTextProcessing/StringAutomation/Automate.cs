using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Automate
{
    //You are given a text. Write a program that changes 
    //the text in all regions surrounded by the tags 
    //<upcase> and </upcase> to uppercase. 
    //The tags cannot be nested. Example:
    static void Main(string[] args)
    {
        string text = "<upcase>You</upcase> are given a text. <upcase>Write</upcase> a program that changes " +
                      "the text in all regions surrounded by the tags to uppercase. ";

        bool inUpperTag = false;
        string openBracket = "<upcase>";
        string closedBracket = "</upcase>";
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {

            if ((text.Length - i) > openBracket.Length && text.Substring(i, openBracket.Length) == openBracket)
            {
                i += openBracket.Length;
                inUpperTag = true;
            }

            if ((text.Length - i) > closedBracket.Length && text.Substring(i, closedBracket.Length) == closedBracket)
            {
                i += closedBracket.Length;
                inUpperTag = false;
            }

            if (inUpperTag)
            {
                sb.Append(text[i].ToString().ToUpper());
            }
            else
            {
                sb.Append(text[i]);
            }
        }

        Console.WriteLine(sb.ToString());
    }

}