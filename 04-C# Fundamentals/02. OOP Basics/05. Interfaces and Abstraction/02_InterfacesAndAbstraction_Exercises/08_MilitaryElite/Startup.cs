using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_MilitaryElite
{
    public class Startup
    {
        public static void Main()
        {
            List<ISoldier> soldiers = new List<ISoldier>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();

                try
                {
                    ISoldier soldier = SoldierParser(tokens, soldiers);
                    soldiers.Add(soldier);
                }
                catch (Exception)
                {

                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private static ISoldier SoldierParser(string[] tokens, List<ISoldier> soldiers)
        {
            string soldierType = tokens[0];
            string id = tokens[1];
            string firstName = tokens[2];
            string lastName = tokens[3];

            switch (soldierType)
            {
                case "Private": return PrivateParser(tokens, id, firstName, lastName);
                case "LeutenantGeneral": return LeutenantGeneralParser(tokens, soldiers, id, firstName, lastName);
                case "Engineer": return EngineerParser(tokens, id, firstName, lastName);
                case "Commando": return CommandoParser(tokens, id, firstName, lastName);
                case "Spy":
                    int codeNumber = int.Parse(tokens[4]);
                    return new Spy(id, firstName, lastName, codeNumber);
                default: throw new ArgumentException("Invalid!");
            }
        }

        private static ISoldier CommandoParser(string[] tokens, string id, string firstName, string lastName)
        {
            double salary = double.Parse(tokens[4]);

            bool isCorps = Enum.TryParse<CorpsEnum>(tokens[5], out CorpsEnum corps);

            if (!isCorps)
            {
                throw new ArgumentException("Invalid");
            }

            List<IMission> missions = new List<IMission>();

            for (int i = 6; i < tokens.Length; i += 2)
            {
                string codename = tokens[i];

                bool isState = Enum.TryParse<MissionStateEnum>(tokens[i + 1], out MissionStateEnum missionState);

                if (isState)
                {
                    var mission = missions.FirstOrDefault(m => m.CodeName == codename);
                    if(mission == null)
                    {
                        mission = new Mission(codename, missionState);
                    }
                    else if (mission.State == MissionStateEnum.inProgress && missionState == MissionStateEnum.Finished)
                    {
                        mission.CompleteMission();
                    }

                    missions.Add(mission);
                }
            }
            return new Commando(id, firstName, lastName, salary, corps, missions);
        }

        private static ISoldier EngineerParser(string[] tokens, string id, string firstName, string lastName)
        {
            double salary = double.Parse(tokens[4]);

            bool isCorps = Enum.TryParse<CorpsEnum>(tokens[5], out CorpsEnum corps);

            if (!isCorps)
            {
                throw new ArgumentException("Invalid");
            }

            List<IRepair> repairs = new List<IRepair>();

            for (int i = 6; i < tokens.Length; i += 2)
            {
                string partName = tokens[i];
                int hoursWorked = int.Parse(tokens[i + 1]);

                Repair repair = new Repair(partName, hoursWorked);

                repairs.Add(repair);
            }

            return new Engineer(id, firstName, lastName, salary, corps, repairs);
        }

        private static ISoldier LeutenantGeneralParser(string[] tokens, List<ISoldier> soldiers, string id, string firstName, string lastName)
        {
            double salary = double.Parse(tokens[4]);

            List<ISoldier> privates = new List<ISoldier>();

            for (int i = 5; i < tokens.Length; i++)
            {
                string privateId = tokens[i];

                ISoldier privateSoldier = soldiers.FirstOrDefault(s => s.Id == privateId);

                if(privateSoldier != null)
                {
                    privates.Add(privateSoldier);
                }          
            }

            return new LeutenantGeneral(id, firstName, lastName, salary, privates);
        }

        private static ISoldier PrivateParser(string[] tokens, string id, string firstName, string lastName)
        {
            double salary = double.Parse(tokens[4]);
            return new Private(id, firstName, lastName, salary);
        }
    }
}
