using System;

public class DateModifier
{
    private DateTime firstDate;
    private DateTime secondDate;

    public DateTime FirstDate
    {
        get { return firstDate; }
        set { firstDate = value; }
    }

    public DateTime SecondDate
    {
        get { return secondDate; }
        set { secondDate = value; }
    }

    public DateModifier(DateTime first, DateTime second)
    {
        this.firstDate = first;
        this.secondDate = second;
    }

    public double DateDiff()
    {
        return Math.Abs((firstDate - secondDate).TotalDays);
    }
}
