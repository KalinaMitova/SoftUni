namespace _01_Regeh
{
    using System;
    using System.Text.RegularExpressions;

    class Regeh
    {
        static void Main()
        {
            string line = Console.ReadLine();

            string pattern = @"\[[^\[\]\s]+<(?<a>\d+)REGEH(?<b>\d+)>[^\[\]\s]+\]";
            var regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(line);

            string output = string.Empty;

            int baseIndex = 0;

            foreach (Match match in matches)
            {
                int firstIndex = int.Parse(match.Groups[1].Value);
                baseIndex = (baseIndex + firstIndex) % line.Length;
                output += line[baseIndex];
                int secondIndex = int.Parse(match.Groups[2].Value);
                baseIndex = (baseIndex + secondIndex) % line.Length;
                output += line[baseIndex];
            }

            Console.WriteLine(output);
        }
    }
}
