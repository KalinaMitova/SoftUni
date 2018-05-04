namespace _08_PetClinic.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using _08_PetClinic.Common;
    using _08_PetClinic.Factories;
    using _08_PetClinic.Models.Contracts;

    public class Engine
    {
        PetFactory petFactory;
        ClinicFactory clinicFactory;

        ICollection<IClinic> clinics;
        ICollection<IPet> pets;

        public Engine(ICollection<IClinic> clinics, ICollection<IPet> pets)
        {
            this.petFactory = new PetFactory();
            this.clinicFactory = new ClinicFactory();

            this.clinics = clinics;
            this.pets = pets;
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string command = tokens[0];
                string[] args = tokens.Skip(1).ToArray();

                try
                {
                    switch (command)
                    {
                        case "Create":
                            string type = args[0];
                            if(type == "Pet")
                            {
                                pets.Add(petFactory.CreatePet(args.Skip(1).ToArray()));
                            }
                            else if(type == "Clinic")
                            {
                                clinics.Add(clinicFactory.CreateClinic(args.Skip(1).ToArray()));
                            }
                            break;
                        case "Add":
                            {
                                string petName = args[0];
                                string clinicName = args[1];

                                IPet pet = GetPet(petName);
                                IClinic clinic = GetClinic(clinicName);

                                bool result = clinic.Add(pet);

                                Console.WriteLine(result);
                            }
                            break;
                        case "Release":
                            {
                                string clinicName = args[0];

                                IClinic clinic = GetClinic(clinicName);

                                bool result = clinic.Release();

                                Console.WriteLine(result);
                            }
                            break;
                        case "HasEmptyRooms":
                            {
                                string clinicName = args[0];

                                var clinic = this.clinics.FirstOrDefault(c => c.Name == clinicName);
                                if (clinic == null)
                                {
                                    throw new ArgumentException(ErrorMessages.InvalidOperation);
                                }

                                bool result = clinic.HasEmptyRooms();

                                Console.WriteLine(result);
                            }
                            break;
                        case "Print":
                            {
                                string clinicName = args[0];

                                var clinic = this.clinics.FirstOrDefault(c => c.Name == clinicName);
                                if (clinic == null)
                                {
                                    throw new ArgumentException(ErrorMessages.InvalidOperation);
                                }

                                if (args.Length == 1)
                                {
                                    clinic.PrintAll();
                                }
                                else
                                {
                                    int roomIndex = int.Parse(args[1]);
                                    clinic.Print(roomIndex);
                                }
                            }
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private IPet GetPet(string petName)
        {
            var pet = this.pets.FirstOrDefault(p => p.Name == petName);
            if (pet == null)
            {
                throw new ArgumentException(ErrorMessages.InvalidOperation);
            }

            return pet;
        }

        private IClinic GetClinic(string clinicName)
        {
            var clinic = this.clinics.FirstOrDefault(c => c.Name == clinicName);
            if (clinic == null)
            {
                throw new ArgumentException(ErrorMessages.InvalidOperation);
            }

            return clinic;
        }
    }
}
