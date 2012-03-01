using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

        int v;           // we want to find the absolute value of v
        uint r;  // the result goes here 


       // r = (v + mask) ^ mask;
            Console.WriteLine(sizeof(int));
        }

        public static void ExchangeBits(ref uint number, byte firstIndex, byte secondIndex, byte count)
        {
            ulong num = number;
            ExchangeBits(ref num, firstIndex, secondIndex, count, 32);
            number = (uint)num;
        }

        public static void ExchangeBits(ref ulong number, byte firstIndex, byte secondIndex, byte count, byte size)
        {
            ulong firstMask = 0; // mask used to save first group of bits
            ulong secondMask = 0; // mask used to save second group of bits

            // sets the masks
            for (int i = firstIndex; i < secondIndex + count; i++)
            {
                if (i >= firstIndex && i < firstIndex + count)
                {
                    if (i >= size)
                        firstMask += (ulong)Math.Pow(2, i - size);
                    else
                        firstMask += (ulong)Math.Pow(2, i);
                }
                if (i >= secondIndex && i < secondIndex + count)
                {
                    if (i >= size)
                        secondMask += (ulong)Math.Pow(2, i - size);
                    else
                        secondMask += (ulong)Math.Pow(2, i);
                }
            }
            ulong firstBits = firstMask & number; // first group of bits on their original position
            ulong secondBits = secondMask & number; // second group of bits on their original position

            firstBits <<= secondIndex - firstIndex; // move first group to second group's position

            if (firstIndex + count >= size) // if first group's index + bits' count is larger than number's size...
            {
                ExchangeBits(ref firstBits, 0, (byte)size, (byte)(secondIndex - count), 64); // ...put all bits from the group together, at the end
            }
            if (secondIndex + count >= size) // same for second group
            {
                ExchangeBits(ref secondBits, 0, size, (byte)(count - (size - secondIndex)), 64);
            }

            secondBits >>= secondIndex - firstIndex; // move second group to first group's position

            number &= (ulong)~(firstMask | secondMask); // set all bits from the two groups to 0

            // change the bits in the two groups
            for (int i = firstIndex; i < secondIndex + count; i++)
            {
                bool first = false; // true if i = [firstIndex; firstIndex + count)
                if (i >= firstIndex && i < firstIndex + count) // if i is in first group
                {
                    bool bit = (secondBits >> i) % 2 == 1; // check if current bit is 1
                    if (bit)        // if it is 1, change that bit from the original number to 1
                    {
                        if (i >= size)
                            number += (ulong)Math.Pow(2, i - size);    // if bit's position is larger than number's size start from the first bit.
                        else
                            number += (ulong)Math.Pow(2, i);
                    }
                    first = true;
                }
                else if (i >= secondIndex && i < secondIndex + count && !first) // do the same, if i is in second group
                {
                    bool bit = (firstBits >> i) % 2 == 1;
                    if (bit)
                    {
                        if (i >= size)
                            number += (ulong)Math.Pow(2, i - size);
                        else
                            number += (ulong)Math.Pow(2, i);
                    }
                }
            }
        }
    }
}
