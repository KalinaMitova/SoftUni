using NUnit.Framework;

public class MissionControllerTests
{
    [Test]
    public void SuccessfullMissionTest()
    {
        IArmy army = new Army();
        IWareHouse wareHouse = new WareHouse();

        MissionController missionController = new MissionController(army, wareHouse);

        IMission mission = new Easy(0);

        string result = missionController.PerformMission(mission);
        string expectedResult = string.Format("Mission completed - {0}", mission.Name);

        Assert.That(result.Trim(), Is.EqualTo(expectedResult));
    }

    [Test]
    public void MissionOnHoldTest()
    {
        IArmy army = new Army();
        IWareHouse wareHouse = new WareHouse();

        MissionController missionController = new MissionController(army, wareHouse);

        IMission mission = new Easy(30);

        string result = missionController.PerformMission(mission);
        string expectedResult = string.Format("Mission on hold - {0}", mission.Name);

        Assert.That(result.Trim(), Is.EqualTo(expectedResult));
    }
    
    [Test]
    public void MissionDeclinedTest()
    {
        IArmy army = new Army();
        IWareHouse wareHouse = new WareHouse();

        MissionController missionController = new MissionController(army, wareHouse);

        IMission mission = new Easy(30);

        missionController.PerformMission(mission);
        missionController.PerformMission(mission);
        missionController.PerformMission(mission);
        string result = missionController.PerformMission(mission).TrimEnd();

        string expectedResult = string.Format("Mission declined - {0}", mission.Name);

        Assert.That(result.StartsWith(expectedResult));
    }
}