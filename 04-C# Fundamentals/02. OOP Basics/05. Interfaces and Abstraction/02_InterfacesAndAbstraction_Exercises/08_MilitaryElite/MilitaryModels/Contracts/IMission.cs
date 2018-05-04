public interface IMission
{
    string CodeName { get; set; }

    MissionStateEnum State { get; set; }

    void CompleteMission();
}