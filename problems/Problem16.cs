using System;
using System.Collections.Generic;
using System.Linq;

[ProblemId(16), ProblemTitle("Power Digit Sum")]
public class Problem16 : Problem
{
    protected override string Solve(string input)
    {
        if (!int.TryParse(input, out int power))
        {
            return "input invalid";
        }
        else
        {
            var numberOfDigits = (int) Math.Round(power * Math.Log10(2));
            var number = new List<int>(numberOfDigits){1};
            short carry = 0;
            for (var i = 1; i <= power; i++)
            {
                for (int digit = 0; digit < number.Count; digit++)
                {
                    var prod = number[digit] * 2 + carry;
                    number[digit] = (short) (prod % 10);
                    carry = (short) (prod / 10);
                }
                if (carry > 0)
                {
                    number.Add(carry);
                }
                carry = 0;
            }
            return number.Sum(x => x).ToString();
        }
    }
}