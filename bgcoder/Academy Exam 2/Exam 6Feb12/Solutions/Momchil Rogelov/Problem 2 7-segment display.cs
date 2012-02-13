using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Digit[] digits = new Digit[2];
            //digits[0] = new Digit("1111110");
            //digits[1] = new Digit("1111111");
            
            int n = int.Parse(Console.ReadLine());
            //int n =1;
            Digit[] digits= new Digit[n];
            for (int i = 0; i < n; i++)
            {
                digits[i]= new Digit(Console.ReadLine());
                //digits[0] = new Digit("1011111");
            }
            
            //Array.Reverse(digits);

            List<string> result = new List<string>();

            foreach (Digit item in digits)
            {
                int[] possibleDigits = item.GetPossibleDigits();
                result=AddToResult(result, possibleDigits);
            }

            string[] finalres = result.ToArray();
            Array.Sort(finalres);
            Console.WriteLine(finalres.Length);
            foreach (string item in finalres)
            {
                Console.WriteLine(item);
            }
        }

        private static List<string> AddToResult(List<string> result, int[] possibleDigits)
        {
            // TODO: Implement this method
            List<string> newres = new List<string>();
            if (result.Count == 0) 
            {
                foreach (var item in possibleDigits)
                {
                    newres.Add(item.ToString());
                }
            }
            else
            {
                foreach (int possibleInt in possibleDigits)
                {
                    foreach (string oldres in result)
                    {
                        newres.Add(oldres + possibleInt.ToString());
                    }
                }
            }
            return newres;
        }
    }

    class DigitHelper
    {
        static string[] numbers;
        public static List<int[]> permutationsOfPanels = new List<int[]>();

        static DigitHelper()
        {
            numbers = new string[10];
            numbers[0] = "1111110";
            numbers[1] = "0110000";
            numbers[2] = "1101101";
            numbers[3] = "1111001";
            numbers[4] = "0110011";
            numbers[5] = "1011011";
            numbers[6] = "1011111";
            numbers[7] = "1110000";
            numbers[8] = "1111111";
            numbers[9] = "1111011";
        }
 
        static public int StringToNumber(string numStr)
        {
            return Array.IndexOf(numbers, numStr);
        }
        static public int ArrayToNumber(int[] arr) 
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in arr)
            {
                sb.Append(item);
            }
            return StringToNumber(sb.ToString());
        }

    }
    public class Digit 
    {
        private int[] panels;

        private List<int[]> possiblePanels= new List<int[]>();

        public Digit(string litPanels)
        {
            this.panels = new int[7];
            for (int i = 0; i < litPanels.Length; i++)
            {
                panels[i] = int.Parse(litPanels[i].ToString());
            }
            this.GeneratePossiblePanels(this.panels, 0);
        }

        private void GeneratePossiblePanels(int[] pern, int index)
        {
            if (index == 7)
            {
                possiblePanels.Add(pern);
                return;
            }
            else
            {
                int nextIndex = index+1;
                if (panels[index] == 0) 
                {
                    int[] newP = (int[])pern.Clone();
                    newP[index] = 1;
                    GeneratePossiblePanels(newP, nextIndex);
                }
                GeneratePossiblePanels(pern, nextIndex);
            }
        }

        public void PrintPossiblePanels() 
        {
            foreach (var item in possiblePanels)
            {
                foreach (var b in item)
                {
                    Console.Write(b);
                }
                Console.WriteLine();
            }
        }

        public int ToInt()
        {
            char[] digitC = new char[7];
            for (int i = 0; i < panels.Length; i++)
			{
			    digitC[i]= panels[i].ToString()[0];
			}
            return DigitHelper.StringToNumber(new string(digitC));
        }

        public void PrintPossibleDigits() 
        {
            foreach (int[] item in possiblePanels)
            {
                int number = DigitHelper.ArrayToNumber(item);
                if (number>=0 && number<10) 
                {
                    Console.WriteLine(number);
                }
            }
        }
        public int[] GetPossibleDigits() 
        {
            List<int> result = new List<int>();
            foreach (int[] item in possiblePanels)
            {
                int number = DigitHelper.ArrayToNumber(item);
                if (number >= 0 && number < 10)
                {
                    result.Add(number);
                }
            }
            return result.ToArray();
        }
    }
}
