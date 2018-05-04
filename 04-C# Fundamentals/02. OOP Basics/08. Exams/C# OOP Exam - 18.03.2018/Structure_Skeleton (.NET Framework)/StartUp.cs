using DungeonsAndCodeWizards.Core;
using System;
using System.Linq;

namespace DungeonsAndCodeWizards
{
	public class StartUp
	{
		// DO NOT rename this file's namespace or class name.
		// However, you ARE allowed to use your own namespaces (or no namespaces at all if you prefer) in other classes.
		public static void Main(string[] args)
		{
            DungeonMaster dm = new DungeonMaster();

            string input;
            while (!string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                string[] tokens = input.Split();

                string command = tokens[0];

                string[] arguments = tokens.Skip(1).ToArray();

                string output = string.Empty;

                try
                {
                    switch (command)
                    {
                        case "JoinParty":
                            output = dm.JoinParty(arguments);
                            break;
                        case "AddItemToPool":
                            output = dm.AddItemToPool(arguments);
                            break;
                        case "PickUpItem":
                            output = dm.PickUpItem(arguments);
                            break;
                        case "UseItem":
                            output = dm.UseItem(arguments);
                            break;
                        case "UseItemOn":
                            output = dm.UseItemOn(arguments);
                            break;
                        case "GiveCharacterItem":
                            output = dm.GiveCharacterItem(arguments);
                            break;
                        case "GetStats":
                            output = dm.GetStats();
                            break;
                        case "Attack":
                            output = dm.Attack(arguments);
                            break;
                        case "Heal":
                            output = dm.Heal(arguments);
                            break;
                        case "EndTurn":
                            output = dm.EndTurn(arguments);
                            break;
                        case "IsGameOver":
                            output = dm.IsGameOver().ToString();
                            break;
                    }

                    if (!string.IsNullOrEmpty(output))
                    {
                        Console.WriteLine(output);
                    }
                }
                catch (ArgumentException ar)
                {
                    Console.WriteLine("Parameter Error: " + ar.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine("Invalid Operation: " + ioe.Message);
                }

                bool isGameOver = dm.IsGameOver();
                if (isGameOver)
                {
                    break;
                }
            }

            Console.WriteLine($"Final stats:");
            Console.WriteLine(dm.GetStats());
        }
	}
}