namespace BashSoftProgram
{
    using System;

    using BashSoftProgram.IO.Contracts;

    public class InputReader : IReader
    {
        private const string endCommand = "quit";
        private IInterpreter interpreter;

        public InputReader(IInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void StartReadingCommands()
        {
            OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
            string input = Console.ReadLine();

            while (!input.Equals(endCommand))
            {
                input = input.Trim();
                interpreter.InterpretCommand(input);
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                input = Console.ReadLine();
            }
           
        }
    }
}
