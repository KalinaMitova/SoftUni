using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Cat> cats = new List<Cat>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string breed = tokens[0];
            string name = tokens[1];

            Cat cat;
            switch (breed)
            {
                case "Siamese":
                    {
                        int earSize = int.Parse(tokens[2]);
                        cat = new Siamese(breed, name, earSize);
                    }
                    break;
                case "Cymric":
                    double furLength = double.Parse(tokens[2], CultureInfo.InvariantCulture);
                    cat = new Cymric(breed, name, furLength);
                    break;
                case "StreetExtraordinaire":
                    int decibelsOfMeows = int.Parse(tokens[2]);
                    cat = new StreetExtraordinaire(breed, name, decibelsOfMeows);
                    break;
                default:
                    continue;
            }
            cats.Add(cat);
        }

        string catName = Console.ReadLine();

        Cat catToPrint = cats.Single(c => c.Name == catName);

        Console.WriteLine(catToPrint);
    }
}