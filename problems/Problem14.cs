using System;
using Internal;

[ProblemId(14), ProblemTitle("Longest Collatz Sequence")]
public class Problem14 : Problem
{
    protected override string Solve(string input)
    {
        if (!int.TryParse(input, out int maxN))
        {
            return "input invalid";
        }
        else
        {
            var stepsForNumbersTillN = new int[maxN];

            for (int i = 2; i < stepsForNumbersTillN.Length; i++)
            {
                stepsForNumbersTillN[i] = Steps(i, stepsForNumbersTillN);
            }

            int max = 0, maxIndex = 2;
            for (int i = 2; i < stepsForNumbersTillN.Length; i++)
            {
                if (stepsForNumbersTillN[i] > max)
                {
                    max = stepsForNumbersTillN[i];
                    maxIndex = i;
                }
            }
            return maxIndex.ToString();
        }
    }

    private int Steps(int n, int[] stepsForNumbers)
    {
        var initial_n = n;
        var steps = 0;
        long nLong = n;
        while (nLong > 1)
        {
            if (nLong % 2 == 0)
            {
                nLong /= 2;
                steps++;
            }
            else
            {
                nLong = nLong * 3 + 1;
                steps++;
            }
            if (nLong < initial_n)
            {
                try
                {
                    steps += stepsForNumbers[nLong];
                }
                catch (System.Exception)
                {
                    Console.WriteLine($"Probably, at some step, n has overflown the LONG format:\nn: {nLong}, initial_n: {initial_n}");
                    throw;
                }
                break;
            }
        }

        return steps;
    }
}