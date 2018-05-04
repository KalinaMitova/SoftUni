public abstract class Command : ICommand, IExecutable
{
    private string[] data;

    public Command(string[] data)
    {
        this.Data = data;
    }

    public string[] Data
    {
        get { return data; }
        private set { data = value; }
    }
    
    public abstract void Execute();
}