public class Tire
{
    private double pressure;
    private int age;

    public double Pressure
    {
        get { return pressure; }
        set { pressure = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }
    
    public Tire(double pressure, int age)
    {
        Pressure = pressure;
        Age = age;
    }
}