using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06_ReplaceATag
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"<a.*href=""(?<link>.*)"">(?<name>.*)<\/a>";

            var line = Console.ReadLine();

            var output = new StringBuilder();

            while (line != "end")
            {
                var match = Regex.Match(line, pattern);
                if (match.Success)
                {
                    var replaced = Regex.Replace(line, pattern,
                    m => $@"[URL href=""{m.Groups["link"]}""]{m.Groups["name"]}[/URL]");

                    output.Append(replaced + Environment.NewLine);
                }
                else
                {
                    output.Append(line + Environment.NewLine);
                }
                line = Console.ReadLine();
            }

            Console.WriteLine(output.ToString());
        }
    }
}
