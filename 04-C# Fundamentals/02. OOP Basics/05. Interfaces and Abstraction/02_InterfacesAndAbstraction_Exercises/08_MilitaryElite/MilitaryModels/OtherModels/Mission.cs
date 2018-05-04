using System;

public class Mission : IMission
{
    private string codeName;
    private MissionStateEnum state;

    public string CodeName
    {
        get
        {
            return this.codeName;
        }
        set
        { 
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid");
            }
            this.codeName = value;
        }
    }

    public MissionStateEnum State
    {
        get
        {
            return this.state;
        }
        set
        {
            this.state = value;
        }
    }

    public Mission(string codeName, MissionStateEnum state)
    {
        this.CodeName = codeName;
        this.State = state;
    }

    public void CompleteMission()
    {
        this.State = MissionStateEnum.Finished;
    }

    public override string ToString()
    {
        return $"Code Name: {this.CodeName} State: {this.State.ToString()}";
    }
}