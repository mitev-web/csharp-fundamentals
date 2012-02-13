using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem4
{
    class Star
    {

        private static void FillCuboid(string[, ,] cuboid, List<string> input)
        {
            for (int heigh = 0; heigh < cuboid.GetLength(1); heigh++)
            {
                int lineIndex = 0;
                for (int depth = 0; depth < cuboid.GetLength(2); depth++)
                {
                    for (int width = 0; width < cuboid.GetLength(0); width++)
                    {
                        string currChar = input[heigh].Substring(lineIndex, 1);
                        if (currChar == " ")
                        {
                            lineIndex++;
                            currChar = input[heigh].Substring(lineIndex, 1);
                        }
                        cuboid[width, heigh, depth] = currChar;
                        lineIndex++;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            //int w = 7;
            //int h = 4;
            //int d = 3;

            string input1 = Console.ReadLine();
            int index = input1.IndexOf(" ");
            int w = int.Parse(input1.Substring(0, index));
            input1 = input1.Substring(index + 1, input1.Length - (index + 1));
            index = input1.IndexOf(" ");
            int h = int.Parse(input1.Substring(0, index));
            input1 = input1.Substring(index + 1, input1.Length - (index + 1));
            int d = int.Parse(input1);

            string[, ,] cuboid = new string[w, h, d];
            List<string> input = new List<string>();
            for (int row = 0; row < h; row++)
            {
                input.Add(Console.ReadLine());
            }

            //string line1 = "BRYYYYY RYYYYGY YRYYYYY";
            //string line2 = "YYYGBGY YYYYGGG YYYGGGY";
            //string line3 = "RYBYGYY RYYYYGY RYBYGBB";
            //string line4 = "RYBYGYY RBYYGYY RYBYGBB";
            //string[] input = { line1, line2, line3, line4};
            
            //input.Add(line1);
            //input.Add(line2);
            //input.Add(line3);
            //input.Add(line4);

            List<string> result = new List<string>();
            FillCuboid(cuboid, input);

            for (int row = 0; row < cuboid.GetLength(0); row++)
            {
                for (int col = 0; col < cuboid.GetLength(1); col++)
                {
                    for (int dep = 0; dep < cuboid.GetLength(2); dep++)
                    {
                        if (row < (cuboid.GetLength(0) - 1) && col < (cuboid.GetLength(1) - 1) && dep < (cuboid.GetLength(2) - 1) && (row > 0) && (col > 0) && (dep > 0))
                        {
                            string currValue = cuboid[row, col, dep];

                            string poss1 = cuboid[row - 1, col, dep];
                            string poss2 = cuboid[row + 1, col, dep];
                            string poss3 = cuboid[row, col - 1, dep];
                            string poss4 = cuboid[row, col + 1, dep];
                            string poss5 = cuboid[row, col, dep - 1];
                            string poss6 = cuboid[row, col, dep + 1];
                            if ((poss1 == currValue) && (poss2 == currValue) && (poss3 == currValue) && (poss4 == currValue) && (poss5 == currValue) && (poss6 == currValue))
                            {
                                result.Add(currValue);
                            }
                        }
                    }
                }
            }
            int printCount = result.Count;
            List<string> temp = result;
            List<string> resultOut = new List<string>();
            while (temp.Count > 0)
            {
                string value = temp[0];
                int count = 0;
                
                foreach (string ele in result)
                {
                    if (value == ele)
                    {
                        count++;
                    }
                }
                
                if (count != 0)
                {
                    string addStr = string.Format("{0} {1}", value, count);
                    resultOut.Add(addStr);
                    while (temp.Remove(value))
                    {
                        temp.Remove(value);
                    }
                }
            }
            resultOut.Sort();
            Console.WriteLine(printCount);
            foreach (string ele in resultOut)
            {
                Console.WriteLine(ele);
            }
        }
    }
}