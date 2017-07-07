using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07_QueryMess
{
    class Program
    {
        static void Main(string[] args)
        {
            string replacePattern = @"(\+|%20)+";
            string pattern = @"(?:\b|&|\?|^)*(?<key>[^\?&\n]+)=(?<value>[^\?&\n]+)(?:\b|&|\?|&)*";

            StringBuilder output = new StringBuilder();

            string line = Console.ReadLine();
            
            while (line != "END")
            {
                var fieldsValues = new Dictionary<string, List<string>>();

                line = Regex.Replace(line, replacePattern, " ");

                MatchCollection fieldValue = Regex.Matches(line, pattern);
                                
                foreach (Match match in fieldValue)
                {
                    string key = match.Groups["key"].Value.Trim();
                    string value = match.Groups["value"].Value.Trim();

                    if (!fieldsValues.ContainsKey(key))
                    {
                        fieldsValues[key] = new List<string>();
                    }

                    fieldsValues[key].Add(value);
                }

                foreach (var kvp in fieldsValues)
                {
                    var field = kvp.Key;
                    var value = kvp.Value;

                    output.Append($"{field}=[{string.Join(", ", value)}]");
                }

                output.Append(Environment.NewLine);

                line = Console.ReadLine();
            }

            Console.Write(output);
        }
    }
}
