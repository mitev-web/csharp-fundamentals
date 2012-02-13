using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Input 
//5
//Output 
//*****
//.***.
//..*..
//.***.
//*****


//Input 
//7	
//Output 

//*******
//.*****.
//..***..
//...*...
//..***..
//.*****.
//*******

class SandGlass
{
    static void Main(string[] args)
        {

            byte N = byte.Parse(Console.ReadLine());
            bool reverse = false;
            bool first = true;
            int count = 0;
            int width = N;
            int dots = 0;
            for (int i = 0; i < N; i++)
            {
                count = width;
                if (!reverse)
                {
                    if (dots > 0)
                    {
                        for (int k = 0; k < dots / 2; k++)
                        {
                            Console.Write(".");
                        }
                    }
                    while (count > 0)
                    {
                        Console.Write("*");
                        count--;

                        if (width <= 1)
                        {
                            reverse = true;
                        }
                    }
                    if (dots > 0)
                    {
                        for (int k = 0; k < dots / 2; k++)
                        {
                            Console.Write(".");
                        }
                    }
                    width -= 2;
                    dots += 2;

                }
                else
                {
            
                    if (first)
                    {
                        dots = N - 1;
                        width = 3;
                        count = 3;
                        first = false;
                    }
                    dots -= 2;
                    width += 2;
                    if (dots > 0)
                    {
                        for (int k = 0; k < dots / 2; k++)
                        {
                            Console.Write(".");
                        }
                    }
                    while (count > 0)
                    {
                        Console.Write("*");
                        count--;

                    }
                    if (dots > 0)
                    {
                        for (int k = 0; k < dots / 2; k++)
                        {
                            Console.Write(".");
                        }
                    }

                }
                Console.WriteLine();
            }
        }
    }


