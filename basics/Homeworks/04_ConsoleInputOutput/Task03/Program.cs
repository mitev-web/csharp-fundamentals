using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            //A company has name, address, phone number, fax number, web site and 
            //manager. The manager has first name, last name, age and a phone number. 
            //Write a program that reads the information about a company 
            //and its manager and prints them on the console.
            string input;
            string companyName;
            string companyAddress;
            string companyPhone;
            string companyFax;
            string companyURL;
            string managerFName;
            string managerLName;
            byte managerAge;
            string managerPhone;


            Console.WriteLine("please enter company name");
            companyName = Console.ReadLine();

            Console.WriteLine("please enter company address");
            companyAddress = Console.ReadLine();

            Console.WriteLine("please enter company phone");
            companyPhone = Console.ReadLine();

            Console.WriteLine("please enter company fax");
            companyFax = Console.ReadLine();

            Console.WriteLine("please enter company URL");
            companyURL = Console.ReadLine();

            Console.WriteLine("please enter Manager's First Name");
            managerFName = Console.ReadLine();

            Console.WriteLine("please enter Manager's Last Name");
            managerLName = Console.ReadLine();

            Console.WriteLine("please enter Manager's phone");
            managerPhone = Console.ReadLine();

            Console.WriteLine("please enter Manager's age");
            input = Console.ReadLine();
            byte.TryParse(input, out managerAge);


            Console.WriteLine("Company: {0}", companyName);
            Console.WriteLine("Address: {0}", companyAddress);
            Console.WriteLine("URL:     {0}", companyURL);
            Console.WriteLine("Phone:   {0}", companyPhone);
            Console.WriteLine("Fax:     {0}", companyFax);
            Console.WriteLine("----------------------------");
            Console.WriteLine("Manager: {0}", managerFName);
            Console.WriteLine("         {0}", managerLName);
            Console.WriteLine("Age:     {0}", managerAge);
            Console.WriteLine("Phone:   {0}", managerPhone);





        }
    }
}
