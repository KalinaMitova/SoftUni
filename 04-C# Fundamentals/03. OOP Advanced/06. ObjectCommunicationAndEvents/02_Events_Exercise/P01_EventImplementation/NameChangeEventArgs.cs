namespace P01_EventImplementation
{
    using System;

    using P01_EventImplementation.Contracts;

    public class NameChangeEventArgs : EventArgs, INameable
    {
        public NameChangeEventArgs(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}
