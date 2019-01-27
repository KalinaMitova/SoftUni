namespace _04_Everest
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int baseCampHeight = 5364;
            int mountaintop = 8848;

            int days = 1;

            while (true)
            {
                string isRest = Console.ReadLine();
                if(isRest == "END")
                {
                    break;
                }
                else if (isRest == "Yes")
                {
                    days++;
                    if(days > 5)
                    {
                        break;
                    }
                }

                int currentClimbedHeight = int.Parse(Console.ReadLine());
                baseCampHeight += currentClimbedHeight;

                if(baseCampHeight >= mountaintop)
                {
                    break;
                }
            }

            if(baseCampHeight >= mountaintop)
            {
                Console.WriteLine($"Goal reached for {days} days!");
            }
            else
            {
                Console.WriteLine("Failed!");
                Console.WriteLine(baseCampHeight);
            }
        }
    }
}
