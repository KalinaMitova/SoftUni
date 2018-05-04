namespace _01_Database
{
    using System;

    public class Database
    {
        private const int maxDataSize = 16;

        private int[] data;
        private int currentIndex;

        public Database()
        {
            this.data = new int[maxDataSize];
            this.currentIndex = 0;
        }

        public Database(params int[] elements)
            : this()
        {
            foreach (var element in elements)
            {
                this.Add(element);
            }

            this.currentIndex = elements.Length;
        }

        public void Add(int element)
        {
            if(this.currentIndex == maxDataSize)
            {
                throw new InvalidOperationException("Array is full!");
            }
            
            this.data[currentIndex] = element;
            currentIndex++;
        }

        public void Remove()
        {
            if(currentIndex == 0)
            {
                throw new InvalidOperationException("Array is empty!");
            }

            currentIndex--;
            this.data[currentIndex] = default(int);
        }

        public int[] Fetch()
        {
            int[] elements = new int[currentIndex];

            Array.Copy(this.data, elements, currentIndex);

            return elements;
        }
    }
}
