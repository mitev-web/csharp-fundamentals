
using System;
using System.Linq;

//What is the average of a series of numbers: the quotient of numbers’ 
//sum by their count. Write a program average, which inputs two positive 
//    decimalegers m and n and displays the average of all even numbers, w
//        hich are not less than m and not greater than n.
//Input
//The program inputs two decimalegers m and n. 
//Output
//The program outputs a single number – the wanted average.
//Restrictions
//0<m<n<2000000000
//Examples
//Input
//1 6 
//Output
//4

//Input
//4 12
//Output
//8

    class AverageNumber
    {


        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            string[] numbers = input.Split(new string[] { " " },
        StringSplitOptions.None);

            decimal m = decimal.Parse(numbers[0]);
            decimal n = decimal.Parse(numbers[1]);

            if (m < 0 || m >= n || n > 2000000000 || n<1)
            {
                return;
            }


            decimal sum = 0;
            decimal count = 0;

            for (decimal i = m; i <= n; i++)
            {
                if(i%2==0){
                sum += i;
                    count++;
                }
            }
            decimal answer = sum / count;

            Console.WriteLine(Math.Round(answer));
   
        }
    }
