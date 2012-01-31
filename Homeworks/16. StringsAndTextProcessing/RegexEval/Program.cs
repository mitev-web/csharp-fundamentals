using System;
using System.Linq;
using System;
using System.Text.RegularExpressions;

namespace RegexEval
{
    class TagUpCase
    {
        static void Main()
        {
            string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
            Console.WriteLine(TagBasedConvertRegex(text));
        }

        static string TagBasedConvertRegex(string input)
        {
            Regex r = new Regex("(<upcase>)(.+?)(</upcase>)");

            MatchEvaluator eval = new MatchEvaluator(Replace);

            string result = r.Replace(input, eval);
            return result;
        }

        static string Replace(Match m)
        {
            return m.Result("$2").ToString().ToUpper();
        }
    }
}