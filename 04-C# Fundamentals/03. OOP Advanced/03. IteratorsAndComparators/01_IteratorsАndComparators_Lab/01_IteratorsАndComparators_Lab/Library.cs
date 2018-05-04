using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Library : IEnumerable<Book>
{
    private SortedSet<Book> books;

    public Library(params Book[] books)
    {
        this.books = new SortedSet<Book>(books, new BookComparator());
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.books.ToList());
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;

        private int index;

        public LibraryIterator(List<Book> books)
        {
            this.index = -1;
            this.books = books;
        }

        public int Count => this.books.Count;

        public Book Current => this.books[this.index];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            this.index++;
            return this.index < this.Count;
        }

        public void Reset()
        {
            this.index = -1;
        }
    }
}

