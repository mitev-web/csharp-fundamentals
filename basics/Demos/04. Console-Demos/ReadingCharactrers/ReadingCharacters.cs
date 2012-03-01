using System;

class ReadingCharacters
{
    static void Main()
    {
        int i = Console.Read();
        
        char ch = (char)i;  // Cast the int value to char

        // Gets the code of the entered symbol
        Console.WriteLine("The code of '{0}' is {1}.", ch, i);
    }
}
