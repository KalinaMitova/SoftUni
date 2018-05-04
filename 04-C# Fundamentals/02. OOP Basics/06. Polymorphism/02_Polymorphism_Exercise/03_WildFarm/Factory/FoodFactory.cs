using System;

public class FoodFactory
{
    public Food GetType(string[] tokens)
    {
        string foodType = tokens[0];
        int quantity = int.Parse(tokens[1]);

        switch (foodType)
        {
            case "Fruit":
                {
                    return new Fruit(quantity);
                }
            case "Meat":
                {
                    return new Meat(quantity);
                }
            case "Seeds":
                {
                    return new Seeds(quantity);
                }
            case "Vegetable":
                {
                    return new Vegetable(quantity);
                }
            default:
                throw new ArgumentException("Invalid type of food!");
        }
    }
}