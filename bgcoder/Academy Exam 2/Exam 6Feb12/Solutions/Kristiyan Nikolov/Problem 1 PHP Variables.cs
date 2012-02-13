using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prob1_PHPVars
{
    class PHPVars
    {
        enum State
        {
            Code, Comment, String
        }

        static State state = State.Code;
        static bool read = false;
        static bool dash = false;
        static char esc = (char)0;

        static void Main(string[] args)
        {
            string input = ReadInput();
//            @"<?php
//# this is $comment
//$valid_var='""text""...{$valid_var}'
//$just=""Just another var $Just..."";$just=$code;
//?>";
//            @"<?php
///* This is $var1 in comments */
//$var3 = ""Some string \$var4 with var escaped."";
//echo $var5; echo(""$foo,$bar"");
//// another comment with variable $var2
//?>";
            
            List<string> vars = ExtractVars(input);
            vars = QuickSort(vars, vars.Count / 2);
            Console.WriteLine(vars.Count);
            foreach (var v in vars)
            {
                Console.WriteLine(v);
            }
        }

        static string ReadInput()
        {
            StringBuilder php = new StringBuilder();
            string input = Console.ReadLine();

            while (input != "?>")
            {
                php.AppendLine(input);
                input = Console.ReadLine();
            }

            return php.ToString();
        }

        static List<string> ExtractVars(string php)
        {
            List<string> result = new List<string>();


            StringBuilder var = new StringBuilder("");
            state = State.Code;
            read = false;
            dash = false;
            esc = (char)0;

            for (int i = 0; i < php.Length; i++)
            {
                if (php[i] == '$')
                {
                    switch (state)
                    {
                        case State.Code:
                            read = true;
                            break;

                        case State.String:
                            if (!dash)
                                read = true;
                            break;
                    }
                }
                else
                {
                    if (read)
                    {
                        if ((php.ToUpper()[i] >= 65 && php.ToUpper()[i] <= 90) || php[i] == 95)
                        {
                            var.Append(php[i]);
                        }
                        else if ((php[i] >= 48 && php[i] <= 57) && php[i - 1] != '$')
                        {
                            var.Append(php[i]);
                        }
                        else
                        {
                            read = false;
                            if (var.Length > 0)
                            {
                                if (!result.Contains(var.ToString()))
                                    result.Add(var.ToString());
                                var.Clear();
                            }
                        }
                    }

                    CheckState(php[i]);
                }
            }

            return result;
        }

        static void CheckState(char ch)
        {
            switch (state)
            {
                case State.Code:
                    {
                        if (ch == '#')
                        {
                            state = State.Comment;
                            esc = '\n';
                        }
                        else if (dash)
                        {
                            if (ch == '/')
                            {
                                state = State.Comment;
                                esc = '\n';
                            }
                            else if (ch == '*')
                            {
                                state = State.Comment;
                                esc = '*';
                            }
                            dash = false;
                        }
                        if (ch == '\"' || ch == '\'')
                        {
                            state = State.String;
                            esc = ch;
                        }
                        else if (ch == '/')
                        {
                            dash = true;
                        }
                        break;
                    }
                case State.Comment:
                    {
                        if (ch == esc)
                        {
                            if (ch == '*')
                            {
                                dash = true;
                            }
                            else
                            {
                                state = State.Code;
                            }
                        }
                        if (dash && ch == '/')
                        {
                            state = State.Code;
                        }
                        if (ch != '*')
                        {
                            dash = false;
                        }
                        break;
                    }
                case State.String:
                    {
                        if (!dash)
                        {
                            if (ch == '\\')
                            {
                                dash = true;
                            }
                            else
                            {
                                dash = false;
                                if (ch == '$')
                                {
                                    read = true;
                                }
                                else if (ch == esc)
                                {
                                    state = State.Code;
                                }
                            }
                        }
                        else
                            dash = false;
                        break;
                    }
            }
        }

        static List<string> QuickSort(List<string> list, int index)
        {
            if (list.Count < 2)
            {
                return list;
            }
            else
            {
                List<string> less = new List<string>();
                List<string> greater = new List<string>();

                string pivot = list[index];
                list.RemoveAt(index);

                foreach (var st in list)
                {
                    if (CompareStrings(st, pivot) < 0)
                    {
                        less.Add(st);
                    }
                    else
                    {
                        greater.Add(st);
                    }
                }

                less = QuickSort(less, less.Count / 2);
                greater = QuickSort(greater, greater.Count / 2);

                List<string> result = new List<string>(less);
                result.Add(pivot);
                result.AddRange(greater);
                return result;
            }
        }

        static int CompareStrings(string st1, string st2)
        {
            for (int i = 0; i < st1.Length; i++)
            {
                if (i >= st2.Length)
                    return 1;
                else
                {
                    if (st1[i] > st2[i])
                        return 1;
                    else if (st1[i] < st2[i])
                        return -1;
                }
            }
            if (st1.Length < st2.Length)
                return -1;

            return 0;
        }
    }
}
