public interface ICommand : IExecutable
{
    string[] Data { get; }
}