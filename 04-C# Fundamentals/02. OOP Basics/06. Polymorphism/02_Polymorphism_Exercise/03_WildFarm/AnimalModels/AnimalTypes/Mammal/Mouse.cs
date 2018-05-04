using System;

public class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    {

    }

    public override double WeightPerEatenFood => 0.10d;

    public override void Eat(Food food)
    {
        if (!(food is Vegetable) && !(food is Fruit))
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        this.FoodEaten += food.Quantity;
        this.Weight += WeightPerEatenFood * food.Quantity;
    }

    public override string ProduceSound()
    {
        return "Squeak";
    }
}