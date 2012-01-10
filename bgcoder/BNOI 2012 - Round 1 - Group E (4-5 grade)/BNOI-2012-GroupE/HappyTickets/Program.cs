using System;
using System.Linq;

//Task Е2. LUCKY TICKET
//Author: Plamenka Hristova
//Every morning, going to the school, Ivan and Goshko verify which tickets for their bus travel are "happy". Children decided that to be a "happy", a ticket must fulfill the following two conditions:
//1 - the six-digit serial number on the ticket is such that the sum of its first three digits is equal to the sum of its last three digits.
//2 - the value of its second digit is not less than the value of its fourth digit. 
//Write a program lucky, that checks whether a ticket is happy, if you know its number. For example, ticket number 273516 is happy, because 2 +7 +3 = 5 +1 +6 and 7> 5.
//Input
//On the only line of the standard input is written a six-digit number – the serial number of the ticket.
//Output
//If the ticket is happy, on the only line of the standard output must be written one number - the sum of the first three digits of the serial number on the ticket. 
//If the ticket is not happy, the only line of the standard output should display the reason code:
//30 - both conditions for "happiness" are not fulfilled;
//31 - the first condition for "happiness" is not fulfilled, and the second is fulfilled;
//32 - the first condition for "happiness" is fulfilled, but the second is not met.
//Examples
//Input			Input
//273516		143256
//Output		Output
//12			31

    class Program
    {
        static void Main(string[] args)
        {

            string number = Console.ReadLine();


            bool firstCondition = false;
            bool secondCondition = false;

            int first3Numbers = int.Parse(number[0].ToString()) + int.Parse(number[1].ToString()) + int.Parse(number[2].ToString());
            int second3Numbers = int.Parse(number[3].ToString()) + int.Parse(number[4].ToString()) + int.Parse(number[5].ToString());

            if (first3Numbers == second3Numbers)
            {
                firstCondition = true;
            }

            if (int.Parse(number[1].ToString()) > int.Parse(number[3].ToString()))
            {
                secondCondition = true;
            }


            if (!firstCondition && !secondCondition)
            {
                Console.WriteLine(30);
            }

            if (!firstCondition && secondCondition)
            {
                Console.WriteLine(31);
            }
            if (firstCondition && !secondCondition)
            {
                Console.WriteLine(32);
            }

            if (firstCondition && secondCondition)
            {
                Console.WriteLine(first3Numbers);
            }

        }
    }

