using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tubes
{
    class Program
    {
       static int n;
       static int m;
       static int[] tubes;

       static int Salvage(int TubeSize)
       {
            int tubeCount=0;
            for (int i = 0; i < n; i++)
            {
                tubeCount += tubes[i] / TubeSize;
            }

            return tubeCount;
       }


       static void Main(string[] args)
        {
             n = int.Parse(Console.ReadLine());
             m = int.Parse(Console.ReadLine());
             tubes = new int[n];

            for (int i = 0; i < n; i++)
            {
                tubes[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(tubes);

            int min = 1;
            int max = tubes[n - 1];
            int maxSize = -1;
            for (; min < max; )
            {
                int currentSize =min + (max - min) / 2;
                int partsCount = Salvage( currentSize);
                if (partsCount >= m)
                {
                    if (maxSize < currentSize) { maxSize = currentSize; }
                    min = currentSize+1;
                }
                else //if (partsCount < m)
                {
                    max = currentSize;
                }              
            }

            Console.WriteLine(maxSize);

            

        }
    }
}
