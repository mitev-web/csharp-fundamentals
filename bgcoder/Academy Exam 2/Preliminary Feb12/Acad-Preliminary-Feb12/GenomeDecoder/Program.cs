using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class GenomeDecoder
{
    static int N;
    static int M;

    static string encoded;

    static void Main(string[] args)
    {
        string line = Console.ReadLine();

        N = int.Parse(line.Split(' ')[0]);
        M = int.Parse(line.Split(' ')[1]);
        encoded = Console.ReadLine();

        //N = 1000;
        //M = 1;
        //encoded = "10000A12345G67890TC";

        string genome = DecodeGenome();
 
        StringBuilder sb = new StringBuilder();
        
        int maxRowNumber = (int)Math.Ceiling((decimal)genome.Length / (decimal)N);
        int padSize = maxRowNumber.ToString().Length;

        for (int i = 1; i <= maxRowNumber; i++)
        {
            sb.Append(new string(' ', padSize - i.ToString().Length));
            sb.Append(i);
            sb.Append(" ");
            int counter = 1;
            for (int j = 0; j < N; j++)
            {
                if (genome.Length > j)
                    sb.Append(genome[j]);
                if (N - M > j && M == counter)
                {
                    sb.Append(" ");
                    counter = 0;
                }
                counter++;
            }
            if (i != maxRowNumber)
            {
                genome = genome.Substring(N, genome.Length - N);
                sb.Append(Environment.NewLine);
            }
        }

        //StreamWriter sw = new StreamWriter(@"..\..\text.txt");
        //sw.Write(sb.ToString());
        //sw.Close();
            
        Console.WriteLine(sb.ToString().TrimEnd());
    }

    private static string DecodeGenome()
    {
        string genom = string.Empty;
        StringBuilder sb = new StringBuilder();

        foreach (Match e in new Regex(@"[0-9]+\w|\w").Matches(encoded))
        {
            genom = e.ToString();
            int multiplier = 0;

            foreach (Match f in new Regex(@"(?<numb>[0-9]+)(?<word>\w)|(?<word>\w)").Matches(genom))
            {
                if (!int.TryParse(f.Groups["numb"].ToString(), out multiplier))
                {
                    multiplier = 1;
                }

                sb.Append(Convert.ToChar(f.Groups["word"].ToString()), multiplier);
            }
        }

        return sb.ToString();
    }
    //split string in chunks
    static IEnumerable<string> Split(string str, int chunkSize)
    {
        return Enumerable.Range(0, str.Length / chunkSize)
                         .Select(i => str.Substring(i * chunkSize, chunkSize));
    }
}