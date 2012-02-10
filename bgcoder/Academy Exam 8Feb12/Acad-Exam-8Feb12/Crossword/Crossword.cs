using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

class Crossword
{
    //public static string[] words = { "FIRE", "ACID", "CENG", "EDGE", "FACE", "ICED", "RING", "CERN" };
    //static int N = 4;

    static int N;
    public static string[] words;
    static List<string> crossWords = new List<string>();

    static bool solutionFound;
    static char[,] board = new char[N, N];

    static void Main(string[] args)
    {
         InputWords();
        Stopwatch sw = Stopwatch.StartNew();

        int[] arr = new int[N * 2];

        GenerateVariations(arr, N * 2 - 1, N * 2 - 1);

        PrintResult();
        //sw.Stop();
        //Console.WriteLine(sw.ElapsedMilliseconds);
    }

    static void GenerateVariations(int[] arr, int startIndex, int endIndex)
    {
        if (solutionFound)
            return;

        if (startIndex == -1)
        {
            FindCrosswords(arr);
        }
        else
        {
            for (int i = 1; i <= endIndex; i++)
            {
                arr[startIndex] = i;

                GenerateVariations(arr, startIndex - 1, endIndex);
            }
        }
    }

    private static void InputWords()
    {
        N = int.Parse(Console.ReadLine());
        board = new char[N, N];
        words = new string[N * 2];
        for (int i = 0; i < N * 2; i++)
        {
            words[i] = Console.ReadLine();
        }
    }
  
    private static void PrintResult()
    {
        if (crossWords.Count > 0)
        {
            string e = (from s in crossWords
                        orderby s
                        select s).First();
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < N * N; i++)
            {
                if (i % N == 0)
                {
                    sb.Append(Environment.NewLine);
                }
                sb.Append(e[i]);
            }
            Console.WriteLine(sb.ToString().Trim());
        }
        else
        {
            Console.WriteLine("NO SOLUTION!");
        }
    }

    public static void PrintBoard()
    {
        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < N; col++)
            {
                Console.Write(board[row, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    private static bool IsCrossword()
    {
        StringBuilder sb = new StringBuilder();
        bool isCrossword = true;

        //check vertical
        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < N; col++)
            {
                sb.Append(board[row, col]);
            }

            if (!words.Contains(sb.ToString()))
            {
                isCrossword = false;
            }
            sb.Clear();
        }
        //check horizontal
        for (int col = 0; col < N; col++)
        {
            for (int row = 0; row < N; row++)
            {
                sb.Append(board[row, col]);
            }

            if (!words.Contains(sb.ToString()))
            {
                isCrossword = false;
            }
            sb.Clear();
        }

        return isCrossword;
    }

    private static string BoardToString()
    {
        StringBuilder sb = new StringBuilder();
        
        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < N; col++)
            {
                sb.Append(board[row, col]);
            }
        }
        return sb.ToString();
    }

    private static void FindCrosswords(int[] arr)
    {
        int count = 0;
        foreach (int word in arr)
        {
            for (int col = 0; col < N; col++)
            {
                if (count == N)
                {
                    if (IsCrossword())
                    {
                        solutionFound = true;
                        string boardStr = BoardToString();
                        if (!crossWords.Contains(boardStr))
                        {
                            crossWords.Add(boardStr);
                            return;
                        }
                    }

                    count = 0;
                }
                board[count, col] = words[word][col];
                //Console.Write(words[word][col]);
            }

            count++;
        }
        //Console.WriteLine();
    }
}