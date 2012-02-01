using System;
using System.Text.RegularExpressions;

namespace ReplaceHtmlTags
{
    class ReplaceHtmlTags
    {
        static void Main(string[] args)
        {
            Console.WriteLine("From [URL=...]...[/URL] to <a href=\"...\">...</a>");
            String firstSampleHtmlDocument = @"<p> Please visit [URL=http://academy.telerik.com] " +
                "our site[/URL] to choose a training course.</p>";
            Console.WriteLine(firstSampleHtmlDocument);

            // "[URL="  -> "<a href"
            // "\"]"    -> "\">"  
            // "[/URL]" -> "</a>" 

            string oldsPattern = @"\[URL=(?<url>[^\]]+)\](?<content>(.|\s)*?)\[/URL\]";
            string newsPattern = "<a href=\"${url}\">${content}</a>";
            string newfirstSampleHtmlDocument =
            Regex.Replace(firstSampleHtmlDocument, oldsPattern, newsPattern);
            Console.WriteLine(newfirstSampleHtmlDocument);
            Console.WriteLine();

            Console.WriteLine("From <a href=\"...\">...</a> to [URL=...]...[/URL]");
            String secondSampleHtmlDocument = "<p> Please visit <a href=\"http://academy.telerik.com\"> " +
                "our site</a> to choose a training course.</p>";

            Console.WriteLine(secondSampleHtmlDocument);

            // "<a href" -> "[URL="
            // "\">"     -> "\"]"
            // "</a>"    -> "[/URL]"

            string oldPattern = @"\<a href=\""(?<url>[^]]+)\""\>(?<content>(.|\s)*?)\</a\>";
            string newPattern = "[URL=${url}]${content}[/URL]";

            string newSecondSampleHtmlDocument =
                Regex.Replace(secondSampleHtmlDocument, oldPattern, newPattern);
            Console.WriteLine(newSecondSampleHtmlDocument);
            Console.WriteLine();
        }
    }
}