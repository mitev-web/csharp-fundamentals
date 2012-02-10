using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


class HowEasy
{

    static void Main(){
    }


  public int pointVal(string problemStatement)
    {
        MatchCollection matches = Regex.Matches(problemStatement, @"[^\.][\w+]{1,}\.|[^\.][\w+]{1,}");
        int wordCount = matches.Count;
        int wordLength = 0;
        int averageWordLenght = 0;
        foreach (Match m in matches)
        {
            wordLength += m.ToString().Length;
        }

        averageWordLenght = wordLength / wordCount;

        if (averageWordLenght <= 3)
        {
            return 250;
        }
        else if (averageWordLenght == 4 || averageWordLenght == 5)
        {
            return 500;
        }
        else
        {
            return 1000;
        }
    }
}
