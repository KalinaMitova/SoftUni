namespace BashSoftProgram.IO.Commands
{
    using BashSoftProgram.Attributes;
    using BashSoftProgram.Exceptions;
    using BashSoftProgram.IO.Contracts;
    using System.Linq;

    [Alias("cdabs")]
    public class ChangeAbsolutePathCommand : Command, IExecutable
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public ChangeAbsolutePathCommand(string input, string[] data) 
            : base(input, data)
        {
        }

        public override void Execute()
        {            
            string absolutePath = string.Join(" ", Data.Skip(1));
            this.inputOutputManager.ChangeCurrentDirectoryAbsolute(absolutePath);            
        }
    }
}
