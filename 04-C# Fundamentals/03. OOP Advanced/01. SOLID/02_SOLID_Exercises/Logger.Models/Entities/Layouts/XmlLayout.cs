using System.Text;

namespace Logger.Models.Entities.Layouts
{
    public class XmlLayout : Layout
    {
        public override string DateFormat => "HH:mm:ss dd-MMM-yyyy";
        
        public override string Format => GetFormat();
        
        private string GetFormat()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<log>");
            sb.AppendLine("  <date>{0}</date>");
            sb.AppendLine("  <level>{1}</level>");
            sb.AppendLine("  <message>{2}</message>");
            sb.AppendLine("</log>");

            return sb.ToString().Trim();
        }   
    }
}
