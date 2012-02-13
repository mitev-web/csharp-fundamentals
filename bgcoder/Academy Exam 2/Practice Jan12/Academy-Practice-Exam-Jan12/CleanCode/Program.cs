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
            //             "class HardTest" + Environment.NewLine + Environment.NewLine +
            //             "{" + Environment.NewLine +
            //             " public HardMethod()" + Environment.NewLine +
            //             " {" + Environment.NewLine +
            //             "string str = @\"//not a " + Environment.NewLine +
            //             " comment ;)\";//(y)" + Environment.NewLine +
            //             "string str2 = \"/*no\"oo\\oo*/\";/*noo*/" + Environment.NewLine +
            //             " }" + Environment.NewLine +
            //             "}";
            string code = InputToString();

            bool inSingleLineComment = false;
            string singleLineComment = "//";
            string singleLineCommentClose = Environment.NewLine;

            bool inMultyLineComment = false;
            string multyComment = "/*";
            string multyCommentClose = "*/";

            bool inString = false;
            string inStringStart = "\"";

            bool inStringComment = false;
            string stringCommentStart = "@\"";
            string inStringEnd = "\";";

            bool notInClass = false;

            StringBuilder sb = new StringBuilder();

            string[] lines = Regex.Split(code, Environment.NewLine);

            for (int k = 0; k < lines.Length; k++)
            {
                string line = string.Empty;
                string l = lines[k];

                if (!l.Trim().StartsWith("//"))
                {
                    line = l + Environment.NewLine;
                }

                for (int i = 0; i < line.Length; i++)
                {
                    if (line.Trim().Length == 0)
                    {
                        continue;
                    }

                    if (line.Length - i > inStringStart.Length &&
                        line.Substring(i, inStringStart.Length) == inStringStart)
                    {
                        inString = true;
                    }
                    if (line.Length - i > inStringEnd.Length &&
                        line.Substring(i, inStringEnd.Length) == inStringEnd)
                    {
                        inString = false;
                    }

                    if (line.Length - i > multyComment.Length &&
                        line.Substring(i, multyComment.Length) == multyComment)
                    {
                        if (!inString)
                            inMultyLineComment = true;
                    }

                    if (line.Length - i > multyCommentClose.Length && i > 2 &&
                        line.Substring((i - 2), multyCommentClose.Length) == multyCommentClose)
                    {
                        inMultyLineComment = false;
                    }
                    if (l.Trim() == "}")
                    {
                        inMultyLineComment = false;
                    }

                    if (line.Length - i > stringCommentStart.Length &&
                        line.Substring(i, stringCommentStart.Length) == stringCommentStart)
                    {
                        inStringComment = true;
                    }

                    if (line.Length - i > inStringEnd.Length &&
                        line.Substring(i, inStringEnd.Length) == inStringEnd)
                    {
                        inStringComment = false;
                    }
                    if (!inStringComment)
                    {
                        if (line.Length - i > singleLineComment.Length &&
                            line.Substring(i, singleLineComment.Length) == singleLineComment)
                        {
                            inSingleLineComment = true;
                        }
                    }

                    if (line.Length - i > (singleLineCommentClose.Length - 1) &&
                        line.Substring(i, singleLineCommentClose.Length) == singleLineCommentClose)
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