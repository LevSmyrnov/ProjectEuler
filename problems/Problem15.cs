using System;

[ProblemId(15), ProblemTitle("Lattice Paths")]
public class Problem15 : Problem
{
    protected override string Solve(string input)
    {
        if (!uint.TryParse(input, out uint gridSize))
        {
            return "input invalid";
        }
        else
        {
            var res = CalculateCombinations(gridSize, gridSize * 2);
            return res.ToString();
        }
    }

    private ulong CalculateCombinations(uint k, uint n)
    {
        ulong res = 1;
        for (uint i = 1; i <= k; i++)
        {
            res = res * (n - k + i) / i;
        }
        return res;
    }
}