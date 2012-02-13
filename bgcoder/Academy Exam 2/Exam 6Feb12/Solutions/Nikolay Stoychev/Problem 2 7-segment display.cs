using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _7_segmentDigits
{
    class Program
    {
        const int SEGMENTS = 7;
        static int[] current;
        static int[] input;
        static List<List<int>> results = new List<List<int>>();
        static int? GetNumber(int[] digits)
        {
            if (digits[0] == 1 && digits[1] == 1 && digits[2] == 1 && digits[3] == 1 && digits[4] == 1 && digits[5] == 1 && digits[6] == 0)
            {
                return 0;
            }

            if (digits[0] == 0 && digits[1] == 1 && digits[2] == 1 && digits[3] == 0 && digits[4] == 0 && digits[5] == 0 && digits[6] == 0)
            {
                return 1;
            }

            if (digits[0] == 1 && digits[1] == 1 && digits[2] == 0 && digits[3] == 1 && digits[4] == 1 && digits[5] == 0 && digits[6] == 1)
            {
                return 2;
            }

            if (digits[0] == 1 && digits[1] == 1 && digits[2] == 1 && digits[3] == 1 && digits[4] == 0 && digits[5] == 0 && digits[6] == 1)
            {
                return 3;
            }

            if (digits[0] == 0 && digits[1] == 1 && digits[2] == 1 && digits[3] == 0 && digits[4] == 0 && digits[5] == 1 && digits[6] == 1)
            {
                return 4;
            }

            if (digits[0] == 1 && digits[1] == 0 && digits[2] == 1 && digits[3] == 1 && digits[4] == 0 && digits[5] == 1 && digits[6] == 1)
            {
                return 5;
            }

            if (digits[0] == 1 && digits[1] == 0 && digits[2] == 1 && digits[3] == 1 && digits[4] == 1 && digits[5] == 1 && digits[6] == 1)
            {
                return 6;
            }

            if (digits[0] == 1 && digits[1] == 1 && digits[2] == 1 && digits[3] == 0 && digits[4] == 0 && digits[5] == 0 && digits[6] == 0)
            {
                return 7;
            }

            if (digits[0] == 1 && digits[1] == 1 && digits[2] == 1 && digits[3] == 1 && digits[4] == 1 && digits[5] == 1 && digits[6] == 1)
            {
                return 8;
            }

            if (digits[0] == 1 && digits[1] == 1 && digits[2] == 1 && digits[3] == 1 && digits[4] == 0 && digits[5] == 1 && digits[6] == 1)
            {
                return 9;
            }

            return null;
        }

        static void CheckNumbers(int index, int currentNumer)
        {
            if (index == SEGMENTS - 1)
            {
                int? num = GetNumber(current);
                if (num != null)
                {
                    if (!results[currentNumer].Contains((int)num))
                    {
                        results[currentNumer].Add((int)num);
                    }
                }
                return;
            }

            for (int i = index + 1; i < SEGMENTS; i++)
            {
                if (i < SEGMENTS && input[i] == 0)
                {
                    current[i] = 0;
                    CheckNumbers(i, currentNumer);

                    current[i] = 1;
                    CheckNumbers(i, currentNumer);
                }
                else
                {
                    if (i == SEGMENTS - 1)
                    {
                        int? num = GetNumber(current);
                        if (num != null)
                        {
                            if (!results[currentNumer].Contains((int)num))
                            {
                                results[currentNumer].Add((int)num);
                            }
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            //StreamReader reader = new StreamReader("in.txt");
            int lines = int.Parse(Console.ReadLine());
            List<int[]> inputs = new List<int[]>(lines);
            for (int i = 0; i < lines; i++)
            {
                string line = Console.ReadLine();
                int[] array = new int[SEGMENTS];
                for (int j = 0; j < SEGMENTS; j++)
                {
                    array[j] = int.Parse(line[j].ToString());
                }
                inputs.Add(array);
            }

            //reader.Close();

            for (int i = 0; i < inputs.Count; i++)
            {
                input = inputs[i];
                current = new int[SEGMENTS] { 1, 1, 1, 1, 1, 1, 1 };
                results.Add(new List<int>());
                CheckNumbers(-1, i);
            }

            CalculateResult(-1, 0);
            Console.WriteLine(combinations.Count);
            combinations.Sort();
            foreach (var item in combinations)
            {
                Console.WriteLine(item);
            }
        }

        static string currentNum = string.Empty;
        static List<string> combinations = new List<string>();

        static void CalculateResult(int index, int currentList)
        {
            if (currentList == results.Count)
            {
                if (currentNum != string.Empty)
                {
                    //Console.WriteLine(currentNum);
                    combinations.Add(currentNum);
                    currentNum = string.Empty;
                }
                return;
            }

            for (int i = index + 1; i < results[currentList].Count; i++)
            {
                currentNum += results[currentList][i].ToString();
                currentList++;
                int ind = -1;
                CalculateResult(ind, currentList);
                ind++;
                CalculateResult(ind, currentList);
                currentList--;
            }
        }
    }
}