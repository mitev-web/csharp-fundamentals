using System;

namespace Constructors
{
	public class Person
	{
		private string name;
		private int age;

		// Default constructor
		public Person()
		{
			name = "[no name]";
			age = 0;
		}

		// Constructor with parameters
		public Person(string name, int age)
		{
			this.name = name;
			this.age = age;
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public int Age
		{
			get { return age; }
			set { age = value; }
		}
	} 
}