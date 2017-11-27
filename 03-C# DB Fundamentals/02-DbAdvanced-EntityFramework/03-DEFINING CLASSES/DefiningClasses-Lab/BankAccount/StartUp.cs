using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = input.Split();

                string cmdType = cmdArgs[0];
                switch (cmdType)
                {
                    case "Create":
                        Create(cmdArgs, accounts);
                        break;
                    case "Deposit":
                        Deposit(cmdArgs, accounts);
                        break;
                    case "Withdraw":
                        Withdraw(cmdArgs, accounts);
                        break;
                    case "Print":
                        Print(cmdArgs, accounts);
                        break;
                }
            }            
        }

        private static void Print(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
        {
            int id = int.Parse(cmdArgs[1]);
            if (accounts.ContainsKey(id))
            {
                BankAccount acc = accounts.FirstOrDefault(ba => ba.Key == id).Value;
                Console.WriteLine($"Account ID {acc.ID}, balance = {acc.Balance:f2}");
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Withdraw(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
        {
            int id = int.Parse(cmdArgs[1]);
            decimal amount = decimal.Parse(cmdArgs[2]);

            if (accounts.ContainsKey(id))
            {
                BankAccount acc = accounts.FirstOrDefault(ba => ba.Key == id).Value;
                if(acc.Balance < amount)
                {
                    Console.WriteLine("Insufficient balance");
                }
                else
                {
                    acc.Withdraw(amount);
                }
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Deposit(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
        {
            int id = int.Parse(cmdArgs[1]);
            decimal amount = decimal.Parse(cmdArgs[2]);

            if (accounts.ContainsKey(id))
            {
                BankAccount acc = accounts.FirstOrDefault(ba => ba.Key == id).Value;
                acc.Deposit(amount);
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Create(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
        {
            int id = int.Parse(cmdArgs[1]);
            if(accounts.ContainsKey(id))
            {
                Console.WriteLine("Account already exists");
            }
            else
            {
                BankAccount acc = new BankAccount();
                acc.ID = id;
                accounts.Add(id, acc);
            }
        }
    }
}
