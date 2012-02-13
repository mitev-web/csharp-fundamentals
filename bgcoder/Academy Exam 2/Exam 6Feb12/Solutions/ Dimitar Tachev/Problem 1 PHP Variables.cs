using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
 
namespace Task1
{
    class Test
    {
        static StringBuilder currVariable = new StringBuilder();
        static List<string> variables = new List<string>();
        static void Main(string[] args)
        {
            #region declaration
            StringBuilder tempText = new StringBuilder();
            string line = Console.ReadLine();
            while (line != "?>")
            {
                tempText.Append(line);
                tempText.Append("\n");
                line = Console.ReadLine();
            }
            tempText.Append(line);
            tempText.Append("\n");
            string text = tempText.ToString();
            char prev = text[0];
            char next = text[2];
            #endregion
            for (int i = 1; i < text.Length - 1; i++)
            {
                prev = text[i - 1];
                next = text[i + 1];
                #region comment //
                if (text[i] == '/' && prev == '/')
                {
                    while (text[i] != '\n' || i == (text.Length - 2))
                    {
                        i++;
                    }
                    continue;
                }
                #endregion
                #region comment /*
                else if (text[i] == '*' && prev == '/')
                {
                    prev = text[i];
                    i++;
                    while (!(text[i] == '/' && prev == '*'))
                    {
                        prev = text[i];
                        i++;
                    }
                    continue;
                }
                #endregion
                #region comment#
                else if (prev == '#')
                {
                    while (text[i] != '\n')
                    {
                        i++;
                    }
                    continue;
                }
                #endregion
                #region chars
                else if (text[i] == '\'')
                {
                    prev = text[i];
                    i++;
                    while (!(text[i] == '\'' && (prev != '\\' || (prev == '\\' && text[i - 2] == '\\' && text[i - 3] != '\\'))))
                    {
                        if (text[i] == '$' && prev != '\\')
                        {
                            i++;
                            if (!char.IsDigit(text[i]))
                            {
                                while (char.IsLetter(text[i]) || char.IsDigit(text[i]) || text[i] == '_')
                                {
                                    currVariable.Append(text[i]);
                                    prev = text[i];
                                    i++;
                                }
                                if (!variables.Contains(currVariable.ToString()) && currVariable.Length > 0)
                                {
                                    variables.Add(currVariable.ToString());
                                }
                                currVariable.Clear();
                                i--;
                            }
                        }
                        prev = text[i];
                        i++;
                    }
                    continue;
                }
                #endregion
                #region proverka za vlizane v normalen string
                else if (text[i] == '"')
                {
                    prev = text[i];
                    i++;
                    next = text[i + 1];
                    while (!(text[i] == '"' && prev != '\\'))
                    {
                        if (text[i] == '$' && prev != '\\')
                        {
                            i++;
                            if (!char.IsDigit(text[i]))
                            {
                                while (char.IsLetter(text[i]) || char.IsDigit(text[i]) || text[i] == '_')
                                {
                                    currVariable.Append(text[i]);
                                    prev = text[i];
                                    i++;
                                }
                                if (currVariable.Length != 0)
                                {
                                    if (!variables.Contains(currVariable.ToString()))
                                    {
                                        variables.Add(currVariable.ToString());
                                    }
                                    currVariable.Clear();
                                }
                            }
                            i--;
                        }
                        prev = text[i];
                        i++;
                        next = text[i + 1];
                    }
                    continue;
                }
                #endregion
 
                if (text[i] == '$' && prev != '\\')
                {
                    i++;
                    if (!char.IsDigit(text[i]))
                    {
                        while (char.IsLetter(text[i]) || char.IsDigit(text[i]) || text[i] == '_')
                        {
                            currVariable.Append(text[i]);
                            prev = text[i];
                            i++;
                        }
                        if (!variables.Contains(currVariable.ToString()) && currVariable.Length > 0)
                        {
                            variables.Add(currVariable.ToString());
                        }
                        currVariable.Clear();
                    }
                    continue;
                }
            }
            if (variables.Count > 0)
            {
                var sortedList = variables.OrderBy(x => x[0]).ThenBy(x => x).ToList();
                Console.WriteLine(variables.Count);
                foreach (var item in sortedList)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("0");
            }
 
        }
    }
}
 
/*
<?php
$var_1 = $_var2[fad];
$Var3 = $var3;
'$probaTrue' '$ g' "$probaS" "$ pr"
//$var4
#$var5
/*var6
var7*/