using System;
using System.Linq;


    class MiniPoker
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None);
            int[] arr = numbers.Select(x => int.Parse(x)).ToArray();
            Array.Sort(arr);

            bool consecutive = true;

            for (int i = 0; i < arr.Length-1; i++)
            {
                if (arr[i] + 1 != arr[i + 1])
                {
                    consecutive = false;
                }
            }

            if (consecutive)
            {
                foreach (var item in arr)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine(arr.Last());

            }

        }
    }

