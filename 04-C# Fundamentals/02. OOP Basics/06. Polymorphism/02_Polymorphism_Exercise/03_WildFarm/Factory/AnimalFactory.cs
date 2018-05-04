﻿using System;

public class AnimalFactory
{
    public Animal GetType(string[] tokens)
    {
        string type = tokens[0];
        string name = tokens[1];
        double weight = double.Parse(tokens[2]);

        switch (type)
        {
            case "Hen":
                {
                    double wingSize = double.Parse(tokens[3]);
                    return new Hen(name, weight, wingSize);
                }
            case "Owl":
                {
                    double wingSize = double.Parse(tokens[3]);
                    return new Owl(name, weight, wingSize);
                }
            case "Dog":
                {
                    string livingRegion = tokens[3];
                    return new Dog(name, weight, livingRegion);
                }
            case "Mouse":
                {
                    string livingRegion = tokens[3];
                    return new Mouse(name, weight, livingRegion);
                }
            case "Cat":
                {
                    string livingRegion = tokens[3];
                    string breed = tokens[4];
                    return new Cat(name, weight, livingRegion, breed);
                }
            case "Tiger":
                {
                    string livingRegion = tokens[3];
                    string breed = tokens[4];
                    return new Tiger(name, weight, livingRegion, breed);
                }
            default:
                throw new ArgumentException("Invalid type of animal!");
        }
    }
}