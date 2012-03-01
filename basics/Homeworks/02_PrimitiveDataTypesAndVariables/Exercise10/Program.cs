using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise10
{
    class Program
    {
        static void Main(string[] args)
        {
            //A marketing firm wants to keep record of its employees. 
            //Each record would have the following characteristics – first name, family name, age, gender (m or f), ID number, unique employee number (27560000 to 27569999). 
            //Declare the variables needed to keep the information for a single employee using appropriate data types and descriptive names.

            string firstName = "Pero";
            string secondName = "Peshev";
            byte age = 28;
            bool isMale = true;
            ushort id = 3123;
            int EmployeeID = 27560000;
            Console.WriteLine("{0} {1} \n age:{2} \n id:{3} \n employee id: {4}", firstName, secondName, age, id, EmployeeID);

        }
    }
}
