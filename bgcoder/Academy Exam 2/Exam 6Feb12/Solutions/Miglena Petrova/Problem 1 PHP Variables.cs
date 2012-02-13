using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
  
namespace Exam2_Zad1_PHPToC 
{ 
    class Program 
    { 
        static void Main(string[] args) 
        { 
            StringBuilder variables = new StringBuilder(); 
            int countLines = 0; 
            int countVar = 0; 
            bool end = false; 
              
            string line; 
            int i = 0; 
            do
            { 
                i++; 
                line = Console.ReadLine(); 
                if (line[i] == '\n') 
                    countLines++; 
                if (line == "?>") 
                { 
                    end = true; 
                } 
            } 
            while (end); 
            for (i = 0; i < countLines; i++) 
            { 
                if ((line[i] == '$') && (line[i-1] != '\\') && ((line[i + 1] == '_') || (char.IsLetter(line[i + 1])))) 
                { 
                    countVar++; 
                    int j = i+1; 
                    while ((line[j] != ' ') && ((line[j] != '[') || (line[j] != ']'))) 
                    { 
                        variables.Append(line[j]); 
                        j++; 
                    } 
                    variables.Append(' '); 
                    //variables.Append('\n'); 
                } 
            } 
            string validVariables = variables.ToString(); 
            string[] vars = validVariables.Split(); 
            Array.Sort(vars); 
            Console.WriteLine(countVar); 
            for (i = 0; i < countVar; i++) 
            { 
                Console.WriteLine(vars[i]); 
            } 
        } 
    } 
} 

