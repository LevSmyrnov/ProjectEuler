using System;
using System.Collections.Generic;
using System.Linq;

[ProblemId(20), ProblemTitle("Factorial Digit Sum")]
public class Problem20 : Problem
{
    protected override string Solve(string input)
    {
        if (!int.TryParse(input, out int number) || number > 1000)
        {
            return "input invalid or number too big (over 1000)";
        }
        else
        {
            var digitsArray = new List<int>(FactorialDigitNumber(number) + 1) {1};
            for (var factor = 2; factor <= number; factor++)
            {
                MultiplyListNumberBy(digitsArray, factor);
            }
            return digitsArray.Sum(x => x).ToString();
        }
    }

    private void MultiplyListNumberBy(List<int> listNumber, int multiplier)
    {
        int carry = 0;
        for (var i = 0; i < listNumber.Count || carry > 0; i++)
        {
            if (i == listNumber.Count)
            {
                listNumber.Add(0);
            }

            var product = listNumber[i] * multiplier + carry;
            listNumber[i] = product % 10;
            carry = product / 10;
        }
    }

    private int FactorialDigitNumber(int n)
    {
        double logSum = 0;
        for (var i = 1; i <= n; i++)
        {
            logSum += Math.Log10(i);
        }
        return (int)logSum + 1;
    }
}