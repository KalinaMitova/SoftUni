using System;

public class UltrasoftTyre : Tyre
{
    private double grip;

    public UltrasoftTyre(double hardness, double grip)
        : base(hardness)
    {
        this.Grip = grip;
    }

    public override string Name => "Ultrasoft";

    public override double Degradation
    {
        get => base.Degradation;
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Blown Tyre");
            }
            base.Degradation = value;
        }
    }

    public double Grip
    {
        get { return grip; }
        private set { grip = value; }
    }

    public override void ReduceDegradation()
    {
        this.Degradation -= (this.Hardness + this.Grip);
    }
}