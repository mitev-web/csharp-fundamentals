using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task13
{
    class Program
    {
        static void Main(string[] args)
        {
            //* Write a program that sorts an array of integers using the merge sort
            //    algorithm (find it in Wikipedia).


            List<string> numbers = new List<string> { "asdasdsdf", "zdsdsdf", "ddsdf","jfg","fffsdf"};

            IList jj = MergeSort((IList)numbers);
            

            foreach (var item in jj)
                Console.WriteLine(item);

        }

        public static IList MergeSort(IList list)
        {
            if (list.Count <= 1)
                return list;

            int mid = list.Count / 2;

            IList left = new ArrayList();
            IList right = new ArrayList();

            for (int i = 0; i < mid; i++)
                left.Add(list[i]);

            for (int i = mid; i < list.Count; i++)
                right.Add(list[i]);

            return Merge(MergeSort(left), MergeSort(right));
        }

        public static IList Merge(IList left, IList right)
        {
            IList rv = new ArrayList();

            while (left.Count > 0 && right.Count > 0)
            {
                if (((IComparable)left[0]).CompareTo(right[0]) > 0)
                {
                    rv.Add(right[0]);
                    right.RemoveAt(0);
                }
                else
                {
                    rv.Add(left[0]);
                    left.RemoveAt(0);
                }
            }

            for (int i = 0; i < left.Count; i++)
                rv.Add(left[i]);

            for (int i = 0; i < right.Count; i++)
                rv.Add(right[i]);

            return rv;
        }
    }


}
