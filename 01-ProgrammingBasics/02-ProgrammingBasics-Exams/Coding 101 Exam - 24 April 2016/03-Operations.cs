using System;

namespace _03_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());
            string operatorInit = Console.ReadLine();

            double result = 0.0;
            string oddOrEven = "";

            switch (operatorInit)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    result = num1 / (double)num2;
                    break;
                case "%":
                    result = num1 % (double)num2;
                    break;
                default:
                    Console.WriteLine("unknown operator");
                    return;
            }

            if (operatorInit == "+" || operatorInit == "-" || operatorInit == "*")
            {
                oddOrEven = result % 2 == 0 ? "even" : "odd";
                Console.WriteLine("{0} {1} {2} = {3} - {4}", num1, operatorInit, num2, result, oddOrEven);
            }
            else
            {
                if (num1 == 0) Console.WriteLine("Cannot divide {0} by zero", num2);
                else if (num2 == 0) Console.WriteLine("Cannot divide {0} by zero", num1);
                else
                    if (operatorInit == "/") Console.WriteLine("{0} / {1} = {2:F2}", num1, num2, result);
                else Console.WriteLine("{0} % {1} = {2}", num1, num2, result);
            }
        }
    }
}
