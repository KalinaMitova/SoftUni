using System;

namespace _04.TrainersSalary
{
    class Program
    {
        static void Main(string[] args)
        {
            int lectures = int.Parse(Console.ReadLine());
            double budged = double.Parse(Console.ReadLine());

            int jelevLectures = 0;
            int royalLectures = 0;
            int roliLectures = 0;
            int trifonLectures = 0;
            int sinoLectures = 0;
            int others = 0;

            double sumPerLecture = budged / lectures;

            for (int i = 1; i <= lectures; i++)
            {
                string trainer = Console.ReadLine();

                switch (trainer)
                {
                    case "Jelev":
                        jelevLectures++;
                        break;
                    case "RoYaL":
                        royalLectures++;
                        break;
                    case "Roli":
                        roliLectures++;
                        break;
                    case "Trofon":
                        trifonLectures++;
                        break;
                    case "Sino":
                        sinoLectures++;
                        break;
                    default:
                        others++;
                        break;
                }
            }

            Console.WriteLine("Jelev salary: {0:F2} lv", jelevLectures * sumPerLecture);
            Console.WriteLine("RoYaL salary: {0:F2} lv", royalLectures * sumPerLecture);
            Console.WriteLine("Roli salary: {0:F2} lv", roliLectures * sumPerLecture);
            Console.WriteLine("Trofon salary: {0:F2} lv", trifonLectures * sumPerLecture);
            Console.WriteLine("Sino salary: {0:F2} lv", sinoLectures * sumPerLecture);
            Console.WriteLine("Others salary: {0:F2} lv", others * sumPerLecture);
        }
    }
}
