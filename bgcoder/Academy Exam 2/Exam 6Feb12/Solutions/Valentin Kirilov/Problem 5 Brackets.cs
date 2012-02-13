using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5.Brackets
{
    class Brackets
    {

        static string input;
        static int possibleSolutions;
        static Dictionary<string, bool> checkedSolutions;

        static void Main(string[] args)
        {
            // Read input
            input = Console.ReadLine();

            checkedSolutions = new Dictionary<string, bool>();
            FindSolutionWithRecursion(new StringBuilder(input));

            Console.WriteLine("{0}", possibleSolutions);

        }

        private static void FindSolution()
        {

            int numberOfSolutions = int.Parse(Math.Pow(2, input.Length).ToString());

            // Find max number of characters
            int maxNumberOfCharacters = Convert.ToString(numberOfSolutions - 1, 2).Length;

            for (int currentOption = 0; currentOption < numberOfSolutions; currentOption++)
            {
                //Console.WriteLine(Convert.ToString(currentOption, 2));
                StringBuilder currentStringOption = new StringBuilder();
                currentStringOption.Append(Convert.ToString(currentOption, 2).PadLeft(maxNumberOfCharacters, '0'));
                //Console.WriteLine(currentStringOption);

                // Generate options
                for (int currentInputIndex = 0; currentInputIndex < input.Length; currentInputIndex++)
                {
                    // Put brackets on thei places
                    if (input[currentInputIndex].Equals('?') == false)
                    {
                        currentStringOption.Remove(currentInputIndex, 1);
                        currentStringOption.Insert(currentInputIndex, input[currentInputIndex]);
                    }

                    // Put optional brackets on their places
                    if (currentStringOption[currentInputIndex].Equals('0') == true)
                    {
                        currentStringOption.Remove(currentInputIndex, 1);
                        currentStringOption.Insert(currentInputIndex, '(');
                    }
                    else if (currentStringOption[currentInputIndex].Equals('1') == true)
                    {
                        currentStringOption.Remove(currentInputIndex, 1);
                        currentStringOption.Insert(currentInputIndex, ')');
                    }
                }
                Console.WriteLine(currentStringOption);

                if (checkedSolutions.ContainsKey(currentStringOption.ToString()) == false)
                {
                    checkedSolutions.Add(currentStringOption.ToString(), true);
                    CheckSolution(currentStringOption);
                }
                
            }
        }

        private static void FindSolutionWithRecursion(StringBuilder brackets)
        {
            if (CheckForQuestionMarks(brackets) > -1)
            {
                int indexToChange = CheckForQuestionMarks(brackets);
                StringBuilder newOpenString = new StringBuilder();
                newOpenString.Append(brackets);
                newOpenString.Remove(indexToChange, 1);
                newOpenString.Insert(indexToChange, '(');
                //Console.WriteLine(" NEW {0}", newOpenString);

                StringBuilder newCloseString = new StringBuilder();
                newCloseString.Append(brackets);
                newCloseString.Remove(indexToChange, 1);
                newCloseString.Insert(indexToChange, ')');
                //Console.WriteLine(" NEW {0}", newCloseString);

                FindSolutionWithRecursion(newOpenString);
                FindSolutionWithRecursion(newCloseString);

            }

            if (checkedSolutions.ContainsKey(brackets.ToString()) == false)
            {
                checkedSolutions.Add(brackets.ToString(), true);
                CheckSolution(brackets);
            }
            
        }

        private static int CheckForQuestionMarks(StringBuilder inputString) 
        {
            for (int index = 0; index < inputString.Length; index++)
            {
                if (inputString[index].Equals('?') == true)
                {
                    //Console.WriteLine("{0} at index {1}", inputString, index);
                    return index;
                }
            }

            //Console.WriteLine("                    ??? Correct -> {0}", inputString);
            return -1;
        }

        private static void CheckSolution(StringBuilder inputSolution)
        {   
            Stack<char> solutionChecker = new Stack<char>();

            for (int currentIndex = 0; currentIndex < inputSolution.Length; currentIndex++)
            {
                if (inputSolution[currentIndex].Equals('?') == true)
                {
                    return;
                }
                if (inputSolution[currentIndex].Equals('(') == true)
                {
                    //Console.WriteLine(" Push (");
                    solutionChecker.Push('(');
                }
                else if (inputSolution[currentIndex].Equals(')') == true)
                {
                    if (solutionChecker.Count > 0)
                    {
                        char popedBracket = solutionChecker.Pop();
                        if (popedBracket == ')')
                        {
                            //Console.WriteLine("POP {0}", popedBracket);
                            return;
                        }
                    }
                    else
                    {
                        //Console.WriteLine("POP - Empty stack");
                        return;
                    }
                }
            }

            if (solutionChecker.Count == 0)
            {
                possibleSolutions++;
                //Console.WriteLine(" ^^^ Correct solution - {0}", inputSolution);
            }
        }
    }
}
