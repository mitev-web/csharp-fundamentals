using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArithmeticalExpression
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter Expression");
            string expression = Console.ReadLine();
            Evaluator expressionEvaluator =
                new Evaluator();
            double result = 0;
            if (expressionEvaluator.TryEvaluate(expression,
                out result))
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Incorrect expression!");
            }
        }
    }
}
