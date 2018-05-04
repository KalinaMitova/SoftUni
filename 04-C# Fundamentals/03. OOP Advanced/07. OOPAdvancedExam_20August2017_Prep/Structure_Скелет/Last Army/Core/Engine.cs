using System;

public class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;
    private GameController gameController;

    public Engine(IReader reader, IWriter writer, GameController gameController)
    {
        this.reader = reader;
        this.writer = writer;
        this.gameController = gameController;
    }

    public void Run()
    {
        var input = reader.ReadLine();

        while (!input.Equals("Enough! Pull back!"))
        {
            try
            {
                gameController.GiveInputToGameController(input);
            }
            catch (ArgumentException arg)
            {
                writer.AppendLine(arg.Message);
            }
            input = reader.ReadLine();
        }

        gameController.RequestResult();
        writer.WriteAllText();
    }
}