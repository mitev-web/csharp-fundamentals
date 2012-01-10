using System;

namespace Constructors
{
	public class Point
	{
		private int xCoord;
		private int yCoord;
		private string name;
	
		public Point() : this(0,0)
		{ 
        }

		public Point(int xCoord, int yCoord)
		{
			this.xCoord = xCoord;
			this.yCoord = yCoord;
			name = string.Format("({0},{1})", xCoord, yCoord);
		}

		public int XCoord
		{
			get { return xCoord; }
			set { xCoord = value; }
		}

		public int YCoord
		{
			get { return yCoord; }
			set { yCoord = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	} 
}
