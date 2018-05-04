using System.Collections.Generic;
using System.Linq;

public class Hospital
{
    private List<Doctor> doctors;
    private List<Department> departments;
    
    public List<Doctor> Doctors
    {
        get { return doctors; }
        set { doctors = value; }
    }

    public List<Department> Departments
    {
        get { return departments; }
        set { departments = value; }
    }

    public Hospital()
    {
        Doctors = new List<Doctor>();
        Departments = new List<Department>();
    }
    
    public void AddInputInfo(string departament, string patientName, string doctorFullName)
    {
        Department currentDepartment = AddDepartmentIfNotExists(departament);

        Doctor doctor = AddDoctorIfNotExists(doctorFullName);

        bool isThereFreeRoom = CheckForFreeRooms(currentDepartment);

        if (isThereFreeRoom)
        {
            AddPatient(patientName, currentDepartment, doctor);
        }
    }

    private static void AddPatient(string patientName, Department currentDepartment, Doctor doctor)
    {
        doctor.Patients.Add(patientName);

        int roomIndex = FindFreeRoomIndex(currentDepartment);

        currentDepartment.Rooms[roomIndex].Add(patientName);
    }

    private static int FindFreeRoomIndex(Department currentDepartment)
    {
        int room = 0;

        for (int currentRoom = 0; currentRoom < currentDepartment.Rooms.Count; currentRoom++)
        {
            if (currentDepartment.Rooms[currentRoom].Count < 3)
            {
                room = currentRoom;
                break;
            }
        }

        return room;
    }

    private static bool CheckForFreeRooms(Department currentDepartment)
    {
        return currentDepartment
            .Rooms
            .SelectMany(x => x)
            .Count() < 60;
    }

    private Doctor AddDoctorIfNotExists(string doctorFullName)
    {
        var doctor = Doctors.SingleOrDefault(d => d.Name == doctorFullName);

        if (doctor == null)
        {
            doctor = new Doctor(doctorFullName);
            doctors.Add(doctor);
        }

        return doctor;
    }

    private Department AddDepartmentIfNotExists(string departament)
    {
        var currentDepartment = Departments.SingleOrDefault(d => d.Name == departament);

        if (currentDepartment == null)
        {
            currentDepartment = new Department(departament);
            Departments.Add(currentDepartment);
        }

        return currentDepartment;
    }

    public string[] GetAllPatientsFromDepartment(string department)
    {
        return Departments
            .SingleOrDefault(d => d.Name == department).Rooms
            .Where(r => r.Count > 0)
            .SelectMany(x => x)
            .ToArray();
    }

    public string[] GetAllPatientsFromRoom(string department, int room)
    {
        return Departments
            .SingleOrDefault(d => d.Name == department).Rooms[room - 1]
            .OrderBy(p => p)
            .ToArray();
    }

    public string[] GetAllPatientsByDoctorName(string doctorName)
    {
        return Doctors
            .SingleOrDefault(d => d.Name == doctorName)
            .Patients.OrderBy(p => p)
            .ToArray();
    }
}
