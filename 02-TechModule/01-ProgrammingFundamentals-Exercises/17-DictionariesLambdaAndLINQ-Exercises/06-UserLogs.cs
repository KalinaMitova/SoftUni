using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_UserLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separators = { '=', ' ' };
            var command = Console.ReadLine().Split(separators).ToList();

            var allUsers = new SortedDictionary<string, Dictionary<string, int>>();

            while (command[0] != "end")
            {
                var ip = command[1];
                var message = command[3];
                var user = command[5];
                
                if (allUsers.ContainsKey(user))
                {
                    if (allUsers[user].ContainsKey(ip))
                    {
                        allUsers[user][ip]++;
                    }
                    else
                    {
                        allUsers[user].Add(ip, 1);
                    }                    
                }
                else
                {
                    allUsers.Add(user, new Dictionary<string, int>() { { ip, 1} });
                }

                command = Console.ReadLine().Split(separators).ToList();
            }

            foreach (var user in allUsers)
            {
                Console.WriteLine(user.Key + ": ");
                
                var last = user.Value.Last();

                foreach (var ip in user.Value)
                {
                    Console.Write($"{ip.Key} => {ip.Value}");

                    if (ip.Equals(last))
                    {
                        Console.WriteLine(".");
                    }
                    else
                    {
                        Console.Write(", ");
                    }
                }    
            }
        }
    }
}
