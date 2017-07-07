using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_EnduranceRally
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] drivers = Console.ReadLine().Split();
            decimal[] track = Console.ReadLine().Split().Select(decimal.Parse).ToArray();
            List<int> checkpoints = Console.ReadLine().Split().Select(int.Parse).ToList();

            var output = new StringBuilder();

            for (int j = 0; j < drivers.Length; j++)
            {
                decimal driverFuel = (int)drivers[j].First();

                for (int i = 0; i < track.Length; i++)
                {
                    if (checkpoints.Contains(i))
                    {
                        driverFuel += track[i];
                    }
                    else
                    {
                        driverFuel -= track[i];
                    }

                    if (driverFuel <= 0)
                    {
                        output.Append($"{drivers[j]} - reached {i}" + Environment.NewLine);
                        break;
                    }
                }

                if (driverFuel > 0)
                {
                    output.Append($"{drivers[j]} - fuel left {driverFuel:F2}" + Environment.NewLine);
                }
            }

            Console.Write(output);
        }
    }
}
