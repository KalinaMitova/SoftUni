public interface IMission
{
    string CodeName { get; }

    MissionStateEnum State { get; }

    void Complete();
}