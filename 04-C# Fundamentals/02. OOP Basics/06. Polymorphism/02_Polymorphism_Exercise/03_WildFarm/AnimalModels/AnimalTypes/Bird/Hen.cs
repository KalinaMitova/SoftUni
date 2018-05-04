public class Hen : Bird
{
    public Hen(string name, double weight, double wingSize) 
        : base(name, weight, wingSize)
    {

    }

    public override double WeightPerEatenFood => 0.35d;
    
    public override void Eat(Food food)
    {
        this.FoodEaten += food.Quantity;
        this.Weight += WeightPerEatenFood * food.Quantity;
    }

    public override string ProduceSound()
    {
        return "Cluck";
    }
}