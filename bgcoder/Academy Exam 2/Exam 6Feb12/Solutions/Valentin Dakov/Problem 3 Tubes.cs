using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace Tubes
{
    class Program
    {
        static void Size(int n, int count, int m, int temp, int[] arr, bool first, bool second)
        {
            bool third = true;
            int temporary = 0;
            if (first.CompareTo(second) == 0 && first.CompareTo(third) == 0)
            {
                Console.WriteLine("-1");
                return;
            }
 
            if (temp > m)
            {
                count++;
                int check = 0;
                do
                {
                    temporary = temporary + arr[check]  / count;
                    check++;
                } while (check < n);
                if (temporary != m && first.CompareTo(second) != 0)
                {
                    first = true;
                    Size(n, count, m, temporary, arr, first, second);
                }
                else if (temporary == m)
                {
                    Console.WriteLine(count);
                    return;
                }
            }
 
            else if (temp < m)
            {
                int check = 0;
                count--;
                do
                {
                    temporary = temporary + arr[check] / count;
                    check++;
                } while (check < n);
                if (temporary != m)
                {
                    second = true;
                    Size(n, count, m, temporary, arr, first, second);
                }
                else if (temporary == m)
                    Console.WriteLine(count);
            }
 
        }
 
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            long temp = 0;
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
                temp += arr[i];
            }
            long count = temp / m;
            int count2 = (int)count;
            temp = 0;
            for (int i = 0; i < n; i++)
            {
                temp = temp + (arr[i] - arr[i] % count2) / count2;
            }
            if (temp == m)
                Console.WriteLine(count2);
            else if (temp <0)
                Console.WriteLine("-1");
            bool one = false;
            bool two = false;
            Size(n, count2, m, (int)temp, arr, one, two);
        }
    }
}