using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise14
{
    class Program
    {
        static void Main(string[] args)
        {
            //A bank account has a holder name (first name, middle name and last name), 
            //available amount of money (balance), bank name, IBAN, 
            //BIC code and number of 3 cards associated with the account. 
            //Declare the variables needed to keep the information for a single bank account 
            //using the appropriate data types and descriptive names.

            string accountFirstName = "Pero";
            string accountMiddleName = "Peshev";
            string accountLastName = "Ivanov";
            decimal accountBallance = 3.23M;

            string accountBankName = "First Investment Bank";
            string accountBIC = "FINVBG";
            string accountIBAN = "FINVBG2100000120031";
            string accountVisa = "4123 2343 43242 3243";
            string accountMasterCard = "5123 2143 43242 3243";
            string accountVisaElectron = "4421 2343 43242 3243";

            Console.WriteLine("{0} {1} {2} \n ballance: {3}lv \n Bank: {4} \n BIC: {5} \n IBAN: {6} \n credit cards: \n {7} \n {8} \n {9} \n",accountFirstName, accountMiddleName, accountLastName, accountBallance, accountBankName, accountBIC, accountIBAN, accountVisa, accountMasterCard, accountVisaElectron);



        }
    }
}
