namespace _03BarracksFactory.Core.Commands
{
    using _03BarracksFactory.Contracts;
    using _03BarracksFactory.Core.Attributes;

    public class ReportCommand : Command, IExecutable
    {
        [Inject]
        private IRepository repository;

        public ReportCommand(string[] data, IRepository repository)
            : base(data)
        {
            this.Repository = repository;
        }

        protected IRepository Repository
        {
            get { return this.repository; }
            set { this.repository = value; }
        }

        public override string Execute()
        {
            string output = this.Repository.Statistics;
            return output;
        }
    }
}
