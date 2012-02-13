using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Task01
{
    class Program
    {
        static Queue<string> q = new Queue<string>();
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            //Queue<string> allVar = new Queue<string>();

            Regex r1 = new Regex("[_]+");
            Regex r2 = new Regex("[a-z]+");
            Regex r3 = new Regex("[A-Z]+");
            Regex r4 = new Regex("[0-9]+");

            string str = Console.ReadLine();
            while (str != "?>")
            {
                sb.Append(str);
                sb.Append("\n");
                str = Console.ReadLine();
            }
            sb.Append("?>");
            str = sb.ToString();
            int l = str.Length;
            for (int i = 0; i < l; i++)
            {
                if (str[i] == '"')
                {
                    i++;
                    while (str[i] != '"')
                    {
                        if (str[i] == '\\') i++;
                        if ((str[i] == '$') && ((r1.IsMatch(str[i + 1].ToString())) || (r2.IsMatch(str[i + 1].ToString())) || (r3.IsMatch(str[i + 1].ToString()))))
                        {
                            StringBuilder sb2 = new StringBuilder();
                            i++;
                            while ((r1.IsMatch(str[i].ToString())) || (r2.IsMatch(str[i].ToString())) || (r3.IsMatch(str[i].ToString())) ||
                                (r4.IsMatch(str[i].ToString())))
                            {
                                sb2.Append(str[i]);
                                i++;
                            }
                            string strr = sb2.ToString();
                            if (!check(strr))
                            {
                                q.Enqueue(strr);
                              //  allVar.Enqueue(strr);
                            }
                        }
                    }
                    i++;
                }

                if ((str[i] == '/') && (str[i + 1] == '*'))
                {
                    i += 2;
                    while ((str[i] != '*') && (str[i+1] != '/'))
                    {
                        i++;
                    }
                    i += 2;
                }

                if ((str[i] == '/') && (str[i + 1] == '/'))
                {
                    i += 2;
                    while (str[i] != '\n')
                    {
                        i++;
                    }
                    i++;
                }

                if (str[i] == '#')
                {
                    i++;
                    while (str[i] != '\n')
                    {
                        i++;
                    }
                    i++;
                }

                if ((str[i] == '$') && ((r1.IsMatch(str[i+1].ToString())) || (r2.IsMatch(str[i+1].ToString())) || (r3.IsMatch(str[i+1].ToString()))))
                {
                    StringBuilder sb2 = new StringBuilder();
                    i++;
                    while ((r1.IsMatch(str[i].ToString())) || (r2.IsMatch(str[i].ToString())) || (r3.IsMatch(str[i].ToString())) ||
                        (r4.IsMatch(str[i].ToString())))
                    {
                        sb2.Append(str[i]);
                        i++;
                    }
                    string strr = sb2.ToString();
                    if (!check(strr))
                    {
                        q.Enqueue(strr);
                    }
                }
            }
            int length = 0;
            foreach (string var in q)
            {
                length++;
            }
            Console.WriteLine(length);
            /*
            foreach (string var in allVar)
            {
                Console.WriteLine(var);
            }
            */
            string[] answer = new string[length];
            int z = 0;
            foreach (string var in q)
            {
                answer[z] = var;
                z++;
            }
            Array.Sort(answer);
            foreach (string var in answer)
            {
                Console.WriteLine(var);
            }
        }
        static bool check(string str)
        {
            foreach (string var in q)
            {
                if (str.Equals(var)) return true;
            }
            return false;
        }
    }
}