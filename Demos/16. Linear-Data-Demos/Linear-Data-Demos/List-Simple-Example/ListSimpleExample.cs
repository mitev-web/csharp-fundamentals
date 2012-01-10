using System;
using System.Collections.Generic;

class ListSimpleExample
{
    static void Main()
    {
        List<string> list = new List<string>();
        list.Add("C#");
        list.Add("Java");
        list.Add("PHP");
        foreach (string item in list)
        {
            Console.WriteLine(item);
        }
        // Result:
        //   C#
        //   Java
        //   PHP
    }
}
