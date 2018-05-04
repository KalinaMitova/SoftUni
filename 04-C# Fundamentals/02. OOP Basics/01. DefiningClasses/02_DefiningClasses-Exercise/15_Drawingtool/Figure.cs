public class Figure
{
    private int a;
    private int b;

    public int A
    {
        get { return a; }
        set { a = value; }
    }

    public int B
    {
        get { return b; }
        set { b = value; }
    }

    public Figure()
    {

    }

    public Figure(int a, int b)
    {
        this.A = a;
        this.B = b;
    }
}