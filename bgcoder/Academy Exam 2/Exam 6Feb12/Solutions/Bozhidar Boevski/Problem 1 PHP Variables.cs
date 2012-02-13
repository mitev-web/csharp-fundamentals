using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string cInput = "";
            StringBuilder output = new StringBuilder();

            while (cInput != "?>")
            {
                cInput = Console.ReadLine();
                Find(cInput, output);
            }
            string outStr = output.ToString();
            string[] arr = Sort(outStr);
            arr = RemoveDub(arr).Split(' ');
            
            Console.WriteLine(arr.Length - 1);
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        static void Find(string cInput,StringBuilder output)
        {
            for (int i = 0; i < cInput.Length; i++)
            {
                if (cInput[i] == '$')
                {
                    int count = i + 1;
                    while (cInput[count] != ' ' && cInput[count] != ';'
                        && cInput[count] != ']' && cInput[count] != '"'
                        && cInput[count] != '\'' && cInput[count] != '}'
                        && cInput[count] != '[' && cInput[count] != '{'
                        && cInput[count] != '(' && cInput[count] != ')')
                    {
                        output.Append(cInput[count]);
                        count++;
                    }
                    output.Append(' ');
                }
            }
        }
        static string[] Sort(string str)
        {
            string[] temp = str.Split(' ');
            string[] arr = new string[temp.Length - 1];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = temp[i];
            }
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[i][0] < arr[j][0])
                    {
                        string someStr = arr[i];
                        arr[i] = arr[j];
                        arr[j] = someStr;
                    }
                }
            }
            return arr;
        }
        static string RemoveDub(string[] str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] != str[i + 1])
                {
                    sb.Append(str[i]);
                    sb.Append(' ');
                }
                if (i == str.Length - 2)
                {
                    sb.Append(str[i]);
                    sb.Append(' ');
                }
            }
            string rem = sb.ToString();
            return rem;
        }
    }
}