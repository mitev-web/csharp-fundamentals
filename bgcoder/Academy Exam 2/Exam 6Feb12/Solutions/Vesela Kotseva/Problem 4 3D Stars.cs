using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Stars3D
{
    class Program
    {
        static void Main(string[] args)
        {

            string dim = Console.ReadLine();
            string[] dimention = dim.Split(' ');
            int dimA = int.Parse(dimention[0]);
            int dimB = int.Parse(dimention[1]);
            int dimC = int.Parse(dimention[2]);
            string[] s = new string[dimB];
            for (int i = 0; i < dimB; i++)
            {
                s[i] = Console.ReadLine();
            }
            int sLength = dimA * dimC + dimC - dimA - 2;
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= s.Length - 2; i++)
            {
                for (int j = dimA + 2; j <= sLength; j++)
                {
                    char ch = s[i][j];
                    if (s[i][j] == s[i + 1][j])
                    {
                        if (s[i - 1][j] == s[i][j - 1])
                        {
                            if (s[i][j + 1] == s[i][j - dimA - 1])
                            {
                                if (s[i][j + dimA + 1] == s[i][j])
                                {
                                    result.Append(ch);
                                }
                            }
                        }
                    }
                }
            }

            string charStr = result.ToString();
            Console.WriteLine(charStr.Length);
            int countA = 0;
            int countB = 0;
            int countC = 0;
            int countD = 0;
            int countE = 0;
            int countF = 0;
            int countG = 0;
            int countH = 0;
            int countI = 0;
            int countJ = 0;
            int countK = 0;
            int countL = 0;
            int countM = 0;
            int countN = 0;
            int countO = 0;
            int countP = 0;
            int countQ = 0;
            int countR = 0;
            int countS = 0;
            int countT = 0;
            int countU = 0;
            int countV = 0;
            int countW = 0;
            int countX = 0;
            int countY = 0;
            int countZ = 0;
            

            for (int i = 0; i < charStr.Length; i++)
            {
                if (charStr[i] == 'A') countA++;
                if (charStr[i] == 'B') countB++;
                if (charStr[i] == 'C') countC++;
                if (charStr[i] == 'D') countD++;
                if (charStr[i] == 'E') countE++;
                if (charStr[i] == 'F') countF++;
                if (charStr[i] == 'G') countG++;
                if (charStr[i] == 'H') countH++;
                if (charStr[i] == 'I') countI++;
                if (charStr[i] == 'J') countJ++;

                if (charStr[i] == 'K') countK++;
                if (charStr[i] == 'L') countL++;
                if (charStr[i] == 'M') countM++;
                if (charStr[i] == 'N') countN++;
                if (charStr[i] == 'O') countO++;
                if (charStr[i] == 'P') countP++;
                if (charStr[i] == 'Q') countQ++;
                if (charStr[i] == 'R') countR++;
                if (charStr[i] == 'S') countS++;
                if (charStr[i] == 'T') countT++;

                if (charStr[i] == 'U') countU++;
                if (charStr[i] == 'V') countV++;
                if (charStr[i] == 'W') countW++;
                if (charStr[i] == 'X') countX++;
                if (charStr[i] == 'Y') countY++;
                if (charStr[i] == 'Z') countZ++;
                


            }
            if (countA != 0) { Console.WriteLine("A {0}", countA); }
            if (countB != 0) { Console.WriteLine("B {0}", countB); }
            if (countC != 0) { Console.WriteLine("C {0}", countC); }
            if (countD != 0) { Console.WriteLine("D {0}", countD); }
            if (countE != 0) { Console.WriteLine("E {0}", countE); }
            if (countF != 0) { Console.WriteLine("F {0}", countF); }
            if (countG != 0) { Console.WriteLine("G {0}", countG); }
            if (countH != 0) { Console.WriteLine("H {0}", countH); }
            if (countI != 0) { Console.WriteLine("I {0}", countI); }
            if (countJ != 0) { Console.WriteLine("J {0}", countJ); }
            if (countK != 0) { Console.WriteLine("K {0}", countK); }
            if (countL != 0) { Console.WriteLine("L {0}", countL); }
            if (countM != 0) { Console.WriteLine("M {0}", countM); }
            if (countN != 0) { Console.WriteLine("N {0}", countN); }
            if (countO != 0) { Console.WriteLine("O {0}", countO); }           
            if (countP != 0) { Console.WriteLine("P {0}", countP); }
            if (countQ != 0) { Console.WriteLine("Q {0}", countQ); }

            if (countR != 0) { Console.WriteLine("R {0}", countR); }
            if (countS != 0) { Console.WriteLine("S {0}", countS); }
            if (countT != 0) { Console.WriteLine("T {0}", countT); }
            if (countU != 0) { Console.WriteLine("U {0}", countU); }
            if (countV != 0) { Console.WriteLine("V {0}", countV); }

            if (countW != 0) { Console.WriteLine("W {0}", countW); }
            if (countX != 0) { Console.WriteLine("X {0}", countX); }

            if (countY != 0) { Console.WriteLine("Y {0}", countY); }
            if (countZ != 0) { Console.WriteLine("Z {0}", countZ); }


        }
    }
}
