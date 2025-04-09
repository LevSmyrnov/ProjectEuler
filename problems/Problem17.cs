using System;
using System.Collections.Generic;

[ProblemId(17), ProblemTitle("Number Letter Counts")]
public class Problem17 : Problem
{
    private static readonly Dictionary<int, int> LettersInNumber = new Dictionary<int, int>() {
        {0, 0},
        {1, 3},
        {2, 3},
        {3, 5},
        {4, 4},
        {5, 4},
        {6, 3},
        {7, 5},
        {8, 5},
        {9, 4},
        {10, 3},
        {11, 6},
        {12, 6},
        {13, 8},
        {14, 8},
        {15, 7},
        {16, 7},
        {17, 9},
        {18, 8},
        {19, 8},
        {20, 6},
        {30, 6},
        {40, 5},
        {50, 5},
        {60, 5},
        {70, 7},
        {80, 6},
        {90, 6},
        {100, 7},
        {1000, 11}
    };
    protected override string Solve(string input)
    {
        if (!int.TryParse(input, out int n))
        {
            return "input invalid";
        }
        else
        {
            if (n > 9999)
            {
                return "method only works for numbers up to 1000";
            }
            var lettersSum = 0;
            for (var i = 1; i <= n; i++)
            {
                if (i == 1000)
                {
                    lettersSum += LettersInNumber[i];
                    continue;
                }
                if (i / 100 > 0)
                {
                    lettersSum += LettersInNumber[i / 100] + LettersInNumber[100] + (i % 100 == 0 ? 0 : 3);
                }
                if (i % 100 < 21)
                {
                    lettersSum += LettersInNumber[i % 100];
                } else {
                    lettersSum += LettersInNumber[((i % 100) / 10) * 10] + LettersInNumber[i % 10];
                }
            }
            return lettersSum.ToString();
        }
    }
}