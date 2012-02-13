using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _1.PHP_Vars
{
	class Program
	{
		static readonly bool DEBUG_MODE_ON = false;
		static System.IO.StreamReader inputFile = DEBUG_MODE_ON ? new System.IO.StreamReader("input.php") : null;

		static string phpVarPattern = @"\\?\$\w+";

		static bool inCode = true;
		static bool inQuotedString;
		static bool inApsString;
		static bool inComment;

		static StringBuilder lineBuffer = new StringBuilder();

		static string GetInputLine()
		{
			return DEBUG_MODE_ON ? inputFile.ReadLine() : Console.ReadLine();
		}

		static List<string> vars = new List<string>(128);

		static void ExecuteExtraction()
		{
		    string inputLine = GetInputLine();;
		    while (inputLine != "?>")
		    {
				MatchCollection pseudoVars = Regex.Matches(inputLine, phpVarPattern);
				foreach (Match varCandidate in pseudoVars)
				{
					char[] var = varCandidate.Groups[0].ToString().ToCharArray();
					if (var[0] != '\\')
					{
						string varName = new string(var, 1, var.Length - 1);
						if (!vars.Contains(varName))
						{
							vars.Add(varName);
						}
					}
				}
				inputLine = GetInputLine();
		    }
		}

		static void AnalyzeBuffer()
		{
			string input = lineBuffer.ToString();
			MatchCollection variables = Regex.Matches(input, phpVarPattern);
			foreach (Match extractedVar in variables)
			{
				string varName = extractedVar.Groups[0].ToString();
				if (varName[0] != '\\' && !vars.Contains(varName))
				{
					vars.Add(varName);
				}
			}
		}

		static void Main(string[] args)
		{
			ExecuteExtraction();
			Console.WriteLine(vars.Count);
			vars.Sort();
			foreach (string var in vars)
			{
				Console.WriteLine(var);
			}
		}
	}
}
