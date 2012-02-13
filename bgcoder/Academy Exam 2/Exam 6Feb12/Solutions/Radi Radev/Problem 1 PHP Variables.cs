using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong n = ulong.Parse(Console.ReadLine());
            ulong m = ulong.Parse(Console.ReadLine());
            ulong[] tubes = new ulong[m];
            ulong tubes_zusamen = 0;
            for (ulong i = 0; i < n; i++)
            {
                tubes[i] = uint.Parse(Console.ReadLine());
                tubes_zusamen = tubes_zusamen + tubes[i];
            }
            ulong maxtube = tubes_zusamen/m;
            ulong[] max_pieces_from_a_tube = new ulong[n];
        step:
            ulong number_of_pieces = 0;
            for (ulong i = 0; i < n; i++)
            {
                max_pieces_from_a_tube[i] = tubes[i] / maxtube;
                number_of_pieces = number_of_pieces + max_pieces_from_a_tube[i];
            }                        
            if (number_of_pieces<m)
            {
		        maxtube=maxtube-1;
                goto step;
            }
            if (maxtube > 1)
            {
                Console.WriteLine(maxtube);
            }
            else
            {
                Console.WriteLine("-1");
            }
            
        }
    }
}
