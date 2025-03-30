using System;
using System.Collections.Generic;
using System.Linq;

[ProblemId(5), ProblemTitle("Smallest Multiple")]
public class Problem5 : Problem
{
    protected override string Solve(string input)
    {
        if (!long.TryParse(input, out long n))
        {
            return "input invalid";
        }
        else
        {
            var resPrimeFactorisation = new Dictionary<long, long>();
            for (long i = 2; i <= n; i++)
            {
                if (IsPrime(i))
                {
                    resPrimeFactorisation.Add(i, 1);
                    continue;
                }

                var iCopy = i;
                var iCopyPrimeFactorisation = new Dictionary<long, long>();
                while (iCopy > 1)
                {
                    foreach (var item in resPrimeFactorisation)
                    {
                        if (iCopy % item.Key == 0)
                        {
                            iCopy /= item.Key;
                            if (iCopyPrimeFactorisation.ContainsKey(item.Key))
                            {
                                iCopyPrimeFactorisation[item.Key]++;
                            }
                            else
                            {
                                iCopyPrimeFactorisation.Add(item.Key, 1);
                            }
                            continue;
                        }
                    }
                }

                foreach (var item in iCopyPrimeFactorisation)
                {
                    if (resPrimeFactorisation[item.Key] < item.Value)
                    {
                        resPrimeFactorisation[item.Key] = item.Value;
                    }
                }
            }

            long res = 1;
            foreach (var item in resPrimeFactorisation)
            {
                res *= (long) Math.Pow(item.Key, item.Value);
            }

            return res.ToString();
        }
    }

    private bool IsPrime(long n)
    {
        if (n == 2 || n == 3)
        {
            return true;
        }

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