using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_FixEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var emails = new Dictionary<string, string>();
            int counter = 1;
            var name = input;

            while (input != "stop")
            {
                if (counter % 2 == 1)
                {
                    name = input;

                    if (!emails.ContainsKey(name))
                    {
                        emails.Add(name, string.Empty);
                    }
                }
                else
                {
                    var email = input;
                    if (email.EndsWith("uk") || email.EndsWith("us"))
                    {
                        emails.Remove(name);
                    }

                    if (emails.ContainsKey(name))
                    {
                        emails[name] = email;
                    }
                }

                input = Console.ReadLine();
                counter++;
            }

            foreach (var email in emails)
            {
                Console.WriteLine($"{email.Key} -> {email.Value}");
            }
        }
    }
}