namespace _08_PetClinic.Models.Contracts
{
    public interface IClinic
    {
        string Name { get; }
        bool Add(IPet pet);
        bool Release();
        bool HasEmptyRooms();
        void Print(int roomIndex);
        void PrintAll();
    }
}
