using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task07.A
{
    class Program
    {
        static void Main(string[] args)
        {
            //Here i'm sorting using recursion and different algorithm
            int[] arr = { 2, 2, 63, 2, 5, 5, 5, 5, 7, 7, 2, 2, 6, 7, 8, 2, 1, 1, 1, 6, 7, 73, 3, 1 };

            arr = SortArray(arr);

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }


        static int[] SortArray(int[] arr)
        {
            bool isSorted = true;
            int tempInt = 0;
            for (int i = 0; i < arr.Count() - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    isSorted = false;
                    tempInt = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = tempInt;
                }
            }



            if (isSorted)
                return arr;
            else
                return SortArray(arr);
        }
    }
}
