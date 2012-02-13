using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tubes2
{
    class Program
    {
        static int m;
        static int[] tubes;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            m = int.Parse(Console.ReadLine());
            tubes = new int[n];
            long sum = 0;
            for (int i = 0; i < tubes.Length; i++)
            {
                tubes[i] = int.Parse(Console.ReadLine());
                sum += tubes[i];
            }
            int maxNumber = (int)(sum / m);
            while (maxNumber > 0)
            {
                int sumOfElements = 0;
                for (int i = 0; i < tubes.Length; i++)
                {
                    sumOfElements += tubes[i] / maxNumber;
                }
                if (sumOfElements == m)
                {
                    Console.WriteLine(maxNumber);
                    return;
                }
                maxNumber--;
                if (sumOfElements > m)
                {
                    break;
                }
            }
            Console.WriteLine(-1);
        }
        
    }
}
