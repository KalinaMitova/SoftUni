using System;
using System.Linq;

namespace Minedraft
{
    class Startup
    {
        static void Main()
        {
            DraftManager draftManager = new DraftManager();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split();

                string command = tokens[0];

                var arguments = tokens.Skip(1).Take(tokens.Length - 1).ToList();

                string output = string.Empty;

                switch (command)
                {
                    case "RegisterHarvester":
                        output = draftManager.RegisterHarvester(arguments);
                        break;
                    case "RegisterProvider":
                        output = draftManager.RegisterProvider(arguments);
                        break;
                    case "Day":
                        output = draftManager.Day();
                        break;
                    case "Mode":
                        output = draftManager.Mode(arguments);
                        break;
                    case "Check":
                        output = draftManager.Check(arguments);
                        break;
                    case "Shutdown":
                        output = draftManager.ShutDown();
                        Console.WriteLine(output);
                        return;
                }

                Console.WriteLine(output);
            }
        }
    }
}
