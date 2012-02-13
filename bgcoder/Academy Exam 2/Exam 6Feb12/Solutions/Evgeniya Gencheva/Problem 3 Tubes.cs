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
            int numberTubes = Convert.ToInt32(Console.ReadLine());
            int friends = Convert.ToInt32(Console.ReadLine());
            List<int> tubeLen = new List<int>();
            int sum = 0;
            for (int i = 0; i < numberTubes; i++)
            {
                int len = Convert.ToInt32(Console.ReadLine());
                sum += len;
                tubeLen.Add(len);
            }
            if (sum % friends == 0)
            {
                bool isTrue = true;
                int devisor = sum / friends;
                foreach (var item in tubeLen)
                {
                    if (item % devisor != 0)
                    {
                        isTrue = false;
                    }
                }
                if (isTrue == true)
                {
                    Console.WriteLine(devisor);
                }
                else
                {
                    Console.WriteLine("-1");
                }
            }
        }
    }
}
