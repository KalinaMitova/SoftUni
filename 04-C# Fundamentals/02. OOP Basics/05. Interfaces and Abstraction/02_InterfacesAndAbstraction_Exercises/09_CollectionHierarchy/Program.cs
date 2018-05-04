using System;

namespace _09_CollectionHierarchy
{
    public class Program
    {
        public static void Main()
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            string[] items = Console.ReadLine().Split();
            int removeCount = int.Parse(Console.ReadLine());

            int[] addCollectionIndexes = new int[items.Length];
            int[] addRemoveCollectionIndexes = new int[items.Length];
            int[] myListIndexes = new int[items.Length];

            for (int i = 0; i < items.Length; i++)
            {
                addCollectionIndexes[i] = addCollection.Add(items[i]);
                addRemoveCollectionIndexes[i] = addRemoveCollection.Add(items[i]);
                myListIndexes[i] = myList.Add(items[i]);
            }

            string[] removedStringsFromAddRemoveCollection = new string[removeCount];
            string[] removedStringsFromMyList = new string[removeCount];

            for (int i = 0; i < removeCount; i++)
            {
                removedStringsFromAddRemoveCollection[i] = addRemoveCollection.Remove();
                removedStringsFromMyList[i] = myList.Remove();
            }
            
            Console.WriteLine(string.Join(" ", addCollectionIndexes));
            Console.WriteLine(string.Join(" ", addRemoveCollectionIndexes));
            Console.WriteLine(string.Join(" ", myListIndexes));
            Console.WriteLine(string.Join(" ", removedStringsFromAddRemoveCollection));
            Console.WriteLine(string.Join(" ", removedStringsFromMyList));
        }
    }
}
