using System;
using System.Collections.Generic;
using System.Linq;

[ProblemId(10), ProblemTitle("Summation of Primes")]
public class Problem10 : Problem
{
    protected override string Solve(string input)
    {
        if (!long.TryParse(input, out long primeUpperBound))
        {
            return "input invalid";
        }
        else
        {
            long sum = 5;
            long candidate = 1;
            long k = 1;
            while (candidate < primeUpperBound)
            {
                candidate = 6 * k - 1;
                if (IsPrime(candidate) && candidate < primeUpperBound)
                {
                    sum += candidate;
                }
                candidate = 6 * k + 1;
                if (IsPrime(candidate) && candidate < primeUpperBound)
                {
                    sum += candidate;
                }
                k += 1;
            }

            return sum.ToString();
        }
    }

    private bool IsPrime(long n)
    {
        if (n == 2 || n == 3)
        {
            return true;
        }

        if (n % 6 != 1 && n % 6 != 5)
        {
            return false;
        }

        for (var i = 5; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}