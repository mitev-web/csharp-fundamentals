using System;
using System.Linq;


class FishGlobe
{
//On his birthday, Goshko received from the class-mates an aquarium, containing 
//    K silvery fishes. After one day, silvery fish become golden. 
//After one more day, each gold fish gives birth to one silver fish. 
//    This process is repeated periodically. Help Goshko to monitor the number of fishes in 
//the aquarium without having to count them. Write a program fishglobe, which prints the 
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

    static void Main(string[] args)
    {

       string[] numbers = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None);

        int K = int.Parse(numbers[0]);
        int N = int.Parse(numbers[1]);
        if (K < 2 || K > 24 || N < 2 || N > 65)
        {
            return;
        }


        int count = K;
        for (int i = 1; i <= K; i++)
        {
            for (int j = 0; j < N; j++)
            {
                count++;
            }

        }

        Console.WriteLine(count);
    }


}

