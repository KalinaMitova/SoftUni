namespace BashSoftProgram.Repository.Contracts
{
    using System.Collections.Generic;

    using BashSoftProgram.DataStructures.Contracts;
    using BashSoftProgram.Models.Contracts;

    public interface IRequester
    {
        void GetStudentScoresFromCourse(string courseName, string userName);

        void GetAllStudentsFromCourse(string courseName);

        ISimpleOrderedBag<ICourse> GetAllCoursesSorted(IComparer<ICourse> cmp);

        ISimpleOrderedBag<IStudent> GetAllStudentsSorted(IComparer<IStudent> cmp);
    }
}
