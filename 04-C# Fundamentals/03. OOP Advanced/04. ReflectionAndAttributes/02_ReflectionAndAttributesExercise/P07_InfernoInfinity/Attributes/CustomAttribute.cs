using System;

[AttributeUsage(AttributeTargets.Class)]
public class CustomAttribute : Attribute
{
    public string Author { get; set; }

    public int Revision { get; set; }

    public string Description { get; set; }

    public string[] Reviewers { get; set; }
}
