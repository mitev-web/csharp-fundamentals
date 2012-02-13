using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace _5___Brackets
{
    class Program
    {
        static List<int> possitions = new List<int>();
        static byte[] loops;
        static int counter = 0;
        static int k = 0;
        static byte[] brackSeq;
        static void Main(string[] args)
        {
            string brackets = Console.ReadLine();
            brackSeq = new byte[brackets.Length];
            for (byte j = 0; j < brackets.Length; j++)
            {
                if (brackets[j] == '(')
                {
                    brackSeq[j] = 0;
                }
                else if (brackets[j] == ')')
                {
                    brackSeq[j] = 1;
                }
                else { brackSeq[j] = 2; }
            }
            Console.WriteLine(counter);
            return;
            for (byte i = 0; i < brackSeq.Length; i++)
            {
                if (brackSeq[i] == 2)
                {
                    possitions.Add(i);
                    k++;
                }
            }
             
            if (k == 1)
            {
                Console.WriteLine(1); return;
            }
            loops = new byte[k];
            Variation(0);
             
        }
        private static void Variation(int currentLoop)
        {
            if (currentLoop == k)
            {
                PrintLoops();
                return;
            }
            for (byte i = 0; i <= 1; i++)
            {
                loops[currentLoop] = i;
                Variation(currentLoop + 1);
            }
        }
        private static void PrintLoops()
        {
            int i = 0;
            foreach (var pos in possitions)
            {
                brackSeq[pos] = loops[i];
                i++;
            }
            if (IsValidBrackets(brackSeq))
            {
                counter++;
            }
            else return;
        }
        static bool IsValidBrackets(byte[] brackets)
        {
            int count = 0;
            for (byte i = 0; i < brackets.Length; i++)
            {
                if (brackets[i] == 0)
                {
                    count++;
                }
                else if (brackets[i] == 1)
                {
                    count--;
                }
                if (count < 0)
                {
                    return false;
                }
            }
            if (count == 0)
            {
                return true;
            }
            else return false;
        }
    }
}