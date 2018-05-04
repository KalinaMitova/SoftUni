namespace _08_PetClinic.Factories
{
    using _08_PetClinic.Models;
    using _08_PetClinic.Models.Contracts;

    public class ClinicFactory
    {
        public IClinic CreateClinic(string[] args)
        {
            string name = args[0];
            int roomsCount = int.Parse(args[1]);

            return new Clinic(name, roomsCount);
        }
    }
}
