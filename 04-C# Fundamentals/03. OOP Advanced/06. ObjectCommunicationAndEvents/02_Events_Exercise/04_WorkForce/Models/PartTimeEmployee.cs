namespace P04_WorkForce.Models
{
    using P04_WorkForce.Contracts;

    public class PartTimeEmployee : IEmployee
    {
        private const int DefaultWorkHoursPerWeek = 20;

        public PartTimeEmployee(string name)
        {
            this.Name = name;
            this.WorkHoursPerWeek = DefaultWorkHoursPerWeek;
        }

        public string Name { get; }

        public int WorkHoursPerWeek { get; }
    }
}
