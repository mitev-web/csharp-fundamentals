﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RemovePrefix
{
    class Program
    {
        static void Main(string[] args)
        {
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
