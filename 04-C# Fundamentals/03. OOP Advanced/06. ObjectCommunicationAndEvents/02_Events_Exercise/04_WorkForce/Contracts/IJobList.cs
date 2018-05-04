namespace P04_WorkForce.Contracts
{
    public delegate void OnPassWeekEventHandler();

    public interface IJobList
    {
        event OnPassWeekEventHandler OnPassWeek;

        void Status();
    }
}
