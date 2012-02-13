using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stars
{
    class starf
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string[] inputing = str.Split(' ');
            int w, h, d;
            w = int.Parse(inputing[0]);
            h = int.Parse(inputing[1]);
            d = int.Parse(inputing[2]);
            char[,,] arr = new char[w, h, d];

            for (int i = 0; i < h; i++)
            {
                string line = Console.ReadLine();
                string[] sequence = line.Split(' ');
                for (int i1 = 0; i1 < d; i1++)
			    {
                    string m = sequence[i1];
                    for (int i2 = 0; i2 < w; i2++)
                    {
                        arr[i2, i, i1] = m[i2];
                    }
			    }
            }

            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            int[] beta = new int[30];
            int total =0;
            
            for (int i = 1; i < h-1; i++)
            {
                for (int i1 = 1; i1 < d-1; i1++)
                {
                    for (int i2 = 1; i2 < w-1; i2++)
                    {
                        if (arr[i2 + 1, i, i1].Equals(arr[i2, i, i1]))
                        {
                            if(arr[i2-1, i, i1].Equals(arr[i2, i, i1]))
                                if(arr[i2, i+1, i1].Equals(arr[i2, i, i1]))
                                    if(arr[i2, i-1, i1].Equals(arr[i2, i, i1]))
                                        if(arr[i2, i, i1+1].Equals(arr[i2, i, i1]))
                                            if(arr[i2, i, i1-1].Equals(arr[i2, i, i1]))
                                            {
                                                int counter = 0;
                                                bool tocheck = false;
                                                do
                                                {
                                                    if (alpha[counter].Equals(arr[i2, i, i1]))
                                                    {
                                                        beta[counter]++;
                                                        total++;
                                                        tocheck = true;
                                                    }
                                                    counter++;
                                                } while (!tocheck);
                                            }
                        }
                    }
                }
            }
            Console.WriteLine(total);
            for (int i = 0; i < alpha.Length; i++)
            {
                if (beta[i] > 0)
                {
                    Console.WriteLine(alpha[i] + " " + beta[i]);
                }
            }
        }
    }
}
