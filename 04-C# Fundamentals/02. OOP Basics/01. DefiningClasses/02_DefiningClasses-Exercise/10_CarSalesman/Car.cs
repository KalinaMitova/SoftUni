using System.Text;

public class Car
{
    private string model;
    private Engine engine;
    private string weight;
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
    
    public string Weight
    {
        get { return weight; }
        set { weight = value; }
    }
    
    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public Car(string model, Engine engine)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = "n/a";
        this.Color = "n/a";
    }
    
    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"{this.Model}:");
        stringBuilder.AppendLine($"  {this.Engine.Model}:");
        stringBuilder.AppendLine($"    Power: {this.Engine.Power}");
        stringBuilder.AppendLine($"    Displacement: {this.Engine.Displacement}");
        stringBuilder.AppendLine($"    Efficiency: {this.Engine.Efficiency}");
        stringBuilder.AppendLine($"  Weight: {this.Weight}");
        stringBuilder.Append($"  Color: {this.Color}");

        return stringBuilder.ToString();
    }
}