using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RockDwarf
{
    struct Position
    {
        public int row;
        public int col;
        public ConsoleColor color;
        public string sign;
        public Position(int row, int col, ConsoleColor color, string sign)
        {
            this.row = row;
            this.col = col;
            this.color = color;
            this.sign = sign;
        }
        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
            this.color = ConsoleColor.Black;
            this.sign = "";
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            //variables
            sbyte right = 3;
            sbyte left = -3;
            int direction = right;
            int i = 0;
            bool contains = false;
            ushort score = 0;
            try
            {
                String[] signs = new String[]
            {
                "*", "?", ",", ".", "#", ";", ":", "<", "&", "+", "!", "^", 
                "%", "$", "-", "@", "TELERIK", "≤≥", ">", "=", "()", "[]", "{}"
            };
                String[] colorNames = ConsoleColor.GetNames(typeof(ConsoleColor));
                ConsoleColor[] color = new ConsoleColor[16];
                for (i = 0; i < 16; i++)
                {
                    color[i] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorNames[i]);
                }
                Random rand = new Random();

                //Remove the crollbars
                Console.BufferHeight = Console.WindowHeight;
                Console.BufferWidth = Console.WindowWidth;

                //The dwarf in the begining
                Position dwarf = new Position(24, 38, color[12], "(0)");
                Queue<Position> rockDwarf = new Queue<Position>();
                rockDwarf.Enqueue(dwarf);
                Console.SetCursorPosition(dwarf.col, dwarf.row);
                Console.ForegroundColor = dwarf.color;
                Console.Write(dwarf.sign);

                //Rocks in the begining
                //Creating a list of rocks
                List<Position> startRocks = new List<Position>();
                for (i = 0; i < 25; i++)
                {
                    startRocks.Add(new Position(rand.Next(0, 20), rand.Next(0, 78), color[rand.Next(1, 16)], signs[rand.Next(0, 23)]));
                }
                //Putting them in a queue
                Queue<Position> rocks = new Queue<Position>();
                foreach (Position startRock in startRocks)
                {
                    rocks.Enqueue(startRock);
                }
                //Drawing them on the screen
                foreach (Position rock in rocks)
                {
                    Console.ForegroundColor = rock.color;
                    Console.SetCursorPosition(rock.col, rock.row);
                    Console.Write(rock.sign);
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Catch the yellow rocks to increase your score.\nPress any key to continue...");
                ConsoleKeyInfo userInput = Console.ReadKey();
                //The game itself
                while (true)
                {
                    Console.Clear();

                    direction = 0;
                    if (Console.KeyAvailable)
                    {
                        userInput = Console.ReadKey();
                        if (userInput.Key == ConsoleKey.LeftArrow)
                        {
                            direction = left;
                        }
                        if (userInput.Key == ConsoleKey.RightArrow)
                        {
                            direction = right;
                        }
                    }

                    //The rocks are moving
                    for (i = 0; i < 25; i++)
                    {
                        startRocks[i] = rocks.Dequeue();
                        if (startRocks[i].row + 1 != 25)
                        {
                            startRocks[i] = new Position(startRocks[i].row + 1, startRocks[i].col, startRocks[i].color, startRocks[i].sign);
                            rocks.Enqueue(startRocks[i]);
                        }
                        else
                        {
                            startRocks.Remove(startRocks[i]);
                            startRocks.Insert(i, new Position(0, rand.Next(0, 78), color[rand.Next(1, 16)], signs[rand.Next(0, 23)]));
                            rocks.Enqueue(startRocks[i]);
                        }
                    }
                    foreach (Position rock in rocks)
                    {
                        Console.ForegroundColor = rock.color;
                        Console.SetCursorPosition(rock.col, rock.row);
                        Console.Write(rock.sign);
                    }

                    //The dwarf is moving
                    dwarf = rockDwarf.Dequeue();
                    if ((direction == right && dwarf.col < 75) || (direction == left && dwarf.col > 3))
                    {
                        dwarf = new Position(dwarf.row, dwarf.col + direction, dwarf.color, dwarf.sign);
                    }
                    rockDwarf.Enqueue(dwarf);
                    Console.SetCursorPosition(dwarf.col, dwarf.row);
                    Console.ForegroundColor = dwarf.color;
                    Console.Write(dwarf.sign);

                    //Colision detection
                    //Keeping score
                    foreach (Position rock in rocks)
                    {
                        contains = rock.row == 24 && (dwarf.col == rock.col || (dwarf.col + 1) == rock.col || (dwarf.col + 2) == rock.col);
                        if (rock.color != color[14] && contains)
                        {
                            Console.Clear();
                            throw new Exception("Game Over...");
                        }
                        if (contains && rock.color == color[14])
                        {
                            score++;
                        }
                    }
                    Thread.Sleep(150);
                }
            }
            catch (Exception ex)
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(ex.Message);
                Console.WriteLine("Your score is: {0}", score);
            }
        }
    }
}