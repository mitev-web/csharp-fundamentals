using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prob4_3DStars
{
    class Program
    {
        static void Main(string[] args)
        {
            // input
            string input = Console.ReadLine();
            string[] nums = input.Split(' ');

            int w = int.Parse(nums[0]);
            int h = int.Parse(nums[1]);
            int d = int.Parse(nums[2]);

            string[] cuboid = new string[h];
            for (int i = 0; i < h; i++)
            {
                cuboid[i] = Console.ReadLine();
            }

            int[] starsCount = new int[26];
            int total = 0;
            for (int i = 1; i < cuboid.Length - 1; i++)
            {
                for (int j = w + 1; j < cuboid[i].Length - w - 1; j++)
                {
                    if (AreEqual(cuboid[i][j], cuboid[i][j - 1], cuboid[i][j + 1],
                        cuboid[i - 1][j], cuboid[i + 1][j], cuboid[i][j + w + 1], cuboid[i][j - w - 1]))
                    {
                        starsCount[cuboid[i][j] - 65]++;
                        total++;
                    }
                }
            }

            Console.WriteLine(total);
            for (int i = 0; i < starsCount.Length; i++)
            {
                if (starsCount[i] > 0)
                {
                    Console.WriteLine("{0} {1}", (char)(i + 65), starsCount[i]);
                }
            }
        }

        static bool AreEqual(params char[] chars)
        {
            for (int i = 0; i < chars.Length - 1; i++)
            {
                if (chars[i] != chars[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

    }
}
