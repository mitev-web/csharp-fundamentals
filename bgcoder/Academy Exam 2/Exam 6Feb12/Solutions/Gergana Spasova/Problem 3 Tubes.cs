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
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            Int32[] array = new Int32[n];
            Int32 max;
            Int32 sum = 0;
            Int32 result = 0;
            Int32 t = 1;
            for (int i = 0; i < n; i++)
            {
                array[i] = Int32.Parse(Console.ReadLine());
                sum += array[i];
            }
            max = sum / m;
            if (max < m)
            {
                Console.WriteLine("-1");
            }
            else
            {
                while (t != m)
                {
                    t = 0;
                    for (int i = 0; i < array.Length; i++)
                    {
                        result = array[i] / max;
                        t += result;
                    }
                    max--;
                }
                Console.WriteLine(max + 1);
            }
        }
    }
}