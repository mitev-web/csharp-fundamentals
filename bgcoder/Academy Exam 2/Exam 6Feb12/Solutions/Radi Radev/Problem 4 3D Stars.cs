using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
  
namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            string listOfBeers =Console.ReadLine();
            string[] beers = listOfBeers.Split(' ');
            int w = int.Parse(beers[0]);
            int h = int.Parse(beers[1]);
            int d = int.Parse(beers[2]);
            char[, ,] cuboid = new char[w, h, d];
            int a = 0;
            int b = 0;
            int c = 0;
            for (int i = 0; i < h; i++)
            {
                string text = Console.ReadLine();
                int k = 0;
                a = 0;
                b = 0;
                c = 0;
                while (true)
                {                  
                    if (text[k]==' ')
                    {
                        k++;
                        continue;
                    }
                    cuboid[a, b, c] = text[k];
                    if (a==w-1)
                    {
                        a = 0;
                        c++;
                    }
                    else
                    {
                        a++;
                    }
                    if (c==d-1)
                    {
                        break;
                    }
                    k++;
                }
            }
            a = 1;
            b = 1;
            c = 1;
            int[,] arr = new int[26, 2];
            for (int i = 0; i < 26; i++)
            {
                arr[i, 0] = i + 1;
            }
            while (true)
            {
                if (a >= w - 2)
                {
                    a = 1;
                    b++;
                }
                if (b >= h - 2)
                {
                    b = 1;
                    c++;
                }
                if (c >= d - 2)
                {
                    break;
                }
                if (cuboid[a, b, c] == cuboid[a - 1, b, c] && cuboid[a, b, c] == cuboid[a + 1, b, c] && cuboid[a, b, c] == cuboid[a, b + 1, c] && cuboid[a, b, c] == cuboid[a, b - 1, c] && cuboid[a, b, c] == cuboid[a, b, c + 1] && cuboid[a, b, c] == cuboid[a, b, c - 1])
                {
                    switch (cuboid[a, b, c])
                    {
                        case 'A':
                            arr[0,1]++;
                            break;
                        case 'B':
                            arr[1,1]++;
                            break;
                        case 'C':
                            arr[2,1]++;
                            break;
                        case 'D':
                            arr[3,1]++;
                            break;
                        case 'E':
                            arr[4,1]++;
                            break;
                        case 'F':
                            arr[5,1]++;
                            break;
                        case 'G':
                            arr[6,1]++;
                            break;
                        case 'H':
                            arr[7,1]++;
                            break;
                        case 'I':
                            arr[8,1]++;
                            break;
                        case 'J':
                            arr[9,1]++;
                            break;
                        case 'K':
                            arr[10,1]++;
                            break;
                        case 'L':
                            arr[11,1]++;
                            break;
                        case 'M':
                            arr[12,1]++;
                            break;
                        case 'N':
                            arr[13,1]++;
                            break;
                        case 'O':
                            arr[14,1]++;
                            break;
                        case 'P':
                            arr[15,1]++;
                            break;
                        case 'Q':
                            arr[16,1]++;
                            break;
                        case 'R':
                            arr[17,1]++;
                            break;
                        case 'S':
                            arr[18,1]++;
                            break;
                        case 'T':
                            arr[19,1]++;
                            break;
                        case 'U':
                            arr[20,1]++;
                            break;
                        case 'V':
                            arr[21,1]++;
                            break;
                        case 'W':
                            arr[22,1]++;
                            break;
                        case 'X':
                            arr[23,1]++;
                            break;
                        case 'Y':
                            arr[24,1]++;
                            break;
                        case 'Z':
                            arr[25,1]++;
                            break;                      
                    }
                }
                    a++;
                      
                  
            }
            int sum=0;
            for (int i = 0; i < 26; i++)
            {
                sum = sum+ arr[i, 1];
            }
            Console.WriteLine(sum);
            for (int i = 0; i < 26; i++)
            {
                if (arr[i,1]>0)
                {
                    string color = "0";
                    switch (arr[i,0])
                    {
                        case 0:
                            color = "A";
                            break;
                        case 1:
                            color = "B";
                            break;
                        case 2:
                            color = "C";
                            break;
                        case 3:
                            color = "D";
                            break;
                        case 4:
                            color = "E";
                            break;
                        case 5:
                            color = "F";
                            break;
                        case 6:
                            color = "G";
                            break;
                        case 7:
                            color = "H";
                            break;
                        case 8:
                            color = "I";
                            break;
                        case 9:
                            color = "J";
                            break;
                        case 10:
                            color = "K";
                            break;
                        case 11:
                            color = "L";
                            break;
                        case 12:
                            color = "M";
                            break;
                        case 13:
                            color = "N";
                            break;
                        case 14:
                            color = "O";
                            break;
                        case 15:
                            color = "P";
                            break;
                        case 16:
                            color = "Q";
                            break;
                        case 17:
                            color = "R";
                            break;
                        case 18:
                            color = "S";
                            break;
                        case 19:
                            color = "T";
                            break;
                        case 20:
                            color = "U";
                            break;
                        case 21:
                            color = "V";
                            break;
                        case 22:
                            color = "W";
                            break;
                        case 23:
                            color = "X";
                            break;
                        case 24:
                            color = "Y";
                            break;
                        case 25:
                            color = "Z";
                            break;
                    }
                    Console.WriteLine("{0} {1}", color, arr[i,1]);                      
                }
            }
        }
    }
}