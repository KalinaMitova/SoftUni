using System.Collections.Generic;

public class Department
{
    private string name;
    private List<List<string>> rooms;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public List<List<string>> Rooms
    {
        get { return rooms; }
        set { rooms = value; }
    }

    public Department()
    {
        rooms = new List<List<string>>(20);
        
        for (int room = 0; room < rooms.Capacity; room++)
        {
            rooms.Add(new List<string>(3));
        }
    }

    public Department(string name)
        :this()
    {
        Name = name;
    }
}