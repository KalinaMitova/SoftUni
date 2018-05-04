﻿public abstract class Mammal : Animal, IMammal
{
    private string livingRegion;

    public Mammal(string name, double weight, string livingRegion)
        : base(name, weight)
    {
        this.LivingRegion = livingRegion;
    }

    public string LivingRegion
    {
        get { return livingRegion; }
        set { livingRegion = value; }
    }

    public override string ToString()
    {
        string output = $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        return output;
    }
}