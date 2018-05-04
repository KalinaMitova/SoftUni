namespace BashSoftProgram.DataStructures
{
    using System.Collections.Generic;

    public static class QuickSort<T>
    {
        public static void Sort(T[] elements, int left, int right, IComparer<T> comparer)
        {
            int i = left, j = right;
            T pivot = elements[(left + right) / 2];
            
            while (i <= j)
            {
                while (comparer.Compare(elements[i], pivot) < 0)
                {
                    i++;
                }

                while (comparer.Compare(elements[j], pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    T tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                Sort(elements, left, j, comparer);
            }

            if (i < right)
            {
                Sort(elements, i, right, comparer);
            }
        }
    }
}
