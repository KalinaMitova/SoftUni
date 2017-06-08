using System;

class PriceChangeAlert
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double significanceThreshold = double.Parse(Console.ReadLine());

        double lastPrice = double.Parse(Console.ReadLine());
        for (int i = 0; i < n - 1; i++)
        {
            double currentPrice = double.Parse(Console.ReadLine());
            double differenceInPrecentage = GetDifferenceInPercentage(lastPrice, currentPrice);
            bool isSignificantDifference = CheckDifference(differenceInPrecentage, significanceThreshold);
            string message = GetMessage(currentPrice, lastPrice, differenceInPrecentage, isSignificantDifference);
            Console.WriteLine(message);
            lastPrice = currentPrice;
        }
    }

    private static string GetMessage(double currentPrice, double lastPrice, double difference, bool isSignificantDifference)
    {
        string message = "";
        if (difference == 0)
        {
            message = string.Format("NO CHANGE: {0}", currentPrice);
        }
        else if (isSignificantDifference)
        {
            message = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, difference);
        }
        else if (!isSignificantDifference && (difference > 0))
        {
            message = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, difference);
        }
        else if (!isSignificantDifference && (difference < 0))
        {
            message = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, difference);
        }
        return message;
    }

    private static bool CheckDifference(double differenceInPrecentage, double significanceThreshold)
    {
        if (Math.Abs(differenceInPrecentage) / 100 < significanceThreshold)
        {
            return true;
        }
        return false;
    }

    private static double GetDifferenceInPercentage(double lastPrice, double currentPrice)
    {
        double result = (currentPrice - lastPrice) / lastPrice * 100;
        return result;
    }
}