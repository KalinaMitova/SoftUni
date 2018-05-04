using System;

public class Tesla : Car, ICar, IElectricCar
{
    public int Battery { get; set; }

    public Tesla(string model, string color, int battery)
        : base(model, color)
    {
        this.Battery = battery;
    }

    public override string ToString()
    {
        return $"{this.Color} {nameof(Tesla)} {this.Model} with {this.Battery} Batteries" +
            Environment.NewLine +
            base.ToString();
    }
}