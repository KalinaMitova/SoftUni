namespace _02_SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SimpleCalculator
    {
        public static void Main()
        {
            //2 + 5 + 10 - 2 - 1
            string[] input = Console.ReadLine().Split(' ');
            Stack<string> elements = new Stack<string>(input.Reverse());

            while (elements.Count() > 1)
            {
                int leftOperand = int.Parse(elements.Pop());
                string operatorSign = elements.Pop();
                int rightOperand = int.Parse(elements.Pop());

                switch (operatorSign)
                {
                    case "+": elements.Push((leftOperand + rightOperand).ToString()); break;
                    case "-": elements.Push((leftOperand - rightOperand).ToString()); break;
                }
            }

            string result = elements.Pop();

            Console.WriteLine(result);
        }
    }
}
