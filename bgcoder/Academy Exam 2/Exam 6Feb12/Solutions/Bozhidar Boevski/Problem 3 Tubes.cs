using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string cInput;
            int n;
            int m;
            int totalLength = 0;
            int result = 0;

            cInput = Console.ReadLine();
            n = Convert.ToInt32(cInput);

            int[] tubeLength = new int[n];

            cInput = Console.ReadLine();
            m = Convert.ToInt32(cInput);

            for (int i = 0; i < n; i++)
            {
                cInput = Console.ReadLine();
                tubeLength[i] = Convert.ToInt32(cInput);
                totalLength += tubeLength[i];
            }
            totalLength /= m;
            while (result != m)
            {
                result = 0;
                for (int i = 0; i < tubeLength.Length; i++)
                {
                    result += tubeLength[i] / totalLength;
                }
                totalLength--;
            }
            Console.WriteLine(totalLength + 1);
        }
    }
}
