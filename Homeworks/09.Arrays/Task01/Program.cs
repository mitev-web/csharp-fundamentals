using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that allocates array of 20 integers and 
            //initializes each element by its index multiplied by 5.
            //Print the obtained array on the console.
            int[] array = new int[20];
            for (int i = 0; i < array.Length; i++) array[i] = i * 5;
            foreach (int i in array) Console.WriteLine(i);
                
        }
    }
}
