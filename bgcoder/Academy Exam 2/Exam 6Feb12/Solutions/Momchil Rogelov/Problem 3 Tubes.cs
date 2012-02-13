using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tubes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[] tubes= new int[n];
            for (int i = 0; i < n; i++)
            {
                tubes[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(tubes);
            Array.Reverse(tubes);
            ulong sum = 0;
            foreach (var item in tubes)
            {
                sum += (ulong)item;
            }
            int tryingWith = (int)(sum / (ulong)m);
            bool success = false;
            while (tryingWith > 0 && !success) 
            {
                tryingWith--;
                long availabletubes = 0;
                foreach (int tube in tubes)
                {
                    availabletubes = availabletubes + (tube-(tube % tryingWith))/tryingWith;
                    if (availabletubes >= m)
                    {
                        Console.WriteLine(tryingWith);
                        success = true;
                        break;
                    }
                }
                
            }
            if (tryingWith==0)
            {
                Console.WriteLine("-1");    
            }
            
            
            


        }
    }
}
