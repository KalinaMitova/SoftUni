using System;
using System.Linq;

public class Engine
{
    private CustomList<string> collection;

    public Engine()
    {
        this.collection = new CustomList<string>();
    }

    public void Run()
    {
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] tokens = input.Split();
            string command = tokens[0];
            string[] args = tokens.Skip(1).ToArray();

            string result = CommandParser(command, args);

            if (!string.IsNullOrEmpty(result))
            {
                Console.WriteLine(result);
            }
        }
    }

    private string CommandParser(string command, string[] args)
    {
        string output = null;

        switch (command)
        {
            case "Add":
                {
                    string element = args[0];
                    this.collection.Add(element);
                }
                break;
            case "Remove":
                {
                    int index = int.Parse(args[0]);
                    this.collection.Remove(index);
                }
                break;
            case "Contains":
                {
                    string element = args[0];
                    output = this.collection.Contains(element).ToString();
                }
                break;
            case "Swap":
                {
                    int index1 = int.Parse(args[0]);
                    int index2 = int.Parse(args[1]);
                    this.collection.Swap(index1, index2);
                }
                break;
            case "Greater":
                {
                    string element = args[0];
                    int count = this.collection.CountGreaterThan(element);
                    output = count.ToString();
                }
                break;
            case "Max":
                {
                    output = this.collection.Max();
                }
                break;
            case "Min":
                {
                    output = this.collection.Min();
                }
                break;
            case "Print":
                {
                    output = string.Join(Environment.NewLine, this.collection);
                }
                break;
        }

        return output;
    }
}