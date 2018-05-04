public abstract class Ammunition : IAmmunition
{
    public Ammunition()
    {
        this.WearLevel = this.Weight * 100;
    }

    public string Name => this.GetType().Name;

    public abstract double Weight { get; }

    public double WearLevel { get; private set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }
}