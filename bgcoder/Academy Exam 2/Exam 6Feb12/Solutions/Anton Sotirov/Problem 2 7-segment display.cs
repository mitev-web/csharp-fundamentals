using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace problem2
{
    class Program
    {
        static int CheckState(string state)
        {
            if (state == "1111111") return 8;
            if (state == "1111110") return 0;
            if (state == "1100000") return 1;
            if (state == "1101101") return 2;
            if (state == "1111001") return 3;
            if (state == "0110011") return 4;
            if (state == "1011011") return 5;
            if (state == "1011111") return 6;
            if (state == "1110000") return 7;
            if (state == "1111011") return 9;
            else
                return -1;
        }
        static int c=0;
        static Dictionary<string, int> vals = new Dictionary<string, int>();
        static void AllStates(string state, List<int> l, Dictionary<string, int> vals, int index)
        {
            c++;
            int checkState = CheckState(state);
            if (checkState >= 0)
                l.Add(checkState);
            for (int i = index; i < 7; i++)
            {
                if (state[i] == '0')
                {
                    char[] state1 = state.ToCharArray();
                    state1[i] = '1';
                    string str1 = new string(state1);
                    int state1int = CheckState(str1);

                    char[] state2 = state.ToCharArray();
                    state1[i] = '1';
                    string str2 = new string(state1);
                    int state2int = CheckState(str1);

                    if (!vals.ContainsKey(str1))
                    {
                        vals.Add(str1, state1int);
                        
                        AllStates(str1, l , vals,i + 1);
                        
                    }

                    if (!vals.ContainsKey(str2))
                    {
                        vals.Add(str2, state2int);
                        
                        AllStates(str2, l,vals, i + 1);
                    }
                }
            }
        }

        static void Print(List<int>[] l, int index, int[] vector)
        {
            if(index>=l.Length)
            {
                foreach (var item in vector)
	            {
		            Console.Write(item);
	            }
                Console.WriteLine();
                return;
            }
            for (int i = 0; i < l[index].Count; i++)
            {
                vector[index] = l[index][i];
                Print(l, index + 1, vector);
            }
        }
        static void Main(string[] args)
        {            
            int n=int.Parse(Console.ReadLine());
            List<int>[] l = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                l[i] = new List<int>();
                vals = new Dictionary<string, int>();
                string state = Console.ReadLine();
                AllStates(state, l[i],vals, 0);
                l[i].Sort();
            }
            int[] vector = new int[n];
            int total = 1;
            foreach (var item in l)
            {
                total *= item.Count;
            }
            Console.WriteLine(total);
            Print(l, 0 , vector);   
        }
    }
}
