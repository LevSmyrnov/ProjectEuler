using System.Threading.Tasks;
using System;
using Internal;

[ProblemId(1), ProblemTitle("Multiples of 3 or 5 below N")]
public class Problem1 : Problem
{
    protected override string Solve(string input)
    {
        if (!int.TryParse(input, out int n))
        {
            return "input invalid";
        }
        else
        {
            n -= 1;
            var divisorBy3 = n / 3;
            var sumOfMultiplesOf3InN = SumOfNaturalNumbers(divisorBy3);

            var divisorBy5 = n / 5;
            var sumOfMultiplesOf5InN = SumOfNaturalNumbers(divisorBy5);

            var divisorBy15 = n / 15;
            var sumOfMultiplesOf15InN = SumOfNaturalNumbers(divisorBy15);

            return (sumOfMultiplesOf3InN * 3 + sumOfMultiplesOf5InN * 5 - sumOfMultiplesOf15InN * 15).ToString();
        }
    }

    private int SumOfNaturalNumbers(int n)
    {
        return n * (n + 1) / 2;
    }
}