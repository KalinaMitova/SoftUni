namespace _03BarracksFactory.Core.Commands
{
    using _03BarracksFactory.Contracts;

    public abstract class Command : IExecutable
    {        
        private string[] data;

        public Command(string[] data)
        {
            this.data = data;
        }
        
        protected string[] Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }

        public abstract string Execute();
    }
}
