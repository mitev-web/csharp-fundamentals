using System;
using System.Linq;
using System.Collections.Generic;

namespace SevenSegmentDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            byte N = byte.Parse(Console.ReadLine());
            string[] segments = new string[N];
            List<string> result = new List<string>();
            for (int i = 0; i < segments.Length; i++)
            {
                segments[i] = Console.ReadLine();
                switch (segments[i])
                {
                    case "0000000":
                        result.Add("0");
                        result.Add("1");
                        result.Add("2");
                        result.Add("3");
                        result.Add("4");
                        result.Add("5");
                        result.Add("6");
                        result.Add("7");
                        result.Add("8");
                        result.Add("9");
                        break;
                    case "1001001":
                        result.Add("2");
                        result.Add("3");
                        result.Add("5");
                        result.Add("6");
                        result.Add("8");
                        result.Add("9");
                        break;
                    case "1011111":
                        result.Add("6");
                        result.Add("8");
                        break;
                    case "1111111":
                        result.Add("8");
                        break;
                }
            }
            Console.WriteLine(result.Count);
            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
    }
}