using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerable<T>
{
    private List<T> data;
    private int index;

    public ListyIterator(List<T> data)
    {
        this.data = data;
        this.index = 0;
    }
    
    public bool Move()
    {
        if(this.index == data.Count - 1)
        {
            return false;
        }
        index++;
        return true;
    }

    public bool HasNext()
    {
        return this.index < this.data.Count - 1;
    }

    public void Print()
    {
        if (this.index < 0 || this.index > this.data.Count - 1)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        Console.WriteLine(this.data[index]);
    }

    public void PrintAll()
    {
        Console.WriteLine(string.Join(" ", this.data));
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.data.Count; i++)
        {
            yield return this.data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}