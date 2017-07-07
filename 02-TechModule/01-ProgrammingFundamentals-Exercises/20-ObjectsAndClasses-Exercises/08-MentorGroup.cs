using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _08_MentorGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentsAttendance = GetStudentsAttendance();

            var studentsComments = GetStudentsComments(studentsAttendance);

            var students = GetStudentsList(studentsAttendance, studentsComments);

            PrintStudents(students);
        }

        private static void PrintStudents(List<Student> students)
        {
            foreach (var student in students.OrderBy(s => s.Name))
            {
                Console.WriteLine(student.Name);
                Console.WriteLine("Comments:");

                foreach (var comment in student.Comments)
                {
                    Console.WriteLine($"- {comment}");
                }

                Console.WriteLine("Dates attended:");

                foreach (var attendance in student.Attendance.OrderBy(d => d))
                {
                    Console.WriteLine($"-- {attendance:dd/MM/yyyy}");
                }
            }
        }

        private static List<Student> GetStudentsList(Dictionary<string, List<DateTime>> studentsAttendance, Dictionary<string, List<string>> studentsComments)
        {
            var students = new List<Student>();

            foreach (var studentDates in studentsAttendance)
            {
                var student = new Student
                {
                    Name = studentDates.Key,
                    Attendance = studentDates.Value,
                    Comments = studentsComments.ContainsKey(studentDates.Key) ? studentsComments[studentDates.Key] : new List<string>()
                };

                students.Add(student);
            }

            return students;
        }

        private static Dictionary<string, List<string>> GetStudentsComments(Dictionary<string, List<DateTime>> studentsAttendance)
        {
            var studentsComments = new Dictionary<string, List<string>>();

            var studentComments = Console.ReadLine();
            while (studentComments != "end of comments")
            {
                var tokens = studentComments.Split('-');
                var studentName = tokens[0];
                var comment = tokens[1];

                if (studentsAttendance.ContainsKey(studentName) && !(studentsComments.ContainsKey(studentName)))
                {
                    studentsComments[studentName] = new List<string>();
                }

                if (studentsAttendance.ContainsKey(studentName))
                {
                    studentsComments[studentName].Add(comment);
                }

                studentComments = Console.ReadLine();
            }

            return studentsComments;
        }

        private static Dictionary<string, List<DateTime>> GetStudentsAttendance()
        {
            var studentsAttendance = new Dictionary<string, List<DateTime>>();

            var studentsDates = Console.ReadLine();
            while (studentsDates != "end of dates")
            {
                var tokens = studentsDates.Split();
                var studentName = tokens[0];

                var dates = new List<DateTime>();

                if (tokens.Length > 1)
                {
                    dates = tokens[1].Split(',').Select(date => DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture)).ToList();
                }

                if (!studentsAttendance.ContainsKey(studentName))
                {
                    studentsAttendance[studentName] = new List<DateTime>();
                }

                studentsAttendance[studentName].AddRange(dates);

                studentsDates = Console.ReadLine();
            }

            return studentsAttendance;
        }
    }

    class Student
    {
        public string Name { get; set; }
        public List<DateTime> Attendance { get; set; }
        public List<string> Comments { get; set; }
    }
}
