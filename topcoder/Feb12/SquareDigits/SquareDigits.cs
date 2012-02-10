using System;
using System.Collections.Generic;

class SquareDigits
{
    public int SmallestResult(int number)
    {
        for (int i = 1; i < 9999; i++)
        {
            if (BrakeToSquares(number, i, -1, 1) == i)
            {
                return i;
            }
        }

        return -1;
    }
    private static int BrakeToSquares(int numb, int startWith, int result, int counter)
    {
        if (numb == 1)
            return 1;

        if (numb == result)
        {
            return startWith;
        }
        if (counter == 9999)
        {
            return -1;
        }

        if (result == -1)
        {
            result = startWith;
        }
 
        List<int> numbers = new List<int>();

        foreach (char c in result.ToString())
        {
            numbers.Add(int.Parse(c.ToString()));
        }
        result = 0;
        foreach (int item in numbers)
        {
            result += item * item;
        }

        return BrakeToSquares(numb, startWith, result, ++counter);
    }
}