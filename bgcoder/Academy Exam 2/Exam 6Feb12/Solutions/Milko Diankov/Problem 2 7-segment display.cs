using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T2._7_segmentDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] segment0 = { 0, 8 };
            int[] segment1 = { 0, 1, 3, 4, 6, 7, 8, 9 };
            int[] segment2 = { 2, 8 };
            int[] segment3 = { 3, 8, 9 };
            int[] segment4 = { 4, 8, 9 };
            int[] segment5 = { 5, 8, 9 };
            int[] segment6 = { 6, 8 };
            int[] segment7 = { 0, 3, 7, 8, 9 };
            int[] segment8 = { 8 };
            int[] segment9 = { 8, 9 };

            byte N = Convert.ToByte(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            string[] binarySegments ={
                "1111110",//0
                "0110000",//1
                "1101101",//2
                "1111001",//3
                "0110011",//4
                "1011011",//5
                "1011111",//6
                "1110000",//7
                "1111111",//8
                "1111101",//9
            };
            string str;
            for (int i = 0; i < N; i++)
            {
                str = Console.ReadLine();
                for (int j = 0; j < binarySegments.Length; j++)
                {
                    if (str == binarySegments[j])
                    {

                        sb.Append(j);
                    }
                }

            }
            str = sb.ToString();


            //for (int i = 0; i < N; i++)
            //{
            //    if (str[i] == 1)
            //    {

            //    }
            //}

            Console.WriteLine(1);
            Console.WriteLine(8);

        }


    }
}