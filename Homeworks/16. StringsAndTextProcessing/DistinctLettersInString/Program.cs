using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DistinctLettersInString
{
    class Program
    {
        //Write a program that reads a string from the 
        //console and replaces all series of consecutive 
        //identical letters with a single one. 
        //Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".
        static void Main(string[] args)
        {
            //string str = "aaaaabbbbbcdddeeeedssaa";
            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < str.Length-1; i++)
            //{
            //    if (str[i] != str[i+1])
            //    {
            //        sb.Append(str[i]);
            //    }
                
            //}
            //if (str[str.Length - 2] == str[str.Length - 1] && str.Length > 1)
            //{
            //    sb.Append(str[str.Length - 1]);
            //}
            //Console.WriteLine(sb.ToString());


            DeleteRepeatingLetters();
        }

        static void DeleteRepeatingLetters()
        {
          //  Regex deleteRepeatingLetters = new Regex("(.)(?<=\\1\1)+",RegexOptions.IgnoreCase);
          ////  Console.Write("Enter sentence: ");
          //  string text = "aaaaabbbbbcdddeeeedssaa";
          //  text = deleteRepeatingLetters.Replace(text, string.Empty);
          //  Console.WriteLine("Result is: {0}",text);



        }
     
    }
}