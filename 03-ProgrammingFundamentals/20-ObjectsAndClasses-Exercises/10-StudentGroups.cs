using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_StudentGroups
{
    class Program
    {
        static void Main(string[] args)
        {
            var towns = ReadTownsAndStudents();

            var groups = DistributeStudentsIntoGroups(towns);
                    
            Console.WriteLine($"Created {groups.Count} groups in {towns.Count} towns:");
            foreach (var group in groups.OrderBy(g => g.Town.Name))
            {
                Console.WriteLine($"{group.Town.Name} => {string.Join(", ", group.Students.Select(s => s.Email))}");
            }
        }

        private static List<Group> DistributeStudentsIntoGroups(List<Town> towns)
        {
            var groups = new List<Group>();

            foreach (var town in towns)
            {
                IEnumerable<Student> students = town
                    .Students.OrderBy(s => s.RegistrationDate)
                    .ThenBy(s => s.Name)
                    .ThenBy(s => s.Email);

                while(students.Any())
                {
                    var group = new Group();
                    group.Town = town;
                    group.Students = students.Take(group.Town.SeatsCount).ToList();
                    students = students.Skip(group.Town.SeatsCount);
                    groups.Add(group);
                }
            }

            return groups;
        }

        private static List<Town> ReadTownsAndStudents()
        {
            var towns = new List<Town>();

            var inputLine = Console.ReadLine();

            while (inputLine != "End")
            {
                if (inputLine.Contains("=>"))
                {
                    var tokens = inputLine.Split("=>".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    var town = tokens[0].Trim();
                    var labCapacity = int.Parse(tokens[1].Trim().Split()[0]);

                    var currentTown = new Town
                    {
                        Name = town,
                        SeatsCount = labCapacity,
                        Students = new List<Student>()
                    };

                    towns.Add(currentTown);
                }
                else
                {
                    var students = new List<Student>();

                    var tokens = inputLine.Split('|').Select(el => el.Trim()).ToArray();

                    var studentName = tokens[0];
                    var studentEmail = tokens[1];
                    var studentRegDate = DateTime.ParseExact(tokens[2], "d-MMM-yyyy", CultureInfo.InvariantCulture);

                    var currentStudent = new Student
                    {
                        Name = studentName,
                        Email = studentEmail,
                        RegistrationDate = studentRegDate
                    };

                    towns.Last().Students.Add(currentStudent);
                }

                inputLine = Console.ReadLine();
            }

            Console.WriteLine();
            return towns;
        }
    }

    class Student
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime RegistrationDate { get; set; }
    }

    class Town
    {
        public string Name { get; set; }

        public int SeatsCount { get; set; }

        public List<Student> Students { get; set; }
    }

    class Group
    {
        public Town Town { get; set; }

        public List<Student> Students { get; set; }
    }
}
