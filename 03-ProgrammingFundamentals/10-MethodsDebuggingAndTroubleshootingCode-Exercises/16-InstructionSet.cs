using System;
using System.Numerics;

class InstructionSet_broken
{
    static void Main()
    {
        string opCode = Console.ReadLine();

        string[] codeArgs = opCode.Split(' ');

        while (codeArgs[0] != "END")
        {
            BigInteger result = 0;
            switch (codeArgs[0])
            {
                case "INC":
                {
                    int operandOne = int.Parse(codeArgs[1]);
                    result = (BigInteger)operandOne + 1;
                    break;
                }
                case "DEC":
                {
                    int operandOne = int.Parse(codeArgs[1]);
                    result = (BigInteger)operandOne - 1;
                    break;
                }
                case "ADD":
                {
                    int operandOne = int.Parse(codeArgs[1]);
                    int operandTwo = int.Parse(codeArgs[2]);
                    result = (BigInteger)operandOne + operandTwo;
                    break;
                }
                case "MLA":
                {
                    int operandOne = int.Parse(codeArgs[1]);
                    int operandTwo = int.Parse(codeArgs[2]);
                    result = (BigInteger)operandOne * operandTwo;
                    break;
                }
            }

            Console.WriteLine(result);

            opCode = Console.ReadLine();
            codeArgs = opCode.Split(' ');
        }
    }
}