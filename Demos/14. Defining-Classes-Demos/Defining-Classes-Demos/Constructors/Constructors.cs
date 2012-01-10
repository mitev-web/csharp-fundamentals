using System;

namespace Constructors
{
	class Constructors
	{
		static void Main()
		{
			Person anonymous = new Person();
			Person peter = new Person("Peter", 19);
			Console.WriteLine("Person 1: name:{0}, age:{1}", anonymous.Name, anonymous.Age);
			Console.WriteLine("Person 2: name:{0}, age:{1}", peter.Name, peter.Age);
			Console.WriteLine();

			ClockAlarm defaultAlarm = new ClockAlarm();
			ClockAlarm earlyAlarm = new ClockAlarm(5,15);
			Console.WriteLine("Wake up!!! It's {0:D2}:{1:D2} o'clock", 
                defaultAlarm.Hours, defaultAlarm.Minutes);
			Console.WriteLine("Wake up!!! It's {0:D2}:{1:D2} o'clock", 
                earlyAlarm.Hours, earlyAlarm.Minutes);
			Console.WriteLine();

			Point centerPoint = new Point();
			centerPoint.Name = "Center of the coord system";
			Point sector1Point = new Point(7,7);
			Console.WriteLine("First point: {0}, {1} has name {2}", centerPoint.XCoord, 
                centerPoint.YCoord, centerPoint.Name);
			Console.WriteLine("Second point: {0}, {1} has name {2}", sector1Point.XCoord, 
                sector1Point.YCoord, sector1Point.Name);
			Console.WriteLine();
		}
	}
}
