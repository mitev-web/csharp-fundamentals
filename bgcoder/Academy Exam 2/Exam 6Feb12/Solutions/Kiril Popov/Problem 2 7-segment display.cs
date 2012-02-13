
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace P2.SevenSegmentDigits
{
    class Program
    {
        private static string[] inputDigits;
        private static bool[,] possible;
        static bool[] used; 
        //private static int currentDigit = 0;
        private static int N;
        static List<List<int>> comb;
        static void Main(string[] args)
        {
            //using (StreamReader reader = new StreamReader("..\\..\\Input1.txt"))
           // {
                N = int.Parse(Console.ReadLine());
                inputDigits = new string[N];
                possible = new bool[N,7];
                for (int i = 0; i < N; i++)
                {
                    inputDigits[i] = Console.ReadLine();
                    for (int j = 0; j < 7; j++)
                    {
                        if(inputDigits[i][j] == '0')
                        possible[i, j] = true;
                    }
                }
                int variations = 127;
                Dictionary<string, int> possibleDigits = new Dictionary<string, int>();
                for (int i = 0; i < inputDigits.Length; i++)
                {                    
                    for (int j = 1; j <= variations; j++)
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int k = 0; k < 7; k++)
                        {
                            int mask = ((j >> k) & 1);
                            if (possible[i, k] == true)
                            {
                                sb.Append((char)('0' + mask));
                            }
                            else
                            {
                                sb.Append((char)(inputDigits[i][k]));
                            }
                        }
                        if (possibleDigits.ContainsKey(sb.ToString()) == false)
                        {
                            possibleDigits.Add(sb.ToString(), 1);
                        }                       
                    }
                }
                List<int> allDigits = new List<int>();
                foreach (var digit in possibleDigits)
                {
                    allDigits.Add(ConvertVectorToDigit(digit.Key.ToCharArray()));
                }
                used = new bool[allDigits.Count];
                
                comb = new List<List<int>>();
                List<int> c = new List<int>();
                int[] arr = allDigits.ToArray();
                
                GetComb(arr, 0, c);
                Console.WriteLine(comb.Count);
                foreach (var item in comb) 
                {
                    
                    foreach (var x in item) 
                    { 
                        Console.Write(x);
                    }
                    Console.WriteLine("");
                } 
               
            //}   //         
        }

        static void GetComb(int[] arr, int colindex, List<int> c) 
        { 
            if (colindex >= N)
            {
                comb.Add(new List<int>(c));
                return; 
            } 
            for (int i = 0; i < arr.Length; i++)
            { 
                if (!used[i])
                {
                    used[i] = true;
                    c.Add(arr[i]);
                    GetComb(arr, colindex + 1, c);
                    c.RemoveAt(c.Count - 1);
                    used[i] = false;
                } 
            } 
        } 
   
        private static int ConvertVectorToDigit(char[] vector)
        {
            if (vector[0] == '1' && vector[1] == '1' && vector[2] == '1' && vector[3] == '1' &&
                vector[4] == '1' && vector[5] == '1' && vector[6] == '1')
            {
                return 8;
            }
            if (vector[0] == '1' && vector[1] == '1' && vector[2] == '1' && vector[3] == '1' &&
                vector[4] == '1' && vector[5] == '1' && vector[6] == '0' )
            {
                return 0;
            }
            if (vector[0] == '0' && vector[1] == '1' && vector[2] == '1' && vector[3] == '0' &&
                vector[4] == '0' && vector[5] == '0' && vector[6] == '0' )
            {
                return 1;
            }
            if (vector[0] == '1' && vector[1] == '1' && vector[2] == '0' && vector[3] == '1' &&
              vector[4] == '1' && vector[5] == '0' && vector[6] == '1')
            {
                return 2;
            }
            if (vector[0] == '1' && vector[1] == '1' && vector[2] == '1' && vector[3] == '1' &&
               vector[4] == '0' && vector[5] == '0' && vector[6] == '1')
            {
                return 3;
            }
            if (vector[0] == '0' && vector[1] == '1' && vector[2] == '1' && vector[3] == '0' &&
               vector[4] == '0' && vector[5] == '1' && vector[6] == '1')
            {
                return 4;
            }
            if (vector[0] == '1' && vector[1] == '0' && vector[2] == '1' && vector[3] == '1' &&
              vector[4] == '0' && vector[5] == '1' && vector[6] == '1')
            {
                return 5;
            }
            if (vector[0] == '1' && vector[1] == '0' && vector[2] == '1' && vector[3] == '1' &&
              vector[4] == '1' && vector[5] == '1' && vector[6] == '1')
            {
                return 6;
            }
            if (vector[0] == '1' && vector[1] == '1' && vector[2] == '1' && vector[3] == '0' &&
              vector[4] == '0' && vector[5] == '0' && vector[6] == '0')
            {
                return 7;
            }
            return 9;
        }
    }
}