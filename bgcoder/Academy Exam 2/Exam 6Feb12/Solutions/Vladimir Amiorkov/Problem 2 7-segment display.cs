using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem2
{
    class SegmentDigits
    {
        private static void Combinations(int[] intArr, int index, int[] possibleNum, int start, int size)
        {
            if (index >= intArr.Length)
            {
                bool state = new bool();
                for (int i = 0; i < intArr.Length; i++)
                {
                    int sum = intArr[i] + intArr[1];
                    if (sum != 0)
                    {
                        Console.Write(intArr[i]);
                        state = true;
                    }
                }
                if (state)
                {
                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = start; i < size; i++)
                {
                    intArr[index] = possibleNum[i];
                    Combinations(intArr, index + 1, possibleNum, i, size);
                }
            }
        }

        private static int GetNum(string states)
        {
            int num = new int();
            switch (states)
            {
                case "1111110":
                    num = 0;
                    break;
                case "0110000":
                    num = 1;
                    break;
                case "1101101":
                    num = 2;
                    break;
                case "1111001":
                    num = 3;
                    break;
                case "0110011":
                    num = 4;
                    break;
                case "1011011":
                    num = 5;
                    break;
                case "1011111":
                    num = 6;
                    break;
                case "1110000":
                    num = 7;
                    break;
                case "1111111":
                    num = 8;
                    break;
                case "1111011":
                    num = 9;
                    break;

                default:
                    break;
            }
            return num;
        }

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] states = new string[n];
            for (int line = 0; line < n; line++)
            {
                states[line] = Console.ReadLine();
            }

            //string[] states = new string[n];
            //states[0] = "1011111";

            List<int> nums = new List<int>();
            nums.Add(GetNum(states[0]));
            int zeroIndex = states[0].IndexOf("0");
            while (zeroIndex != -1)
            {
                states[0] = states[0].Remove(zeroIndex, 1);
                states[0] = states[0].Insert(zeroIndex, "1");
                nums.Add(GetNum(states[0]));
                zeroIndex = states[0].IndexOf("0");
            }
            Console.WriteLine(nums.Count);
            if (n < 2)
            {
                foreach (int ele in nums)
                {
                    Console.WriteLine(ele);
                }
            }
            else
            {
                int k = nums.Count;

                int[] array = new int[k];
                int[] possible = nums.ToArray();
                Combinations(array, 0, possible, 0, k);
            }
        }
    }
}