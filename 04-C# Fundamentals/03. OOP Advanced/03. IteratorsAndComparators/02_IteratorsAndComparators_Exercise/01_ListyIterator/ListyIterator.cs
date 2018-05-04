using System;
using System.Collections.Generic;

public class ListyIterator<T>
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

    public void Print()
    {
        if(this.index < 0 || this.index > this.data.Count - 1)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        Console.WriteLine(this.data[index]);
    }

    public bool HasNext()
    {
        return this.index < this.data.Count - 1;
    }
}