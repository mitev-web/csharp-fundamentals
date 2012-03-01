using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise03
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that safely compares floating-point numbers with precision of 0.000001.

            float a = 1.463234f;
            float b = 1.4632342f;
            float epsilon = 0.000001f;

            string state = "";
            if (IsNearlyEqual(a, b, epsilon))
            {
                state = "are";
            }
            else
            {
                state = "are not";
            }
            Console.WriteLine("Both numbers {0} nearly equal", state);
        }


       public static bool IsNearlyEqual(float a, float b, float epsilon)
       {
         float absA = Math.Abs(a);
         float absB = Math.Abs(b);
         float diff = Math.Abs(a - b);

        if (a == b) { // shortcut, handles infinities
            return true;
        } else if (a * b == 0) { // a or b or both are zero
            // relative error is not meaningful here
            return diff < (epsilon * epsilon);
        } else { // use relative error
            return diff / (absA + absB) < epsilon;
        }
    }
    }
}
