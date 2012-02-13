using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace Problem1
{
    class Php
    {
        static void Main()
        {
            //string line1 = "<?php";
            //string line2 = "$browser = $_SERVER['HTTP_USER_AGENT']  ;";
            //string line3 = "$arr =  array();";
            //string line4 = "$arr[$zero]   = $browser;";
            //string line5 = " var_dump($arr);";
            //string line6 = "?>";
            //string[] arr = new string[] { line1, line2, line3, line4, line5, line6 };
 
            string input = Console.ReadLine();
            List<string> lines = new List<string>();
            while (input != "?>")
            {
                lines.Add(input);
                input = Console.ReadLine();
            }
            lines.Add(input);
            string[] arr = lines.ToArray();
            List<string> listNames = new List<string>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Length != 0)
                {
                    if (arr[i].Substring(0, 1) != "#" && arr[i].Substring(0, 1) != "//" && arr[i].Substring(0, 1) != "/*")
                    {
                        int index = arr[i].IndexOf("$");
                        int temp = index;
                        while (index != -1)
                        {
                            index++;
                            string currChar = arr[i].Substring(index, 1);
                            string name = string.Empty;
                            while (currChar != " " && currChar != "[" && currChar != "]" && currChar != ";" && currChar != ")" && currChar != "=" && currChar != "'" && currChar != "\"")
                            {
                                name += currChar;
                                index++;
                                currChar = arr[i].Substring(index, 1);
                            }
                            bool addState = true;
                            foreach (string ele in listNames)
                            {
                                if (name == ele)
                                {
                                    addState = false;
                                }
                            }
                            if (addState)
                            {
                                listNames.Add(name);
                            }
                            index = arr[i].IndexOf("$");
                            arr[i] = arr[i].Remove(index, 1);
                            index = arr[i].IndexOf("$");
                        }
                    }
                }
            }
            listNames.Sort();
            Console.WriteLine("{0}", listNames.Count);
            foreach (string name in listNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}