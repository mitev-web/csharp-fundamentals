using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.Segmented_Digits
{
	class Program
	{
		const bool DEBUG_MODE_ON = false;

		static string[] GetInput()
		{
			if (DEBUG_MODE_ON)
			{
				return new string[] { "1111110", "1111111" };
			}
			else
			{
				int nLines = Convert.ToInt32(Console.ReadLine());
				string[] input = new string[nLines];
				for (int i = 0; i < nLines; i++)
				{
					input[i] = Console.ReadLine();
				}
				return input;
			}
		}

		static int[] digitsTable = { 126, 48, 109, 121, 51, 91, 95, 112, 127, 123 };

		public static int GetSumOfInputString(string s)
		{
			int sum = 0;
			for (int i = 0; i < 7; i++)
			{
				if (s[s.Length - i - 1] != '0')
				{
					sum += 1 << i;
				}
			}

			return sum;
		}

		static List<int[]> jaggedVals;

		public static int[] GetDigitCombinations(string state)
		{
			List<int> result = new List<int>(8);
			int stringSum = GetSumOfInputString(state);
			for (int i = 0; i < digitsTable.Length; i++)
			{
				if ((digitsTable[i] & stringSum) == stringSum)
				{
					result.Add(i);
				}
			}
			return result.ToArray();
		}

		static string PrintCombinationSetToString(List<int> combination)
		{
			StringBuilder buffer = new StringBuilder(combination.Count);
			for (int i = 0; i < combination.Count; i++)
			{
				buffer.Append(combination[i]);
			}
			return buffer.ToString();
		}

		static int nCombinations = 0;

		static void EnumerateCombinations(int currentSet)
		{
			if (currentSet >= currentCombination.Length)
			{
				BufferOutput();
				nCombinations++;
			}
			else
			{
				for (int i = 0; i < jaggedVals[currentSet].Length; i++)
				{
					currentCombination[currentSet] = jaggedVals[currentSet][i];
					EnumerateCombinations(currentSet + 1);
				}
			}
		}

		static StringBuilder consoleBuffer = new StringBuilder(10000);

		static int[] currentCombination;
		static void BufferOutput()
		{
			for (int i = 0; i < currentCombination.Length; i++)
			{
				consoleBuffer.Append(currentCombination[i].ToString());
			}
			consoleBuffer.AppendLine();
		}
		static List<int[]> validCombinations = new List<int[]>();

		static void Main(string[] args)
		{
			string[] input = GetInput();
			jaggedVals = new List<int[]>(input.Length);
			currentCombination = new int[input.Length];
			for (int i = 0; i < input.Length; i++)
			{
				jaggedVals.Add(GetDigitCombinations(input[i]));
			}
			EnumerateCombinations(0);
			Console.WriteLine(nCombinations);
			Console.Write(consoleBuffer);
		}
	}
}
