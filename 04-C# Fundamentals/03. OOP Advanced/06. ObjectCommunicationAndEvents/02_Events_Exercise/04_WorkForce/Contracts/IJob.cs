namespace P04_WorkForce.Contracts
{
    public delegate void OnJobIsDoneEventHandler(IJob job);

    public interface IJob : INameable
    {
        IEmployee Employee { get; }

        int HoursOfWorkRequired { get; }

        event OnJobIsDoneEventHandler OnJobIsDone;

        void Update();
    }
}
