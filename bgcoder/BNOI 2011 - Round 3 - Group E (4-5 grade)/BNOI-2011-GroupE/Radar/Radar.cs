using System;
using System.Linq;

class Radar
{
    //        Напишете програма radars, която намира възможно най-голямата мощност на
    //излъчване на телевизионните предавания.
    //Вход
    //От първия ред на стандартния вход се въвежда едно цяло число n. От втория ред
    //се въвеждат n цели числа 0 1 1 , ,..., n − x x x , разделени с по един интервал.
    //Изход
    //На един ред на стандартния изход програмата трябва да изведе едно цяло число
    //– максималната мощност на излъчване.
    //Ограничения
    //3 ≤ n ≤ 100 000
    //–1 000 000 ≤ xi ≤ 1 000 000
    //Пример
    //Вход
    //5
    //3 1 5 2 4
    //Изход
    //4
    static void Main(string[] args)
    {
        long N = long.Parse(Console.ReadLine());

        string[] strNumbers = Console.ReadLine().Split(' ');
        long[] arr = strNumbers.Select(x => long.Parse(x)).ToArray();
           
        Array.Sort(arr);

        //the 3 radar podoubles will be a, b and c

        //a is always first in sorted array
        long a = arr[0];
        //c will always be last in sorted array
        long c = arr[arr.Count() - 1];

        if (a == c)
            return;

        long temp = 0;
        long max = long.MinValue;
        long b = 0;

        for (int i = 1; i < arr.Length - 1; i++)
        {
            temp = (c - arr[i]) * (arr[i] - a);

            if (temp > max && arr[i] != c && arr[i] != a && b < 1000000 && b > -1000000)
            {
                max = temp;
                b = arr[i];
            }
        }

        Console.WriteLine((b - a) * (c - b));
    }
}