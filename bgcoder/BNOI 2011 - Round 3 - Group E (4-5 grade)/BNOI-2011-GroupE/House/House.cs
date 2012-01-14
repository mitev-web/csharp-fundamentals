using System;
using System.Linq;

class House
{
    static void Main(string[] args)
    {
        string[] numbers = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None);

        int N = int.Parse(numbers[0]);
        int K = int.Parse(numbers[1]);

        int whiteCount = N - 1;

        //the pokriv of the kushta
        for (int i = 1; i <= N; i++, whiteCount--)
        {
            for (int j = 0; j < whiteCount; j++)
                Console.Write(" ");

            for (int j = 1; j <= i; j++)
                Console.Write("/");

            for (int j = 1; j <= i; j++)
                Console.Write("\\");

            Console.WriteLine();
        }

        //purviq etaj
        for (int i = 1; i <= K; i++)
        {
            for (int j = 1; j <= (N - K); j++)
                Console.Write(" ");

            for (int j = 1; j <= K * 2; j++)
                Console.Write("=");

            Console.WriteLine();
        }
    }
}