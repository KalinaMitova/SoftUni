using Logger.Models.Enums;
using Logger.Models.Contracts;

namespace Logger.Models.Entities.Appenders
{
    internal class FileAppender : Appender
    {
        private ILogFile logFile;

        public FileAppender(ILayout layout, ErrorLevel errorLevel, ILogFile logFile)
            :base(layout, errorLevel)
        {
            this.logFile = logFile;
        }
        
        public override void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);
            this.logFile.WriteToFile(formattedError);
            this.MessagesAppended++;
        }
        
        public override string ToString()
        {
            string result = base.ToString() + $", File size: {this.logFile.Size}";
            return result;
        }
    }
}