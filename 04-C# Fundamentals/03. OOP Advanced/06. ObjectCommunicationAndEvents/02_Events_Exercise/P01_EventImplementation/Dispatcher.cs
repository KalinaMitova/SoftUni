namespace P01_EventImplementation
{
    using P01_EventImplementation.Contracts;

    public delegate void NameChangeEventHandler(object source, NameChangeEventArgs args);

    public class Dispatcher : INameable, INameChangeable
    {
        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                OnNameChange(new NameChangeEventArgs(value));
                this.name = value;
            }
        }

        public event NameChangeEventHandler NameChange;
        
        public void OnNameChange(NameChangeEventArgs args)
        {
            this.NameChange?.Invoke(this, args);
        }
    }
}
