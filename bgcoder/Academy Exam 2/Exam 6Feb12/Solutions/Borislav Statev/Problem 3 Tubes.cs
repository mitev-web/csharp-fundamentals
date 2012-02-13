using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3b.Tubes
{
    class Tubes
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            int[] tubes = new int[n];
            int totalLength = 0;
            for (int i = 0; i < n; i++)
            {
                tubes[i] = int.Parse(Console.ReadLine());
                totalLength += tubes[i];
            }

            int averageLength = totalLength / m;
            bool haveSolution = false;
            int solutionLength = -1;

            for (int i = averageLength; i > 0; i--)
            {
                int cutLength = i;
                int tubeItems = 0;

                for (int j = 0; j < n; j++)
                {
                    tubeItems += tubes[j] / cutLength;
                    if (tubeItems >= m)
                    {
                        solutionLength = cutLength;
                        haveSolution = true;
                        break;
                    }
                }
                if (haveSolution)
                {
                    break;
                }
            }

            Console.WriteLine(solutionLength);
        }
    }
}
