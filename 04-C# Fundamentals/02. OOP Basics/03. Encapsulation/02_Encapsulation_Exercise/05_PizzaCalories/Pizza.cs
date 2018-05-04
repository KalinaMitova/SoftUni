using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public string Name
    {
        get { return name; }
        set
        {
            if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            name = value;
        }
    }

    public Dough Dough
    {
        get { return dough; }
        set { dough = value; }
    }
    
    private List<Topping> Toppings
    {
        get { return toppings; }
        set { toppings = value; }
    }

    public double TotalCalories => this.dough.CalculateTotalCalories() + this.Toppings.Sum(t => t.CalculateTotalCalories());
    
    public Pizza(string name)
    {
        this.Name = name;
        this.Toppings = new List<Topping>();
    }

    public void AddTopping(Topping topping)
    {
        if (this.Toppings.Count() == 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        this.toppings.Add(topping);
    }
}