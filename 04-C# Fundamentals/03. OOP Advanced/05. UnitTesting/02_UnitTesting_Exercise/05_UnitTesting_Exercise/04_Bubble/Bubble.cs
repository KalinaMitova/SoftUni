namespace _04_BubbleSort
{
    using System;

    public class Bubble<T> where T : IComparable
    {
        public T[] Sort(T[] array)
        {
            T[] sortedArray = new T[array.Length];
            Array.Copy(array, sortedArray, array.Length);

            int counter = 1;
            while (counter < array.Length)
            {
                for (int i = 0; i < array.Length - counter; i++)
                {
                    if (array[i].CompareTo(array[i + 1]) > 0)
                    {
                        this.Swap(array, i);
                    }
                }

                counter++;
            }

            return sortedArray;
        }

        private void Swap(T[] array, int index)
        {
            T swapper = array[index];
            array[index] = array[index + 1];
            array[index + 1] = swapper;
        }
    }
}
