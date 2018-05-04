using System;

public class Car
{
    private int hp;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp
    {
        get { return hp; }
        private set { hp = value; }
    }

    public double FuelAmount
    {
        get { return fuelAmount; }
        private set
        {
            if (value > 160)
            {
                this.fuelAmount = 160;
            }
            else if(value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }
            else
            {
                this.fuelAmount = value;
            }
        }
    }
    
    public Tyre Tyre
    {
        get { return tyre; }
        private set { tyre = value; }
    }

    public void ReduceFuel(double trackLength, double fuelConsumption)
    {
        this.FuelAmount -= trackLength * fuelConsumption;
    }

    public void ChangeTyres(Tyre tyre)
    {
        this.Tyre = tyre;
    }

    public void RefillFuel(double amount)
    {
        this.FuelAmount += amount;
    }
}