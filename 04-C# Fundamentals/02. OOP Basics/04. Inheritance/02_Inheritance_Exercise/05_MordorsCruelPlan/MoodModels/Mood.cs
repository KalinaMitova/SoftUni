using System.Text;

public class Mood
{
    private int pointsOfHappiness;

    public virtual int PointsOfHapiness
    {
        get { return pointsOfHappiness; }
        set { pointsOfHappiness = value; }
    }

    public virtual string Name => "";

    public Mood(int pointsOfHappiness)
    {
        this.PointsOfHapiness = pointsOfHappiness;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(this.PointsOfHapiness.ToString());
        sb.AppendLine(this.Name);

        return sb.ToString().TrimEnd();
    }
}