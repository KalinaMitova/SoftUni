using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06_EmailStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"^(?<user>[A-Za-z]{5,})@(?<domain>[a-z]{3,}(\.bg|\.com|\.org))$";
            Dictionary<string, List<string>> domainsUsernames = new Dictionary<string, List<string>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var email = Console.ReadLine();

                var matchEmail = Regex.Match(email, pattern);

                if (matchEmail.Success)
                {
                    var domain = matchEmail.Groups["domain"].Value;
                    var user = matchEmail.Groups["user"].Value;

                    if (!domainsUsernames.ContainsKey(domain))
                    {
                        domainsUsernames[domain] = new List<string>();
                    }

                    if (!domainsUsernames[domain].Contains(user))
                    {
                        domainsUsernames[domain].Add(user);
                    }
                }                
            }

            foreach (var domainUser in domainsUsernames.OrderByDescending(du => du.Value.Count))
            {
                Console.WriteLine(domainUser.Key + ":");
                foreach (var user in domainUser.Value)
                {
                    Console.WriteLine("### " + user);
                }
            }
        }
    }
}
