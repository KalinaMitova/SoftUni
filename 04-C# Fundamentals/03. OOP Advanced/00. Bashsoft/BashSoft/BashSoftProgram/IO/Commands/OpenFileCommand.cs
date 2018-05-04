namespace BashSoftProgram.IO.Commands
{
    using System.Diagnostics;
    using BashSoftProgram.Attributes;
    using BashSoftProgram.Exceptions;
    using BashSoftProgram.IO.Contracts;

    [Alias("open")]
    public class OpenFileCommand : Command, IExecutable
    {
        public OpenFileCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (Data.Length!=2)
            {
                throw new InvalidCommandException(Input);
            }
            string fileName = Data[1];
            Process.Start(SessionData.currentPath + "\\" + fileName);
        }
    }
}
