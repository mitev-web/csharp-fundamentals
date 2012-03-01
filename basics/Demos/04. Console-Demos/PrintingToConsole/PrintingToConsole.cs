using System;

class PrintingToConsole
{
    static void Main()
    {
        string name = "Peter";
        int age = 18;
        string town = "Sofia";

        Console.Write("{0} is {1} years old from {2}.",
                      name, age, town);
        Console.Write("This is on the same line!");
        Console.WriteLine("Next sentence will be" +
                          " on a new line.");

        Console.WriteLine("Bye, bye, {0} from {1}.",
                          name, town);
        Console.WriteLine();

        double someVar = 1.234;
        Console.WriteLine("sdf {0:0.000xxx}", someVar);
        // 1.234000

        int a = 2, b = 3;
        Console.Write("{0} + {1} =", a, b);
        Console.WriteLine(" {0}", a + b);
        // 2 + 3 = 5

        Console.WriteLine("{0} * {1} = {2}",
                          a, b, a * b);
        // 2 * 3 = 6

        float pi = 3.14159206f;
        Console.WriteLine("{0:F2}", pi); // 3,14
        Console.WriteLine();

        double colaPrice = 1.20;
        string cola = "Coca Cola";
        double fantaPrice = 1.20;
        string fanta = "Fanta Dizzy";
        double zagorkaPrice = 1.50;
        string zagorka = "Zagorka";

        Console.WriteLine("Menu:");
        Console.WriteLine("1. {0} – {1}",
                          cola, colaPrice);
        Console.WriteLine("2. {0} – {1}",
                          fanta, fantaPrice);
        Console.WriteLine("3. {0} – {1}",
                          zagorka, zagorkaPrice);
        Console.WriteLine("Have a nice day!");
    }
}
