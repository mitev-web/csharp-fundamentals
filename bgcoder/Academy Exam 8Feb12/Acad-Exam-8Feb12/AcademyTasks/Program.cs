using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyTasks
{
    class Program
    {
        static List<int> numbers;
        static List<int> solved = new List<int>();
        static int N;
        static int minNum = 0;
        static int maxNum = 0;
        static bool skipped = false;
        static void Main(string[] args)
        {
            GetInput();

            if (!IsNotPleasant())
            {
                Console.WriteLine(solved.Count);
            }
           
        }
  
        private static bool IsNotPleasant()
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                //we skip a number
                if (!skipped && i < (numbers.Count) && solved.Count > 0 && solved.Last() == numbers[i]-1)
                {
                    skipped = true;
                    continue;
                }

                if(solved.Count >0){
                minNum = solved.Min();
                maxNum = solved.Max();
                }

                int variety = maxNum - minNum;

                if (variety >= N)
                {
                    Console.WriteLine(solved.Count);
                    return true;
                }

                solved.Add(numbers[i]);
            }

            return false;
        }

        private static void GetInput()
        {
            numbers = Console.ReadLine().Split(new string[] { ", " },
                StringSplitOptions.None).Select(x => int.Parse(x)).ToList();

            N = int.Parse(Console.ReadLine());
        }
    }
}