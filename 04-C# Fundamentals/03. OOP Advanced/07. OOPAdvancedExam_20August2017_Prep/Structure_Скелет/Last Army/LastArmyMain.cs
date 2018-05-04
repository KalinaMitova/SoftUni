using System;
using System.Text;

namespace Last_Army
{
    class LastArmyMain
    {
        static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            GameController gameController = new GameController(writer);

            IEngine engine = new Engine(reader, writer, gameController);
            engine.Run();
        }
    }
}