using System;

public class HardTyre : Tyre
{
    public HardTyre(double hardness) 
        : base(hardness)
    {
    }

    public override string Name => "Hard";
    
    public override void ReduceDegradation()
    {
        this.Degradation -= this.Hardness;
    }
}