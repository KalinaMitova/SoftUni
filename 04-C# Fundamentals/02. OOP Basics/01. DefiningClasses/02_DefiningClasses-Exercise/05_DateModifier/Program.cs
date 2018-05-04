using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[] firstDateInput = Console.ReadLine().Split()
            .Select(int.Parse).ToArray();

        int[] secondDateInput = Console.ReadLine().Split()
            .Select(int.Parse).ToArray();

        DateTime firstDate = new DateTime(firstDateInput[0], firstDateInput[1], firstDateInput[2]);
        DateTime secondDate = new DateTime(secondDateInput[0], secondDateInput[1], secondDateInput[2]);

        DateModifier dateModifier = new DateModifier(firstDate, secondDate);

        Console.WriteLine(dateModifier.DateDiff());
    }
}