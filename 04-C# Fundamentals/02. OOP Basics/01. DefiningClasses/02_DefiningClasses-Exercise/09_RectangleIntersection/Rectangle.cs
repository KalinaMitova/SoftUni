public class Rectangle
{
    public string Id { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double X { get; set; }
    public double Y { get; set; }

    public Rectangle(string id, double width, double height, double x, double y)
    {
        this.Id = id;
        this.Width = width;
        this.Height = height;
        this.X = x;
        this.Y = y;
    }

    public bool isIntersect(Rectangle rectangle)
    {
        bool a = (rectangle.X + rectangle.Width) >= this.X;
        bool b = rectangle.X <= (this.X + this.Width);
        bool c = (rectangle.Y + rectangle.Width) >= this.Y;
        bool d = rectangle.Y <= (this.Y + this.Height);

        return a && b && c && d;
    }
}