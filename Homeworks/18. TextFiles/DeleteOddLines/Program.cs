﻿using System;
using System.IO;
using System.Linq;
using System.Text;

namespace DeleteOddLines
{
    class Program
    {
        //Write a program that deletes from given 
        //text file all odd lines. The result should be in the same file.

        static void Main(string[] args)
        {
            string filePath = "../../../remove_odd.txt";
                            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                int counter = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    if (counter % 2 == 1)
                    {
                        sb.Append(line);
                        sb.Append(Environment.NewLine);
                    }

                    counter++;
                }
            }

            StreamWriter sw = new StreamWriter(filePath);
            sw.Write(sb.ToString());
            sw.Close();
        }

      
    }
}
