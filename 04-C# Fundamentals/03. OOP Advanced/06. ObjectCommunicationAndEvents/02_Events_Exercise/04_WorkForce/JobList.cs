namespace P04_WorkForce
{
    using System;
    using System.Collections.Generic;

    using P04_WorkForce.Contracts;

    public class JobList : List<IJob>, IJobList
    {
        public event OnPassWeekEventHandler OnPassWeek;

        public void PassWeek()
        {
            this.OnPassWeek?.Invoke();
        }

        public void Status()
        {
            foreach (var job in this)
            {
                 Console.WriteLine($"Job: {job.Name} Hours Remaining: {job.HoursOfWorkRequired}");
            }
        }

        public void OnJobIsDone(IJob job)
        {
            this.OnPassWeek -= job.Update;
            this.Remove(job);
            Console.WriteLine($"Job {job.Name} done!");
        }
    }
}
