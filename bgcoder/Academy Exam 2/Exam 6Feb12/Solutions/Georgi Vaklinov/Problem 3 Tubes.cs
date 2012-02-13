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
            long sum = 0;
            int[] size = new int[N];
            for (int i = 0; i < N; i++)
            {
                size[i] = int.Parse(Console.ReadLine());
                sum += size[i];
            }
            bool found = false;
            int max = (int)(sum / M);
            int count = 0;
            for (int i = max; i > 0; i--)
            {
                count = 0;
                for (int j = 0; j < size.Length; j++)
                {
                    int temp = size[j];
                    while (temp >= i)
                    {
                        temp -= i;
                        count++;
                    }
                }
                   
                if (count >= M)
                {
                    Console.WriteLine(i);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine(-1);
            }
        }
    }
}