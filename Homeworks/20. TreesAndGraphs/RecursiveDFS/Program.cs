using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecursiveDFS
{
    //Implement the recursive Depth-First-Search (DFS)
    //traversal algorithm. Test it with the sample graph
    //from the demonstrations.

    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph(
                new int[][] {
                new int[] { 6,3},
                new int[] { 4,1,0},
                new int[] { 0,1,5},
                new int[] { 6,4,2,5,3},
                new int[] { 6,1,2},
                new int[] { 4,1,5},
                new int[] { 2,1,3},
                new int[] { 4,1,5}                
                });
        }
    }

    public class Graph
    {
        internal const int MaxNode = 1024;
        private int[][] childnodes;

        public Graph(int[][] childNodes)
        {
            this.childnodes = childNodes;
        }

    }
}
