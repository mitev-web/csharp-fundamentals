using System;
using System.Text;
using System.Threading;
using System.Globalization;

class RegionalSettingsDemo
{
	static void Main()
	{
		Console.OutputEncoding = Encoding.UTF8;
		Console.WriteLine("Това е кирилица: ☺");
		Console.WriteLine("© Светлин Наков, 2011");
		Console.WriteLine("السلام عليكم");

		double value = 3.54;
		Console.WriteLine("The value is: {0}", value);
		// Two possible outputs:
		// The value is 3.54
		// The value is 3,54

		Thread.CurrentThread.CurrentCulture =
			CultureInfo.InvariantCulture;

		Console.WriteLine("The value is: {0}", value);
		// The value is 3.54

		// Now the decimal separator is "."
		decimal d = Decimal.Parse(Console.ReadLine());
		Console.WriteLine(d);
	}
}
