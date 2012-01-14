using System;
using System.Linq;

//On his birthday, Goshko received from the class-mates an aquarium, containing 
//    K silvery fishes. After one day, silvery fish become golden. 
//After one more day, each gold fish gives birth to one silver fish. 
//    This process is repeated periodically. Help Goshko to monitor the number of fishes in 
//the aquarium without having to count them. Write a program fishglobe, which prdecimals the 
//    total number of fishes in the aquarium after N days.
//Input
//On the single line of the standard input, two natural numbers K and N are written. 
//K – the number of silvery fishes and N - number of days.
//Output
//The only line of the standard output should contain
//    the total number of fishes in the aquarium after N days. 
//Restrictions
//2 ≤ K ≤ 24
//2 ≤ N ≤ 65
//Examples
//Input
//5 7
//Output
//40

class FishGlobe
{
    static void Main(string[] args)
    {
        string[] numbers = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None);
        //fishes
        decimal K = decimal.Parse(numbers[0]);
        //days
        decimal N = decimal.Parse(numbers[1]);
        if (K < 2 || K > 24 || N < 2 || N > 65)
        {
            return;
        }

        decimal count = K;

        for (decimal j = 1; j <= N; j++)
        {
            if (j % 2 == 0)
            {
                for (decimal i = 0; i < K; i++)
                {
                    count++;
                }
                K = count;
            }
        }

        Console.WriteLine(count);
    }
}