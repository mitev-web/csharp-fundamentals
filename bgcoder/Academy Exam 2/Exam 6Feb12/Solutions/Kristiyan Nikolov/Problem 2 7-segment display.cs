using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prob2_Digits
{
    class Digits
    {
        #region Digits
        static readonly string[] Dig = {
                                        "1111110", // 0
                                        "0110000", // 1
                                        "1101101", // 2
                                        "1111001", // 3
                                        "0110011", // 4
                                        "1011011", // 5
                                        "1011111", // 6
                                        "1110000", // 7
                                        "1111111", // 8
                                        "1111011"  // 9
                                    };
        #endregion

        static void Main(string[] args)
        {
            string[] input = ReadInput();

            List<List<int>> list = new List<List<int>>();

            for (int i = 0; i < input.Length; i++)
            {
                list.Add(AllDigits(input[i].ToCharArray(), 0));
            }

            list = AllComb(list, new List<int>(), 0);
            list = QuickSort(list, list.Count / 2);
            Console.WriteLine(list.Count);
            foreach (var comb in list)
            {
                foreach (var d in comb)
                {
                    Console.Write(d);
                }
                Console.WriteLine();
            }
        }

        static string[] ReadInput()
        {
            string input = Console.ReadLine();
            int n = int.Parse(input);

            string[] result = new string[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = Console.ReadLine();
            }

            return result;
        }

        static List<List<int>> AllComb(List<List<int>> list, List<int> comb, int pos)
        {
            List<List<int>> result = new List<List<int>>();

            if (pos == list.Count - 1)
            {
                for (int i = 0; i < list[pos].Count; i++)
                {
                    comb.Add(list[pos][i]);
                    result.Add(new List<int>(comb));
                    comb.RemoveAt(comb.Count - 1);
                }
                return result;
            }

            for (int i = 0; i < list[pos].Count; i++)
            {
                comb.Add(list[pos][i]);

                result.AddRange(AllComb(list, comb, pos + 1));

                comb.RemoveAt(comb.Count - 1);
            }

            return result;
        }

        static List<int> AllDigits(char[] dig, int start)
        {
            List<int> result = new List<int>();

            int d = StrIndexOf(Dig, dig, 0);

            if (d > -1)
            {
                result.Add(d);
            }

            int i = ChIndexOf(dig, '0', start);
            while (i > -1)
            {
                dig[i] = '1';
                result.AddRange(AllDigits(dig, i + 1));
                dig[i] = '0';
                i = ChIndexOf(dig, '0', i + 1);
            }

            return result;
        }

        static int StrIndexOf(string[] source, char[] d, int start)
        {
            string s = new string(d);
            for (int i = start; i < source.Length; i++)
            {
                if (source[i] == s)
                    return i;
            }
            return -1;
        }

        static int ChIndexOf(char[] source, char ch, int start)
        {
            for (int i = start; i < source.Length; i++)
            {
                if (source[i] == ch)
                    return i;
            }
            return -1;
        }

        static List<List<int>> QuickSort(List<List<int>> list, int index)
        {
            if (list.Count < 2)
            {
                return list;
            }
            else
            {
                List<List<int>> less = new List<List<int>>();
                List<List<int>> greater = new List<List<int>>();

                List<int> pivot = list[index];
                list.RemoveAt(index);

                foreach (var st in list)
                {
                    if (CompareListInt(st, pivot) < 0)
                    {
                        less.Add(st);
                    }
                    else
                    {
                        greater.Add(st);
                    }
                }

                less = QuickSort(less, less.Count / 2);
                greater = QuickSort(greater, greater.Count / 2);

                List<List<int>> result = new List<List<int>>(less);
                result.Add(pivot);
                result.AddRange(greater);
                return result;
            }
        }

        static int CompareListInt(List<int> st1, List<int> st2)
        {
            for (int i = 0; i < st1.Count; i++)
            {
                if (st1[i] > st2[i])
                    return 1;
                else if (st1[i] < st2[i])
                    return -1;
            }

            return 0;
        }
    }
}
