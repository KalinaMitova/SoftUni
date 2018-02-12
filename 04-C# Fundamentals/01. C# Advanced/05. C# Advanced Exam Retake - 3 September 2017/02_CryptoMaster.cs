namespace _02_CryptoMaster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CryptoMaster
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int longestSequence = 1;
            int counter = 1;
            int startNum;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int step = 1; step <= numbers.Length; step++)
                {
                    startNum = numbers[i];
                    int currentStep = (i + step) % numbers.Length;
                    int nextNum = numbers[currentStep];
                    while (startNum < nextNum)
                    {
                        startNum = nextNum;
                        currentStep = (currentStep + step) % numbers.Length;
                        nextNum = numbers[currentStep];
                        counter++;
                        if (counter > longestSequence)
                        {
                            longestSequence = counter;
                        }
                    }
                    counter = 1;
                }
            }
            
            Console.WriteLine(longestSequence);
        }
    }
}
