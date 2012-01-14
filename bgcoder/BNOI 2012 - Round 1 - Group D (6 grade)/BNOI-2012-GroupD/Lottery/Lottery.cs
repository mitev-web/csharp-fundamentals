using System;
using System.Linq;

namespace Lottery
{
//    At the school, there is a Christmas lottery. Each student has a lottery number. 
//Winning are those numbers, which have repeating digits. 
//Write a program lottery that inputs a positive integer n and displays the last digit in it, which is repeated.
//Input
//The program inputs natural number n. 
//Output
//The program outputs the last digit, which is repeated in the number n, if there exists one, and No otherwise.
//Restrictions
//9 <n< 2000000000
//Examples
 
//Input
//234256 
//Output
//2

//Input
//676678
//Output
//7

//Input
//2345
//Output
//No

    class Lottery
    {
        static void Main(string[] args)
        {
            string N = Console.ReadLine();

            Console.WriteLine(CharIsRepeated(N));

        }


        private static string CharIsRepeated(string str)
        {
            char c = str.Last();

            str = str.Substring(0, str.Length - 1);

            int count = 1;

            for(int i = str.Length-1;i>= 0;i--)
            {
                if (str[i] == c)
                {
                    count++;
                }
            }

            if (count > 1)
            {
                return c.ToString();
            }

                if (str.Length > 0)
                {
                   return CharIsRepeated(str);
                }
                else
                {
                    return "No";
                }
            }
            
        }
    }

