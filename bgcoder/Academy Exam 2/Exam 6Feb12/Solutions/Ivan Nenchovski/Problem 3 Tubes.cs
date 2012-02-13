using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3_Tubes
{
	static class Program
	{
		static long GetLongSum(this IEnumerable<long> collection)
		{
			long sum = 0;
			foreach (long number in collection)
			{
				sum += number;
			}
			return sum;
		}

		static readonly bool DEBUG_MODE_ON = false; // I swear, I'll never again use const for the exams
		static long nTubesRequired = 0;
		static long[] tubes;
		static long[] currentPieces;

		static void InitializeData()
		{
			if (DEBUG_MODE_ON)
			{
				nTubesRequired = 6;
				tubes = new long[] { 100, 200, 300 };
			}
			else
			{
				long tubesCount = Convert.ToInt64(Console.ReadLine());
				nTubesRequired = Convert.ToInt64(Console.ReadLine());
				tubes = new long[tubesCount];
				for (long i = 0; i < tubesCount; i++)
				{
					tubes[i] = Convert.ToInt64(Console.ReadLine()); ;
				}
			}
			currentPieces = new long[tubes.LongLength];
		}

		static long GetEqualSizedCutsCount(long tubeLength, long cutSize)
		{
			return (tubeLength - tubeLength % cutSize) / cutSize;
		}

		static long GetSumOfEqualCuts(long cutLength)
		{
			for (long i = 0; i < (long)currentPieces.LongLength; i++)
			{
				currentPieces[i] = GetEqualSizedCutsCount(tubes[i], cutLength);
			}

			long sum = currentPieces.GetLongSum();
			return sum;
		}

		static void TryCutExactly()
		{
			long maxElem = tubes.Max();
			for (long i = maxElem; i >= 1; i--)
			{
				long sum = GetSumOfEqualCuts(i);
				if (GetSumOfEqualCuts(i) == nTubesRequired)
				{
					Console.WriteLine(i);
					return;
				}
				if (sum > nTubesRequired)
				{
					Console.WriteLine(-1);
					return;
				}
			}
			Console.WriteLine(-1);
		}

		static void Main(string[] args)
		{
			InitializeData();
			TryCutExactly();
		}
	}
}
