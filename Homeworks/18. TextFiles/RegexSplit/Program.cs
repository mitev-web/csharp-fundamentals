using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CompareTextFiles
{
    class Program
    {
        static void Main(string[] args)
        {
                string filePath1 = "../../../file_1.txt";
                string filePath2 = "../../../file_2.txt";
                string text1 = FileToString(filePath1);
                string text2 = FileToString(filePath2);

                string[] linesFile1 = Regex.Split(text1, "\r\n");
                string[] linesFile2 = Regex.Split(text2, "\r\n");


                for (int i = 0; i < linesFile1.Count(); i++)
                {
                    Console.Write("Line: {0}:",i+1);
                    if (linesFile1[i] == linesFile2[i])
                    {
                        Console.WriteLine("Match");
                    }
                    else
                    {
                        Console.WriteLine("Different");
                    }
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


        static long CountLinesInString(string s)
        {
            long count = 1;
            int start = 0;
            while ((start = s.IndexOf('\n', start)) != -1)
            {
                count++;
                start++;
            }
            return count;
        }
    }
}
