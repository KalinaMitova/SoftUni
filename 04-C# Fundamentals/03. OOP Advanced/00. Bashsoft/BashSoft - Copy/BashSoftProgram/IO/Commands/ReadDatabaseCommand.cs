﻿namespace BashSoftProgram.IO.Commands
{
    using BashSoftProgram.Attributes;
    using BashSoftProgram.Exceptions;
    using BashSoftProgram.IO.Contracts;
    using BashSoftProgram.Repository.Contracts;

    [Alias("readdb")]
    public class ReadDatabaseCommand : Command, IExecutable
    {
        [Inject]
        private IDatabase repository;

        public ReadDatabaseCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (Data.Length != 2)
            {
                throw new InvalidCommandException(Input);
            }
            string fileName = Data[1];
            this.repository.LoadData(fileName);
        }
    }
}
