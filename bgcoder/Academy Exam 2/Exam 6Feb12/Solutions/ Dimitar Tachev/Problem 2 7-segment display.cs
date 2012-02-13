using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _22222222222222
{
    class Program
    {
        static List<int>[] possibles;
        static int maxPoss = 0;
        static int numbers = 0;
        static StringBuilder tempSegment = new StringBuilder();
        static string[] segments;
        static int combinations=0;
        static void Main(string[] args)
        {
            Inizialize();
            for (int i = 0; i < numbers; i++)
            {
                if (segments[i][6] == '0')
                {
                    possibles[i].Add(0);
                }
                if (segments[i][0] == 0 && segments[i][3] == 0 && segments[i][4] == 0 && segments[i][5] == 0 && segments[i][6] == 0)
                {
                    possibles[i].Add(1);
                }
                if (segments[i][2] == '0' && segments[i][5] == '0')
                {
                    possibles[i].Add(2);
                }
                if (segments[i][4] == '0' && segments[i][5] == '0')
                {
                    possibles[i].Add(3);
                }
                if (segments[i][0] == '0' && segments[i][3] == '0' && segments[i][4] == '0')
                {
                    possibles[i].Add(4);
                }
                if (segments[i][1] == '0' && segments[i][4] == '0')
                {
                    possibles[i].Add(5);
                }
                if (segments[i][1] == '0')
                {
                    possibles[i].Add(6);
                }
                if (segments[i][3] == '0' && segments[i][4] == '0' && segments[i][5] == '0' && segments[i][6] == '0')
                {
                    possibles[i].Add(7);
                }
                if (segments[i][4] == '0')
                {
                    possibles[i].Add(9);
                }
                possibles[i].Add(8);
            }
            PrintPossibilities();
            PRINT();
        }
        private static void Inizialize()
        {
            tempSegment.Append("0000000");
            numbers = int.Parse(Console.ReadLine());
            segments = new string[numbers];
            possibles = new List<int>[numbers];
            for (int i = 0; i < numbers; i++)
            {
                segments[i] = Console.ReadLine();
                possibles[i] = new List<int>();
            }
        }
        private static void PrintPossibilities()
        {
            combinations = 1;
            //       Console.WriteLine(totalNumbers);
            for (int i = 0; i < possibles.Length; i++)
            {
                //if (possibles[i].Count>maxPoss)
                //{
                //    maxPoss = possibles[i].Count;
                //}
                possibles[i].Sort();
                for (int j = 1; j < possibles[i].Count; j++)
                {
                    combinations *= 2;
                }
            }
            Console.WriteLine(combinations);
        }
        private static void PRINT()
        {
            StringBuilder[] totalArr = new StringBuilder[combinations];
            for (int i = 0; i < combinations; i++)
            {
                totalArr[i] = new StringBuilder();
                for (int j = 0; j < numbers; j++)
                {
                    if (i % possibles[j].Count==0)
                    {
                        totalArr[i].Append(possibles[j][possibles[j].Count - 1]);
                    }
                    else
                    totalArr[i].Append(possibles[j][i % possibles[j].Count-1]);
                }
            }
            if (totalArr.Length > 0)
            {
                foreach (var item in totalArr)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}

/*
2
1111110
1111111
 *
1
1011111
*/