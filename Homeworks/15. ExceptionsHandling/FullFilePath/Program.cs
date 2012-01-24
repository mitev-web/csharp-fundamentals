using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FullFilePath
{
    class Program
    {
        //Write a program that enters file name along with its full file path
        //(e.g. C:\WINDOWS\win.ini), reads its contents and prints it on 
        //the console. Find in MSDN how to use System.IO.File.ReadAllText(…). 
        //Be sure to catch all possible exceptions and print user-friendly error messages.
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a file path");
            string filePath = Console.ReadLine();
            try
            {
                PrintFileContent(filePath);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid filePath format!");
                Console.WriteLine(e.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Your filename is too long!");
                Console.WriteLine(e.Message);
            }
        }

        private static void PrintFileContent(string filePath)
        {
            string readText = File.ReadAllText(filePath);
            Console.WriteLine(readText);
        }
    }
}