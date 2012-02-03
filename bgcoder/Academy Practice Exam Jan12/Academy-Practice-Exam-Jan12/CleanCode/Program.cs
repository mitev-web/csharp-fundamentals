using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CleanCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //string code =
            //             "using System; // no comment..." +Environment.NewLine+
            //             "class JustClass" +Environment.NewLine+
            //             "{ /* Just" +Environment.NewLine+
            //             "multiline" +Environment.NewLine+
            //             "comment  */private void JustMethod()" +Environment.NewLine+
            //             " {" +Environment.NewLine+
            //             "// string str=\"inception/*//*/" +Environment.NewLine+
            //             " }" +Environment.NewLine+
            //             "}";

           string code = InputToString();

            bool inSingleLineComment = false;
            string singleLineComment = "//";
            string singleLineCommentClose = Environment.NewLine;

            bool inMultyLineComment = false;
            string MultyComment = "/*";
            string multyCommentClose = "*/";

            StringBuilder sb = new StringBuilder();

            string[] lines = Regex.Split(code, Environment.NewLine);


            foreach (string l in lines)
            {
                string line = string.Empty;
                     
                if (!l.Trim().StartsWith("//"))
                {
                    line = l + Environment.NewLine;
                }
                for (int i = 0; i < line.Length; i++)
                {
                    if (line.Length - i > MultyComment.Length && line.Substring(i, MultyComment.Length) == MultyComment)
                    {
                        inMultyLineComment = true;
                    }
                    if (line.Length - i > multyCommentClose.Length && line.Substring(i, multyCommentClose.Length) == multyCommentClose)
                    {
                        i = i + MultyComment.Length;
                        inMultyLineComment = false;
                    }
                    if (line.Length - i > singleLineComment.Length && line.Substring(i, singleLineComment.Length) == singleLineComment)
                    {
                        inSingleLineComment = true;
                    }
                    //line.Length - i > singleLineCommentClose.Length &&
                    if (line.Length - i > (singleLineCommentClose.Length-1) && line.Substring(i, singleLineCommentClose.Length) == singleLineCommentClose)
                    {
                        inSingleLineComment = false;
                    }

                    if (!inMultyLineComment && !inSingleLineComment)
                    {
                        sb.Append(line[i]);
                    }
                }
            }
            Console.WriteLine(sb.ToString());
        }
  
        private static string InputToString()
        {
            int N = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < N; i++)
            {
                sb.Append(Console.ReadLine());
                sb.Append(Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }
    }
}