using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise06
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare a boolean variable called isFemale 
            //and assign an appropriate value corresponding to your gender.

            string name = "pena";
            string gender = "female";
            bool isFemale;


            if (gender == "male")
            {
                isFemale = false;
            }
            else
            {
                isFemale = true;
            }

            if (isFemale)
            {
                Console.WriteLine("{0} is a woman", name);
            }
            else
            {
                Console.WriteLine("{0} is a man", name);
            }


        }
    }
}
