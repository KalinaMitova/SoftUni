using System;

using Logger.Models.Enums;
using Logger.Models.Contracts;

namespace Logger.Models.Entities
{
    public class Error : IError
    {
        public Error(DateTime dateTime, ErrorLevel level, string message)
        {
            this.DateTime = dateTime;
            this.Level = level;
            this.Message = message;
        }

        public DateTime DateTime { get; }

        public string Message { get; }

        public ErrorLevel Level { get; }
    }
}
