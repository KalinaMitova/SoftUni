namespace P04_WorkForce.Models
{
    using P04_WorkForce.Contracts;

    public class StandardEmployee : IEmployee
    {
        private const int DefaultWorkHoursPerWeek = 40;

        public StandardEmployee(string name)
        {
            this.Name = name;
            this.WorkHoursPerWeek = DefaultWorkHoursPerWeek;
        }

        public string Name { get; }

        public int WorkHoursPerWeek { get; }
    }
}
