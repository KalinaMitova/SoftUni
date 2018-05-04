using System;

using Logger.Models.Enums;
using Logger.Models.Contracts;
using Logger.Models.Entities;
using Logger.Models.Entities.Appenders;

namespace Logger.Models.Factories
{
    public class AppenderFactory
    {
        const string DefaultFileName = "logFile{0}";
        const string Extension = ".txt";
        
        private LayoutFactory layoutFactory;
        private int fileNumber;
        private string fileName;

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
            this.fileNumber = 0;
        }

        public IAppender CreateAppender(string appenderType, string errorLevelString, string layoutType)
        {
            ILayout layout = this.layoutFactory.CreateLayout(layoutType);
            ErrorLevel errorLevel = this.ParseErrorLevel(errorLevelString);

            IAppender appender = null;

            switch (appenderType)
            {
                case "ConsoleAppender":
                    appender = new ConsoleAppender(layout, errorLevel);
                    break;
                case "FileAppender":

                    this.fileName = layout.GetType().Name;
                    string fullFileName = DefaultFileName + "_" + this.fileName + Extension;

                    ILogFile logFile = new LogFile(string.Format(fullFileName, this.fileNumber));
                    appender = new FileAppender(layout, errorLevel, logFile);

                    this.fileNumber++;

                    break;
                default:
                    throw new ArgumentException("Invalid Appender Type!");
            }

            return appender;
        }

        private ErrorLevel ParseErrorLevel(string errorLevelString)
        {
            bool validErrorLevel = Enum.TryParse(errorLevelString, out ErrorLevel errorLevel);

            if (!validErrorLevel)
            {
                throw new ArgumentException("Invalid ErrorLevel Type!");
            }

            return errorLevel;
        }
    }
}
