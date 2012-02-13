using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace problem3
{
    class Program
    {
        static int[] tubes;
        static void Main(string[] args)
        {
            int n =int.Parse( Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            tubes = new int[n];
            int maxTubeSize = 0;
            for (int i = 0; i < n; i++)
            {
                tubes[i] = int.Parse(Console.ReadLine());
                if (maxTubeSize < tubes[i]) maxTubeSize = tubes[i];
            }
            int minTubeSize = 1;
            bool canDo = false;
            int currentTubeSize = -1;
            while (minTubeSize != maxTubeSize)
            {                
                if (currentTubeSize == (minTubeSize + maxTubeSize) / 2) 
                    break;
                else currentTubeSize=((minTubeSize + maxTubeSize) / 2) ;
                int howManyCanCut=0;
                for (int i = 0; i < n; i++)
                {
                    howManyCanCut += tubes[i] / currentTubeSize;
                }
                if (howManyCanCut >= m)
                {
                    minTubeSize = currentTubeSize-1;
                    canDo = true;
                }
                else
                {
                    canDo = false;
                    maxTubeSize = currentTubeSize+1;
                }
            }
            if (!canDo)
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(currentTubeSize);
            }
            }
    }
}
