using System;
using System.IO;
using System.Linq;
using System.Text;

class CompareTextFiles
{
    static void Main(string[] args)
    {
        //Write a program that compares two text files line by line and prints
        //the number of lines that are the same and the number of lines that 
        //are different. Assume the files have equal number of lines.
        // Create two readers with the Cyrillic encoding
        StreamReader firstStreamReader = new StreamReader("../../Files/file_1.txt");
        StreamReader secondStreamReader = new StreamReader("../../Files/file_2.txt");

        // Create counters for the same and the different text lines
        int counterOfEqualLines = 0;
        int counterOfDifferentLines = 0;

        // Use the two StreamReaders
        using (firstStreamReader)
        {
            using (secondStreamReader)
            {
                string firstFileLines = "";
                string secondFileLines = "";

                // Read the lines of the two text files
                firstFileLines = firstStreamReader.ReadLine();
                secondFileLines = secondStreamReader.ReadLine();
                while (secondFileLines != null)
                {
                    // Compare the two text files line by line 
                    if (firstFileLines.CompareTo(secondFileLines) == 0)
                    {
                        counterOfEqualLines++;
                    }
                    else
                    {
                        counterOfDifferentLines++;
                    }
                    firstFileLines = firstStreamReader.ReadLine();
                    secondFileLines = secondStreamReader.ReadLine();
                }
            }
        }

        // Print the number of same and the different lines 
        Console.WriteLine("The number of lines that are the same is: {0}",
            counterOfEqualLines);
        Console.WriteLine("The number of lines that are different is: {0}",
            counterOfDifferentLines);
    }
}