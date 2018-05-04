using Logger.Models.Enums;
using Logger.Models.Contracts;

namespace Logger.Models.Entities
{
    public abstract class Appender : IAppender
    {
        public Appender(ILayout layout, ErrorLevel level)
        {
            this.Layout = layout;
            this.Level = level;
            this.MessagesAppended = 0;
        }

        public ILayout Layout { get; }

        public ErrorLevel Level { get; }

        public int MessagesAppended { get; protected set; }

        public abstract void Append(IError error);

        public override string ToString()
        {
            string appenderType = this.GetType().Name;
            string layoutType = this.Layout.GetType().Name;
            string level = this.Level.ToString();

            string result = $"Appender type: {appenderType}, Layout type: {layoutType}, Report level: {level}, Messages appended: {this.MessagesAppended}";
            return result;
        }
    }
}
