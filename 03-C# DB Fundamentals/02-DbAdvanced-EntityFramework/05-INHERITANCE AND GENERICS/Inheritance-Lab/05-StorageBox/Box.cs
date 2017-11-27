using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_StorageBox
{
    class Box<T>
    {
        private T[] data;
        private int count;

        public Box()
        {
            this.Data = new T[4];
            this.Count = 0;
        }

        public T[] Data
        {
            get
            {
                return this.data;
            }
            private set
            {
                this.data = value;
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }
            private set
            {
                if(value > this.Data.Length)
                {
                    throw new ArgumentException("Collection is full.");
                }
                this.count = value;
            }
        }

        public void Add(T element)
        {
            if(this.Count >= this.Data.Length)
            {
                var newData = new T[this.Data.Length * 2];
                this.data.CopyTo(newData, 0);
                this.data = newData;
            }

            this.data[this.Count] = element;
            count++;
        }

        public T Remove()
        {
            var index = this.Count - 1;
            T lastElement = this.Data[index];
            this.Data[index] = default(T);
            count--;
            return lastElement;
        }

        public override string ToString()
        {
            return string.Join(", ", this.Data.Take(this.Count));
        }
    }
}
