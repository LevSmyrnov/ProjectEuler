using System;
using Internal;

[ProblemId(2), ProblemTitle("Even Fibonacci Numbers")]
public class Problem2 : Problem
{
    private double phi = (1 + Math.Sqrt(5)) / 2;
    private double psi = (1 - Math.Sqrt(5)) / 2;

    protected override string Solve(string input)
    {
        if (!int.TryParse(input, out int limit))
        {
            return "input invalid";
        }
        else
        {
            var n = (int)((Math.Log(limit) + 0.5 * Math.Log(5)) / (Math.Log(phi)));

            int sum = 0;
            while (n > 1)
            {
                var fib = CalculateNthFibonacciNumber(n);
                if (fib % 2 == 0)
                {
                    sum += fib;
                }
                n--;
            }

            return sum.ToString();
        }
    }

    private int CalculateNthFibonacciNumber(int n)
    {
        return (int)((Math.Pow(phi, n) - Math.Pow(psi, n)) / Math.Sqrt(5));
    }
}