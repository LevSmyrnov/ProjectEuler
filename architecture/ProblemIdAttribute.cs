using System;

[AttributeUsage(AttributeTargets.Class)]
public class ProblemIdAttribute : Attribute
{
    private int problemId;

    public int ProblemId { get => problemId; set => problemId = value; }

    public ProblemIdAttribute(int id)
    {
        problemId = id;
    }
}