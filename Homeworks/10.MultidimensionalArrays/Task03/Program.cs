using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task03
{
    class Program
    {
       static Random rand = new Random();

        static void Main(string[] args)
        {
            //We are given a matrix of strings of size N x M. 
            //Sequences in the matrix we define as sets of several
            //    neighbor elements located on the same line, column 
            //or diagonal. Write a program that finds the longest 
            //    sequence of equal strings in the matrix. Example:

           //ha  fifi ho   hi
           //fo  ha   hi   xx
           //xxx ho   ha   xx
            //
          //answer: ha, ha, ha

            // s  qq  s
            //pp  pp  s
            //pp  qq  s
            //answer: s, s, s
            int N = 3;
            int K = 4;

            string[,] arr = new string[N, K];

            FillMatrix(arr);

            PrintMatrix(arr);

            SearchForMatches(arr);
        }

        public static void SearchForMatches(string[,] arr){
            int N = arr.GetLength(0);
            int K = arr.GetLength(1);

            int curentMax = 0;
            int max = 0;
            string maxStr = "";
            bool sequence = false;

            for (int i = 0; i < N; i++){

                for (int j = 0;j < K-1; j++) {

                    if (sequence)
                    {
                        if (arr[i, j] == arr[i, j + 1])
                        {
                            curentMax++;
                            if (max < curentMax)
                            {
                                maxStr = arr[i, j];
                                max = curentMax;
                            }
                        }
                        else
                        {
                            curentMax = 0;
                            if (max < curentMax)
                            {
                                maxStr = arr[i, j];
                                max = curentMax;
                            }
                            sequence = false;
                        }


                    }
                    else
                    {
                        if (arr[i, j] == arr[i, j + 1])
                        {
                            curentMax = 2;
                            if (max < curentMax)
                            {
                                maxStr = arr[i, j];
                                max = curentMax;
                            }
                            sequence = true;
                        }

                    }
                  
                }
                          
            }

            for (int i = 0; i < max; i++)
            {
                Console.Write(maxStr+",");
                
            }
            Console.WriteLine();
        }


        public static void FillMatrix(string[,] arr) 
        {
           int N = arr.GetLength(0);
           int K = arr.GetLength(1);
            for (int i = 0; i < N; i++) for (int j = 0; j < K; j++) arr[i, j] = RandomString(2); 
        
        }


        public static string RandomString(int size)
        {

            string letters = "AB";
            char[] buff = new char[size];

            for(int i=0; i< size;i++)
            {
                buff[i] =  letters[rand.Next(letters.Length)];
            }

            return new string(buff);
        }

        private static void PrintMatrix(string[,] matrix)
        {
            int n = matrix.GetLength(0);
            int k = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    Console.Write("{0,3}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
