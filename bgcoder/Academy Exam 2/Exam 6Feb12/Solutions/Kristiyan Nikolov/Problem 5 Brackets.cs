using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace Prob5_Brackets
{
    class Brackets
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
 
            int count = CombCount(input.ToCharArray(), 0, 0);
 
            Console.WriteLine(count);
        }
 
        static int CombCount(char[] text, int start, int oCount)
        {
            if (!text.Contains('?'))
            {
                return 1;
            }
 
            int result = 0;
 
            for (int i = start; i < text.Length; i++)
            {
                if (text[i] == '(')
                {
                    oCount++;
                }
                else if (text[i] == ')')
                {
                    oCount--;
                }
                else
                {
                    if (oCount > 0)
                    {
                        int[] qcCount = QCCount(text, i + 1);
 
                        int count = oCount - qcCount[1];
                        if (Math.Abs(count) == qcCount[0] + 1)
                        {
                            char br = ' ';
                            if (count > 0)
                            {
                                br = ')';
                            }
                            else
                            {
                                br = '(';
                            }
                            char[] temp = new char[text.Length];
                            Array.Copy(text, temp, temp.Length);
                            for (int j = i; j < temp.Length; j++)
                            {
                                temp[j] = br;
                            }
                            result += CombCount(temp, i + 1, oCount + 1);
                        }
                        else
                        {
                            char[] temp = new char[text.Length];
                            Array.Copy(text, temp, temp.Length);
                            temp[i] = '(';
                            result += CombCount(temp, i + 1, oCount + 1);
                            temp[i] = ')';
                            result += CombCount(temp, i + 1, oCount - 1);
                        }
                    }
                    else if (oCount == 0)
                    {
                        char[] temp = new char[text.Length];
                        Array.Copy(text, temp, temp.Length);
                        temp[i] = '(';
                        result += CombCount(temp, i + 1, oCount + 1);
                    }
 
                    return result;
                }
            }
 
            return result;
        }
 
        static int[] QCCount(char[] text, int start)
        {
            int qCount = 0;
            int cCount = 0;
            for (int i = start; i < text.Length; i++)
            {
                if (text[i] == '?')
                {
                    qCount++; ;
                }
                else if (text[i] == '(')
                {
                    cCount--;
                }
                else
                {
                    cCount++;
                }
            }
 
            return new int[] { qCount, cCount };
        }
 
        static bool CorrectExpr(char[] expr)
        {
            int brCount = 0;
            for (int i = 0; i < expr.Length; i++)
            {
                if (expr[i] == '(')
                {
                    brCount++;
                }
                else if (expr[i] == ')')
                {
                    brCount--;
                }
 
                if (brCount < 0)
                    return false;
            }
 
            if (brCount == 0)
                return true;
 
            return false;
        }
    }
}