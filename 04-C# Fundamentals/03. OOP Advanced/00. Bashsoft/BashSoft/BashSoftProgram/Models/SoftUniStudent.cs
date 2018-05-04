namespace BashSoftProgram.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using BashSoftProgram.Exceptions;
    using BashSoftProgram.Models.Contracts;

    public class SoftUniStudent : IStudent
    {
        private string username;
        private Dictionary<string, ICourse> enrolledCourses;
        private Dictionary<string, double> marksByCourseName;

        public SoftUniStudent(string username)
        {
            Username = username;
            enrolledCourses = new Dictionary<string, ICourse>();
            marksByCourseName = new Dictionary<string, double>();
        }

        public IReadOnlyDictionary<string, double> MarksByCourseName
        {
            get { return marksByCourseName; }
        }

        public IReadOnlyDictionary<string, ICourse> EnrolledCourses
        {
            get { return enrolledCourses; }
        }

        public string Username
        {
            get { return username; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }
                username = value;
            }
        }

        public void EnrollInCourse(ICourse course)
        {
            if (EnrolledCourses.ContainsKey(course.Name))
            {
                throw new DuplicateEntryInStructureException(Username, course.Name);
            }

            enrolledCourses.Add(course.Name, course);
        }

        public void SetMarkOnCourse(string courseName, params int[] scores)
        {
            if (!enrolledCourses.ContainsKey(courseName))
            {
                throw new CourseNotFoundException();
            }

            if (scores.Length > SoftUniCourse.NumberOfTasksOnExam)
            {
                throw new ArgumentOutOfRangeException(ExceptionMessages.InvalidNumberOfScores);
            }
            marksByCourseName.Add(courseName, CalculateMark(scores));
        }

        private double CalculateMark(int[] scores)
        {
            double percentageOfSolvedExam = scores.Sum() / (double)(SoftUniCourse.NumberOfTasksOnExam * SoftUniCourse.MaxScoreOnExamTask);

            double mark = percentageOfSolvedExam * 4 + 2;
            return mark;
        }

        public int CompareTo(IStudent other) => this.Username.CompareTo(other.Username);

        public override string ToString() => this.Username;
    }
}

