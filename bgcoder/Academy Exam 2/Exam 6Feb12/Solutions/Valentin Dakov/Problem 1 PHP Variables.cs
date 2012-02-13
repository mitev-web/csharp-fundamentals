using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhP
{
    class Program
    {
        static string Variable(string str,int n)
        {
            string newstr = null;
            bool now = false;
            int i = n;
            if (str[n-1] == '\\')
                str = str.Substring(n);
            else
                do
                {
                    if((char)str[i]>'\u0040' && (char)str[i]<'\u007b')
                        newstr = newstr+str[i];
                    else 
                        now = true;
                } while (now == false);
            return newstr;
        }

        static void Main(string[] args)
        {
            string firstLine = Console.ReadLine();
            string str;
            List<string> arr = new List<string>();
            int skip = 0;
            bool now = false;
            do
            {
                int n = 0;
                str = Console.ReadLine();
                if (str.CompareTo("?>") == 0)
                    now = true;
                if (str.Contains("/*"))
                {
                    n = str.IndexOf("/*");
                    str = str.Substring(0,str.Length - (str.Length-n-1));
                    skip = 1;
                }

                if(str.Contains("*/") && skip == 1)
                {
                    n = str.IndexOf("*/");
                    str = str.Substring(n - 1);
                    skip = 0;
                }

                if (str.Contains("//"))
                {
                    n = str.IndexOf("//");
                    str = str.Substring(0,str.Length - (str.Length-n-1));
                }

                if(skip == 0)
                    n = str.IndexOf('\u0024');

                arr.Add(Variable(str,n));
            } while (!now);
            Console.WriteLine(arr.Capacity);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
