using System;

public class Dough
{
    private const double BASE_CALORIES_PER_GRAM = 2d;

    private double flourModifier;
    private double bakingTechniqueModifier;

    private string flourType;
    private string bakingTechnique;
    private double weight;

    public string FlourType
    {
        get { return flourType; }
        set
        {
            if(value.ToLower() == "white" || value.ToLower() == "wholegrain")
            {
                flourType = value;
            }
            else
            {
                throw new ArgumentException("Invalid type of dough.");
            }
        }
    }
    
    public string BakingTechnique
    {
        get { return bakingTechnique; }
        set
        {
            if (value.ToLower() == "crispy" || value.ToLower() == "chewy" || value.ToLower() == "homemade")
            {
                bakingTechnique = value;
            }
            else
            {
                throw new ArgumentException("Invalid type of dough.");
            }
        }
    }
    
    public double Weight
    {
        get { return weight; }
        set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }

            weight = value;
        }
    }
    
    public Dough(string flourType, string bakingTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;

        switch (this.flourType.ToLower())
        {
            case "white":
                flourModifier = 1.5d;
                break;
            case "wholegrain":
                flourModifier = 1d;
                break;
        }

        switch (this.bakingTechnique.ToLower())
        {
            case "crispy":
                this.bakingTechniqueModifier = 0.9d;
                break;
            case "chewy":
                this.bakingTechniqueModifier = 1.1d;
                break;
            case "homemade":
                this.bakingTechniqueModifier = 1d;
                break;
        }
    }

    public double CalculateTotalCalories()
    {
        return (BASE_CALORIES_PER_GRAM  * this.weight) * this.flourModifier * this.bakingTechniqueModifier;
    }
}