namespace _03BarracksFactory.Core.Commands
{
    using _03BarracksFactory.Contracts;
    using _03BarracksFactory.Core.Attributes;

    public class RetireCommand : Command, IExecutable
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data, IRepository repository)
            :base(data)
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
            string unitType = this.Data[1];
            this.Repository.RemoveUnit(unitType);
            return $"{unitType} retired!";
        }
    }
}
