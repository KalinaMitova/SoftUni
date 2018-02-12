namespace _01_OddLines
{
    using System;
    using System.IO;

    public class OddLines
    {
        public static void Main()
        {
            string filePath = @"..\00_Resources\text.txt";
            using (var stream = new StreamReader(filePath))
            {
                int lineCounter = 0;

                string textLine;
                while ((textLine = stream.ReadLine()) != null)
                {
                    if(lineCounter % 2 == 1)
                    {
                        Console.WriteLine(textLine);
                    }

                    lineCounter++;
                }
            }
        }
    }
}
