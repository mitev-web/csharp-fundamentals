using System; // no comment...
class JustClass
{ /* Just
multiline
comment  */
    static void Main()
    {

        string j = Environment.NewLine;
        string f = Environment.NewLine.ToString();
        Console.WriteLine(Environment.NewLine.ToString().Length);
        foreach (char c in Environment.NewLine.ToString())
        {
            Console.WriteLine(c);
        }

        Console.WriteLine();
    }
}
