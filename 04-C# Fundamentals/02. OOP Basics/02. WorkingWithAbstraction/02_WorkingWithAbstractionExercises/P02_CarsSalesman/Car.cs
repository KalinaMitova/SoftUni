using System.Text;

public class Car
{
    private const string offset = "  ";

    private string model;
    private Engine engine;
    private int weight;
    private string color;
    
    public string Model
    {
        get { return model; }
        set { model = value; }
    }
    
    public Engine Engine
    {
        get { return engine; }
        set { engine = value; }
    }
    
    public int Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public string Color
    {
        get { return color; }
        set { color = value; }
    }
    
    public Car()
    {
        Weight = -1;
        Color = "n/a";
    }

    public Car(string model, Engine engine)
        :this()
    {
        Model = model;
        Engine = engine;
    }

    public Car(string model, Engine engine, int weight)
        :this(model, engine)
    {
        Weight = weight;
    }

    public Car(string model, Engine engine, string color)
        : this(model, engine)
    {
        Color = color;
    }

    public Car(string model, Engine engine, int weight, string color)
    {
        Model = model;
        Engine = engine;
        Weight = weight;
        Color = color;
    }
    
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendFormat("{0}:\n", Model);
        sb.Append(this.engine.ToString());
        sb.AppendFormat("{0}Weight: {1}\n", offset, Weight == -1 ? "n/a" : Weight.ToString());
        sb.AppendFormat("{0}Color: {1}", offset, Color);

        return sb.ToString();
    }
}