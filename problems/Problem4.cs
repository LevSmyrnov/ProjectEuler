using System;

[ProblemId(4), ProblemTitle("Largest Palindrome Product")]
public class Problem4 : Problem
{
    protected override string Solve(string input)
    {
        if (!int.TryParse(input, out int n))
        {
            return "input invalid";
        }
        else
        {
            var maxPalindrome = 0;
            for (int i = (int)Math.Pow(10, n-1), k=0; i < (int)Math.Pow(10, n); i++, k++)
            {
                for (int j = (int)Math.Pow(10, n-1) + k; j < (int)Math.Pow(10, n); j++)
                {
                    var product = i*j;
                    if (IsPalindrome(product) && product > maxPalindrome)
                    {
                        maxPalindrome = product;
                    }
                }
            }
            return maxPalindrome.ToString();
        }
    }

    private bool IsPalindrome(int n)
    {
        if (n % 10 == 0)
        {
            return false;
        }

        var stringN = n.ToString();
        for (int i = 0; i < stringN.Length / 2; i++)
        {
            if (stringN[i] != stringN[stringN.Length - 1 - i])
            {
                return false;
            }
        }
        
        return true;
    }
}