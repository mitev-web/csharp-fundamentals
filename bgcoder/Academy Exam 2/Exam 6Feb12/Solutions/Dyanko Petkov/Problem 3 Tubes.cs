using System;
namespace PernikTubes
{
    class Program
    {
        static void Main(string[] args)
        {
            uint N = uint.Parse(Console.ReadLine());
            uint M = uint.Parse(Console.ReadLine());
            ulong[] vinkeli = new ulong[N];
            double result = 0;

            for (int i = 0; i < N; i++)
            {
                vinkeli[i] = ulong.Parse(Console.ReadLine());
            }

            foreach (var tube in vinkeli)
            {
                result += tube;
            }

            if (result % M == 0)
            {
                Console.WriteLine(result / M);
                return;
            }
            else
            {
                result = result / N;
                Array.Sort(vinkeli);
                result = result - vinkeli[0];

                Console.WriteLine((int)result);
            }
        }
    }
}
