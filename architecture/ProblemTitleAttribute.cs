using System;

[AttributeUsage(AttributeTargets.Class)]
public class ProblemTitleAttribute : Attribute
{
    private string title;

    public string Title { get => title; set => title = value; }

    public ProblemTitleAttribute(string title)
    {
        this.title = title;
    }
}