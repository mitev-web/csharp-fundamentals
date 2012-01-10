using System;
using System.Linq;


    class AverageNumber
    {
        //What is the average of a series of numbers: the quotient of numbers’ 
        //sum by their count. Write a program average, which inputs two positive 
        //    integers m and n and displays the average of all even numbers, w
        //        hich are not less than m and not greater than n.
        //Input
        //The program inputs two integers m and n. 
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

        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            string[] numbers = input.Split(new string[] { " " },
        StringSplitOptions.None);

            int m = int.Parse(numbers[0]);
            int n = int.Parse(numbers[1]);

            if (m < 0 || m >= n || n > 2000000000 || n<1)
            {
                return;
            }
            ulong sum = 0;
            int count = n - m+1;
            for (int i = m; i <= n; i++)
            {
                sum += (ulong)i;
            }
            double answer = Convert.ToDouble((double)sum / (double)count);
            Console.WriteLine(Math.Round(answer));
   
        }
    }
