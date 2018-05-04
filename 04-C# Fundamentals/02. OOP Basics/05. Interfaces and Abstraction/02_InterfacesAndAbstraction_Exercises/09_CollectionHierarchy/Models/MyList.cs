using System.Collections.Generic;

public class MyList : ICollect, IAddable, IRemovable, ICountable
{
    private Stack<string> collection;

    public MyList()
    {
        this.collection = new Stack<string>(100);
    }

    public IReadOnlyCollection<string> Collection => (IReadOnlyCollection<string>)collection;

    public int Add(string item)
    {
        collection.Push(item);

        return 0;
    }

    public string Remove()
    {
        return collection.Pop();
    }

    public int Used()
    {
        return this.collection.Count;
    }
}
