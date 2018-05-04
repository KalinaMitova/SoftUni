using System.Collections.Generic;

public class AddCollection : ICollect , IAddable
{
    private List<string> collection;

    public AddCollection()
    {
        this.collection = new List<string>(100);
    }

    public IReadOnlyCollection<string> Collection => (IReadOnlyCollection<string>)collection;

    public int Add(string item)
    {
        collection.Add(item);

        return collection.Count - 1;
    }
}