using System;
using System.Collections.Generic;
using System.Linq;

[ProblemId(7), ProblemTitle("10 001st Prime")]
public class Problem7 : Problem
{
    protected override string Solve(string input)
    {
        if (!long.TryParse(input, out long n))
        {
            return "input invalid";
        }
        else
        {
            if (n >= 6 && n <= 1000000)
            {
                long upperBound = (long)(n * Math.Log(n) + n * Math.Log(Math.Log(n)));
                List<long> allNumbers = (new long[upperBound]).ToList();
                allNumbers[0] = 1;
                for (var i = 1; i < allNumbers.Count; i++)
                {
                    allNumbers[i] = allNumbers[i-1] + 1;
                }

                SieveOfEratosthenes(allNumbers);
                var primeNumbers = new LinkedList<long>(allNumbers);
                while(primeNumbers.Contains(0))
                {
                    primeNumbers.Remove(0);
                }

                allNumbers = new List<long>(primeNumbers);
                return allNumbers[(int)n].ToString();
            }
            return "this method is inappropriate to find nth prime";
        }
    }

    private void SieveOfEratosthenes(List<long> numbers)
    {
        for (var i = 1; i < Math.Sqrt(numbers.Count); i++)
        {
            if (numbers[i] == 0)
            {
                continue;
            }

            for (var j = i + 1; j < numbers.Count; j++)
            {
                if (numbers[j] == 0)
                {
                    continue;
                }
                if (numbers[j] % numbers[i] == 0)
                {
                    numbers[j] = 0;
                }
            }
        }
    }
}