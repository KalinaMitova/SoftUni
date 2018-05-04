public class Position
{
    private int row;
    private int col;

    public int Row
    {
        get { return row; }
        set { row = value; }
    }

    public int Col
    {
        get { return col; }
        set { col = value; }
    }

    public Position()
    {

    }

    public Position(int row, int col)
    {
        Row = row;
        Col = col;
    }
}