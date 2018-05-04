public class Rectangle : Shape
{
    public Rectangle(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public double Width { get; set; }

    public double Height { get; set; }

    public override double CalculateArea()
    {
        return this.Width * 2 + this.Height * 2;
    }

    public override double CalculatePerimeter()
    {
        return this.Width * this.Height;
    }

    public override string Draw()
    {
        return base.Draw() + "Rectangle";
    }
}