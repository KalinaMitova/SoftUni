using System.Collections.Generic;

public interface ICommando : ISpecialisedSoldier
{
    IReadOnlyCollection<IMission> Missions { get; }

    void Complete(string missionCodeName);

    void AddMission(IMission mission);
}