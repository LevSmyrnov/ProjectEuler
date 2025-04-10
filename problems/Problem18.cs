using System;

[ProblemId(18), ProblemTitle("Maximum Path Sum I")]
public class Problem18 : Problem
{
    protected override string Solve(string input)
    {
        var inputRows = input.Split('\n');
        var matrix = new int[inputRows.Length, inputRows[inputRows.Length - 1].Length];
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            var rowNumbers = inputRows[i].Split(' ');
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                if (j >= rowNumbers.Length)
                {
                    matrix[i, j] = 0;
                    continue;
                }

                int.TryParse(rowNumbers[j], out int number);
                matrix[i, j] = number;
            }
        }


        for (var i = matrix.GetLength(0) - 2; i >= 0; i--)
        {
            for (var j = matrix.GetLength(1) - 1; j >= 0; j--)
            {
                if (matrix[i, j] == 0)
                {
                    continue;
                }

                matrix[i, j] = 
                    matrix[i, j] + matrix[i + 1, j] > matrix[i, j] + matrix[i + 1, j + 1] ?
                        matrix[i, j] + matrix[i + 1, j] :
                        matrix[i, j] + matrix[i + 1, j + 1];
            }
        }

        return matrix[0, 0].ToString();
    }
}