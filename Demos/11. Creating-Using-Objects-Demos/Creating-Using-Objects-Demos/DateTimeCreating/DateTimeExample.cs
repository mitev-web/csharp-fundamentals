using System;

class DateTimeExample
{
	static void Main()
	{
		DateTime halloween = new DateTime(2006, 10, 31);
		Console.WriteLine(halloween);

		DateTime julyMorning;
		julyMorning = new DateTime(2006,7,1, 5,52,0);
		Console.WriteLine(julyMorning);
	}
}
