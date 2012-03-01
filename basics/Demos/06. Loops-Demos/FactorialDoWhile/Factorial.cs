using System;
//using System.Numerics;

class Factorial
{
	static void Main()
	{
		Console.Write("n = ");
        int n = Convert.ToInt32(Console.ReadLine());
        decimal factorial = 1;
        //BigInteger factorial = 1;

		do
		{
			factorial *= n;
			n--;
		}
        while (n > 0);
		
		Console.WriteLine("n! = " + factorial);
	}
}
