using System;

class FormattingStrings
{
    static void Main()
    {
        int number = 42;
        string s = number.ToString("D5"); // 00042
        Console.WriteLine(s);

        s = number.ToString("X"); // 00042
        Console.WriteLine(s);

        // Consider the default culture is Bulgarian
        s = number.ToString("C"); // 42,00 ыт
        Console.WriteLine(s);

        double d = 0.375;
        s = d.ToString("F2"); // 0,38
        Console.WriteLine(s);

        s = d.ToString("F10"); // 0,3750000000
        Console.WriteLine(s);

        s = d.ToString("P2"); // 37,50 %
        Console.WriteLine(s);

        string template = "If I were {0}, I would {1}.";
        string sentence1 = String.Format(
            template, "developer", "know C#");
        Console.WriteLine(sentence1);
        // If I were developer, I would know C#.

        string sentence2 = String.Format(
            template, "elephant", "weigh 4500 kg");
        Console.WriteLine(sentence2);
        // If I were elephant, I would weigh 4500 kg.

        s = String.Format("{0,10:D}", number); // "        42"
        Console.WriteLine(s);

        s = String.Format("{0,10:F5}", d); // "   0,37500"
        Console.WriteLine(s);

        Console.WriteLine("Dec {0:D} = Hex {1:X}", number, number);
        // "Dec 42 = Hex 2A"

        DateTime now = DateTime.Now;
        Console.WriteLine("Now is {0:d.MM.yyyy HH:mm:ss}.", now);
        // Now is 31.03.2006 08:30:32
    }
}
