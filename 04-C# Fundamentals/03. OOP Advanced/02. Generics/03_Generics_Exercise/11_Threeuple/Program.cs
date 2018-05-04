using System;

public class Program
{
    public static void Main()
    {
        string[] firstLine = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        string fullName = firstLine[0] + " " + firstLine[1];
        string address = firstLine[2];
        string town = firstLine[3];

        string[] secondLine = Console.ReadLine().Split();
        string name = secondLine[0];
        int liters = int.Parse(secondLine[1]);
        bool isDrunk = secondLine[2] == "drunk" ? true : false;

        string[] thirdLine = Console.ReadLine().Split();
        string ownerName = thirdLine[0];
        double balance = double.Parse(thirdLine[1]);
        string bankName = thirdLine[2];

        var firstTuple = new Threeuple<string, string, string>(fullName, address, town);
        var secondTuple = new Threeuple<string, int, bool>(name, liters, isDrunk);
        var thirdTuple = new Threeuple<string, double, string>(ownerName, balance, bankName);

        Console.WriteLine(firstTuple);
        Console.WriteLine(secondTuple);
        Console.WriteLine(thirdTuple);
    }
}