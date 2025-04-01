using System;

[ProblemId(9), ProblemTitle("Special Pythagorean Triplet")]
public class Problem9 : Problem
{
    protected override string Solve(string input)
    {
        if (!int.TryParse(input, out int sidesSum))
        {
            return "input invalid";
        }
        else
        {
            var sides = new int[3];
            if (TryEuclidFormula(sidesSum, ref sides))
            {
                var sidesProduct = sides[0] * sides[1] * sides[2];
                return sidesProduct.ToString();
            }

            return "Euclid formula failed to generate pythagorean triplet from triangle perimeter D:";
        }
    }

    private bool TryEuclidFormula(int sum, ref int[] sides)
    {
        int a, b, c;
        double m;
        int n = 1;

        while (n < Math.Sqrt(sum / 2))
        {
            m = (Math.Sqrt(Math.Pow(n, 2) + 2 * sum) - n) / 2;
            if (!IsInteger(m) || m <= n)
            {
                n += 1;
                continue;
            }

            a = (int)(Math.Pow(m, 2) - Math.Pow(n, 2));
            b = (int)(2 * m * n);
            c = (int)(Math.Pow(m, 2) + Math.Pow(n, 2));

            if (Math.Pow(c, 2) == Math.Pow(a, 2) + Math.Pow(b, 2))
            {
                sides[0] = a;
                sides[1] = b;
                sides[2] = c;
                return true;
            }

            n += 1;
        }
        return false;
    }

    private bool IsInteger(double x) => (x % 1) <= (Double.Epsilon * 100);
}