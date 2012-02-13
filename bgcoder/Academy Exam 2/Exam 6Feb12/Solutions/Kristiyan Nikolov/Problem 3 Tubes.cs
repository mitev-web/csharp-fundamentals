using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prob3_Tubes
{
    class Tubes
    {
        struct Tube
        {
            public int Value;
            public int Left;
            public int Parts;

            public Tube(int value)
            {
                Value = value;
                Left = 0;
                Parts = 1;
            }
        }

        static void Main(string[] args)
        {
            // input
            string input = Console.ReadLine();
            int tubesCount = int.Parse(input);

            input = Console.ReadLine();
            int peopleCount = int.Parse(input);

            Tube[] tubes = new Tube[tubesCount];
            int minIndex = 0;
            for (int i = 0; i < tubes.Length; i++)
            {
                input = Console.ReadLine();
                tubes[i] = new Tube(int.Parse(input));
                if (tubes[i].Value <= tubes[minIndex].Value)
                {
                    minIndex = i;
                }
            }
            int maxLeft = minIndex;
            int resultIndex = 0;
            for (int p = tubesCount; p < peopleCount + 1; p++)
            {
                for (int t = 0; t < tubesCount; t++)
                {
                    tubes[t].Left = tubes[t].Value - tubes[t].Parts * (tubes[maxLeft].Value / tubes[maxLeft].Parts);
                }
                resultIndex = maxLeft;
                for (int t = 0; t < tubesCount; t++)
                {
                    if (tubes[t].Left >= tubes[maxLeft].Left)
                    {
                        maxLeft = t;
                    }

                }

                tubes[maxLeft].Parts++;
            }
            int result = (tubes[resultIndex].Value / tubes[resultIndex].Parts);
            Console.WriteLine(result);
        }
    }
}
