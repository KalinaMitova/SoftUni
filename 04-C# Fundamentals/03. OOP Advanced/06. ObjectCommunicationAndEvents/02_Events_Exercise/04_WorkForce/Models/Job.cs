namespace P04_WorkForce.Models
{
    using P04_WorkForce.Contracts;
    using System;

    public class Job : IJob
    {
        private int hoursOfWorkRequired;

        public Job(string jobName, int hoursOfWorkRequired, IEmployee employee)
        {
            this.Name = jobName;
            this.HoursOfWorkRequired = hoursOfWorkRequired;
            this.Employee = employee;
        }

        public string Name { get; }

        public int HoursOfWorkRequired
        {
            get
            {
                return this.hoursOfWorkRequired;
            }
            private set
            {
                this.hoursOfWorkRequired = value;
                if(this.hoursOfWorkRequired <= 0)
                {
                    this.OnJobIsDone?.Invoke(this);
                }
            }
        }

        public IEmployee Employee { get; }

        public event OnJobIsDoneEventHandler OnJobIsDone;

        public void Update()
        {
            this.HoursOfWorkRequired -= this.Employee.WorkHoursPerWeek;
        }
    }
}
