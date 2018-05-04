using System;

public class Box
{
    private decimal length;
    private decimal width;
    private decimal height;

    public decimal Length
    {
        get
        {
            return this.length;
        }
        private set
        {
            ValidateSide("Length", value);
            this.length = value;
        }
    }

    public decimal Width
    {
        get
        {
            return this.width;
        }
        private set
        {
            ValidateSide("Width", value);
            this.width = value;
        }
    }

    public decimal Height
    {
        get
        {
            return this.height;
        }
        private set
        {
            ValidateSide("Height", value);
            this.height = value;
        }
    }

    public Box(decimal length, decimal width, decimal height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    private void ValidateSide(string sideName, decimal value)
    {
        if (value <= 0)
        {
            throw new ArgumentException($"{sideName} cannot be zero or negative.");
        }
    }
    
    public decimal SurfaceArea()
    {
        return 2 * length * width + 2 * length * height + 2 * width * height;
    }
    
    public decimal LateralSurfaceArea()
    {
        return 2 * length * height + 2 * width * height;
    }

    public decimal Volume()
    {
        return length * width * height;
    }
}