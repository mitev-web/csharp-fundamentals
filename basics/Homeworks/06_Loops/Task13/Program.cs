using System;

class Program
{
    static void Main(string[] args)
    {
    //    * Write a program that calculates for given N how many trailing zeros present at the end of the number N!. Examples:
    //N = 10 ? N! = 3628800 ? 2
    //N = 20 ? N! = 2432902008176640000 ? 4
    //Does your program work for N = 50 000?
    //Hint: The trailing zeros in N! are equal to the number of its prime divisors of value 5. Think why!

        int N = new int();
        Console.WriteLine("Enter N");
        if (!int.TryParse(Console.ReadLine(), out N))
        {
            Console.WriteLine("Invalid Input");
        }
        ulong number = new ulong();

        try 
        {
            number = Factorial(N);
            Console.WriteLine(number);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }

        int zerosCount = 0;

        for (int i = 5; i <= N; i *= 5)
        {
            zerosCount += N / i;
        }
        Console.Write("Number of zeros is {0}", zerosCount);
    }

    private static ulong Factorial(int number)
    {
        ulong factorial = 1;
        for (int i = 1; i < number; i++)
        {
            factorial += factorial * (ulong)i;
        }
        return factorial;
    }
}