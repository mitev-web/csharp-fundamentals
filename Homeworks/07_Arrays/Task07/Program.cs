using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task07
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. Use the "selection sort" algorithm: 
            //Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.
            int[] arr = { 2, 2, 63, 2, 5, 5, 5, 5, 7, 7, 2, 2, 6, 7, 8, 2, 1, 1, 1, 6, 7, 73, 3, 1 };

            arr = SelectionSort(arr);

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }


     
            static int[] SelectionSort(int[] arr)
            {
                int min = 0;
                int temp = 0;

                for (int i = 0; i < arr.Count()-1; i++)
                {
                    min = i;
                    for (int j = i + 1; j < arr.Count(); j++)
                    {
                        if (arr[j] < arr[min]) min = j;
                    }
                    temp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = temp;
                }
              return arr;
            }
        }
    }
