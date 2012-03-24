using System;
using System.IO;
using System.Linq;

namespace PrintOddLines
{
    class Program
    {
        //Write a program that reads a text file and 
        //prints on the console its odd lines.
        static void Main(string[] args)
        {
            string filePath = "../../Files/file_1.txt";

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                int lineNumber = 1;
                while ((line = sr.ReadLine()) != null)
                {
                    if (lineNumber % 2 == 1)
                        Console.WriteLine(line);

                    lineNumber++;
                }
            }
        }
    }
}