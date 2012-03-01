using System;

class Triangle
{
	static void Main()
	{
		Console.Write("n = ");
		int n = int.Parse(Console.ReadLine());
		Console.WriteLine();

        for (int row = 1; row <= n; row++)
        {
            for (int col = 1; col <= row; col++)
            {
                Console.Write("{0} ", col);
            }
	        Console.WriteLine();
        }
	}
}
