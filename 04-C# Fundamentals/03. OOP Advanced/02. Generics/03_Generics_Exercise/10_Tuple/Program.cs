using System;

public class Program
{
    public static void Main()
    {
        string[] firstLine = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        string fullName = firstLine[0] + " " + firstLine[1];
        string address = firstLine[2];
        
        string[] secondLine = Console.ReadLine().Split();
        string name = secondLine[0];
        int liters = int.Parse(secondLine[1]);
        
        string[] thirdLine = Console.ReadLine().Split();
        int integerNumber = int.Parse(thirdLine[0]);
        double doubleNumber = double.Parse(thirdLine[1]);

        var firstTuple = new Tuple<string, string>(fullName, address);
        var secondTuple = new Tuple<string, int>(name, liters);
        var thirdTuple = new Tuple<int, double>(integerNumber, doubleNumber);

        Console.WriteLine(firstTuple);
        Console.WriteLine(secondTuple);
        Console.WriteLine(thirdTuple);
    }
}