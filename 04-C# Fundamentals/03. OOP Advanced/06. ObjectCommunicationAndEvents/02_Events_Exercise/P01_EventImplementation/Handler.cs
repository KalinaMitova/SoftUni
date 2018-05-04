namespace P01_EventImplementation
{
    using System;

    public class Handler
    {
        public void OnDispatcherNameChange(object source, NameChangeEventArgs args)
        {
            Console.WriteLine($"Dispatcher's name changed to {args.Name}.");
        }
    }
}
