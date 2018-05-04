using System;

public class Mission : IMission
{
    public Mission(string codeName, string missionState)
    {
        this.CodeName = codeName;

        ParseState(missionState);
    }

    public string CodeName { get; private set; }

    public MissionStateEnum State { get; private set; }

    private void ParseState(string state)
    {
        bool isValidState = Enum.TryParse<MissionStateEnum>(state, out MissionStateEnum missionState);

        if (!isValidState)
        {
            throw new ArgumentException("Invalid state!");
        }

        this.State = missionState;
    }

    public void Complete()
    {
        if(this.State == MissionStateEnum.Finished)
        {
            throw new InvalidOperationException("Mission already finished!");
        }

        this.State = MissionStateEnum.Finished;
    }
    
    public override string ToString()
    {
        return $"Code Name: {this.CodeName} State: {this.State.ToString()}";
    }
}