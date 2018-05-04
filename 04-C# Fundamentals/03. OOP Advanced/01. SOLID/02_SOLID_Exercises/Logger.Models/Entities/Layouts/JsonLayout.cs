using System.Text;

namespace Logger.Models.Entities.Layouts
{
    public class JsonLayout : Layout
    {
        public override string DateFormat => "HH:mm:ss dd-MMM-yyyy";

        public override string Format => GetFormat();

        private string GetFormat()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("{{");
            sb.AppendLine("  Error: {{");
            sb.AppendLine("    DateTime: {0}");
            sb.AppendLine("    Level: {1}");
            sb.AppendLine("    Message: {2}");
            sb.AppendLine("  }}");
            sb.AppendLine("}}");

            return sb.ToString().Trim();
        }
    }
}
