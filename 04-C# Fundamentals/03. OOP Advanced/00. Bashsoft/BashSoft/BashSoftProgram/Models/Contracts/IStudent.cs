namespace BashSoftProgram.Models.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IStudent : IComparable<IStudent>
    {
        string Username { get; }

        IReadOnlyDictionary<string, double> MarksByCourseName { get; }

        IReadOnlyDictionary<string, ICourse> EnrolledCourses { get; }

        void EnrollInCourse(ICourse course);

        void SetMarkOnCourse(string courseName, params int[] scores);
    }
}
