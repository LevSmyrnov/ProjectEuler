using System;
using System.Linq;
using System.Collections.Generic;
using Internal;

[ProblemId(21), ProblemTitle("Amicable Numbers")]
public class Problem21 : Problem
{
    private List<int> primes = new();

    protected override string Solve(string input)
    {
        if (!int.TryParse(input, out int numberLimit))
        {
            return "input invalid";
        }
        else
        {
            Sieve(numberLimit);
            var candidates = new List<bool?>(numberLimit * 2);
            for (int i = 0; i <= numberLimit; i++)
            {
                candidates.Add(null);
            }

            for (var i = 10; i <= numberLimit; i++)
            {
                if (candidates.ElementAtOrDefault(i) != null)
                {
                    continue;
                }
                var sumOfDivisors = SumOfDivisors(i);
                if (sumOfDivisors == 1)
                {
                    continue;
                }
                var pairSumOfDivisors = SumOfDivisors(sumOfDivisors);
                while (pairSumOfDivisors >= candidates.Count)
                {
                    candidates.Add(null);
                }
                candidates[sumOfDivisors] = sumOfDivisors == pairSumOfDivisors;
                candidates[pairSumOfDivisors] = sumOfDivisors == pairSumOfDivisors;
            }

            var sumOfAmicableNumbers = 0;
            for (int i = 0; i < candidates.Count; i++)
            {
                if (candidates[i] ?? false)
                {
        Console.WriteLine(i);

                    sumOfAmicableNumbers += i;
                }
            }
            return sumOfAmicableNumbers.ToString();
        }
    }

    private int SumOfDivisors(int n)
    {
        var sumOfDivisors = 1;
        foreach (var factor in PrimeFactors(n))
        {
            sumOfDivisors *= (int)((Math.Pow(factor.Key, factor.Value + 1) - 1) / (factor.Key - 1));
        }
        if (sumOfDivisors == 1)
        {
            return sumOfDivisors;
        }
        sumOfDivisors -= n;
        return sumOfDivisors;
    }

    private Dictionary<int, int> PrimeFactors(int n)
    {
        if (primes.Contains(n))
        {
            return new Dictionary<int, int>();
        }
        Dictionary<int, int> factors = new Dictionary<int, int>();
        var initial_n = n;
        for (var i = 0; primes[i] <= n / 2; i++)
        {
            while (initial_n % primes[i] == 0)
            {
                initial_n /= primes[i];
                if (factors.ContainsKey(primes[i]))
                {
                    factors[primes[i]] += 1;
                }
                else
                {
                    factors.Add(primes[i], 1);
                }
            }
        }
        return factors;
    }

    private void Sieve(int numberLimit)
    {
        bool[] composite = new bool[numberLimit];
        for (var i = 2; i < numberLimit; i++)
        {
            if (!composite[i])
            {
                primes.Add(i);
                for (var j = i; j < numberLimit; j += i)
                {
                    composite[j] = true;
                }
            }
        }
    }
}