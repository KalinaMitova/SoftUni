using System;
using System.Collections;
using System.Collections.Generic;

namespace _03_Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] data;
        private int index;

        public Stack()
        {
            this.data = new T[0];
            this.index = -1;
        }

        public void Push(params T[] elements)
        {
            ExtendCollection(elements.Length);
            for (int i = 0; i < elements.Length; i++)
            {
                this.index++;
                this.data[this.index] = elements[i];
            }
        }

        public T Pop()
        {
            if (this.index < 0)
            {
                throw new ArgumentException("No elements");
            }

            T lastElement = this.data[this.data.Length - 1];
            this.data[this.data.Length - 1] = default(T);
            this.index--;

            return lastElement;
        }

        private void ExtendCollection(int neededSpace)
        {
            if(this.data.Length < this.index + neededSpace + 1)
            {
                var newData = new T[this.index + neededSpace + 1];
                Array.Copy(this.data, newData, this.index + 1);
                this.data = newData;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.index; i >= 0; i--)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
