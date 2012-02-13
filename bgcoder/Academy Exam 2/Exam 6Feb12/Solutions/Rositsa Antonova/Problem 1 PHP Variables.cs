using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;


namespace Zad1
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder code = new StringBuilder();
            //int linesCount = int.Parse(Console.ReadLine());

            bool inMultiLineComment = false;
            bool inString = false;
            bool inMultilineString = false;
            bool inSingleQuotedString = false;
            int i = 0;
            string line;
            string clear="";
            //for (int i = 1; i <= linesCount; i++)
            do
            {
                i++;
                line = Console.ReadLine();
                string line1 = "";
             //   line1 = line;
               for (int y=0;y<line.Length;y++)
                {
                    if (line[y]==('#'))
                    {
                        break;
                        line1 = line1;
                    }
                    else
                    {
                        line1 = line1+line[y];
                    }
                }
               // Console.WriteLine(line.IndexOf("f"));
                for (int j = 0; j < line1.Length; j++)
                {
                   /* if (inMultilineString)
                    {
                        if (line1[j] == '\"' && j + 1 < line1.Length && line1[j + 1] == '\"')
                        {
                            code.Append("\"\"");
                            clear = clear + "\"\"";
                            j++;
                            continue;
                        }
                    }
                    * */
                    /*
                    if (inString)
                    {
                        if (line1[j] == '\\' && j + 1 < line1.Length && line1[j + 1] == '\"' && line1[j - 1] != '\"')
                        {
                            code.Append("\\\"");
                            clear = clear + "\\\"";
                            j++;
                            continue;
                        }
                        if (line1[j] == '\\' && j + 1 < line1.Length && line1[j + 1] == '\'')
                        {
                            code.Append("\\\'");
                            clear = clear + "\\\'";
                            j++;
                            continue;
                        }
                        if (line1[j] == '\"' && !inSingleQuotedString)
                        {
                            inString = false;
                            inMultilineString = false;
                            code.Append('\"');
                            clear = clear + '\"';
                            continue;
                        }
                        if (line1[j] == '\'' && inSingleQuotedString)
                        {
                            inString = false;
                            inSingleQuotedString = false;
                            code.Append('\'');
                            clear = clear + '\'';
                            continue;
                        }
                        code.Append(line1[j]);
                        continue;
                    }
                    */
                    // Multiline comments
                    if (!inMultiLineComment && j + 1 < line1.Length && line1[j] == '/' && line1[j + 1] == '*')
                    {
                        inMultiLineComment = true;
                        j++;
                        continue;
                    }
                    if (inMultiLineComment && j + 1 < line1.Length && line[j] == '*' && line1[j + 1] == '/')
                    {
                        inMultiLineComment = false;
                        j++;
                        continue;
                    }
                    if (inMultiLineComment)
                    {
                        continue;
                    }

                    // One line comment
                    if (line1[j] == '/' && j + 1 < line1.Length && line1[j + 1] == '/')
                    {
                        if (j + 2 >= line1.Length || line1[j + 2] != '/')
                        {
                            break;
                        }
                        else
                        {
                            // Inline documentation (///)
                            code.Append("///");
                            clear = clear + ("///");
                            j += 2;
                            continue;
                        }
                    }

            /*        if (line1[j] == '@' && j + 1 < line1.Length && line1[j + 1] == '\"')
                    {
                        inString = true;
                        inMultilineString = true;
                        j++;
                        code.Append("@\"");
                        clear = clear + ("@\"");
                        continue;
                    }
            */
                    if (line1[j] == '\"')
                    {
                        inString = true;
                    }

                    if (line1[j] == '\'')
                    {
                        inString = true;
                        inSingleQuotedString = true;
                    }


                    code.Append(line1[j]);
                   // string line1 = Regex.Replace(line[j], @"[//]\s*([^"">]+)\s*[\n]", "");
                    clear = clear + (line1[j]);
                }

                if (!inMultiLineComment) code.AppendLine();
            } while (!line.Equals("?>"));

            StringReader sr = new StringReader(code.ToString());
            string lineToPrint = null;
            while ((lineToPrint = sr.ReadLine()) != null)
            {
                if (!string.IsNullOrWhiteSpace(lineToPrint))
                {
              //      Console.WriteLine(lineToPrint);
                }
            }
            //Console.WriteLine(sr);
            string newString = sr.ToString();
            string[] arr=new string[10000];
            //Console.WriteLine(clear);
            //Console.WriteLine(clear.IndexOf("$"));
            int index = -1;
          //  Console.WriteLine(newString.IndexOf("f"));
            //string dol = @"$";

            //Console.WriteLine(newString);
           // Console.WriteLine("index = {0}", index);
            int k=-1;
            int l;
            do
            {
                k++;
                index = clear.IndexOf("$", index+1);
                l = 10000000;
                if (clear.IndexOf(" ", index + 1) > -1)
                {
                    l = clear.IndexOf(" ", index + 1);
                }
                int m = clear.IndexOf("=", index + 1);
                if (m<l && m>-1) l=m;
                m=clear.IndexOf("}",index+1);
                if (m<l && m>-1) l=m;
                 m=clear.IndexOf("[",index+1);
                if (m<l && m>-1) l=m;
                m = clear.IndexOf("]", index + 1);
                if (m < l && m>-1) l = m;
                m = clear.IndexOf(";", index + 1);
                if (m < l && m > -1) l = m;
                m = clear.IndexOf("\n", index + 1);
                if (m < l && m > -1) l = m;
                m = clear.IndexOf("$", index + 1);
                if (m < l && m > -1) l = m;
                m = clear.IndexOf(")", index + 1);
                if (m < l && m > -1) l = m;
                m = clear.IndexOf(",", index + 1);
                if (m < l && m > -1) l = m;
                m = clear.IndexOf("(", index + 1);
                if (m < l && m > -1) l = m;
                m = clear.IndexOf(".", index + 1);
                if (m < l && m > -1) l = m;
                m = clear.IndexOf("\"", index + 1);
                if (m < l && m > -1) l = m;
                if ((index > -1) && (l > 1) && clear.Substring(index-1,1)!="\\")
                {
                    //for (int u = 0; u < k;u++ )
                     //   if (arr[u]==clear.Substring(index + 1, l - index - 1))
                     //   {
                     //       k = k - 1;
                      //  }
                       // else
                       // {
                            arr[k] = clear.Substring(index + 1, l - index - 1);
                            //break;
                        //}
                 
                }
              //  Console.WriteLine("index = {0}, l = {1}", index, l);
                //index = l+1;
                
                
            } while (index != -1 && l!=-1);

            Array.Sort(arr);
            int t = 0;
            for (int z = 0; z < arr.Length; z++)
            {
                for (int x = z+1; x < arr.Length ;x++ )
                    if (arr[z] ==arr[x])
                    {
                        arr[x] = null;
                      //  t = t + 1;
                    }
            }
                
            foreach (string z in arr)
            {
                if (z!=null)
                {
                    t = t + 1;
                   // Console.WriteLine(z);
                }
            }
            Console.WriteLine(t);
            foreach (string z in arr)
            {
                if (z != null)
                {
             //       t = t + 1;
                    Console.WriteLine(z);
                }
            }
        }
    }
}
