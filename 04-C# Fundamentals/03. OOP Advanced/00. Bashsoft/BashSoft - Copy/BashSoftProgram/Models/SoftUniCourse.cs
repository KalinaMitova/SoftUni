namespace BashSoftProgram.Models
{
    using System.Collections.Generic;

    using BashSoftProgram.Exceptions;
    using BashSoftProgram.Models.Contracts;

    public class SoftUniCourse : ICourse
    {
        public const int NumberOfTasksOnExam = 5;
        public const int MaxScoreOnExamTask = 100;

        private string name;
        private Dictionary<string, IStudent> studentsByName;

        public SoftUniCourse(string name)
        {
            Name = name;
            studentsByName = new Dictionary<string, IStudent>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }
                name = value;
            }
        }
        public IReadOnlyDictionary<string, IStudent> StudentsByName
        {
            get { return studentsByName; }
        }

        public void EnrollStudent(IStudent student)
        {
            if (studentsByName.ContainsKey(student.Username))
            {
                throw new DuplicateEntryInStructureException(student.Username, Name);
            }

            studentsByName.Add(student.Username, student);
        }

        public int CompareTo(ICourse other) => this.Name.CompareTo(other.Name);

        public override string ToString() => this.Name;
    }
}
