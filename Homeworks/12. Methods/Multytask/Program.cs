using System;
using System.Linq;

namespace Multytask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please choose operation");
            Console.WriteLine("1. Reverse Number");
            Console.WriteLine("2. Calculate average of sequence");
            Console.WriteLine("3. Solve linear equation");


            switch (Console.ReadLine())
            {
                case "1":
                    int number = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter positive number");
                    if (number < 0)
                    {
                        Console.WriteLine("number should be positive");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Reversed number is");
                        Console.WriteLine(ReverseNumber(number));
                    }
                    break;
                case "2":
                    Console.WriteLine("Please enter some numbers separated by space and hit enter");
                    string line = Console.ReadLine();

                    string[] strNumbers = line.Split(new string[] { " " }, StringSplitOptions.None);
                    int[] numbers = strNumbers.Select(x => int.Parse(x)).ToArray();

                    Console.WriteLine("The average of these numbers is: {0:F2} ", Average(numbers));
                    break;
                                           
                                           
                case "3":
                    Console.WriteLine("Enter a");
                    int a = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter b");
                    int b = int.Parse(Console.ReadLine());
                    Console.WriteLine("x =");
                    Console.WriteLine(CalculateNinearEquation(a,b));
                    
                    break;

            }

        }


        public static double Average(int[] numbers)
        {
            return numbers.Average();
        }

        public static int ReverseNumber(int number)
        {

            string reversed = "";
            while (number > 0)
            {
                reversed += number % 10;
                number /= 10;
            }

            return int.Parse(reversed);
        }



        public static double CalculateNinearEquation(int a, int b)
        {
            b = -1 * b;
            return b / a;
        }
    }
}
