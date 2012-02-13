using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5.Brackets
{
    class Brackets
    {
        static int solutions = 0;

        static void GenerateBrakets(string input, StringBuilder output, int index, int openBraket, int closenBraket)
        {
            if (openBraket < closenBraket || openBraket > input.Length / 2 || closenBraket > input.Length / 2)
            {
                index = output.Length;
                return;
            }
            if (index == output.Length)
            {
                solutions++;
                //Console.WriteLine(output.ToString());
            }
            else
            {
                if (input[index] == '?')
                {
                    output[index] = ')';
                    GenerateBrakets(input, output, index + 1, openBraket, closenBraket + 1);
                    output[index] = '(';
                    GenerateBrakets(input, output, index + 1, openBraket + 1, closenBraket);
                }
                else
                {
                    if (input[index] == ')')
                    {
                        GenerateBrakets(input, output, index + 1, openBraket, closenBraket + 1);
                    }
                    else
                    {
                        GenerateBrakets(input, output, index + 1, openBraket + 1, closenBraket);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            StringBuilder input = new StringBuilder(Console.ReadLine());
            //StringBuilder output = new StringBuilder("????(?");
            GenerateBrakets(input.ToString(), input, 0, 0, 0);

            Console.WriteLine(solutions);
            //CorrectBraketsGenerator(input, 0, 0, 0, output);
        }
    }
}
