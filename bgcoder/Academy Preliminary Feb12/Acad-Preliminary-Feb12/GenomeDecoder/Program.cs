using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class GenomeDecoder
{
    static int N = 6;
    static int M = 3;

    static string encoded = "10A15G3CA6T19C";
    
    static void Main(string[] args)
    {
        string[] decoded = Regex.Split(encoded, "[0-9]+w");

        foreach (String a in decoded)
        {
            Console.WriteLine(a);
        }

    }
}