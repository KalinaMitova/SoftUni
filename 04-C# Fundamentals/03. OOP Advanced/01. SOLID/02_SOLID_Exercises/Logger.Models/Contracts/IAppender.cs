namespace Logger.Models.Contracts
{
    public interface IAppender : ILevelable
    {
        ILayout Layout { get; }

        int MessagesAppended { get; }

        void Append(IError error);
    }
}
