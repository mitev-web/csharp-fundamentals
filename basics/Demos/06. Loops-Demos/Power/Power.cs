using System;

class Power
{
	static void Main()
	{
		Console.Write("n = ");
		int n = int.Parse(Console.ReadLine());
		Console.Write("m = ");
		int m = int.Parse(Console.ReadLine());

		decimal result = 1;
        
        for(int i = 0; i < m; i++)
        {
            result *= n;
        }

		Console.WriteLine("n^m = " + result);
	}
}
