public class Car
{
    private string model;
    private string speed;

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public string Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public Car(string model, string speed)
    {
        this.Model = model;
        this.Speed = speed;
    }
}