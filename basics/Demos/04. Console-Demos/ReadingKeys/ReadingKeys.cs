using System;

class ReadingKeys
{
    static void Main()
    {
        ConsoleKeyInfo key = Console.ReadKey();
        Console.WriteLine();
        Console.WriteLine("Character entered: " + key.KeyChar);
        Console.WriteLine("Special keys: " + key.Modifiers);
    }
}
