using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise07
{
    class Program
    {
        static void Main(string[] args)
        {
        //Declare two string variables and assign them with “Hello” and “World”. 
        //Declare an object variable and assign it with the concatenation of the first two variables (mind adding an interval). 
        //Declare a third string variable and initialize it with the value of the object variable (you should perform type casting).
            string firstWord = "Hello";
            string secondWord = "Word!";
            object sentence = firstWord + " " + secondWord;

            string newSentence = (string)sentence;

            Console.WriteLine(newSentence);

      
        }
    }
}
