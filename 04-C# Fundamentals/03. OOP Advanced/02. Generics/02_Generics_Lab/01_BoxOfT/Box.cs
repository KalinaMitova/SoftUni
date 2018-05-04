using System;
using System.Collections.Generic;
using System.Text;

public class Box<T>
{
    private Stack<T> stack;

    public Box()
    {
        this.stack = new Stack<T>();
    }

    public void Add(T element)
    {
        this.stack.Push(element);
    }

    public T Remove()
    {
        T element = this.stack.Pop();
        return element;
    }

    public int Count => this.stack.Count;
}
