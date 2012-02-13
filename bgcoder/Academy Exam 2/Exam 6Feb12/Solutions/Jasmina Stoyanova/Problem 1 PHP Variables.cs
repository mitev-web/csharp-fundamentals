using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Task01
{
    class Program
    {
        static string StripComments(string code)
        {
            var re = @"(@(?:""[^""]*"")+|""(?:[^""\n\\]+|\\.)*""|'(?:[^'\n\\]+|\\.)*')|//.*|/\*(?s:.*?)\*/";
            return Regex.Replace(code, re, "$1");
        } 

        static void Main(string[] args)
        {
            string inputCode = Console.ReadLine();
            string str = StripComments(inputCode);

            StringBuilder sb = new StringBuilder();
            string strCode;
            List<string> code;

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == '$')
                {
                    while (Char.IsLetterOrDigit(str[i + 1]) || str[i + 1] == '_')
                    {

                        sb.Append(str[i + 1]);


                        i++;

                    }
                    sb.Append(" ");
                }
            }

            strCode = sb.ToString();
            code = new List<string>(strCode.Split(' '));

            for (int i = 0; i < code.Count; i++)
            {
                for (int j = i + 1; j < code.Count; j++)
                {
                    if (code[i] == code[j])
                    {
                        code.Remove(code[j]);
                    }
                }

            }

            for (int i = 0; i < code.Count; i++)
            {
                if (code[i] == String.Empty)
                {
                    code.Remove(String.Empty);
                }
            }

            Console.WriteLine(code.Count);

            for (int i = 0; i < code.Count; i++)
            {
                string inputString = code[i];

                StringBuilder sb1 = new StringBuilder();

                for (int j = 0; j < inputString.Length; j++)
                {
                    sb1.Append(String.Format("\\u{0:x4}", Convert.ToInt16(inputString[j])));
                }

                Console.WriteLine(sb1.ToString());
            } 
        }
    }
}
