using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitwiseMethods
{
    class Program
    {

        //Convert.ToString(number, 2).PadLeft(16, '0');

        ////from str to int
        //int z = Convert.ToInt32("11001001", 2);

        ////swap first 4 wish second 4
        //  x = ((x & 0xf) << 4) | ((x & 0xf0) >> 4);


        static void Main(string[] args)
        {
            ReverseNumber(36);
        }

        public static int GetBit(int value, int position)
        {
            int bit = value & (int)Math.Pow(2, position);
            return (bit > 0 ? 1 : 0);
        }

        public static void GetLast3Bits(int number)
        {
            for (int i = 0; i < 3; i++)
            {

                if ((number & 1) == 1)
                {
                    Console.WriteLine("current bit is 1");

                }
                else
                {
                    Console.WriteLine("currentbit is 0");
                }
                number = number >> 1;

            }
        }


        public static void GetBitsFromPosition(int number, int position, int bits)
        {
            int count = 0;
        
                while (count < position)
                {
                    number = number >> 1;
                    count++;
                }
                for (int i = 0; i < bits; i++)
                {
                    if ((number & 1) == 1)
                    {
                        Console.WriteLine("1");
                    }
                    else
                    {
                        Console.WriteLine("0");
                    }
                    number = number >> 1;
                }
        }


        public static void GetBitsFromPositionAndReverse(int number, int position, int bits)
        {
            int count = 0;
            int mask = 0;
            while (count < position)
            {
                number = number >> 1;
                count++;
            }
            for (int i = 0; i < bits; i++)
            {
                if ((number & 1) == 1)
                {
                    mask = mask | 0;
                }
                else
                {
                    mask = mask | 1;
                }
                mask = mask << 1;
                number = number >> 1;
            }

            Console.WriteLine(Convert.ToString(mask, 2).PadLeft(16, '0'));
        }

        
        public static void ReverseNumber(int number)
        {//not ready
            Console.WriteLine(Convert.ToString(number, 2).PadLeft(16, '0'));
            int tempnumb = 1;
            while (number != 0)
            {
                if ((number & 1) == 1)
                {
                    tempnumb = tempnumb | 0;
                }
                else
                {
                    tempnumb = tempnumb | 1;
                }
                tempnumb = tempnumb << 1;
                number = number >> 1;
            }
            tempnumb = tempnumb >> 1;

            Console.WriteLine(Convert.ToString(tempnumb, 2).PadLeft(16, '0'));
        }


        static string GetIntBinaryString(int n)
        {
            char[] b = new char[32];
            int pos = 31;
            int i = 0;

            while (i < 32)
            {
                if ((n & (1 << i)) != 0)
                    b[pos] = '1';
                else
                    b[pos] = '0';
                pos--;
                i++;
            }
            return new string(b);
        }

        public static void CountBits(uint number, byte B)
        {
            //count one or 0 in the number
            //byte should be one or 0
                int count = 0;
                while (number != 0)
                {
                    if ((number & 1) == B)
                    {
                        count++;
                    }
                    number = number >> 1;
                }
                // Write answers
                Console.WriteLine(count);
        }



    }
}
