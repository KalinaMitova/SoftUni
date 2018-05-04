using System;

public class Owl : Bird
{
    public Owl(string name, double weight, double wingSize) 
        : base(name, weight, wingSize)
    {

    }

    public override double WeightPerEatenFood => 0.25d;

    public override void Eat(Food food)
    {
        if (!(food is Meat))
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        this.FoodEaten += food.Quantity;
        this.Weight += WeightPerEatenFood * food.Quantity;
    }

    public override string ProduceSound()
    {
        return "Hoot Hoot";
    }
}