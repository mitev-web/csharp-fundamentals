using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that calculates N!/K! for given N and K (1<N<K).

            double N;
            double K;
            double result =  new double();
            string inputLine;

            Console.WriteLine("Please enter value for N");
            inputLine = Console.ReadLine();


            double.TryParse(inputLine, out N);

            Console.WriteLine("Please enter value for K");
            inputLine = Console.ReadLine();
            double.TryParse(inputLine, out K);

            if (!(1 < N && N < K))
            {
                Console.WriteLine("invalid N or K");
                return;
            }

            result = Factorial(N) / Factorial(K);

            Console.WriteLine(result);

         

        }

        static double Factorial(double x)
        {
            int factorial = 1;
            for (int i = 1; i < x; i++)
            {
                factorial += factorial * i;
            }

            return factorial;
        }
    }
}
