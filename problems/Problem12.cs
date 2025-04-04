using System;
using System.Collections.Generic;

[ProblemId(12), ProblemTitle("Highly Divisible Triangular Number")]
public class Problem12 : Problem
{
    private List<long> primes = new ();

    protected override string Solve(string input)
    {
        if (!int.TryParse(input, out int numberOfDivisors))
        {
            return "input invalid";
        }
        else
        {
            Sieve();

            var divisorsCount = 0;
            long number = 0, i = 0;
            while(divisorsCount <= 500)
            {
                number = GetTriangleNumber(i);
                divisorsCount = GetDivisorsCount(number);
                i++;
            }
            return number.ToString();
        }
    }

    private void Sieve()
    {
        bool[] composite = new bool[1000000];
        for (var i = 2; i < 1000000; i++)
        {
            if (!composite[i])
            {
                primes.Add(i);
                for (var j = i; j < 1000000; j += i)
                {
                    composite[j] = true;
                }
            }
        }
    }

    private int GetDivisorsCount(long n)
    {
        var initial_n = n;
        var factors = 1;

        for (int i = 0; primes[i] * primes[i] <= n; i++)
        {
            var powers = 0;
            while (initial_n % primes[i] == 0)
            {
                powers++;
                initial_n /= primes[i];
            }
            factors *= (powers + 1);            
        }

        if (initial_n > 1)
        {
            factors *= 2;
        }

        return factors;
    }

    private long GetTriangleNumber(long i)
    {
        return i * (i + 1) / 2;
    }
}