using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Crossword
{
    static int N;

    static char[,] board;
    //static List<string> words = new List<string> { "FIRE", "ACID", "CENG", "EDGE", "FACE", "ICED", "RING", "CERN" };

    static List<string> words = new List<string>();
    static List<string> crossWords = new List<string>(); 

    static void Main(string[] args)
    {
        N = int.Parse(Console.ReadLine());
        board = new char[N * 2, N];
        for (int i = 0; i < N*2; i++)
        {
            words.Add(Console.ReadLine());
        }

        FillBoard();
        CheckForCrosswords();

        PrintResult();
    }
  
    private static void PrintResult()
    {
        if (crossWords.Count >= N)
        {
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(crossWords[i]);
            }
        }
        else
        {
            Console.WriteLine("NO SOLUTION!");
        }
    }
  
    private static void FillBoard()
    {
        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < N; col++)
            {
                board[row, col] = words[row][col];
            }
        }
    }

    private static void CheckForCrosswords()
    {
        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < N; col++)
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < N; i++)
                {
                    sb.Append(board[row + i, col]);
                }
                string word = sb.ToString();
                if (words.Contains(word) && word.Length == N)
                {
                    crossWords.Add(word);
                }

                sb.Clear();
            }
        }
    }
}