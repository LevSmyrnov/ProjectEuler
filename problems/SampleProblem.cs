using System.Threading.Tasks;
using System;

[ProblemId(0), ProblemTitle("Copy from input to output")]
public class SampleProblem : Problem
{
    protected override string Solve(string input)
    {
        Console.WriteLine("Problem 0");
        return input;
    }
}