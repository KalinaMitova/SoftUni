using BashSoftProgram.Files.Contracts;
using BashSoftProgram.IO.Contracts;
using BashSoftProgram.Repository.Contracts;

namespace BashSoftProgram
{
    public class Launcher
    {
        public static void Main()
        {
            IContentComparer tester = new Tester();
            IDirectoryManager ioManager = new IOManager();
            IDatabase repo = new StudentsRepository(new RepositoryFilter(), new RepositorySorter());

            IInterpreter currentInterpreter = new CommandInterpreter(tester, repo, ioManager);
            IReader reader = new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}
