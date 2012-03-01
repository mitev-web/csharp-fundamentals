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
           // Write a program that reads a number N and calculates the sum 
           // of the first N members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
            //Each member of the Fibonacci sequence (except the first two) is a sum of the previous two members.


            Console.WriteLine("Please enter a positive integer");
            int n;
            int.TryParse(Console.ReadLine(), out n);
            SumFibonacciNumbers(n);
        }

        static void SumFibonacciNumbers(int count)
        {
            int a = 0;
            int b = 1;
            int currentFibonacciNumber = 0;
            int[] fiboNumbers = new int[count];


            for (int i = 0; i < count; i++)
            {
                fiboNumbers[i] = currentFibonacciNumber;

                currentFibonacciNumber = a + b;
                a = b;
                b = currentFibonacciNumber;
                //Console.WriteLine(currentFibonacciNumber);
            }

            try {
               Console.WriteLine(fiboNumbers.Sum());
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }
            
        }

        }
    }

