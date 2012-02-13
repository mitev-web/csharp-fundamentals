using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3DStars
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> num = Input();
            InputLayer(num);
        }

        private static void InputLayer(List<int> num)
        {
            int width = num[0];
            int height = num[1];
            int deep = num[2];
            List<char[,]> cubee = new List<char[,]>();
            for (int i = 0; i < deep; i++)
            {
                char[,] arr = new char[height, width];
                cubee.Add(arr);
            }
            for (int i = 0; i < height; i++)
            {
                string line = Console.ReadLine();
                while (line.Contains(" "))
                {
                    line = line.Remove(line.IndexOf(" "), 1);
                }
                int index = 0;
                for (int j = 0; j < deep; j++)
                {
                    for (int w = 0; w < width; w++)
                    {
                        char[,] item = cubee[j];
                        item[i, w] = line[index];
                        index++;
                    }
                }
            }
            List<char> result = MyFind(cubee, deep, width, height);
            Console.WriteLine(result.Count);
            if (result.Count != 0)
            {
                result.Sort();
                char first = result[0];
                int count = 0;
                foreach (var item in result)
                {
                    if (item == first)
                    {
                        count++;
                    }
                    else
                    {
                        Console.WriteLine("{0} {1}", first, count);
                        first = item;
                        count = 1;
                    }
                }
                Console.WriteLine("{0} {1}", first, count);
            }
        }

        private static List<char> MyFind(List<char[,]> cubee, int deep, int width, int height)
        {
            List<char> result = new List<char>();
            for (int d = 1; d < deep - 1; d++)
            {
                char[,] item = cubee[d];
                char[,] preItem = cubee[d - 1];
                char[,] afterItem = cubee[d + 1];
                for (int h = 1; h < height - 1; h++)
                {
                    for (int w = 1; w < width - 1; w++)
                    {
                        if (item[h, w] == item[h - 1, w] &&
                            item[h - 1, w] == item[h, w - 1] &&
                            item[h, w - 1] == item[h, w + 1] &&
                            item[h, w + 1] == item[h + 1, w])
                        {
                            char ch = item[h, w];
                            if (preItem[h, w] == ch && afterItem[h, w] == ch)
                            {
                                result.Add(ch);
                            }
                        }
                    }
                }
            }
            return result;
        }
        public static List<int> Input()
        {
            string numbers = Console.ReadLine();
            numbers = numbers.Trim();
            int index = numbers.IndexOf(' ');
            int width = Convert.ToInt32(numbers.Remove(index));
            numbers = numbers.Remove(0, width.ToString().Length + 1);
            index = numbers.IndexOf(' ');
            int height = Convert.ToInt32(numbers.Remove(index));
            int deep = Convert.ToInt32(numbers.Remove(0, index));
            List<int> num = new List<int>();//width, height, deep );
            num.Add(width);
            num.Add(height);
            num.Add(deep);
            return num;
        }
    }
}
