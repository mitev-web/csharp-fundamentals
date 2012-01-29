﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ReplaceString
{
    class Program
    {
        //Write a program that replaces all occurrences of the substring 
        //"start" with the substring "finish" in a text file. 
        //Ensure it will work with large files (e.g. 100 MB).
        static void Main(string[] args)
        {
            string filePath = "../../../replace_string.txt";
            string fileContent = string.Empty;

            fileContent = FileToString(filePath);
            string pattern = @".*(start).*";

            Stopwatch watch = new Stopwatch();
            watch.Start();
            //substrings
            //fileContent = Regex.Replace(fileContent, "start", "finish");
            //whole words
            fileContent = Regex.Replace(fileContent, @"(\s|^)start(\s)", "$1finish$2");

            watch.Stop();

            Console.WriteLine(watch.Elapsed);
            watch.Reset();
            watch.Start();
            StreamWriter sw = new StreamWriter("../../../replaced_string.txt");
            sw.Write(fileContent);
            sw.Close();
            watch.Stop();

            Console.WriteLine(watch.Elapsed);
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
                    sb.Append(Environment.NewLine);
                }
            }

            return sb.ToString();
        }
    }
}