using System;
using System.Numerics;
using System.Collections.Generic;
 
namespace _03_Problem
{
   class Program
   {
      static void Main()
      {
         ushort n = ushort.Parse(Console.ReadLine());
         int m = Int32.Parse(Console.ReadLine());
         BigInteger allTubes = 0;
         List<int> tubes = new List<int>();
         for (int i = 0; i < n; i++)
         {
            tubes.Add(Int32.Parse(Console.ReadLine()));
            allTubes += tubes[i];
         }
         BigInteger max = (allTubes / m);
         Recursion(tubes, n, max, m);
      }
      static void Recursion(List<int> tubes, ushort n, BigInteger max, int m)
      {
         int counter = m;
         for (int i = 0; i < n; i++)
         {
            int del = (int)(tubes[i] / max);
            counter -= del;
         }
         if (counter > 0)
         {
            max--;
            Recursion(tubes, n, max, m);
         }
         else
         {
            Console.Write(max);
         }
      }
   }
}