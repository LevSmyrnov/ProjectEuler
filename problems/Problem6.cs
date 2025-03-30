using System;

[ProblemId(6), ProblemTitle("Sum Square Difference")]
public class Problem6 : Problem
{
    protected override string Solve(string input)
    {
        if (!int.TryParse(input, out int n))
        {
            return "input invalid";
        }
        else
        {
            var res = Math.Pow(SumOfNaturalNumbersSequence(n), 2) - SumOfSquaresOfNNaturalNumbers(n);
            return res.ToString();
        }
    }

    private int SumOfSquaresOfNNaturalNumbers(int n)
    {
        return n * (n + 1) * (2 * n + 1) / 6;
    }
    
    private int SumOfNaturalNumbersSequence(int n)
    {
        return n * (n + 1) / 2;
    }
}