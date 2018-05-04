using System.Collections.Generic;

public class AddRemoveCollection : ICollect, IAddable, IRemovable
{
    private Queue<string> collection;

    public AddRemoveCollection()
    {
        this.collection = new Queue<string>(100);
    }

    public IReadOnlyCollection<string> Collection => (IReadOnlyCollection<string>)collection;

    public int Add(string item)
    {
        collection.Enqueue(item);

        return 0;
    }

    public string Remove()
    {
        return collection.Dequeue();
    }
}