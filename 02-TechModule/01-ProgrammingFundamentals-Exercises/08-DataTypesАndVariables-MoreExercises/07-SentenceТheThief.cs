namespace _06_CatchTheThief
{
    using System;

    static class CatchTheThief
    {
        static void Main()
        {
            string numeralType = Console.ReadLine();

            long maxValue = 0L;
            switch (numeralType.ToLower())
            {
                case "sbyte":
                    maxValue = sbyte.MaxValue;
                    break;
                case "int":
                    maxValue = int.MaxValue;
                    break;
                case "long":
                    maxValue = long.MaxValue;
                    break;
            }

            long thiefId = long.MinValue;

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                long currentId = long.Parse(Console.ReadLine());

                if (currentId > thiefId && currentId <= maxValue)
                {
                    thiefId = currentId;
                }
            }

            long durationOfTheSentence;

            if (thiefId > 0)
            {
                durationOfTheSentence = (long)Math.Ceiling(thiefId / (double)sbyte.MaxValue);
            }
            else
            {
                durationOfTheSentence = (long)Math.Ceiling(thiefId / (double)sbyte.MinValue);
            }

            if (durationOfTheSentence > 1)
            {
                Console.WriteLine($"Prisoner with id {thiefId} is sentenced to {durationOfTheSentence} years");
            }
            else
            {
                Console.WriteLine($"Prisoner with id {thiefId} is sentenced to {durationOfTheSentence} year");
            }
        }
    }
}
