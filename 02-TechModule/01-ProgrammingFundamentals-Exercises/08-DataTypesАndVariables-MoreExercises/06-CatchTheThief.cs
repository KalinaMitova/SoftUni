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
            Console.WriteLine(thiefId);
        }
    }
}
