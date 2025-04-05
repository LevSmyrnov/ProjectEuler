using System;
using System.Text;

[ProblemId(13), ProblemTitle("Large Sum")]
public class Problem13 : Problem
{
    protected override string Solve(string input)
    {
        var numbers = input.Split('\n');
        var result = new StringBuilder();
        var overflow = 0;
        for (int i = numbers[0].Length - 1; i >= 0 ; i--)
        {
            foreach (var number in numbers)
            {
                overflow += int.Parse(number[i].ToString());
            }
            result.Insert(0, overflow % 10);
            overflow /= 10;
        }
        result.Insert(0, overflow);

        return result.ToString().Substring(0, 10);
    }
}