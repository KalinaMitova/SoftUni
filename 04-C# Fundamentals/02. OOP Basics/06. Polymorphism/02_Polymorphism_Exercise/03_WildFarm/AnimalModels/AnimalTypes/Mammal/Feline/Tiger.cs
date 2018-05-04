using System;

public class Tiger : Feline
{
    public Tiger(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed)
    {

    }

    public override double WeightPerEatenFood => 1.0d;

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
        return "ROAR!!!";
    }
}