using System;

namespace _04_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());

            int failure = 0;
            int average = 0;
            int good = 0;
            int excellent = 0;

            double totalGrades = 0;
            double gpa = 0;

            for (int i = 0; i < students; i++)
            {
                double grade = double.Parse(Console.ReadLine());

                if (grade >= 2 && grade < 3)
                {
                    failure++;
                }
                else if (grade >= 3 && grade < 4)
                {
                    average++;
                }
                else if (grade >= 4 && grade < 5)
                {
                    good++;
                }
                else if (grade >= 5 && grade <= 6)
                {
                    excellent++;
                }
                else
                {
                    Console.WriteLine("incorrect assessment");
                    return;
                }

                totalGrades += grade;
            }

            gpa = totalGrades / students;


            Console.WriteLine("Top students: {0:F2}%", (excellent / (double)students) * 100);
            Console.WriteLine("Between 4.00 and 4.99: {0:F2}%", (good / (double)students) * 100);
            Console.WriteLine("Between 3.00 and 3.99: {0:F2}%", (average / (double)students) * 100);
            Console.WriteLine("Fail: {0:F2}%", (failure / (double)students) * 100);
            Console.WriteLine("Average: {0:F2}", gpa);
        }
    }
}
