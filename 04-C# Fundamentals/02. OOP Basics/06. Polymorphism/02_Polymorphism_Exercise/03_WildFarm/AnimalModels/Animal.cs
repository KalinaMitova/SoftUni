using System.Collections.Generic;

public abstract class Animal : IAnimal, IEatable, ISoundProducible
{
    private string name;
    private double weight;
    private int foodEaten;

    public Animal(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = 0;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public int FoodEaten
    {
        get { return foodEaten; }
        set { foodEaten = value; }
    }

    public abstract double WeightPerEatenFood { get; }
    
    public abstract void Eat(Food food);

    public abstract string ProduceSound();
}