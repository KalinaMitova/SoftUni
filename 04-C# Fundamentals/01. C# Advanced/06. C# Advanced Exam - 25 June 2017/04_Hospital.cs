namespace _04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Hospital
    {
        public static void Main()
        {
            var departmentsRoomPatient = new Dictionary<string, List<string>>();

            var doctorPatients = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "Output")
            {
                string[] tokens = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string department = tokens[0];
                string doctor = tokens[1] + " " + tokens[2];
                string patient = tokens[3];

                if (!departmentsRoomPatient.ContainsKey(department))
                {
                    departmentsRoomPatient.Add(department, new List<string>());
                }

                if (!departmentsRoomPatient[department].Contains(patient) && departmentsRoomPatient[department].Count <= 60)
                {
                    departmentsRoomPatient[department].Add(patient);

                    if (!doctorPatients.ContainsKey(doctor))
                    {
                        doctorPatients.Add(doctor, new List<string>());
                    }

                    doctorPatients[doctor].Add(patient);                    
                }
            }

            string output;
            while ((output = Console.ReadLine()) != "End")
            {
                string[] tokens = output
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                if (departmentsRoomPatient.ContainsKey(command))
                {
                    if (tokens.Length == 1)
                    {
                        foreach (var patient in departmentsRoomPatient[command])
                        {
                            Console.WriteLine(patient);
                        }
                    }
                    else
                    {
                        int room = int.Parse(tokens[1]);

                        List<string> patients = new List<string>();
                        
                        for (int i = 1; i <= 3; i++)
                        {
                            int index = (room * 3) - i;

                            if(index <= departmentsRoomPatient[command].Count && index >= 0)
                            {
                                patients.Add(departmentsRoomPatient[command][index]);
                            }
                        }

                        foreach (var patient in patients.OrderBy(p => p))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                }
                else if (doctorPatients.ContainsKey(command + " " + tokens[1]))
                {
                    foreach (var patient in doctorPatients[command + " " + tokens[1]].OrderBy(p => p))
                    {
                        Console.WriteLine(patient);
                    }
                }
            }
        }
    }
}
