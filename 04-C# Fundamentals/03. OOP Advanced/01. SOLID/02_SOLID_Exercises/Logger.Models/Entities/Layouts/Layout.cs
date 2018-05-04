using System.Globalization;

using Logger.Models.Contracts;

namespace Logger.Models.Entities.Layouts
{ 
    public abstract class Layout : ILayout
    {
        public abstract string DateFormat { get; }
        public abstract string Format { get; }
        
        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);
            string errorLevel = error.Level.ToString();

            string formattedError = string.Format(Format, dateString, errorLevel, error.Message);
            return formattedError;
        }
    }
}
