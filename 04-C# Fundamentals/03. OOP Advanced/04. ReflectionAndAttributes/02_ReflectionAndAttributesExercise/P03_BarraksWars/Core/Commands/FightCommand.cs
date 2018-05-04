namespace P03_BarraksWars.Core.Commands
{
    using System;

    using _03BarracksFactory.Contracts;
    using _03BarracksFactory.Core.Commands;

    public class FightCommand : Command, IExecutable
    {
        public FightCommand(string[] data) 
            : base(data)
        {

        }

        public override string Execute()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
