namespace BashSoftProgram.IO.Commands
{
    using BashSoftProgram.Attributes;
    using BashSoftProgram.Exceptions;
    using BashSoftProgram.IO.Contracts;
    using System.Linq;

    [Alias("cdrel")]
    public class ChangeRelativePathCommand : Command, IExecutable
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public ChangeRelativePathCommand(string input, string[] data) 
            : base(input, data)
        {
        }

        public override void Execute()
        {
            string relPath = string.Join(" ", Data.Skip(1));
            this.inputOutputManager.ChangeCurrentDirectoryRelative(relPath);
        }
    }
}
