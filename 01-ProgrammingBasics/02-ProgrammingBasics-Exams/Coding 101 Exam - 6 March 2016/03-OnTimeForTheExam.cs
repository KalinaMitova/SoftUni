using System;

namespace _03_OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHours = Convert.ToInt32(Console.ReadLine());
            int examMinutes = Convert.ToInt32(Console.ReadLine());

            int arrivalHours = Convert.ToInt32(Console.ReadLine());
            int arrivalMinutes = Convert.ToInt32(Console.ReadLine());

            int examTotalMinutes = (examHours * 60) + examMinutes;
            int arrivalTotalMinutes = (arrivalHours * 60) + arrivalMinutes;

            int timeDifference = examTotalMinutes - arrivalTotalMinutes;
            string minutes = "";

            if (Math.Abs(timeDifference) % 60 < 10)
            {
                minutes = "0" + Math.Abs(timeDifference) % 60;
            }
            else
            {
                minutes = "" + Math.Abs(timeDifference) % 60;
            }

            if (timeDifference < 0)
            {
                Console.WriteLine("Late");

                if (timeDifference > -60)
                {
                    Console.WriteLine("{0} minutes after the start", Math.Abs(timeDifference));
                }
                else
                {
                    Console.WriteLine("{0}:{1} hours after the start", Math.Abs(timeDifference) / 60, minutes);
                }
            }
            else if (timeDifference <= 30)
            {
                Console.WriteLine("On time");
                Console.WriteLine("{0} minutes before the start", Math.Abs(timeDifference));
            }
            else
            {
                Console.WriteLine("Early");
                if (timeDifference < 60)
                {
                    Console.WriteLine("{0} minutes before the start", Math.Abs(timeDifference));
                }
                else
                {
                    Console.WriteLine("{0}:{1} hours before the start", Math.Abs(timeDifference) / 60, minutes);
                }
            }
        }
    }
}
