using System;
using System.Globalization;

using Logger.Models.Enums;
using Logger.Models.Entities;
using Logger.Models.Contracts;

namespace Logger.Models.Factories
{
    public class ErrorFactory
    {
        const string DateFormat = "M/dd/yyyy h:mm:ss tt";

        public IError CreateError(string dateTimeString, string errorLevelString, string message)
        {
            DateTime dateTime = DateTime.ParseExact(dateTimeString, DateFormat, CultureInfo.InvariantCulture);
            ErrorLevel errorLevel = ParseErrorLevel(errorLevelString);

            IError error = new Error(dateTime, errorLevel, message);

            return error;
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
