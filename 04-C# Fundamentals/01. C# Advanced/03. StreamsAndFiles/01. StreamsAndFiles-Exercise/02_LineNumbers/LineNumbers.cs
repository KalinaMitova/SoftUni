namespace _02_LineNumbers
{
    using System.IO;

    public class LineNumbers
    {
        public static void Main()
        {
            string fileReadPath = @"..\00_Resources\text.txt";
            string fileWritePath = @"..\00_OutputFiles\LineNumbers.txt";

            using (var streamReader = new StreamReader(fileReadPath))
            {
                using (var streamWriter = new StreamWriter(fileWritePath))
                {
                    int lineCounter = 1;
                    string textLine;
                    while ((textLine = streamReader.ReadLine()) != null)
                    {
                        streamWriter.WriteLine($"Line {lineCounter}: {textLine}");
                        lineCounter++;
                    }
                }
            }
        }
    }
}
