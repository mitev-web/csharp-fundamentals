using System;

class RecursiveFibonacciSlow
{
    static decimal Fibonacci(int n)
    {
        if ((n == 1) || (n == 2))
        {
            return 1;
        }
        else
        {
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }

    static void Main()
    {
        decimal fib10 = Fibonacci(10);
        Console.WriteLine(fib10);

        decimal fib50 = Fibonacci(50);
        Console.WriteLine(fib50);
    }
}
