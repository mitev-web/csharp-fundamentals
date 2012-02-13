using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7___Segments
{
    class Program
    {
        static List<byte> positions = new List<byte>();
        static byte[] loops;
        static byte loopsSize = 0;
        static int[] digets = new int[7];
        static List<string> possibleResults = new List<string>();
        static Dictionary<int, string> Representation = new Dictionary<int, string>();
        static void Main(string[] args)
        {
            //Representation.Add(0, new int[] { 1, 0, 1, 1, 1, 1, 1 });
            //Representation.Add(1, new int[] { 0,1,1,0,0,0,0 });
            //Representation.Add(2, new int[] { 1,1,0,1,1,0,1 });
            //Representation.Add(3, new int[] { 1,1,1,1,0,0,1 });
            //Representation.Add(4, new int[] { 0,1,1,0,0,1,1 });
            //Representation.Add(5, new int[] { 1,0,1,1,0,1,1 });
            //Representation.Add(6, new int[] { 1,0,1,1,1,1,1 });
            //Representation.Add(7, new int[] { 1,1,1,0,0,0,0 });
            //Representation.Add(8, new int[] { 1,1,1,1,1,1,1 });
            //Representation.Add(9, new int[] { 1,1,1,1,0,1,1 });


            Representation.Add(0, "1111110");
            Representation.Add(1, "0110000");
            Representation.Add(2, "1101101");
            Representation.Add(3, "1111001");
            Representation.Add(4, "0110011");
            Representation.Add(5, "1011011");
            Representation.Add(6, "1011111");
            Representation.Add(7, "1110000");
            Representation.Add(8, "1111111");
            Representation.Add(9, "1111011");
            int n = int.Parse(Console.ReadLine());
            //string[] digets = new string[n];
            //for (int i = 0; i < n; i++)
            //{
            //    digets[i] = Console.ReadLine();
            //}
            StringBuilder sb = new StringBuilder();
            for (int l = 0; l < n; l++)
            {
                string temp = Console.ReadLine();
                for (int i = 0; i < 7; i++)
                {
                    if (temp[i] == '1')
                    { digets[i] = 1; }
                    else digets[i] = 0;
                }
                for (byte i = 0; i < 7; i++)
                {
                    if (digets[i] == 0)
                    {
                        positions.Add(i);
                        loopsSize++;
                    }
                }
                loops = new byte[loopsSize];
                Variation(0);
                foreach (var posR in possibleResults)
                {
                        foreach (var rep in Representation)
                        {
                            if (rep.Value == posR)
                            {
                                sb.Append(rep.Key);
                            }
                        }
                }
                possibleResults.Clear();
                positions.Clear();
            }
            int count = sb.Length / n;
            Console.WriteLine(count);
            for (int i = 0; i < sb.Length; i++)
            {
                Console.Write(sb[i]);
                if ((i + 1) % n == 0)
                {
                    Console.WriteLine();
                }
            }
        }
        private static void Variation(int currentLoop)
        {
            if (currentLoop == loopsSize)
            {
                PrintLoops();
                return;
            }
            for (byte i = 0; i <= 1; i++)
            {
                loops[currentLoop] = i;
                Variation(currentLoop + 1);
            }
        }
        private static void PrintLoops()
        {
            int i = 0;
            foreach (var pos in positions)
            {
                digets[pos] = loops[i];
                i++;
            }
            StringBuilder sb = new StringBuilder(7);
            for (int j = 0; j < 7; j++)
            {
                sb.Append(digets[j]);
            }
            if (Representation.ContainsValue(sb.ToString()))
            {
                possibleResults.Add(sb.ToString());
            } 
        }
    }
}
