public abstract class MainId
{
    private string id;

    public MainId(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get { return id; }
        protected set { id = value; }
    }

}