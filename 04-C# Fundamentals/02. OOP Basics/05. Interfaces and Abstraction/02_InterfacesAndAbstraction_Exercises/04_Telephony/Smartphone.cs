using System;

public class Smartphone : ICallable, IBrowsable
{
    public string Call(string phoneNumber)
    {
        ValidatePhoneNumber(phoneNumber);

        return $"Calling... {phoneNumber}";
    }

    public string Browse(string url)
    {
        ValidateURL(url);

        return $"Browsing: {url}!";
    }

    private void ValidatePhoneNumber(string phoneNumber)
    {
        foreach (var c in phoneNumber)
        {
            if (!char.IsDigit(c))
            {
                throw new ArgumentException("Invalid number!");
            }
        }
    }

    private void ValidateURL(string url)
    {
        foreach (var c in url)
        {
            if (char.IsDigit(c))
            {
                throw new ArgumentException("Invalid URL!");
            }
        }
    }
}