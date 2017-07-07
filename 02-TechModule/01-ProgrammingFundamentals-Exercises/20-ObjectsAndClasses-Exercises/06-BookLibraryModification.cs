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

            var afterDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            foreach (var book in books
                .OrderBy(book => book.ReleaseDate)
                .ThenBy(book => book.Title))
            {
                if (book.ReleaseDate > afterDate)
                {
                    Console.WriteLine($"{book.Title} -> {book.ReleaseDate:dd.MM.yyyy}");
                }
            }

        }

        private static List<Book> GetBooks()
        {
            var books = new List<Book>();

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

                books.Add(currentBook);
            }

            return books;
        }
    }
}
