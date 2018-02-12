namespace _04_TreasureMap
{
    using System;
    using System.Text.RegularExpressions;

    public class TreasureMap
    {
        public static void Main()
        {
            string pattern = 
                @"#[^!#]*?(?<=[^A-Za-z0-9])([A-Za-z]{4})(?=[^A-Za-z0-9])[^!#]*(?<=[^\d])(?:(\d{3})-(\d{6}|\d{4}))(?=[^\d])[^!#]*!|![^!#]*?(?<=[^A-Za-z0-9])([A-Za-z]{4})(?=[^A-Za-z0-9])[^!#]*(?<=[^\d])(?:(\d{3})-(\d{6}|\d{4}))(?=[^\d])[^!#]*#";

            int n = int.Parse(Console.ReadLine());

            var matchInstruction = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                var matches = matchInstruction.Matches(line);
                
                if(matches.Count > 0)
                {
                    int index = matches.Count / 2 + 1;
                    var match = matches[index - 1];

                    if (match.Value[0] == '#')
                    {
                        Console.WriteLine($"Go to str. {match.Groups[1]} {match.Groups[2]}. Secret pass: {match.Groups[3]}.");
                    }
                    else
                    {
                        Console.WriteLine($"Go to str. {match.Groups[4]} {match.Groups[5]}. Secret pass: {match.Groups[6]}.");
                    }
                }                
            }
        }
    }
}
