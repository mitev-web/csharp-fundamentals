using System;

class fastRecursiveFibonacci
{
    const int MAX_FIBОNACCI_SEQUENCE_MEMBER = 100;
    static decimal[] fib = new decimal[MAX_FIBОNACCI_SEQUENCE_MEMBER];

    static decimal Fibonacci(int n)
    {
        if (fib[n] == 0)
        {
            // The value of fib[n] is still not calculated -> calculate it now
            if ((n == 1) || (n == 2))
            {
                fib[n] = 1;
            }
            else
            {
                fib[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }
        return fib[n];
    }

    static void Main()
    {
        decimal fib10 = Fibonacci(10);
        Console.WriteLine(fib10);

        decimal fib50 = Fibonacci(50);
        Console.WriteLine(fib50);
    }
}
