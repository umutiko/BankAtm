using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAtm
{
    class Program
    {
        static void Main(string[] args)
        {
            void ShowMenu()
            {
                
                Console.WriteLine("Brave ATM Welcome :)");
                Console.WriteLine("---------------------");
                Console.WriteLine("Please select your transaction");
                Console.WriteLine("1 - Withdraw Money");
                Console.WriteLine("2 - Deposit Money");
            }

            Console.WriteLine("Press a key to get started");
            Console.ReadLine();
            
            int[] accounts = { 2500, 1200, 6000, 10000, 7450, 4569 };
            string repeat;
            int processNumber;
            do
            {
                ShowMenu();
                processNumber = Convert.ToInt32(Console.ReadLine());
                Process();
                Console.WriteLine("Do you want to take another action ? (Y/N)");
                repeat = Console.ReadLine();
            }
            while (repeat == "y" || repeat == "Y");

            void Process()
            {
                
                Console.WriteLine("Choose an account  :");
                ShowAccounts();

                int accountNumber = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the amount");
                int amount = Convert.ToInt32(Console.ReadLine());

                switch (processNumber)
                {
                    case 1:
                        MakeADeposit(accountNumber, amount, ProcessType.WithdrawMoney);
                        break;
                    case 2:
                        MakeADeposit(accountNumber, amount, ProcessType.DepositMoney);
                        break;

                }

            }
            void MakeADeposit(int accountNumber, int amount, ProcessType processType)
            {
                for (int i = 1; i <= accounts.Length; i++)
                {
                    if (i == accountNumber)
                    {
                        int account = accounts[i - 1];
                        account = processType == ProcessType.WithdrawMoney ? account - amount : processType == ProcessType.DepositMoney ? account + amount : account;

                        Console.WriteLine("Your transaction is in progress,please wait...");
                        System.Threading.Thread.Sleep(1500);
                        if (account >= 0)
                        {
                            accounts[i - 1] = account;
                            ShowAccounts(accountNumber);
                        }
                        else
                        {
                            Console.WriteLine("You don't have enough funds !");
                            ShowAccounts(accountNumber);
                        }

                    }
                }

            }

            void ShowAccounts(int index = 0)
            {
                if (index > 0)
                {
                    Console.WriteLine("Account");
                    Console.WriteLine("--------------");
                    for (int i = 1; i <= accounts.Length; i++)
                    {
                        if (index == i)
                            Console.WriteLine($"Account Number: {i} | Available Balance: {accounts[i - 1]}");
                    }
                }
                else
                {
                    Console.WriteLine("Accounts");
                    Console.WriteLine("--------------");
                    for (int i = 1; i <= accounts.Length; i++)
                    {
                        Console.WriteLine($"Account Number: {i} | Available Balance: {accounts[i - 1]}");
                    }
                }

            }

        }
        enum ProcessType
        {
            WithdrawMoney,
            DepositMoney
        }
    }
}
