using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_AverageGrades
{
    class Program
    {
        class Student
        {
            public string Name { get; set; }
            public List<double> Grades { get; set; }
            public double AverageGrade
            {
                get
                {
                    return Grades.Average();
                }
            }
        }
        static void Main(string[] args)
        {
            List<Student> students = ReadStudents();

            foreach (var student in students.OrderBy(el => el.Name).ThenByDescending(el => el.AverageGrade))
            {
                if (student.AverageGrade >= 5.0)
                {
                    Console.WriteLine($"{student.Name} -> {student.AverageGrade:F2}");
                }
            }
        }

        private static List<Student> ReadStudents()
        {
            int n = int.Parse(Console.ReadLine());

            var students = new List<Student>(n);

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split().ToList();

                var name = line.First();
                var grades = line.Skip(1).Take(line.Count - 1).Select(double.Parse).ToList();

                students.Add(new Student { Name = name, Grades = grades });
            }

            return students;
        }
    }
}
