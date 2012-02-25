using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    //* We are given a labyrinth of size N x N. Some of its cells
    //are empty (0) and some are full (x). We can move from an 
    //empty cell to another empty cell if they share common wall.
    //Given a starting position (*) calculate and fill in the array
    //the minimal distance from this position to any other cell in 
    //the array. Use "u" for all unreachable cells. Example:
        /*
    0	0	0	x	0	x
    0	x	0	x	0	x
    0	*	x	0	x	0
    0	x	0	0	0	0
    0	0	0	x	x	0
    0	0	0	x	0	x

    -->
    3	4	5	x	u	x
    2	x	6	x	u	x
    1	*	x	8	x	10
    2	x	6	7	8	9
    3	4	5	x	x	10
    4	5	6	x	u	x

        */
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
