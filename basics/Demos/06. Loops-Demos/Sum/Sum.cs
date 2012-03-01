using System;

class Sum
{	
	static void Main()
	{
		Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        int num = 1;
		int sum = 1;

		Console.Write("The sum 1");
		while (num < n)
		{
			num++;
			sum += num;
			Console.Write("+{0}", num);
		}
		Console.WriteLine(" = {0}", sum);
	}
}
