using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Basic
{
    class Program
    {
        static string input = "5 X=-1" +Environment.NewLine+
                            "6 IF X=-1 THEN X=0" + Environment.NewLine +
                            "7 PRINT X" + Environment.NewLine +
                            "8 CLS" + Environment.NewLine +
                            "10 PRINT X" + Environment.NewLine +
                            "20 X=X+1" + Environment.NewLine +
                            "30 IF X < 4 THEN GOTO 10" + Environment.NewLine +
                            "40 STOP" + Environment.NewLine +
                            "50 PRINT X" + Environment.NewLine +
                            "RUN";
        static void Main(string[] args)
        {

            foreach (Match m in Regex.Matches(input, @"(?<lineNumber>[0-9]+)\s(?<expression>.*)"))
            {
                Console.Write(m.Groups["lineNumber"].ToString());

                //Console.Write(m.Groups["expression"].ToString());



            }


        }
    }
}
