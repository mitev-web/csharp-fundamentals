using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem3
{
    class Tubes
    {
        static void Main()
        {
            //number of tubes
            int n = int.Parse(Console.ReadLine());
            //int n = 4;
            //Pernik warriors
            int m = int.Parse(Console.ReadLine());
            int[] availableTubes = new int[n];
            for (int i = 0; i < n; i++)
            {
                availableTubes[i] = int.Parse(Console.ReadLine());
                if (availableTubes[i] >= 1 && availableTubes[i] <= 2000000000)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("The size is invalid");
                    break;
                }
            }
            if ((n >= 1) && (n <= 20000) && (m >= 1) && (m <= 2000000000))
            {
                Array.Sort(availableTubes);
                int theSize = availableTubes[n - 1] / n;
                int count = 0;
                for (int i = 0; i < n; i++)
                {
                    count = count + availableTubes[i] / theSize;
                }
                if (count == m)
                {
                    Console.WriteLine(theSize);
                }
                else
                {
                    Console.WriteLine("-1");
                }
            }
            else
            {
                Console.WriteLine("The data is outside the constraints");
            }
        }
    }
}
