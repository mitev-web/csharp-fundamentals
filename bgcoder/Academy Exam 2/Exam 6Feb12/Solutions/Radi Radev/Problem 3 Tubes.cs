using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long m = long.Parse(Console.ReadLine());
            long[] tubes = new long[n];
            long tubes_zusamen = 0;
            for (long i = 0; i < n; i++)
            {
                tubes[i] = int.Parse(Console.ReadLine());
                tubes_zusamen = tubes_zusamen + tubes[i];
            }            
            long maxtube = tubes_zusamen/m;
            long[] max_pieces_from_a_tube = new long[n];
        step:
            if (tubes_zusamen<m)
            {
                Console.WriteLine("-1");
                goto end;
            }
            long number_of_pieces = 0;
            for (long i = 0; i < n; i++)
            {
                max_pieces_from_a_tube[i] = tubes[i] / maxtube;
                number_of_pieces = number_of_pieces + max_pieces_from_a_tube[i];
            }                       
            if (number_of_pieces<m)
            {
                if (n > 1700)
                {
                    maxtube = maxtube - 3;
                }

                else
                {
                    maxtube = maxtube - 1;
                }
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
        end: ;
        }
    }
}
