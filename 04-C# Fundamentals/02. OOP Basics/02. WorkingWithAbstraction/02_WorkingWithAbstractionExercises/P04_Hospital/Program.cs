using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Hospital hospital = new Hospital();

            string input;
            while ((input = Console.ReadLine()) != "Output")
            {
                ParseInput(hospital, input);
            }

            string output;
            while ((output = Console.ReadLine()) != "End")
            {
                string[] patients = ParseOutput(hospital, output);

                Console.WriteLine(string.Join("\n", patients));
            }
        }

        private static string[] ParseOutput(Hospital hospital, string output)
        {
            string[] args = output.Split();
            string[] patients;

            if (args.Length == 1)
            {
                var department = args[0];
                patients = hospital.GetAllPatientsFromDepartment(department);
            }
            else if (args.Length == 2 && int.TryParse(args[1], out int room))
            {
                string department = args[0];
                patients = hospital.GetAllPatientsFromRoom(department, room);
            }
            else
            {
                string doctorName = args[0] + " " + args[1];
                patients = hospital.GetAllPatientsByDoctorName(doctorName);
            }

            return patients;
        }

        private static void ParseInput(Hospital hospital, string input)
        {
            string[] tokens = input.Split();

            var departament = tokens[0];
            var doctorFirstName = tokens[1];
            var doctorLastName = tokens[2];
            var patientName = tokens[3];
            var doctorFullName = doctorFirstName + " " + doctorLastName;

            hospital.AddInputInfo(departament, patientName, doctorFullName);
        }
    }
}
