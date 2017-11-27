using System;

public class Stat
{
    private string name;
    private int value;

    public Stat(string name, int value)
    {
        this.Name = name;
        this.Value = value;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            this.name = value;
        }
    }

    public int Value
    {
        get
        {
            return this.value;
        }
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{this.Name} should be between 0 and 100.");
            }
            this.value = value;
        }
    }
}