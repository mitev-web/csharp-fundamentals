using System;
using System.Linq;

class Cubes
{
    static void Main(string[] args)
    {
        long[] arr = Console.ReadLine().Split(' ').Select(x => long.Parse(x)).ToArray();

        decimal a = arr[0];
        decimal b = arr[1];
        decimal c = arr[2];


        decimal BigBoxV = a * b * c;

        
        decimal cubeSide = findGCD(c, findGCD(a, b));

        decimal cubeV = cubeSide * cubeSide * cubeSide;

        Console.WriteLine(Math.Round(BigBoxV / cubeV));
    }

    public static decimal findGCD(decimal a, decimal b)
    {

        if (b == 0)
        {
            return a;
        }
        else
        {
            return (findGCD(b, a % b));
        }

    }
}

