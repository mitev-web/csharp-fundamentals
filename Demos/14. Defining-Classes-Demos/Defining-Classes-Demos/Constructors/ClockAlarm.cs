using System;

namespace Constructors
{
	public class ClockAlarm
	{
		private int hours = 9; // Inline initialization
		private int minutes = 0; // Inline initialization

		// Default constructor
		public ClockAlarm()
		{ 
        }

		// Constructor with parameters
		public ClockAlarm(int hours, int minutes)
		{
			this.hours = hours;
			this.minutes = minutes;
		}

		public int Hours
		{
			get { return hours; }
			set { hours = value; }
		}

		public int Minutes
		{
			get { return minutes;}
			set { minutes = value; }
		}
	} 
}
