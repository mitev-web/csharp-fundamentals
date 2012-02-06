using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class GenomeDecoder
{
    static int N = 9;
    static int M = 4;

    static string encoded = "18A13C10T10GA18GT17C";

    static void Main(string[] args)
    {
        string genome = DecodeGenome();
        bool printing = true;
        int counter = 1;
        StringBuilder sb = new StringBuilder();
        
        int maxRowNumber = (int)Math.Ceiling((decimal)genome.Length / (decimal)N);
        int padSize = maxRowNumber.ToString().Length;

        //for (int i = 1; i <= maxRowNumber; i++)
        //{
        //    StringBuilder line = new StringBuilder();
        //    line.Append(new string(' ', padSize - i.ToString().Length));
        //    line.Append(i);
        //    for (int j = (i - 1) * N; j <= i * N - 1; j++)
        //    {
        //        if ((j - (i - 1) * N) % M == 0) line.Append(' ');
        //        if (j >= genome.Length) break;
        //        line.Append(genome[j]);
        //    }
        //    Console.WriteLine(line.ToString());
        //}

        //Regex regex = new Regex(@"(\w{" + M + "})");

        //string crazyGenome = regex.Replace(genome, "$1 ");
     

        for (int i = 1; i <= maxRowNumber; i++)
        {
            sb.Append(new string(' ', padSize - i.ToString().Length));
            sb.Append(i);
            sb.Append(" ");
            for (int j = 0; j <= N; j++)
            {
                if(genome.Length > j)
                sb.Append(genome[j]);
                if (j == M)
                {
                     sb.Append(" ");
                }
            }
            if((genome.Length-N) > N)
            genome = genome.Substring(N, genome.Length - N);
            sb.Append(Environment.NewLine);
        }
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

    static IEnumerable<string> Split(string str, int chunkSize)
    {
        return Enumerable.Range(0, str.Length / chunkSize)
                         .Select(i => str.Substring(i * chunkSize, chunkSize));
    }
}