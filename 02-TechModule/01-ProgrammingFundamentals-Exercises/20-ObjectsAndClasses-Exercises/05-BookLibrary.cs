using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _05_BookLibrary
{
    class Program
    {
        class Library
        {
            public string Name { get; set; }
            public List<Book> Books { get; set; }

            public decimal totalSum
            {
                get
                {
                    return Books.Sum(book => book.Price);
                }
            }
        }

        class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public string Publisher { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string ISBN { get; set; }
            public decimal Price { get; set; }
        }

        static void Main(string[] args)
        {
            var books = GetBooks();

            var libraries = new List<Library>();

            foreach (var book in books)
            {
                libraries.Add(new Library
                {
                    Name = book.Key,
                    Books = book.Value
                });
            }

            foreach (var library in libraries
                .OrderByDescending(lib => lib.totalSum)
                .ThenBy(lib => lib.Name))
            {
                Console.WriteLine($"{library.Name} -> {library.totalSum:F2}");
            }
        }

        private static Dictionary<string, List<Book>> GetBooks()
        {
            var lib = new Dictionary<string, List<Book>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split();

                var currentBook = new Book
                {
                    Title = line[0],
                    Author = line[1],
                    Publisher = line[2],
                    ReleaseDate = DateTime.ParseExact(line[3], "dd.MM.yyyy", CultureInfo.InvariantCulture),
                    ISBN = line[4],
                    Price = decimal.Parse(line[5])
                };

                if (!lib.ContainsKey(line[1]))
                {
                    lib[line[1]] = new List<Book>();
                }
                lib[line[1]].Add(currentBook);
            }

            return lib;
        }
    }
}
