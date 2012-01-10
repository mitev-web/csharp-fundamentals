using System;

class RandomNumbers
{
    static void Main()
    {
        // This random generator is initialized with random seed
        Random randomGenerator = new Random();
        Console.WriteLine(randomGenerator.Next());

        // This random generator has fixed seed
        Random randomGenerator1 = new Random(123);
        Console.WriteLine(randomGenerator1.Next());

        // This random generator has fixed seed
        Random randomGenerator2 = new Random(456);
        Console.WriteLine(randomGenerator2.Next(50));
    }
}
