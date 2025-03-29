using System;

[ProblemId(3), ProblemTitle("Largest Prime Factor")]
public class Problem3 : Problem
{
    protected override string Solve(string input)
    {
        if (!long.TryParse(input, out long n))
        {
            return "input invalid";
        }
        else
        {
            var maxFactor = (long)Math.Sqrt(n);
            while (maxFactor > 0)
            {
                if (n % maxFactor != 0)
                {
                    maxFactor--;
                    continue;
                }

                if (IsPrime(maxFactor))
                {
                    return maxFactor.ToString();
                }

                maxFactor--;
            }
            return "1";
        }
    }

    private bool IsPrime(long n)
    {
        if (n % 2 == 0 || n % 3 == 0)
        {
            return false;
        }

        for (var i = 5; i < Math.Sqrt(n); i++)
        {
            if (i % 6 != 1 && i % 6 != 5)
            {
                continue;
            }

            if (n % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}