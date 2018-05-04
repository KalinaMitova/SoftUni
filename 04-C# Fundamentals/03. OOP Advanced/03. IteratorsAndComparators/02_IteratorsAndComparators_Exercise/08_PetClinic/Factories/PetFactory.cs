namespace _08_PetClinic.Factories
{
    using _08_PetClinic.Models;
    using _08_PetClinic.Models.Contracts;

    public class PetFactory
    {
        public IPet CreatePet(string[] args)
        {
            string name = args[0];
            int age = int.Parse(args[1]);
            string kind = args[2];

            return new Pet(name, age, kind);
        }
    }
}
