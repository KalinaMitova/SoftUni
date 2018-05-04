using System;
using System.Text;

public class Book
{
    private string title;
    private string author;
    private decimal price;

    public virtual string Title
    {
        get { return title; }
        set
        {
            if(value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }

            title = value;
        }
    }
    
    public virtual string Author
    {
        get { return author; }
        set
        {            
            string[] names = value.Split(" ".ToCharArray(), StringSplitOptions.None);

            if(names.Length == 2)
            {
                string lastName = names[1];

                if (char.IsDigit(lastName[0]))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }

            author = value;
        }
    }
    
    public virtual decimal Price
    {
        get { return price; }
        set
        {
            if(value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }

            price = value;
        }
    }

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public override string ToString()
    {
        var resultBuilder = new StringBuilder();

        resultBuilder.AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Title: {this.Title}")
            .AppendLine($"Author: {this.Author}")
            .AppendLine($"Price: {this.Price:f2}");

        string result = resultBuilder.ToString().TrimEnd();

        return result;
    }
}