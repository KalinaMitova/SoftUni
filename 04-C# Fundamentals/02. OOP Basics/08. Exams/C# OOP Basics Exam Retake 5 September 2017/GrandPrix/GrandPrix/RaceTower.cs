using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private int lapsNumber;
    private int trackLength;

    public int currentLap = 0;
    private string weather = "Sunny";

    private List<Driver> drivers;
    private Stack<Driver> crashedDrivers;
    
    public RaceTower()
    {
        this.drivers = new List<Driver>();
        this.crashedDrivers = new Stack<Driver>();
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.lapsNumber = lapsNumber;
        this.trackLength = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        string driverType = commandArgs[0];
        string driverName = commandArgs[1];

        int hp = int.Parse(commandArgs[2]);
        double fuelAmount = double.Parse(commandArgs[3]);

        var tyreArguments = commandArgs.Skip(4).Take(commandArgs.Count - 4).ToList();

        try
        {
            Tyre tyre = TyreFactory.GetType(tyreArguments);
            Car car = new Car(hp, fuelAmount, tyre);
            Driver driver = DriverFactory.GetType(driverType, driverName, car);

            drivers.Add(driver);
        }
        catch (ArgumentException ex)
        {
            
        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string reasonToBox = commandArgs[0];
        string driversName = commandArgs[1];

        Driver driver = this.drivers.Find(d => d.Name == driversName);

        if(reasonToBox == "ChangeTyres")
        {
            var tyreArgs = commandArgs.Skip(2).Take(commandArgs.Count - 2).ToList();

            Tyre tyre = TyreFactory.GetType(tyreArgs);

            driver.Car.ChangeTyres(tyre);
        }
        else if(reasonToBox == "Refuel")
        {
            double fuelAmount = double.Parse(commandArgs[2]);

            driver.Car.RefillFuel(fuelAmount);
        }

        driver.TotalTime += 20;
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        StringBuilder sb = new StringBuilder();

        int numberOfLaps = int.Parse(commandArgs[0]);
        int leftLaps = this.lapsNumber - this.currentLap;

        if(numberOfLaps > leftLaps)
        {
            return $"There is no time! On lap {this.currentLap}.";
        }

        for (int i = 1; i <= numberOfLaps; i++)
        {
            this.currentLap++;

            for (int j = 0; j < this.drivers.Count; j++)
            {
                Driver driver = this.drivers[j];

                driver.TotalTime += 60 / (this.trackLength / driver.Speed);

                try
                {
                    driver.Car.ReduceFuel(this.trackLength, driver.FuelConsumptionPerKm);
                    driver.Car.Tyre.ReduceDegradation();
                }
                catch (ArgumentException ex)
                {
                    MarkAsCrashedDriver(driver, ex.Message);
                    j--;
                }
            }

            this.drivers = this.drivers.OrderByDescending(d => d.TotalTime).ToList();

            for (int j = 0; j < this.drivers.Count - 1; j++)
            {
                var currentDriver = this.drivers[j];
                var frontDriver = this.drivers[j + 1];

                int interval = 2;

                if(currentDriver is AggressiveDriver && currentDriver.Car.Tyre is UltrasoftTyre)
                {
                    interval = 3;
                    if(this.weather == "Foggy")
                    {
                        MarkAsCrashedDriver(currentDriver, "Crashed");
                        j--;
                        continue;
                    }
                }
                else if(currentDriver is EnduranceDriver && currentDriver.Car.Tyre is HardTyre)
                {
                    interval = 3;
                    if(this.weather == "Rainy")
                    {
                        MarkAsCrashedDriver(currentDriver, "Crashed");
                        j--;
                        continue;
                    }
                }

                if (currentDriver.TotalTime - frontDriver.TotalTime <= interval)
                {
                    currentDriver.TotalTime -= interval;
                    frontDriver.TotalTime += interval;
                    sb.AppendLine($"{currentDriver.Name} has overtaken {frontDriver.Name} on lap {this.currentLap}.");                   
                }
            }
        }

        return sb.ToString().Trim();
    }

    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Lap {this.currentLap}/{this.lapsNumber}");

        var orederedDrivers = this.drivers.OrderBy(d => d.TotalTime);

        var driverPosition = 0;
        
        foreach (var driver in orederedDrivers)
        {
            driverPosition++;
            sb.AppendLine($"{driverPosition} {driver.Name} {driver.TotalTime:F3}");
        }

        foreach (var crashedDriver in this.crashedDrivers)
        {

            driverPosition++;
            sb.AppendLine($"{driverPosition} {crashedDriver.Name} {crashedDriver.FailureMessage}");
        }
                
        return sb.ToString().Trim();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        string weather = commandArgs[0];

        this.weather = weather;
    }

    public Driver GetWinner()
    {
        return this.drivers.OrderBy(d => d.TotalTime).First();
    }

    private void MarkAsCrashedDriver(Driver driver, string message)
    {
        driver.IsCrashed = true;
        driver.FailureMessage = message;
        this.crashedDrivers.Push(driver);
        this.drivers.Remove(driver);
    }
}