using System;

public class Seat : Car, ICar
{
    public Seat(string model, string color)
        : base (model, color)
    {

    }

    public override string ToString()
    {
        return $"{this.Color} {nameof(Seat)} {this.Model}" +
            Environment.NewLine +            
            base.ToString();
    }
}