using System;

class SlowBuildingStrings
{
    public static string DupChar(char ch, int count)
    {
        string result = "";
        for (int i = 0; i < count; i++)
        {
            result += ch;
        }
        return result;
    }

    static void Main()
    {
        DateTime startTime = DateTime.Now;
        DupChar('a', 50000);
        DateTime endTime = DateTime.Now;
        Console.WriteLine(endTime - startTime);

        startTime = DateTime.Now;
        DupChar('a', 200000);
        endTime = DateTime.Now;
        Console.WriteLine(endTime - startTime);
    }
}
