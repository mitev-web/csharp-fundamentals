using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tubes
{
    class tubes
    {
        
            

            static bool BrackletsCheck(string s)
            {
                bool IsCorrect = true;        
                int indexOpen = s.IndexOf('(');
                int indexClose = s.IndexOf(')');
                int lastIndexOpen = s.LastIndexOf('(');
                int lastIndexClose = s.LastIndexOf(')');
                int counterss = 0;
                foreach (var item in s)
                {
                    if (item.CompareTo('(')==0)
                    {
                        counterss++;
                    }
                    else if (item.CompareTo(')') == 0)
                    {
                        counterss--;
                    }
                }
                if ((counterss != 0)||(indexClose<indexOpen)||(lastIndexOpen==s.Length-1)||(lastIndexOpen>lastIndexClose))
                {
                    IsCorrect = false;
                }
            
                return(IsCorrect);
            }
            
            static int counter = 0;
            static int count = 0;
            
            static int Gen01(string str)
            {
                StringBuilder biulddd = new StringBuilder(str);
                
                int ind = str.IndexOf('?');
                if (ind < 0)
                {
                    if (BrackletsCheck(str))
                    {
                        count++;
                    }
                    else
                    {
                        return(count);
                    }
                }
                else
                {
                    for (char i = '('; i <= ')'; i++)
                    {
                        biulddd[ind] = i;
                        Gen01(biulddd.ToString());
                    }
                }
                
                return (count);
            }
            static void Main(string[] args)
            {
                string s = Console.ReadLine();
                int countIt = Gen01(s);
                    
                Console.WriteLine(countIt);
                
            }
        }
    }
