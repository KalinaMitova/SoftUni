namespace BashSoftProgram.IO.Commands
{
    using BashSoftProgram.Attributes;
    using BashSoftProgram.Exceptions;
    using BashSoftProgram.IO.Contracts;

    [Alias("mkdir")]
    public class MakeDirectoryCommand : Command, IExecutable
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public MakeDirectoryCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (Data.Length != 2)
            {
                throw new InvalidCommandException(Input);
            }

            string folderName = Data[1];
            this.inputOutputManager.CreateDirectoryInCurrentFolder(folderName);
        }
    }
}
