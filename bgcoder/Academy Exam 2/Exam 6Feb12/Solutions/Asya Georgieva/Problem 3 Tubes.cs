using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.Tubles
{
   class Program
   {
      static void Main(string[] args)
      {
         ushort n = ushort.Parse(Console.ReadLine());
         uint m = uint.Parse(Console.ReadLine());

         uint result = 0;
         for (uint i = 0; i < n; i++)
         {
            uint num = uint.Parse(Console.ReadLine());
            result += num;
         }

         // Console.WriteLine(result);

         uint output = result / m;
         Console.WriteLine(output);

         //int a = 800;
         //int b = 847  5;
         //Console.WriteLine(b);
      }
   }
}
