using System;

public class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    {

    }

    public override double WeightPerEatenFood => 0.40d;

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
        return "Woof!";
    }
}