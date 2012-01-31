using System;
using System.Linq;


    class Program
    {
     
    //        * Write a program that reads a number N and generates and prints 
    //            all the permutations of the numbers [1 … N]. Example:
    //n = 3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}

        static void GenPermutations(int[] vector, int index)
        {
            if (index == vector.Length)
            {
                Print(vector);
            }
            else
            {
                for (int i = index; i < vector.Length; i++)
                {
                    int temp = vector[i];
                    vector[i] = vector[index];
                    vector[index] = temp;
                    GenPermutations(vector, index + 1);
                    temp = vector[i];
                    vector[i] = vector[index];
                    vector[index] = temp;
                }
            }
        }

        static void Print(int[] vector)
        {

            foreach (int element in vector)
            {
                Console.Write(" {0} ", element);
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.Write("Enter number N: ");
            string inputStr = Console.ReadLine();
            int n = int.Parse(inputStr);
            int[] array = new int[n];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }
            GenPermutations(array, 0);
        }
    }
