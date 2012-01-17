using System;
using System.Collections;

class PrimeNumbers
{
    static void Main()
    {
        const int COUNT = 100;

        bool[] primes = new bool[COUNT + 1];
        for (int i = 2; i <= COUNT; i++)
        {
            primes[i] = true;
        }

        for (int p = 2; p <= COUNT; p++)
        {
            if (primes[p])
            {
                Console.Write("{0} ", p);
                for (int i = 2 * p; i <= COUNT; i += p)
                {
                    primes[i] = false;
                }
            }
        }
        Console.WriteLine();

        //Array arr = Array.CreateInstance(
        //    typeof(bool), new int[] { 5 }, new int[] { 3 });
        //Console.WriteLine(arr.GetValue(4));
    }
}
