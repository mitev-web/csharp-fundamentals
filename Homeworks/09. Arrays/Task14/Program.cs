using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task14
{
    class Program
    {

 
        static void Main(string[] args)
        {
            //Write a program that sorts an array of strings using the quick sort algorithm 
            //(find it in Wikipedia).


            int[] array = { 2, 4, 5, 2, 1, 0, -33, 424, 12, 522 };
            int left = 0;
            int right = array.Length - 1;

            q_sort(array, left, right);

            foreach (var e in array)
            {
                Console.WriteLine(e);
            }
        }

        
 

 
        public static void q_sort(int[] array, int left, int right)
        {
            int pivot, l_hold, r_hold;
 
            l_hold = left;
            r_hold = right;
            pivot = array[left];
 
            while (left < right)
            {
                while ((array[right] >= pivot) && (left < right))
                {
                    right--;
                }
 
                if (left != right)
                {
                    array[left] = array[right];
                    left++;
                }
 
                while ((array[left] <= pivot) && (left < right))
                {
                    left++;
                }
 
                if (left != right)
                {
                    array[right] = array[left];
                    right--;
                }
            }
 
            array[left] = pivot;
            pivot = left;
            left = l_hold;
            right = r_hold;
 
            if (left < pivot)
            {
                q_sort(array, left, pivot - 1);
            }
 
            if (right > pivot)
            {
                q_sort(array, pivot + 1, right);
            }
        }
    }
}
