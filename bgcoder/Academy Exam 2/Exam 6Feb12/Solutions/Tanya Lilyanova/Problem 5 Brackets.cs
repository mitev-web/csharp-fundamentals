using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Solution2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            string p = Console.ReadLine();

            n = p.Length;

            BigInteger r;

            char[] s = new char[n + 2];

            for (int i = 0; i < n; i++) s[i + 1] = p[i];

            int c, k;
            BigInteger[,] f = new BigInteger[n + 2, n + 3];

            for (c = 0; c <= n + 1; c++) f[0, c] = 0;
            for (k = 0; k <= n; k++) f[k, n + 1] = 0;


            f[0, 0] = 1;
            for (k = 1; k <= n; k++)
            {
                c = 0;
                if (s[k] == '(') f[k, c] = 0;
                else if (s[k] == ')') f[k, c] = f[k - 1, c + 1];
                else f[k, c] = f[k - 1, c + 1];


                for (c = 1; c <= n; c++)
                {
                    if (s[k] == '(') f[k, c] = f[k - 1, c - 1];
                    else if (s[k] == ')') f[k, c] = f[k - 1, c + 1];
                    else f[k, c] = f[k - 1, c - 1] + f[k - 1, c + 1];
                }
            }
            r = f[n, 0];


            Console.WriteLine(r);



        }
    }
}
