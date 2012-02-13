using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task04
{
    class Program
    {
        struct Star
        {
            public int r;
            public char c;
            public Star(char cc, int rr)
            {
                c = cc;
                r = rr;
            }
        }
        static Star[] arr;
        static int next = 0;
        static void Main(string[] args)
        {
            string firstline = Console.ReadLine();
            string[] numbers = firstline.Split(new char[] { ' ' });
            byte w = byte.Parse(numbers[0]);
            byte h = byte.Parse(numbers[1]);
            byte d = byte.Parse(numbers[2]);
            numbers = new string[h];
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < h; i++)
            {
                numbers[i] = Console.ReadLine();
            }

            for (int i = 1; i < h - 1; i++)
            {
                for (int y = w + 2, swap = 0; y < w * d + d - 1 - w - 1;)
                {
                    while (swap < w - 2)
                    {
                        if (numbers[i][y] != ' ')
                            if ((numbers[i][y] == numbers[i][y + 1]) &&
                                (numbers[i][y] == numbers[i][y - 1]) &&
                                (numbers[i][y] == numbers[i - 1][y]) &&
                                (numbers[i][y] == numbers[i + 1][y]))
                                sb.Append(numbers[i][y]);
                        y++;
                        swap++;
                    }
                    swap = 0;
                    y += 3;
                }
            }
            string stars = sb.ToString();
            int l = stars.Length;
            if (l > 0)
            {
                arr = new Star[l];
                for (int j = 0; j < l; j++)
                {
                    int v = check(stars[j]);
                    if (v >= 0) arr[v].r++;
                    else
                    {
                        arr[next].c = stars[j];
                        arr[next].r++;
                        next++;
                    }
                }

                StringBuilder zzz = new StringBuilder();
                int result = 0;
                int min = -1;
                int o = 0;
                while ((o < arr.Length) && (arr[o].r != 0))
                {
                    int u = 0;
                    char cur = 'z';
                    while ((u < arr.Length) && (arr[u].r != 0))
                    {
                        if (arr[u].c < cur)
                        {
                            min = u;
                            cur = arr[u].c;
                        }
                        u++;
                    }
                    zzz.Append(arr[min].c).Append(" ").Append(arr[min].r).Append("\n");
                    result += arr[min].r;
                    arr[min].c = 'z';
                    o++;
                }
                Console.WriteLine(result + "\n" + zzz.ToString());
            }
            else
            {
                Console.WriteLine("0");
            }
        }

        static int check(char str)
        {
            int i = 0;
            while ((i < arr.Length) && (arr[i].r != 0))
            {
                if (str == arr[i].c) return i;
            }
            return -1;
        }
    }
}