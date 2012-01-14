using System;
using System.Linq;
//Given are n boxes, which were empty. During the day Ivancho placed balls k times in some of the boxes. Write program balls, which computes the number of empty boxes at the end of the day.

//The program reads data by the standard input. On the first line are given the values of n and k. On each of the next k lines a box number (1,2,…n), in which Ivancho has set balls, is given.

//On the standard output the program has to write an integer, which is the sought value.

//Constraints:
//1 < n < 1 000 000 000 000
//1 < k < 101

//Example.
//Input:
//5 4
//1 
//1 
//2 
//2 

class Balls
{
    static void Main(string[] args)
    {
        decimal[] numbers = Console.ReadLine().Split(' ').Select(x => decimal.Parse(x)).ToArray();

        //boxes
        decimal N = numbers[0];

        int K = int.Parse(numbers[1].ToString());

        decimal[] filledboxes = new decimal[K];

        for (int i = 0; i < K; i++)
        {
            filledboxes[i] = decimal.Parse(Console.ReadLine());
        }

        decimal differenFilledBoxes = filledboxes.Distinct().ToArray().LongCount();

        Console.WriteLine(N-differenFilledBoxes);
    }
}

