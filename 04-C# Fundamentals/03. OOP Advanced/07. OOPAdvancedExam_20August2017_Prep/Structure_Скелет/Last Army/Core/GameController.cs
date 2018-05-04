using System;
using System.Linq;

public class GameController
{
    private IArmy army;
    private IWareHouse wareHouse;
    private MissionController missionController;
    private IWriter writer;
    private ISoldierFactory soldierFactory;
    private IMissionFactory missionFactory;

    public GameController(IWriter writer)
    {
        this.army = new Army();
        this.wareHouse = new WareHouse();
        this.missionController = new MissionController(this.army, this.wareHouse);

        this.soldierFactory = new SoldierFactory();
        this.missionFactory = new MissionFactory();

        this.writer = writer;
    }

    public void GiveInputToGameController(string input)
    {
        var data = input.Split();

        if (data[0].Equals("Soldier"))
        {
            string type = data[1];

            if(type == "Regenerate")
            {
                string soldierType = data[2];
                this.army.RegenerateTeam(soldierType);
            }
            else
            {
                string soldierType = data[1];
                string name = data[2];
                int age = int.Parse(data[3]);
                double experience = double.Parse(data[4]);
                double endurance = double.Parse(data[5]);

                ISoldier soldier = this.soldierFactory.CreateSoldier(soldierType, name, age, experience, endurance);

                if (!this.wareHouse.TryEquipSoldier(soldier))
                {
                    throw new ArgumentException(string.Format(OutputMessages.NoWeaponForSoldier, soldierType, name));
                }

                this.army.AddSoldier(soldier);
            }
        }
        else if (data[0].Equals("WareHouse"))
        {
            string name = data[1];
            int quantity = int.Parse(data[2]);

            this.wareHouse.AddAmmunition(name, quantity);
        }
        else if (data[0].Equals("Mission"))
        {
            string type = data[1];
            double scoreToComplete = double.Parse(data[2]);

            IMission mission = this.missionFactory.CreateMission(type, scoreToComplete);

            string result = this.missionController.PerformMission(mission);
            this.writer.AppendLine(result.Trim());
        }
    }

    public void RequestResult()
    {
        this.missionController.FailMissionsOnHold();
        this.writer.AppendLine("Results:");
        this.writer.AppendLine(string.Format("Successful missions - {0}", this.missionController.SuccessMissionCounter));
        this.writer.AppendLine(string.Format("Failed missions - {0}", this.missionController.FailedMissionCounter));
        this.writer.AppendLine("Soldiers:");

        var orderedSoldiers = this.army.Soldiers.OrderByDescending(s => s.OverallSkill);
        foreach (var soldier in orderedSoldiers)
        {
            this.writer.AppendLine(soldier.ToString());
        }
    }
}
