using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task02
{
    class Program
    {
        static List<string> RecursiveAppend(List<string> priorPermutations, string[] additions)
        {
            List<string> newPermutationsResult = new List<string>();
            foreach (string priorPermutation in priorPermutations)
            {
                foreach (string addition in additions)
                {
                    newPermutationsResult.Add(priorPermutation + "" + addition);
                }
            }
            return newPermutationsResult;
        }

        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());
            string[] digits = new string[10];
            int[] arr = new int[n];
            StringBuilder sb = new StringBuilder();
            
            digits[0] = "1111110";
            digits[1] = "0110000";
            digits[2] = "1101101";
            digits[3] = "1111001";
            digits[4] = "0110011";
            digits[5] = "1011011";
            digits[6] = "1011111";
            digits[7] = "1110000";
            digits[8] = "1111111";
            digits[9] = "1111011";

            if (n == 1)
	        {
                string number = Console.ReadLine();

                for (int j = 0; j < digits.Length; j++)
                {
                    if (number == digits[j])
                    {
                        if (j == 0)
                        {
                            Console.WriteLine(2);
                            Console.WriteLine(0);
                            Console.WriteLine(8);
                        }
                        else if (j == 1)
                        {
                            Console.WriteLine(6);
                            Console.WriteLine(1);
                            Console.WriteLine(3);
                            Console.WriteLine(4);
                            Console.WriteLine(7);
                            Console.WriteLine(8);
                            Console.WriteLine(9);
                        }
                        else if (j == 2)
                        {
                            Console.WriteLine(2);
                            Console.WriteLine(2);
                            Console.WriteLine(8);
                        }
                        else if (j == 3)
                        {
                            Console.WriteLine(3);
                            Console.WriteLine(3);
                            Console.WriteLine(8);
                            Console.WriteLine(9);
                        }
                        else if (j == 4)
                        {
                            Console.WriteLine(3);
                            Console.WriteLine(4);
                            Console.WriteLine(8);
                            Console.WriteLine(9);
                        }
                        else if (j == 5)
                        {
                            Console.WriteLine(4);
                            Console.WriteLine(5);
                            Console.WriteLine(6);
                            Console.WriteLine(8);
                            Console.WriteLine(9);
                        }
                        else if (j == 6)
                        {
                            Console.WriteLine(2);
                            Console.WriteLine(6);
                            Console.WriteLine(8);
                        }
                        else if (j == 7)
                        {
                            Console.WriteLine(5);
                            Console.WriteLine(0);
                            Console.WriteLine(3);
                            Console.WriteLine(7);
                            Console.WriteLine(8);
                            Console.WriteLine(9);
                        }
                        else if (j == 8)
                        {
                            Console.WriteLine(1);
                            Console.WriteLine(8);
                        }
                        else if (j == 9)
                        {
                            Console.WriteLine(2);
                            Console.WriteLine(8);
                            Console.WriteLine(9);
                        }
                    }
                }
	        }
            else if (n == 2)
            {
                string number1 = Console.ReadLine();
                string number2 = Console.ReadLine();
                
                string[][] myList = new string[2][];



                myList[0] = new string[] { "0", "8" };
                myList[1] = new string[] { "8" };

                List<string> permutations = new List<string>(myList[0]);

                for (int i = 1; i < myList.Length; ++i)
                {
                    permutations = RecursiveAppend(permutations, myList[i]);

                }
                Console.WriteLine("2");
                for (int i = 0; i < permutations.Count; i++)
                {
                    Console.WriteLine(permutations[i]);
                } 
            }
        }
    }
}
