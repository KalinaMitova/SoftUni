using System;
using System.Collections.Generic;

namespace _08_1MilitaryElite
{
    public class Startup
    {
        public static void Main()
        {
            var soldiers = new List<ISoldier>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();

                string soldierType = tokens[0];
                int id = int.Parse(tokens[1]);
                string firstName = tokens[2];
                string lastName = tokens[3];
                decimal salary = decimal.Parse(tokens[4]);

                ISoldier soldier = null;

                switch (soldierType)
                {
                    case "Private":
                        soldier = new Private(id, firstName, lastName, salary);
                        break;
                    case "LeutenantGeneral":
                        soldier = new LeutenantGeneral(id, firstName, lastName, salary);
                        break;
                    case "Engineer":
                        string engineerCorps = tokens[5];
                        soldier = new Engineer(id, firstName, lastName, salary, engineerCorps);
                        break;
                    case "Commando":
                        string comandoCorps = tokens[5];
                        soldier = new Commando(id, firstName, lastName, salary, comandoCorps);
                        break;
                }

                soldiers.Add(soldier);
            }
        }
    }
}
