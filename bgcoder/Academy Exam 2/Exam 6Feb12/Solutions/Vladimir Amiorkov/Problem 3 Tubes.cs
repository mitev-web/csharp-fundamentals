using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem3
{
    class Tubes
    {
        private static decimal GetMin(List<decimal> tubeSize)
        {
            decimal min = tubeSize[0];
            int index = 1;
            while (min == 0)
            {
                if (index < tubeSize.Count)
                {
                    min = tubeSize[index];
                    index++;
                }
                else
                {
                    return 0;
                }
            }

            foreach (decimal ele in tubeSize)
            {
                if (ele != 0 && ele < min)
                {
                    min = ele;
                }
            }
            return min;
        }

        private static decimal GetSum(List<decimal> tubeSize)
        {
            decimal sum = new decimal();
            foreach (decimal ele in tubeSize)
            {
                sum += ele;
            }
            return sum;
        }

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            decimal m = int.Parse(Console.ReadLine());
            //int n = 3;
            //int m = 6;
            List<decimal> tubeSize = new List<decimal>();
            for (int i = 0; i < n; i++)
            {
                tubeSize.Add(decimal.Parse(Console.ReadLine()));
            }
            //tubeSize.Add(100);
            //tubeSize.Add(200);
            //tubeSize.Add(300);

            decimal minSize = GetMin(tubeSize);
            decimal sumSize = GetSum(tubeSize);
            int splitNum = (int)(sumSize / m);
            bool loop = true;
            if (minSize != 0)
            {
                while (loop)
                {
                    if (splitNum == 0)
                    {
                        Console.WriteLine("-1");
                        loop = false;
                    }
                    else
                    {
                        if (minSize >= splitNum)
                        {
                            int sum = new int();
                            for (int i = 0; i < n; i++)
                            {
                                if (tubeSize[i] != 0)
                                {
                                    sum += (int)(tubeSize[i] / splitNum);
                                }
                            }
                            if (sum == m)
                            {
                                loop = false;
                                Console.WriteLine(splitNum);
                            }
                            else
                            {
                                splitNum--;
                            }
                        }
                        else
                        {
                            Console.WriteLine("-1");
                            loop = false;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("-1");
            }
        }
    }
}