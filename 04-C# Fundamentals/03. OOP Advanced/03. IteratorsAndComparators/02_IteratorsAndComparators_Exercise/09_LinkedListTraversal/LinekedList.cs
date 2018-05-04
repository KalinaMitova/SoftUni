namespace _09_LinkedListTraversal
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinekеdList<T> : IEnumerable<T>
    {
        public class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }
            public Node Next { get; set; }
        }

        public Node Head { get; private set; }
        public Node Tail { get; private set; }
        public int Count { get; private set; }

        public void Add(T item)
        {
            Node old = this.Tail;
            this.Tail = new Node(item);

            if (this.Count == 0)
            {
                this.Head = this.Tail;
            }
            else
            {
                old.Next = this.Tail;
            }

            this.Count++;
        }

        public bool Remove(T itemToRemove)
        {
            if(this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            
            Node current = this.Head;
            Node prev = this.Head;

            while (current != null)
            {
                if (current.Value.Equals(itemToRemove))
                {
                    if(this.Count == 1)
                    {
                        this.Head = this.Tail = null;
                    }
                    else if (this.Head == current)
                    {
                        this.Head = this.Head.Next;
                    }
                    else
                    {
                        prev.Next = current.Next;
                    }

                    this.Count--;
                    return true;
                }

                prev = current;
                current = current.Next;
            }

            if(this.Count == 0)
            {
                this.Tail = null;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = this.Head;
            while(current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
