using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zad2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr=new int[18,8];
            int[,] result=new int[18,50];
            int n = int.Parse(Console.ReadLine());
            string[,] res=new string[303,303];
            for (int i = 0; i < n; i++)
            {
                string s = Console.ReadLine();
                res[i,0]=s;
                int y=1;
                for (int j = 0; j < 7; j++)
                {
                    arr[i, j] = int.Parse(s[j].ToString());
                    
                }
                if (s=="1111110") 
                {
                    result[i,0]=0;
                }
                if (s=="0110000") 
                {
                    result[i,0]=1;
                }
                if (s=="1101101") 
                {
                    result[i,0]=2;
                }
                if (s=="1111001") 
                {
                    result[i,0]=3;
                }
                if (s=="0110011") 
                {
                    result[i,0]=4;
                
                }
                 if (s=="1011011") 
                {
                    result[i,0]=5;
                }
                if (s=="1011111") 
                {
                    result[i,0]=6;
                }
                if (s=="1110000") 
                {
                    result[i,0]=7;
                
                }
                 if (s=="1111111") 
                {
                    result[i,0]=8;
                }
                if (s=="1111011") 
                {
                    result[i,0]=9;
                }
               
               
            
               // Console.ReadLine();
                
            }
            int[] m = new int[20]; 
            int r = 1;
            for (int i = 0; i < n; i++)
            {
                r =0;
                if (result[i,0]==0)
                {
                    m[i] = 2;
                    r++;
                    result[i, r] = 8;
              //      r++;
                //    result[i, r] = 0;
                }
                if (result[i, 0] == 1)
                {
                    m[i] = 7;
                  //  r++;
                  //  result[i, r] = 1;
                    r++;
                    result[i, r] = 0;
                    
                    
                    r++;
                    result[i, r] = 3;
                    r++;
                    result[i, r] = 4;
                    r++;
                    result[i, r] = 7;
                    r++;
                    result[i, r] = 8;
                    r++;
                    result[i, r] = 9;
                    
                    
                }
                if (result[i, 0] == 2)
                {
                    r++;
                    result[i, r] = 8;
                    r++;
                    result[i, r] = 999;
                    m[i] = 2;
                   // r++;
                   // result[i, r] = 2;
                }
                if (result[i, 0] == 3)
                {
                   // r++;
                   // result[i, r] = 3;
                    r++;
                    result[i, r] = 8;
                    r++;
                    result[i, r] = 9;
                    m[i] = 3;
                }
                if (result[i, 0] == 4)
                {
                   // r++;
                   // result[i, r] = 4;
                    r++;
                    result[i, r] = 8;
                    r++;
                    result[i, r] = 9;
                    m[i] = 3;
                }
                if (result[i, 0] == 5)
                {
                   // r++;
                   // result[i, r] = 5;
                    r++;
                    result[i, r] = 6;
                    r++;
                    result[i, r] = 8;
                    r++;
                    result[i, r] = 9;
                    m[i]=4;
                   
                }
                if (result[i, 0] == 6)
                {
                    r++;
                    result[i, r] = 8;
                    m[i]=2;
                  //  r++;
                  //  result[i, r] = 6;
                }
                if (result[i, 0] == 7)
                {
                    r++;
                    result[i, r] = 0;
                    r++;
                    result[i, r] = 3;
                    
                    r++;
                   // result[i, r] = 7;
                   // r++;
                    result[i, r] = 8;
                    r++;
                    result[i, r] = 9;
                    m[i]=5;
                }
                if (result[i, 0] == 8)
                {
                    r++;
                    result[i, r] = 999;
                    m[i]=1;
                    
                }
                if (result[i, 0] == 9)
                {
                    r++;
                    result[i, r] = 8;
                    m[i]=2;
                    //r++;
                    //result[i, r] = 9;
                }
            }
            int coun = 0;
            if (n == 1)
            {
                //Console.WriteLine(m[result[0,]]);
                for (int i = 0; i < 7; i++)
                {
                    if (result[0, i] == 0 && i > 1)
                    {
                        result[0, i] = 999;
                    }
                    if (result[0, i] != 999)
                    {
                        coun++;
                        //Console.WriteLine("{0}", result[0, i]);
                    }


                }
            }
            if (n == 1)
            {
                Console.WriteLine(coun);
                for (int i = 0; i < 7; i++)
                {
                    if (result[0, i] == 0 && i > 1)
                    {
                        result[0, i] = 999;
                    }
                    if (result[0, i] != 999)
                    {
                        
                        Console.WriteLine("{0}",result[0, i]);
                    }


                }
            }
            string[] srt = new string[255];
            string[] srt1 = new string[255];
            int w=-1;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < 20; j++)
                {

                    if (j > 1 && result[i, j] == 0)
                    {
                        result[i, j] = 999;
                    }
                    
                    if (i > 1 && result[j, i] == 0)
                    {
                        result[j, i] = 999;
                    }
                    if (result[i, j]!=999)
                    {
                        w++;
                       // srt1[w] = result[i, j] + result[i,j+1]+"";
                        //Console.WriteLine(" srt = {0} ... ", srt1[w]);
                    }
                    if (result[i, j] != 999)
                    {
                        
                        for (int f=0; f < 7; f++)
                        {

                            w++;
                            srt1[w] = result[i, j].ToString() +result[i+1,f].ToString();

                         //   Console.WriteLine(" srt = {0} ...{1}... ", srt1[w],w);
                         //   Console.Write(" {0} ", result[i, j]);
                        }

                    }
                }
                //Console.WriteLine();
            }
            /*
            int u=-1;
            int h = -1;
            for (int i = 0; i < n; i++)
            {
                h = -1;
                do
                {
                    u++;
                    h++;
                    srt[u]=result[i, h].ToString();
                    int p=-1;
                    do 
                    {
                       // u++;
                        p++;
                    
                    //h++;
                       
                    if (result[i + 1, p] != 999 && result[i, h]!=999)
                    {
                        srt[u] =srt[u] + result[i + 1, p].ToString();
                    }
                    } while (result[i, p] != 999);
                } while (result[i, h] != 999);
            }*/
            /*int u =-1;
            for (int i = 0; i < n; i++)
            {
                for (int h = 0; h < 7; h++)
                {
                    u++;
                    if (result[i,h] != 999)
                    {
                        srt[u] = result[i,h].ToString();
                    }
                        for (int d = 0; d < 7; d++)
                        {
                            if (result[i+1, d] != 999)
                            {
                                srt[u] = srt[u] + result[i+1, d].ToString();
                            }
                        }
                    
                }
            }*/
            string x, yy;
            int u=-1;
            for (int i = 0; i < n-1; i++)
            {
                
                
                for (int t = 0; t < 7; t++)
                {
                    u++;
                    if (result[i, t] != 999 && t<m[i])
                    {
                        x = result[i, t]+"";
                      //  Console.WriteLine("t = {0}", x);
                        srt[u] = x;
                      //  Console.WriteLine("s = {0}", srt[u]);
                    }
                    for (int d = 0; d < 7; d++)
                    {
                        if (result[i + 1, d] != 999 && d<m[i+1] && srt[u]!="")
                        {
                            yy = result[i + 1, d] + "";      
                      //     Console.WriteLine("d = {0}", result[i + 1, d]);
                            srt[u] = srt[u]+yy;
                      //      Console.WriteLine("ss = {0}", srt[u]);
                        }
                    }
                }
            }
            Array.Sort(srt1);
            for (int g = 0; g < srt1.Length-1; g++)
            {
                for (int p = g+1; p < srt1.Length - 1;p++ )
                    if (srt1[g] == srt1[p])
                    {
                        srt1[p] = "a";
                    }
            }
                foreach (string l in srt1)
                {
                    if (l != null && l[0] != '\n' && l!="a")
                    {

                        Console.WriteLine(l);
                    }
                }
             //   if (n == 2)
             //   {
              ///      Console.WriteLine("2");
              ///      Console.WriteLine("08");
              ///      Console.WriteLine("88");
              //  }
        }

    }
}
