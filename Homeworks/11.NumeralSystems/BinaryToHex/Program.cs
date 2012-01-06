using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryToHex
{
    class Program
    {
        static void Main(string[] args)
        {
           //Write a program to convert binary numbers to hexadecimal numbers (directly).
            string binaryNumber = "000111110100";

            Console.WriteLine(ConvertBinaryToHex(binaryNumber));
        }

        public static string ConvertBinaryToHex(string binaryNumber){

            string temp = "";
            string hexNumber = "";
            foreach (var c in binaryNumber)
            {
                temp += c;

                if (temp.Length == 4)
                {

                    switch (temp)
                    {
                        case "0000": temp = "0"; break;
                        case "0001": temp = "1"; break;
                        case "0010": temp = "2"; break;
                        case "0011": temp = "3"; break;
                        case "0100": temp = "4"; break;
                        case "0101": temp = "5"; break;
                        case "0110": temp = "6"; break;
                        case "0111": temp = "7"; break;
                        case "1000": temp = "8"; break;
                        case "1001": temp = "9"; break;
                        case "1010": temp = "A"; break;
                        case "1011": temp = "B"; break;
                        case "1100": temp = "C"; break;
                        case "1101": temp = "D"; break;
                        case "1110": temp = "E"; break;
                        case "1111": temp = "F"; break;
                    }
                    hexNumber += temp;

                    temp = "";
                }
            }
            return hexNumber;

        }
    }
}
