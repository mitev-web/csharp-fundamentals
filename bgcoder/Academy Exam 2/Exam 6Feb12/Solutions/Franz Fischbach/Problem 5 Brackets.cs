using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace brackets
{
    class Program
    {
        static bool IsBracketsExpressionValid(char[] expression,int expressionLenght)
        {
            int openBrackets = 0;
            for (int i = 0; i < expressionLenght; i++)
            {
                if (expression[i] == '(')
                {
                    openBrackets++;
                }
                else
                {
                    if (openBrackets == 0)
                    {
                        return false;
                    }
                    openBrackets--;
                }
            }
 
            if (openBrackets != 0)
            {
                return false;
            }
            else { return true; }
 
 
        }
 
        static char[] mainExpression;
        static int mainExpressionLenght;
 
        static int solutionsCount = 0;
 
        static void GenerateSolutions(char[] currentExpression, int progress)
        {
            if (progress == mainExpressionLenght)
            {
                if (IsBracketsExpressionValid(currentExpression, mainExpressionLenght))
                {
                    solutionsCount++;
                    return;
                }
                return;
            }
             
 
      //      for (; progress < mainExpressionLenght; progress++)
       //     {
            if (currentExpression[progress] == '?')
            {
                currentExpression[progress] = '(';
                GenerateSolutions((char[])currentExpression.Clone(), progress+1);
 
                currentExpression[progress] = ')';
                GenerateSolutions((char[])currentExpression.Clone(), progress+1);
            }
            else
            {
                GenerateSolutions((char[])currentExpression.Clone(), progress + 1);
            }
 
           // }
        }
 
        static void Main(string[] args)
        {
           string  input = Console.ReadLine();
           mainExpressionLenght = input.Length;
           mainExpression = new char[mainExpressionLenght];
           for (int i = 0; i < mainExpressionLenght; i++)
           {
               mainExpression[i] = input[i];
           }
 
           GenerateSolutions(mainExpression, 0);
 
           Console.WriteLine(solutionsCount);
 
        }
    }
}