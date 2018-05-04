namespace P01_EventImplementation.Contracts
{
    public interface INameChangeable
    {
        void OnNameChange(NameChangeEventArgs args);
    }
}
