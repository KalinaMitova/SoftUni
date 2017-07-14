using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04_CubicMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            while (line != "Over!")
            {
                int m = int.Parse(Console.ReadLine());
                var pattern = $@"^[0-9]+([A-Za-z]{{{m}}})[^A-Za-z]*$";

                Match messageMatch = Regex.Match(line, pattern);
                
                if (messageMatch.Success)
                {
                    string message = messageMatch.Groups[1].Value;

                    int[] indexes = messageMatch.Value
                        .Where(c => char.IsDigit(c))
                        .Select(c => (int)char.GetNumericValue(c))
                        .ToArray();

                    StringBuilder verificationCode = new StringBuilder();

                    foreach (int index in indexes)
                    {
                        if (index < message.Length)
                        {
                            verificationCode.Append(message[index]);
                        }
                        else
                        {
                            verificationCode.Append(' ');
                        }
                    }
                    
                    Console.WriteLine($"{message} == {verificationCode.ToString()}");
                    
                }

                line = Console.ReadLine();
            }            
        }
    }
}
