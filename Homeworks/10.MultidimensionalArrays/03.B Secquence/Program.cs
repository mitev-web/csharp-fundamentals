using System;

class MatrixLongestSequence
{
    struct result
    {
        public int sequence;
        public string value;
    }

    static void Main(string[] args)
    {
        string[,] matrix = {
                        { "ha", "fifi", "ho","hi"  },
                        { "fo", "ha", "hi", "xx" },
                        { "xxx", "ho", "ha", "xx" }
                        };
        int bestSequence = 0;
        string bestValue = null;
        result current;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                current = checkLine(matrix, row, col);
                if (current.sequence > bestSequence)
                {
                    bestSequence = current.sequence;
                    bestValue = current.value;
                }
                current = checkColumn(matrix, row, col);
                if (current.sequence > bestSequence)
                {
                    bestSequence = current.sequence;
                    bestValue = current.value;
                }
                current = checkLeftDiagonal(matrix, row, col);
                if (current.sequence > bestSequence)
                {
                    bestSequence = current.sequence;
                    bestValue = current.value;
                }
                current = checkRightDiagonal(matrix, row, col);
                if (current.sequence > bestSequence)
                {
                    bestSequence = current.sequence;
                    bestValue = current.value;
                }
            }
        }
        Console.WriteLine(bestSequence);
        Console.WriteLine(bestValue);
    }

    static result checkLine(string[,] matrix, int row, int col)
    {
        result current;
        current.sequence = 1;
        current.value = matrix[row, col];
        for (int i = col + 1; i < matrix.GetLength(1); i++)
        {
            if (matrix[row, i] == current.value)
            {
                current.sequence++;
            }
            else
            {
                break;
            }
        }
        return current;
    }

    static result checkColumn(string[,] matrix, int row, int col)
    {
        result current;
        current.sequence = 1;
        current.value = matrix[row, col];
        for (int i = row + 1; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, col] == current.value)
            {
                current.sequence++;
            }
            else
            {
                break;
            }
        }
        return current;
    }

    static result checkLeftDiagonal(string[,] matrix, int row, int col)
    {
        result current;
        current.sequence = 1;
        current.value = matrix[row, col];
        for (int i = row + 1, j = col - 1; i < matrix.GetLength(0) && j >= 0; i++, j--)
        {
            if (matrix[i, j] == current.value)
            {
                current.sequence++;
            }
            else
            {
                break;
            }
        }
        return current;
    }

    static result checkRightDiagonal(string[,] matrix, int row, int col)
    {
        result current;
        current.sequence = 1;
        current.value = matrix[row, col];
        for (int i = row + 1, j = col + 1; i < matrix.GetLength(0) && j < matrix.GetLength(1); i++, j++)
        {
            if (matrix[i, j] == current.value)
            {
                current.sequence++;
            }
            else
            {
                break;
            }
        }
        return current;
    }
}