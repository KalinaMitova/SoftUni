using System.Collections.Generic;

public class Car
{
    private string model;
    private int engineSpeed;
    private int enginePower;
    private int cargoWeight;
    private string cargoType;
    private List<Tire> tires;
    
    public string Model
    {
        get { return model; }
        set { model = value; }
    }
    
    public int EngineSpeed
    {
        get { return engineSpeed; }
        set { engineSpeed = value; }
    }
    
    public int EnginePower
    {
        get { return enginePower; }
        set { enginePower = value; }
    }
    
    public int CargoWeight
    {
        get { return cargoWeight; }
        set { cargoWeight = value; }
    }
    
    public string CargoType
    {
        get { return cargoType; }
        set { cargoType = value; }
    }
    
    public List<Tire> Tires
    {
        get { return tires; }
        set { tires = value; }
    }
    
    public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, List<Tire> tires)
    {
        this.Model = model;
        this.EngineSpeed = engineSpeed;
        this.EnginePower = enginePower;
        this.CargoWeight = cargoWeight;
        this.CargoType = cargoType;
        this.Tires = tires;
    }
}