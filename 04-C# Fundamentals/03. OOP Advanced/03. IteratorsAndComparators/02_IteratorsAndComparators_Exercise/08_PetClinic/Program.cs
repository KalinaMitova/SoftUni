namespace _08_PetClinic
{
    using _08_PetClinic.Core;
    using _08_PetClinic.Models.Contracts;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {            
            Engine engine = new Engine(new List<IClinic>(), new List<IPet>());
            engine.Run();
        }
    }
}
