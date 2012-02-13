using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace _5_Brackets
{
	class Program
	{
		static readonly bool DEBUG_MODE_ON = false;

		static char[] pattern;

		static void GetInput()
		{
			if (DEBUG_MODE_ON)
			{
				pattern = "????(?".ToCharArray();
			}
			else
			{
				pattern = Console.ReadLine().ToCharArray();
			}
		}

		static int validSolutions = 0;

		public static bool ParenthesesMatch()
		{
			int openParentheses = 0;
			for (int i = 0; i < pattern.Length; i++)
			{
				if (pattern[i] == '(')
					openParentheses++;
				if (pattern[i] == ')')
					openParentheses--;
				if (openParentheses < 0)
					return false;
			}
			bool allParenthesesAreClosed = openParentheses == 0;
			return allParenthesesAreClosed;
		}

		static void EnumerateSolutions(int currentPos)
		{
			if (pattern.Length <= currentPos)
			{
				if (ParenthesesMatch())
				{
					validSolutions++;
				}
				return;
			}

			while (currentPos < pattern.Length && pattern[currentPos] != '?')
			{
				currentPos++;
			}
			if (currentPos < pattern.Length)
			{
				pattern[currentPos] = '(';
				EnumerateSolutions(currentPos + 1);
				pattern[currentPos] = ')';
				EnumerateSolutions(currentPos + 1);
				pattern[currentPos] = '?';
			}
			else
			{
				if (ParenthesesMatch())
				{
					validSolutions++;
				}
				return;
			}
			//if (pattern[currentPos] == '?')
			//{
			//    pattern[currentPos] = '(';
			//    EnumerateSolutions(currentPos + 1);
			//    pattern[currentPos] = ')';
			//    EnumerateSolutions(currentPos + 1);
			//    pattern[currentPos] = '?';
			//}
			//else
			//{
			//    EnumerateSolutions(currentPos + 1);
			//}
		}

		static void Main(string[] args)
		{
			GetInput();
			if (pattern.Length % 2 == 1)
			{
				Console.WriteLine(0);
			}
			else
			{
				EnumerateSolutions(0);
				Console.WriteLine(validSolutions);
			}
		}
	}
}
