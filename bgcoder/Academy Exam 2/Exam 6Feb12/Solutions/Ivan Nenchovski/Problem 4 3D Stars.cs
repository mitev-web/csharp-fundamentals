using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4._3D_Stars
{
	class Program
	{
		enum Direction { Forward, Backward, Deeper, Shallower, Left, Right };
		const bool DEBUG_MODE_ON = false;
		static System.IO.StreamReader inputFile = DEBUG_MODE_ON ? new System.IO.StreamReader("test2.txt") : null;

		static int CharToIndex(char x)
		{
			return x - 'A';
		}

		static int[] colorOccurrences = new int['Z' - 'A' + 1];

		class CuboidEnumerator
		{
			public int WPos { get; private set; }
			public int HPos { get; private set; }
			public int DPos { get; private set; }

			public CuboidEnumerator() :
				this(0, 0, 0)
			{

			}

			public CuboidEnumerator(CuboidEnumerator c)
			{
				if (c != null)
				{
					WPos = c.WPos;
					HPos = c.HPos;
					DPos = c.DPos;
				}
				else
				{
					throw new System.ArgumentNullException();
				}
			}

			public CuboidEnumerator(int wPos, int hPos, int dPos)
			{
				WPos = wPos;
				HPos = hPos;
				DPos = dPos;
			}

			public void Move(Direction d)
			{
				switch (d)
				{
					case Direction.Forward:		DPos++; break;
					case Direction.Backward:	DPos--; break;
					case Direction.Deeper:		HPos--; break;
					case Direction.Shallower:	HPos++; break;
					case Direction.Left:		WPos--; break;
					case Direction.Right:		WPos++; break;
				}
			}

			public CuboidEnumerator GetNewFromDirection(Direction d)
			{
				CuboidEnumerator result = new CuboidEnumerator(this);
				result.Move(d);
				return result;
			}

			public override string ToString()
			{
				StringBuilder buffer = new StringBuilder();
				buffer.AppendFormat("[{0} {1} {2}]", WPos, HPos, DPos);
				return buffer.ToString();
			}
		}

		class Cuboid
		{
			private char[, ,] cells;
			private Dictionary<char, uint> stars;

			public Dictionary<char, uint> Stars
			{
				get
				{
					if (stars == null)
					{
						stars = new Dictionary<char, uint>();
						EnumerateStars();
					}
					return stars;
				}

				private set
				{
					stars = value;
				}
			}
			public int Width { get; private set; }
			public int Height { get; private set; }
			public int Depth { get; private set; }

			public char this[int wPos, int hPos, int dPos]
			{
				get
				{
					char val = char.MinValue;
					try
					{
						val = cells[wPos, hPos, dPos];
						return val;
					}
					catch (IndexOutOfRangeException)
					{
						return val;
					}
				}

				set
				{
					char val = value;
					try
					{
						cells[wPos, hPos, dPos] = val;
					}
					catch (IndexOutOfRangeException)
					{

					}
				}
			}
			public static int iterations = 0;
			public void EnumerateStars()
			{
				for (int w = 1; w < Width - 1; w++)
				{
					for (int h = 1; h < Height - 1; h++)
					{
						for (int d = 1; d < Depth - 1; d++, iterations++)
						{
							CuboidEnumerator currentPos = new CuboidEnumerator(w, h, d);
							if (IsStar(currentPos))
							{
								colorOccurrences[CharToIndex(this[currentPos])]++;
								//char current = this[currentPos];
								//if (stars.ContainsKey(current))
								//{
								//    stars[current]++;
								//}
								//else
								//{
								//    stars.Add(current, 1);
								//}
							}
						}
					}
				}
			}

			public bool IsStar(CuboidEnumerator fromPos)
			{
				char currentColor = this[fromPos];
				return (currentColor == this[fromPos.WPos, fromPos.HPos, fromPos.DPos + 1] &&
					currentColor == this[fromPos.WPos, fromPos.HPos, fromPos.DPos - 1] &&
					currentColor == this[fromPos.WPos, fromPos.HPos + 1, fromPos.DPos] &&
					currentColor == this[fromPos.WPos, fromPos.HPos - 1, fromPos.DPos] &&
					currentColor == this[fromPos.WPos + 1, fromPos.HPos, fromPos.DPos] &&
					currentColor == this[fromPos.WPos - 1, fromPos.HPos, fromPos.DPos]
					);
				//return (this[fromPos] == this[fromPos.GetNewFromDirection(Direction.Backward)] &&
				//    this[fromPos] == this[fromPos.GetNewFromDirection(Direction.Forward)] &&
				//    this[fromPos] == this[fromPos.GetNewFromDirection(Direction.Deeper)] &&
				//    this[fromPos] == this[fromPos.GetNewFromDirection(Direction.Shallower)] &&
				//    this[fromPos] == this[fromPos.GetNewFromDirection(Direction.Left)] &&
				//    this[fromPos] == this[fromPos.GetNewFromDirection(Direction.Right)]
				//    );
			}

			public char this[CuboidEnumerator c]
			{
				get
				{
					return this[c.WPos, c.HPos, c.DPos];
				}

				set
				{
					this[c.WPos, c.HPos, c.DPos] = value;
				}
			}

			public Cuboid(char[, ,] cells)
			{
				this.cells = cells;
				//stars = new Dictionary<char, uint>();
				Width = cells.GetLength(0);
				Height = cells.GetLength(1);
				Depth = cells.GetLength(2);
			}

		}

		public static string GetInput()
		{
			return DEBUG_MODE_ON ? inputFile.ReadLine() : Console.ReadLine();
		}

		static char[, ,] GetMatrix()
		{
			string[] dimensions = GetInput().Split(' ');
			int width = Convert.ToInt32(dimensions[0]);
			int height = Convert.ToInt32(dimensions[1]);
			int depth = Convert.ToInt32(dimensions[2]);

			char[, ,] matrix = new char[width, height, depth];
			for (int i = 0; i < height; i++)
			{
				string[] inputSequences = GetInput().Split(' ');
				for (int j = 0; j < depth; j++)
				{
					for (int k = 0; k < width; k++)
					{
						matrix[k, i, j] = inputSequences[j][k];
					}
				}
			}

			return matrix;
		}

		static void Main(string[] args)
		{
			char[, ,] testMatrix = GetMatrix();
			Cuboid examMain = new Cuboid(testMatrix);
			examMain.EnumerateStars();
			int sum = 0;
			for (int i = 0; i < colorOccurrences.Length; i++)
			{
				sum += colorOccurrences[i];
			}
			Console.WriteLine(sum);
			for (char x = 'A'; x <= 'Z'; x++)
			{
				int currentIndex = CharToIndex(x);
				if (colorOccurrences[currentIndex] != 0)
				{
					Console.WriteLine("{0} {1}", x, colorOccurrences[currentIndex]);
				}
			}
			//Dictionary<char, uint> stars = examMain.Stars;
			//IEnumerable<KeyValuePair<char, uint>> sortedResult = stars.OrderBy(x => x.Key);
			//Console.WriteLine(stars.Sum(x => x.Value));
			//foreach (KeyValuePair<char, uint> star in sortedResult)
			//{
			//    Console.WriteLine("{0} {1}", star.Key, star.Value);
			//}
		}
	}
}
