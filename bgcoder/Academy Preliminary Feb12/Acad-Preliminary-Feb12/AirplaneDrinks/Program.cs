using System;
using System.Linq;

namespace GenomeDecoder
{
    class Program
    {
        static int N;
        static bool[] pass = null;
        static bool[] isServed = null;

        static int seconds = 48;
        static int drinks = 7;
        static bool currentlyServing;
        static bool nextDrink = false;
        static bool passangersAreServed = false;

        static void Main(string[] args)
        {
            //true = tea
            N = int.Parse(Console.ReadLine());
            int K = int.Parse(Console.ReadLine());
            pass = new bool[N];
            isServed = new bool[N];

            for (int i = 0; i < K; i++)
            {
                pass[int.Parse(Console.ReadLine()) - 1] = true;
            }

            currentlyServing = true;
            CalculateServingTime();
            int secondsWhenStartingWithTea = seconds;

            ResetParams();
            currentlyServing = false;
            CalculateServingTime();
            int secondsWhenStartingWithCoffee = seconds;

            if (secondsWhenStartingWithCoffee < secondsWhenStartingWithTea)
            {
                Console.WriteLine(secondsWhenStartingWithCoffee);
            }
            else
            {
                Console.WriteLine(secondsWhenStartingWithTea);
            }
        }

        private static void CalculateServingTime()
        {

            while (!passangersAreServed)
            {
                ServeFromBeginning();



                //ServeFromEnd();
           

            }
        }
  
        private static void ServeFromBeginning()
        {
            for (int i = 0; i < N; i++, seconds++)
            {
                if (RefillIsNeeded())
                {
                    Refill(i);
                    i = 0;
                }
                if (isServed[i] == false)
                {
                    if (pass[i] == currentlyServing)
                    {
                        isServed[i] = true;
                        drinks--;
                        seconds += 4;
                        if (PassangersAreServed())
                        {
                            passangersAreServed = true;
                            return;
                        }
                    }
                }
            }
        }
  
        private static void ServeFromEnd()
        {
            for (int i = N - 1; i >= 0; i--,seconds++)
            {
                if (RefillIsNeeded())
                {
                    Refill(i);
                    return;
                }
                if (isServed[i] == false)
                {
                    if (pass[i] == currentlyServing)
                    {
                        isServed[i] = true;
                        seconds += 4;
                        drinks--;
                        if (PassangersAreServed())
                        {
                            passangersAreServed = true;
                            return;
                        }
                    }
                }
            }
        }

        private static bool RefillIsNeeded()
        {
            bool refillIsneeded = false;

            for (int i = 0; i < N; i++)
            {
                if (pass[i] != currentlyServing && !isServed[i])
                {
                    nextDrink = pass[i];
                }
            }

            for (int i = 0; i < N; i++)
            {
                if (pass[i] != currentlyServing && !isServed[i] && drinks == 0)
                {
                    refillIsneeded = true;
                    nextDrink = pass[i];
                    return true;
                }

                refillIsneeded = true;
                if (pass[i] == currentlyServing && !isServed[i] && drinks > 0)
                {
                    return false;
                }
            }

            return refillIsneeded;
        }
  
        private static void Refill(int position)
        {
            seconds += position + 2 + 47;
            currentlyServing = nextDrink;
       
            drinks = 7;
        }
  
        private static bool PassangersAreServed()
        {
            bool areServerd = true;
            for (int i = 0; i < isServed.Length; i++)
            {
                if (isServed[i] == false)
                {
                    areServerd = false;
                }
            }
            return areServerd;
        }

        private static void ResetParams()
        {
            pass = new bool[N];
            isServed = new bool[N];
            pass[1] = true;
            pass[2] = true;
            seconds = 48;
            drinks = 7;
            nextDrink = false;
            passangersAreServed = false;
        }
    }
}