using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Digits
{
    static bool[][] possibleDigits;
    static string result;
    static int N;
    static List<string> resultArray=new List<string>();
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        string[] stringArray = new string[N];
        for (int i = 0; i < N; i++)
        {
            stringArray[i] = Console.ReadLine();
        }
        //N = 1;
        //string[] stringArray = { "1011111" };
        possibleDigits = new bool[N][];
        for (int i = 0; i < N; i++)
		{
            possibleDigits[i]=new bool[10];
			 possibleDigits[i]=PossibleDigits(stringArray[i]);
		}
        //bool[] result = PossibleDigits(stringArray[0]);
        //foreach (var item in result)
        //{
        //    Console.Write("{0} ", item);
        //}
        Variation(0);
        Console.WriteLine(resultArray.Count);
        //int[] tmpArray = new int[resultArray.Count];
        //for (int i = 0; i < resultArray.Count; i++)
        //{
        //    tmpArray[i] = int.Parse(resultArray[i]);
        //}
        //Array.Sort(tmpArray);
        for (int i = 0; i < resultArray.Count; i++)
        {
            if (resultArray[i].Length==(N-1))
            {
                resultArray[i] = resultArray[i] + resultArray[i][resultArray[i].Length - 1];
            }
        }
        resultArray.Sort();

        foreach (var item in resultArray)
        {
            Console.WriteLine("{0}", item);
        }
    }
    //static byte CalcDigit(string line)
    //{
    //    byte calcDigit=0;
    //    switch (line)
    //    {
    //        case "1111110": calcDigit = 0; break;
    //        case "0110000": calcDigit = 1; break;
    //        case "1101101": calcDigit = 2; break;
    //        case "1111001": calcDigit = 3; break;
    //        case "0110011": calcDigit = 4; break;
    //        case "1011011": calcDigit = 5; break;
    //        case "1011111": calcDigit = 6; break;
    //        case "1110000": calcDigit = 7; break;
    //        case "1111111": calcDigit = 8; break;
    //        case "1111011": calcDigit = 9; break;
    //    }
    //    return calcDigit;
    //}
    static string CalcSegments(byte calcDigit)
    {
        string calcSegments="";
        switch (calcDigit)
        {
            case 0: calcSegments = "1111110"; break;
            case 1: calcSegments = "0110000"; break;
            case 2: calcSegments = "1101101"; break;
            case 3: calcSegments = "1111001"; break;
            case 4: calcSegments = "0110011"; break;
            case 5: calcSegments = "1011011"; break;
            case 6: calcSegments = "1011111"; break;
            case 7: calcSegments = "1110000"; break;
            case 8: calcSegments = "1111111"; break;
            case 9: calcSegments = "1111011"; break;
        }
        return calcSegments;
    }
    static byte BinToDec(string binRepresentation)
    {
        int len = binRepresentation.Length;
        int decNumber = 0;
        int powerTwo = 1;
        byte digit = 0;
        for (int i = len - 1; i >= 0; i--)
        {
            digit = (byte)(binRepresentation[i] - '0');
            decNumber += powerTwo * digit;
            powerTwo *= 2;
        }
        return (byte)decNumber;
    }
    static bool[] PossibleDigits(string calcSegments)
    {
        bool[] possibleDigitsIndex = new bool[10];
        for (byte i = 0; i < 10; i++)
        {
            bool possible = (BinToDec(calcSegments) | BinToDec(CalcSegments(i))) == BinToDec(CalcSegments(i));
            if (possible)
            {
                possibleDigitsIndex[i] = true;
            }
        }
        return possibleDigitsIndex;
    }
    static void Variation(int currentLoop)
    {
        if (currentLoop == N)
        {
            //Print(vector);
            resultArray.Add(result);    //.PadLeft(N,'0')
            result = "";
            //return;
        }
        else
        {
            for (int j = 0; j <= 9; j++)
            {
                if (possibleDigits[currentLoop][j])
                {
                    //vector[currentLoop] = j;
                    
                        result += j;
                    
                    
                    Variation(currentLoop + 1);
                }                
            }
        }
    }
}
