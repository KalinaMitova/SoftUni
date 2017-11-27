namespace BookShop
{
    using System;
    using BookShop.Data;
    using BookShop.Models;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;
    using BookShop.Initializer;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
            }
        }

        //1. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            command = command.ToLower();

            AgeRestriction? ageRestriction = null;

            switch (command)
            {
                case "minor":
                    ageRestriction = AgeRestriction.Minor;
                    break;
                case "teen":
                    ageRestriction = AgeRestriction.Teen;
                    break;
                case "adult":
                    ageRestriction = AgeRestriction.Adult;
                    break;
            }

            if (ageRestriction == null)
            {
                return string.Empty;
            }

            var bookTitles = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            string output = string.Join(Environment.NewLine, bookTitles);

            return output;
        }

        //2. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            string output = string.Join(Environment.NewLine, books);

            return output;
        }

        //3. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new { b.Title, b.Price })
                .ToList();

            var output = string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - ${b.Price:F2}"));

            return output;
        }

        //4. Not Released In
        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            var output = string.Join(Environment.NewLine, books);

            return output;
        }

        //5. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.Split().Select(c => c.ToLower()).ToArray();

            var books = context.Books
                .Where(b => b.BookCategories.Any(c => categories.Contains((c.Category.Name).ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //6. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var currentDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate.Value < currentDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new { b.Title, b.EditionType, b.Price })
                .ToList();

            var output = string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}"));

            return output;
        }

        //7. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .ToArray();

            var output = string.Join(Environment.NewLine, authors.Select(a => $"{a.FirstName} {a.LastName}"));

            return output;
        }

        //8. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var titles = context.Books
                .Where(b => b.Title
                    .ToLower()
                    .Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            var output = string.Join(Environment.NewLine, titles);

            return output;
        }

        //9. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.StartsWith(input, true, CultureInfo.InvariantCulture))
                .Include(b => b.Author)
                .OrderBy(b => b.BookId)
                .Select(b => new { Title = b.Title, AuthorName = $"{b.Author.FirstName} {b.Author.LastName}" })
                .ToArray();

            var output = string.Join(Environment.NewLine, books.Select(b => $"{b.Title} ({b.AuthorName})"));

            return output;
        }

        //10. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksCount = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return booksCount;
        }

        //11. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Include(a => a.Books)
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    CopiesCount = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.CopiesCount)
                .ToArray();

            var output = string.Join(Environment.NewLine, authors.Select(a => $"{a.FirstName} {a.LastName} - {a.CopiesCount}"));

            return output;
        }

        //12. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var profitByCategory = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks
                        .Sum(cb => cb.Book.Price * cb.Book.Copies)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .ToArray();

            var output = string.Join(Environment.NewLine, profitByCategory.Select(p => $"{p.Name} ${p.Profit:F2}"));

            return output;
        }

        //13. Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var mostRecentBooks = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                        .Select(cb => new
                        {
                            cb.Book.Title,
                            cb.Book.ReleaseDate
                        })
                        .OrderByDescending(b => b.ReleaseDate)
                        .Take(3)
                        .ToList()
                })
                .OrderBy(c => c.Name)
                .ToList();

            var output = new StringBuilder();

            foreach (var mrb in mostRecentBooks)
            {
                output.Append($"--{mrb.Name}" + Environment.NewLine);

                foreach (var book in mrb.Books)
                {
                    output.Append($"{book.Title} ({book.ReleaseDate.Value.Year})" + Environment.NewLine);
                }
            }

            return output.ToString();
        }

        //14. Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var b in books)
            {
                b.Price += 5m;
            }

            context.SaveChanges();
        }

        //15. Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            context.Books.RemoveRange(books);
            context.SaveChanges();

            return books.Count();
        }
    }
}
