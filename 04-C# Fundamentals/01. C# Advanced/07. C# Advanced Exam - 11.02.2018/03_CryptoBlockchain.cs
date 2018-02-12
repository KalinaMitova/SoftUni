namespace _03_CryptoBlockchain
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string block = string.Empty;

            for (int i = 0; i < n; i++)
            {
                block += Console.ReadLine();
            }

            var pattern = @"((?<b1>\[)|(?<b2>{))([^\[\]{}\d]*(?<nums>\d{3,})[^\[\]{}\d]*)?(?(b1)\]|(?(b2)}))";

            var regex = new Regex(pattern);

            var matches = regex.Matches(block);

            string output = string.Empty;

            foreach (Match match in matches)
            {
                string nums = match.Groups["nums"].Value;
                if (nums.Length % 3 == 0)
                {
                    for (int i = 0; i < nums.Length; i+=3)
                    {
                        var num = nums.Substring(i, 3);
                        output += Convert.ToChar(int.Parse(num) - match.Length);
                    }
                }
            }

            Console.WriteLine(output);
        }
    }
}
