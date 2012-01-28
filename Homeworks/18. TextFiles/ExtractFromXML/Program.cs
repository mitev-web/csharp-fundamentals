using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ExtractFromXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "../../../student.xml";
            string text = FileToString(filePath);

            string pattern = @"\t+<.*?>(.*?)</.*?>|(.*xml.*)|<\w+>|</\w+>|<.*=.*>";

            Regex regex = new Regex(pattern);
            text = regex.Replace(text, "$1");


            //MatchCollection matches = regex.Matches(text);
            //foreach (Match m in matches)
            //{
            //    Console.WriteLine(m);
            //}

            //Console.WriteLine(regex.Replace(text, "$1"));
            string[] rows = text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var str in rows)
            {
                    Console.WriteLine(str);
            }
        }


        public static string FileToString(string filePath)
        {
            StringBuilder sb = new StringBuilder();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    sb.Append(line);
                    if (!sr.EndOfStream)
                        sb.Append(Environment.NewLine);
                }
            }

            return sb.ToString();
        }
    }
}
