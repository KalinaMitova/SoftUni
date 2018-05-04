using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomList<T> : IEnumerable<T> where T : IComparable<T>
{
    private IList<T> collection;

    public CustomList()
    {
        this.collection = new List<T>();
    }

    public CustomList(IList<T> list)
    {
        this.collection = list;
    }

    public void Add(T element)
    {
        this.collection.Add(element);
    }

    public T Remove(int index)
    {
        T element = this.collection[index];
        this.collection.RemoveAt(index);
        return element;
    }

    public bool Contains(T element)
    {
        return this.collection.Contains(element);
    }

    public void Swap(int index1, int index2)
    {
        var swaper = this.collection[index1];
        this.collection[index1] = this.collection[index2];
        this.collection[index2] = swaper;
    }

    public int CountGreaterThan(T element)
    {
        int counter = 0;

        foreach (var el in this.collection)
        {
            if (el.CompareTo(element) > 0)
            {
                counter++;
            }
        }

        return counter;
    }

    public T Max()
    {
        T maxElement = this.collection.Max();
        return maxElement;
    }

    public T Min()
    {
        T minElement = this.collection.Min();
        return minElement;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.collection.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.collection.GetEnumerator();
    }
}