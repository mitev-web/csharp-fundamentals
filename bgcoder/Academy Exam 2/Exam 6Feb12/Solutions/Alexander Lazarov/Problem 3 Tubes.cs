using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Izpit
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[] mSizes = new int[n];
            int count=0;
            for (int i = 0; i < n; i++)
            {
                mSizes[i] = int.Parse(Console.ReadLine());
                count +=mSizes[i];
            }
            Array.Sort(mSizes);
            decimal biggestNum = Convert.ToDecimal(count/m);
            int number = count/m;
            int biggestLen = (getLen(count/m));
            decimal length = Convert.ToDecimal(biggestLen);
            int numb = count/m;
            for (int i = 0; i < biggestLen; i++)
			{
                numb = numb / 10;
			}
            decimal calc = Convert.ToDecimal(numb);
            string s = Convert.ToString(Math.Round(calc, 0));
            int newNum = Convert.ToInt32(s);
            for (int i = 0; i < biggestLen; i++)
            {
                newNum = newNum * 10;
            }
            if (count < m )
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(newNum);
            }
        }


        static int getLen(int x)
        {
            if (x < 1000000)
            {
                if (x < 100) return 1;
                if (x < 1000) return 2;
                if (x < 10000) return 3;
                if (x < 100000) return 4;
                return 5;
            }
            else
            {
                if (x < 10000000) return 6;
                if (x < 100000000) return 7;
                if (x < 1000000000) return 8;
                return (int)Math.Truncate(Math.Log10(x)) + 1; // Very uncommon
            }
        }
    }
}
