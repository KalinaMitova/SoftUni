public class Gem
{
    private GemEnums name;
    private long _value;

    public GemEnums Name
    {
        get { return name; }
        set { name = value; }
    }
    
    public long Value
    {
        get { return _value; }
        set { _value = value; }
    }

    public Gem(GemEnums name, long value)
    {
        Name = name;
        Value = value;
    }
}