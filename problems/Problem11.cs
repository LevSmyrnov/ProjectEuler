using System;

[ProblemId(11), ProblemTitle("Largest Product in a Grid")]
public class Problem11 : Problem
{
    protected override string Solve(string input)
    {
        var rows = input.Split('\n');
        var grid = new int[rows.Length, rows[0].Split(' ').Length];
        int r = 0, c = 0;
        try
        {
            foreach (var row in rows)
            {
                var elements = row.Split(' ');
                foreach (var element in elements)
                {
                    grid[r, c] = int.Parse(element);
                    c++;
                }
                r++;
                c = 0;
            }
        }
        catch (System.Exception e)
        {
            return $"Input parsing exception:\n{e.Message}";
        }
        
        long maxProduct = 0, productInRow = 0, productInColumn = 0, productInDiagonal = 0, productInDiagonalReversed = 0;
        for (r = 0;r < grid.GetLength(0); r++)
        {
            for (c = 0; c < grid.GetLength(1); c++)
            {
                if (grid[r, c] == 0)
                {
                    continue;
                }

                if (c < grid.GetLength(1) - 3)
                {
                    productInRow = (long)(grid[r, c] * grid[r, c + 1] * grid[r, c + 2] * grid[r, c + 3]);
                    if (productInRow > maxProduct)
                    {
                        maxProduct = productInRow;
                    }
                }

                if (r < grid.GetLength(0) - 3)
                {
                    productInColumn = (long)(grid[r, c] * grid[r + 1, c] * grid[r + 2, c] * grid[r + 3, c]);
                    if (productInColumn > maxProduct)
                    {
                        maxProduct = productInColumn;
                    }
                }

                if (r < grid.GetLength(0) - 3 && c < grid.GetLength(1) - 3)
                {
                    productInDiagonal = (long)(grid[r, c] * grid[r + 1, c + 1] * grid[r + 2, c + 2] * grid[r + 3, c + 3]);
                    if (productInDiagonal > maxProduct)
                    {
                        maxProduct = productInDiagonal;
                    }
                }

                if (r > 2 && c < grid.GetLength(1) - 3)
                {
                    productInDiagonalReversed = (long)(grid[r, c] * grid[r - 1, c + 1] * grid[r - 2, c + 2] * grid[r - 3, c + 3]);
                    if (productInDiagonalReversed > maxProduct)
                    {
                        maxProduct = productInDiagonalReversed;
                    }
                }
            }
        }

        return maxProduct.ToString();
    }
}