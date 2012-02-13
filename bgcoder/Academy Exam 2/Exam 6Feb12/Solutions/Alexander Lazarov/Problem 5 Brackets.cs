using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace ConsoleApplication17
{
    class Program
    {
        static int position = 0;
        static int counter = 0;
        static int printcounter = 0;
        static int count = 0;
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            char[] ch = new char[str.Length];
            for (int i = 0; i < ch.Length; i++)
            {
                ch[i] = str[i];
            }
            FindBrackets(0, ch, 's');
            Console.WriteLine(printcounter-count);
        }
        static void FindBrackets(int n, char[] array, char ch)
        {
            if (n < 0 || n > array.Length)
            {
                return;
            }
            array[position] = ch;
            position++;
            if (array[n] == array[array.Length - 1])
            {
                PrintResult(array, 1, position - 1);
                printcounter++;
            }
            if (array[n] == '?')
            {
                array[n] ='s';
                ch = '(';
                FindBrackets(n - 1, array,ch);
                ch = ')';
                FindBrackets(n + 1, array,ch);
                array[n] = '?';
                position--;
            }
        }
        static void PrintResult (char[]array,int startPos,int endPos)
        {
            foreach (char ch in array)
            {
                if (ch == '(')
                {
                    counter++;
                }
                else if (ch == ')')
                {
                    counter--;
                }
                if (counter < 0)
                {
                    count++;
                }
            }
            if (counter == 0)
            {
                count--;
            }
            else
            {
                count--;
            }
        }
    }
}