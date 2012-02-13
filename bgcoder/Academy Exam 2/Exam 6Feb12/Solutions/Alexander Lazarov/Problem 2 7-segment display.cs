using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApplication2
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static StringBuilder result= new StringBuilder();
        static int count =0;
        static string s;
        static string[] diggits =
            {
                "1111110",
                "0110000",
                "1101101",
                "1111001",
                "0110011",
                "1011011",
                "1011111",
                "1110000",
                "1111111",
                "1111011"
            };
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] numbers = new string[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = Console.ReadLine();
            }
            FindZeroOrOne('0',0,0);
            Console.WriteLine(count);
            string res = result.ToString();
            Console.WriteLine(result);
           
        }
        static void Compareit(string s)
        {
            for (int i = 0; i < diggits.Length; i++)
            {
                if(Regex.IsMatch(diggits[i],s))
                {
                    result.Append(i);
                    count++;
                }
            }
        }
        static void FindZeroOrOne(char number,int counter,int deeperer)
        {
            if (counter < diggits.Length && counter >= 0 && deeperer < diggits[counter].Length && deeperer >= 0)
            {
                s = diggits[counter];
                char ch = s[deeperer];
                if (ch == number)
                {
                    sb.Append(number);
                }
                else if (sb.Length == diggits.Length - 1)
                {
                    string compare = sb.ToString();
                    Compareit(compare);
                }
                else
                {
                    FindZeroOrOne('1', counter + 1, deeperer + 1);
                    FindZeroOrOne('0', counter - 1, deeperer - 1);
                }
            }
                    
                }
            }
        }
    
    
