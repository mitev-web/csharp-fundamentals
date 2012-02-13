using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2._7SegmentDigits
{
    class _7SegmentDigits
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
             byte[] digitsBitPresenting = { 126, 48, 109, 121, 51, 91, 95, 112, 127, 123 };
             byte[][] resultDigitsCombination = new byte[n][];

             for (int i = 0; i < n; i++)
             {
                 short displayNumber = Convert.ToInt16(Console.ReadLine(),2);
                 List<byte> posibleNumber = new List<byte>();
                 for (byte j = 0; j < 10; j++)
                 {
                     if ((displayNumber & ~digitsBitPresenting[j]) == 0)
                     {
                         posibleNumber.Add(j);
                     }
                 }
                 resultDigitsCombination[i] = posibleNumber.ToArray();
             }

             int k = 1;
             for (int i = 0; i < n; i++)
             {
                 k *= resultDigitsCombination[i].Length;
             }

             Console.WriteLine(k);
            int[] vector = new int[n];

            Gen01(0, vector, resultDigitsCombination);
            
        }

        static void Gen01(int index, int[] vector, byte[][] useDigits)
        {
            if (index == vector.Length)
            {
                Print(vector);
            }
            else
            {
                for (int i = 0; i < useDigits[index].Length; i++)
                {
                    vector[index] = useDigits[index][i];
                    Gen01(index + 1, vector, useDigits);
                }
            }
        }

        static void Print(int[] vector)
        {
            foreach (int i in vector)
            {
                Console.Write("{0}", i);
            }
            Console.WriteLine();
        }
    }
}