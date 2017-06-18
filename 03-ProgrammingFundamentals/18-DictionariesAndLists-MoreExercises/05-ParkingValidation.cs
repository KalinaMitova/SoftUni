using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _05_ParkingValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex rgx = new Regex(@"[A-Z]{2}[0-9]{4}[A-Z]{2}");
            var usersCars = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();
                var command = tokens[0];
                var username = tokens[1];

                if (command == "register")
                {
                    var licensePlateNumber = tokens[2];

                    Match m = rgx.Match(licensePlateNumber);

                    if (usersCars.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {usersCars[username]}");
                        continue;
                    } else if (!(m.Success) || licensePlateNumber.Length != 8)
                    {
                        Console.WriteLine($"ERROR: invalid license plate {licensePlateNumber}");
                        continue;
                    }else if (usersCars.ContainsValue(licensePlateNumber))
                    {
                        Console.WriteLine($"ERROR: license plate {licensePlateNumber} is busy");
                        continue;
                    }
                    else
                    {
                        usersCars[username] = licensePlateNumber;
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                }
                else if (command == "unregister")
                {
                    if (usersCars.ContainsKey(username))
                    {
                        usersCars.Remove(username);
                        Console.WriteLine($"user {username} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                }                       
            }

            foreach (var userCar in usersCars)
            {
                var username = userCar.Key;
                var licensePlateNumber = userCar.Value;

                Console.WriteLine($"{username} => {licensePlateNumber}");
            }
        }
    }
}
