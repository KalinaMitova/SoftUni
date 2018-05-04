namespace Logger.Models.Entities.Layouts
{
    internal class SimpleLayout : Layout
    {
        public override string DateFormat => "M/dd/yyyy h:mm:ss tt";
        public override string Format => "{0} - {1} - {2}";
    }
}