using System;

public class Topping
{
    private const double BASE_CALORIES_PER_GRAM = 2d;

    private double modifier;

    private string type;
    private double weight;

    public string Type
    {
        get { return type; }
        set
        {
            switch (value.ToLower())
            {
                case "meat":
                case "veggies":
                case "cheese":
                case "sauce":
                    type = value;
                    break;
                default:
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
        }
    }
    
    public double Weight
    {
        get { return weight; }
        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
            }
            weight = value;
        }
    }

    public Topping(string type, double weight)
    {
        this.Type = type;
        this.Weight = weight;

        switch (this.Type.ToLower())
        {
            case "meat":
                this.modifier = 1.2d;
                break;
            case "veggies":
                this.modifier = 0.8d;
                break;
            case "cheese":
                this.modifier = 1.1d;
                break;
            case "sauce":
                this.modifier = 0.9d;
                break;
        }
    }


    public double CalculateTotalCalories()
    {
        return (BASE_CALORIES_PER_GRAM * this.weight) * this.modifier;
    }
}