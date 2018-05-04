public class DrawingTool
{
    private Figure figure;

    public Figure Figure
    {
        get { return figure; }
        set { figure = value; }
    }

    public DrawingTool(Figure figure)
    {
        this.Figure = figure;
    }

    public void Draw()
    {
        for (int i = 0; i < figure.B; i++)
        {
            System.Console.WriteLine($"|{new string(i == 0 || i == Figure.B - 1 ? '-' : ' ', Figure.A)}|");
        }
    }
}
