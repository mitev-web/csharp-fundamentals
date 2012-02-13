using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace T3.Tubes
{
    class Tubes
    {
        static void Main(string[] args)
        {
            int tubesN = Convert.ToInt32(Console.ReadLine());//4//Convert.ToInt32(Console.ReadLine());
            int friends = Convert.ToInt32(Console.ReadLine());//11;
            BigInteger sum = 0;
            int result;
            int[] tubes = new int[tubesN];

            for (int i = 0; i < tubesN; i++)
            {
                tubes[i] = Convert.ToInt32(Console.ReadLine());
                sum += tubes[i];
            }


            Array.Sort(tubes);

            int maxLength = (int)(sum / friends);

           

                Console.WriteLine(calcMaxLength(tubes, friends, maxLength));
      


        }

        public static int calcMaxLength(int[] arr, int frM, int max)
        {

            bool Istrue = true;


            while (Istrue)
            {
                int count = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    count += arr[i] / max;
                }

                if (count >= frM)
                {

                    Istrue = false;
                }
                else
                {
                    max--;
                }
            }

            return max;
        }
    }
}
