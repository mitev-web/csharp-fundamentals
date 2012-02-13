using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4ThreeDStars
{
    class ThreeDStars
    {
        static void Main(string[] args)
        {
            string whd = Console.ReadLine();
            string[] separators = { " " };
            string[] dimentions = whd.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            int with = int.Parse(dimentions[0]);
            int height = int.Parse(dimentions[1]);
            int depth = int.Parse(dimentions[2]);
            int counter = 0;




            string[] lines = new string[height];

            for (int i = 0; i < height; i++ )
            {
                lines[i] = Console.ReadLine();
            }

            int[] letters = new int[100000];

            
            for(int i = 1; i < height - 1; i++)
            {
                for (int j = with + 2; j < lines[i].Length - with-2; j++ )
                {
                    if (lines[i][j] == lines[i][j - 1] && lines[i][j] == lines[i][j + 1] && lines[i][j] == lines[i - 1][j] &&
                        lines[i][j] == lines[i + 1][j] && lines[i][j] == lines[i][j + with + 1] && lines[i][j] == lines[i][j - with - 1])
                    {
                        counter++;
                        for (char ch = 'A'; ch <= 'Z'; ch++)
                        {
                            if(ch==lines[i][j])
                            {
                                letters[ch] = letters[ch] + 1;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(counter);
            for (char ch = 'A'; ch <= 'Z'; ch++)
            {
                if (letters[ch]!=0)
                {
                    Console.WriteLine("{0} {1}",ch, letters[ch]);
                }
            }
             
            //Console.WriteLine(lines[0].Length);
        }
    }
}