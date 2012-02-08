using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indices
{
    class Program
    {
        static List<int> numbers = new List<int>();
        static int N;
        static int startMarker;
        static bool brackets = false;
       
        //static int[] arr = new int[] { 1, 2, 3, 5, 7, 8 };

        static int[] arr;
        static void Main(string[] args)
        {
            GetInput();

            FindNumbers(0);

            PrintResult();
        }
  
        private static void PrintResult()
        {
            for (int i = 0; i < numbers.Count; i++)
            {
   
                Console.Write(numbers[i]);
                


                if (i < numbers.Count - 1 && numbers[i + 1] == startMarker)
                {
                    Console.Write("(");
                }else if (i != numbers.Count - 1)
                {
                    Console.Write(" ");
                }


                if (brackets == true && i == numbers.Count - 1)
                {
                    Console.Write(")");
                }
            }
        }
  
        private static void GetInput()
        {
            N = int.Parse(Console.ReadLine());
            arr = new int[N];

            arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        }
  
        private static void FindNumbers(int numb)
        {
            if (isOutsideOfArray(numb))
            {
                return;
            }
            if (numbers.Contains(numb))
            {
                startMarker = numb;
                brackets = true;
                return;
            }else{
            numbers.Add(numb);
            }

            int newNumb = arr[numb];
            FindNumbers(newNumb);
        }
  
        private static bool isOutsideOfArray(int index)
        {
            if (index < 0 || index > arr.Length - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}