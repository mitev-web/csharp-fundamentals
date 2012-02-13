using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P1_GenomeDecoder
{
    class Program
    {
        static void Main(string[] args)
        {
            int lineFeeds = 3;
            int whiteSpace = 2;
            List<Tuple<int, char>> data;

            string input = "AGTC90000G";


            //N = 1000;
            //M = 1;
            //encoded = "10000A12345G67890TC";


            //input = Console.ReadLine();
            //lineFeeds = int.Parse(input.Split(' ')[0]);
            //whiteSpace = int.Parse(input.Split(' ')[1]);
            //input = Console.ReadLine();


            data = parseData(input);

            string output = formatData(data, lineFeeds, whiteSpace);
            Console.WriteLine(output);
        }


        public static List<Tuple<int, char>> parseData(string input)
        {
            List<Tuple<int, char>> data = new List<Tuple<int, char>>();
            int enumerator = 0;

            for (int i = 0; i < input.Length; enumerator++, i = enumerator)
            {
                while ((int)input[enumerator] >= 48 && (int)input[enumerator] < 58)
                {
                    enumerator++;
                }
                if (enumerator - i == 0)
                {
                    data.Add(new Tuple<int, char>(1, input[enumerator]));
                }
                else
                {
                    data.Add(new Tuple<int, char>(int.Parse(input.Substring(i, enumerator - i)), input[enumerator]));
                }
            }
            return data;
        }

        // Faster, more memory
        public static string formatData(List<Tuple<int, char>> input, int lineFeeds, int whiteSpace)
        {
            StringBuilder data = new StringBuilder();

            // Make tuples into one big string
            for (int i = 0; i < input.Count; i++)
            {
                data.Append(input[i].Item2, input[i].Item1);
            }

            // Calc padding for line numbers
            int padding = (int)Math.Log(data.Length / lineFeeds + 1, 10) + 1;

            // Build formatted string
            StringBuilder data2 = new StringBuilder(data.Length + (data.Length / lineFeeds + 1) * (padding + 2) + ((data.Length / lineFeeds) * (lineFeeds / whiteSpace)));
            int whiteSpaceCounter = 0;
            int lineFeedCounter = 0;

            data2.Append((1).ToString().PadLeft(padding) + " ");
            for (int i = 0; i < data.Length; )
            {
                if (lineFeedCounter == lineFeeds)
                {
                    data2.Append("\n" + (i / lineFeeds + 1).ToString().PadLeft(padding) + " ");
                    lineFeedCounter = 0;
                    whiteSpaceCounter = 0;
                }
                else
                {
                    if (whiteSpaceCounter == whiteSpace)
                    {
                        data2.Append(' ');
                        whiteSpaceCounter = 0;
                    }
                    else
                    {
                        data2.Append(data[i]);
                        i++;
                        whiteSpaceCounter++;
                        lineFeedCounter++;
                    }
                }
            }

            return data2.ToString();
        }

        // Slower speed, less memory usage
        public static string formatData2(List<Tuple<int, char>> input, int lineFeeds, int whiteSpace)
        {
            StringBuilder data = new StringBuilder();

            // Make tuples into one big string
            for (int i = 0; i < input.Count; i++)
            {
                data.Append(input[i].Item2, input[i].Item1);
            }

            // Calc padding for line numbers
            int padding = (int)Math.Log(data.Length / lineFeeds + 1, 10) + 1;

            // Format that string
            for (int i = data.Length - 1; i >= 0; i--)
            {
                int linePosition = i % lineFeeds;
                if (linePosition == 0)
                {
                    data.Insert(i, "\n" + (i / lineFeeds + 1).ToString().PadLeft(padding) + " ");
                }
                if (linePosition % whiteSpace == 0 && linePosition != 0)
                {
                    data.Insert(i, ' ');
                }
            }
            data.Remove(0, 1);

            return data.ToString();
        }
    }
}