using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace Brackets
{
    class Program
    {
        static string input;
        static int correct = 0;    
        static void Main(string[] args)
        {
            input = Console.ReadLine();
            char[] startingArray = input.ToCharArray();
 
            generateCombinations(startingArray, 0);
             
            Console.WriteLine(correct);
        }
   
        private static bool IsCorrrectCombination(char[] item)
        {
            int openbrackets = 0;
            foreach (char n in item)
            {
                if (n == '(') openbrackets++;
                if (n == ')') openbrackets--;
                if (openbrackets<0)
                {
                    return false;
                }
            }
 
            if (openbrackets==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
 
        private static void generateCombinations(char[] startingArray, int index)
        {
            if (index == startingArray.Length)
            {
                if (IsCorrrectCombination(startingArray)) correct++;
            }
            else {
                int nextIndex = index+1;
                if (startingArray[index] == '?')
                {
                    startingArray[index] = '(';
                    generateCombinations(startingArray, nextIndex);
                    startingArray[index] = ')';
                    //restore
                    for (int i = index+1; i < startingArray.Length; i++)
                    {
                        startingArray[i]=input[i];
                    }
                    generateCombinations(startingArray, nextIndex);
                    
                }
                else
                {
                    generateCombinations(startingArray, nextIndex);
                }
            }
        }
    }
}