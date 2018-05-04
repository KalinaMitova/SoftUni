using System;

public abstract class Tyre
{
    private double hardness;
    private double degradation;

    protected Tyre(double hardness)
    {
        this.Hardness = hardness;
        this.Degradation = 100;
    }

    public abstract string Name { get; }

    public double Hardness
    {
        get { return hardness; }
        private set { hardness = value; }
    }

    public virtual double Degradation
    {
        get { return this.degradation; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Blown Tyre");
            }
            this.degradation = value;
        }
    }

    public abstract void ReduceDegradation();
}