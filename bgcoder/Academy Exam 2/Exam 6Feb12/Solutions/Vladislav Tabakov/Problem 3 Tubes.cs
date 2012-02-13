using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tubes
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int result = 0;
            int tubeSize = 0;
            int[] tubeSizes = new int[N];
            for (int i = 0; i < tubeSizes.Length; i++)
            {
                tubeSizes[i] = int.Parse(Console.ReadLine());
                result = result + tubeSizes[i];
            }
            tubeSize = result / M;
            Console.WriteLine(tubeSize);
        }
    }
}
