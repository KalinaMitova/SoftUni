using System;
using System.Collections.Generic;

public static class TyreFactory
{
    public static Tyre GetType(List<string> arguments)
    {
        string type = arguments[0];
        double hardness = double.Parse(arguments[1]);

        switch (type)
        {
            case "Hard":
                return new HardTyre(hardness);
            case "Ultrasoft":
                double grip = double.Parse(arguments[2]);
                return new UltrasoftTyre(hardness, grip);
            default:
                throw new ArgumentException();
        }
    }
}