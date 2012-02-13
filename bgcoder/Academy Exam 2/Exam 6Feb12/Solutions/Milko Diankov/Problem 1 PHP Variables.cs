using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace T1.PHPVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "";
            StringBuilder sbline = new StringBuilder();
            List<string> variablesPHP = new List<string>();
 
            while (str != "?>")
            {
                str = Console.ReadLine();
                sbline.Append(str + "\n");
            }
 
            int k = 0;
 
            str = sbline.ToString();
 
            if (str.Contains("/*"))
            {
                str = str.Remove(str.IndexOf("/*"), str.IndexOf("*/") - str.IndexOf("/*") + 2);
            }
            if (str.Contains("//"))
            {
                str = str.Remove(str.IndexOf("//"), str.IndexOf('\n', str.IndexOf("//")) - str.IndexOf("//"));
            }
            if (str.Contains("#"))
            {
                str = str.Remove(str.IndexOf("#"), str.IndexOf('\n', str.IndexOf("#")) - str.IndexOf("#"));
            }
            sbline.Clear();
 
            // Console.WriteLine(str);
 
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == '$' && str[i - 1] != '\\')
                {
                    k = i + 1;
 
                    while (char.IsDigit(str[k]) || char.IsLetter(str[k]) || str[k] == '_')
                    {
                        sbline.Append(str[k]);
                        k++;
                    }
                    variablesPHP.Add(sbline.ToString());
                    sbline.Clear();
                }
            }
            try
            {
 
                List<string> sortString = new List<string>();
                variablesPHP.Sort();
 
                for (int i = 0; i < variablesPHP.Count - 1; i++)
                {
 
                    if (variablesPHP[i] != variablesPHP[i + 1])
                    {
                        sortString.Add(variablesPHP[i]);
 
                    }
                }
                sortString.Add(variablesPHP[variablesPHP.Count - 1]);
 
                string[] resultPHPvar = new string[sortString.Count];
 
                for (int i = 0; i < sortString.Count; i++)
                {
                    resultPHPvar[i] = sortString[i];
                }
 
 
                Array.Sort(resultPHPvar, StringComparer.Ordinal);
 
                Console.WriteLine(resultPHPvar.Length);
 
                for (int i = 0; i < resultPHPvar.Length; i++)
                {
                    Console.WriteLine(resultPHPvar[i]);
                }
            }
            catch
            {
                Console.WriteLine(0);
            }
        }
    }
}