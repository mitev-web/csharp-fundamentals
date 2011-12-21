using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {3,4,5,2,3};
            Array.Sort(arr, (item1, item2) =>
            {
                if (item1 == item2) return 0;
                if (item1 > item2) return 1;
                else return -1;
            });


            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }


            //2nd way
            arr = arr.OrderBy(x => x).ToArray();

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        
        }

        class B : IComparer<B>
        {
            public int Compare(B x, B y)
            {
                // TODO: Implement this method
                throw new NotImplementedException();
            }

        }

        class A : IComparable<A>
        {
            public int CompareTo(A other)
            {
                // TODO: Implement this method
                throw new NotImplementedException();
            }
        }
    }
}
