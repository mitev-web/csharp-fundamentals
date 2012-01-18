using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task15
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that finds all prime numbers in the range [1...10 000 000].
            //    Use the sieve of Eratosthenes algorithm (find it in Wikipedia).
  
                int n = 100000;
                bool[] notPrime = new bool[n + 1];
                notPrime[0] = true;
                notPrime[1] = true;

                for (long i = 2; i < Math.Sqrt(n); i++)
                {
                    if (notPrime[i] == false)
                    {
                        Console.WriteLine(i);
                        for (long j = i * 2; j <= n; j += i)
                        {
                            notPrime[j] = true;
                        }
                    }
                }
                }


        }
    }

