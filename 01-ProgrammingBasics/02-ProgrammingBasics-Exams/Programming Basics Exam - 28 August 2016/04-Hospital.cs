using System;

namespace _04_Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            int period = int.Parse(Console.ReadLine());
            int doctors = 7;
            int examinedPatients = 0;
            int notExaminedPatients = 0;

            for (int i = 1; i <= period; i++)
            {
                if (i % 3 == 0)
                {
                    if (examinedPatients < notExaminedPatients)
                    {
                        doctors++;
                    }
                }

                int numOfPatients = int.Parse(Console.ReadLine());
                if (doctors - numOfPatients >= 0)
                {
                    examinedPatients += numOfPatients;
                }
                else
                {
                    notExaminedPatients += numOfPatients - doctors;
                    examinedPatients += doctors;
                }                
            }

            Console.WriteLine("Treated patients: {0}.", examinedPatients);
            Console.WriteLine("Untreated patients: {0}.", notExaminedPatients);
        }
    }
}
