using System;
using System.Collections.Generic;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> products;

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }
    
    public decimal Money
    {
        get { return money; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            money = value;
        }
    }

    private List<Product> Products
    {
        get { return products; }
        set { products = value; }
    }

    public Person()
    {
        Products = new List<Product>();
    }

    public Person(string name, decimal money) : this()
    {
        Name = name;
        Money = money;
    }

    public void BuyProduct(Product product)
    {
        if(Money < product.Cost)
        {
            Console.WriteLine($"{Name} can't afford {product.Name}");
        }
        else
        {
            Money -= product.Cost;
            Products.Add(product);
            Console.WriteLine($"{Name} bought {product.Name}");
        }
    }

    public override string ToString()
    {
        if (products.Count == 0)
        {
            return $"{Name} - Nothing bought";
        }

        return $"{Name} - {string.Join(", ", products)}";
    }
}