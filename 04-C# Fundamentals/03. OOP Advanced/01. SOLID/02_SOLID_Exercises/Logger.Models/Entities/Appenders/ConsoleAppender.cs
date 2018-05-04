using System;

using Logger.Models.Enums;
using Logger.Models.Contracts;

namespace Logger.Models.Entities.Appenders
{
    internal class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout, ErrorLevel level)
            :base(layout, level)
        {

        }
        
        public override void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);
            Console.WriteLine(formattedError);
            MessagesAppended++;
        }
    }
}